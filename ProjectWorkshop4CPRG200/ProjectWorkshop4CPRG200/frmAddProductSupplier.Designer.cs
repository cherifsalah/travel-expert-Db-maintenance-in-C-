namespace ProjectWorkshop4CPRG200
{
    partial class frmAddProductSupplier
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
            this.chkboxProductNull = new System.Windows.Forms.CheckBox();
            this.chkbxSupNull = new System.Windows.Forms.CheckBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbboxSupplier = new System.Windows.Forms.ComboBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.cmbboxProduct = new System.Windows.Forms.ComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkboxProductNull
            // 
            this.chkboxProductNull.AutoSize = true;
            this.chkboxProductNull.Location = new System.Drawing.Point(446, 119);
            this.chkboxProductNull.Name = "chkboxProductNull";
            this.chkboxProductNull.Size = new System.Drawing.Size(61, 24);
            this.chkboxProductNull.TabIndex = 37;
            this.chkboxProductNull.Text = "Null";
            this.chkboxProductNull.UseVisualStyleBackColor = true;
            // 
            // chkbxSupNull
            // 
            this.chkbxSupNull.AutoSize = true;
            this.chkbxSupNull.Location = new System.Drawing.Point(446, 44);
            this.chkbxSupNull.Name = "chkbxSupNull";
            this.chkbxSupNull.Size = new System.Drawing.Size(61, 24);
            this.chkbxSupNull.TabIndex = 36;
            this.chkbxSupNull.Text = "Null";
            this.chkbxSupNull.UseVisualStyleBackColor = true;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(23, 21);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(67, 20);
            this.lblSupplier.TabIndex = 31;
            this.lblSupplier.Text = "Supplier";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(163, 176);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbboxSupplier
            // 
            this.cmbboxSupplier.FormattingEnabled = true;
            this.cmbboxSupplier.Location = new System.Drawing.Point(23, 42);
            this.cmbboxSupplier.Name = "cmbboxSupplier";
            this.cmbboxSupplier.Size = new System.Drawing.Size(398, 28);
            this.cmbboxSupplier.TabIndex = 30;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(24, 176);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(112, 35);
            this.btnAccept.TabIndex = 34;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // cmbboxProduct
            // 
            this.cmbboxProduct.FormattingEnabled = true;
            this.cmbboxProduct.Location = new System.Drawing.Point(23, 116);
            this.cmbboxProduct.Name = "cmbboxProduct";
            this.cmbboxProduct.Size = new System.Drawing.Size(398, 28);
            this.cmbboxProduct.TabIndex = 32;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(23, 93);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(64, 20);
            this.lblProduct.TabIndex = 33;
            this.lblProduct.Text = "Product";
            // 
            // frmAddProductSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 300);
            this.Controls.Add(this.chkboxProductNull);
            this.Controls.Add(this.chkbxSupNull);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbboxSupplier);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.cmbboxProduct);
            this.Controls.Add(this.lblProduct);
            this.Name = "frmAddProductSupplier";
            this.Text = "Add a New Product Supplier";
            this.Load += new System.EventHandler(this.frmAddProductSupplier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkboxProductNull;
        private System.Windows.Forms.CheckBox chkbxSupNull;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbboxSupplier;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ComboBox cmbboxProduct;
        private System.Windows.Forms.Label lblProduct;
    }
}