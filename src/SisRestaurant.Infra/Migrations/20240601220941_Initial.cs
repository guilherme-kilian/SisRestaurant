using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisRestaurant.Infra.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Categories",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                Deleted = table.Column<bool>(type: "bit", nullable: false),
                DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Categories", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Menus",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                Deleted = table.Column<bool>(type: "bit", nullable: false),
                DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Menus", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Notifications",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                SendAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                Success = table.Column<bool>(type: "bit", nullable: false),
                Finished = table.Column<bool>(type: "bit", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Notifications", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Payments",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Status = table.Column<int>(type: "int", nullable: false),
                Value = table.Column<double>(type: "float", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                Deleted = table.Column<bool>(type: "bit", nullable: false),
                DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Payments", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ReservationSettings",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                PaymentRequired = table.Column<bool>(type: "bit", nullable: false),
                StartAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                FinishAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                Capacity = table.Column<int>(type: "int", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ReservationSettings", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                Deleted = table.Column<bool>(type: "bit", nullable: false),
                DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "MenuItems",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Price = table.Column<double>(type: "float", nullable: false),
                CategoryId = table.Column<int>(type: "int", nullable: false),
                MenuId = table.Column<int>(type: "int", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                Deleted = table.Column<bool>(type: "bit", nullable: false),
                DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MenuItems", x => x.Id);
                table.ForeignKey(
                    name: "FK_MenuItems_Categories_CategoryId",
                    column: x => x.CategoryId,
                    principalTable: "Categories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_MenuItems_Menus_MenuId",
                    column: x => x.MenuId,
                    principalTable: "Menus",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "Restaurants",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                MenuId = table.Column<int>(type: "int", nullable: false),
                SettingsId = table.Column<int>(type: "int", nullable: false),
                Open = table.Column<bool>(type: "bit", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                Deleted = table.Column<bool>(type: "bit", nullable: false),
                DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Restaurants", x => x.Id);
                table.ForeignKey(
                    name: "FK_Restaurants_Menus_MenuId",
                    column: x => x.MenuId,
                    principalTable: "Menus",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Restaurants_ReservationSettings_SettingsId",
                    column: x => x.SettingsId,
                    principalTable: "ReservationSettings",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Reservations",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CustomerId = table.Column<int>(type: "int", nullable: false),
                RestaurantId = table.Column<int>(type: "int", nullable: false),
                PaymentId = table.Column<int>(type: "int", nullable: true),
                ReservedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                Deleted = table.Column<bool>(type: "bit", nullable: false),
                DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Reservations", x => x.Id);
                table.ForeignKey(
                    name: "FK_Reservations_Payments_PaymentId",
                    column: x => x.PaymentId,
                    principalTable: "Payments",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Reservations_Restaurants_RestaurantId",
                    column: x => x.RestaurantId,
                    principalTable: "Restaurants",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Reservations_Users_CustomerId",
                    column: x => x.CustomerId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_MenuItems_CategoryId",
            table: "MenuItems",
            column: "CategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_MenuItems_MenuId",
            table: "MenuItems",
            column: "MenuId");

        migrationBuilder.CreateIndex(
            name: "IX_Reservations_CustomerId",
            table: "Reservations",
            column: "CustomerId");

        migrationBuilder.CreateIndex(
            name: "IX_Reservations_PaymentId",
            table: "Reservations",
            column: "PaymentId");

        migrationBuilder.CreateIndex(
            name: "IX_Reservations_RestaurantId",
            table: "Reservations",
            column: "RestaurantId");

        migrationBuilder.CreateIndex(
            name: "IX_Restaurants_MenuId",
            table: "Restaurants",
            column: "MenuId");

        migrationBuilder.CreateIndex(
            name: "IX_Restaurants_SettingsId",
            table: "Restaurants",
            column: "SettingsId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "MenuItems");

        migrationBuilder.DropTable(
            name: "Notifications");

        migrationBuilder.DropTable(
            name: "Reservations");

        migrationBuilder.DropTable(
            name: "Categories");

        migrationBuilder.DropTable(
            name: "Payments");

        migrationBuilder.DropTable(
            name: "Restaurants");

        migrationBuilder.DropTable(
            name: "Users");

        migrationBuilder.DropTable(
            name: "Menus");

        migrationBuilder.DropTable(
            name: "ReservationSettings");
    }
}
