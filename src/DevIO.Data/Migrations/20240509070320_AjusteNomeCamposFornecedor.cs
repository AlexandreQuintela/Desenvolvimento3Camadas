using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevIO.Data.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNomeCamposFornecedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "varchar(200)",
                table: "Fornecedores",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "varchar(14)",
                table: "Fornecedores",
                newName: "Documento");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Fornecedores",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "Documento",
                table: "Fornecedores",
                type: "varchar(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Fornecedores",
                newName: "varchar(200)");

            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "Fornecedores",
                newName: "varchar(14)");

            migrationBuilder.AlterColumn<string>(
                name: "varchar(200)",
                table: "Fornecedores",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "varchar(14)",
                table: "Fornecedores",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(14)");
        }
    }
}
