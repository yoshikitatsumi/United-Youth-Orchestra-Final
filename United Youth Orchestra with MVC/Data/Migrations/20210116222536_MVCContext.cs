using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace United_Youth_Orchestra_with_MVC.Data.Migrations
{
    public partial class MVCContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instrument",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    instrument = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrument", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schoolyear",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year6orEarlier = table.Column<bool>(nullable: false),
                    Year7 = table.Column<bool>(nullable: false),
                    Year8 = table.Column<bool>(nullable: false),
                    Year9 = table.Column<bool>(nullable: false),
                    Year10 = table.Column<bool>(nullable: false),
                    Year11 = table.Column<bool>(nullable: false),
                    Year12 = table.Column<bool>(nullable: false),
                    Year13 = table.Column<bool>(nullable: false),
                    Other = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schoolyear", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Telephone = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    SYearFK = table.Column<int>(nullable: false),
                    InstFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Instrument_InstFK",
                        column: x => x.InstFK,
                        principalTable: "Instrument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Member_Schoolyear_SYearFK",
                        column: x => x.SYearFK,
                        principalTable: "Schoolyear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Member_InstFK",
                table: "Member",
                column: "InstFK");

            migrationBuilder.CreateIndex(
                name: "IX_Member_SYearFK",
                table: "Member",
                column: "SYearFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Instrument");

            migrationBuilder.DropTable(
                name: "Schoolyear");
        }
    }
}
