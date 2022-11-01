using AventStack.ExtentReports.MarkupUtils;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
using System;
using System.Data;
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

        public string GetMetricsTableForLast5Date(string testName)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Date", typeof(string)),
                    new DataColumn("Time Taken in (ms)", typeof(string)) });
            string oString = $"SELECT TOP (5) [Date],[TotalTime] FROM TestResponseTime where TestCaseID = (SELECT TestCaseID from TestNameTable where [TestName] = '{testName}') ORDER BY Date desc ";
            SqlCommand oCmd = new SqlCommand(oString, conn);
            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    dt.Rows.Add(oReader["Date"].ToString(), oReader["TotalTime"].ToString());                        
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 9pt;font-family:Arial'>");
            sb.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + column.ColumnName + "</th>");
            }
            sb.Append("</tr>");
            foreach (DataRow row in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    sb.Append("<td style='width:200px;border: 1px solid #ccc'> <b>" + row[column.ColumnName].ToString() + "</b></td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            return sb.ToString();

        }

        public IMarkup GetTableMarkupforLast5Runs(string testName)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Date", typeof(string)),
                    new DataColumn("TotalTime", typeof(string)) });
            string oString = $"SELECT TOP (5) [Date],[TotalTime] FROM TestResponseTime where TestCaseID = (SELECT TestCaseID from TestNameTable where [TestName] = '{testName}') ORDER BY Date desc ";
            SqlCommand oCmd = new SqlCommand(oString, conn);
            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    dt.Rows.Add(oReader["Date"].ToString(), oReader["TotalTime"].ToString());
                }
            }
            string[,] data = new string[dt.Rows.Count+1, 2];
            data[0,0] = "Date";
            data[0,1] = "Time Taken in (ms)";
            int i = 1;
            foreach(DataRow r in dt.Rows)
            {
                data[i,0] = r["Date"].ToString();
                data[i,1] = r["TotalTime"].ToString();
                i++;
            }
            var m = MarkupHelper.CreateTable(data);
            return m;
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
