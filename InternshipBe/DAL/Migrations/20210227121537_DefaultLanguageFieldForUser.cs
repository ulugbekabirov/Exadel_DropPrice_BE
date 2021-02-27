using Microsoft.EntityFrameworkCore.Migrations;
using Shared.Middleware.Localization;

namespace DAL.Migrations
{
    public partial class DefaultLanguageFieldForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultLanguage",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: Cultures.DefaultCulture);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultLanguage",
                table: "AspNetUsers");
        }
    }
}
