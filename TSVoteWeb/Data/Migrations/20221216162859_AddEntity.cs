using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSVoteWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.EnsureSchema(
                name: "Gene");

            migrationBuilder.EnsureSchema(
                name: "Vote");

            migrationBuilder.EnsureSchema(
                name: "Admi");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "MyUserTokens",
                newSchema: "Admi");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "MyUserRoles",
                newSchema: "Admi");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "MyUserLogins",
                newSchema: "Admi");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "MyUserClaims",
                newSchema: "Admi");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "MyRoles",
                newSchema: "Admi");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "MyRoleClaims",
                newSchema: "Admi");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "Admi",
                table: "MyUserRoles",
                newName: "IX_MyUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Admi",
                table: "MyUserLogins",
                newName: "IX_MyUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "Admi",
                table: "MyUserClaims",
                newName: "IX_MyUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "Admi",
                table: "MyRoleClaims",
                newName: "IX_MyRoleClaims_RoleId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Admi",
                table: "MyUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "Admi",
                table: "MyUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                schema: "Admi",
                table: "MyUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "Admi",
                table: "MyUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyUserTokens",
                schema: "Admi",
                table: "MyUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyUserRoles",
                schema: "Admi",
                table: "MyUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyUserLogins",
                schema: "Admi",
                table: "MyUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyUserClaims",
                schema: "Admi",
                table: "MyUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyRoles",
                schema: "Admi",
                table: "MyRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyRoleClaims",
                schema: "Admi",
                table: "MyRoleClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Gene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                schema: "Gene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupTypes",
                schema: "Vote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                schema: "Gene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                schema: "Gene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Gene",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "Gene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommuneTownships",
                schema: "Gene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommuneTownships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommuneTownships_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "Gene",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommuneTownships_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalSchema: "Gene",
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Polls",
                schema: "Vote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    MarketStall = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Table = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Polls_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "Gene",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NeighborhoodSidewalks",
                schema: "Gene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommuneTownshipId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeighborhoodSidewalks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NeighborhoodSidewalks_CommuneTownships_CommuneTownshipId",
                        column: x => x.CommuneTownshipId,
                        principalSchema: "Gene",
                        principalTable: "CommuneTownships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MyUser",
                schema: "Admi",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Document = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NeighborhoodSidewalkId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    Referred = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    PollId = table.Column<int>(type: "int", nullable: true),
                    GroupTypeId = table.Column<int>(type: "int", nullable: true),
                    PollingStation = table.Column<int>(type: "int", nullable: false),
                    isVote = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyUser_Genders_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "Gene",
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MyUser_GroupTypes_GroupTypeId",
                        column: x => x.GroupTypeId,
                        principalSchema: "Vote",
                        principalTable: "GroupTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MyUser_NeighborhoodSidewalks_NeighborhoodSidewalkId",
                        column: x => x.NeighborhoodSidewalkId,
                        principalSchema: "Gene",
                        principalTable: "NeighborhoodSidewalks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MyUser_Polls_PollId",
                        column: x => x.PollId,
                        principalSchema: "Vote",
                        principalTable: "Polls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_State_Name",
                schema: "Gene",
                table: "Cities",
                columns: new[] { "StateId", "Name" },
                unique: true,
                filter: "[StateId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CommuneTownship_City_Zone_Name",
                schema: "Gene",
                table: "CommuneTownships",
                columns: new[] { "CityId", "ZoneId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommuneTownships_ZoneId",
                schema: "Gene",
                table: "CommuneTownships",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Name",
                schema: "Gene",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gender_Name",
                schema: "Gene",
                table: "Genders",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupType_Name",
                schema: "Vote",
                table: "GroupTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Admi",
                table: "MyUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_MyUser_GenderId",
                schema: "Admi",
                table: "MyUser",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_MyUser_GroupTypeId",
                schema: "Admi",
                table: "MyUser",
                column: "GroupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MyUser_NeighborhoodSidewalkId",
                schema: "Admi",
                table: "MyUser",
                column: "NeighborhoodSidewalkId");

            migrationBuilder.CreateIndex(
                name: "IX_MyUser_PollId",
                schema: "Admi",
                table: "MyUser",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Admi",
                table: "MyUser",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NeighborhoodSidewalk_CommuneTownship_Name",
                schema: "Gene",
                table: "NeighborhoodSidewalks",
                columns: new[] { "CommuneTownshipId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Poll_CityId_MarketStall",
                schema: "Vote",
                table: "Polls",
                columns: new[] { "CityId", "MarketStall" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_State_Country_Name",
                schema: "Gene",
                table: "States",
                columns: new[] { "CountryId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zone_Name",
                schema: "Gene",
                table: "Zones",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MyRoleClaims_MyRoles_RoleId",
                schema: "Admi",
                table: "MyRoleClaims",
                column: "RoleId",
                principalSchema: "Admi",
                principalTable: "MyRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MyUserClaims_MyUser_UserId",
                schema: "Admi",
                table: "MyUserClaims",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "MyUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MyUserLogins_MyUser_UserId",
                schema: "Admi",
                table: "MyUserLogins",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "MyUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MyUserRoles_MyRoles_RoleId",
                schema: "Admi",
                table: "MyUserRoles",
                column: "RoleId",
                principalSchema: "Admi",
                principalTable: "MyRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MyUserRoles_MyUser_UserId",
                schema: "Admi",
                table: "MyUserRoles",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "MyUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MyUserTokens_MyUser_UserId",
                schema: "Admi",
                table: "MyUserTokens",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "MyUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyRoleClaims_MyRoles_RoleId",
                schema: "Admi",
                table: "MyRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_MyUserClaims_MyUser_UserId",
                schema: "Admi",
                table: "MyUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_MyUserLogins_MyUser_UserId",
                schema: "Admi",
                table: "MyUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_MyUserRoles_MyRoles_RoleId",
                schema: "Admi",
                table: "MyUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_MyUserRoles_MyUser_UserId",
                schema: "Admi",
                table: "MyUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_MyUserTokens_MyUser_UserId",
                schema: "Admi",
                table: "MyUserTokens");

            migrationBuilder.DropTable(
                name: "MyUser",
                schema: "Admi");

            migrationBuilder.DropTable(
                name: "Genders",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "GroupTypes",
                schema: "Vote");

            migrationBuilder.DropTable(
                name: "NeighborhoodSidewalks",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "Polls",
                schema: "Vote");

            migrationBuilder.DropTable(
                name: "CommuneTownships",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "Zones",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "States",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Gene");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyUserTokens",
                schema: "Admi",
                table: "MyUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyUserRoles",
                schema: "Admi",
                table: "MyUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyUserLogins",
                schema: "Admi",
                table: "MyUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyUserClaims",
                schema: "Admi",
                table: "MyUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyRoles",
                schema: "Admi",
                table: "MyRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyRoleClaims",
                schema: "Admi",
                table: "MyRoleClaims");

            migrationBuilder.RenameTable(
                name: "MyUserTokens",
                schema: "Admi",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "MyUserRoles",
                schema: "Admi",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "MyUserLogins",
                schema: "Admi",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "MyUserClaims",
                schema: "Admi",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "MyRoles",
                schema: "Admi",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "MyRoleClaims",
                schema: "Admi",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_MyUserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_MyUserLogins_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MyUserClaims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MyRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
