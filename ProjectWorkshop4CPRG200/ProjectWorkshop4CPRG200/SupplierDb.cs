//Class SupplierDB : conatin method to manipulat a supplier in the table, GetSuppliers to get all the 
// suppliers in the Db, UpdateSupplier to update a supplier, Addsupplier to add a new supplier, 
//DeleteSupplier to delete a supplier from a table of supplier, SupplierNameIsNotTaken to check if Supplier name
//is not taken, GetSupplierNameById to get SupplierName for a given SupplierID

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWorkshop4CPRG200
{
    public static class SupplierDb
    {
        //Get a list of all products in the Db
        public static List<Supplier> GetSuppliers()
        {
            List<Supplier> lstresult = new List<Supplier>();
            using (SqlConnection connection = TravelExpertDB.GetConnection())
            {
                string selectQuery = "SELECT SupplierId, SupName " +
                                     " FROM Suppliers";

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
                            supplier.SupplierID = (int)reader["SupplierId"];

                            supplier.SupName = reader.IsDBNull(col_SupName) ?
                                     null : (string)reader["SupName"];

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
                                     "SupName = @NewSupName " +
                                     "WHERE SupplierID = @OldSupID "; // to identify record to update
            // remaining conditions for optimistic concurrency
            if (OldSupplier.SupName !=null)
            { update_where_str += "AND SupName = @OldSupName "; }
            else
            { update_where_str += "AND SupName is Null "; }
            updateStatement += update_where_str;

            SqlCommand cmd = new SqlCommand(updateStatement, con);
            if (NewSupplier.SupName != null)
                cmd.Parameters.AddWithValue("@NewSupName", NewSupplier.SupName);
            else
                cmd.Parameters.AddWithValue("@NewSupName", DBNull.Value);

            cmd.Parameters.AddWithValue("@OldSupID", OldSupplier.SupplierID);
            if (OldSupplier.SupName !=null )
            { cmd.Parameters.AddWithValue("@OldSupName", OldSupplier.SupName); }
            

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
            //we are calculating the supid before insert because SupplierID is not identity
            string insertStatement = "With x as (select max(SupplierId) as supid from Suppliers) " +
                                    "INSERT INTO Suppliers (SupplierId,SupName) " +
                                     "VALUES ((Select supid from  x) + 1, @SupName) ";
            SqlCommand cmd = new SqlCommand(insertStatement, con);
            if (supplier.SupName!=null)
            { cmd.Parameters.AddWithValue("@SupName", supplier.SupName); }
            else
            { cmd.Parameters.AddWithValue("@SupName", DBNull.Value); }
            try
            {
                con.Open();
                cmd.ExecuteNonQuery(); // run the insert command
                // get the generated ID - current identity value for  Suppliers table
                string selectQuery = "select max(SupplierId) from Suppliers";
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
            if (supplier.SupName !=null)
            { delete_where_str += "AND SupName = @OldSupName "; }
            else
            { delete_where_str += "AND SupName is Null "; }
            deleteStatement += delete_where_str;
            

            SqlCommand cmd = new SqlCommand(deleteStatement, con);
            cmd.Parameters.AddWithValue("@upplierID", supplier.SupplierID);

            if (supplier.SupName!=null)
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

        //return true if supplier name is not taken before
        public static bool SupplierNameIsNotTaken(List<Supplier> lstsuppliers, string SupplierName)
        {
            bool isnottaken = true;
            //we allow table to have multiple row of supplier with suppliername==null 
            if (SupplierName != null)
            {
                if (lstsuppliers.Where(x => x.SupName == SupplierName).ToList().Count() != 0) isnottaken = false;
            }
            return isnottaken;
        }
        //return SupplierName by SupId
        public static string GetSupplierNameById(List<Supplier> lst, int SupID)
        {
            return lst.Where(x => x.SupplierID == SupID).ToList()[0].SupName;
        }
    }
}
