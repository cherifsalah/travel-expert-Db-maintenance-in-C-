namespace ProjectWorkshop4CPRG200
{
    partial class frmUpdateProductsOfPkg
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
            this.dataGridViewProductOv = new System.Windows.Forms.DataGridView();
            this.lblProductsOv = new System.Windows.Forms.Label();
            this.lblProductsNv = new System.Windows.Forms.Label();
            this.dataGridViewProductNv = new System.Windows.Forms.DataGridView();
            this.EditProductSupplier = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnShowSelectedProducts = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productSupplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productSupplierIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductOv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductNv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productSupplierBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProductOv
            // 
            this.dataGridViewProductOv.AutoGenerateColumns = false;
            this.dataGridViewProductOv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductOv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productSupplierIDDataGridViewTextBoxColumn,
            this.productIDDataGridViewTextBoxColumn,
            this.supplierIDDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.supplierNameDataGridViewTextBoxColumn});
            this.dataGridViewProductOv.DataSource = this.productSupplierBindingSource;
            this.dataGridViewProductOv.Location = new System.Drawing.Point(10, 46);
            this.dataGridViewProductOv.Name = "dataGridViewProductOv";
            this.dataGridViewProductOv.ReadOnly = true;
            this.dataGridViewProductOv.RowTemplate.Height = 28;
            this.dataGridViewProductOv.Size = new System.Drawing.Size(1055, 155);
            this.dataGridViewProductOv.TabIndex = 36;
            // 
            // lblProductsOv
            // 
            this.lblProductsOv.AutoSize = true;
            this.lblProductsOv.Location = new System.Drawing.Point(13, 13);
            this.lblProductsOv.Name = "lblProductsOv";
            this.lblProductsOv.Size = new System.Drawing.Size(145, 20);
            this.lblProductsOv.TabIndex = 37;
            this.lblProductsOv.Text = "Old Products  value";
            // 
            // lblProductsNv
            // 
            this.lblProductsNv.AutoSize = true;
            this.lblProductsNv.Location = new System.Drawing.Point(12, 221);
            this.lblProductsNv.Name = "lblProductsNv";
            this.lblProductsNv.Size = new System.Drawing.Size(156, 20);
            this.lblProductsNv.TabIndex = 38;
            this.lblProductsNv.Text = "New Products value  ";
            // 
            // dataGridViewProductNv
            // 
            this.dataGridViewProductNv.AutoGenerateColumns = false;
            this.dataGridViewProductNv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductNv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.EditProductSupplier});
            this.dataGridViewProductNv.DataSource = this.productSupplierBindingSource;
            this.dataGridViewProductNv.Location = new System.Drawing.Point(12, 256);
            this.dataGridViewProductNv.Name = "dataGridViewProductNv";
            this.dataGridViewProductNv.ReadOnly = true;
            this.dataGridViewProductNv.RowTemplate.Height = 28;
            this.dataGridViewProductNv.Size = new System.Drawing.Size(1055, 155);
            this.dataGridViewProductNv.TabIndex = 39;
            this.dataGridViewProductNv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProductNv_CellClick);
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
            // btnShowSelectedProducts
            // 
            this.btnShowSelectedProducts.Location = new System.Drawing.Point(847, 211);
            this.btnShowSelectedProducts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnShowSelectedProducts.Name = "btnShowSelectedProducts";
            this.btnShowSelectedProducts.Size = new System.Drawing.Size(220, 37);
            this.btnShowSelectedProducts.TabIndex = 40;
            this.btnShowSelectedProducts.Text = "Show Selected Products";
            this.btnShowSelectedProducts.UseVisualStyleBackColor = true;
            this.btnShowSelectedProducts.Click += new System.EventHandler(this.btnShowSelectedProducts_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(952, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(819, 6);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(112, 35);
            this.btnAccept.TabIndex = 41;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ProductSupplierID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ProductSupplierID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 175;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ProductID";
            this.dataGridViewTextBoxColumn2.HeaderText = "ProductID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 117;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SupplierID";
            this.dataGridViewTextBoxColumn3.HeaderText = "SupplierID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ProductName";
            this.dataGridViewTextBoxColumn4.HeaderText = "ProductName";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 142;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "SupplierName";
            this.dataGridViewTextBoxColumn5.HeaderText = "SupplierName";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 145;
            // 
            // productSupplierBindingSource
            // 
            this.productSupplierBindingSource.DataSource = typeof(ProjectWorkshop4CPRG200.ProductSupplier);
            // 
            // productSupplierIDDataGridViewTextBoxColumn
            // 
            this.productSupplierIDDataGridViewTextBoxColumn.DataPropertyName = "ProductSupplierID";
            this.productSupplierIDDataGridViewTextBoxColumn.HeaderText = "ProductSupplierID";
            this.productSupplierIDDataGridViewTextBoxColumn.Name = "productSupplierIDDataGridViewTextBoxColumn";
            this.productSupplierIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productIDDataGridViewTextBoxColumn
            // 
            this.productIDDataGridViewTextBoxColumn.DataPropertyName = "ProductID";
            this.productIDDataGridViewTextBoxColumn.HeaderText = "ProductID";
            this.productIDDataGridViewTextBoxColumn.Name = "productIDDataGridViewTextBoxColumn";
            this.productIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // supplierIDDataGridViewTextBoxColumn
            // 
            this.supplierIDDataGridViewTextBoxColumn.DataPropertyName = "SupplierID";
            this.supplierIDDataGridViewTextBoxColumn.HeaderText = "SupplierID";
            this.supplierIDDataGridViewTextBoxColumn.Name = "supplierIDDataGridViewTextBoxColumn";
            this.supplierIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "ProductName";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // supplierNameDataGridViewTextBoxColumn
            // 
            this.supplierNameDataGridViewTextBoxColumn.DataPropertyName = "SupplierName";
            this.supplierNameDataGridViewTextBoxColumn.HeaderText = "SupplierName";
            this.supplierNameDataGridViewTextBoxColumn.Name = "supplierNameDataGridViewTextBoxColumn";
            this.supplierNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmUpdateProductsOfPkg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 451);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnShowSelectedProducts);
            this.Controls.Add(this.dataGridViewProductNv);
            this.Controls.Add(this.lblProductsNv);
            this.Controls.Add(this.lblProductsOv);
            this.Controls.Add(this.dataGridViewProductOv);
            this.Name = "frmUpdateProductsOfPkg";
            this.Text = "Update Products ";
            this.Load += new System.EventHandler(this.frmUpdateProductsOfPkg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductOv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductNv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productSupplierBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProductOv;
        private System.Windows.Forms.DataGridViewTextBoxColumn productSupplierIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource productSupplierBindingSource;
        private System.Windows.Forms.Label lblProductsOv;
        private System.Windows.Forms.Label lblProductsNv;
        private System.Windows.Forms.DataGridView dataGridViewProductNv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EditProductSupplier;
        private System.Windows.Forms.Button btnShowSelectedProducts;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
    }
}