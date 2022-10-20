using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CoreServices.Performance
{
    public class DBHelper
    {
        string connString;
        SqlConnection conn;
       public DBHelper()
        {
            connString = @"Data Source=localhost\SQLEXPRESS01;Initial Catalog=PerformanceMetricsForAAD;Integrated Security=SSPI";
            conn = new SqlConnection(connString);
            conn.Open();
        }

        public DBHelper WriteDatatoTable(string testname,PerformanceMetrics perf)
        {
            string testID;
            if (!checkTestCaseExists(testname))
            {
                Guid myuuid = Guid.NewGuid();
                testID = myuuid.ToString();
                string sqll = $"INSERT INTO TestNameTable (TestName,TestCaseID) values ('{testname}','{testID}');";
                WriteToTable(sqll);
            }
            testID = GetTestCaseId(testname);
            string sql;
            sql = $"INSERT INTO TestResponseTime (TestCaseID,Date,ResponseTime,DOMLoadTime,TotalTime) values('{testID}','{DateTime.Now}'," +
                    $"{perf.TotalResponseTime},{perf.DomLoaded},{perf.TotalTimeTaken});";
            WriteToTable(sql);
            return this;
        }

        private DBHelper WriteToTable(string sql)
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            command = new SqlCommand(sql);
            adapter.InsertCommand = new SqlCommand(sql, conn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            return this;
        }
        private bool checkTestCaseExists(string testName)
        {
            string sql = $"SELECT COUNT(*) FROM TestNameTable where [TestName] = '{testName}'";
            SqlCommand comm = new SqlCommand(sql, conn);
            int count = (int)comm.ExecuteScalar();
            if (count > 0)
                return true;
            else
                return false;
        }

        private string GetTestCaseId(string testName)
        {
            string sql = $"SELECT TestCaseID FROM TestNameTable where [TestName] = '{testName}'";
            SqlCommand comm = new SqlCommand(sql, conn);
            string value = comm.ExecuteScalar().ToString();

            return value;
            
        }
        public DBHelper closeConn()
        {
            conn.Close();
            return this;
        }
    }
}
