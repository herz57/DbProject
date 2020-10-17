using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbProject.Migrations
{
    public partial class AddEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblDeliveryDetail",
                columns: table => new
                {
                    DELDET_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DELDET_CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    DELDET_UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    DELDET_Name = table.Column<string>(nullable: true),
                    DELDET_Email = table.Column<string>(nullable: true),
                    DELDET_Phone = table.Column<string>(nullable: true),
                    DELDET_Mobile = table.Column<string>(nullable: true),
                    DELDET_Address1 = table.Column<string>(nullable: true),
                    DELDET_Address2 = table.Column<string>(nullable: true),
                    DELDET_City = table.Column<string>(nullable: true),
                    DELDET_County = table.Column<string>(nullable: true),
                    DELDET_Country = table.Column<string>(nullable: true),
                    DELDET_PostCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDeliveryDetail", x => x.DELDET_Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    USER_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_UserName = table.Column<string>(nullable: true),
                    USER_Email = table.Column<string>(nullable: true),
                    USER_Phone = table.Column<string>(nullable: true),
                    USER_Mobile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.USER_Id);
                });

            migrationBuilder.CreateTable(
                name: "tblAuditLog",
                columns: table => new
                {
                    AUDLOG_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AUDLOG_CreateDate = table.Column<DateTime>(nullable: true, computedColumnSql: "getutcdate()"),
                    AUDLOG_UpdateDate = table.Column<DateTime>(nullable: true, computedColumnSql: "getutcdate()"),
                    AUDLOG_TableName = table.Column<string>(nullable: true),
                    AUDLOG_Action = table.Column<string>(nullable: true),
                    AUDLOG_CreateUserId = table.Column<int>(nullable: false),
                    AUDLOG_UpdateUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAuditLog", x => x.AUDLOG_Id);
                    table.ForeignKey(
                        name: "FK_tblAuditLog_tblUser_AUDLOG_CreateUserId",
                        column: x => x.AUDLOG_CreateUserId,
                        principalTable: "tblUser",
                        principalColumn: "USER_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAuditLog_tblUser_AUDLOG_UpdateUserId",
                        column: x => x.AUDLOG_UpdateUserId,
                        principalTable: "tblUser",
                        principalColumn: "USER_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblCategory",
                columns: table => new
                {
                    CAT_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CAT_CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CAT_UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CAT_Name = table.Column<string>(nullable: true),
                    CAT_CreateUserId = table.Column<int>(nullable: false),
                    CAT_UpdateUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategory", x => x.CAT_Id);
                    table.ForeignKey(
                        name: "FK_tblCategory_tblUser_CAT_CreateUserId",
                        column: x => x.CAT_CreateUserId,
                        principalTable: "tblUser",
                        principalColumn: "USER_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCategory_tblUser_CAT_UpdateUserId",
                        column: x => x.CAT_UpdateUserId,
                        principalTable: "tblUser",
                        principalColumn: "USER_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomer",
                columns: table => new
                {
                    CUS_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUS_CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CUS_UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CUS_Name = table.Column<string>(nullable: true),
                    CUS_ContactName = table.Column<string>(nullable: true),
                    CUS_Email = table.Column<string>(nullable: true),
                    CUS_ContactPhone = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    UpdateUserId = table.Column<int>(nullable: false),
                    CUS_Address1 = table.Column<string>(nullable: true),
                    CUS_Address2 = table.Column<string>(nullable: true),
                    CUS_City = table.Column<string>(nullable: true),
                    CUS_County = table.Column<string>(nullable: true),
                    CUS_Country = table.Column<string>(nullable: true),
                    CUS_PostCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomer", x => x.CUS_Id);
                    table.ForeignKey(
                        name: "FK_tblCustomer_tblUser_CreateUserId",
                        column: x => x.CreateUserId,
                        principalTable: "tblUser",
                        principalColumn: "USER_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCustomer_tblUser_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "tblUser",
                        principalColumn: "USER_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblOrderStatus",
                columns: table => new
                {
                    ORDSTAT_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORDSTAT_CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    ORDSTAT_UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    ORDSTAT_Name = table.Column<string>(nullable: true),
                    ORDSTAT_CreateUserId = table.Column<int>(nullable: false),
                    ORDSTAT_UpdateUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrderStatus", x => x.ORDSTAT_Id);
                    table.ForeignKey(
                        name: "FK_tblOrderStatus_tblUser_ORDSTAT_CreateUserId",
                        column: x => x.ORDSTAT_CreateUserId,
                        principalTable: "tblUser",
                        principalColumn: "USER_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblOrderStatus_tblUser_ORDSTAT_UpdateUserId",
                        column: x => x.ORDSTAT_UpdateUserId,
                        principalTable: "tblUser",
                        principalColumn: "USER_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblAuditLogDetail",
                columns: table => new
                {
                    AUDLOGDET_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AUDLOGDET_CreateDate = table.Column<DateTime>(nullable: true, computedColumnSql: "getutcdate()"),
                    AUDLOGDET_UpdateDate = table.Column<DateTime>(nullable: true, computedColumnSql: "getutcdate()"),
                    AUDLOGDET_AUDLOG_Id = table.Column<int>(nullable: false),
                    AUDLOGDET_ValueFrom = table.Column<string>(nullable: true),
                    AUDLOGDET_ValueTo = table.Column<string>(nullable: true),
                    AUDLOGDET_FieldName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAuditLogDetail", x => x.AUDLOGDET_Id);
                    table.ForeignKey(
                        name: "FK_tblAuditLogDetail_tblAuditLog_AUDLOGDET_AUDLOG_Id",
                        column: x => x.AUDLOGDET_AUDLOG_Id,
                        principalTable: "tblAuditLog",
                        principalColumn: "AUDLOG_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblProduct",
                columns: table => new
                {
                    PROD_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROD_CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    PROD_UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    PROD_Name = table.Column<string>(nullable: true),
                    PROD_Price = table.Column<double>(nullable: false),
                    PROD_CAT_Id = table.Column<int>(nullable: false),
                    PROD_CreateUserId = table.Column<int>(nullable: false),
                    PROD_UpdateUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProduct", x => x.PROD_Id);
                    table.ForeignKey(
                        name: "FK_tblProduct_tblCategory_PROD_CAT_Id",
                        column: x => x.PROD_CAT_Id,
                        principalTable: "tblCategory",
                        principalColumn: "CAT_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblProduct_tblUser_PROD_CreateUserId",
                        column: x => x.PROD_CreateUserId,
                        principalTable: "tblUser",
                        principalColumn: "USER_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblProduct_tblUser_PROD_UpdateUserId",
                        column: x => x.PROD_UpdateUserId,
                        principalTable: "tblUser",
                        principalColumn: "USER_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblOrder",
                columns: table => new
                {
                    ORD_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORD_CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    ORD_UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    ORD_DELDET_Id = table.Column<int>(nullable: false),
                    ORD_Price = table.Column<double>(nullable: false),
                    ORD_Currency = table.Column<int>(nullable: false),
                    ORD_CUS_Id = table.Column<int>(nullable: false),
                    ORD_ORDSTAT_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrder", x => x.ORD_Id);
                    table.ForeignKey(
                        name: "FK_tblOrder_tblCustomer_ORD_CUS_Id",
                        column: x => x.ORD_CUS_Id,
                        principalTable: "tblCustomer",
                        principalColumn: "CUS_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblOrder_tblDeliveryDetail_ORD_DELDET_Id",
                        column: x => x.ORD_DELDET_Id,
                        principalTable: "tblDeliveryDetail",
                        principalColumn: "DELDET_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblOrder_tblOrderStatus_ORD_ORDSTAT_Id",
                        column: x => x.ORD_ORDSTAT_Id,
                        principalTable: "tblOrderStatus",
                        principalColumn: "ORDSTAT_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblInvoice",
                columns: table => new
                {
                    INV_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INV_CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    INV_UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    INV_ORD_Id = table.Column<int>(nullable: false),
                    INV_PaymentId = table.Column<int>(nullable: false),
                    INV_Price = table.Column<double>(nullable: false),
                    INV_NameOnCard = table.Column<string>(nullable: true),
                    INV_LastForDigit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblInvoice", x => x.INV_Id);
                    table.ForeignKey(
                        name: "FK_tblInvoice_tblOrder_INV_ORD_Id",
                        column: x => x.INV_ORD_Id,
                        principalTable: "tblOrder",
                        principalColumn: "ORD_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblOrderItem",
                columns: table => new
                {
                    ORDITEM_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORDITEM_CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    ORDITEM_UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    ORDITEM_ORD_Id = table.Column<int>(nullable: false),
                    ORDITEM_PROD_Id = table.Column<int>(nullable: false),
                    ORDITEM_Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrderItem", x => x.ORDITEM_Id);
                    table.ForeignKey(
                        name: "FK_tblOrderItem_tblOrder_ORDITEM_ORD_Id",
                        column: x => x.ORDITEM_ORD_Id,
                        principalTable: "tblOrder",
                        principalColumn: "ORD_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblOrderItem_tblProduct_ORDITEM_PROD_Id",
                        column: x => x.ORDITEM_PROD_Id,
                        principalTable: "tblProduct",
                        principalColumn: "PROD_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAuditLog_AUDLOG_Action",
                table: "tblAuditLog",
                column: "AUDLOG_Action");

            migrationBuilder.CreateIndex(
                name: "IX_tblAuditLog_AUDLOG_CreateUserId",
                table: "tblAuditLog",
                column: "AUDLOG_CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAuditLog_AUDLOG_TableName",
                table: "tblAuditLog",
                column: "AUDLOG_TableName");

            migrationBuilder.CreateIndex(
                name: "IX_tblAuditLog_AUDLOG_UpdateUserId",
                table: "tblAuditLog",
                column: "AUDLOG_UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAuditLogDetail_AUDLOGDET_AUDLOG_Id",
                table: "tblAuditLogDetail",
                column: "AUDLOGDET_AUDLOG_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblAuditLogDetail_AUDLOGDET_FieldName",
                table: "tblAuditLogDetail",
                column: "AUDLOGDET_FieldName");

            migrationBuilder.CreateIndex(
                name: "IX_tblAuditLogDetail_AUDLOGDET_ValueFrom",
                table: "tblAuditLogDetail",
                column: "AUDLOGDET_ValueFrom");

            migrationBuilder.CreateIndex(
                name: "IX_tblAuditLogDetail_AUDLOGDET_ValueTo",
                table: "tblAuditLogDetail",
                column: "AUDLOGDET_ValueTo");

            migrationBuilder.CreateIndex(
                name: "IX_tblCategory_CAT_CreateUserId",
                table: "tblCategory",
                column: "CAT_CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCategory_CAT_Name",
                table: "tblCategory",
                column: "CAT_Name");

            migrationBuilder.CreateIndex(
                name: "IX_tblCategory_CAT_UpdateUserId",
                table: "tblCategory",
                column: "CAT_UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_CUS_ContactName",
                table: "tblCustomer",
                column: "CUS_ContactName");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_CUS_ContactPhone",
                table: "tblCustomer",
                column: "CUS_ContactPhone");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_CreateUserId",
                table: "tblCustomer",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_CUS_Email",
                table: "tblCustomer",
                column: "CUS_Email");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_CUS_Name",
                table: "tblCustomer",
                column: "CUS_Name");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_UpdateUserId",
                table: "tblCustomer",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_CUS_Address1",
                table: "tblCustomer",
                column: "CUS_Address1");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_CUS_Address2",
                table: "tblCustomer",
                column: "CUS_Address2");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_CUS_City",
                table: "tblCustomer",
                column: "CUS_City");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_CUS_Country",
                table: "tblCustomer",
                column: "CUS_Country");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_CUS_County",
                table: "tblCustomer",
                column: "CUS_County");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_CUS_PostCode",
                table: "tblCustomer",
                column: "CUS_PostCode");

            migrationBuilder.CreateIndex(
                name: "IX_tblDeliveryDetail_DELDET_Email",
                table: "tblDeliveryDetail",
                column: "DELDET_Email");

            migrationBuilder.CreateIndex(
                name: "IX_tblDeliveryDetail_DELDET_Mobile",
                table: "tblDeliveryDetail",
                column: "DELDET_Mobile");

            migrationBuilder.CreateIndex(
                name: "IX_tblDeliveryDetail_DELDET_Name",
                table: "tblDeliveryDetail",
                column: "DELDET_Name");

            migrationBuilder.CreateIndex(
                name: "IX_tblDeliveryDetail_DELDET_Phone",
                table: "tblDeliveryDetail",
                column: "DELDET_Phone");

            migrationBuilder.CreateIndex(
                name: "IX_tblDeliveryDetail_DELDET_Address1",
                table: "tblDeliveryDetail",
                column: "DELDET_Address1");

            migrationBuilder.CreateIndex(
                name: "IX_tblDeliveryDetail_DELDET_Address2",
                table: "tblDeliveryDetail",
                column: "DELDET_Address2");

            migrationBuilder.CreateIndex(
                name: "IX_tblDeliveryDetail_DELDET_City",
                table: "tblDeliveryDetail",
                column: "DELDET_City");

            migrationBuilder.CreateIndex(
                name: "IX_tblDeliveryDetail_DELDET_Country",
                table: "tblDeliveryDetail",
                column: "DELDET_Country");

            migrationBuilder.CreateIndex(
                name: "IX_tblDeliveryDetail_DELDET_County",
                table: "tblDeliveryDetail",
                column: "DELDET_County");

            migrationBuilder.CreateIndex(
                name: "IX_tblDeliveryDetail_DELDET_PostCode",
                table: "tblDeliveryDetail",
                column: "DELDET_PostCode");

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoice_INV_LastForDigit",
                table: "tblInvoice",
                column: "INV_LastForDigit");

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoice_INV_NameOnCard",
                table: "tblInvoice",
                column: "INV_NameOnCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoice_INV_ORD_Id",
                table: "tblInvoice",
                column: "INV_ORD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoice_INV_PaymentId",
                table: "tblInvoice",
                column: "INV_PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoice_INV_Price",
                table: "tblInvoice",
                column: "INV_Price");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_ORD_Currency",
                table: "tblOrder",
                column: "ORD_Currency");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_ORD_CUS_Id",
                table: "tblOrder",
                column: "ORD_CUS_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_ORD_DELDET_Id",
                table: "tblOrder",
                column: "ORD_DELDET_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_ORD_ORDSTAT_Id",
                table: "tblOrder",
                column: "ORD_ORDSTAT_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_ORD_Price",
                table: "tblOrder",
                column: "ORD_Price");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderItem_ORDITEM_ORD_Id",
                table: "tblOrderItem",
                column: "ORDITEM_ORD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderItem_ORDITEM_PROD_Id",
                table: "tblOrderItem",
                column: "ORDITEM_PROD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderItem_ORDITEM_Quantity",
                table: "tblOrderItem",
                column: "ORDITEM_Quantity");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderStatus_ORDSTAT_CreateUserId",
                table: "tblOrderStatus",
                column: "ORDSTAT_CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderStatus_ORDSTAT_Name",
                table: "tblOrderStatus",
                column: "ORDSTAT_Name");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderStatus_ORDSTAT_UpdateUserId",
                table: "tblOrderStatus",
                column: "ORDSTAT_UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_PROD_CAT_Id",
                table: "tblProduct",
                column: "PROD_CAT_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_PROD_CreateUserId",
                table: "tblProduct",
                column: "PROD_CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_PROD_Name",
                table: "tblProduct",
                column: "PROD_Name");

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_PROD_Price",
                table: "tblProduct",
                column: "PROD_Price");

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_PROD_UpdateUserId",
                table: "tblProduct",
                column: "PROD_UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_USER_Email",
                table: "tblUser",
                column: "USER_Email");

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_USER_Mobile",
                table: "tblUser",
                column: "USER_Mobile");

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_USER_Phone",
                table: "tblUser",
                column: "USER_Phone");

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_USER_UserName",
                table: "tblUser",
                column: "USER_UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAuditLogDetail");

            migrationBuilder.DropTable(
                name: "tblInvoice");

            migrationBuilder.DropTable(
                name: "tblOrderItem");

            migrationBuilder.DropTable(
                name: "tblAuditLog");

            migrationBuilder.DropTable(
                name: "tblOrder");

            migrationBuilder.DropTable(
                name: "tblProduct");

            migrationBuilder.DropTable(
                name: "tblCustomer");

            migrationBuilder.DropTable(
                name: "tblDeliveryDetail");

            migrationBuilder.DropTable(
                name: "tblOrderStatus");

            migrationBuilder.DropTable(
                name: "tblCategory");

            migrationBuilder.DropTable(
                name: "tblUser");
        }
    }
}
