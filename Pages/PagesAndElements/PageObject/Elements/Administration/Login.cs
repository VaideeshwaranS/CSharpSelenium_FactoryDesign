using Elements;
using PageObject.Elements;

namespace PagesAndElements.PageObject.Elements.Administration
{
    public class Login : BaseElement
    {
        public InputField Username => Element.CreateElementByID<InputField>("signInName");
        public InputField Password => Element.CreateElementByID<InputField>("password");
        public Button Continuebutton => Element.CreateElementByID<Button>("continue");
        public Button Next => Element.CreateElementByID<Button>("next");

    }
}
