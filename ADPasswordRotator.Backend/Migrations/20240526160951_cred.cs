using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADPasswordRotator.Backend.Migrations
{
    /// <inheritdoc />
    public partial class cred : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "DomainControllers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "DomainControllers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "DomainControllers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "DomainControllers");
        }
    }
}
