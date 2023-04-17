using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class try15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Profile",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Profile",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Profile",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_Email",
                table: "Profile",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profile_Login",
                table: "Profile",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profile_PhoneNumber",
                table: "Profile",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profile_Email",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Profile_Login",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Profile_PhoneNumber",
                table: "Profile");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");
        }
    }
}
