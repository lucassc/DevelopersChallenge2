using Microsoft.EntityFrameworkCore.Migrations;

namespace DeveloperChallenge.Infra.Migrations
{
    public partial class UpdateForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OFX_TRANSACTION_OFX_FILE_Id",
                table: "OFX_TRANSACTION");

            migrationBuilder.AlterColumn<decimal>(
                name: "VALUE",
                table: "OFX_TRANSACTION",
                type: "NUMERIC(20,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(20,2)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OFX_TRANSACTION_OFX_FILE_ID",
                table: "OFX_TRANSACTION",
                column: "OFX_FILE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OFX_TRANSACTION_OFX_FILE_OFX_FILE_ID",
                table: "OFX_TRANSACTION",
                column: "OFX_FILE_ID",
                principalTable: "OFX_FILE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OFX_TRANSACTION_OFX_FILE_OFX_FILE_ID",
                table: "OFX_TRANSACTION");

            migrationBuilder.DropIndex(
                name: "IX_OFX_TRANSACTION_OFX_FILE_ID",
                table: "OFX_TRANSACTION");

            migrationBuilder.AlterColumn<decimal>(
                name: "VALUE",
                table: "OFX_TRANSACTION",
                type: "NUMBER(20,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(20,2)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OFX_TRANSACTION_OFX_FILE_Id",
                table: "OFX_TRANSACTION",
                column: "Id",
                principalTable: "OFX_FILE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}