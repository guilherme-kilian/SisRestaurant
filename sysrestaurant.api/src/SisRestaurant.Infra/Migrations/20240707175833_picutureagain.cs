using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisRestaurant.Infra.Migrations
{
    /// <inheritdoc />
    public partial class picutureagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Restaurants");
        }
    }
}
