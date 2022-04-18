using Microsoft.EntityFrameworkCore.Migrations;

namespace Arvato.DBAdapter.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerSupport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Number = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Inquiry = table.Column<int>(type: "INT", nullable: false),
                    DescriptionSupport = table.Column<string>(type: "NVARCHAR(4000)", maxLength: 4000, nullable: false),
                    Aggreement = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSupport", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerSupport");
        }
    }
}
