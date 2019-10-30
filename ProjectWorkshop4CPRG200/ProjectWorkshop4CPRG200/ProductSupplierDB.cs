//ProductSupplierDB class: contain methods  GetAllProductSupplier to get a list of all
//ProductSupplier , AddProductSupplier to add a new ProductSupplier ,GetListProductSupplier_BySupplierID to get
// a list of ProductSupplier for a given SupplierId, GetListProductSupplier_ByProductID to get list of
// productSupplier for a given ProductId, UpdateProductSupplier to update a given productsupplier
//SupplierProductIsNotTaken : check if SupplierProduct is not taken
//GetProductSupplierByProdSuppId : get a ProductSupplier for a given ProdSupID

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWorkshop4CPRG200
{
    public static class ProductSupplierDB
    {
        //Get all the Product suppliers in the table
        public static List<ProductSupplier> GetAllProductSupplier(List<Product> lstProducts, 
                                                List<Supplier> lstSuppLiers)
           
        {
            
            List<ProductSupplier> lstresult = new List<ProductSupplier>();
            using (SqlConnection connection = TravelExpertDB.GetConnection())
            {
                string selectQuery = "SELECT ProductSupplierID, ProductID, SupplierID" +
                                     " FROM Products_Suppliers ";


                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    //test if there is a productsupplier 
                    if (reader.HasRows)
                    {
                        int col_ProductID = reader.GetOrdinal("ProductID");
                        int col_SupplierID = reader.GetOrdinal("SupplierID");
                        //create a productsupplier and add it to the list
                        while (reader.Read())
                        {
                            ProductSupplier productsupplier = new ProductSupplier();
                            productsupplier.ProductSupplierID = (int)reader["ProductSupplierID"];

                            productsupplier.ProductID = reader.IsDBNull(col_ProductID) ?
                                     null : (int?)reader["ProductID"];


                            productsupplier.SupplierID = reader.IsDBNull(col_SupplierID) ?
                                     null : (int?)reader["SupplierID"];

                            if (productsupplier.ProductID.HasValue)
                            productsupplier.ProductName = ProductDB.GetProductNameById(lstProducts, productsupplier.ProductID.Value);

                            if (productsupplier.SupplierID.HasValue)
                                productsupplier.SupplierName = SupplierDb.GetSupplierNameById(lstSuppLiers, productsupplier.SupplierID.Value);
                            lstresult.Add(productsupplier);
                        }
                    }

                }
            }

            return lstresult;
        }
        
        //add a new product supplier object
        public static int AddProductSupplier(ProductSupplier productsupplier)
        {
            SqlConnection con = TravelExpertDB.GetConnection();
            string insertStatement = "INSERT INTO Products_Suppliers (ProductId,SupplierId) " +
                                     "VALUES (@ProductID, @SupplierID) ";
            SqlCommand cmd = new SqlCommand(insertStatement, con);
            if (productsupplier.ProductID.HasValue)
            { cmd.Parameters.AddWithValue("@ProductID", productsupplier.ProductID); }
            else
            { cmd.Parameters.AddWithValue("@ProductID", DBNull.Value); }
            if (productsupplier.SupplierID.HasValue)
            { cmd.Parameters.AddWithValue("@SupplierID", productsupplier.SupplierID); }
            else
            { cmd.Parameters.AddWithValue("@SupplierID", DBNull.Value); }

            try
            {
                con.Open();
                cmd.ExecuteNonQuery(); // run the insert command
                // get the generated ID - current identity value for  Suppliers table
                string selectQuery = "SELECT IDENT_CURRENT('Products_Suppliers') FROM Products_Suppliers";
                SqlCommand selectCmd = new SqlCommand(selectQuery, con);
                int ProductSupplierID = Convert.ToInt32(selectCmd.ExecuteScalar()); // single value
                                                                             // typecase (int) does NOT work!
                return ProductSupplierID;
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

        //return all the Product_supplier of this SupplierId
        public static List<ProductSupplier> GetListProductSupplier_BySupplierID(List <ProductSupplier>listps,int SupID)
        {
            //Retrieve all the productsupplier from listps where SupplierID == SupID
            List<ProductSupplier> listresult = new List<ProductSupplier>();
            listresult= listps.Where(x => x.SupplierID == SupID).ToList();
            return listresult;
        }
        //return all the Product_supplier of this ProdId
        public static List<ProductSupplier> GetListProductSupplier_ByProductID(List<ProductSupplier> listps, int ProdID)
        {
            //Retrieve all the productsupplier from listps where ProductID == ProdID
            List<ProductSupplier> listresult = new List<ProductSupplier>();
            listresult = listps.Where(x => x.ProductID == ProdID).ToList();
            return listresult;
        }

        //update OldProductSupplier with values in NewProductSupplier
        public static bool UpdateProductSupplier(ProductSupplier OldProductSupplier, ProductSupplier NewProductSupplier)
        {
            bool success = true;
            string update_where_str = "";
            SqlConnection con = TravelExpertDB.GetConnection();
            string updateStatement = "UPDATE Products_Suppliers SET " +
                                     "SupplierID = @NewSupplierID, " +
                                     "ProductID = @NewProductID "+
                                     "WHERE ProductSupplierID = @OldProductSupplierID "; // to identify record to update
            // remaining conditions for optimistic concurrency
            if (OldProductSupplier.SupplierID.HasValue)
            { update_where_str += "AND SupplierID = @OldSupplierID "; }
            else
            { update_where_str += "AND SupplierID is Null "; }

            if (OldProductSupplier.ProductID.HasValue)
            { update_where_str += "AND ProductID = @OldProductID "; }
            else
            { update_where_str += "AND ProductID is Null "; }

            updateStatement += update_where_str;

            SqlCommand cmd = new SqlCommand(updateStatement, con);

            if (NewProductSupplier.SupplierID.HasValue)
                 cmd.Parameters.AddWithValue("@NewSupplierID", NewProductSupplier.SupplierID); 
            else  cmd.Parameters.AddWithValue("@NewSupplierID", DBNull.Value);

            if (NewProductSupplier.ProductID.HasValue)
                cmd.Parameters.AddWithValue("@NewProductID", NewProductSupplier.ProductID);
            else
                cmd.Parameters.AddWithValue("@NewProductID", DBNull.Value);


            cmd.Parameters.AddWithValue("@OldProductSupplierID", OldProductSupplier.ProductSupplierID);

            if (OldProductSupplier.ProductID.HasValue)
                cmd.Parameters.AddWithValue("@OldProductID", OldProductSupplier.ProductID);
            
            if (OldProductSupplier.SupplierID.HasValue)
                cmd.Parameters.AddWithValue("@OldSupplierID", OldProductSupplier.SupplierID);
            
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

        //test if SupplierProduct is not taken
        public static bool SupplierProductIsNotTaken(List<ProductSupplier>lstProductsSuppliers,
            int? NewSupplierID,int?  NewProductID)
        {

            bool isnottaken = true;
            if (lstProductsSuppliers.Where(x => x.ProductID == NewProductID && x.SupplierID== NewSupplierID).ToList().Count() != 0) isnottaken = false;
            return isnottaken;
        }
        //Get ProductSupplierByprodSuppId
        public static ProductSupplier GetProductSupplierByProdSuppId(List<ProductSupplier> lstProductsSuppliers,
           int ProdSuppId)
        {
            ProductSupplier prodsup_result = null; 
            foreach (ProductSupplier prodsup in lstProductsSuppliers)
            {
                if (prodsup.ProductSupplierID == ProdSuppId)
                { 
                    prodsup_result = prodsup.CopyProductSupplier();
                    break;
                }

            }
            return prodsup_result;
        }

    }
}
