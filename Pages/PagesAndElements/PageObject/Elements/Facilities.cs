using Elements;
using PageObject.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObject.Elements
{
    public class Facilities : BaseElement
    {
        public TextField PageTitle => Element.CreateElementByXpath<TextField>("//span[@class='page-header']/span");
    }
}
