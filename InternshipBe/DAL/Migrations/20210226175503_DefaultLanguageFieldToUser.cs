using Microsoft.EntityFrameworkCore.Migrations;
using Shared.Middleware.Localization;

namespace DAL.Migrations
{
    public partial class DefaultLanguageFieldToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultLanguage",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: Cultures.DefaultCulture);

            migrationBuilder.Sql($"UPDATE AspNetUsers SET DefaultLanguage = '{Cultures.Russian}' WHERE Id <= 5;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultLanguage",
                table: "AspNetUsers");
        }
    }
}
