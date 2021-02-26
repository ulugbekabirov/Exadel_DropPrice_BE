using BL.EmailService;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.EmailService
{
    public class ReplacerServiceTests
    {
        [Fact]
        public void Replace_TransmittedString_StringModifiedWithRegulars()
        {
            //arrange
            var replacer = new ReplacerService()
            {
            };
            var expectedOutputString = "Albert Einstein Germanovich you received a 33% discount to Nosochki coupon on 22.01 from a supplier. supplier contact details - Phone:+123321 Email: venor@gmail.com";
            var inputString = "##FirstName## ##LastName## ##Patronymic## you received a ##DiscountValue##% discount to ##DiscountName## coupon on ##Date## from a supplier. supplier contact details - Phone:##VendorPhone## Email: ##VendorEmail##";
            var dictionary = new Dictionary<string, string>
                {
                    { "FirstName", "Albert" },
                    { "LastName", "Einstein" },
                    { "Patronymic", "Germanovich" },
                    { "Date", "22.01" },
                    { "DiscountName", "Nosochki" },
                    { "DiscountValue", "33" },
                    { "Vendor", "Belwest" },
                    { "VendorPhone", "+123321" },
                    { "VendorEmail", "venor@gmail.com" },
                    { "Promocode", null }
                };

            //act
            var outputSting = replacer.Replace(inputString, dictionary);

            //assert
            Assert.Equal(expectedOutputString, outputSting);
        }
    }
}
