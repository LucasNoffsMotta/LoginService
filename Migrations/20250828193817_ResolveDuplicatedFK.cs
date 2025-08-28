using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginService.Migrations
{
    /// <inheritdoc />
    public partial class ResolveDuplicatedFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Adress_AdressId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AdressId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "AdressId1",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_AdressId1",
                table: "User",
                column: "AdressId1");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Adress_AdressId1",
                table: "User",
                column: "AdressId1",
                principalTable: "Adress",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Adress_AdressId1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AdressId1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AdressId1",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_User_AdressId",
                table: "User",
                column: "AdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Adress_AdressId",
                table: "User",
                column: "AdressId",
                principalTable: "Adress",
                principalColumn: "Id");
        }
    }
}
