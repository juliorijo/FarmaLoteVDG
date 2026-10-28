using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FarmaLoteVDG
{
    internal sealed class LotEditorForm : Form
    {
        private readonly TextBox medicineTextBox;
        private readonly TextBox lotTextBox;
        private readonly NumericUpDown quantityInput;
        private readonly DateTimePicker expiryInput;
        private readonly ErrorProvider errors;
        private readonly IContainer components = new Container();
        private readonly MedicineLot original;
        private readonly IEnumerable<MedicineLot> existingLots;
        private readonly string initialMedicine;
        private readonly string initialLotNumber;
        private readonly string initialQuantityText;
        private readonly DateTime initialExpiry;

        public LotEditorForm(MedicineLot lot, IEnumerable<MedicineLot> lots)
        {
            original = lot;
            existingLots = lots;
            Text = lot == null ? "Nuevo lote" : "Editar lote";
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(23, 59, 83);
            BackColor = Color.White;
            AutoScaleDimensions = new SizeF(7F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 590);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;

            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(32, 20, 40, 20),
                ColumnCount = 1,
                RowCount = 11
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            int[] heights = { 86, 28, 52, 28, 52, 28, 52, 28, 52, 70, 56 };
            foreach (int height in heights)
                layout.RowStyles.Add(new RowStyle(SizeType.Absolute, height));
            Label heading = new Label
            {
                Text = lot == null ? "Nuevo lote" : "Editar lote",
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            medicineTextBox = new TextBox { Name = "medicineTextBox", Dock = DockStyle.Fill, MaxLength = 120, TabIndex = 0,
                Font = new Font("Segoe UI", 13F), BorderStyle = BorderStyle.FixedSingle, BackColor = Color.FromArgb(247, 250, 253) };
            lotTextBox = new TextBox { Name = "lotTextBox", Dock = DockStyle.Fill, MaxLength = 60, TabIndex = 1,
                Font = new Font("Segoe UI", 13F), BorderStyle = BorderStyle.FixedSingle, BackColor = Color.FromArgb(247, 250, 253) };
            quantityInput = new NumericUpDown
            {
                Name = "quantityInput",
                Dock = DockStyle.Left,
                Width = 250,
                Font = new Font("Segoe UI", 13F),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(247, 250, 253),
                Minimum = 0,
                Maximum = int.MaxValue,
                DecimalPlaces = 0,
                ThousandsSeparator = true,
                TabIndex = 2
            };
            expiryInput = new DateTimePicker
            {
                Name = "expiryInput",
                Dock = DockStyle.Left,
                Width = 250,
                Font = new Font("Segoe UI", 13F),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Value = DateTime.Today.AddMonths(6),
                TabIndex = 3
            };
            layout.Controls.Add(heading, 0, 0);
            AddField(layout, "Medicamento", medicineTextBox, 1);
            AddField(layout, "Número de lote", lotTextBox, 3);
            AddField(layout, "Cantidad disponible (unidades)", quantityInput, 5);
            AddField(layout, "Fecha de vencimiento", expiryInput, 7);
            layout.Controls.Add(new Label
            {
                Text = "Completa todos los campos con una cantidad entera mayor que cero.\nPuedes registrar fechas pasadas para identificar lotes vencidos.",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.5F),
                Padding = new Padding(12, 10, 8, 8),
                Margin = new Padding(0, 0, 0, 12),
                BackColor = Color.FromArgb(242, 248, 231),
                ForeColor = Color.FromArgb(63, 91, 23),
                AutoSize = false
            }, 0, 9);
            FlowLayoutPanel actions = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Margin = new Padding(0, 6, 0, 0)
            };
            Button cancelButton = new Button
            {
                Text = "Cancelar",
                DialogResult = DialogResult.Cancel,
                Size = new Size(112, 42),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                Margin = new Padding(10, 0, 0, 0),
                TabIndex = 1,
                CausesValidation = false
            };
            Button saveButton = new Button
            {
                Name = "saveButton",
                Text = "&Guardar",
                Size = new Size(144, 42),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 113, 187),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(0),
                TabIndex = 0
            };
            cancelButton.FlatAppearance.BorderColor = Color.FromArgb(207, 224, 238);
            cancelButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 245, 253);
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 91, 151);
            saveButton.Click += SaveButton_Click;
            actions.Controls.Add(cancelButton);
            actions.Controls.Add(saveButton);
            layout.Controls.Add(actions, 0, 10);
            Controls.Add(layout);
            AcceptButton = saveButton;
            CancelButton = cancelButton;
            errors = new ErrorProvider(components) { ContainerControl = this, BlinkStyle = ErrorBlinkStyle.NeverBlink };

            if (lot != null)
            {
                medicineTextBox.Text = lot.Medicine;
                lotTextBox.Text = lot.LotNumber;
                quantityInput.Value = lot.Quantity;
                expiryInput.Value = lot.Expiry;
            }
            initialMedicine = medicineTextBox.Text;
            initialLotNumber = lotTextBox.Text;
            initialQuantityText = quantityInput.Text;
            initialExpiry = expiryInput.Value;
            Shown += delegate { medicineTextBox.Focus(); };
        }

        public MedicineLot Result { get; private set; }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            bool hasChanges = medicineTextBox.Text != initialMedicine
                || lotTextBox.Text != initialLotNumber
                || quantityInput.Text != initialQuantityText
                || expiryInput.Value != initialExpiry;
            if (Result == null && hasChanges && MessageBox.Show(this,
                "Hay cambios sin guardar en este lote.\n\n¿Descartar los cambios y cerrar?",
                "Cambios sin guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                e.Cancel = true;
                DialogResult = DialogResult.None;
            }
            base.OnFormClosing(e);
        }

        private static void AddField(TableLayoutPanel layout, string label, Control input, int row)
        {
            input.AccessibleName = label;
            layout.Controls.Add(new Label { Text = label, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(0), ForeColor = Color.FromArgb(89, 111, 127) }, 0, row);
            layout.Controls.Add(input, 0, row + 1);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            errors.Clear();
            string medicine = medicineTextBox.Text.Trim();
            string number = lotTextBox.Text.Trim();
            Control firstInvalid = null;
            if (medicine.Length == 0)
            {
                errors.SetError(medicineTextBox, "Escribe el nombre del medicamento.");
                firstInvalid = medicineTextBox;
            }
            if (number.Length == 0)
            {
                errors.SetError(lotTextBox, "Escribe el número de lote.");
                firstInvalid = firstInvalid ?? lotTextBox;
            }
            if (quantityInput.Value <= 0 || quantityInput.Value != decimal.Truncate(quantityInput.Value))
            {
                errors.SetError(quantityInput, "Escribe una cantidad entera mayor que cero.");
                firstInvalid = firstInvalid ?? quantityInput;
            }
            if (existingLots.Any(lot => !ReferenceEquals(lot, original)
                && string.Equals(lot.Medicine, medicine, StringComparison.CurrentCultureIgnoreCase)
                && string.Equals(lot.LotNumber, number, StringComparison.CurrentCultureIgnoreCase)))
            {
                errors.SetError(lotTextBox, "Ya existe ese lote para este medicamento. Edita el registro existente.");
                firstInvalid = firstInvalid ?? lotTextBox;
            }
            if (firstInvalid != null)
            {
                firstInvalid.Focus();
                return;
            }
            Result = new MedicineLot(medicine, number, decimal.ToInt32(quantityInput.Value), expiryInput.Value.Date);
            DialogResult = DialogResult.OK;
            Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                components.Dispose();
            base.Dispose(disposing);
        }
    }
}
