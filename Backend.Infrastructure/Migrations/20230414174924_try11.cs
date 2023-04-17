using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class try11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AudienceId",
                table: "EmotionalResult",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AudienceId",
                table: "EmotionalExpect",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmotionalResult_AudienceId",
                table: "EmotionalResult",
                column: "AudienceId");

            migrationBuilder.CreateIndex(
                name: "IX_EmotionalExpect_AudienceId",
                table: "EmotionalExpect",
                column: "AudienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmotionalExpect_Audience_AudienceId",
                table: "EmotionalExpect",
                column: "AudienceId",
                principalTable: "Audience",
                principalColumn: "AudienceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmotionalResult_Audience_AudienceId",
                table: "EmotionalResult",
                column: "AudienceId",
                principalTable: "Audience",
                principalColumn: "AudienceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmotionalExpect_Audience_AudienceId",
                table: "EmotionalExpect");

            migrationBuilder.DropForeignKey(
                name: "FK_EmotionalResult_Audience_AudienceId",
                table: "EmotionalResult");

            migrationBuilder.DropIndex(
                name: "IX_EmotionalResult_AudienceId",
                table: "EmotionalResult");

            migrationBuilder.DropIndex(
                name: "IX_EmotionalExpect_AudienceId",
                table: "EmotionalExpect");

            migrationBuilder.DropColumn(
                name: "AudienceId",
                table: "EmotionalResult");

            migrationBuilder.DropColumn(
                name: "AudienceId",
                table: "EmotionalExpect");
        }
    }
}
