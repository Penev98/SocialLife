using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialLife.Data.Migrations
{
    public partial class AddExtensionAttributeToAttachmentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "Attachments");
        }
    }
}
