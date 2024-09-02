using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCardApp.API.Migrations
{
    /// <inheritdoc />
    public partial class director_contact_information : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DirectorId",
                table: "contact_information",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_contact_information_DirectorId",
                table: "contact_information",
                column: "DirectorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_contact_information_director_DirectorId",
                table: "contact_information",
                column: "DirectorId",
                principalTable: "director",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contact_information_director_DirectorId",
                table: "contact_information");

            migrationBuilder.DropIndex(
                name: "IX_contact_information_DirectorId",
                table: "contact_information");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "contact_information");
        }
    }
}
