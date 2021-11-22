using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas.Page
{
    public class CountryPage : BasePage
    {
        private const string PageAddress = "https://eu.charmedaroma.com/";
        private const string ResultText = "CAD";
        private IWebElement CountryButton => Driver.FindElement(By.CssSelector("#cart > li:nth-child(5) > div > div.flag-dropdown > div > div > div"));
        private IWebElement ResultTextElement => Driver.FindElement(By.XPath("/html/body/header/section[1]/div[1]/div/div[2]/div[1]/span"));
        private IWebElement CanadaButton => Driver.FindElement(By.CssSelector("#cart > li:nth-child(5) > div > div.flag-dropdown > ul > li:nth-child(2)"));
        private IWebElement DetailsButton => Driver.FindElement(By.CssSelector("#epb_button"));
        private IWebElement ShopNowButton => Driver.FindElement(By.CssSelector("#cboxLoadedContent > p:nth-child(12) > input"));

        public CountryPage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public CountryPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public CountryPage ClickCountrySelector()
        {
            CountryButton.Click();
            return this;
        }

        public CountryPage ChooseCountry()
        {
            CanadaButton.Click();
            return this;
        }

        public CountryPage ClosePopUp()
        {
            DetailsButton.Click();
            ShopNowButton.Click();
            return this;
        }

        public CountryPage VerifyResult()
        {
            Assert.IsTrue(ResultTextElement.Text.Equals(ResultText), "Country is not Canada");
            return this;
        }
    }
}
