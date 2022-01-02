using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CRMService.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Contractor");

            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "Contractor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contractors",
                schema: "Contractor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    FullName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    EMail = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    SiteLink = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ActualAddress = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    LegalTitle = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LegalAddress = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    INN = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OGRN = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    KPP = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OKPO = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CertificateNumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CertificateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contractors_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Contractor",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "Contractor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Position = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    ContractorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalSchema: "Contractor",
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "Contractor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BankName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BankBIC = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BankBill = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BankAddress = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    KBill = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    RBill = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    ContractorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalSchema: "Contractor",
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContractorId",
                schema: "Contractor",
                table: "Contacts",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_GroupId",
                schema: "Contractor",
                table: "Contractors",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ContractorId",
                schema: "Contractor",
                table: "Payments",
                column: "ContractorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "Contractor");

            migrationBuilder.DropTable(
                name: "Payments",
                schema: "Contractor");

            migrationBuilder.DropTable(
                name: "Contractors",
                schema: "Contractor");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "Contractor");
        }
    }
}
