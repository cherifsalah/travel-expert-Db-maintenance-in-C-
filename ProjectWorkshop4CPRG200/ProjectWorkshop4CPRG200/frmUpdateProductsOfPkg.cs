//Update ProductsOfPkg: Display Old value of the list of ProductSupplier for the selected Package
//Display all the ProductSupplier in the gridview ProductsNv (new value)
//user can select a list of ProductSupplier from GridViewProductsNv
//if user click on showselectedProducts button : show just the ProductSupplier that he selected
//when user click Accept than we delete all the rows from table Packages_Products_Suppliers
//that have PackageId== Id of the selected Package (Package we want to update) and 
//ProductSupplierId == Id of one ProductSupplier from old value list of ProductSupplier
//we will add new rows to the table Packages_Products_Suppliers to replace the old value deleted
//the value of new rows = (PackageID,ProductSupplierID :Get ID from a list of New ProductSupplier)

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
    public partial class frmUpdateProductsOfPkg : Form
    {
        public List<ProductSupplier> lstProdOfPckgOv; //contain a list Of ProdSup that we want apply update
        public Package Package;//conatin selected Package
        public List<ProductSupplier> ListProductSupplier;//list of all ProductSupplier
       public  List<ProductSupplier> lstProdSupplierPkgNv =new List<ProductSupplier>() ;//new list of ProductSuplier 
                                                           //selected by user     

        const int SELECT_Btn_INDX_SUPPLIER_PROD = 5;//index of button select in GridView ProductsNv


        public frmUpdateProductsOfPkg()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            bool success = true;
            //update with the new list of ProductSupplier
            //1.delete all productSupplier in the old list
            success = Packages_Products_SuppliersDB.DeleteListProductsOfPackage(Package.PackageId, lstProdOfPckgOv);
            //2.add productSupplier of new list of PorductSupplier
            Packages_Products_SuppliersDB.AddListProdSupplierOfPackageID(lstProdSupplierPkgNv, Package.PackageId);
            
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

        private void btnShowSelectedProducts_Click(object sender, EventArgs e)
        {
            //filter list add show just selected ProductSuppliers
            //Test if column select value is checked than display it in the new list


            if (lstProdSupplierPkgNv.Count() != 0)
            {

                try
                {

                    //Display the Supplier poduct list in grid view ProductsOfPkg
                    dataGridViewProductNv.DataSource = lstProdSupplierPkgNv;
                    //hide column select

                    dataGridViewProductNv.Columns[SELECT_Btn_INDX_SUPPLIER_PROD].Visible = false;
                    dataGridViewProductNv.Focus();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while loading ProductSupplier data: " + ex.Message,
                        ex.GetType().ToString());
                }

            }
        }

        private void frmUpdateProductsOfPkg_Load(object sender, EventArgs e)
        {
            //load grid view of Old Products with value
            //load gird view of new Products gird with all values
            try
            {

                //Display the Supplier poduct list in grid view ProductOv
                dataGridViewProductOv.DataSource = lstProdOfPckgOv;

                //select entire row if user click on any cell
                dataGridViewProductNv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //Display the Supplier poduct list in grid view ProductOv
                dataGridViewProductNv.DataSource = ListProductSupplier;

                //select entire row if user click on any cell
                dataGridViewProductNv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading ProductSupplier data: " + ex.Message,
                    ex.GetType().ToString());
            }

        }

        private void dataGridViewProductNv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if cell click then change selected ProductSupplier 

            int index; //the selected row index

            //get index of the selected row
            index = dataGridViewProductNv.CurrentRow.Index;
            //get ProductSupplier selected from list
            ProductSupplier ProductSupplierSelected = ListProductSupplier[index];

            //get the selected row

            DataGridViewRow row = dataGridViewProductNv.CurrentRow;
            //test if selected then unselect and vice versa
            if (Convert.ToBoolean(row.Cells[SELECT_Btn_INDX_SUPPLIER_PROD].Value))
            {
                row.Cells[SELECT_Btn_INDX_SUPPLIER_PROD].Value = false;
                //remove ProductSupplierSelected from list lstProdSupplierPkg
                lstProdSupplierPkgNv.Remove(ProductSupplierSelected);
            }
            else
            {
                row.Cells[SELECT_Btn_INDX_SUPPLIER_PROD].Value = true;
                // add selected ProductSupplier to the list lstProdSupplierPkg
                lstProdSupplierPkgNv.Add(ProductSupplierSelected);
            }

        }
    }
}
