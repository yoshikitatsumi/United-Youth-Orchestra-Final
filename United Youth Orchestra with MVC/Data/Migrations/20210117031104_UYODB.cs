using Microsoft.EntityFrameworkCore.Migrations;

namespace United_Youth_Orchestra_with_MVC.Data.Migrations
{
    public partial class UYODB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "instrument",
                table: "Instrument");

            migrationBuilder.AddColumn<string>(
                name: "MusicInst",
                table: "Instrument",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MusicInst",
                table: "Instrument");

            migrationBuilder.AddColumn<string>(
                name: "instrument",
                table: "Instrument",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
