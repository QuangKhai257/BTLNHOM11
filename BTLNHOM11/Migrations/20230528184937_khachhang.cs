using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNHOM11.Migrations
{
    /// <inheritdoc />
    public partial class khachhang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "khachhang",
                columns: table => new
                {
                    makh = table.Column<string>(type: "TEXT", nullable: false),
                    tenkh = table.Column<string>(type: "TEXT", nullable: false),
                    diachikh = table.Column<string>(type: "TEXT", nullable: false),
                    sdtkh = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khachhang", x => x.makh);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "khachhang");
        }
    }
}
