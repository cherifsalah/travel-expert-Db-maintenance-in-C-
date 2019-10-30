//Add New Package: user enter all the  data for new package including the Products for this package
//User can click on Show selected Products to show just the selected Products from the list of all
//ProductSupplier in the system
//If user click on Accept : validation of data for new user start .if everything is correct then
//proceed of adding a new package to the list of Pckages
//there will be 2 step :
//1-adding a row to the table of Packages for this new Package
//2-adding a row for everey single Product selected from the list Of ProductSupplier to the table 
//Package_Product_Supplier using the Id of the new Package we just create
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
    public partial class frmAddPKg : Form
    {
        public List<Package> lstPckgs; //list of Packages
        public List<Product> listProduct;//list of products
        public List<Supplier> listSuppliers;//list of suppliers
        public Package PackageAdded; //Package added
        public List<ProductSupplier> ListProductSupplier;//list of all ProductSupplier in Db
        private List<ProductSupplier> lstProdSupplierPkg=new List<ProductSupplier>(); //list of ProductSupplier Of added Package
        const int  SELECT_Btn_INDX_SUPPLIER_PROD = 5; //index of Button Select in Gridview ProductSupplier
        public frmAddPKg()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Package NewPackage=new Package();//New Package we want to add to the list of packages 
            string PkgNameNv = txtPkgNameNv.Text;//new Package name
            DateTime? PkgStartDateNv = dateTimePickerPkgStartDateNv.Value;//new Package Start Date
            DateTime? PkgEndDateNv = dateTimePickerEndDateNv.Value;//new Package End Date
            string PkgDescNv = txtPkgDescNv.Text;//new Package Description

            decimal PkgBasePriceNv = 0;//New Package base Price
            decimal? PkgAgencyCommissionNv = null;//New Package Agency Commission
            //a)	the Agency Commission cannot be greater than the Base Price
            //b)	the Package End Date must be later than Package Start Date
            //c)	Package Name and Package Description cannot be null


            //test if PkgNameNv is !=null and not exist in Db
            if (PkgNameNv.Length <= 50 && !string.IsNullOrWhiteSpace(PkgNameNv))
            {
                if (!PackageDB.PackageNameIsNotTaken(lstPckgs, PkgNameNv))

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
            if (chkStartDateNull.Checked) PkgStartDateNv = null;
            if (chkEndDateNull.Checked) PkgEndDateNv = null;
            //if both are not null and PkgStartDateNv>=PkgEndDateNv 
            if (PkgStartDateNv != null && PkgEndDateNv != null && !(PkgStartDateNv < PkgEndDateNv))
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
            NewPackage.PkgName = PkgNameNv;
            NewPackage.PkgStartDate = PkgStartDateNv;
            NewPackage.PkgEndDate = PkgEndDateNv;
            NewPackage.PkgDesc = PkgDescNv;
            NewPackage.PkgBasePrice = PkgBasePriceNv;
            NewPackage.PkgAgencyCommission = PkgAgencyCommissionNv;

            //apply add in the db
            int packageID = PackageDB.AddPackage(NewPackage);
            NewPackage.PackageId = packageID;
            PackageAdded = NewPackage.CopyPackage();
          

            if (packageID >= 1)
            {
                //add the list of Product supplier of Package selected by user
                Packages_Products_SuppliersDB.AddListProdSupplierOfPackageID(lstProdSupplierPkg, packageID);
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

       

       
        private void frmAddPKg_Load(object sender, EventArgs e)
        {
            //load all the Product Supplier of Db
            LoadProductSupplier();

        }

        private void LoadProductSupplier()
        {

            //load all the Product Supplier of Db
            try
            {

                //Display the Supplier poduct list in grid view ProductsOfPkg
                dataGridViewProductSupplier.DataSource = ListProductSupplier;

                //select entire row if user click on any cell
                dataGridViewProductSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading ProductSupplier data: " + ex.Message,
                    ex.GetType().ToString());
            }

        }

        private void btnShowSelectedProducts_Click(object sender, EventArgs e)
        {
            //filter list add show just selected ProductSuppliers
            //Test if column select value is checked than display it in the new list


            if (lstProdSupplierPkg.Count() != 0)
            {
                //load all the Product Supplier of Db
                try
                {

                    //Display the Supplier poduct list in grid view ProductsOfPkg
                    dataGridViewProductSupplier.DataSource = lstProdSupplierPkg;
                    //hide column select
                    
                    dataGridViewProductSupplier.Columns[SELECT_Btn_INDX_SUPPLIER_PROD].Visible = false;
                    dataGridViewProductSupplier.Focus() ;

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while loading ProductSupplier data: " + ex.Message,
                        ex.GetType().ToString());
                }

            }
        }

        private void dataGridViewProductSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if cell click then change selected ProductSupplier 

            int index; //the selected row index

            //get index of the selected row
            index = dataGridViewProductSupplier.CurrentRow.Index;
            //get ProductSupplier selected from list
            ProductSupplier ProductSupplierSelected = ListProductSupplier[index];

            //get the selected row
            
            DataGridViewRow row = dataGridViewProductSupplier.CurrentRow ;
            //test if selected then unselect and vice versa
            if (Convert.ToBoolean(row.Cells[SELECT_Btn_INDX_SUPPLIER_PROD].Value))
            {
                row.Cells[SELECT_Btn_INDX_SUPPLIER_PROD].Value = false;
                //remove ProductSupplierSelected from list lstProdSupplierPkg
                lstProdSupplierPkg.Remove(ProductSupplierSelected);
            }
            else
            {
                row.Cells[SELECT_Btn_INDX_SUPPLIER_PROD].Value = true;
                // add selected ProductSupplier to the list lstProdSupplierPkg
                lstProdSupplierPkg.Add(ProductSupplierSelected);
            }


        }

        
    }
}
