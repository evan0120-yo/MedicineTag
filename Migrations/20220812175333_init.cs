using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineTag.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicineClass",
                columns: table => new
                {
                    MedicineClassId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MedicineClassName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedicineClassTpye = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicineClass", x => x.MedicineClassId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicineInfos",
                columns: table => new
                {
                    MedicineInfoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MedicineInfoName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicineInfos", x => x.MedicineInfoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicineInfoClass",
                columns: table => new
                {
                    MedicineInfoClassId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MedicineInfoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MedicineClassId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicineInfoClass", x => x.MedicineInfoClassId);
                    table.ForeignKey(
                        name: "FK_medicineInfoClass_medicineClass_MedicineClassId",
                        column: x => x.MedicineClassId,
                        principalTable: "medicineClass",
                        principalColumn: "MedicineClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicineInfoClass_medicineInfos_MedicineInfoId",
                        column: x => x.MedicineInfoId,
                        principalTable: "medicineInfos",
                        principalColumn: "MedicineInfoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_medicineInfoClass_MedicineClassId",
                table: "medicineInfoClass",
                column: "MedicineClassId");

            migrationBuilder.CreateIndex(
                name: "IX_medicineInfoClass_MedicineInfoId",
                table: "medicineInfoClass",
                column: "MedicineInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicineInfoClass");

            migrationBuilder.DropTable(
                name: "medicineClass");

            migrationBuilder.DropTable(
                name: "medicineInfos");
        }
    }
}
