//Add ProductSupplier: user choose a product form a list of all product
//and choose one supplier from a list of all supplier
//When user hit accept we look in table ProductSupplier if this new ProductSupplier is not created before
// then we add to the table
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
    


    public partial class frmAddProductSupplier : Form
    {
        public List<ProductSupplier> lstProductsSuppliers; //list of Products suppliers
        public List<Product> listProduct;//list of products
        public List<Supplier> listSuppliers;//list of suppliers
        public ProductSupplier ProductSupplierAdded; //Product supplier added
        public frmAddProductSupplier()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
           
            int? NewProductID;
            int? NewSupplierID;
            //test if newproductID ==null
            if (chkboxProductNull.Checked) NewProductID = null;
            else NewProductID = (int)cmbboxProduct.SelectedValue; //new ProductID
            //test if new supplieris==null
            if (chkbxSupNull.Checked) NewSupplierID = null;
            else NewSupplierID = (int)cmbboxSupplier.SelectedValue;  //new SupplierID

            ProductSupplier productSupplier = new ProductSupplier();
            
                //test if NewSupplierID and NewProductID is not taken before in any row of table ProductsSuppliers
                if (ProductSupplierDB.SupplierProductIsNotTaken(lstProductsSuppliers, NewSupplierID,NewProductID))
                {
                    //assign this value to my ProductSpplier 
                    productSupplier.SupplierID = NewSupplierID;
                    productSupplier.ProductID = NewProductID;
                    //apply add in the db
                    int prodsupID = ProductSupplierDB.AddProductSupplier(productSupplier);
                    productSupplier.ProductSupplierID = prodsupID;
                    ProductSupplierAdded = productSupplier.CopyProductSupplier();
                    if (prodsupID >= 1)
                    {
                        this.DialogResult = DialogResult.OK;

                    }
                    else
                    {
                        this.DialogResult = DialogResult.Retry;
                    }
                }
                else
                {
                    
                    //display a warning message to the user with a rule on how to add the supplier name
                    MessageBox.Show("You trying to create a new Product Supplier connection that exist \n " +
                        "already in the Travel Experts DB", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // set dialog result to Retry
            this.DialogResult = DialogResult.Retry;
        }

        private void frmAddProductSupplier_Load(object sender, EventArgs e)
        {
            //display cmbboxSupplier
            cmbboxSupplier.DataSource = listSuppliers;
            cmbboxSupplier.DisplayMember = "SupName";
            cmbboxSupplier.ValueMember = "SupplierID";


            //display dmbboxProducts
            cmbboxProduct.DataSource = listProduct;
            cmbboxProduct.DisplayMember = "ProductName";
            cmbboxProduct.ValueMember = "ProductID";
        }
    }
}
