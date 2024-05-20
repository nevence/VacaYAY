using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresentationLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsDeletedIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VacationRequests_IsDeleted",
                table: "VacationRequests");

            migrationBuilder.DropIndex(
                name: "IX_Positions_IsDeleted",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IsDeleted",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_IsDeleted",
                table: "VacationRequests",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_IsDeleted",
                table: "Positions",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IsDeleted",
                table: "AspNetUsers",
                column: "IsDeleted",
                filter: "IsDeleted = 0");
        }
    }
}
