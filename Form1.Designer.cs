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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            this.shellLayout = new System.Windows.Forms.TableLayoutPanel();
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.brandLabel = new System.Windows.Forms.Label();
            this.brandCaption = new System.Windows.Forms.Label();
            this.navigationLabel = new System.Windows.Forms.Label();
            this.navigationHint = new System.Windows.Forms.Label();
            this.workspaceLabel = new System.Windows.Forms.Label();
            this.demoLabel = new System.Windows.Forms.Label();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.expiryLabel = new System.Windows.Forms.Label();
            this.toolbar = new System.Windows.Forms.TableLayoutPanel();
            this.searchLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.retireButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.emptyLabel = new System.Windows.Forms.Label();
            this.inventoryGrid = new System.Windows.Forms.DataGridView();
            this.medicineColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            // shellLayout
            // 
            this.shellLayout.ColumnCount = 2;
            this.shellLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.shellLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.shellLayout.Controls.Add(this.navigationPanel, 0, 0);
            this.shellLayout.Controls.Add(this.mainLayout, 1, 0);
            this.shellLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shellLayout.Location = new System.Drawing.Point(0, 0);
            this.shellLayout.Name = "shellLayout";
            this.shellLayout.RowCount = 1;
            this.shellLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.shellLayout.Size = new System.Drawing.Size(1240, 760);
            this.shellLayout.TabIndex = 0;
            // 
            // navigationPanel
            // 
            this.navigationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(187)))));
            this.navigationPanel.Controls.Add(this.brandLabel);
            this.navigationPanel.Controls.Add(this.brandCaption);
            this.navigationPanel.Controls.Add(this.navigationLabel);
            this.navigationPanel.Controls.Add(this.navigationHint);
            this.navigationPanel.Controls.Add(this.workspaceLabel);
            this.navigationPanel.Controls.Add(this.demoLabel);
            this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanel.Location = new System.Drawing.Point(0, 0);
            this.navigationPanel.Margin = new System.Windows.Forms.Padding(0);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Size = new System.Drawing.Size(200, 760);
            this.navigationPanel.TabIndex = 0;
            // 
            // brandLabel
            // 
            this.brandLabel.AutoSize = true;
            this.brandLabel.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.brandLabel.ForeColor = System.Drawing.Color.White;
            this.brandLabel.Location = new System.Drawing.Point(22, 32);
            this.brandLabel.Name = "brandLabel";
            this.brandLabel.Size = new System.Drawing.Size(233, 57);
            this.brandLabel.TabIndex = 0;
            this.brandLabel.Text = "FarmaLote";
            // 
            // brandCaption
            // 
            this.brandCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.brandCaption.Location = new System.Drawing.Point(26, 78);
            this.brandCaption.Name = "brandCaption";
            this.brandCaption.Size = new System.Drawing.Size(150, 24);
            this.brandCaption.TabIndex = 1;
            this.brandCaption.Text = "VDG / Gestión de lotes";
            // 
            // navigationLabel
            // 
            this.navigationLabel.BackColor = System.Drawing.Color.White;
            this.navigationLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.navigationLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(187)))));
            this.navigationLabel.Location = new System.Drawing.Point(12, 144);
            this.navigationLabel.Name = "navigationLabel";
            this.navigationLabel.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.navigationLabel.Size = new System.Drawing.Size(176, 46);
            this.navigationLabel.TabIndex = 2;
            this.navigationLabel.Text = "Inventario";
            this.navigationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // navigationHint
            // 
            this.navigationHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.navigationHint.Location = new System.Drawing.Point(26, 204);
            this.navigationHint.Name = "navigationHint";
            this.navigationHint.Size = new System.Drawing.Size(150, 64);
            this.navigationHint.TabIndex = 3;
            this.navigationHint.Text = "Cada lote, su cantidad\ny su vencimiento.";
            // 
            // workspaceLabel
            // 
            this.workspaceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.workspaceLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.workspaceLabel.ForeColor = System.Drawing.Color.White;
            this.workspaceLabel.Location = new System.Drawing.Point(24, 588);
            this.workspaceLabel.Name = "workspaceLabel";
            this.workspaceLabel.Size = new System.Drawing.Size(152, 28);
            this.workspaceLabel.TabIndex = 4;
            this.workspaceLabel.Text = "Modo demostración";
            // 
            // demoLabel
            // 
            this.demoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.demoLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.demoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.demoLabel.Location = new System.Drawing.Point(24, 620);
            this.demoLabel.Name = "demoLabel";
            this.demoLabel.Size = new System.Drawing.Size(152, 112);
            this.demoLabel.TabIndex = 5;
            this.demoLabel.Text = "Datos locales en memoria.\nSin base de datos.\n\nLos cambios se pierden\nal cerrar la" +
    " aplicación.";
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.headerPanel, 0, 0);
            this.mainLayout.Controls.Add(this.expiryLabel, 0, 2);
            this.mainLayout.Controls.Add(this.toolbar, 0, 3);
            this.mainLayout.Controls.Add(this.resultLabel, 0, 4);
            this.mainLayout.Controls.Add(this.gridPanel, 0, 5);
            this.mainLayout.Controls.Add(this.selectionLabel, 0, 6);
            this.mainLayout.Controls.Add(this.activityLabel, 0, 7);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(200, 0);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mainLayout.Name = "mainLayout";
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
            this.mainLayout.Size = new System.Drawing.Size(1040, 760);
            this.mainLayout.TabIndex = 1;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.subtitleLabel);
            this.headerPanel.Controls.Add(this.logoPictureBox);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1040, 122);
            this.headerPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(59)))), ((int)(((byte)(83)))));
            this.titleLabel.Location = new System.Drawing.Point(32, 24);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(469, 67);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Inventario de lotes";
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(111)))), ((int)(((byte)(127)))));
            this.subtitleLabel.Location = new System.Drawing.Point(36, 82);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(513, 28);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "Controla existencias y prioriza los próximos vencimientos.";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.AccessibleName = "Farmacia VDG";
            this.logoPictureBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.logoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(740, 24);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(264, 72);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 2;
            this.logoPictureBox.TabStop = false;
            this.logoPictureBox.Click += new System.EventHandler(this.logoPictureBox_Click);
            // 
            // expiryLabel
            // 
            this.expiryLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(248)))), ((int)(((byte)(231)))));
            this.expiryLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expiryLabel.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.expiryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(91)))), ((int)(((byte)(23)))));
            this.expiryLabel.Location = new System.Drawing.Point(36, 122);
            this.expiryLabel.Margin = new System.Windows.Forms.Padding(36, 0, 36, 4);
            this.expiryLabel.Name = "expiryLabel";
            this.expiryLabel.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.expiryLabel.Size = new System.Drawing.Size(968, 48);
            this.expiryLabel.TabIndex = 1;
            this.expiryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolbar
            // 
            this.toolbar.ColumnCount = 5;
            this.toolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.toolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.toolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.toolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.toolbar.Controls.Add(this.searchLabel, 1, 0);
            this.toolbar.Controls.Add(this.searchTextBox, 1, 1);
            this.toolbar.Controls.Add(this.newButton, 2, 1);
            this.toolbar.Controls.Add(this.editButton, 3, 1);
            this.toolbar.Controls.Add(this.retireButton, 4, 1);
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolbar.Location = new System.Drawing.Point(36, 188);
            this.toolbar.Margin = new System.Windows.Forms.Padding(36, 14, 36, 8);
            this.toolbar.Name = "toolbar";
            this.toolbar.RowCount = 2;
            this.toolbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.toolbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolbar.Size = new System.Drawing.Size(968, 72);
            this.toolbar.TabIndex = 2;
            // 
            // searchLabel
            // 
            this.searchLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(111)))), ((int)(((byte)(127)))));
            this.searchLabel.Location = new System.Drawing.Point(0, 0);
            this.searchLabel.Margin = new System.Windows.Forms.Padding(0);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(664, 26);
            this.searchLabel.TabIndex = 0;
            this.searchLabel.Text = "&Buscar medicamento o lote";
            this.searchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // searchTextBox
            // 
            this.searchTextBox.AccessibleName = "Buscar por medicamento o lote";
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.searchTextBox.Location = new System.Drawing.Point(0, 28);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(648, 42);
            this.searchTextBox.TabIndex = 0;
            // 
            // newButton
            // 
            this.newButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(187)))));
            this.newButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newButton.FlatAppearance.BorderSize = 0;
            this.newButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(73)))), ((int)(((byte)(122)))));
            this.newButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(151)))));
            this.newButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.newButton.ForeColor = System.Drawing.Color.White;
            this.newButton.Location = new System.Drawing.Point(664, 26);
            this.newButton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(106, 46);
            this.newButton.TabIndex = 1;
            this.newButton.Text = "+  &Nuevo";
            this.newButton.UseVisualStyleBackColor = false;
            this.newButton.Click += new System.EventHandler(this.newButton_Click_1);
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.Color.White;
            this.editButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(224)))), ((int)(((byte)(238)))));
            this.editButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(253)))));
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Location = new System.Drawing.Point(780, 26);
            this.editButton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(84, 46);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "&Editar";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click_1);
            // 
            // retireButton
            // 
            this.retireButton.BackColor = System.Drawing.Color.White;
            this.retireButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.retireButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(213)))), ((int)(((byte)(211)))));
            this.retireButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.retireButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.retireButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(53)))), ((int)(((byte)(46)))));
            this.retireButton.Location = new System.Drawing.Point(874, 26);
            this.retireButton.Margin = new System.Windows.Forms.Padding(0);
            this.retireButton.Name = "retireButton";
            this.retireButton.Size = new System.Drawing.Size(94, 46);
            this.retireButton.TabIndex = 3;
            this.retireButton.Text = "&Retirar";
            this.retireButton.UseVisualStyleBackColor = false;
            // 
            // resultLabel
            // 
            this.resultLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.resultLabel.Location = new System.Drawing.Point(36, 268);
            this.resultLabel.Margin = new System.Windows.Forms.Padding(36, 0, 36, 0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(968, 38);
            this.resultLabel.TabIndex = 3;
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridPanel
            // 
            this.gridPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(233)))), ((int)(((byte)(242)))));
            this.gridPanel.Controls.Add(this.emptyLabel);
            this.gridPanel.Controls.Add(this.inventoryGrid);
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanel.Location = new System.Drawing.Point(36, 306);
            this.gridPanel.Margin = new System.Windows.Forms.Padding(36, 0, 36, 0);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Padding = new System.Windows.Forms.Padding(1);
            this.gridPanel.Size = new System.Drawing.Size(968, 368);
            this.gridPanel.TabIndex = 4;
            // 
            // emptyLabel
            // 
            this.emptyLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(253)))));
            this.emptyLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.emptyLabel.Location = new System.Drawing.Point(1, 303);
            this.emptyLabel.Name = "emptyLabel";
            this.emptyLabel.Size = new System.Drawing.Size(966, 64);
            this.emptyLabel.TabIndex = 0;
            this.emptyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.emptyLabel.Visible = false;
            // 
            // inventoryGrid
            // 
            this.inventoryGrid.AccessibleName = "Inventario de lotes";
            this.inventoryGrid.AllowUserToAddRows = false;
            this.inventoryGrid.AllowUserToDeleteRows = false;
            this.inventoryGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            this.inventoryGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.inventoryGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.inventoryGrid.BackgroundColor = System.Drawing.Color.White;
            this.inventoryGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inventoryGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.inventoryGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(187)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(187)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.inventoryGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.inventoryGrid.ColumnHeadersHeight = 46;
            this.inventoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.inventoryGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.medicineColumn,
            this.lotColumn,
            this.quantityColumn,
            this.expiryColumn,
            this.statusColumn});
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(59)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle24.Padding = new System.Windows.Forms.Padding(16, 0, 8, 0);
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(244)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(59)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.inventoryGrid.DefaultCellStyle = dataGridViewCellStyle24;
            this.inventoryGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventoryGrid.EnableHeadersVisualStyles = false;
            this.inventoryGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(246)))));
            this.inventoryGrid.Location = new System.Drawing.Point(1, 1);
            this.inventoryGrid.MultiSelect = false;
            this.inventoryGrid.Name = "inventoryGrid";
            this.inventoryGrid.ReadOnly = true;
            this.inventoryGrid.RowHeadersVisible = false;
            this.inventoryGrid.RowHeadersWidth = 62;
            this.inventoryGrid.RowTemplate.Height = 58;
            this.inventoryGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.inventoryGrid.Size = new System.Drawing.Size(966, 366);
            this.inventoryGrid.TabIndex = 4;
            // 
            // medicineColumn
            // 
            this.medicineColumn.DataPropertyName = "Medicine";
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.medicineColumn.DefaultCellStyle = dataGridViewCellStyle21;
            this.medicineColumn.FillWeight = 32F;
            this.medicineColumn.HeaderText = "Medicamento";
            this.medicineColumn.MinimumWidth = 180;
            this.medicineColumn.Name = "medicineColumn";
            this.medicineColumn.ReadOnly = true;
            this.medicineColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lotColumn
            // 
            this.lotColumn.DataPropertyName = "LotNumber";
            this.lotColumn.FillWeight = 18F;
            this.lotColumn.HeaderText = "N.º de lote";
            this.lotColumn.MinimumWidth = 110;
            this.lotColumn.Name = "lotColumn";
            this.lotColumn.ReadOnly = true;
            this.lotColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // quantityColumn
            // 
            this.quantityColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Format = "N0";
            dataGridViewCellStyle22.Padding = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.quantityColumn.DefaultCellStyle = dataGridViewCellStyle22;
            this.quantityColumn.FillWeight = 15F;
            this.quantityColumn.HeaderText = "Disponible";
            this.quantityColumn.MinimumWidth = 100;
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.ReadOnly = true;
            this.quantityColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // expiryColumn
            // 
            this.expiryColumn.DataPropertyName = "Expiry";
            dataGridViewCellStyle23.Format = "dd/MM/yyyy";
            this.expiryColumn.DefaultCellStyle = dataGridViewCellStyle23;
            this.expiryColumn.FillWeight = 18F;
            this.expiryColumn.HeaderText = "Vencimiento";
            this.expiryColumn.MinimumWidth = 120;
            this.expiryColumn.Name = "expiryColumn";
            this.expiryColumn.ReadOnly = true;
            this.expiryColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // statusColumn
            // 
            this.statusColumn.DataPropertyName = "Status";
            this.statusColumn.FillWeight = 17F;
            this.statusColumn.HeaderText = "Estado";
            this.statusColumn.MinimumWidth = 110;
            this.statusColumn.Name = "statusColumn";
            this.statusColumn.ReadOnly = true;
            this.statusColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // selectionLabel
            // 
            this.selectionLabel.AutoEllipsis = true;
            this.selectionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectionLabel.Location = new System.Drawing.Point(36, 674);
            this.selectionLabel.Margin = new System.Windows.Forms.Padding(36, 0, 36, 0);
            this.selectionLabel.Name = "selectionLabel";
            this.selectionLabel.Size = new System.Drawing.Size(968, 38);
            this.selectionLabel.TabIndex = 5;
            this.selectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // activityLabel
            // 
            this.activityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activityLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.activityLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(111)))), ((int)(((byte)(127)))));
            this.activityLabel.Location = new System.Drawing.Point(36, 712);
            this.activityLabel.Margin = new System.Windows.Forms.Padding(36, 0, 36, 0);
            this.activityLabel.Name = "activityLabel";
            this.activityLabel.Size = new System.Drawing.Size(968, 28);
            this.activityLabel.TabIndex = 6;
            this.activityLabel.Text = "Busca por medicamento o número de lote. Vencimiento más próximo primero.";
            this.activityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 60000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1240, 760);
            this.Controls.Add(this.shellLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(59)))), ((int)(((byte)(83)))));
            this.MinimumSize = new System.Drawing.Size(900, 640);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
