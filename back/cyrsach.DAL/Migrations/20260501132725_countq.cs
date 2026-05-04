using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cyrsach.DAL.Migrations
{
    /// <inheritdoc />
    public partial class countq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionCount",
                table: "Tests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuestionId",
                table: "Tests",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionCount",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Tests");
        }
    }
}
