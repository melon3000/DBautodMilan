using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBautodMilan.Migrations
{
    /// <inheritdoc />
    public partial class testing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valmis",
                table: "CarServices",
                newName: "Done");

            migrationBuilder.RenameColumn(
                name: "Labisoit",
                table: "CarServices",
                newName: "Mileage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mileage",
                table: "CarServices",
                newName: "Labisoit");

            migrationBuilder.RenameColumn(
                name: "Done",
                table: "CarServices",
                newName: "Valmis");
        }
    }
}
