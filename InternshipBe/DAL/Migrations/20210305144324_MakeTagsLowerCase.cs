using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class MakeTagsLowerCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Update Tags set Name = LOWER(Name)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
