using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMService.Migrations
{
    public partial class Fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                schema: "Contractor",
                table: "Groups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                schema: "Contractor",
                table: "Contractors",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "Contractor",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "Contractor",
                table: "Contractors");
        }
    }
}
