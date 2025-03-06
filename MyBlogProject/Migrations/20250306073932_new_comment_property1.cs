using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogProject.Migrations
{
    /// <inheritdoc />
    public partial class new_comment_property1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Comments",
                newName: "Text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Comments",
                newName: "Description");
        }
    }
}
