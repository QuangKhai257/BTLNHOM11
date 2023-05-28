using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNHOM11.Migrations
{
    /// <inheritdoc />
    public partial class nhaphang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nhaphang",
                columns: table => new
                {
                    idnh = table.Column<string>(type: "TEXT", nullable: false),
                    tensp = table.Column<string>(type: "TEXT", nullable: false),
                    tenncc = table.Column<string>(type: "TEXT", nullable: false),
                    soluongnh = table.Column<string>(type: "TEXT", nullable: false),
                    ngaynh = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhaphang", x => x.idnh);
                    table.ForeignKey(
                        name: "FK_nhaphang_nhacungcap_tenncc",
                        column: x => x.tenncc,
                        principalTable: "nhacungcap",
                        principalColumn: "mancc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nhaphang_sanpham_tensp",
                        column: x => x.tensp,
                        principalTable: "sanpham",
                        principalColumn: "masp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nhaphang_tenncc",
                table: "nhaphang",
                column: "tenncc");

            migrationBuilder.CreateIndex(
                name: "IX_nhaphang_tensp",
                table: "nhaphang",
                column: "tensp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nhaphang");
        }
    }
}
