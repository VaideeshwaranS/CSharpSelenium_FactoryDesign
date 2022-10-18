using DriverManager;
using Elements;
using Pages;


namespace CustomFrameworkPOC.Pages
{
    public class Spinner
    {
        ElementService Element;
        public Spinner(DriverFactory instance, ElementService Element)
        {
            this.Element = Element;
        }

        public Icon SpinnerIcon => Element.CreateElementByXpath<Icon>("//app-loader/div/div[@class='soc-loading-image']");
        
    }
}
