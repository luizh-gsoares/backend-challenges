using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VUTTR.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Tools_ToolId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ToolId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ToolId",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "TagTool",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "int", nullable: false),
                    ToolsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagTool", x => new { x.TagsId, x.ToolsId });
                    table.ForeignKey(
                        name: "FK_TagTool_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagTool_Tools_ToolsId",
                        column: x => x.ToolsId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToolTags",
                columns: table => new
                {
                    ToolId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolTags", x => new { x.ToolId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ToolTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToolTags_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagTool_ToolsId",
                table: "TagTool",
                column: "ToolsId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolTags_TagId",
                table: "ToolTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagTool");

            migrationBuilder.DropTable(
                name: "ToolTags");

            migrationBuilder.AddColumn<int>(
                name: "ToolId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ToolId",
                table: "Tags",
                column: "ToolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Tools_ToolId",
                table: "Tags",
                column: "ToolId",
                principalTable: "Tools",
                principalColumn: "Id");
        }
    }
}
