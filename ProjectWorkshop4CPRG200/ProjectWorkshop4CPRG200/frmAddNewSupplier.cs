//Add new supplier Module: user enter new SupplierName
//validate suppliername and add it to the table of Suppliers 
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
    
    public partial class frmAddNewSupplier : Form
    {
        public Supplier supplieradded;
        public List<Supplier> listSupplier;
        public frmAddNewSupplier()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string NewSupplierName = txtSupplierName.Text; //new SupplierName
            Supplier supplier = new Supplier();


            //test new productname is valid 
            if (NewSupplierName.Length <= 255)
                  
            {
                //if user enter a whitespace --> newsupname =null
                if (string.IsNullOrWhiteSpace(NewSupplierName)) NewSupplierName = null;
                //test if product name is not taken
                if (SupplierDb.SupplierNameIsNotTaken(listSupplier, NewSupplierName))
                {
                    //assign this value to my Product
                    supplier.SupName = NewSupplierName;
                    //apply add in the db
                    int supID = SupplierDb.AddSupplier(supplier);
                    supplier.SupplierID = supID;
                    supplieradded = supplier.CopySupplier();
                    if (supID >= 1)
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
                    txtSupplierName.SelectAll();
                    txtSupplierName.Focus();
                    //display a warning message to the user with a rule on how to add the supplier name
                    MessageBox.Show("The value of the given Supplier Name is already taken \n " +
                        "by another supplier in the Travel Experts DB", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                

                }
            }
            else
            {

                //select the contenu of the textbox and set focus
                txtSupplierName.SelectAll();
                txtSupplierName.Focus();
                //display a warning message to the user with a rule on how to add the supplier name
                MessageBox.Show("Check the value of the given Supplier Name, use this rule:\n " +
                    "Product Name field has to be a set of no null character or white space of size <=255 ", "Warning",
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
