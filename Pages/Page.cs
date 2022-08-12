using DriverManager;
using Elements;


namespace Pages
{
    public abstract class Page
    {

        public Page(DriverInstance instance)
        {
            this.instance = instance;
            Element = new ElementService(instance);
        }

        protected ElementService Element;
       protected DriverInstance instance;
    }
}
