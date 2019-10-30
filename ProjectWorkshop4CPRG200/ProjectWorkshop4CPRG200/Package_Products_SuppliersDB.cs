//Class Packages_Products_SuppliersDB: contain method to get the list of  all the Packages_Products_Suppliers
//Add and delete of a list of ProductSupplier for a given package
//GetListProdSupplierOfPkgID : get a list of productSupplier of PackageID
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectWorkshop4CPRG200
{
    public static class Packages_Products_SuppliersDB
    {
        //return all the packages_products_suppliers 
        public static List<Packages_Products_Suppliers> GetAllPackages_Products_Suppliers()
        {
            List<Packages_Products_Suppliers> lstresult = new List<Packages_Products_Suppliers>();
            using (SqlConnection connection = TravelExpertDB.GetConnection())
            {
                string selectQuery = "SELECT PackageId, ProductSupplierId" +
                                     " FROM Packages_Products_Suppliers";

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    //test if there is package_product_supplier
                    if (reader.HasRows)
                    {
                        //create a package_product_supplier and add it to the list
                        while (reader.Read())
                        {
                            Packages_Products_Suppliers package_product_supplier = new Packages_Products_Suppliers();
                            package_product_supplier.PackageID = (int)reader["PackageId"];
                            package_product_supplier.ProductSupplierID = (int)reader["ProductSupplierId"];

                            lstresult.Add(package_product_supplier);
                        }
                    }

                }
            }

            return lstresult;
            
        }
        //get all prodSup of PackagId
        public static List<ProductSupplier> GetListProdSupplierOfPkgID(
            List<Packages_Products_Suppliers> lstPkgProdSupp,List<ProductSupplier> lstProdSupp,
            int PkgId)

        {
            List<ProductSupplier> lstresult=new List<ProductSupplier>() ;
            ProductSupplier prodsupp = new ProductSupplier();
            foreach (Packages_Products_Suppliers pkgProdsupp in lstPkgProdSupp)
            {
                if (pkgProdsupp.PackageID == PkgId)
                {
                    //get productSupplier of pkgProdSupp.ProductSupplier
                    prodsupp = ProductSupplierDB.GetProductSupplierByProdSuppId(lstProdSupp,pkgProdsupp.ProductSupplierID);
                    //add this ProductSupplier to the result list
                    lstresult.Add(prodsupp); 
                }

            }
            return lstresult;
        }

        //update OldProduct with values in NewProduct
        public static bool UpdatePackage_Product_Supplier(Packages_Products_Suppliers OldPackageProductSupplier,
            Packages_Products_Suppliers NewPackageProductSupplier)
        {
            bool success = true;

            SqlConnection con = TravelExpertDB.GetConnection();
            string updateStatement = "UPDATE Package_Products_Suppliers SET " +
                                     "PackageId = @NewPackageId, " +
                                     "ProductSupplierId = @NewProductSupplierId " +
                                     "WHERE PackageID = @OldPackageID " + // to identify record to update
                                      "AND ProductSupplierId = @OldProductSupplierId";  // remaining conditions for optimistic concurrency
            SqlCommand cmd = new SqlCommand(updateStatement, con);
            cmd.Parameters.AddWithValue("@NewPackageId", NewPackageProductSupplier.PackageID);
            cmd.Parameters.AddWithValue("@NewProductSupplierId",NewPackageProductSupplier.ProductSupplierID);
            cmd.Parameters.AddWithValue("@OldPackageID", OldPackageProductSupplier.PackageID);
            cmd.Parameters.AddWithValue("@OldProductSupplierID", OldPackageProductSupplier.ProductSupplierID);

            try
            {
                con.Open();
                int rowsUpdated = cmd.ExecuteNonQuery();
                if (rowsUpdated == 0) success = false; // did not update (another user updated or deleted)
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

            return success;
        }

        //add a package_product_supplier to the table of Package_Products_Suppliers
        public static void AddPackageProductSupplier(Packages_Products_Suppliers package_product_supplier)
        {
            SqlConnection con = TravelExpertDB.GetConnection();
            string insertStatement = "INSERT INTO Packages_Products_Suppliers (PackageId,ProductSupplierId) " +
                                     "VALUES(@PackageId,@ProductSupplierId)";
            SqlCommand cmd = new SqlCommand(insertStatement, con);
            cmd.Parameters.AddWithValue("@PackageId", package_product_supplier.PackageID);
            cmd.Parameters.AddWithValue("@ProductSupplierId", package_product_supplier.ProductSupplierID);
            
            try
            {
                con.Open();
                cmd.ExecuteNonQuery(); // run the insert command
                
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        //add a list of Product supplier to PackageProductSupplier
        public static void AddListProdSupplierOfPackageID(List<ProductSupplier> lstProdSupp, int PkgID)
        {
            Packages_Products_Suppliers PkgProdSupp;
            
            foreach (ProductSupplier prodsup in lstProdSupp)
            {
                //create a new row in Package_Products_Suppliers
                PkgProdSupp = new Packages_Products_Suppliers();
                PkgProdSupp.PackageID = PkgID;
                PkgProdSupp.ProductSupplierID = prodsup.ProductSupplierID;
                //add this entry
                 AddPackageProductSupplier( PkgProdSupp);

            }

        }
        //Delete all the products of Package
        public static bool DeleteListProductsOfPackage(int PkgId, List<ProductSupplier> lstProdSupp)
        {
            // for each ProductSupplier in lstProdSupp delete the row in table Package_Products_Supplier
            //that have PackageId=PkgId and ProductSupplierID=ProductSupplier.ID
            bool success = true;
            foreach (ProductSupplier prodsup in lstProdSupp)
            {
                //if delete with no success than display an error message 
                if (!DeletePkgProdSup(PkgId, prodsup.ProductSupplierID))
                {
                    MessageBox.Show("Error while deleting Package_Product_Supplier data: " ,
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;

                }
                
            }
            return success;
            
        }
        //delete from Package_Products_Supplier row with value
        //=(PkgId, ProductSupplierID)
        public static bool DeletePkgProdSup(int PkgId, int ProductSupplierID)
        {
            
            SqlConnection con = TravelExpertDB.GetConnection();
            string deleteStatement = "DELETE FROM  Packages_Products_Suppliers " +
                                     "WHERE PackageId = @PackageID " +
                                      " AND ProductSupplierId= @ProdSuppID ";      
                            // to identify the package_products_Supplier to be  deleted
                             // remaining conditions - to ensure optimistic concurrency
            
            SqlCommand cmd = new SqlCommand(deleteStatement, con);
            cmd.Parameters.AddWithValue("@PackageID", PkgId);
            cmd.Parameters.AddWithValue("@ProdSuppID", ProductSupplierID); 
            
            try
            {
                con.Open();
                int count = cmd.ExecuteNonQuery();
                if (count > 0) return true;
                else return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            
        }
        
    }
}
