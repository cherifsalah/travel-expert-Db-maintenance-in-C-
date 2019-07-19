namespace ProjectWorkshop4CPRG200
{
    partial class frmMain
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
            this.tabOperation = new System.Windows.Forms.TabControl();
            this.tabProduct = new System.Windows.Forms.TabPage();
            this.tabSuplier = new System.Windows.Forms.TabPage();
            this.tabTravelPackages = new System.Windows.Forms.TabPage();
            this.tabProductSupplier = new System.Windows.Forms.TabPage();
            this.tabOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabOperation
            // 
            this.tabOperation.Controls.Add(this.tabProduct);
            this.tabOperation.Controls.Add(this.tabSuplier);
            this.tabOperation.Controls.Add(this.tabProductSupplier);
            this.tabOperation.Controls.Add(this.tabTravelPackages);
            this.tabOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabOperation.Location = new System.Drawing.Point(20, 17);
            this.tabOperation.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tabOperation.Name = "tabOperation";
            this.tabOperation.SelectedIndex = 0;
            this.tabOperation.Size = new System.Drawing.Size(2177, 712);
            this.tabOperation.TabIndex = 0;
            // 
            // tabProduct
            // 
            this.tabProduct.Location = new System.Drawing.Point(4, 34);
            this.tabProduct.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tabProduct.Name = "tabProduct";
            this.tabProduct.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tabProduct.Size = new System.Drawing.Size(2169, 674);
            this.tabProduct.TabIndex = 0;
            this.tabProduct.Text = "Product";
            this.tabProduct.UseVisualStyleBackColor = true;
            // 
            // tabSuplier
            // 
            this.tabSuplier.Location = new System.Drawing.Point(4, 34);
            this.tabSuplier.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tabSuplier.Name = "tabSuplier";
            this.tabSuplier.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tabSuplier.Size = new System.Drawing.Size(2169, 674);
            this.tabSuplier.TabIndex = 1;
            this.tabSuplier.Text = "Supplier";
            this.tabSuplier.UseVisualStyleBackColor = true;
            // 
            // tabTravelPackages
            // 
            this.tabTravelPackages.Location = new System.Drawing.Point(4, 34);
            this.tabTravelPackages.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tabTravelPackages.Name = "tabTravelPackages";
            this.tabTravelPackages.Size = new System.Drawing.Size(2169, 674);
            this.tabTravelPackages.TabIndex = 2;
            this.tabTravelPackages.Text = "TravelPackages";
            this.tabTravelPackages.UseVisualStyleBackColor = true;
            // 
            // tabProductSupplier
            // 
            this.tabProductSupplier.Location = new System.Drawing.Point(4, 34);
            this.tabProductSupplier.Name = "tabProductSupplier";
            this.tabProductSupplier.Size = new System.Drawing.Size(2169, 674);
            this.tabProductSupplier.TabIndex = 3;
            this.tabProductSupplier.Text = "Product Supplier";
            this.tabProductSupplier.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1912, 747);
            this.Controls.Add(this.tabOperation);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmMain";
            this.Text = "Travel Expert DB Maintenance";
            this.tabOperation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabOperation;
        private System.Windows.Forms.TabPage tabProduct;
        private System.Windows.Forms.TabPage tabSuplier;
        private System.Windows.Forms.TabPage tabTravelPackages;
        private System.Windows.Forms.TabPage tabProductSupplier;
    }
}

