using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaigiamasisDarbas.Page
{
    public class QuantityPage : BasePage
    {
        private const string PageAddress = "https://eu.charmedaroma.com/collections/all-candles/products/hawaiian-oasis-candle-necklace-collection";

        private IWebElement InputField => Driver.FindElement(By.CssSelector("#AddToCartForm > div.product-qty.selector-wrapper > input"));
        private IWebElement AddToCartButton => Driver.FindElement(By.Id("AddToCart"));
        private IWebElement CartBox => Driver.FindElement(By.Id("CartDrawer"));
        private IWebElement ResultElement => Driver.FindElement(By.XPath("/html/body/div[1]/div/aside/div[2]/div[1]/div/div[1]/div/table/tbody/tr/td[1]/div/span"));
        private IWebElement CheckOutButton => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/form/div[2]/button"));
        private IWebElement CartButton => Driver.FindElement(By.CssSelector("body > div.content > div > div > header > nav > ol > li.breadcrumb__item.breadcrumb__item--completed > a"));

        public QuantityPage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public QuantityPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public QuantityPage InsertQuantity(string quantity)
        {
            InputField.Clear();
            InputField.SendKeys(quantity);
            return this;
        }

        public QuantityPage ClickAddToCartButton()
        {
            AddToCartButton.Click();
            return this;
        }

        private void WaitForCart()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => CartBox.Displayed);
        }
        public QuantityPage ClickCheckOutButton()
        {
            WaitForCart();
            CheckOutButton.Click();
            return this;
        }

        public QuantityPage VerifyResult(string expectedResult)
        {
            
            Assert.IsTrue(ResultElement.Text.Equals(expectedResult), $"Quantity is not {expectedResult}");
            return this;
        }
        public QuantityPage ClickCartButton()
        {
            CartButton.Click();
            return this;
        }        
    }
}
