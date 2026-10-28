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
            editButton.Click += EditButton_Click;
            retireButton.Click += RetireButton_Click;
            inventoryGrid.SelectionChanged += delegate { UpdateSelection(); };
            inventoryGrid.CellFormatting += InventoryGrid_CellFormatting;
            inventoryGrid.CellPainting += InventoryGrid_CellPainting;
            Resize += delegate { AdaptLayout(); };
            inventoryGrid.CellDoubleClick += delegate(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                    EditButton_Click(sender, EventArgs.Empty);
            };
            refreshTimer.Tick += delegate { RefreshInventory(SelectedLot); };
            LoadDemoLots();
            RefreshInventory(null);
            AdaptLayout();
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
                demoLabel.Text = "Demostración en memoria. Sin base de datos. Los cambios se pierden al cerrar.";
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
                demoLabel.Text = "Datos locales en memoria.\nSin base de datos.\n\nLos cambios se pierden\nal cerrar la aplicación.";
                mainLayout.RowStyles[1].Height = 0;
            }
        }

        private MedicineLot SelectedLot
        {
            get { return inventoryGrid.CurrentRow == null ? null : inventoryGrid.CurrentRow.DataBoundItem as MedicineLot; }
        }

        private void LoadDemoLots()
        {
            DateTime today = DateTime.Today;
            lots.Add(new MedicineLot("Paracetamol 500 mg", "PAR-2401", 120, today.AddMonths(8)));
            lots.Add(new MedicineLot("Amoxicilina 500 mg", "AMX-0312", 48, today.AddDays(18)));
            lots.Add(new MedicineLot("Loratadina 10 mg", "LOR-0198", 32, today.AddDays(-12)));
            lots.Add(new MedicineLot("Ibuprofeno 400 mg", "IBU-0815", 85, today.AddMonths(5)));
            lots.Add(new MedicineLot("Omeprazol 20 mg", "OME-0620", 64, today.AddDays(30)));
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
            expiryLabel.Text = string.Format("{0} vencidos   |   {1} por vencer en 30 días", expired, nearExpiry);
            resultLabel.Text = string.Format("{0} de {1} lotes visibles", visibleLots.Count, lots.Count);
            emptyLabel.Visible = visibleLots.Count == 0;
            emptyLabel.Text = lots.Count == 0
                ? "No hay lotes. Usa Nuevo para registrar el primero."
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
                lots.Add(editor.Result);
                RefreshInventory(editor.Result);
                AnnounceActivity("Lote registrado en esta sesión.");
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            MedicineLot selected = SelectedLot;
            if (selected == null)
                return;
            using (LotEditorForm editor = new LotEditorForm(selected, lots))
            {
                if (editor.ShowDialog(this) != DialogResult.OK)
                    return;
                selected.Medicine = editor.Result.Medicine;
                selected.LotNumber = editor.Result.LotNumber;
                selected.Quantity = editor.Result.Quantity;
                selected.Expiry = editor.Result.Expiry;
                RefreshInventory(selected);
                AnnounceActivity("Cambios guardados en esta sesión.");
            }
        }

        private void RetireButton_Click(object sender, EventArgs e)
        {
            MedicineLot selected = SelectedLot;
            if (selected == null)
                return;
            string message = string.Format(
                "¿Retirar el lote completo?\n\nMedicamento: {0}\nLote: {1}\nCantidad: {2} unidades\n\nSe quitará del inventario de esta sesión.",
                selected.Medicine, selected.LotNumber, selected.Quantity);
            if (MessageBox.Show(this, message, "Confirmar retiro", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;
            lots.Remove(selected);
            RefreshInventory(null);
            AnnounceActivity("Lote retirado de esta sesión.");
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
    }

    internal sealed class MedicineLot
    {
        public MedicineLot(string medicine, string lotNumber, int quantity, DateTime expiry)
        {
            Medicine = medicine;
            LotNumber = lotNumber;
            Quantity = quantity;
            Expiry = expiry.Date;
        }

        public string Medicine { get; set; }
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
