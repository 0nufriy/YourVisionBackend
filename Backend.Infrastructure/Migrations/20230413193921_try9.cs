using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class try9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audience",
                columns: table => new
                {
                    AudienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audience", x => x.AudienceId);
                });

            migrationBuilder.CreateTable(
                name: "AudiencePack",
                columns: table => new
                {
                    AudiencePackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudiencePackName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudiencePack", x => x.AudiencePackId);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ProfileId);
                });

            migrationBuilder.CreateTable(
                name: "AAP",
                columns: table => new
                {
                    AudienceId = table.Column<int>(type: "int", nullable: false),
                    AudiencePackId = table.Column<int>(type: "int", nullable: false),
                    AudienceCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AAP", x => new { x.AudiencePackId, x.AudienceId });
                    table.ForeignKey(
                        name: "FK_AAP_AudiencePack_AudiencePackId",
                        column: x => x.AudiencePackId,
                        principalTable: "AudiencePack",
                        principalColumn: "AudiencePackId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AAP_Audience_AudienceId",
                        column: x => x.AudienceId,
                        principalTable: "Audience",
                        principalColumn: "AudienceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datetime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationMinute = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_Session_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AudienceSession",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    AudiencePackId = table.Column<int>(type: "int", nullable: false),
                    AudiencePackCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudienceSession", x => new { x.AudiencePackId, x.SessionId });
                    table.ForeignKey(
                        name: "FK_AudienceSession_AudiencePack_AudiencePackId",
                        column: x => x.AudiencePackId,
                        principalTable: "AudiencePack",
                        principalColumn: "AudiencePackId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AudienceSession_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmotionalExpect",
                columns: table => new
                {
                    EmotionalExpectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    Emotional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    End = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmotionalExpect", x => x.EmotionalExpectId);
                    table.ForeignKey(
                        name: "FK_EmotionalExpect_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmotionalResult",
                columns: table => new
                {
                    EmotionalResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    Emotional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    End = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmotionalResult", x => x.EmotionalResultId);
                    table.ForeignKey(
                        name: "FK_EmotionalResult_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Report_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AAP_AudienceId",
                table: "AAP",
                column: "AudienceId");

            migrationBuilder.CreateIndex(
                name: "IX_AudienceSession_SessionId",
                table: "AudienceSession",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmotionalExpect_SessionId",
                table: "EmotionalExpect",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmotionalResult_SessionId",
                table: "EmotionalResult",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_SessionId",
                table: "Report",
                column: "SessionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Session_ProfileId",
                table: "Session",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AAP");

            migrationBuilder.DropTable(
                name: "AudienceSession");

            migrationBuilder.DropTable(
                name: "EmotionalExpect");

            migrationBuilder.DropTable(
                name: "EmotionalResult");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Audience");

            migrationBuilder.DropTable(
                name: "AudiencePack");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Profile");
        }
    }
}
