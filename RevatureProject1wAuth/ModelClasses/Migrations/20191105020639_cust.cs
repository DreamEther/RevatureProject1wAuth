using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelClasses.Migrations
{
    public partial class cust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Customers_CustomerID",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_AccountID",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_AccountID",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_CustomerID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "CheckingAccounts");

            migrationBuilder.AddColumn<int>(
                name: "CheckingAccountID",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerID",
                table: "CheckingAccounts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomerID1",
                table: "CheckingAccounts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckingAccounts",
                table: "CheckingAccounts",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CheckingAccountID",
                table: "Transaction",
                column: "CheckingAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingAccounts_CustomerID1",
                table: "CheckingAccounts",
                column: "CustomerID1");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckingAccounts_Customers_CustomerID1",
                table: "CheckingAccounts",
                column: "CustomerID1",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_CheckingAccounts_CheckingAccountID",
                table: "Transaction",
                column: "CheckingAccountID",
                principalTable: "CheckingAccounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckingAccounts_Customers_CustomerID1",
                table: "CheckingAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_CheckingAccounts_CheckingAccountID",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_CheckingAccountID",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckingAccounts",
                table: "CheckingAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CheckingAccounts_CustomerID1",
                table: "CheckingAccounts");

            migrationBuilder.DropColumn(
                name: "CheckingAccountID",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "CustomerID1",
                table: "CheckingAccounts");

            migrationBuilder.RenameTable(
                name: "CheckingAccounts",
                newName: "Account");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Account",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccountID",
                table: "Transaction",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Account_CustomerID",
                table: "Account",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Customers_CustomerID",
                table: "Account",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_AccountID",
                table: "Transaction",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
