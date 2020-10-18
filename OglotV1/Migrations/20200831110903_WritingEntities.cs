using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OglotV1.Migrations
{
    public partial class WritingEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WritingConversionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WritingConversionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WritingDocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WritingDocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WritingPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConversionTypId = table.Column<int>(nullable: false),
                    TimePeriodId = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WritingPrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WritingRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    PageNumber = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    Paid = table.Column<bool>(nullable: false),
                    Done = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WritingRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WritingTimePeriod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WritingTimePeriod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WritingAttachment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachment = table.Column<int>(nullable: false),
                    WritingRequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WritingAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WritingAttachment_WritingRequest_WritingRequestId",
                        column: x => x.WritingRequestId,
                        principalTable: "WritingRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WritingAttachment_WritingRequestId",
                table: "WritingAttachment",
                column: "WritingRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WritingAttachment");

            migrationBuilder.DropTable(
                name: "WritingConversionType");

            migrationBuilder.DropTable(
                name: "WritingDocumentType");

            migrationBuilder.DropTable(
                name: "WritingPrice");

            migrationBuilder.DropTable(
                name: "WritingTimePeriod");

            migrationBuilder.DropTable(
                name: "WritingRequest");
        }
    }
}
