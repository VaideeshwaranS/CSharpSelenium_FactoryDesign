using DriverManager;
using Elements;

namespace Pages
{
    public class ProductDetailPage : Page
    {
        public ProductDetailPage(DriverFactory instance) : base(instance)
        {
        }

        public TextField ProductDesc(string pname) => Element.CreateElementByXpath<TextField>($"//div[contains(text(),'{pname}')]/following-sibling::div");
    }
}
