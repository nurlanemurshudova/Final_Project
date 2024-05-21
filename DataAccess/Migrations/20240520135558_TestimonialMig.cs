using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TestimonialMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GurdianNumbers_Number",
                table: "GurdianNumbers");

            migrationBuilder.DropIndex(
                name: "IX_GurdianNumbers_Number_Deleted",
                table: "GurdianNumbers");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_GurdianEmail",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_GurdianEmail_Deleted",
                table: "Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_GurdianNumbers_Number",
                table: "GurdianNumbers",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_GurdianEmail",
                table: "Appointments",
                column: "GurdianEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GurdianNumbers_Number",
                table: "GurdianNumbers");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_GurdianEmail",
                table: "Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_GurdianNumbers_Number",
                table: "GurdianNumbers",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GurdianNumbers_Number_Deleted",
                table: "GurdianNumbers",
                columns: new[] { "Number", "Deleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_GurdianEmail",
                table: "Appointments",
                column: "GurdianEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_GurdianEmail_Deleted",
                table: "Appointments",
                columns: new[] { "GurdianEmail", "Deleted" },
                unique: true);
        }
    }
}
