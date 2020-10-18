using Microsoft.EntityFrameworkCore.Migrations;

namespace OglotV1.Migrations
{
    public partial class allowNull_SippingID_StoreID_PreparationDelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PraparationDelivery_Shipping_ShippingId",
                table: "PraparationDelivery");

            migrationBuilder.DropForeignKey(
                name: "FK_PraparationDelivery_Store_StoreId",
                table: "PraparationDelivery");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "PraparationDelivery",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ShippingId",
                table: "PraparationDelivery",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PraparationDelivery_Shipping_ShippingId",
                table: "PraparationDelivery",
                column: "ShippingId",
                principalTable: "Shipping",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PraparationDelivery_Store_StoreId",
                table: "PraparationDelivery",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PraparationDelivery_Shipping_ShippingId",
                table: "PraparationDelivery");

            migrationBuilder.DropForeignKey(
                name: "FK_PraparationDelivery_Store_StoreId",
                table: "PraparationDelivery");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "PraparationDelivery",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShippingId",
                table: "PraparationDelivery",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PraparationDelivery_Shipping_ShippingId",
                table: "PraparationDelivery",
                column: "ShippingId",
                principalTable: "Shipping",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PraparationDelivery_Store_StoreId",
                table: "PraparationDelivery",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
