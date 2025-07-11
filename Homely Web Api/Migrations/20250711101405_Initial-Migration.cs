using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homely_Web_Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AppUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            //        LastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AppUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Categories",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Categories", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Locations",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        City = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        State = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Locations", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Roles",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Roles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RefreshTokens",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        AppUserId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RefreshTokens", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_RefreshTokens_AppUsers_AppUserId",
            //            column: x => x.AppUserId,
            //            principalTable: "AppUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ResidentialUnits",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Price = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
            //        Capacity = table.Column<int>(type: "int", nullable: false),
            //        BedroomsNum = table.Column<int>(type: "int", nullable: false),
            //        BathroomsNum = table.Column<int>(type: "int", nullable: false),
            //        BedsNum = table.Column<int>(type: "int", nullable: false),
            //        LocationId = table.Column<int>(type: "int", nullable: false),
            //        CategoryId = table.Column<int>(type: "int", nullable: false),
            //        HostId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ResidentialUnits", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ResidentialUnits_AppUsers_HostId",
            //            column: x => x.HostId,
            //            principalTable: "AppUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ResidentialUnits_Categories_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ResidentialUnits_Locations_LocationId",
            //            column: x => x.LocationId,
            //            principalTable: "Locations",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AppUserRoles",
            //    columns: table => new
            //    {
            //        AppUserId = table.Column<int>(type: "int", nullable: false),
            //        RoleId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AppUserRoles", x => new { x.AppUserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AppUserRoles_AppUsers_AppUserId",
            //            column: x => x.AppUserId,
            //            principalTable: "AppUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AppUserRoles_Roles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "Roles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Reservations",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        UnitId = table.Column<int>(type: "int", nullable: false),
            //        CheckIn = table.Column<DateOnly>(type: "date", nullable: false),
            //        CheckOut = table.Column<DateOnly>(type: "date", nullable: false),
            //        CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Pending"),
            //        TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        GuestsNum = table.Column<int>(type: "int", nullable: false),
            //        IdentificationNumber = table.Column<double>(type: "float", nullable: false),
            //        Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Reservations", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Reservations_AppUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AppUsers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Reservations_ResidentialUnits_UnitId",
            //            column: x => x.UnitId,
            //            principalTable: "ResidentialUnits",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "WishList",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        UnitId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_WishList", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_WishList_AppUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AppUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_WishList_ResidentialUnits_UnitId",
            //            column: x => x.UnitId,
            //            principalTable: "ResidentialUnits",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AppUserRoles_RoleId",
            //    table: "AppUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AppUsers_Email",
            //    table: "AppUsers",
            //    column: "Email",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_RefreshTokens_AppUserId",
            //    table: "RefreshTokens",
            //    column: "AppUserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Reservations_UnitId",
            //    table: "Reservations",
            //    column: "UnitId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Reservations_UserId",
            //    table: "Reservations",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ResidentialUnits_CategoryId",
            //    table: "ResidentialUnits",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ResidentialUnits_HostId",
            //    table: "ResidentialUnits",
            //    column: "HostId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ResidentialUnits_LocationId",
            //    table: "ResidentialUnits",
            //    column: "LocationId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_WishList_UnitId",
            //    table: "WishList",
            //    column: "UnitId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_WishList_UserId",
            //    table: "WishList",
            //    column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AppUserRoles");

            //migrationBuilder.DropTable(
            //    name: "RefreshTokens");

            //migrationBuilder.DropTable(
            //    name: "Reservations");

            //migrationBuilder.DropTable(
            //    name: "WishList");

            //migrationBuilder.DropTable(
            //    name: "Roles");

            //migrationBuilder.DropTable(
            //    name: "ResidentialUnits");

            //migrationBuilder.DropTable(
            //    name: "AppUsers");

            //migrationBuilder.DropTable(
            //    name: "Categories");

            //migrationBuilder.DropTable(
            //    name: "Locations");
        }
    }
}
