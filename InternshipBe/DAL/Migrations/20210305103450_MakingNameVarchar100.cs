using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class MakingNameVarchar100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE Discounts ADD TempName nvarchar(100) NOT NULL default ''; 
                                   ALTER TABLE Vendors ADD TempName nvarchar(100) NOT NULL default '';
                                   ALTER TABLE Tags ADD TempName nvarchar(100) NOT NULL default'';");

            migrationBuilder.Sql("UPDATE Discounts SET TempName = Discounts.Name;");
            migrationBuilder.Sql("UPDATE Tags SET TempName = Tags.Name;");
            migrationBuilder.Sql("UPDATE Vendors SET TempName = Vendors.Name;");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Discounts");

            migrationBuilder.Sql("sp_rename 'Discounts.TempName', 'Name', 'COLUMN';");
            migrationBuilder.Sql("sp_rename 'Tags.TempName', 'Name', 'COLUMN';");
            migrationBuilder.Sql("sp_rename 'Vendors.TempName', 'Name', 'COLUMN';");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
