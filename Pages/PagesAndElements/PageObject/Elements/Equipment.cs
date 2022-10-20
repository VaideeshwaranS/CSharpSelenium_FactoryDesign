using Elements;
using PageObject.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObject.Elements
{
    public class Equipment : BaseElement
    {
        public TextField Tab(string tabName) => Element.CreateElementByXpath<TextField>($"//tabset//li[contains(@class,'nav-item')]//span/span[normalize-space()='{tabName}']");
    }
}
