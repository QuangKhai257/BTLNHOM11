using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNHOM11.Migrations
{
    /// <inheritdoc />
    public partial class chucvu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chucvu",
                columns: table => new
                {
                    idcv = table.Column<string>(type: "TEXT", nullable: false),
                    tencv = table.Column<string>(type: "TEXT", nullable: false),
                    motacv = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chucvu", x => x.idcv);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chucvu");
        }
    }
}
