using DriverManager;
using Elements;


namespace Pages
{
    public class Page
    {

        public Page(DriverFactory instance)
        {
            this.instance = instance;
            Element = GetElementService(instance);
        }

        private static ElementService GetElementService(DriverFactory instance)
        {
            return new ElementService(instance);
        }

        protected ElementService Element;
        protected DriverFactory instance;

    }
}
