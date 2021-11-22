using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas.Page
{
    public class FreeGiftPage : BasePage
    {
        private const string PageAddress = "https://eu.charmedaroma.com/collections/holiday-sale-2021/products/snow-angels-mug-candle-925-sterling-silver-angel-wing-necklace-collection";
        private const string PriceResultText = "€0.00";
        private IWebElement InputField => Driver.FindElement(By.CssSelector("#AddToCartForm > div.product-qty.selector-wrapper > input"));
        private IWebElement AddToCartButton => Driver.FindElement(By.Id("AddToCart"));
        private IWebElement CartBox => Driver.FindElement(By.Id("CartDrawer"));
        private IWebElement PriceResultElement => Driver.FindElement(By.CssSelector("#CartContainer > div > form > div.ajaxcart__inner > div:nth-child(2) > div > div.desktop-7.tablet-4.mobile-3 > div.item_dtl > div > p > span"));
        
        public FreeGiftPage(IWebDriver webdriver) : base(webdriver)
        {       
        }

        public FreeGiftPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public FreeGiftPage InsertQuantity(string quantity)
        {
            InputField.Clear();
            InputField.SendKeys(quantity);
            return this;
        }

        public FreeGiftPage ClickAddToCartButton()
        {
            AddToCartButton.Click();
            return this;
        }

        private void WaitForCart()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => CartBox.Displayed);
        }

        public FreeGiftPage VerifyResult()
        {
            WaitForCart();
            Assert.IsTrue(PriceResultElement.Text.Equals(PriceResultText), "Price is not 0.00");
            return this;
        }
    }
}
