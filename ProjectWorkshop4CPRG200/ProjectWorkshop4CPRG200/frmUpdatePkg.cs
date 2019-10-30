//update package:display old value of the package we want to update
//user enter new values for the new Package in the New value group
//validate the data and update package
//in this module we are not updating the products of the package this will be done 
//in the main form when user select a package there is a button  there (update package) 
//that allow user to update the list of ProductSupplier for the selected package.


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
    public partial class frmUpdatePackage : Form
    {
        public Package Package; // current Package
        public Package OldPackage; // original Package data
        public List<Package> listPackages; //list of all Packages
        
        public frmUpdatePackage()
        {
            InitializeComponent();
        }

        private void frmUpdatePackage_Load(object sender, EventArgs e)
        {
            //Display the values of currant Package (PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice,PkgAgencyCommission) 
            //we are displaying by name because user can know this by name rather than ID 
            txtPkgNameOv.Text = OldPackage.PkgName;
            //test if PkgStartDate != null
            if (OldPackage.PkgStartDate.HasValue) pkgStartDateTimePickerOv.Value = OldPackage.PkgStartDate.Value;
            else pkgStartDateTimePickerOv.Visible = false;
            //test if PkgEndDate != null
            if (OldPackage.PkgEndDate.HasValue) pkgEndDateTimePickerOv.Value = OldPackage.PkgEndDate.Value;
            else pkgEndDateTimePickerOv.Visible = false;

            txtPkgDescOv.Text = OldPackage.PkgDesc;
            txtpkgBasePriceOv.Text = OldPackage.PkgBasePrice.ToString("C");
            //test if PkgAgencyCommission !=null
            if (OldPackage.PkgAgencyCommission.HasValue)
                txtpkgAgencyCommissionOv.Text = OldPackage.PkgAgencyCommission.Value.ToString("C");
            txtPkgNameOv.SelectAll();
            txtPkgNameOv.Focus();
                
        }

        //update value of oldPackage with a new values given by user
        private void btnAccept_Click(object sender, EventArgs e)
        {
            bool success;//public static bool UpdatePackage
                         // (Package OldPackage,Package NewPackage)
            string PkgNameNv= txtPkgNameNv.Text;
            DateTime? PkgStartDateNv=dateTimePickerPkgStartDateNv.Value;
            DateTime? PkgEndDateNv=dateTimePickerEndDateNv.Value;
            string PkgDescNv=txtPkgDescNv.Text;

            decimal PkgBasePriceNv=0;
            decimal? PkgAgencyCommissionNv=null;
            //a)	the Agency Commission cannot be greater than the Base Price
            //b)	the Package End Date must be later than Package Start Date
            //c)	Package Name and Package Description cannot be null


            //test if PkgNameNv is !=null and not exist in Db
            if (PkgNameNv.Length <= 50 && !string.IsNullOrWhiteSpace(PkgNameNv))
            {
                if (!PackageDB.PackageNameIsNotTaken(listPackages, PkgNameNv))
                
                {
                    //display a warning message to the user with a rule on how to update Package Name
                    MessageBox.Show("The value of the given Package Name is already taken \n " +
                        "by another Package in the Travel Experts DB", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPkgNameNv.SelectAll();
                    txtPkgNameNv.Focus();
                    return;
                }
            }
            else
            {
                //display a warning message to the user with a rule on how to update Package Name
                MessageBox.Show("Package Name should be a not null value \n " +
                    "and size <= 50", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPkgNameNv.SelectAll();
                txtPkgNameNv.Focus();

                return;
            }
            //validate startdate and enddate
            if (chkStartDateNull.Checked)  PkgStartDateNv = null;
            if (chkEndDateNull.Checked) PkgEndDateNv = null;
            //if both are not null and PkgStartDateNv>=PkgEndDateNv 
            if (PkgStartDateNv != null && PkgEndDateNv != null && ! (PkgStartDateNv<PkgEndDateNv))
            {
                MessageBox.Show("the Package End Date must be later than Package Start Date  \n " 
                   , "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePickerPkgStartDateNv.Select();
                dateTimePickerPkgStartDateNv.Focus();
                return;
            }
            if (!(PkgDescNv.Length <= 50))
            {
                MessageBox.Show("The Package Description must be no longer than 50  \n "
                    , "Warning",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPkgDescNv.SelectAll();
                txtPkgDescNv.Focus();
                return;
            }
            if (Validator.IsPresent(txtPkgBasePriceNv, "Pkg Base Price") &&
                Validator.IsNonNegativeDecimal(txtPkgBasePriceNv, "Pkg Base Price"))
            {
                PkgBasePriceNv = Convert.ToDecimal(txtPkgBasePriceNv.Text);
            }
            else
            {
                txtPkgBasePriceNv.SelectAll();
                txtPkgBasePriceNv.Focus();
                return;
            }
            //test if user provide an input for PkgAgencyCommission  
            if (txtPkgAgencyCommissionNv.Text != "")
            {
                if (Validator.IsNonNegativeDecimal(txtPkgAgencyCommissionNv, "Pkg Agency Commission"))
                {
                    PkgAgencyCommissionNv = Convert.ToDecimal(txtPkgAgencyCommissionNv.Text);
                }
                else
                {
                    txtPkgAgencyCommissionNv.SelectAll();
                    txtPkgAgencyCommissionNv.Focus();
                    return;
                }
            }
            else
                PkgAgencyCommissionNv = null;

            if ((PkgAgencyCommissionNv.HasValue) && (PkgAgencyCommissionNv > PkgBasePriceNv))
            {
                MessageBox.Show("the Agency Commission cannot be greater than the Base Price  \n "
                 , "Warning",
                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPkgBasePriceNv.SelectAll();
                txtPkgBasePriceNv.Focus();
                return;
                
            }
            //all test on input validated
            Package.PkgName = PkgNameNv;
            Package.PkgStartDate = PkgStartDateNv;
            Package.PkgEndDate = PkgEndDateNv;
            Package.PkgDesc = PkgDescNv;
            Package.PkgBasePrice = PkgBasePriceNv;
            Package.PkgAgencyCommission = PkgAgencyCommissionNv;
            
            //apply upddate in the db
            success = PackageDB.UpdatePackage (OldPackage, Package);
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
    }

}
