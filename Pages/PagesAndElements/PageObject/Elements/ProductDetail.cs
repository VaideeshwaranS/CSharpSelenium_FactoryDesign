using Elements;

namespace PageObject.Elements
{
    public class ProductDetail : BaseElement
    {     
        public TextField ProductDesc(string pname) => Element.CreateElementByXpath<TextField>($"//div[contains(text(),'{pname}')]/following-sibling::div");
    }
}
