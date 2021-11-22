using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas.Page
{
    public class SearchPage : BasePage
    {
        private const string PageAddress = "https://eu.charmedaroma.com/";

        private IWebElement SearchButton => Driver.FindElement(By.CssSelector("#cart > li.seeks"));
        private IWebElement InputField => Driver.FindElement(By.CssSelector("#q"));
        private IWebElement SearchSubmitButton => Driver.FindElement(By.CssSelector("#search_button"));
        private IWebElement ResultTextElement1 => Driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div[3]/div/div[1]/div[2]/a/h3"));
        
        public SearchPage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public SearchPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public SearchPage ClickSearchButton()
        {
            SearchButton.Click();
            return this;
        }

        public SearchPage InsertProductToSearchInput(string text)
        {
            InputField.Clear();
            InputField.SendKeys(text);
            return this;
        }

        public SearchPage ClickSubmitSearch()
        {
            SearchSubmitButton.Click();
            return this;
        }

        public SearchPage VerifySearchResults(string product)
        {
            Assert.IsTrue(ResultTextElement1.Text.Equals(product), $"Result is wrong, not {product}");
            return this;
        }

    }
}
