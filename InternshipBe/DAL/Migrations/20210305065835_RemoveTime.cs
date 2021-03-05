using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RemoveTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE Discounts 
                                   SET StartDate = DATEADD(dd, DATEDIFF(dd, 0, StartDate), 0),
                                   EndDate = DATEADD(dd, DATEDIFF(dd, 0, EndDate), 0);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
