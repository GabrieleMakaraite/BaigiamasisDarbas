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
    public class JewelryAppraisalPage : BasePage
    {
        private const string PageAddress = "https://eu.charmedaroma.com/pages/appraisal";
        
        private IWebElement EmailInput => Driver.FindElement(By.Id("email"));
        private IWebElement CodeInput => Driver.FindElement(By.Id("aprCode"));
        private IWebElement AppraisalResultTextElement => Driver.FindElement(By.Id("aprResult"));        
        private IWebElement AppraiseButton => Driver.FindElement(By.Id("aprSubmit"));
        private IWebElement ResultTextBox => Driver.FindElement(By.CssSelector("#aprResult"));

        public JewelryAppraisalPage(IWebDriver webdriver) : base(webdriver)
        {            
        }

        public JewelryAppraisalPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public JewelryAppraisalPage InsertEmail(string email)
        {
            EmailInput.Clear();
            EmailInput.SendKeys(email);
            return this;
        }

        public JewelryAppraisalPage InsertCode(string code)
        {
            CodeInput.Clear();
            CodeInput.SendKeys(code);
            return this;
        }

        public JewelryAppraisalPage ClickAppraisalButton()
        {
            AppraiseButton.Click();
            return this;
        }

        private void WaitForResult()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => ResultTextBox.Displayed);
        }

        public JewelryAppraisalPage VerifyAppraisalResult(string expectedResult)
        {
            WaitForResult();
            Assert.IsTrue(AppraisalResultTextElement.Text.Contains(expectedResult), $"Result is wrong, not {expectedResult}");
            return this;
        }
    }

}
