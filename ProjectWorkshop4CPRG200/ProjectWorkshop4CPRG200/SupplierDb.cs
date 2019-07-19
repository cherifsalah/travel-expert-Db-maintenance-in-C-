using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWorkshop4CPRG200
{
    public class SupplierDb
    {
        //Get a list of all products in the Db
        public List<Supplier> GetSuppliers()
        {
            List<Supplier> lstresult = new List<Supplier>();
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
                        int col_SupName = reader.GetOrdinal("SupName");
                        //create a product and add it to the list
                        while (reader.Read())
                        {
                            Supplier supplier = new Supplier();
                            supplier.SupplierID = (int)reader["SupplierID"];

                            supplier.SupName = reader.IsDBNull(col_SupName) ?
                                     null : (string?)reader["SupName"];

                            lstresult.Add(supplier);
                        }
                    }

                }
            }

            return lstresult;
        }

        //update OldSupplier with values in Newsupplier
        public static bool UpdateSupplier(Supplier OldSupplier, Supplier NewSupplier)
        {
            bool success = true;
            string update_where_str = "";
            SqlConnection con = TravelExpertDB.GetConnection();
            string updateStatement = "UPDATE Suppliers SET " +
                                     "SuppName = @NewSupName, " +
                                     "WHERE SupID = @OldSupID "; // to identify record to update
            // remaining conditions for optimistic concurrency
            if (OldSupplier.SupName.HasValue)
            { update_where_str += "AND SupName = @OldSupName "; }
            else
            { update_where_str += "AND SupName is Null "; }
            updateStatement += update_where_str;

            SqlCommand cmd = new SqlCommand(updateStatement, con);
            cmd.Parameters.AddWithValue("@NewSupName", NewSupplier.SupName.ToString());
            cmd.Parameters.AddWithValue("@OldSupID", OldSupplier.SupplierID);
            if (OldSupplier.SupName.HasValue)
            { cmd.Parameters.AddWithValue("@OldSupName", OldSupplier.SupName.ToString()); }

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

        //add a Supplier to the table of Suppliers
        public static int AddSupplier(Supplier supplier)
        {
            SqlConnection con = TravelExpertDB.GetConnection();
            string insertStatement = "INSERT INTO Suppliers (SupName) " +
                                     "VALUES(@SupName)";
            SqlCommand cmd = new SqlCommand(insertStatement, con);
            if (supplier.SupName.HasValue)
            { cmd.Parameters.AddWithValue("@SupName", supplier.SupName.ToString()); }
            else
            { cmd.Parameters.AddWithValue("@SupName", null); }
            try
            {
                con.Open();
                cmd.ExecuteNonQuery(); // run the insert command
                // get the generated ID - current identity value for  Suppliers table
                string selectQuery = "SELECT IDENT_CURRENT('Suppliers') FROM Suppliers";
                SqlCommand selectCmd = new SqlCommand(selectQuery, con);
                int SupplierID = Convert.ToInt32(selectCmd.ExecuteScalar()); // single value
                                                                            // typecase (int) does NOT work!
                return SupplierID;
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

        //delete a Supplier from table
        public static bool DeleteSupplier(Supplier supplier)
        {
            string delete_where_str = "";
            SqlConnection con = TravelExpertDB.GetConnection();
            string deleteStatement = "DELETE FROM Suppliers " +
                                     "WHERE SupplierID = @SupplierID "; // to identify the supplier to be  deleted
            // remaining conditions - to ensure optimistic concurrency
            if (supplier.SupName.HasValue)
            { delete_where_str += "AND SupName = @OldSupName "; }
            else
            { delete_where_str += "AND SupName is Null "; }
            deleteStatement += delete_where_str;
            

            SqlCommand cmd = new SqlCommand(deleteStatement, con);
            cmd.Parameters.AddWithValue("@upplierID", supplier.SupplierID);

            if (supplier.SupName.HasValue)
            { cmd.Parameters.AddWithValue("@SupName", supplier.SupName.ToString()); }
            else
            { cmd.Parameters.AddWithValue("@SupName", null); }

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
