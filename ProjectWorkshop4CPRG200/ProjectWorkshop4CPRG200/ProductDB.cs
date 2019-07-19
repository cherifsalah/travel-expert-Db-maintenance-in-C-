using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWorkshop4CPRG200
{
    public class ProductDB
    {
        //Get a list of all products in the Db
        public List<Product> GetProducts()
        { 
        List<Product> lstresult = new List<Product>();
            using (SqlConnection connection = TravelExpertDB.GetConnection())
            {
                string selectQuery = "SELECT ProductID, ProductName" +
                                     " FROM Products";
                
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                { 
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    //test if there is product
                    if (reader.HasRows)
                    {
                        //create a product and add it to the list
                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.ProductID = (int)reader["ProductID"];
                            product.ProductName = (string)reader["ProductName"];

                            lstresult.Add(product);
                        }
                    }

                }
            }
           
            return lstresult;
        }

        //update OldProduct with values in NewProduct
        public static bool UpdateProduct(Product OldProduct, Product NewProduct)
        {
            bool success = true;
           
            SqlConnection con = TravelExpertDB.GetConnection();
            string updateStatement = "UPDATE Products SET " +
                                     "ProductName = @NewProductName, " +
                                     "WHERE ProductID = @OldProductID " + // to identify record to update
                                      "AND ProductName=@OldProductName";  // remaining conditions for optimistic concurrency
            SqlCommand cmd = new SqlCommand(updateStatement, con);
            cmd.Parameters.AddWithValue("@NewProductName", NewProduct.ProductName);
            cmd.Parameters.AddWithValue("@OldProductID", OldProduct.ProductID);
            cmd.Parameters.AddWithValue("@OldProductName", OldProduct.ProductName);
            
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
        //add a product to the table of products
        public static int AddProduct(Product product)
        {
            SqlConnection con = TravelExpertDB.GetConnection();
            string insertStatement = "INSERT INTO Products (ProductName) " +
                                     "VALUES(@ProductName)";
            SqlCommand cmd = new SqlCommand(insertStatement, con);
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            
            try
            {
                con.Open();
                cmd.ExecuteNonQuery(); // run the insert command
                // get the generated ID - current identity value for  Products table
                string selectQuery = "SELECT IDENT_CURRENT('Products') FROM Products";
                SqlCommand selectCmd = new SqlCommand(selectQuery, con);
                int ProductID = Convert.ToInt32(selectCmd.ExecuteScalar()); // single value
                                                                             // typecase (int) does NOT work!
                return ProductID;
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
        //delete a product from table
        public static bool DeleteProduct(Product product)
        {
            SqlConnection con = TravelExpertDB.GetConnection();
            string deleteStatement = "DELETE FROM Products " +
                                     "WHERE ProductID = @ProductID " + // to identify the product to be  deleted
                                     "AND ProductName = @ProductName "; // remaining conditions - to ensure optimistic concurrency
                                     
            SqlCommand cmd = new SqlCommand(deleteStatement, con);
            cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            
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
