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
    public class HomePage : BasePage
    {
        private const string PageAddress = "https://eu.charmedaroma.com/";
        private const string ProductResultText = "Candy Cane Lane Candle - Ring Collection";
        private const string SizeResultText = "Size 6";

        private IWebElement AddToCartButton => Driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div[3]/section/div/div/div[2]/div[6]/div[2]/div[2]/div/form/div[2]/input"));
        private IWebElement ChooseSizeButton => Driver.FindElement(By.CssSelector("#product_form_6622599446622 > a"));
        private IWebElement SizeButton => Driver.FindElement(By.CssSelector("#product_form_6622599446622 > div.choose-variants > div.swatch.clearfix > div > div:nth-child(2) > label"));
        private IWebElement ProductResultTextElement => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/form/div[1]/div/div/div[2]/div[1]/p/a/b"));
        private IWebElement SizeResultTextElement => Driver.FindElement(By.CssSelector(".ajaxcart__product-meta"));
        private IWebElement CartBox => Driver.FindElement(By.Id("CartDrawer"));
        private IWebElement BathBombsCategory => Driver.FindElement(By.XPath("/html/body/div[2]/div[1]/header/div[2]/div/div/nav/ul/li[4]/a"));
        private IWebElement BathSaltsCategory => Driver.FindElement(By.XPath("/html/body/div[2]/div[1]/header/div[2]/div/div/nav/ul/li[4]/ul/div/li[1]/ul/li[2]/a"));
            
        public HomePage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public HomePage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public HomePage ChooseCategory()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(BathBombsCategory);
            action.Click(BathSaltsCategory);
            return this;
        }

        public HomePage ChooseSize()
        {
            ChooseSizeButton.Click();
            SizeButton.Click();
            return this;
        }

        public HomePage AddToCart()
        {
            AddToCartButton.Click();
            return this;
        }

        private void WaitForCart()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => CartBox.Displayed);
        }

        public HomePage VerifyProductResult(string selectedProduct)
        {
            WaitForCart();
            Assert.IsTrue(ProductResultTextElement.Text.Equals(ProductResultText), $"Result is wrong, not {selectedProduct}");
            return this;
        }

        public HomePage VerifySizeResult(string selectedSize)
        {
            Assert.IsTrue(SizeResultTextElement.Text.Equals(SizeResultText), $"Result is wrong, not {selectedSize}");
            return this;
        }
    }
}
