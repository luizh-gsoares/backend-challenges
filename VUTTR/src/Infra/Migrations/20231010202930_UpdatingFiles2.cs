using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VUTTR.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingFiles2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToolTags");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_ToolTags_TagId",
                table: "ToolTags",
                column: "TagId");
        }
    }
}
