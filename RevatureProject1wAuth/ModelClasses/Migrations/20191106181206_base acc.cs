using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelClasses.Migrations
{
    public partial class baseacc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Customers_CustomerID1",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Account_AccountID",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "Accounts");

            migrationBuilder.RenameIndex(
                name: "IX_Account_CustomerID1",
                table: "Accounts",
                newName: "IX_Accounts_CustomerID1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Customers_CustomerID1",
                table: "Accounts",
                column: "CustomerID1",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountID",
                table: "Transactions",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Customers_CustomerID1",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountID",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Account");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_CustomerID1",
                table: "Account",
                newName: "IX_Account_CustomerID1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Customers_CustomerID1",
                table: "Account",
                column: "CustomerID1",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Account_AccountID",
                table: "Transactions",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
