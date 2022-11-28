using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tryiiter.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserIdColumnNameInPostsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("UserId", "Posts", "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("user_id", "Posts", "UserId");
        }
    }
}
