using Microsoft.EntityFrameworkCore.Migrations;

namespace VugleBE.Migrations
{
    public partial class AddedSuggestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuggestionKeywords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Keyword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuggestionKeywords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Responses = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suggestions_Suggestions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Suggestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KeywordSuggestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KeywordId = table.Column<int>(nullable: false),
                    SuggestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordSuggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeywordSuggestions_SuggestionKeywords_KeywordId",
                        column: x => x.KeywordId,
                        principalTable: "SuggestionKeywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeywordSuggestions_Suggestions_SuggestionId",
                        column: x => x.SuggestionId,
                        principalTable: "Suggestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeywordSuggestions_KeywordId",
                table: "KeywordSuggestions",
                column: "KeywordId");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordSuggestions_SuggestionId",
                table: "KeywordSuggestions",
                column: "SuggestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_ParentId",
                table: "Suggestions",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeywordSuggestions");

            migrationBuilder.DropTable(
                name: "SuggestionKeywords");

            migrationBuilder.DropTable(
                name: "Suggestions");
        }
    }
}
