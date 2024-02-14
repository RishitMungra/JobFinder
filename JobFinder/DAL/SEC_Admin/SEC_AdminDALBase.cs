using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace JobFinder.DAL.SEC_Admin
{
    public class SEC_AdminDALBase : DALHelper
    {
        #region Method : SEC_Admin_Dashboard
        public DataTable SEC_Admin_Dashboard()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("SEC_Admin_Dashboard");
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

        #region Method : SEC_Product_Dashboard
        public DataTable SEC_Product_Dashboard()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("SEC_Admin_Dashboard");
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
    }
}
