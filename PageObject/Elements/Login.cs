using CustomFrameworkPOC.PageObject.Pages;
using Elements;
using OpenQA.Selenium;

namespace CustomFrameworkPOC.PageObject.Elements
{
    public class Login : BaseElement
    {
        public InputField Username => Element.CreateElementByID<InputField>("user-name");
        public InputField Password => Element.CreateElementByID<InputField>("password");
        public Button Loginbutton => Element.CreateElementByID<Button>("login-button");

    }
}
