//UpdateProduct: display the old value Product selected
//user enter new name for the product
//validate the new name if valid update the product in DB
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
    public partial class frmUpdateProduct : Form
    {
        public Product Product; // current Product
        public Product OldProduct; // original Product data
        public List<Product> listProduct;
        public frmUpdateProduct()
        {
        
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            bool success;//public static bool UpdateProduct(Product OldProduct,Product NewProduct)
            string NewProductName=txtProductName.Text; //new ProductName
            
            
            //test new productname is valid 
            if (NewProductName.Length<= 50 &&
                  ! string.IsNullOrWhiteSpace(NewProductName))
            {
                //test if product name is not taken
                if (ProductDB.ProductNameIsNotTaken(listProduct, NewProductName))
                {
                    //assign this value to my Product
                    Product.ProductName = NewProductName;

                    //apply upddate in the db
                    success = ProductDB.UpdateProduct(OldProduct, Product);
                    if (success)
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
                    //select the contenu of the textbox and set focus
                    txtProductName.SelectAll();
                    txtProductName.Focus();
                    //display a warning message to the user with a rule on how to update the order dates
                    MessageBox.Show("The value of the given Product Name is already taken \n " +
                        "by another product in the Travel Experts DB", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {

                //select the contenu of the textbox and set focus
                txtProductName.SelectAll();
                txtProductName.Focus();
                //display a warning message to the user with a rule on how to update the order dates
                MessageBox.Show("Check the value of the given Product Name, use this rule:\n " +
                    "Product Name field has to be a set of no null charachter or white space of size <=50 ", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // set dialog result to Retry
            this.DialogResult = DialogResult.Retry;
        }

        private void frmUpdateProduct_Load(object sender, EventArgs e)
        {
            //Display the values of currant Product (ProductID,ProductName) 
           
            txtProductID.Text = Product.ProductID.ToString();
            txtProductName.Text = Product.ProductName;
            txtProductName.SelectAll();


        }
    }
}
