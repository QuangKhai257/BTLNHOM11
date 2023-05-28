using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNHOM11.Migrations
{
    /// <inheritdoc />
    public partial class sanpham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sanpham",
                columns: table => new
                {
                    masp = table.Column<string>(type: "TEXT", nullable: false),
                    tensp = table.Column<string>(type: "TEXT", nullable: false),
                    gia = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanpham", x => x.masp);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sanpham");
        }
    }
}
