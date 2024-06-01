﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisRestaurant.Infra.Migrations;

/// <inheritdoc />
public partial class AddedUserToRestaurant : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "UserId",
            table: "Restaurants",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.CreateIndex(
            name: "IX_Restaurants_UserId",
            table: "Restaurants",
            column: "UserId");

        migrationBuilder.AddForeignKey(
            name: "FK_Restaurants_Users_UserId",
            table: "Restaurants",
            column: "UserId",
            principalTable: "Users",
            principalColumn: "Id",
            onDelete: ReferentialAction.SetDefault);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Restaurants_Users_UserId",
            table: "Restaurants");

        migrationBuilder.DropIndex(
            name: "IX_Restaurants_UserId",
            table: "Restaurants");

        migrationBuilder.DropColumn(
            name: "UserId",
            table: "Restaurants");
    }
}
