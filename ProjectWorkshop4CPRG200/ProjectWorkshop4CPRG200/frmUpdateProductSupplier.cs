//UpdateProductSupplier: Display new value of ProductSupplier we want to update
//User enter new value of the ProductSupplier
//validate the values entered by the user
//If values are correct than we update this ProductSupplier

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectWorkshop4CPRG200
{
    public partial class frmUpdateProductSupplier : Form
    {
        public ProductSupplier ProductSupplier; // current ProductSupplier
        public ProductSupplier OldProductSupplier; // original ProductSupplier data
        public List<ProductSupplier> listProductSupplier;
        public string oldProdName ;
        public string oldSupName;
        public List<Supplier> lstSuppliers;
        public List<Product> lstProducts;
        public frmUpdateProductSupplier()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            bool success;//public static bool UpdateProductSupplier
                         // (ProductSupplier OldProductSupplier,ProductSupplier NewProductSupplier)
            int? NewProductID;
            int? NewSupplierID;
            //test if newproductID ==null
            if (chkboxProductNull.Checked) NewProductID = null;
             else NewProductID = (int)cmbboxProduct.SelectedValue; //new ProductID
            //test if new supplieris==null
            if (chkbxSupNull.Checked) NewSupplierID = null;
            else NewSupplierID = (int)cmbboxSupplier.SelectedValue;  //new SupplierID
            
            //assign this value to my ProductSuppplier
            ProductSupplier.ProductID = NewProductID;
            ProductSupplier.SupplierID = NewSupplierID;

            if (NewProductID.HasValue)
                ProductSupplier.ProductName = ProductDB.GetProductNameById(lstProducts, NewProductID.Value);

            if (NewSupplierID.HasValue)
                ProductSupplier.SupplierName = SupplierDb.GetSupplierNameById(lstSuppliers, NewSupplierID.Value);

            //apply upddate in the db
            success = ProductSupplierDB.UpdateProductSupplier(OldProductSupplier, ProductSupplier);
            if (success)
            {
                this.DialogResult = DialogResult.OK;

            }
            else
            {
                this.DialogResult = DialogResult.Retry;
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // set dialog result to Retry
            this.DialogResult = DialogResult.Retry;
        }

        private void frmUpdateProductSupplier_Load(object sender, EventArgs e)
        {
            //Display the values of currant ProductSupplier (ProductName,SupplierName) 
            //we are displaying by name because user can know this by name rather than ID 
            txtboxProductOldValue.Text = oldProdName;
            txtboxSupplieroldValue.Text = oldSupName;
            txtboxProductOldValue.SelectAll();
            txtboxSupplieroldValue.SelectAll();
            txtboxProductOldValue.Focus();
            //display cmbboxSupplier
            cmbboxSupplier.DataSource = lstSuppliers;
            cmbboxSupplier.DisplayMember = "SupName";
            cmbboxSupplier.ValueMember = "SupplierID";
            

            //display dmbboxProducts
            cmbboxProduct.DataSource = lstProducts;
            cmbboxProduct.DisplayMember = "ProductName";
            cmbboxProduct.ValueMember = "ProductID";
            

        }
    }
}
