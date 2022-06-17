using Microsoft.EntityFrameworkCore.Migrations;

namespace SortNumbers.Migrations
{
    public partial class initalsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SortInput",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numbers = table.Column<string>(nullable: true),
                    OrderedNumbers = table.Column<string>(nullable: true),
                    OrderAscending = table.Column<string>(nullable: true),
                    TimeToOrder = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SortInput", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SortInput");
        }
    }
}
