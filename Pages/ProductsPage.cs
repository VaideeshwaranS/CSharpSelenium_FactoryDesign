using DriverManager;
using Elements;

namespace Pages
{
    public class ProductsPage : Page
    {
        public ProductDetailPage productdetail;
        public ProductsPage(DriverFactory instance) : base(instance)
        {
            productdetail = new ProductDetailPage(instance);
        }

        public Hyperlink Productname(string pname) => Element.CreateElementByXpath<Hyperlink>($"//div[contains(text(),'{pname}')]");
    }
}
