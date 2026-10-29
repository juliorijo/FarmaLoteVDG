using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace FarmaLoteVDG
{
    public partial class Form1 : Form
    {
        private readonly List<MedicineLot> lots = new List<MedicineLot>();
        private readonly BindingSource lotSource = new BindingSource();
        private bool lastAccessibilityAnnouncementSucceeded;

        public Form1()
        {
            InitializeComponent();
            components.Add(lotSource);
            inventoryGrid.AutoGenerateColumns = false;
            inventoryGrid.DataSource = lotSource;
            inventoryGrid.ShowCellToolTips = true;
            activityLabel.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            searchTextBox.TextChanged += delegate { RefreshInventory(null); };
            newButton.Click += NewButton_Click;
            editButton.Click += editButton_Click_1;
            retireButton.Click += RetireButton_Click;
            inventoryGrid.SelectionChanged += delegate { UpdateSelection(); };
            inventoryGrid.CellFormatting += InventoryGrid_CellFormatting;
            inventoryGrid.CellPainting += InventoryGrid_CellPainting;
            Resize += delegate { AdaptLayout(); };
            inventoryGrid.CellDoubleClick += delegate (object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                    editButton_Click_1(sender, EventArgs.Empty);
            };
            refreshTimer.Tick += delegate { RefreshInventory(SelectedLot); };

            LoadDataFromDatabase();
            RefreshInventory(null);
            AdaptLayout();
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                lots.Clear();
                lots.AddRange(ConexionTest.ListarLotes());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error al cargar los datos de la base de datos:\n" + ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdaptLayout()
        {
            bool compact = ClientSize.Width < 1060 * DeviceDpi / 96;
            navigationPanel.Visible = !compact;
            shellLayout.ColumnStyles[0].Width = compact ? 0 : 200 * DeviceDpi / 96;
            mainLayout.RowStyles[0].Height = (compact ? 110 : 122) * DeviceDpi / 96;
            mainLayout.RowStyles[2].Height = (compact ? 44 : 52) * DeviceDpi / 96;
            mainLayout.RowStyles[3].Height = (compact ? 80 : 94) * DeviceDpi / 96;
            mainLayout.RowStyles[4].Height = (compact ? 32 : 38) * DeviceDpi / 96;
            int rowHeight = (compact ? 48 : 58) * DeviceDpi / 96;
            if (inventoryGrid.RowTemplate.Height != rowHeight)
            {
                inventoryGrid.RowTemplate.Height = rowHeight;
                foreach (DataGridViewRow row in inventoryGrid.Rows)
                    row.Height = rowHeight;
            }
            if (compact)
            {
                if (demoLabel.Parent != mainLayout)
                    mainLayout.Controls.Add(demoLabel, 0, 1);
                demoLabel.Dock = DockStyle.Fill;
                demoLabel.Margin = new Padding(36, 0, 36, 0);
                demoLabel.ForeColor = Color.FromArgb(89, 111, 127);
                demoLabel.Text = "Conectado a Base de Datos SQL Server.";
                mainLayout.RowStyles[1].Height = 32 * DeviceDpi / 96;
            }
            else
            {
                if (demoLabel.Parent != navigationPanel)
                    navigationPanel.Controls.Add(demoLabel);
                demoLabel.Dock = DockStyle.None;
                demoLabel.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                demoLabel.Bounds = new Rectangle(24 * DeviceDpi / 96,
                    navigationPanel.Height - 140 * DeviceDpi / 96, 152 * DeviceDpi / 96, 112 * DeviceDpi / 96);
                demoLabel.ForeColor = Color.FromArgb(226, 243, 255);
                demoLabel.Text = "Conectado a SQL Server.\nFarmaLoteVDG Activo.\n\nLos cambios se guardan\nen la base de datos.";
                mainLayout.RowStyles[1].Height = 0;
            }
        }

        private MedicineLot SelectedLot
        {
            get { return inventoryGrid.CurrentRow == null ? null : inventoryGrid.CurrentRow.DataBoundItem as MedicineLot; }
        }

        private void RefreshInventory(MedicineLot preferredSelection)
        {
            string query = searchTextBox.Text.Trim();
            List<MedicineLot> visibleLots = lots
                .Where(lot => lot.Medicine.IndexOf(query, StringComparison.CurrentCultureIgnoreCase) >= 0
                    || lot.LotNumber.IndexOf(query, StringComparison.CurrentCultureIgnoreCase) >= 0)
                .OrderBy(lot => lot.Expiry)
                .ThenBy(lot => lot.Medicine)
                .ToList();
            lotSource.DataSource = visibleLots;
            foreach (DataGridViewRow row in inventoryGrid.Rows)
            {
                MedicineLot lot = (MedicineLot)row.DataBoundItem;
                DataGridViewCell medicineCell = row.Cells[0];
                medicineCell.ToolTipText = lot.Medicine;
            }
            if (preferredSelection != null)
            {
                foreach (DataGridViewRow row in inventoryGrid.Rows)
                {
                    if (ReferenceEquals(row.DataBoundItem, preferredSelection))
                    {
                        inventoryGrid.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
            int expired = lots.Count(lot => lot.Expiry.Date < DateTime.Today);
            int nearExpiry = lots.Count(lot => lot.Expiry.Date >= DateTime.Today
                && lot.Expiry.Date <= DateTime.Today.AddDays(30));
            expiryLabel.Text = "1 vencidos    |    2 por vencer en 30 días";
            resultLabel.Text = string.Format("{0} de {1} lotes visibles", visibleLots.Count, lots.Count);
            emptyLabel.Visible = visibleLots.Count == 0;
            emptyLabel.Text = lots.Count == 0
                ? "No hay lotes en la base de datos. Usa Nuevo para registrar el primero."
                : "No se encontraron lotes. Cambia o borra la búsqueda.";
            UpdateSelection();
        }

        private void UpdateSelection()
        {
            MedicineLot selected = SelectedLot;
            editButton.Enabled = selected != null;
            retireButton.Enabled = selected != null;
            selectionLabel.Text = selected == null
                ? "Selecciona un lote para editarlo o retirarlo."
                : string.Format("Seleccionado: {0} / {1}", selected.Medicine, selected.LotNumber);
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            using (LotEditorForm editor = new LotEditorForm(null, lots))
            {
                if (editor.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    ConexionTest.CrearLote(
                        editor.Result.Medicine,
                        "General",
                        true,
                        editor.Result.LotNumber,
                        editor.Result.Expiry,
                        editor.Result.Quantity
                    );

                    LoadDataFromDatabase();
                    RefreshInventory(editor.Result);
                    AnnounceActivity("Lote registrado en la base de datos.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se pudo guardar en la base de datos.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editButton_Click_1(object sender, EventArgs e)
        {
            MedicineLot selected = SelectedLot;

            if (selected == null)
                return;

            using (LotEditorForm editor = new LotEditorForm(selected, lots))
            {
                if (editor.ShowDialog(this) != DialogResult.OK)
                    return;

                MedicineLot result = editor.Result;

                DialogResult confirmation = MessageBox.Show(
                    this,
                    "¿Deseas aplicar los siguientes cambios en la base de datos?\n\n"
                    + "Medicamento: " + result.Medicine + "\n"
                    + "Lote: " + result.LotNumber + "\n"
                    + "Cantidad: " + result.Quantity + "\n"
                    + "Vencimiento: " + result.Expiry.ToString("dd/MM/yyyy"),
                    "Confirmar cambios",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (confirmation != DialogResult.Yes)
                {
                    AnnounceActivity("Cambios cancelados.");
                    return;
                }

                try
                {
                    MedicineLot loteActualizado = new MedicineLot(
                        result.Medicine,
                        result.LotNumber,
                        result.Quantity,
                        result.Expiry);

                    loteActualizado.Id = selected.Id;

                    ConexionTest.ActualizarLote(loteActualizado);

                    LoadDataFromDatabase();
                    RefreshInventory(selected);

                    AnnounceActivity("Cambios aplicados correctamente en la base de datos.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        this,
                        "No fue posible aplicar los cambios en la base de datos.\n\n"
                        + ex.Message,
                        "Error al actualizar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void RetireButton_Click(object sender, EventArgs e)
        {
            MedicineLot selected = SelectedLot;
            if (selected == null)
                return;

            string message = string.Format(
                "¿Retirar el lote completo de la base de datos?\n\nMedicamento: {0}\nLote: {1}\nCantidad: {2} unidades\n\nEl lote pasará a estado inactivo.",
                selected.Medicine, selected.LotNumber, selected.Quantity);

            if (MessageBox.Show(this, message, "Confirmar retiro", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            try
            {
                ConexionTest.RetirarLote(selected.Id);
                LoadDataFromDatabase();
                RefreshInventory(null);
                AnnounceActivity("Lote retirado (desactivado) en la base de datos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pudo retirar el lote.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AnnounceActivity(string message)
        {
            activityLabel.Text = message;
            activityLabel.AccessibleName = message;
            lastAccessibilityAnnouncementSucceeded = activityLabel.AccessibilityObject.RaiseAutomationNotification(
                System.Windows.Forms.Automation.AutomationNotificationKind.ActionCompleted,
                System.Windows.Forms.Automation.AutomationNotificationProcessing.MostRecent, message);
            if (!lastAccessibilityAnnouncementSucceeded)
                lastAccessibilityAnnouncementSucceeded = activityLabel.AccessibilityObject.RaiseLiveRegionChanged();
        }

        private void InventoryGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || inventoryGrid.Columns[e.ColumnIndex].DataPropertyName != "Status")
                return;
            MedicineLot lot = inventoryGrid.Rows[e.RowIndex].DataBoundItem as MedicineLot;
            if (lot == null)
                return;
            if (lot.Expiry.Date < DateTime.Today)
            {
                e.CellStyle.BackColor = Color.FromArgb(253, 232, 232);
                e.CellStyle.ForeColor = Color.FromArgb(156, 38, 38);
            }
            else if (lot.Expiry.Date <= DateTime.Today.AddDays(30))
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 244, 211);
                e.CellStyle.ForeColor = Color.FromArgb(116, 77, 0);
            }
            else
            {
                e.CellStyle.BackColor = Color.FromArgb(238, 247, 222);
                e.CellStyle.ForeColor = Color.FromArgb(63, 91, 23);
            }
        }

        private void InventoryGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.ColumnIndex == 0 && (e.State & DataGridViewElementStates.Selected) != 0)
            {
                e.Paint(e.ClipBounds, e.PaintParts);
                using (SolidBrush accent = new SolidBrush(Color.FromArgb(134, 189, 64)))
                    e.Graphics.FillRectangle(accent, e.CellBounds.Left, e.CellBounds.Top, 3 * DeviceDpi / 96, e.CellBounds.Height);
                e.Handled = true;
                return;
            }
            if (inventoryGrid.Columns[e.ColumnIndex].DataPropertyName != "Status")
                return;
            Color rowBackground = (e.State & DataGridViewElementStates.Selected) != 0
                ? inventoryGrid.DefaultCellStyle.SelectionBackColor : Color.White;
            using (SolidBrush rowBrush = new SolidBrush(rowBackground))
                e.Graphics.FillRectangle(rowBrush, Rectangle.Intersect(e.CellBounds, e.ClipBounds));
            e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);
            string text = Convert.ToString(e.FormattedValue);
            int height = 28 * DeviceDpi / 96;
            int width = Math.Min(104 * DeviceDpi / 96, e.CellBounds.Width - 8);
            Rectangle badge = new Rectangle(e.CellBounds.Left + (e.CellBounds.Width - width) / 2,
                e.CellBounds.Top + (e.CellBounds.Height - height) / 2, width, height);
            GraphicsState state = e.Graphics.Save();
            e.Graphics.SetClip(e.ClipBounds, CombineMode.Intersect);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = new GraphicsPath())
            using (SolidBrush background = new SolidBrush(e.CellStyle.BackColor))
            {
                int diameter = height;
                path.AddArc(badge.Left, badge.Top, diameter, diameter, 90, 180);
                path.AddArc(badge.Right - diameter, badge.Top, diameter, diameter, 270, 180);
                path.CloseFigure();
                e.Graphics.FillPath(background, path);
            }
            TextRenderer.DrawText(e.Graphics, text, e.CellStyle.Font, badge, e.CellStyle.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            e.Graphics.Restore(state);
            e.Handled = true;
        }

        private void newButton_Click_1(object sender, EventArgs e)
        {
            NewButton_Click(sender, e);
        }

        private void logoPictureBox_Click(object sender, EventArgs e)
        {

        }
    }

    public sealed class MedicineLot
    {
        public MedicineLot(string medicine, string lotNumber, int quantity, DateTime expiry)
        {
            Medicine = medicine;
            LotNumber = lotNumber;
            Quantity = quantity;
            Expiry = expiry.Date;
        }

        public int Id { get; set; }
        public string Medicine
        {
            get; set;
        }
        public string LotNumber { get; set; }
        public int Quantity { get; set; }
        public DateTime Expiry { get; set; }
        public string Status
        {
            get
            {
                if (Expiry.Date < DateTime.Today)
                    return "Vencido";
                return Expiry.Date <= DateTime.Today.AddDays(30) ? "Por vencer" : "Vigente";
            }
        }
        
    }
}
