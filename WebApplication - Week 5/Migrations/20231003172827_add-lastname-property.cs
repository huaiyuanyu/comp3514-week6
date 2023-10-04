using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication___Week_5.Migrations
{
    /// <inheritdoc />
    public partial class addlastnameproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "MyRegisteredUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "MyRegisteredUsers");
        }
    }
}
