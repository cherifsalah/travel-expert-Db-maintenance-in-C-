
//create a tab control that contain all the tables and there operations, one tab per table
//when form load default tab open is product
//user can navigate between the tab when he click on the header of each tab
//our system load all the tabs first 
//for each tab we will create a list of object of that class (exp tab Product) --> lstProduct
//in case of Product Tab :  every time user click on add a new object or edit  will display 
//a new form  that allow user to perform that particular operation
//we will always have a reference pointing the actual product in productselected 
//oldproduct will contain the value of the product before updating it. 

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
    public partial class frmMain : Form
    {
        const int TAB_INDEX_PRODUCT = 0;//index of TAB PRODUCT
        const int TAB_INDEX_SUPPLER = 1;//index of TAB SUPPLIER
        const int TAB_INDEX_PRODUCT_SUPPLIER = 2;//index of TAB PRODUCT SUPPLIER
        const int TAB_INDEX_PKG_PROD_SUPP = 3;//index of TAB PKG PRODUCT SUPPLIER
        const int TAB_INDEX_PKG = 4;// index of TAB PACKAGE
        const int EDIT_Btn_INDX_PRODUCT = 2; //index of button edit in Product grid view
        const int EDIT_Btn_INDX_SUPPLIER = 2;//index of button edit in Supplier grid view
        const int EDIT_Btn_INDX_SUPPLIER_PROD = 5; //index of button edit in product Supplier grid view
        const int EDIT_Btn_INDX_SUPPLIER_PKG = 6; ////index of button edit in Package grid view

        public List<Product> LstProducts = null;// list of all the products

        Product oldProduct = null;// to preserve data of the current product before update
        Product ProductSelected = null;//has Product selected on the list

        public List<Supplier> LstSuppliers = null;// list of all the suppliers

        Supplier oldSupplier = null;// to preserve data of the current supplier before update
        Supplier SupplierSelected = null;//has Supplier selected on the list

        public List<ProductSupplier> LstProductsSuppliers = null;// list of all the Products suppliers
        List<ProductSupplier> filterlist_ProdSupp = null;//filtered list of productSupplier filtered by Product and
                                                         //Supplier 

        ProductSupplier oldProductSupplier = null;// to preserve data of the current Productsupplier before update
        ProductSupplier ProductSupplierSelected = null;//has productSupplier selected on the list

        public List<Package> LstPackages = null;// list of all the packages

        Package oldPackage = null;// to preserve data of the current Package before update
        Package PackageSelected = null;//has Package selected on the list

        List<ProductSupplier> lstProdSuppOfSelectedPkg = null; // list of ProdSupp of Selected Package

        List<Packages_Products_Suppliers> lstPkgsProductsSuppliers = null;// list of all PackagesProductSupplier




        public frmMain()
        {
            InitializeComponent();
        }



        private void frmMain_Load(object sender, EventArgs e)
        {
            //load  tab : Product
            loadProducts();
            //load tab:Supplier
            loadSuppliers();
            //load ProductSupplier
            loadProductsSuppliers();
            //Load all Packages product Supplier
            loadPkgProdSupplier();

            //load Packages
            loadPackages();


        }
        private void loadPkgProdSupplier()
        {
            try
            {
                //get all the Packages_Prod_Suppliers from db
                lstPkgsProductsSuppliers = Packages_Products_SuppliersDB.GetAllPackages_Products_Suppliers();

                //Display the package list in grid view
                dataGridViewPkgProdSupp.DataSource = lstPkgsProductsSuppliers;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading Package Product Supplier data: " + ex.Message,
                    ex.GetType().ToString());
            }

        }

        private void loadPackages()
        {
            try
            {
                //get all the Packages from db
                LstPackages = PackageDB.GetPackages();

                //Display the package list in grid view
                dataGridViewPackages.DataSource = LstPackages;
                PackageSelected = LstPackages[0];
                //get all ProductSupplier of  Package selected
                lstProdSuppOfSelectedPkg = Packages_Products_SuppliersDB.GetListProdSupplierOfPkgID(lstPkgsProductsSuppliers,
                    LstProductsSuppliers, PackageSelected.PackageId);

                //display the list of ProductSupplier
                dataGridViewProductsOfPkg.DataSource = lstProdSuppOfSelectedPkg;

                //select entire row if user click on any cell
                dataGridViewPackages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading Package data: " + ex.Message,
                    ex.GetType().ToString());
            }

        }

        private void loadProductsSuppliers()
        {
            try
            {

                //ProductsSuppliers
                //get all the productssuppliers in db
                LstProductsSuppliers = ProductSupplierDB.GetAllProductSupplier(LstProducts, LstSuppliers);

                //display cmbboxSupplier
                cmbboxSupplier.DataSource = LstSuppliers;
                cmbboxSupplier.DisplayMember = "SupName";
                cmbboxSupplier.ValueMember = "SupplierID";

                //display dmbboxProducts
                cmbboxProduct.DataSource = LstProducts;
                cmbboxProduct.DisplayMember = "ProductName";
                cmbboxProduct.ValueMember = "ProductID";

                //Display the Supplier poduct list in grid view
                dataGridViewProductSupplier.DataSource = LstProductsSuppliers;
                ProductSupplierSelected = LstProductsSuppliers[0];

                //select entire row if user click on any cell
                dataGridViewProductSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading ProductSupplier data: " + ex.Message,
                    ex.GetType().ToString());
            }


        }
        //load Suppliers Tab
        private void loadSuppliers()
        {

            try
            {

                //Supplier
                //get all the suppliers in db
                LstSuppliers = SupplierDb.GetSuppliers();

                //Display the poduct n grid view
                dataGridViewSupplier.DataSource = LstSuppliers;
                SupplierSelected = LstSuppliers[0];

                //select entire row if user click on any cell
                dataGridViewSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading Supplier data: " + ex.Message,
                    ex.GetType().ToString());
            }


        }

        //load Products TAB
        private void loadProducts()
        {
            try
            {
                //Product
                //get all the products in db
                LstProducts = ProductDB.GetProducts();

                //Display the poduct n grid view
                dataGridViewproduct.DataSource = LstProducts;
                ProductSelected = LstProducts[0];

                //select entire row if user click on any cell
                dataGridViewproduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading Product data: " + ex.Message,
                    ex.GetType().ToString());
            }

        }

        private void dataGridViewproduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if cell click then change selected product 

            int index; //the selected row index

            //get index of the selected row
            index = dataGridViewproduct.CurrentRow.Index;
            //get product selected from list
            ProductSelected = LstProducts[index];

            //test if user click on button edit
            if (e.ColumnIndex == EDIT_Btn_INDX_PRODUCT)
            {
                oldProduct = ProductSelected.CopyProduct(); // make a  separate copy before update
                frmUpdateProduct updateForm = new frmUpdateProduct();
                //get in the product and olderproduct
                updateForm.Product = ProductSelected; // "pass" current product to the form
                updateForm.OldProduct = oldProduct;        // same for the original product data
                updateForm.listProduct = LstProducts;
                DialogResult result = updateForm.ShowDialog(); // display modal second form
                if (result == DialogResult.OK) // update accepted
                {
                    // refresh the grid view
                    CurrencyManager cm = (CurrencyManager)dataGridViewproduct.BindingContext[LstProducts];
                    cm.Refresh();
                }
                else // update cancelled
                {
                    LstProducts[index] = oldProduct; // revert to the old values
                }
            }

        }

        // if user click on button Add Product
        private void btnAdd_Click(object sender, EventArgs e)
        {

            int index; //the selected row index

            //get index of the selected row
            index = dataGridViewproduct.CurrentRow.Index;
            //get product selected from list
            ProductSelected = LstProducts[index];

            frmAddProduct addForm = new frmAddProduct();
            addForm.listProduct = LstProducts;
            DialogResult result = addForm.ShowDialog(); // display modal second form

            if (result == DialogResult.OK) // add accepted
            {
                //add the new product to lstProducts
                LstProducts.Add(addForm.productadded);
                // refresh the grid view
                CurrencyManager cm = (CurrencyManager)dataGridViewproduct.BindingContext[LstProducts];
                cm.Refresh();
            }
            else // add cancelled
            {
                LstProducts[index] = ProductSelected; // revert to the old values
            }

        }

        private void dataGridViewSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if cell click then change selected Supplier 

            int index; //the selected row index

            //get index of the selected row
            index = dataGridViewSupplier.CurrentRow.Index;
            //get Supplier selected from list
            SupplierSelected = LstSuppliers[index];

            //test if user click on button edit
            if (e.ColumnIndex == EDIT_Btn_INDX_SUPPLIER)
            {
                oldSupplier = SupplierSelected.CopySupplier(); // make a  separate copy before update
                frmUpdateSupplier updateForm = new frmUpdateSupplier();
                //get in the Supplier and oldsupplier value and listSupplier
                updateForm.supplier = SupplierSelected; // "pass" current supplier to the form
                updateForm.OldSupplier = oldSupplier;        // same for the original supplier data
                updateForm.listSupplier = LstSuppliers;
                DialogResult result = updateForm.ShowDialog(); // display modal second form
                if (result == DialogResult.OK) // update accepted
                {
                    // refresh the grid view
                    CurrencyManager cm = (CurrencyManager)dataGridViewSupplier.BindingContext[LstSuppliers];
                    cm.Refresh();
                }
                else // update cancelled
                {
                    LstSuppliers[index] = oldSupplier; // revert to the old values
                }
            }

        }

        //if user click on addsupplier button
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            int index; //the selected row index

            //get index of the selected row
            index = dataGridViewSupplier.CurrentRow.Index;
            //get supplier selected from list
            SupplierSelected = LstSuppliers[index];

            frmAddNewSupplier addForm = new frmAddNewSupplier();
            addForm.listSupplier = LstSuppliers;
            DialogResult result = addForm.ShowDialog(); // display modal second form


            if (result == DialogResult.OK) // add accepted
            {
                //add the new Supplier to lstSuppliers
                LstSuppliers.Add(addForm.supplieradded);
                // refresh the grid view
                CurrencyManager cm = (CurrencyManager)dataGridViewSupplier.BindingContext[LstSuppliers];
                cm.Refresh();
            }
            else // add cancelled
            {
                LstSuppliers[index] = SupplierSelected; // revert to the old values
            }

        }

        //if user select a product from combo box
        //filter gridview by this product: display the productsupplier that 
        //have productid== this product.id
        private void cmbboxProduct_DropDownClosed(object sender, EventArgs e)
        {
            DisplayGridOnDropDownClose();
        }
        private void DisplayGridOnDropDownClose()
        {
            //get the index of selected product
            int index = cmbboxProduct.SelectedIndex;
            //get the id of selected Product from combo
            int ProdId = (int)cmbboxProduct.SelectedValue;
            //get a list of productSupplier where ProductID ==Prodid
            filterlist_ProdSupp = ProductSupplierDB.GetListProductSupplier_BySupplierID
                (LstProductsSuppliers, ProdId);
            //filter by product if And is Checked
            if (chkbxAnd.Checked)
            {
                //get the id of selected Supplier from combo Supplier
                int SupId = (int)cmbboxSupplier.SelectedValue;
                //filter list by supplier id
                filterlist_ProdSupp = ProductSupplierDB.GetListProductSupplier_BySupplierID(filterlist_ProdSupp, ProdId);

            }
            // refresh the grid view
            dataGridViewProductSupplier.DataSource = filterlist_ProdSupp;

        }
        //if user select a supplier from combo box
        //filter gridview by this supplier: display the productsupplier that 
        //have Supplierid== this supplier.id
        private void cmbboxSupplier_DropDownClosed(object sender, EventArgs e)
        {
            //get the index of selected supplier
            int index = cmbboxSupplier.SelectedIndex;
            //get the id of selected supplier from combo
            int SuppId = (int)cmbboxSupplier.SelectedValue;
            //get a list of productSupplier where supplierID ==Supid
            filterlist_ProdSupp =
                ProductSupplierDB.GetListProductSupplier_BySupplierID(LstProductsSuppliers, SuppId);
            //filter by product if And is Checked
            if (chkbxAnd.Checked)
            {
                //get the id of selected product from combo product
                int ProdId = (int)cmbboxProduct.SelectedValue;
                //filter list by product id
                filterlist_ProdSupp =
                    ProductSupplierDB.GetListProductSupplier_ByProductID(filterlist_ProdSupp, ProdId);

            }
            // refresh the grid view
            dataGridViewProductSupplier.DataSource = filterlist_ProdSupp;

        }

        private void chkbxAnd_CheckedChanged(object sender, EventArgs e)
        {
            DisplayGridOnDropDownClose();
        }

        private void dataGridViewProductSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if cell click then change selected ProductSupplier 

            int index; //the selected row index

            //get index of the selected row
            index = dataGridViewProductSupplier.CurrentRow.Index;
            //get ProductSupplier selected from list
            ProductSupplierSelected = LstProductsSuppliers[index];

            //test if user click on button edit
            if (e.ColumnIndex == EDIT_Btn_INDX_SUPPLIER_PROD)
            {
                oldProductSupplier = ProductSupplierSelected.CopyProductSupplier(); // make a  separate copy before update
                frmUpdateProductSupplier updateForm = new frmUpdateProductSupplier();
                //get in the productSupplier and oldproductsupplier value and listproductSupplier
                updateForm.ProductSupplier = ProductSupplierSelected; // "pass" current productsupplier to the form
                updateForm.OldProductSupplier = oldProductSupplier;        // same for the original productsupplier data
                updateForm.listProductSupplier = LstProductsSuppliers;
                if (oldProductSupplier.ProductID.HasValue)
                    updateForm.oldProdName = ProductDB.GetProductNameById(LstProducts, oldProductSupplier.ProductID.Value);
                if (oldProductSupplier.SupplierID.HasValue)
                    updateForm.oldSupName = SupplierDb.GetSupplierNameById(LstSuppliers, oldProductSupplier.SupplierID.Value);
                updateForm.lstProducts = LstProducts;
                updateForm.lstSuppliers = LstSuppliers;
                DialogResult result = updateForm.ShowDialog(); // display modal second form
                if (result == DialogResult.OK) // update accepted
                {
                    // refresh the grid view
                    CurrencyManager cm = (CurrencyManager)dataGridViewSupplier.BindingContext[LstProductsSuppliers];
                    cm.Refresh();
                }
                else // update cancelled
                {
                    LstProductsSuppliers[index] = oldProductSupplier; // revert to the old values
                }
            }
        }

        private void btnAddProdSupp_Click(object sender, EventArgs e)
        {
            int index; //the selected row index

            //get index of the selected row
            index = dataGridViewProductSupplier.CurrentRow.Index;
            //get productsupplier selected from list
            ProductSupplierSelected = LstProductsSuppliers[index];

            frmAddProductSupplier addForm = new frmAddProductSupplier();
            addForm.lstProductsSuppliers = LstProductsSuppliers;
            addForm.listProduct = LstProducts;
            addForm.listSuppliers = LstSuppliers;
            DialogResult result = addForm.ShowDialog(); // display modal second form

            if (result == DialogResult.OK) // add accepted
            {
                //add the new ProductSupplier to lstSuppliers
                LstProductsSuppliers.Add(addForm.ProductSupplierAdded);
                // refresh the grid view
                CurrencyManager cm = (CurrencyManager)dataGridViewProductSupplier.BindingContext[LstProductsSuppliers];

                cm.Refresh();
            }
            else // add cancelled
            {
                LstProductsSuppliers[index] = ProductSupplierSelected; // revert to the old values
            }

        }

        private void dataGridViewPackages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if cell clicked then change selected package 

            int index; //the selected row index

            //get index of the selected row
            index = dataGridViewPackages.CurrentRow.Index;
            //get Package selected from list
            PackageSelected = LstPackages[index];
            //get all the prodsupp of this package selected and display them

            lstProdSuppOfSelectedPkg = Packages_Products_SuppliersDB.GetListProdSupplierOfPkgID(lstPkgsProductsSuppliers,
                LstProductsSuppliers, PackageSelected.PackageId);

            //display the list of ProductSupplier
            dataGridViewProductsOfPkg.DataSource = lstProdSuppOfSelectedPkg;

            //test if user click on button edit
            if (e.ColumnIndex == EDIT_Btn_INDX_SUPPLIER_PKG)
            {
                oldPackage = PackageSelected.CopyPackage(); // make a  separate copy before update
                frmUpdatePackage updateForm = new frmUpdatePackage();
                //get in the package and oldpackage value and listpackage
                updateForm.Package = PackageSelected; // "pass" current package to the form
                updateForm.OldPackage = oldPackage;        // same for the original package data
                updateForm.listPackages = LstPackages;

                DialogResult result = updateForm.ShowDialog(); // display modal second form
                if (result == DialogResult.OK) // update accepted
                {
                    // refresh the grid view
                    CurrencyManager cm = (CurrencyManager)dataGridViewPackages.BindingContext[LstPackages];
                    cm.Refresh();
                }
                else // update cancelled
                {
                    LstPackages[index] = oldPackage; // revert to the old values
                }
            }
        }

        private void btnAddPackages_Click(object sender, EventArgs e)
        {
            int index; //the selected row index

            //get index of the selected row
            index = dataGridViewPackages.CurrentRow.Index;
            //get package selected from list
            PackageSelected = LstPackages[index];

            frmAddPKg addForm = new frmAddPKg();
            addForm.lstPckgs = LstPackages;
            addForm.listProduct = LstProducts;
            addForm.listSuppliers = LstSuppliers;
            addForm.ListProductSupplier = LstProductsSuppliers;
            DialogResult result = addForm.ShowDialog(); // display modal second form

            if (result == DialogResult.OK) // add accepted
            {
                //add the new Package to lstPackages
                LstPackages.Add(addForm.PackageAdded);
                // refresh the grid view
                CurrencyManager cm = (CurrencyManager)dataGridViewPackages.BindingContext[LstPackages];

                cm.Refresh();
            }
            else // add cancelled
            {
                LstPackages[index] = PackageSelected; // revert to the old values
            }

        }



        private void btnDisplayAllProdSupp_Click(object sender, EventArgs e)
        {
            //load ProductSupplier
            loadProductsSuppliers();
        }

        //update the list of ProductSupplier for the selected Package
        //we will show to the user a list of all productSupplier
        //user will select a new list of product supplier
        //update will make sure we delete all the rows in Package_Products_Supplier table for this PackageId
        //and create new rows with the new list of ProductSupplier
        private void btnUpdateProductsPkg_Click(object sender, EventArgs e)
        {

            frmUpdateProductsOfPkg updateForm = new frmUpdateProductsOfPkg();
            updateForm.lstProdOfPckgOv = lstProdSuppOfSelectedPkg;
            updateForm.Package = PackageSelected;
            updateForm.ListProductSupplier = LstProductsSuppliers;

            DialogResult result = updateForm.ShowDialog(); // display modal second form

            if (result == DialogResult.OK) // update accepted
            {
                //update the list of lstPkgsProductsSuppliers with new values
                loadPkgProdSupplier();

                //get new Products list of selected package
                lstProdSuppOfSelectedPkg = Packages_Products_SuppliersDB.GetListProdSupplierOfPkgID
                    (lstPkgsProductsSuppliers, LstProductsSuppliers, PackageSelected.PackageId);
                // refresh the grid view with new value
                //CurrencyManager cm = (CurrencyManager)dataGridViewProductsOfPkg.BindingContext[lstProdSuppOfSelectedPkg];

                //cm.Refresh();
                dataGridViewProductsOfPkg.DataSource = lstProdSuppOfSelectedPkg;

            }
        }

    }
}
