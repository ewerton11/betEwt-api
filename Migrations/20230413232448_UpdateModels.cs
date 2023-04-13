using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace betEwt_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user",
                table: "Users",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "passwordHash",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Users",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Bets",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Bets",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Bets",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Bets",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Bets",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Users",
                newName: "user");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "passwordHash");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Users",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Bets",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Bets",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Bets",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Bets",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bets",
                newName: "id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "passwordHash",
                keyValue: null,
                column: "passwordHash",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "passwordHash",
                table: "Users",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
