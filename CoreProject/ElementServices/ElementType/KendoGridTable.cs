using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;

namespace Elements
{
    public class KendoGridTable : WebElement
    {
       DataTable Grid = new DataTable();
        public KendoGridTable(IWebDriver driver, By by) : base(driver, by)
        {
        }
        public KendoGridTable(IWebDriver driver, IWebElement element, By by) : base(driver, element, by)
        {
        }
        private void GetHeaderList()
        {
            List<TextField> headers = FindAllChildElementByXpath<TextField>("//div[@class='k-grid-header-wrap']/table//th//span[contains(@class,'k-link')]");
            foreach (TextField field in headers)
            {
                var columnName = field.GetText();
                Grid.Columns.Add(new DataColumn(columnName,typeof(string)));
            }
        
        }

        public void SelectRowFromGrid()//string fieldName, string value)
        {
            GetHeaderList();
            List<TextField> Rows = FindAllChildElementByXpath<TextField>("//kendo-grid-list//tbody//tr");
            int i = 1;
            foreach(TextField row in Rows)
            {
                List<TextField> fields = row.FindAllChildElementByXpath<TextField>("[i]/td/span");
                string[] rowVal = new string[fields.Count -1];
                for(int k = 0; k < fields.Count-2; k++)
                {
                    rowVal[k] = fields[k+1].GetText();
                }
                Grid.Rows.Add(rowVal);
                i++;
            }

            foreach(DataRow row in Grid.Rows)
            {
                Console.WriteLine(row["Name"]);
            }
            
        }

    }
}
