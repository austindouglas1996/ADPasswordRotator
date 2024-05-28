using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADPasswordRotator.Backend.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingsOptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Internal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingsOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DomainControllers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    Verified = table.Column<bool>(type: "bit", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    CheckinIntervalType = table.Column<int>(type: "int", nullable: false),
                    CheckinIntervalValue = table.Column<int>(type: "int", nullable: false),
                    LastCheckinTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainControllers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DomainControllers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    CheckinIntervalType = table.Column<int>(type: "int", nullable: false),
                    CheckinIntervalValue = table.Column<int>(type: "int", nullable: false),
                    PasswordResetIntervalType = table.Column<int>(type: "int", nullable: false),
                    PasswordResetIntervalValue = table.Column<int>(type: "int", nullable: false),
                    LastCheckinTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastPasswordReset = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceAccounts_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceAccounts_Locations_LocationId1",
                        column: x => x.LocationId1,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CheckinEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DomainControllerId = table.Column<int>(type: "int", nullable: true),
                    ServiceAccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckinEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckinEntry_DomainControllers_DomainControllerId",
                        column: x => x.DomainControllerId,
                        principalTable: "DomainControllers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CheckinEntry_ServiceAccounts_ServiceAccountId",
                        column: x => x.ServiceAccountId,
                        principalTable: "ServiceAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckinEntry_DomainControllerId",
                table: "CheckinEntry",
                column: "DomainControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckinEntry_ServiceAccountId",
                table: "CheckinEntry",
                column: "ServiceAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainControllers_LocationId",
                table: "DomainControllers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAccounts_LocationId",
                table: "ServiceAccounts",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAccounts_LocationId1",
                table: "ServiceAccounts",
                column: "LocationId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckinEntry");

            migrationBuilder.DropTable(
                name: "SettingsOptions");

            migrationBuilder.DropTable(
                name: "DomainControllers");

            migrationBuilder.DropTable(
                name: "ServiceAccounts");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
