using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenCrown.Migrations
{
    /// <inheritdoc />
    public partial class FixTransactionAccountRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transaction_users_receiver_account_id",
                table: "transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_transaction_users_sender_account_id",
                table: "transaction");

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_account_receiver_account_id",
                table: "transaction",
                column: "receiver_account_id",
                principalTable: "account",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_account_sender_account_id",
                table: "transaction",
                column: "sender_account_id",
                principalTable: "account",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transaction_account_receiver_account_id",
                table: "transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_transaction_account_sender_account_id",
                table: "transaction");

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_users_receiver_account_id",
                table: "transaction",
                column: "receiver_account_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_users_sender_account_id",
                table: "transaction",
                column: "sender_account_id",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
