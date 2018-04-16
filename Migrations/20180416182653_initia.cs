using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sheep.SiteV2.Api.Migrations
{
    public partial class initia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "vAnimalId",
                table: "Vaccines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tAnimalId",
                table: "Treatments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pAnimalId",
                table: "Pregnancies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "vAnimalId",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "tAnimalId",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "pAnimalId",
                table: "Pregnancies");
        }
    }
}
