using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Migrations
{
    /// <inheritdoc />
    public partial class ADDIsDeletedToDestination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Destinations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Destinations");
        }
    }
}
