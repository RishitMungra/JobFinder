using JobFinder.Areas.Job.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace JobFinder.DAL.Job
{
    public class JobDALBase : DALHelper
    {
        #region Method : Job SelectAll
        public DataTable JobSelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("Job_SelectAll");
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

        #region Method : Job Delete
        public bool JobDelete(int JobID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("Job_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@JobID", DbType.Int32, JobID);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                return isSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : Job Insert and Update
        public bool JobSave(JobModel JobModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (JobModel.JobID == 0 || JobModel.JobID==null)
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("Job_Insert");
                    sqlDatabase.AddInParameter(dbCommand, "@Title", DbType.String, JobModel.Title);
                    sqlDatabase.AddInParameter(dbCommand, "@Description", DbType.String, JobModel.Description);
                    sqlDatabase.AddInParameter(dbCommand, "@Requirements", DbType.String, JobModel.Requirements);
                    sqlDatabase.AddInParameter(dbCommand, "@Location", DbType.String, JobModel.Location);
                    sqlDatabase.AddInParameter(dbCommand, "@Salary", DbType.Decimal, JobModel.Salary);
                    sqlDatabase.AddInParameter(dbCommand, "@Created", DbType.DateTime, DBNull.Value);
                    sqlDatabase.AddInParameter(dbCommand, "@Modified", DbType.DateTime, DBNull.Value);
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
                else
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("Job_Update");
                    sqlDatabase.AddInParameter(dbCommand, "@JobID", DbType.Int32, JobModel.JobID);
                    sqlDatabase.AddInParameter(dbCommand, "@Title", DbType.String, JobModel.Title);
                    sqlDatabase.AddInParameter(dbCommand, "@Description", DbType.String, JobModel.Description);
                    sqlDatabase.AddInParameter(dbCommand, "@Requirements", DbType.String, JobModel.Requirements);
                    sqlDatabase.AddInParameter(dbCommand, "@Location", DbType.String, JobModel.Location);
                    sqlDatabase.AddInParameter(dbCommand, "@Salary", DbType.Decimal, JobModel.Salary);
                    sqlDatabase.AddInParameter(dbCommand, "@Modified", DbType.DateTime, DBNull.Value);
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : Job By ID
        public JobModel JobByID(int JobID)
        {
            JobModel JobModel = new JobModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("Job_SelectByID");
                sqlDatabase.AddInParameter(dbCommand, "@JobID", DbType.Int32, JobID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    
                        JobModel.JobID = Convert.ToInt32(dataRow["JobID"]);
                        JobModel.Title = dataRow["Title"].ToString();
                        JobModel.Description = dataRow["Description"].ToString();
                        JobModel.Requirements = dataRow["Requirements"].ToString();
                        JobModel.Location = dataRow["Location"].ToString();
                        JobModel.Salary = dataRow["Salary"].ToString();
                        JobModel.Created = Convert.ToDateTime(dataRow["Created"]);
                        JobModel.Modified = Convert.ToDateTime(dataRow["Modified"]);
                }
                return JobModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
