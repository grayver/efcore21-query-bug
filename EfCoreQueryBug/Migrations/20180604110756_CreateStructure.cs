using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EfCoreQueryBug.Migrations
{
    public partial class CreateStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    StartTime = table.Column<decimal>(nullable: false),
                    Duration = table.Column<decimal>(nullable: false),
                    Difficulty = table.Column<decimal>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestTasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    QuestId = table.Column<int>(nullable: false),
                    StartTime = table.Column<decimal>(nullable: false),
                    Duration = table.Column<decimal>(nullable: false),
                    Reward = table.Column<decimal>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(maxLength: 256, nullable: true),
                    CenterX = table.Column<decimal>(nullable: true),
                    CenterY = table.Column<decimal>(nullable: true),
                    Radius = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestTasks_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestTaskChoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    QuestTaskId = table.Column<int>(nullable: false),
                    Index = table.Column<int>(nullable: true),
                    IsCorrect = table.Column<bool>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    ImageMime = table.Column<string>(nullable: true),
                    ImageFilename = table.Column<string>(nullable: true),
                    CenterX = table.Column<decimal>(nullable: true),
                    CenterY = table.Column<decimal>(nullable: true),
                    Radius = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestTaskChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestTaskChoices_QuestTasks_QuestTaskId",
                        column: x => x.QuestTaskId,
                        principalTable: "QuestTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestTimelinePoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    QuestTaskId = table.Column<int>(nullable: false),
                    Position = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestTimelinePoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestTimelinePoints_QuestTasks_QuestTaskId",
                        column: x => x.QuestTaskId,
                        principalTable: "QuestTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestTaskChoices_QuestTaskId",
                table: "QuestTaskChoices",
                column: "QuestTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestTasks_QuestId",
                table: "QuestTasks",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestTimelinePoints_QuestTaskId",
                table: "QuestTimelinePoints",
                column: "QuestTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestTaskChoices");

            migrationBuilder.DropTable(
                name: "QuestTimelinePoints");

            migrationBuilder.DropTable(
                name: "QuestTasks");

            migrationBuilder.DropTable(
                name: "Quests");
        }
    }
}
