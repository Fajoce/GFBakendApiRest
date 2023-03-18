using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.GF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "GF");

            migrationBuilder.CreateTable(
                name: "BranchOffices",
                schema: "GF",
                columns: table => new
                {
                    BranchOfficeCode = table.Column<string>(nullable: false),
                    BranchOfficeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchOfficeName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOffices", x => x.BranchOfficeCode);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "GF",
                columns: table => new
                {
                    ItemCode = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemCode);
                });

            migrationBuilder.CreateTable(
                name: "Technicals",
                schema: "GF",
                columns: table => new
                {
                    TechnicalCode = table.Column<string>(nullable: false),
                    TechnicalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnicalFullName = table.Column<string>(maxLength: 30, nullable: false),
                    TechnicalSalary = table.Column<double>(nullable: false),
                    BranchOfficeCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicals", x => x.TechnicalCode);
                    table.ForeignKey(
                        name: "FK_Technicals_BranchOffices_BranchOfficeCode",
                        column: x => x.BranchOfficeCode,
                        principalSchema: "GF",
                        principalTable: "BranchOffices",
                        principalColumn: "BranchOfficeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Remissions",
                schema: "GF",
                columns: table => new
                {
                    RemissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RemissionDate = table.Column<DateTime>(nullable: false),
                    TechnicalCode = table.Column<string>(nullable: true),
                    ItemCode = table.Column<string>(nullable: true),
                    RemissionQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remissions", x => x.RemissionId);
                    table.ForeignKey(
                        name: "FK_Remissions_Items_ItemCode",
                        column: x => x.ItemCode,
                        principalSchema: "GF",
                        principalTable: "Items",
                        principalColumn: "ItemCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Remissions_Technicals_TechnicalCode",
                        column: x => x.TechnicalCode,
                        principalSchema: "GF",
                        principalTable: "Technicals",
                        principalColumn: "TechnicalCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Remissions_ItemCode",
                schema: "GF",
                table: "Remissions",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_Remissions_TechnicalCode",
                schema: "GF",
                table: "Remissions",
                column: "TechnicalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Technicals_BranchOfficeCode",
                schema: "GF",
                table: "Technicals",
                column: "BranchOfficeCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Remissions",
                schema: "GF");

            migrationBuilder.DropTable(
                name: "Items",
                schema: "GF");

            migrationBuilder.DropTable(
                name: "Technicals",
                schema: "GF");

            migrationBuilder.DropTable(
                name: "BranchOffices",
                schema: "GF");
        }
    }
}
