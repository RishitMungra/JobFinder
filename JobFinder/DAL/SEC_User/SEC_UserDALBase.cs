using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace JobFinder.DAL.SEC_User
{
    public class SEC_UserDALBase : DALHelper
    {
        #region Method: SEC_User_SelectByUserNamePassword
        public DataTable SEC_User_SelectByUserNamePassword(string UserName, string Password)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("SEC_User_SelectByUserNamePassword");
                sqlDatabase.AddInParameter(dbCommand, "UserName", DbType.String, UserName);
                sqlDatabase.AddInParameter(dbCommand, "Password", DbType.String, Password);

                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: SEC_User_Register
        public bool SEC_User_Register(string UserName, string Password, string FirstName, string LastName, string EmailAddress)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("SEC_User_SelectUserName");
                sqlDatabase.AddInParameter(dbCommand, "UserName", DbType.String, UserName);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                if (dataTable.Rows.Count > 0)
                {
                    return false;
                }
                else
                {
                    DbCommand dbCommand1 = sqlDatabase.GetStoredProcCommand("SEC_User_Insert");
                    sqlDatabase.AddInParameter(dbCommand1, "UserName", DbType.String, UserName);
                    sqlDatabase.AddInParameter(dbCommand1, "Password", DbType.String, Password);
                    sqlDatabase.AddInParameter(dbCommand1, "FirstName", DbType.String, FirstName);
                    sqlDatabase.AddInParameter(dbCommand1, "LastName", DbType.String, LastName);
                    sqlDatabase.AddInParameter(dbCommand1, "EmailAddress", DbType.String, EmailAddress);
                    sqlDatabase.AddInParameter(dbCommand1, "isAdmin", DbType.Boolean, DBNull.Value);
                    sqlDatabase.AddInParameter(dbCommand1, "Created", SqlDbType.DateTime, DBNull.Value);
                    sqlDatabase.AddInParameter(dbCommand1, "Modified", SqlDbType.DateTime, DBNull.Value);
                    if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand1)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
