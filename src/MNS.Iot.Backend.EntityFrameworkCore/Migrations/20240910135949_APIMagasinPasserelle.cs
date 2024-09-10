using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MNS.Iot.Backend.Migrations
{
    /// <inheritdoc />
    public partial class APIMagasinPasserelle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdPhysique",
                table: "AppPasserelles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AppPasserelles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AppMagasins",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPhysique",
                table: "AppPasserelles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AppPasserelles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AppMagasins");
        }
    }
}
