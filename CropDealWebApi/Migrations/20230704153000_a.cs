using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CropDealWebAPI.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminEmail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    AdminPassword = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    CropID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CropImage = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.CropID);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    ErrorDescription = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Data = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    StackTrace = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserAddress = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    UserPhnumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    UserEmail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserPasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserPasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserAccnumber = table.Column<int>(type: "int", nullable: false),
                    UserIFSC = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    UserBankName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    UserStatus = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValueSql: "('ACTIVE')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile_1", x => x.UserID);
                    table.UniqueConstraint("AK_UserProfile_UserAccnumber", x => x.UserAccnumber);
                });

            migrationBuilder.CreateTable(
                name: "CropOnSale",
                columns: table => new
                {
                    CropAdID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CropType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CropQty = table.Column<int>(type: "int", nullable: false),
                    CropPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    FarmerID = table.Column<int>(type: "int", nullable: false),
                    CropId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropOnSale", x => x.CropAdID);
                    table.ForeignKey(
                        name: "FK_CropOnSale_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "CropID");
                    table.ForeignKey(
                        name: "FK_CropOnSale_CropOnSale",
                        column: x => x.FarmerID,
                        principalTable: "UserProfile",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealerAccNumber = table.Column<int>(type: "int", nullable: false),
                    FarmerAccNumber = table.Column<int>(type: "int", nullable: false),
                    CropName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CropType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CropQty = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoices_Farmer",
                        column: x => x.FarmerAccNumber,
                        principalTable: "UserProfile",
                        principalColumn: "UserAccnumber");
                    table.ForeignKey(
                        name: "FK_Invoices_UserProfile",
                        column: x => x.DealerAccNumber,
                        principalTable: "UserProfile",
                        principalColumn: "UserAccnumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CropOnSale_CropId",
                table: "CropOnSale",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_CropOnSale_FarmerID",
                table: "CropOnSale",
                column: "FarmerID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_DealerAccNumber",
                table: "Invoices",
                column: "DealerAccNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_FarmerAccNumber",
                table: "Invoices",
                column: "FarmerAccNumber");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile",
                table: "UserProfile",
                column: "UserAccnumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "CropOnSale");

            migrationBuilder.DropTable(
                name: "ExceptionLog");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Crops");

            migrationBuilder.DropTable(
                name: "UserProfile");
        }
    }
}
