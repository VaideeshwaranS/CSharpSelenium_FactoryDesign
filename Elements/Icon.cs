using OpenQA.Selenium;

namespace Elements
{
    public class Icon : WebElement
    {
        public Icon(WebDriver driver, By by) : base(driver, by)
        {
        }

        public bool IsDisplayed(bool shouldBe = false, int waitTill = 60 )
        {
            bool result;
            if (!shouldBe)
            {
                result = WaitForInvisibilityofElement(waitTill);
            }
            else
            {
                result = WaitForVisibilityofElement(waitTill);
            }
            return result;
        }
    }
}
