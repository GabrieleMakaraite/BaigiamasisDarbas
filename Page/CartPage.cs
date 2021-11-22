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
    public class CartPage : BasePage
    {
        private const string PageAddress = "https://eu.charmedaroma.com/21207435/checkouts/4180e862545dfc500a31d4fee277d90d";
        private IWebElement ResultTExtElement => Driver.FindElement(By.CssSelector("#order-summary > div > div.order-summary__section.order-summary__section--product-list > div > table > tbody > tr > th > span.product__description__variant.order-summary__small-text"));
        public CartPage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public CartPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public CartPage VerifyResult(string selectedType)
        {
            Assert.IsTrue(ResultTExtElement.Text.Equals(selectedType), $"Result is wrong, not {selectedType}");
            return this;
        }
    }
}
