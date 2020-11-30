using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DeveloperChallenge.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OFX_FILE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CREATED_AT_DT = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    LANGUAGE = table.Column<string>(nullable: true),
                    BANK_ID = table.Column<int>(nullable: true),
                    TR_NU_ID = table.Column<string>(nullable: true),
                    INTERVAL_START_DT = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    INTERVAL_END_DT = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    FILE_CREATION_DT = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFX_FILE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OFX_TRANSACTION",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CREATED_AT_DT = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    TRANSACTION_DT = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ENTRY_TYPE = table.Column<int>(type: "INT", nullable: true),
                    VALUE = table.Column<decimal>(type: "NUMERIC(20,2)", nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    DUP_OF_TRANSACTION_ID = table.Column<Guid>(nullable: true),
                    OFX_FILE_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFX_TRANSACTION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OFX_TRANSACTION_OFX_FILE_Id",
                        column: x => x.Id,
                        principalTable: "OFX_FILE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OFX_TRANSACTION");

            migrationBuilder.DropTable(
                name: "OFX_FILE");
        }
    }
}