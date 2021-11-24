using BaigiamasisDarbas.Drivers;
using BaigiamasisDarbas.Page;
using BaigiamasisDarbas.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BaigiamasisDarbas.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;

        public static ProductsSortPage _productsSortPage;
        public static JewelryAppraisalPage _jewelryAppraisalPage;
        public static CartDropDownPage _cartDropDownPage;
        public static CartPage _cartPage;
        public static SearchPage _searchPage;
        public static CountryPage _countryPage;
        public static HomePage _homePage;
        public static QuantityPage _quantityPage;

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            //driver = CustomDriver.GetIncognitoChromeDriver();

            _productsSortPage = new ProductsSortPage(driver);
            _jewelryAppraisalPage = new JewelryAppraisalPage(driver);
            _cartDropDownPage = new CartDropDownPage(driver);
            _cartPage = new CartPage(driver);
            _searchPage = new SearchPage(driver);
            _countryPage = new CountryPage(driver);
            _homePage = new HomePage(driver);
            _quantityPage = new QuantityPage(driver);

        }
        [TearDown]
        public static void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreenshot(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }
    }
}
