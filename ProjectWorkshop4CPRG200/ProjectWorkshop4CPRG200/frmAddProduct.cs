//Add Products: User enter new Product name
// validate Productname , if valid add it to the table of Products
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
    public partial class frmAddProduct : Form
    {
        public Product productadded;
        public List<Product> listProduct ;
        public frmAddProduct()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
           
            string NewProductName = txtProductName.Text; //new ProductName
            Product product = new Product();


            //test new productname is valid 
            if (NewProductName.Length <= 50 &&
                  !string.IsNullOrWhiteSpace(NewProductName))
            {
                //test if product name is not taken
                if (ProductDB.ProductNameIsNotTaken(listProduct, NewProductName))
                {
                    //assign this value to my Product
                    product.ProductName = NewProductName;
                    //apply add in the db
                    int prodID = ProductDB.AddProduct(product);
                    product.ProductID = prodID;
                    productadded = product.CopyProduct();
                    if (prodID >= 1)
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
    }
}
