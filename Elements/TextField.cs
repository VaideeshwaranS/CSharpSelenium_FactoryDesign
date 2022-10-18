using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
     public class TextField : WebElement
    {
        public TextField(WebDriver driver, By by) : base(driver, by)
        {
        }

        public string GetText()
        {
            return _webElement.Text.Trim();
        }

        public bool isDisplayed(int maxSec=60)
        {
            return WaitForVisibilityofElement(maxSec);
        }

        public string GetValueofAttribute(string attrib)
        {
            return _webElement.GetAttribute(attrib).ToString();
        }
    }
}
