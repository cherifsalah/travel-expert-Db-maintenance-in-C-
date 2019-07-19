using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWorkshop4CPRG200
{
    public class ProductSupplierDB
    {
        //Get all the Product suppliers in the table
        public List<ProductSupplier> GetAllProductSupplier()
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

                            lstresult.Add(productsupplier);
                        }
                    }

                }
            }

            return lstresult;
        }
        ///finish delete and add
        ///getbyprodid(big list,prodid):smalllist
        ///getbysupid(big list,prodid):smalllist
        ///deleteby prod id from db
        ///deleteby sup id from db

    }
}
