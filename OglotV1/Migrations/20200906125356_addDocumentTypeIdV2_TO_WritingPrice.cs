using Microsoft.EntityFrameworkCore.Migrations;

namespace OglotV1.Migrations
{
    public partial class addDocumentTypeIdV2_TO_WritingPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ConversionTypId",
                table: "WritingPrice");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "WritingPrice");

            migrationBuilder.DropColumn(
                name: "TimePeriodId",
                table: "WritingPrice");

            migrationBuilder.AlterColumn<int>(
                name: "WritingTimePeriodId",
                table: "WritingPrice",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WritingDocumentTypeId",
                table: "WritingPrice",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WritingConversionTypeId",
                table: "WritingPrice",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WritingPrice_WritingConversionType_WritingConversionTypeId",
                table: "WritingPrice",
                column: "WritingConversionTypeId",
                principalTable: "WritingConversionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WritingPrice_WritingDocumentType_WritingDocumentTypeId",
                table: "WritingPrice",
                column: "WritingDocumentTypeId",
                principalTable: "WritingDocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WritingPrice_WritingTimePeriod_WritingTimePeriodId",
                table: "WritingPrice",
                column: "WritingTimePeriodId",
                principalTable: "WritingTimePeriod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AlterColumn<int>(
                name: "WritingTimePeriodId",
                table: "WritingPrice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "WritingDocumentTypeId",
                table: "WritingPrice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "WritingConversionTypeId",
                table: "WritingPrice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ConversionTypId",
                table: "WritingPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocumentTypeId",
                table: "WritingPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimePeriodId",
                table: "WritingPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
