namespace FarmaLoteVDG
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.shellLayout = new System.Windows.Forms.TableLayoutPanel();
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.brandLabel = new System.Windows.Forms.Label();
            this.brandCaption = new System.Windows.Forms.Label();
            this.navigationLabel = new System.Windows.Forms.Label();
            this.navigationHint = new System.Windows.Forms.Label();
            this.workspaceLabel = new System.Windows.Forms.Label();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.demoLabel = new System.Windows.Forms.Label();
            this.expiryLabel = new System.Windows.Forms.Label();
            this.toolbar = new System.Windows.Forms.TableLayoutPanel();
            this.searchLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.retireButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.inventoryGrid = new System.Windows.Forms.DataGridView();
            this.medicineColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emptyLabel = new System.Windows.Forms.Label();
            this.selectionLabel = new System.Windows.Forms.Label();
            this.activityLabel = new System.Windows.Forms.Label();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.shellLayout.SuspendLayout();
            this.navigationPanel.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.toolbar.SuspendLayout();
            this.gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGrid)).BeginInit();
            this.SuspendLayout();
            //
            // mainLayout
            //
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowCount = 9;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mainLayout.Controls.Add(this.headerPanel, 0, 0);
            this.mainLayout.Controls.Add(this.expiryLabel, 0, 2);
            this.mainLayout.Controls.Add(this.toolbar, 0, 3);
            this.mainLayout.Controls.Add(this.resultLabel, 0, 4);
            this.mainLayout.Controls.Add(this.gridPanel, 0, 5);
            this.mainLayout.Controls.Add(this.selectionLabel, 0, 6);
            this.mainLayout.Controls.Add(this.activityLabel, 0, 7);
            this.mainLayout.Name = "mainLayout";
            //
            // shell and pharmacy navigation
            //
            this.shellLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shellLayout.ColumnCount = 2;
            this.shellLayout.RowCount = 1;
            this.shellLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.shellLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.shellLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.shellLayout.Controls.Add(this.navigationPanel, 0, 0);
            this.shellLayout.Controls.Add(this.mainLayout, 1, 0);
            this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanel.Size = new System.Drawing.Size(200, 760);
            this.navigationPanel.Margin = new System.Windows.Forms.Padding(0);
            this.navigationPanel.BackColor = System.Drawing.Color.FromArgb(0, 113, 187);
            this.navigationPanel.Controls.Add(this.brandLabel);
            this.navigationPanel.Controls.Add(this.brandCaption);
            this.navigationPanel.Controls.Add(this.navigationLabel);
            this.navigationPanel.Controls.Add(this.navigationHint);
            this.navigationPanel.Controls.Add(this.workspaceLabel);
            this.navigationPanel.Controls.Add(this.demoLabel);
            this.brandLabel.AutoSize = true;
            this.brandLabel.Location = new System.Drawing.Point(22, 32);
            this.brandLabel.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.brandLabel.ForeColor = System.Drawing.Color.White;
            this.brandLabel.Text = "FarmaLote";
            this.brandCaption.Location = new System.Drawing.Point(26, 78);
            this.brandCaption.Size = new System.Drawing.Size(150, 24);
            this.brandCaption.ForeColor = System.Drawing.Color.FromArgb(226, 243, 255);
            this.brandCaption.Text = "VDG / Gestión de lotes";
            this.navigationLabel.Location = new System.Drawing.Point(12, 144);
            this.navigationLabel.Size = new System.Drawing.Size(176, 46);
            this.navigationLabel.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.navigationLabel.BackColor = System.Drawing.Color.White;
            this.navigationLabel.ForeColor = System.Drawing.Color.FromArgb(0, 113, 187);
            this.navigationLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.navigationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.navigationLabel.Text = "Inventario";
            this.navigationHint.Location = new System.Drawing.Point(26, 204);
            this.navigationHint.Size = new System.Drawing.Size(150, 64);
            this.navigationHint.ForeColor = System.Drawing.Color.FromArgb(226, 243, 255);
            this.navigationHint.Text = "Cada lote, su cantidad\ny su vencimiento.";
            this.workspaceLabel.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom;
            this.workspaceLabel.Location = new System.Drawing.Point(24, 588);
            this.workspaceLabel.Size = new System.Drawing.Size(152, 28);
            this.workspaceLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.workspaceLabel.ForeColor = System.Drawing.Color.White;
            this.workspaceLabel.Text = "Modo demostración";
            //
            // headerPanel
            //
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.subtitleLabel);
            this.headerPanel.Controls.Add(this.logoPictureBox);
            this.headerPanel.Size = new System.Drawing.Size(1040, 122);
            this.logoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.logoPictureBox.Location = new System.Drawing.Point(740, 24);
            this.logoPictureBox.Size = new System.Drawing.Size(264, 72);
            this.logoPictureBox.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("PharmacyLogo");
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.AccessibleName = "Farmacia VDG";
            this.logoPictureBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.logoPictureBox.TabStop = false;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(23, 59, 83);
            this.titleLabel.Location = new System.Drawing.Point(32, 24);
            this.titleLabel.Text = "Inventario de lotes";
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(89, 111, 127);
            this.subtitleLabel.Location = new System.Drawing.Point(36, 82);
            this.subtitleLabel.Text = "Controla existencias y prioriza los próximos vencimientos.";
            //
            // notices
            //
            this.demoLabel.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom;
            this.demoLabel.Location = new System.Drawing.Point(24, 620);
            this.demoLabel.Size = new System.Drawing.Size(152, 112);
            this.demoLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.demoLabel.ForeColor = System.Drawing.Color.FromArgb(226, 243, 255);
            this.demoLabel.Text = "Datos locales en memoria.\nSin base de datos.\n\nLos cambios se pierden\nal cerrar la aplicación.";
            this.expiryLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expiryLabel.Margin = new System.Windows.Forms.Padding(36, 0, 36, 4);
            this.expiryLabel.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.expiryLabel.BackColor = System.Drawing.Color.FromArgb(242, 248, 231);
            this.expiryLabel.ForeColor = System.Drawing.Color.FromArgb(63, 91, 23);
            this.expiryLabel.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.expiryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // toolbar
            //
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolbar.Margin = new System.Windows.Forms.Padding(36, 14, 36, 8);
            this.toolbar.ColumnCount = 5;
            this.toolbar.RowCount = 2;
            this.toolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.toolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.toolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.toolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.toolbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.toolbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolbar.Controls.Add(this.searchLabel, 1, 0);
            this.toolbar.Controls.Add(this.searchTextBox, 1, 1);
            this.toolbar.Controls.Add(this.newButton, 2, 1);
            this.toolbar.Controls.Add(this.editButton, 3, 1);
            this.toolbar.Controls.Add(this.retireButton, 4, 1);
            this.searchLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchLabel.Margin = new System.Windows.Forms.Padding(0);
            this.searchLabel.ForeColor = System.Drawing.Color.FromArgb(89, 111, 127);
            this.searchLabel.Text = "&Buscar medicamento o lote";
            this.searchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.BackColor = System.Drawing.Color.FromArgb(247, 250, 253);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.AccessibleName = "Buscar por medicamento o lote";
            this.searchTextBox.TabIndex = 0;
            this.newButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newButton.BackColor = System.Drawing.Color.FromArgb(0, 113, 187);
            this.newButton.ForeColor = System.Drawing.Color.White;
            this.newButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newButton.FlatAppearance.BorderSize = 0;
            this.newButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 91, 151);
            this.newButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 73, 122);
            this.newButton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.newButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.newButton.Text = "+  &Nuevo";
            this.newButton.TabIndex = 1;
            this.editButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editButton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(207, 224, 238);
            this.editButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(235, 245, 253);
            this.editButton.BackColor = System.Drawing.Color.White;
            this.editButton.Text = "&Editar";
            this.editButton.TabIndex = 2;
            this.retireButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.retireButton.Margin = new System.Windows.Forms.Padding(0);
            this.retireButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.retireButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(234, 213, 211);
            this.retireButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(252, 239, 237);
            this.retireButton.BackColor = System.Drawing.Color.White;
            this.retireButton.ForeColor = System.Drawing.Color.FromArgb(160, 53, 46);
            this.retireButton.Text = "&Retirar";
            this.retireButton.TabIndex = 3;
            this.resultLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultLabel.Margin = new System.Windows.Forms.Padding(36, 0, 36, 0);
            this.resultLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // inventoryGrid
            //
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanel.Margin = new System.Windows.Forms.Padding(36, 0, 36, 0);
            this.gridPanel.Padding = new System.Windows.Forms.Padding(1);
            this.gridPanel.BackColor = System.Drawing.Color.FromArgb(222, 233, 242);
            this.gridPanel.Controls.Add(this.emptyLabel);
            this.gridPanel.Controls.Add(this.inventoryGrid);
            this.inventoryGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventoryGrid.Name = "inventoryGrid";
            this.inventoryGrid.AccessibleName = "Inventario de lotes";
            this.inventoryGrid.AllowUserToAddRows = false;
            this.inventoryGrid.AllowUserToDeleteRows = false;
            this.inventoryGrid.AllowUserToResizeRows = false;
            this.inventoryGrid.ReadOnly = true;
            this.inventoryGrid.MultiSelect = false;
            this.inventoryGrid.RowHeadersVisible = false;
            this.inventoryGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.inventoryGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.inventoryGrid.BackgroundColor = System.Drawing.Color.White;
            this.inventoryGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inventoryGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.inventoryGrid.GridColor = System.Drawing.Color.FromArgb(233, 240, 246);
            this.inventoryGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.inventoryGrid.EnableHeadersVisualStyles = false;
            this.inventoryGrid.ColumnHeadersHeight = 46;
            this.inventoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.inventoryGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 113, 187);
            this.inventoryGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.inventoryGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 113, 187);
            this.inventoryGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.inventoryGrid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.inventoryGrid.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.inventoryGrid.RowTemplate.Height = 58;
            this.inventoryGrid.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(16, 0, 8, 0);
            this.inventoryGrid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(232, 244, 253);
            this.inventoryGrid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(23, 59, 83);
            this.inventoryGrid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.inventoryGrid.TabIndex = 4;
            this.medicineColumn.DataPropertyName = "Medicine";
            this.medicineColumn.HeaderText = "Medicamento";
            this.medicineColumn.FillWeight = 32F;
            this.medicineColumn.MinimumWidth = 180;
            this.medicineColumn.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.medicineColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.lotColumn.DataPropertyName = "LotNumber";
            this.lotColumn.HeaderText = "N.º de lote";
            this.lotColumn.FillWeight = 18F;
            this.lotColumn.MinimumWidth = 110;
            this.lotColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quantityColumn.DataPropertyName = "Quantity";
            this.quantityColumn.HeaderText = "Disponible";
            this.quantityColumn.FillWeight = 15F;
            this.quantityColumn.MinimumWidth = 100;
            this.quantityColumn.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.quantityColumn.DefaultCellStyle.Format = "N0";
            this.quantityColumn.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.quantityColumn.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.quantityColumn.HeaderCell.Style.Padding = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.quantityColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.expiryColumn.DataPropertyName = "Expiry";
            this.expiryColumn.HeaderText = "Vencimiento";
            this.expiryColumn.FillWeight = 18F;
            this.expiryColumn.MinimumWidth = 120;
            this.expiryColumn.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.expiryColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.statusColumn.DataPropertyName = "Status";
            this.statusColumn.HeaderText = "Estado";
            this.statusColumn.FillWeight = 17F;
            this.statusColumn.MinimumWidth = 110;
            this.statusColumn.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.statusColumn.HeaderCell.Style.Padding = new System.Windows.Forms.Padding(0);
            this.statusColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.inventoryGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.medicineColumn, this.lotColumn, this.quantityColumn, this.expiryColumn, this.statusColumn});
            this.emptyLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.emptyLabel.Height = 64;
            this.emptyLabel.BackColor = System.Drawing.Color.FromArgb(240, 247, 253);
            this.emptyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.emptyLabel.Visible = false;
            this.selectionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectionLabel.Margin = new System.Windows.Forms.Padding(36, 0, 36, 0);
            this.selectionLabel.AutoEllipsis = true;
            this.selectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.activityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activityLabel.Margin = new System.Windows.Forms.Padding(36, 0, 36, 0);
            this.activityLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.activityLabel.ForeColor = System.Drawing.Color.FromArgb(89, 111, 127);
            this.activityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.activityLabel.Text = "Busca por medicamento o número de lote. Vencimiento más próximo primero.";
            this.refreshTimer.Interval = 60000;
            this.refreshTimer.Enabled = true;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.ForeColor = System.Drawing.Color.FromArgb(23, 59, 83);
            this.ClientSize = new System.Drawing.Size(1240, 760);
            this.MinimumSize = new System.Drawing.Size(900, 640);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.shellLayout);
            this.Name = "Form1";
            this.Text = "FarmaLote VDG | Inventario";
            this.shellLayout.ResumeLayout(false);
            this.navigationPanel.ResumeLayout(false);
            this.navigationPanel.PerformLayout();
            this.mainLayout.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.gridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGrid)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel shellLayout;
        private System.Windows.Forms.Panel navigationPanel;
        private System.Windows.Forms.Label brandLabel;
        private System.Windows.Forms.Label brandCaption;
        private System.Windows.Forms.Label navigationLabel;
        private System.Windows.Forms.Label navigationHint;
        private System.Windows.Forms.Label workspaceLabel;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Label demoLabel;
        private System.Windows.Forms.Label expiryLabel;
        private System.Windows.Forms.TableLayoutPanel toolbar;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button retireButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.DataGridView inventoryGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicineColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusColumn;
        private System.Windows.Forms.Label emptyLabel;
        private System.Windows.Forms.Label selectionLabel;
        private System.Windows.Forms.Label activityLabel;
        private System.Windows.Forms.Timer refreshTimer;
    }
}
