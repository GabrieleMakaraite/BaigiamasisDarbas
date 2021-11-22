using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaigiamasisDarbas.Page
{
    public class ProductsSortPage : BasePage
    {
        private const string PageAddress = "https://eu.charmedaroma.com/collections/bath-salts";
        private const string ResultText1 = "Candy Cane Lane Bath Salts - Adjustable Ring Collection";
        private const string ResultText2 = "Coconut Vanilla Bath Salts - Adjustable Ring Collection";
        private const string ResultText3 = "Hemp Bath Salts - Adjustable Ring Collection";
        private const string ResultText4 = "Lavender Bath Salts - Adjustable Ring Collection";
        private const string ResultText5 = "Peach Sugar Kiss Bath Salts - Adjustable Ring Collection";
        
        private IWebElement SortDropDown => Driver.FindElement(By.CssSelector("#full-width-filter > div:nth-child(1)"));
        private IWebElement AlphabeticallyButton => Driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div/div/div/div/div[2]/div[1]/div[1]/ul/li[3]/a"));   
        private IWebElement ResultTextElement1 => Driver.FindElement(By.CssSelector("#prod-6618688389214 > div.ci > div.product-title > a > h3"));
        private IWebElement ResultTextElement2 => Driver.FindElement(By.CssSelector("#prod-6633376874590 > div.ci > div.product-title > a > h3"));
        private IWebElement ResultTextElement3 => Driver.FindElement(By.CssSelector("#prod-6618688553054 > div.ci > div.product-title > a > h3"));
        private IWebElement ResultTextElement4 => Driver.FindElement(By.CssSelector("#prod-6618688356446 > div.ci > div.product-title > a > h3"));
        private IWebElement ResultTextElement5 => Driver.FindElement(By.CssSelector("#prod-6618688421982 > div.ci > div.product-title > a > h3"));

        public ProductsSortPage(IWebDriver webdriver) : base(webdriver)
        {          
        }

        public ProductsSortPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public ProductsSortPage ClickDropDownButton()
        {
            SortDropDown.Click();
            return this;
        }

        public ProductsSortPage ChooseSortAlphabetically()
        {            
            AlphabeticallyButton.Click();
            return this;
        }
        
        public ProductsSortPage VerifySortResult()
        {
            Assert.IsTrue(ResultTextElement1.Text.Equals(ResultText1), $"Result is wrong, not {ResultText1}");
            Assert.IsTrue(ResultTextElement2.Text.Equals(ResultText2), $"Result is wrong, not {ResultText2}");
            Assert.IsTrue(ResultTextElement3.Text.Equals(ResultText3), $"Result is wrong, not {ResultText3}");
            Assert.IsTrue(ResultTextElement4.Text.Equals(ResultText4), $"Result is wrong, not {ResultText4}");
            Assert.IsTrue(ResultTextElement5.Text.Equals(ResultText5), $"Result is wrong, not {ResultText5}");
            return this;
        }

    }
}
