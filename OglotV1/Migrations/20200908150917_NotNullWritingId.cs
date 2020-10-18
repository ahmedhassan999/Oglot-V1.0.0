using Microsoft.EntityFrameworkCore.Migrations;

namespace OglotV1.Migrations
{
    public partial class NotNullWritingId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WritingAttachment_WritingRequest_WritingRequestId",
                table: "WritingAttachment");

            migrationBuilder.AlterColumn<int>(
                name: "WritingRequestId",
                table: "WritingAttachment",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WritingAttachment_WritingRequest_WritingRequestId",
                table: "WritingAttachment",
                column: "WritingRequestId",
                principalTable: "WritingRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WritingAttachment_WritingRequest_WritingRequestId",
                table: "WritingAttachment");

            migrationBuilder.AlterColumn<int>(
                name: "WritingRequestId",
                table: "WritingAttachment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_WritingAttachment_WritingRequest_WritingRequestId",
                table: "WritingAttachment",
                column: "WritingRequestId",
                principalTable: "WritingRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
