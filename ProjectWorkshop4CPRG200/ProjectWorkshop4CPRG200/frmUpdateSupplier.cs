//UpdateSupplier: 
//user enter new value 
//validate the value entered and update the table of Suppliers with new value

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
    public partial class frmUpdateSupplier : Form
    {
        public Supplier supplier; // current Product
        public Supplier OldSupplier ; // original Product data
        public List<Supplier> listSupplier;
        public frmUpdateSupplier()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            bool success;//public static bool UpdateSupplier(Supplier OldSupplier,Supplier NewSupplier)
            string NewSupplierName = txtSupplierName.Text; //new SupplierName


            //test new Suppliername is valid 
            if (NewSupplierName.Length <= 255 )
                 
            {
                //if user enter a whitespace --> newsupname =null
                if (string.IsNullOrWhiteSpace(NewSupplierName)) NewSupplierName = null; 
                //test if supplier name is not taken
                if (SupplierDb.SupplierNameIsNotTaken(listSupplier, NewSupplierName))
                {
                    //assign this value to my supplier
                    supplier.SupName = NewSupplierName;

                    //apply upddate in the db
                    success = SupplierDb.UpdateSupplier(OldSupplier, supplier);
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
                    txtSupplierName.SelectAll();
                    txtSupplierName.Focus();
                    //display a warning message to the user with a rule on how to update the Supplier Name
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
                //display a warning message to the user with a rule on how to update the supplier name
                MessageBox.Show("Check the value of the given Supplier Name, use this rule:\n " +
                    "Supplier Name field has to be a set of characters and white space of size <=255 ", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // set dialog result to Retry
            this.DialogResult = DialogResult.Retry;

        }

        private void frmUpdateSupplier_Load(object sender, EventArgs e)
        {
            //Display the values of currant supplier (SupplierID,SupplierName) 

            txtSupplierID.Text = supplier.SupplierID.ToString();
            if (supplier.SupName!=null)
            txtSupplierName.Text = supplier.SupName;
            txtSupplierName.SelectAll();

        }
    }
}
