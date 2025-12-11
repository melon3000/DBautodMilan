using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBautodMilan.Migrations
{
    /// <inheritdoc />
    public partial class lol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CarServices",
                table: "CarServices");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CarServices",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "CarServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceCharged",
                table: "CarServices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarServices",
                table: "CarServices",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CarServices_CarId",
                table: "CarServices",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CarServices",
                table: "CarServices");

            migrationBuilder.DropIndex(
                name: "IX_CarServices_CarId",
                table: "CarServices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CarServices");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "CarServices");

            migrationBuilder.DropColumn(
                name: "PriceCharged",
                table: "CarServices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarServices",
                table: "CarServices",
                columns: new[] { "CarId", "ServiceId", "DateOfService" });
        }
    }
}
