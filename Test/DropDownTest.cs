using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas.Test
{
    public class DropDownTest : BaseTest
    {
        [Test]
        public void TestDropDown()
        {
            _cartDropDownPage.NavigateToDefaultPage().ChooseSize().AddToCartButtonClick()
                .VerifyResult("Adjustable Ring").SelectFromDropDownByValue("Necklace")
                .ClickCheckOutButton();
            _cartPage.NavigateToDefaultPage().VerifyResult("Necklace");
        }
    }
}
