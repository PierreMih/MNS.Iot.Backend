using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MNS.Iot.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AggregateRootEverywhere : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppMachines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMachines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppMagasins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMagasins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppPasserelles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPasserelles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSondes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPhysique = table.Column<string>(type: "text", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSondes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppMachineSondeJoinEntities",
                columns: table => new
                {
                    SondeId = table.Column<Guid>(type: "uuid", nullable: false),
                    MachineId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMachineSondeJoinEntities", x => x.SondeId);
                    table.ForeignKey(
                        name: "FK_AppMachineSondeJoinEntities_AppMachines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "AppMachines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppMagasinPasserelleJoinEntities",
                columns: table => new
                {
                    PasserelleId = table.Column<Guid>(type: "uuid", nullable: false),
                    MagasinId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMagasinPasserelleJoinEntities", x => x.PasserelleId);
                    table.ForeignKey(
                        name: "FK_AppMagasinPasserelleJoinEntities_AppMagasins_MagasinId",
                        column: x => x.MagasinId,
                        principalTable: "AppMagasins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppMachinePasserelleJoinEntities",
                columns: table => new
                {
                    MachineId = table.Column<Guid>(type: "uuid", nullable: false),
                    PasserelleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMachinePasserelleJoinEntities", x => x.MachineId);
                    table.ForeignKey(
                        name: "FK_AppMachinePasserelleJoinEntities_AppPasserelles_PasserelleId",
                        column: x => x.PasserelleId,
                        principalTable: "AppPasserelles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mesure",
                columns: table => new
                {
                    SondeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Temperature = table.Column<double>(type: "double precision", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesure", x => new { x.SondeId, x.Id });
                    table.ForeignKey(
                        name: "FK_Mesure_AppSondes_SondeId",
                        column: x => x.SondeId,
                        principalTable: "AppSondes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppMachinePasserelleJoinEntities_PasserelleId",
                table: "AppMachinePasserelleJoinEntities",
                column: "PasserelleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMachineSondeJoinEntities_MachineId",
                table: "AppMachineSondeJoinEntities",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMagasinPasserelleJoinEntities_MagasinId",
                table: "AppMagasinPasserelleJoinEntities",
                column: "MagasinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppMachinePasserelleJoinEntities");

            migrationBuilder.DropTable(
                name: "AppMachineSondeJoinEntities");

            migrationBuilder.DropTable(
                name: "AppMagasinPasserelleJoinEntities");

            migrationBuilder.DropTable(
                name: "Mesure");

            migrationBuilder.DropTable(
                name: "AppPasserelles");

            migrationBuilder.DropTable(
                name: "AppMachines");

            migrationBuilder.DropTable(
                name: "AppMagasins");

            migrationBuilder.DropTable(
                name: "AppSondes");
        }
    }
}
