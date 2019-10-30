//PackageDb class : contain methods GetPackages : get the list of all packages from a table
//Add and update package and method to check if packageName is not taken
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWorkshop4CPRG200
{
    public static class PackageDB
    {
        //Get a list of all packages in the Db 
        public static List<Package> GetPackages()
        {
            List<Package> lstresult = new List<Package>();//
            using (SqlConnection connection = TravelExpertDB.GetConnection())
            {
                string selectQuery = "SELECT PackageId, PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, " +
                                     " PkgAgencyCommission FROM Packages";

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    //test if there is packages 
                    if (reader.HasRows)
                    {
                        int col_PkgStartDate = reader.GetOrdinal("PkgStartDate");
                        int col_PkgEndDate = reader.GetOrdinal("PkgEndDate");
                        int col_PkgDesc = reader.GetOrdinal("PkgDesc");
                        int col_PkgAgencyCommission = reader.GetOrdinal("PkgAgencyCommission");
                        //create a package and add it to the list
                        while (reader.Read())
                        {
                            Package package = new Package();
                            package.PackageId = (int)reader["PackageId"];
                            package.PkgName = (string)reader["PKgName"];

                            package.PkgStartDate = reader.IsDBNull(col_PkgStartDate) ?
                                     null : (DateTime?)reader["PkgStartDate"];
                            package.PkgEndDate = reader.IsDBNull(col_PkgEndDate) ?
                                     null : (DateTime?)reader["PkgEndDate"];
                            package.PkgDesc=reader.IsDBNull(col_PkgDesc) ?
                                     null :(string) reader["PkgDesc"] ;

                            package.PkgBasePrice = (decimal)reader["PkgBasePrice"];
                            package.PkgAgencyCommission = reader.IsDBNull(col_PkgAgencyCommission) ?
                                     null : (decimal?)reader["PkgAgencyCommission"];
                            
                            lstresult.Add(package);
                        }
                    }

                }
            }

            return lstresult;
        }

        //update OldPackage with values in NewPackage
        public static bool UpdatePackage(Package OldPackage, Package NewPackage)
        {
            bool success = true;
            string where_statement_str = "";

           SqlConnection con = TravelExpertDB.GetConnection();
            string updateStatement = "UPDATE Packages SET " +
                                     "PkgName = @NewPkgName, " +
                                     "PkgStartDate = @NewPkgStartDate, " +
                                     "PkgEndDate = @NewPkgEndDate, " +
                                     "PkgDesc = @NewPkgDesc, " +
                                     "PkgBasePrice = @NewPkgBasePrice, " +
                                     "PkgAgencyCommission = @NewPkgAgencyCommision " +
                                     "WHERE PackageID = @OldPkgID " + // to identify record to update
                                      "AND PkgName = @OldPkgName ";  // remaining conditions for optimistic concurrency
            if (OldPackage.PkgStartDate.HasValue)
                where_statement_str += "AND PkgStartDate = @OldPkgStartDate ";
            else
                where_statement_str += "AND PkgStartDate is null ";

            if (OldPackage.PkgEndDate.HasValue)
                where_statement_str += "AND PkgEndDate = @OldPkgEndDate ";
            else
                where_statement_str += "AND PkgEndDate is null " ;

            if (OldPackage.PkgDesc != null )
                where_statement_str += "AND PkgDesc = @OldPkgDesc ";
            else
                where_statement_str += "AND PkgDesc is null ";
            where_statement_str += "AND PkgBasePrice = @OldPkgBasePrice ";
            if (OldPackage.PkgAgencyCommission.HasValue)
                where_statement_str += "AND PkgAgencyCommission = @OldPkgAgencyCommission ";
            else
                where_statement_str += "AND PkgAgencyCommission is null ";
            updateStatement += where_statement_str;

            SqlCommand cmd = new SqlCommand(updateStatement, con);
            cmd.Parameters.AddWithValue("@NewPkgName", NewPackage.PkgName);
            if (NewPackage.PkgStartDate.HasValue)
            cmd.Parameters.AddWithValue("@NewPkgStartDate", NewPackage.PkgStartDate);
            else
                cmd.Parameters.AddWithValue("@NewPkgStartDate", DBNull.Value);
            if (NewPackage.PkgEndDate.HasValue)
                cmd.Parameters.AddWithValue("@NewPkgEndDate", NewPackage.PkgEndDate);
            else
                cmd.Parameters.AddWithValue("@NewPkgEndDate", DBNull.Value);

            if (NewPackage.PkgDesc!=null)
            cmd.Parameters.AddWithValue("@NewPkgDesc", NewPackage.PkgDesc);
            else
                cmd.Parameters.AddWithValue("@NewPkgDesc", DBNull.Value);

            cmd.Parameters.AddWithValue("@NewPkgBasePrice", NewPackage.PkgBasePrice);
            if (NewPackage.PkgAgencyCommission.HasValue)
            cmd.Parameters.AddWithValue("@NewPkgAgencyCommision", NewPackage.PkgAgencyCommission);
            else
                cmd.Parameters.AddWithValue("@NewPkgAgencyCommision", DBNull.Value);


            cmd.Parameters.AddWithValue("@OldPkgID", OldPackage.PackageId);
            cmd.Parameters.AddWithValue("@OldPkgName", OldPackage.PkgName);

            if (OldPackage.PkgStartDate.HasValue)
            cmd.Parameters.AddWithValue("@OldPkgStartDate", OldPackage.PkgStartDate);
            if (OldPackage.PkgEndDate.HasValue)
            cmd.Parameters.AddWithValue("@OldPkgEndDate", OldPackage.PkgEndDate);
            if (OldPackage.PkgDesc!=null)
                cmd.Parameters.AddWithValue("@OldPkgDesc", OldPackage.PkgDesc);
            cmd.Parameters.AddWithValue("@OldPkgBasePrice", OldPackage.PkgBasePrice);
            if (OldPackage.PkgAgencyCommission.HasValue)
            cmd.Parameters.AddWithValue("@OldPkgAgencyCommission", OldPackage.PkgAgencyCommission);


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

        //add a Package to the table of Packages
        public static int AddPackage(Package package)
        {
            SqlConnection con = TravelExpertDB.GetConnection();
            string insertStatement = "INSERT INTO Packages ( PkgName, PkgStartDate, PkgEndDate, PkgDesc, " +
                "PkgBasePrice, PkgAgencyCommission ) " +
                " VALUES (@PkgName,@PkgStartDate, @PkgEndDate, " +
                "@PkgDesc, @PkgBasePrice, @PkgAgencyCommission )";

            SqlCommand cmd = new SqlCommand(insertStatement, con);
            cmd.Parameters.AddWithValue("@PkgName", package.PkgName);
        
            if (package.PkgStartDate.HasValue)
             cmd.Parameters.AddWithValue("@PkgStartDate", package.PkgStartDate); 
            else
             cmd.Parameters.AddWithValue("@PkgStartDate", null);

            if (package.PkgEndDate.HasValue)
                cmd.Parameters.AddWithValue("@PkgEndDate", package.PkgEndDate);
            else
                cmd.Parameters.AddWithValue("@PkgEndDate", null);

            if (package.PkgDesc!=null)
                cmd.Parameters.AddWithValue("@PkgDesc", package.PkgDesc);
            else
                cmd.Parameters.AddWithValue("@PkgStartDate", null);

            cmd.Parameters.AddWithValue("@PkgBasePrice", package.PkgBasePrice);

            if (package.PkgAgencyCommission.HasValue)
                cmd.Parameters.AddWithValue("@PkgAgencyCommission", package.PkgAgencyCommission);
            else
                cmd.Parameters.AddWithValue("@PkgAgencyCommission", null);
            
            try
            {
                con.Open();
                cmd.ExecuteNonQuery(); // run the insert command
                // get the generated ID - current identity value for  Packages table
                string selectQuery = "SELECT IDENT_CURRENT('Packages') FROM Packages";
                SqlCommand selectCmd = new SqlCommand(selectQuery, con);
                int PackageID = Convert.ToInt32(selectCmd.ExecuteScalar()); // single value
                                                                             // typecase (int) does NOT work!
                return PackageID;
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

        //return true if Package Name is not taken in the Db
        public static bool PackageNameIsNotTaken(List<Package> lstPackages, string PkgName)
        {
            bool isnottaken = true;
            if (lstPackages.Where(x => x.PkgName == PkgName).ToList().Count() != 0) isnottaken = false;
            return isnottaken;
            
        }

    }
}
