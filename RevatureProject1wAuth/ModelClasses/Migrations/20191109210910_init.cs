using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelClasses.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTypes_Accounts_AccountID",
                table: "AccountTypes");

            migrationBuilder.DropIndex(
                name: "IX_AccountTypes_AccountID",
                table: "AccountTypes");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "AccountTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "AccountTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypes_AccountID",
                table: "AccountTypes",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTypes_Accounts_AccountID",
                table: "AccountTypes",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
