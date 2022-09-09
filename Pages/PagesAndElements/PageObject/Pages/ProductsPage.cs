using AventStack.ExtentReports;
using PageObject.Elements;

namespace PageObject.Pages
{
    public class ProductsPage :Page<Products>
    {
        public void ClickProduct(string name)
        {
            report.LogReport(Status.Info, $"Clicking on the product {name} ");
            page.Productname(name).Click();
        }

        public string GetProductDesc(string name)
        {
            report.LogReport(Status.Info, $"Getting Description of the product {name} ");
            return page.productDetail.ProductDesc(name).GetText();
        }
    }
}
