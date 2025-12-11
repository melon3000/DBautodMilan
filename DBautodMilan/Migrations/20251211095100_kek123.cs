using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBautodMilan.Migrations
{
    /// <inheritdoc />
    public partial class kek123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mileage",
                table: "CarServices",
                newName: "Labisoit");

            migrationBuilder.RenameColumn(
                name: "Completed",
                table: "CarServices",
                newName: "Valmis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valmis",
                table: "CarServices",
                newName: "Completed");

            migrationBuilder.RenameColumn(
                name: "Labisoit",
                table: "CarServices",
                newName: "Mileage");
        }
    }
}
