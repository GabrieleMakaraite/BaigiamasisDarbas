using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaigiamasisDarbas.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BaigiamasisDarbas.Test
{
    public class CharmedAromaTest : BaseTest
    {          
        [Order(1)]
        [Test]
        public void TestPopUpCart()
        {
            _homePage.NavigateToDefaultPage().ChooseSize().AddToCart()
                .VerifyProductResult("Candy Cane Lane Candle - Ring Collection")
                .VerifySizeResult("Size 6");                  
        }

        [Order(2)]
        [Test]
        public void TestSort()
        {
            _homePage.NavigateToDefaultPage().ChooseCategory();
            _productsSortPage.NavigateToDefaultPage().ClickDropDownButton().ChooseSortAlphabetically().VerifySortResult();
        }

        [Order(3)]
        [TestCase("gabyte.mm@gmail.com","2GZZL7", "Appraised for $55", TestName = "Check jewelry code 2GZZL7")]
        [TestCase("gabyte.mm@gmail.com","JKSRE5", "Appraised for $55", TestName = "Check jewelry code JKSRE5")]
        public void TestJewelryAppraisal(string email, string code, string expectedResult)
        {
            _jewelryAppraisalPage.NavigateToDefaultPage().InsertEmail(email).InsertCode(code).ClickAppraisalButton()
                .VerifyAppraisalResult(expectedResult);
        }

        [Order(4)]
        [TestCase("Polar Bear Queen Candle - 925 Sterling Silver Polar Bear Necklace Collection", TestName = "Search Bear Candle")]
        [TestCase("Penguin Bath Bomb - Blue Opal Ring Collection", TestName = "Search Penguin Bath Bomb")]
        public void TestSearch(string product)
        {
            _searchPage.NavigateToDefaultPage().ClickSearchButton().InsertProductToSearchInput(product).ClickSubmitSearch()
                .VerifySearchResults(product);
        }      

        [Order(5)]
        [Test]
        public void TestCountryDropDown()
        {
            _countryPage.NavigateToDefaultPage().ClickCountrySelector().ChooseCountry().VerifyResult();
        }                  
    }
}
