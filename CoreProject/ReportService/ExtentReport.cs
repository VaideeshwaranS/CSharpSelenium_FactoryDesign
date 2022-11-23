using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Xml.Linq;

namespace CoreServices.ReportService
{
    public interface IReportService
    {
        ExtentReports GetExtentReport();
        void StartReport();
        void CloseReport();
        void StartNewTest(string testName);
        void CreateTestMethod(string testMethod);
        void PerfLogTest(Status logStatus, string message);
        void LogReport(Status logStatus, string message);


    }
    public class ExtentReport : IReportService
    {
        private const string reportDir = "Reports\\PerformanceReport.html";
        private ExtentReports _extent;
        private ExtentTest _Perftest;
        private ExtentTest _test;
        private ExtentTest _testlog1;
        private ExtentTest _testlog2;
        private string projectPath;
        public void StartReport()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = Path.Combine(projectPath, reportDir);
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Host Name", "Automation POC for Performance Test");
            _extent.AddSystemInfo("Environment", "UAT - Test Environment");
            _extent.AddSystemInfo("UserName", "AAD Team");

            _Perftest = _extent.CreateTest("AAD - Consolidated Performance Report");
            ServiceRegister.perfConsolidated.Columns.AddRange(new DataColumn[4] { new DataColumn("Test Name", typeof(string)),
                new DataColumn("DOM Loading Time (ms)", typeof(string)),
                new DataColumn("Response Time (ms)", typeof(string)),
                new DataColumn("Total Time Taken (Secs)", typeof(string)) });
        }

        public void CloseReport()
        {
            string[,] data = new string[ServiceRegister.perfConsolidated.Rows.Count + 1, 4];
            data[0, 0] = "Test Name";
            data[0, 1] = "DOM Loading Time (ms)";
            data[0, 2] = "Response Time (ms)";
            data[0, 3] = "Total Time Taken (Secs)";
            int i = 1;
            foreach (DataRow r in ServiceRegister.perfConsolidated.Rows)
            {
                data[i, 0] = r["Test Name"].ToString();
                data[i, 1] = r["DOM Loading Time (ms)"].ToString();
                data[i, 2] = r["Response Time (ms)"].ToString();
                data[i, 3] = r["Total Time Taken (Secs)"].ToString();
                i++;
            }
            var m = MarkupHelper.CreateTable(data);
            _Perftest.Log(Status.Info, "<b>Performance Report Consolidated : <br>" + m.GetMarkup() + "</b>");
            string mail_summary = "<!DOCTYPE html><html>";
            mail_summary += "<head><style>table, th, td { border: 1px solid black;}</style></head>";
            mail_summary += "<body><h2 align='center'><font color = 'blue'>3M - Repair Stack</h2></font><br>" +
                "<h3 align='center'><font color = 'red'>Performance Report - Consolidated</h3></font><br>";
            mail_summary += "<p><i>Please Find the Attached Report for details</i> </p><br><b>";
            mail_summary += m.GetMarkup();
            mail_summary += "</b></body></html>";
            _extent.Flush();
            
            //SendEmail(mail_summary);
        }

        private void SendEmail(string mailSummary)
        {
            string pathReport = projectPath + "Reports\\index.html";

            SmtpClient SmtpServer = new SmtpClient();
            //SmtpServer.EnableSsl = true;
            SmtpServer.Host = "MBSSupercop.cit.congruentindia.com";
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("vaideeshwaran.s@congruentindia.com", "Oct31@2022");

            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.From = new MailAddress("vaideeshwaran.s@congruentindia.com");

            mail.To.Add("vaideeshwaran.s@congruentindia.com");
           // mail.To.Add("logesh.r@congruentindia.com");
            //mail.CC.Add("santhoshkumar.r@congruentindia.com");
            mail.Subject = "AAD Performance Report";
            mail.Body = mailSummary;

            mail.BodyEncoding = System.Text.Encoding.UTF8;

            //attach the Extend Report 
            Attachment attachment = new Attachment(pathReport);
            mail.Attachments.Add(attachment);


            try
            {
                SmtpServer.Send(mail);
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }
        }

        public ExtentReports GetExtentReport()
        {
            return _extent;
        }
        public void PerfLogTest(Status logStatus, string message)
        {
            _testlog1.Log(logStatus, message);
        }
        public void StartNewTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }

        public void CreateTestMethod(string testMethod)
        {
            _testlog1 = _test.CreateNode(testMethod);
            _testlog2 = _testlog1.CreateNode("Detailed Log");
        }

     
        public void LogReport(Status logStatus, string message)
        {
            _testlog2.Log(logStatus, message);
        }


    }
}
