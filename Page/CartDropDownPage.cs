using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BaigiamasisDarbas.Page
{
    public class CartDropDownPage : BasePage
    {
        private const string PageAddress = "https://eu.charmedaroma.com/collections/colored-gemstone-collection";

        private IWebElement ChooseSizeButton => Driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div/div/div/div/div[2]/div[7]/div[2]/div[2]/div[2]/div/form/a"));
        private IWebElement AdjustableRingButton => Driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div/div/div/div/div[2]/div[7]/div[2]/div[2]/div[2]/div/form/div[1]/div[2]/div/div[2]/label"));
        private IWebElement AddToCartButton => Driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div/div/div/div/div[2]/div[7]/div[2]/div[2]/div[2]/div/form/div[2]/input"));
        private SelectElement DropDown => new SelectElement(Driver.FindElement(By.CssSelector("#CartContainer > div > form > div.ajaxcart__inner > div > div > div.desktop-7.tablet-4.mobile-3 > div.item_dtl > div > select")));
        private IWebElement ResultTextElement => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/form/div[1]/div/div/div[2]/div[1]/p/p"));
        private IWebElement CartBox => Driver.FindElement(By.Id("CartDrawer"));
        private IWebElement CheckOutButton => Driver.FindElement(By.CssSelector("#CartContainer > div > form > div.ajaxcart__footer.row > button"));

        public CartDropDownPage(IWebDriver webdriver) : base(webdriver)
        {           
        }

        public CartDropDownPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        
        public CartDropDownPage ChooseSize()
        {
            ChooseSizeButton.Click();
            AdjustableRingButton.Click();
            return this;
        }
        
        public CartDropDownPage AddToCartButtonClick()
        {
            AddToCartButton.Click();
            return this;
        }

        private void WaitForCart()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => CartBox.Displayed);
        }

        public CartDropDownPage ClickCheckOutButton()
        {
            CheckOutButton.Click();
            return this;
        }

        public CartDropDownPage VerifyResult(string selectedType)
        {
            WaitForCart();          
            Assert.IsTrue(ResultTextElement.Text.Equals(selectedType), $"Result is wrong, not {selectedType}");
            return this;
        }

        public CartDropDownPage SelectFromDropDownByValue(string text)
        {            
            DropDown.SelectByText(text);
            return this;
        }
    }
}
