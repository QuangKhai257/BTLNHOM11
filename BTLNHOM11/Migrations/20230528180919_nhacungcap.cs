using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNHOM11.Migrations
{
    /// <inheritdoc />
    public partial class nhacungcap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nhacungcap",
                columns: table => new
                {
                    mancc = table.Column<string>(type: "TEXT", nullable: false),
                    tenncc = table.Column<string>(type: "TEXT", nullable: false),
                    diachincc = table.Column<string>(type: "TEXT", nullable: false),
                    sdtncc = table.Column<string>(type: "TEXT", nullable: false),
                    emailncc = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhacungcap", x => x.mancc);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nhacungcap");
        }
    }
}
