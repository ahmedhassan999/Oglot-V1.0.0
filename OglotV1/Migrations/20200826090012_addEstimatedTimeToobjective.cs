using Microsoft.EntityFrameworkCore.Migrations;

namespace OglotV1.Migrations
{
    public partial class addEstimatedTimeToobjective : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url1",
                table: "Url");

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Url",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstimatedTime",
                table: "Objective",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "Url");

            migrationBuilder.DropColumn(
                name: "EstimatedTime",
                table: "Objective");

            migrationBuilder.AddColumn<string>(
                name: "Url1",
                table: "Url",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
