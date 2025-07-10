using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternAPI.Migrations
{
    public partial class RemoveResumeFieldFromIntern : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResumeFileName",
                table: "Interns");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResumeFileName",
                table: "Interns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
