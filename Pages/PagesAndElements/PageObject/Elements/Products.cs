using Elements;

namespace PageObject.Elements
{
    public class Products : BaseElement
    {
        public ProductDetail productDetail => new ProductDetail();
        public Hyperlink Productname(string pname) => Element.CreateElementByXpath<Hyperlink>($"//div[contains(text(),'{pname}')]");
    }
}
