using Microsoft.EntityFrameworkCore.Migrations;

namespace OglotV1.Migrations
{
    public partial class ForignKeysToWritings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConversionTypeId",
                table: "WritingRequest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocumentTypeId",
                table: "WritingRequest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimePeriodId",
                table: "WritingRequest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WritingConversionTypeId",
                table: "WritingRequest",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WritingDocumentTypeId",
                table: "WritingRequest",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WritingTimePeriodId",
                table: "WritingRequest",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WritingRequest_WritingConversionTypeId",
                table: "WritingRequest",
                column: "WritingConversionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WritingRequest_WritingDocumentTypeId",
                table: "WritingRequest",
                column: "WritingDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WritingRequest_WritingTimePeriodId",
                table: "WritingRequest",
                column: "WritingTimePeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_WritingRequest_WritingConversionType_WritingConversionTypeId",
                table: "WritingRequest",
                column: "WritingConversionTypeId",
                principalTable: "WritingConversionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WritingRequest_WritingDocumentType_WritingDocumentTypeId",
                table: "WritingRequest",
                column: "WritingDocumentTypeId",
                principalTable: "WritingDocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WritingRequest_WritingTimePeriod_WritingTimePeriodId",
                table: "WritingRequest",
                column: "WritingTimePeriodId",
                principalTable: "WritingTimePeriod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WritingRequest_WritingConversionType_WritingConversionTypeId",
                table: "WritingRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_WritingRequest_WritingDocumentType_WritingDocumentTypeId",
                table: "WritingRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_WritingRequest_WritingTimePeriod_WritingTimePeriodId",
                table: "WritingRequest");

            migrationBuilder.DropIndex(
                name: "IX_WritingRequest_WritingConversionTypeId",
                table: "WritingRequest");

            migrationBuilder.DropIndex(
                name: "IX_WritingRequest_WritingDocumentTypeId",
                table: "WritingRequest");

            migrationBuilder.DropIndex(
                name: "IX_WritingRequest_WritingTimePeriodId",
                table: "WritingRequest");

            migrationBuilder.DropColumn(
                name: "ConversionTypeId",
                table: "WritingRequest");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "WritingRequest");

            migrationBuilder.DropColumn(
                name: "TimePeriodId",
                table: "WritingRequest");

            migrationBuilder.DropColumn(
                name: "WritingConversionTypeId",
                table: "WritingRequest");

            migrationBuilder.DropColumn(
                name: "WritingDocumentTypeId",
                table: "WritingRequest");

            migrationBuilder.DropColumn(
                name: "WritingTimePeriodId",
                table: "WritingRequest");
        }
    }
}
