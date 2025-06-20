using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Migrations
{
    /// <inheritdoc />
    public partial class ADDIsDeletedToTourPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TourPackages",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TourPackages");
        }
    }
}
