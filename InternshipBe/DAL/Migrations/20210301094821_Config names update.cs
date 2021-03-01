using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Confignamesupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE ConfigVariables SET Name = 'Sending email toggler' Where Name='SendingEmailToggler';
                                   UPDATE ConfigVariables SET Name = 'Discount edit time in minutes' Where Name='DiscountEditTimeInMinutes';
                                   UPDATE ConfigVariables SET Name = 'Email body for User in English' Where Name='EnMessageForUser';
                                   UPDATE ConfigVariables SET Name = 'Email body for Vendor in English' Where Name='EnMessageForVendor';
                                   UPDATE ConfigVariables SET Name = 'Email body for User in Russian' Where Name='RuMessageForUser';
                                   UPDATE ConfigVariables SET Name = 'Email body for Vendor in Russian' Where Name='RuMessageForVendor';");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
