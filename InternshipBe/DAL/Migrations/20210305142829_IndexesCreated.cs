using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class IndexesCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Create Index ix_discounts_name on Discounts(Name);");
            migrationBuilder.Sql("Create Index ix_tags_name on Tags(Name);");
            migrationBuilder.Sql("Create Index ix_vendors_name on Vendors(Name);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP INDEX IF EXISTS ix_discounts_name on Discounts;");
            migrationBuilder.Sql("DROP INDEX IF EXISTS ix_tags_name on Tags;");
            migrationBuilder.Sql("DROP INDEX IF EXISTS ix_vendors_name on Vendors;");
        }
    }
}
