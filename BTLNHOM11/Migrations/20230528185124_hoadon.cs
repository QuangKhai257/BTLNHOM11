using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNHOM11.Migrations
{
    /// <inheritdoc />
    public partial class hoadon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hoadon",
                columns: table => new
                {
                    mahd = table.Column<string>(type: "TEXT", nullable: false),
                    tenkh = table.Column<string>(type: "TEXT", nullable: false),
                    tensp = table.Column<string>(type: "TEXT", nullable: false),
                    soluongban = table.Column<string>(type: "TEXT", nullable: false),
                    tgban = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoadon", x => x.mahd);
                    table.ForeignKey(
                        name: "FK_hoadon_khachhang_tenkh",
                        column: x => x.tenkh,
                        principalTable: "khachhang",
                        principalColumn: "makh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hoadon_sanpham_tensp",
                        column: x => x.tensp,
                        principalTable: "sanpham",
                        principalColumn: "masp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hoadon_tenkh",
                table: "hoadon",
                column: "tenkh");

            migrationBuilder.CreateIndex(
                name: "IX_hoadon_tensp",
                table: "hoadon",
                column: "tensp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hoadon");
        }
    }
}
