using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grade_Project_.Migrations
{
    public partial class fullname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Full_Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Full_Name",
                table: "AspNetUsers");
        }
    }
}
