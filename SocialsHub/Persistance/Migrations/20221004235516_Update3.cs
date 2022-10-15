using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialsHub.Data.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icons_AspNetUsers_ProfileId",
                table: "Icons");

            migrationBuilder.DropForeignKey(
                name: "FK_References_AspNetUsers_ProfileId",
                table: "References");

            migrationBuilder.DropIndex(
                name: "IX_References_ProfileId",
                table: "References");

            migrationBuilder.DropIndex(
                name: "IX_Icons_ProfileId",
                table: "Icons");

            migrationBuilder.DeleteData(
                table: "Icons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Icons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Icons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Icons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Icons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Icons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "References");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Icons");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Icons",
                newName: "YouTube");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Icons",
                newName: "Twittter");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "References",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Icons",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Icons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GitHub",
                table: "Icons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Icons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Linkedin",
                table: "Icons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_References_UserId",
                table: "References",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Icons_UserId",
                table: "Icons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Icons_AspNetUsers_UserId",
                table: "Icons",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_References_AspNetUsers_UserId",
                table: "References",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icons_AspNetUsers_UserId",
                table: "Icons");

            migrationBuilder.DropForeignKey(
                name: "FK_References_AspNetUsers_UserId",
                table: "References");

            migrationBuilder.DropIndex(
                name: "IX_References_UserId",
                table: "References");

            migrationBuilder.DropIndex(
                name: "IX_Icons_UserId",
                table: "Icons");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Icons");

            migrationBuilder.DropColumn(
                name: "GitHub",
                table: "Icons");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Icons");

            migrationBuilder.DropColumn(
                name: "Linkedin",
                table: "Icons");

            migrationBuilder.RenameColumn(
                name: "YouTube",
                table: "Icons",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Twittter",
                table: "Icons",
                newName: "Link");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "References",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileId",
                table: "References",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Icons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileId",
                table: "Icons",
                type: "nvarchar(450)",
                nullable: true);

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
                name: "IX_References_ProfileId",
                table: "References",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Icons_ProfileId",
                table: "Icons",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Icons_AspNetUsers_ProfileId",
                table: "Icons",
                column: "ProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_References_AspNetUsers_ProfileId",
                table: "References",
                column: "ProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
