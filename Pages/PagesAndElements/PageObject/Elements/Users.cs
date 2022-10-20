using Elements;
using PageObject.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObject.Elements
{
    public class Users : BaseElement
    {
        public TextField PageTitle => Element.CreateElementByXpath<TextField>("//h4[contains(@class,'page-title')]");
    }
}
