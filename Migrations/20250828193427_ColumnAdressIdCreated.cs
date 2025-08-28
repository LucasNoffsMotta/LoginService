using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginService.Migrations
{
    /// <inheritdoc />
    public partial class ColumnAdressIdCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adress_User_UserID",
                table: "Adress");

            migrationBuilder.DropIndex(
                name: "IX_Adress_UserID",
                table: "Adress");

            migrationBuilder.AddColumn<int>(
                name: "AdressId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "AdressId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AdressId1",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_Adress_UserID",
                table: "Adress",
                column: "UserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adress_User_UserID",
                table: "Adress",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
