using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MNS.Iot.Backend.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mesure_AppSondes_SondeId",
                table: "Mesure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mesure",
                table: "Mesure");

            migrationBuilder.RenameTable(
                name: "Mesure",
                newName: "AppMesures");

            migrationBuilder.RenameIndex(
                name: "IX_Mesure_SondeId",
                table: "AppMesures",
                newName: "IX_AppMesures_SondeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppMesures",
                table: "AppMesures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppMesures_AppSondes_SondeId",
                table: "AppMesures",
                column: "SondeId",
                principalTable: "AppSondes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppMesures_AppSondes_SondeId",
                table: "AppMesures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppMesures",
                table: "AppMesures");

            migrationBuilder.RenameTable(
                name: "AppMesures",
                newName: "Mesure");

            migrationBuilder.RenameIndex(
                name: "IX_AppMesures_SondeId",
                table: "Mesure",
                newName: "IX_Mesure_SondeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mesure",
                table: "Mesure",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mesure_AppSondes_SondeId",
                table: "Mesure",
                column: "SondeId",
                principalTable: "AppSondes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
