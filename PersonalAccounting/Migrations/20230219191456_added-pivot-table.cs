using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalAccounting.Migrations
{
    /// <inheritdoc />
    public partial class addedpivottable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTransactionPivot",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTransactionPivot");
        }
    }
}
