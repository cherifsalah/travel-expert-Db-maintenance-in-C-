namespace ProjectWorkshop4CPRG200
{
    partial class frmUpdateProductSupplier
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
            this.lblProduct = new System.Windows.Forms.Label();
            this.cmbboxProduct = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cmbboxSupplier = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.grpbxNewValue = new System.Windows.Forms.GroupBox();
            this.chkboxProductNull = new System.Windows.Forms.CheckBox();
            this.chkbxSupNull = new System.Windows.Forms.CheckBox();
            this.grpbxoldValue = new System.Windows.Forms.GroupBox();
            this.txtboxProductOldValue = new System.Windows.Forms.TextBox();
            this.txtboxSupplieroldValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpbxNewValue.SuspendLayout();
            this.grpbxoldValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(16, 96);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(64, 20);
            this.lblProduct.TabIndex = 9;
            this.lblProduct.Text = "Product";
            // 
            // cmbboxProduct
            // 
            this.cmbboxProduct.FormattingEnabled = true;
            this.cmbboxProduct.Location = new System.Drawing.Point(16, 119);
            this.cmbboxProduct.Name = "cmbboxProduct";
            this.cmbboxProduct.Size = new System.Drawing.Size(398, 28);
            this.cmbboxProduct.TabIndex = 8;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(16, 24);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(67, 20);
            this.lblSupplier.TabIndex = 7;
            this.lblSupplier.Text = "Supplier";
            // 
            // cmbboxSupplier
            // 
            this.cmbboxSupplier.FormattingEnabled = true;
            this.cmbboxSupplier.Location = new System.Drawing.Point(16, 45);
            this.cmbboxSupplier.Name = "cmbboxSupplier";
            this.cmbboxSupplier.Size = new System.Drawing.Size(398, 28);
            this.cmbboxSupplier.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(156, 179);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(17, 179);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(112, 35);
            this.btnAccept.TabIndex = 26;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // grpbxNewValue
            // 
            this.grpbxNewValue.Controls.Add(this.chkboxProductNull);
            this.grpbxNewValue.Controls.Add(this.chkbxSupNull);
            this.grpbxNewValue.Controls.Add(this.lblSupplier);
            this.grpbxNewValue.Controls.Add(this.btnCancel);
            this.grpbxNewValue.Controls.Add(this.cmbboxSupplier);
            this.grpbxNewValue.Controls.Add(this.btnAccept);
            this.grpbxNewValue.Controls.Add(this.cmbboxProduct);
            this.grpbxNewValue.Controls.Add(this.lblProduct);
            this.grpbxNewValue.Location = new System.Drawing.Point(505, 21);
            this.grpbxNewValue.Name = "grpbxNewValue";
            this.grpbxNewValue.Size = new System.Drawing.Size(527, 229);
            this.grpbxNewValue.TabIndex = 28;
            this.grpbxNewValue.TabStop = false;
            this.grpbxNewValue.Text = "New Value";
            // 
            // chkboxProductNull
            // 
            this.chkboxProductNull.AutoSize = true;
            this.chkboxProductNull.Location = new System.Drawing.Point(439, 122);
            this.chkboxProductNull.Name = "chkboxProductNull";
            this.chkboxProductNull.Size = new System.Drawing.Size(61, 24);
            this.chkboxProductNull.TabIndex = 29;
            this.chkboxProductNull.Text = "Null";
            this.chkboxProductNull.UseVisualStyleBackColor = true;
            // 
            // chkbxSupNull
            // 
            this.chkbxSupNull.AutoSize = true;
            this.chkbxSupNull.Location = new System.Drawing.Point(439, 47);
            this.chkbxSupNull.Name = "chkbxSupNull";
            this.chkbxSupNull.Size = new System.Drawing.Size(61, 24);
            this.chkbxSupNull.TabIndex = 28;
            this.chkbxSupNull.Text = "Null";
            this.chkbxSupNull.UseVisualStyleBackColor = true;
            // 
            // grpbxoldValue
            // 
            this.grpbxoldValue.Controls.Add(this.txtboxProductOldValue);
            this.grpbxoldValue.Controls.Add(this.txtboxSupplieroldValue);
            this.grpbxoldValue.Controls.Add(this.label2);
            this.grpbxoldValue.Controls.Add(this.label1);
            this.grpbxoldValue.Location = new System.Drawing.Point(26, 21);
            this.grpbxoldValue.Name = "grpbxoldValue";
            this.grpbxoldValue.Size = new System.Drawing.Size(451, 229);
            this.grpbxoldValue.TabIndex = 29;
            this.grpbxoldValue.TabStop = false;
            this.grpbxoldValue.Text = "OldValue";
            // 
            // txtboxProductOldValue
            // 
            this.txtboxProductOldValue.Location = new System.Drawing.Point(13, 120);
            this.txtboxProductOldValue.Name = "txtboxProductOldValue";
            this.txtboxProductOldValue.ReadOnly = true;
            this.txtboxProductOldValue.Size = new System.Drawing.Size(353, 26);
            this.txtboxProductOldValue.TabIndex = 30;
            // 
            // txtboxSupplieroldValue
            // 
            this.txtboxSupplieroldValue.Location = new System.Drawing.Point(10, 46);
            this.txtboxSupplieroldValue.Name = "txtboxSupplieroldValue";
            this.txtboxSupplieroldValue.ReadOnly = true;
            this.txtboxSupplieroldValue.Size = new System.Drawing.Size(353, 26);
            this.txtboxSupplieroldValue.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Product";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Supplier";
            // 
            // frmUpdateProductSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 274);
            this.Controls.Add(this.grpbxoldValue);
            this.Controls.Add(this.grpbxNewValue);
            this.Name = "frmUpdateProductSupplier";
            this.Text = "Update Product Supplier";
            this.Load += new System.EventHandler(this.frmUpdateProductSupplier_Load);
            this.grpbxNewValue.ResumeLayout(false);
            this.grpbxNewValue.PerformLayout();
            this.grpbxoldValue.ResumeLayout(false);
            this.grpbxoldValue.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cmbboxProduct;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cmbboxSupplier;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.GroupBox grpbxNewValue;
        private System.Windows.Forms.GroupBox grpbxoldValue;
        private System.Windows.Forms.TextBox txtboxProductOldValue;
        private System.Windows.Forms.TextBox txtboxSupplieroldValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkboxProductNull;
        private System.Windows.Forms.CheckBox chkbxSupNull;
    }
}