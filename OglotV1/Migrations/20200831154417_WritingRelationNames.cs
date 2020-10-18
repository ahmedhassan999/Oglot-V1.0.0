using Microsoft.EntityFrameworkCore.Migrations;

namespace OglotV1.Migrations
{
    public partial class WritingRelationNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ConversionTypeId",
                table: "WritingRequest");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "WritingRequest");

            migrationBuilder.DropColumn(
                name: "TimePeriodId",
                table: "WritingRequest");

            migrationBuilder.AlterColumn<int>(
                name: "WritingTimePeriodId",
                table: "WritingRequest",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WritingDocumentTypeId",
                table: "WritingRequest",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WritingConversionTypeId",
                table: "WritingRequest",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WritingRequest_WritingConversionType_WritingConversionTypeId",
                table: "WritingRequest",
                column: "WritingConversionTypeId",
                principalTable: "WritingConversionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WritingRequest_WritingDocumentType_WritingDocumentTypeId",
                table: "WritingRequest",
                column: "WritingDocumentTypeId",
                principalTable: "WritingDocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WritingRequest_WritingTimePeriod_WritingTimePeriodId",
                table: "WritingRequest",
                column: "WritingTimePeriodId",
                principalTable: "WritingTimePeriod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AlterColumn<int>(
                name: "WritingTimePeriodId",
                table: "WritingRequest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "WritingDocumentTypeId",
                table: "WritingRequest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "WritingConversionTypeId",
                table: "WritingRequest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ConversionTypeId",
                table: "WritingRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocumentTypeId",
                table: "WritingRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimePeriodId",
                table: "WritingRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
