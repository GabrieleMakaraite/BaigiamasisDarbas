using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas.Test
{
    public class QuantityTest : BaseTest
    {
        [Test]
        public void TestQuantity()
        {
            _quantityPage.NavigateToDefaultPage().InsertQuantity("2").ClickAddToCartButton().ClickCheckOutButton()
                .VerifyResult("2");

        }
    }
}
