using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialsHub.Data.Migrations
{
    public partial class Update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Twittter",
                table: "Icons",
                newName: "Twitter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Twitter",
                table: "Icons",
                newName: "Twittter");
        }
    }
}
