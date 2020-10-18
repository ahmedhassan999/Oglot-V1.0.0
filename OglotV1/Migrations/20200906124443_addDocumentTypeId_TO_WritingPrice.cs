using Microsoft.EntityFrameworkCore.Migrations;

namespace OglotV1.Migrations
{
    public partial class addDocumentTypeId_TO_WritingPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentTypeId",
                table: "WritingPrice",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WritingConversionTypeId",
                table: "WritingPrice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WritingDocumentTypeId",
                table: "WritingPrice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WritingTimePeriodId",
                table: "WritingPrice",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WritingPrice_WritingConversionTypeId",
                table: "WritingPrice",
                column: "WritingConversionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WritingPrice_WritingDocumentTypeId",
                table: "WritingPrice",
                column: "WritingDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WritingPrice_WritingTimePeriodId",
                table: "WritingPrice",
                column: "WritingTimePeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_WritingPrice_WritingConversionType_WritingConversionTypeId",
                table: "WritingPrice",
                column: "WritingConversionTypeId",
                principalTable: "WritingConversionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WritingPrice_WritingDocumentType_WritingDocumentTypeId",
                table: "WritingPrice",
                column: "WritingDocumentTypeId",
                principalTable: "WritingDocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WritingPrice_WritingTimePeriod_WritingTimePeriodId",
                table: "WritingPrice",
                column: "WritingTimePeriodId",
                principalTable: "WritingTimePeriod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WritingPrice_WritingConversionType_WritingConversionTypeId",
                table: "WritingPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_WritingPrice_WritingDocumentType_WritingDocumentTypeId",
                table: "WritingPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_WritingPrice_WritingTimePeriod_WritingTimePeriodId",
                table: "WritingPrice");

            migrationBuilder.DropIndex(
                name: "IX_WritingPrice_WritingConversionTypeId",
                table: "WritingPrice");

            migrationBuilder.DropIndex(
                name: "IX_WritingPrice_WritingDocumentTypeId",
                table: "WritingPrice");

            migrationBuilder.DropIndex(
                name: "IX_WritingPrice_WritingTimePeriodId",
                table: "WritingPrice");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "WritingPrice");

            migrationBuilder.DropColumn(
                name: "WritingConversionTypeId",
                table: "WritingPrice");

            migrationBuilder.DropColumn(
                name: "WritingDocumentTypeId",
                table: "WritingPrice");

            migrationBuilder.DropColumn(
                name: "WritingTimePeriodId",
                table: "WritingPrice");
        }
    }
}
