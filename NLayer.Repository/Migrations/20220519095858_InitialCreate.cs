using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    IdentityNo = table.Column<long>(type: "bigint", maxLength: 50, nullable: false),
                    IdentityNoVerified = table.Column<bool>(type: "bit", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CardBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardPan = table.Column<long>(type: "bigint", maxLength: 16, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCreditCardFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNetwork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerCreditCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCreditCardFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerCreditCardFeatures_Cards_CustomerCreditCardId",
                        column: x => x.CustomerCreditCardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CardToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerCreditCardId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionLogs_Cards_CustomerCreditCardId",
                        column: x => x.CustomerCreditCardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionLogs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "CustomerId", "IdentityNo", "IdentityNoVerified", "Name", "StatusId", "Surname", "UpdatedDate" },
                values: new object[] { 1, 2000, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 11111111111L, false, "Doctor", 3, "Strange", null });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "CustomerId", "IdentityNo", "IdentityNoVerified", "Name", "StatusId", "Surname", "UpdatedDate" },
                values: new object[] { 2, 2000, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 22222222222L, false, "Black", 3, "Widow", null });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "CustomerId", "IdentityNo", "IdentityNoVerified", "Name", "StatusId", "Surname", "UpdatedDate" },
                values: new object[] { 3, 2000, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 33333333333L, false, "Spider", 3, "Man", null });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CardBrand", "CardPan", "CreatedDate", "CustomerId", "StatusId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Master Card", 5555444433332222L, new DateTime(2022, 5, 19, 13, 58, 58, 305, DateTimeKind.Local).AddTicks(8331), 1, 1, null },
                    { 2, "Master Card", 5555444433332222L, new DateTime(2022, 5, 19, 13, 58, 58, 305, DateTimeKind.Local).AddTicks(8341), 1, 1, null },
                    { 3, "Master Card", 5555444433332222L, new DateTime(2022, 5, 19, 13, 58, 58, 305, DateTimeKind.Local).AddTicks(8342), 1, 3, null },
                    { 4, "Master Card", 5555444433332222L, new DateTime(2022, 5, 19, 13, 58, 58, 305, DateTimeKind.Local).AddTicks(8343), 2, 1, null },
                    { 5, "Master Card", 5555444433332222L, new DateTime(2022, 5, 19, 13, 58, 58, 305, DateTimeKind.Local).AddTicks(8344), 2, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CustomerId",
                table: "Cards",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCreditCardFeatures_CustomerCreditCardId",
                table: "CustomerCreditCardFeatures",
                column: "CustomerCreditCardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLogs_CustomerCreditCardId",
                table: "TransactionLogs",
                column: "CustomerCreditCardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLogs_CustomerId",
                table: "TransactionLogs",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerCreditCardFeatures");

            migrationBuilder.DropTable(
                name: "TransactionLogs");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
