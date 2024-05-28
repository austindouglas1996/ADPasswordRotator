using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADPasswordRotator.Backend.Migrations
{
    /// <inheritdoc />
    public partial class notification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceAccounts_Locations_LocationId",
                table: "ServiceAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceAccounts_Locations_LocationId1",
                table: "ServiceAccounts");

            migrationBuilder.DropTable(
                name: "CheckinEntry");

            migrationBuilder.DropIndex(
                name: "IX_ServiceAccounts_LocationId1",
                table: "ServiceAccounts");

            migrationBuilder.DropColumn(
                name: "CheckinIntervalType",
                table: "ServiceAccounts");

            migrationBuilder.DropColumn(
                name: "CheckinIntervalValue",
                table: "ServiceAccounts");

            migrationBuilder.DropColumn(
                name: "LastCheckinTime",
                table: "ServiceAccounts");

            migrationBuilder.DropColumn(
                name: "LocationId1",
                table: "ServiceAccounts");

            migrationBuilder.DropColumn(
                name: "CheckinIntervalType",
                table: "DomainControllers");

            migrationBuilder.DropColumn(
                name: "LastCheckinTime",
                table: "DomainControllers");

            migrationBuilder.DropColumn(
                name: "Verified",
                table: "DomainControllers");

            migrationBuilder.RenameColumn(
                name: "CheckinIntervalValue",
                table: "DomainControllers",
                newName: "Status");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    DomainControllerId = table.Column<int>(type: "int", nullable: true),
                    ServiceAccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_DomainControllers_DomainControllerId",
                        column: x => x.DomainControllerId,
                        principalTable: "DomainControllers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_ServiceAccounts_ServiceAccountId",
                        column: x => x.ServiceAccountId,
                        principalTable: "ServiceAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_DomainControllerId",
                table: "Notifications",
                column: "DomainControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_LocationId",
                table: "Notifications",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ServiceAccountId",
                table: "Notifications",
                column: "ServiceAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceAccounts_Locations_LocationId",
                table: "ServiceAccounts",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceAccounts_Locations_LocationId",
                table: "ServiceAccounts");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "DomainControllers",
                newName: "CheckinIntervalValue");

            migrationBuilder.AddColumn<int>(
                name: "CheckinIntervalType",
                table: "ServiceAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CheckinIntervalValue",
                table: "ServiceAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastCheckinTime",
                table: "ServiceAccounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LocationId1",
                table: "ServiceAccounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CheckinIntervalType",
                table: "DomainControllers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastCheckinTime",
                table: "DomainControllers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "DomainControllers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CheckinEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomainControllerId = table.Column<int>(type: "int", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceAccountId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "IX_ServiceAccounts_LocationId1",
                table: "ServiceAccounts",
                column: "LocationId1");

            migrationBuilder.CreateIndex(
                name: "IX_CheckinEntry_DomainControllerId",
                table: "CheckinEntry",
                column: "DomainControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckinEntry_ServiceAccountId",
                table: "CheckinEntry",
                column: "ServiceAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceAccounts_Locations_LocationId",
                table: "ServiceAccounts",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceAccounts_Locations_LocationId1",
                table: "ServiceAccounts",
                column: "LocationId1",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
