using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialsHub.Data.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Icons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Icons_AspNetUsers_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Icons",
                columns: new[] { "Id", "Link", "Name", "ProfileId", "UserId" },
                values: new object[,]
                {
                    { 1, null, "Facebook", null, null },
                    { 2, null, "Instagram", null, null },
                    { 3, null, "Twitter", null, null },
                    { 4, null, "YouTube", null, null },
                    { 5, null, "GitHub", null, null },
                    { 6, null, "Linkedin", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Icons_ProfileId",
                table: "Icons",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Icons");
        }
    }
}
