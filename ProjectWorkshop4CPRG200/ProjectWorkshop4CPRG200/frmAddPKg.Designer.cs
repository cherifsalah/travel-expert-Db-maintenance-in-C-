namespace ProjectWorkshop4CPRG200
{
    partial class frmAddPKg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label lblPkgAC;
            System.Windows.Forms.Label lblPkgBp;
            System.Windows.Forms.Label lblPkgED;
            System.Windows.Forms.Label lblPkgName;
            System.Windows.Forms.Label lblPkgSD;
            this.chkStartDateNull = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkEndDateNull = new System.Windows.Forms.CheckBox();
            this.txtPkgDescNv = new System.Windows.Forms.TextBox();
            this.lblPkgDesc = new System.Windows.Forms.Label();
            this.txtPkgAgencyCommissionNv = new System.Windows.Forms.TextBox();
            this.txtPkgBasePriceNv = new System.Windows.Forms.TextBox();
            this.dateTimePickerEndDateNv = new System.Windows.Forms.DateTimePicker();
            this.txtPkgNameNv = new System.Windows.Forms.TextBox();
            this.dateTimePickerPkgStartDateNv = new System.Windows.Forms.DateTimePicker();
            this.grpBxAddPkg = new System.Windows.Forms.GroupBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblProductSelectedPackage = new System.Windows.Forms.Label();
            this.btnShowSelectedProducts = new System.Windows.Forms.Button();
            this.dataGridViewProductSupplier = new System.Windows.Forms.DataGridView();
            this.EditProductSupplier = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.productSupplierIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productSupplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            lblPkgAC = new System.Windows.Forms.Label();
            lblPkgBp = new System.Windows.Forms.Label();
            lblPkgED = new System.Windows.Forms.Label();
            lblPkgName = new System.Windows.Forms.Label();
            lblPkgSD = new System.Windows.Forms.Label();
            this.grpBxAddPkg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productSupplierBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPkgAC
            // 
            lblPkgAC.AutoSize = true;
            lblPkgAC.Location = new System.Drawing.Point(12, 210);
            lblPkgAC.Name = "lblPkgAC";
            lblPkgAC.Size = new System.Drawing.Size(187, 20);
            lblPkgAC.TabIndex = 2;
            lblPkgAC.Text = "Pkg Agency Commission:";
            // 
            // lblPkgBp
            // 
            lblPkgBp.AutoSize = true;
            lblPkgBp.Location = new System.Drawing.Point(12, 178);
            lblPkgBp.Name = "lblPkgBp";
            lblPkgBp.Size = new System.Drawing.Size(120, 20);
            lblPkgBp.TabIndex = 4;
            lblPkgBp.Text = "Pkg Base Price:";
            // 
            // lblPkgED
            // 
            lblPkgED.AutoSize = true;
            lblPkgED.Location = new System.Drawing.Point(12, 109);
            lblPkgED.Name = "lblPkgED";
            lblPkgED.Size = new System.Drawing.Size(112, 20);
            lblPkgED.TabIndex = 6;
            lblPkgED.Text = "Pkg End Date:";
            // 
            // lblPkgName
            // 
            lblPkgName.AutoSize = true;
            lblPkgName.Location = new System.Drawing.Point(12, 44);
            lblPkgName.Name = "lblPkgName";
            lblPkgName.Size = new System.Drawing.Size(86, 20);
            lblPkgName.TabIndex = 8;
            lblPkgName.Text = "Pkg Name:";
            // 
            // lblPkgSD
            // 
            lblPkgSD.AutoSize = true;
            lblPkgSD.Location = new System.Drawing.Point(12, 79);
            lblPkgSD.Name = "lblPkgSD";
            lblPkgSD.Size = new System.Drawing.Size(118, 20);
            lblPkgSD.TabIndex = 10;
            lblPkgSD.Text = "Pkg Start Date:";
            // 
            // chkStartDateNull
            // 
            this.chkStartDateNull.AutoSize = true;
            this.chkStartDateNull.Location = new System.Drawing.Point(415, 73);
            this.chkStartDateNull.Name = "chkStartDateNull";
            this.chkStartDateNull.Size = new System.Drawing.Size(61, 24);
            this.chkStartDateNull.TabIndex = 16;
            this.chkStartDateNull.Text = "Null";
            this.chkStartDateNull.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(533, 84);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkEndDateNull
            // 
            this.chkEndDateNull.AutoSize = true;
            this.chkEndDateNull.Location = new System.Drawing.Point(415, 109);
            this.chkEndDateNull.Name = "chkEndDateNull";
            this.chkEndDateNull.Size = new System.Drawing.Size(61, 24);
            this.chkEndDateNull.TabIndex = 17;
            this.chkEndDateNull.Text = "Null";
            this.chkEndDateNull.UseVisualStyleBackColor = true;
            // 
            // txtPkgDescNv
            // 
            this.txtPkgDescNv.Location = new System.Drawing.Point(199, 143);
            this.txtPkgDescNv.Name = "txtPkgDescNv";
            this.txtPkgDescNv.Size = new System.Drawing.Size(200, 26);
            this.txtPkgDescNv.TabIndex = 15;
            // 
            // lblPkgDesc
            // 
            this.lblPkgDesc.AutoSize = true;
            this.lblPkgDesc.Location = new System.Drawing.Point(12, 146);
            this.lblPkgDesc.Name = "lblPkgDesc";
            this.lblPkgDesc.Size = new System.Drawing.Size(124, 20);
            this.lblPkgDesc.TabIndex = 14;
            this.lblPkgDesc.Text = "Pkg Description:";
            // 
            // txtPkgAgencyCommissionNv
            // 
            this.txtPkgAgencyCommissionNv.Location = new System.Drawing.Point(199, 207);
            this.txtPkgAgencyCommissionNv.Name = "txtPkgAgencyCommissionNv";
            this.txtPkgAgencyCommissionNv.Size = new System.Drawing.Size(200, 26);
            this.txtPkgAgencyCommissionNv.TabIndex = 3;
            // 
            // txtPkgBasePriceNv
            // 
            this.txtPkgBasePriceNv.Location = new System.Drawing.Point(199, 175);
            this.txtPkgBasePriceNv.Name = "txtPkgBasePriceNv";
            this.txtPkgBasePriceNv.Size = new System.Drawing.Size(200, 26);
            this.txtPkgBasePriceNv.TabIndex = 5;
            // 
            // dateTimePickerEndDateNv
            // 
            this.dateTimePickerEndDateNv.Location = new System.Drawing.Point(199, 105);
            this.dateTimePickerEndDateNv.Name = "dateTimePickerEndDateNv";
            this.dateTimePickerEndDateNv.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerEndDateNv.TabIndex = 7;
            // 
            // txtPkgNameNv
            // 
            this.txtPkgNameNv.Location = new System.Drawing.Point(199, 41);
            this.txtPkgNameNv.Name = "txtPkgNameNv";
            this.txtPkgNameNv.Size = new System.Drawing.Size(200, 26);
            this.txtPkgNameNv.TabIndex = 9;
            // 
            // dateTimePickerPkgStartDateNv
            // 
            this.dateTimePickerPkgStartDateNv.Location = new System.Drawing.Point(199, 73);
            this.dateTimePickerPkgStartDateNv.Name = "dateTimePickerPkgStartDateNv";
            this.dateTimePickerPkgStartDateNv.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerPkgStartDateNv.TabIndex = 11;
            // 
            // grpBxAddPkg
            // 
            this.grpBxAddPkg.Controls.Add(this.chkEndDateNull);
            this.grpBxAddPkg.Controls.Add(this.chkStartDateNull);
            this.grpBxAddPkg.Controls.Add(this.txtPkgDescNv);
            this.grpBxAddPkg.Controls.Add(this.lblPkgDesc);
            this.grpBxAddPkg.Controls.Add(lblPkgAC);
            this.grpBxAddPkg.Controls.Add(this.txtPkgAgencyCommissionNv);
            this.grpBxAddPkg.Controls.Add(lblPkgBp);
            this.grpBxAddPkg.Controls.Add(this.txtPkgBasePriceNv);
            this.grpBxAddPkg.Controls.Add(lblPkgED);
            this.grpBxAddPkg.Controls.Add(this.dateTimePickerEndDateNv);
            this.grpBxAddPkg.Controls.Add(lblPkgName);
            this.grpBxAddPkg.Controls.Add(this.txtPkgNameNv);
            this.grpBxAddPkg.Controls.Add(lblPkgSD);
            this.grpBxAddPkg.Controls.Add(this.dateTimePickerPkgStartDateNv);
            this.grpBxAddPkg.Location = new System.Drawing.Point(22, 25);
            this.grpBxAddPkg.Name = "grpBxAddPkg";
            this.grpBxAddPkg.Size = new System.Drawing.Size(494, 256);
            this.grpBxAddPkg.TabIndex = 28;
            this.grpBxAddPkg.TabStop = false;
            this.grpBxAddPkg.Text = "New Package";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(533, 39);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(112, 35);
            this.btnAccept.TabIndex = 29;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblProductSelectedPackage
            // 
            this.lblProductSelectedPackage.AutoSize = true;
            this.lblProductSelectedPackage.Location = new System.Drawing.Point(18, 294);
            this.lblProductSelectedPackage.Name = "lblProductSelectedPackage";
            this.lblProductSelectedPackage.Size = new System.Drawing.Size(189, 20);
            this.lblProductSelectedPackage.TabIndex = 31;
            this.lblProductSelectedPackage.Text = "Products of new Package";
            // 
            // btnShowSelectedProducts
            // 
            this.btnShowSelectedProducts.Location = new System.Drawing.Point(845, 286);
            this.btnShowSelectedProducts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnShowSelectedProducts.Name = "btnShowSelectedProducts";
            this.btnShowSelectedProducts.Size = new System.Drawing.Size(220, 37);
            this.btnShowSelectedProducts.TabIndex = 33;
            this.btnShowSelectedProducts.Text = "Show Selected Products";
            this.btnShowSelectedProducts.UseVisualStyleBackColor = true;
            this.btnShowSelectedProducts.Click += new System.EventHandler(this.btnShowSelectedProducts_Click);
            // 
            // dataGridViewProductSupplier
            // 
            this.dataGridViewProductSupplier.AutoGenerateColumns = false;
            this.dataGridViewProductSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductSupplier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productSupplierIDDataGridViewTextBoxColumn,
            this.productIDDataGridViewTextBoxColumn,
            this.supplierIDDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.supplierNameDataGridViewTextBoxColumn,
            this.EditProductSupplier});
            this.dataGridViewProductSupplier.DataSource = this.productSupplierBindingSource;
            this.dataGridViewProductSupplier.Location = new System.Drawing.Point(22, 331);
            this.dataGridViewProductSupplier.Name = "dataGridViewProductSupplier";
            this.dataGridViewProductSupplier.ReadOnly = true;
            this.dataGridViewProductSupplier.RowTemplate.Height = 28;
            this.dataGridViewProductSupplier.Size = new System.Drawing.Size(1055, 155);
            this.dataGridViewProductSupplier.TabIndex = 35;
            this.dataGridViewProductSupplier.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProductSupplier_CellClick);
            // 
            // EditProductSupplier
            // 
            this.EditProductSupplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EditProductSupplier.HeaderText = "Select";
            this.EditProductSupplier.Name = "EditProductSupplier";
            this.EditProductSupplier.ReadOnly = true;
            this.EditProductSupplier.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EditProductSupplier.ToolTipText = "Select";
            this.EditProductSupplier.Width = 60;
            // 
            // productSupplierIDDataGridViewTextBoxColumn
            // 
            this.productSupplierIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.productSupplierIDDataGridViewTextBoxColumn.DataPropertyName = "ProductSupplierID";
            this.productSupplierIDDataGridViewTextBoxColumn.HeaderText = "ProductSupplierID";
            this.productSupplierIDDataGridViewTextBoxColumn.Name = "productSupplierIDDataGridViewTextBoxColumn";
            this.productSupplierIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.productSupplierIDDataGridViewTextBoxColumn.Width = 175;
            // 
            // productIDDataGridViewTextBoxColumn
            // 
            this.productIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.productIDDataGridViewTextBoxColumn.DataPropertyName = "ProductID";
            this.productIDDataGridViewTextBoxColumn.HeaderText = "ProductID";
            this.productIDDataGridViewTextBoxColumn.Name = "productIDDataGridViewTextBoxColumn";
            this.productIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.productIDDataGridViewTextBoxColumn.Width = 117;
            // 
            // supplierIDDataGridViewTextBoxColumn
            // 
            this.supplierIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.supplierIDDataGridViewTextBoxColumn.DataPropertyName = "SupplierID";
            this.supplierIDDataGridViewTextBoxColumn.HeaderText = "SupplierID";
            this.supplierIDDataGridViewTextBoxColumn.Name = "supplierIDDataGridViewTextBoxColumn";
            this.supplierIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.supplierIDDataGridViewTextBoxColumn.Width = 120;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "ProductName";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.productNameDataGridViewTextBoxColumn.Width = 142;
            // 
            // supplierNameDataGridViewTextBoxColumn
            // 
            this.supplierNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.supplierNameDataGridViewTextBoxColumn.DataPropertyName = "SupplierName";
            this.supplierNameDataGridViewTextBoxColumn.HeaderText = "SupplierName";
            this.supplierNameDataGridViewTextBoxColumn.Name = "supplierNameDataGridViewTextBoxColumn";
            this.supplierNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.supplierNameDataGridViewTextBoxColumn.Width = 145;
            // 
            // productSupplierBindingSource
            // 
            this.productSupplierBindingSource.DataSource = typeof(ProjectWorkshop4CPRG200.ProductSupplier);
            // 
            // frmAddPKg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 498);
            this.Controls.Add(this.dataGridViewProductSupplier);
            this.Controls.Add(this.btnShowSelectedProducts);
            this.Controls.Add(this.lblProductSelectedPackage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.grpBxAddPkg);
            this.Name = "frmAddPKg";
            this.Text = "Add a new Package";
            this.Load += new System.EventHandler(this.frmAddPKg_Load);
            this.grpBxAddPkg.ResumeLayout(false);
            this.grpBxAddPkg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productSupplierBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkStartDateNull;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkEndDateNull;
        private System.Windows.Forms.TextBox txtPkgDescNv;
        private System.Windows.Forms.Label lblPkgDesc;
        private System.Windows.Forms.TextBox txtPkgAgencyCommissionNv;
        private System.Windows.Forms.TextBox txtPkgBasePriceNv;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDateNv;
        private System.Windows.Forms.TextBox txtPkgNameNv;
        private System.Windows.Forms.DateTimePicker dateTimePickerPkgStartDateNv;
        private System.Windows.Forms.GroupBox grpBxAddPkg;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblProductSelectedPackage;
        private System.Windows.Forms.Button btnShowSelectedProducts;
        private System.Windows.Forms.DataGridView dataGridViewProductSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn productSupplierIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EditProductSupplier;
        private System.Windows.Forms.BindingSource productSupplierBindingSource;
    }
}