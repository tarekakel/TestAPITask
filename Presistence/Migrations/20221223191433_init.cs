using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Presistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DownloadTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoDownloadTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoId = table.Column<int>(type: "int", nullable: false),
                    DownloadTypeId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoDownloadTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoDownloadTypes_DownloadTypes_DownloadTypeId",
                        column: x => x.DownloadTypeId,
                        principalTable: "DownloadTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotoDownloadTypes_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DownloadTypes",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "IsDeleted", "TypeName", "UpdateDate", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 23, 23, 14, 32, 848, DateTimeKind.Local).AddTicks(345), null, false, "A4Pdf", null, null },
                    { 2, new DateTime(2022, 12, 23, 23, 14, 32, 848, DateTimeKind.Local).AddTicks(364), null, false, "MobilePdf", null, null },
                    { 3, new DateTime(2022, 12, 23, 23, 14, 32, 848, DateTimeKind.Local).AddTicks(367), null, false, "JPG", null, null }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "ContentText", "ContentTitle", "CreateDate", "CreatedBy", "ImagePath", "IsDeleted", "UpdateDate", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "book2.jpg", "book2.jpg", new DateTime(2022, 12, 23, 23, 14, 32, 848, DateTimeKind.Local).AddTicks(704), null, "C:\\Users\\ASUS\\source\\repos\\TaskTestAppAPI\\TaskTestAppAPI\\wwwRoot\\images\\book2.jpg", false, null, null },
                    { 2, "books.jpg", "books.jpg", new DateTime(2022, 12, 23, 23, 14, 32, 848, DateTimeKind.Local).AddTicks(717), null, "C:\\Users\\ASUS\\source\\repos\\TaskTestAppAPI\\TaskTestAppAPI\\wwwRoot\\images\\books.jpg", false, null, null },
                    { 3, "panda.jpg", "panda.jpg", new DateTime(2022, 12, 23, 23, 14, 32, 848, DateTimeKind.Local).AddTicks(728), null, "C:\\Users\\ASUS\\source\\repos\\TaskTestAppAPI\\TaskTestAppAPI\\wwwRoot\\images\\panda.jpg", false, null, null },
                    { 4, "panda2.png", "panda2.png", new DateTime(2022, 12, 23, 23, 14, 32, 848, DateTimeKind.Local).AddTicks(736), null, "C:\\Users\\ASUS\\source\\repos\\TaskTestAppAPI\\TaskTestAppAPI\\wwwRoot\\images\\panda2.png", false, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotoDownloadTypes_DownloadTypeId",
                table: "PhotoDownloadTypes",
                column: "DownloadTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoDownloadTypes_PhotoId",
                table: "PhotoDownloadTypes",
                column: "PhotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoDownloadTypes");

            migrationBuilder.DropTable(
                name: "DownloadTypes");

            migrationBuilder.DropTable(
                name: "Photos");
        }
    }
}
