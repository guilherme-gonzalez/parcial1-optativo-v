using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_banco = table.Column<string>(type: "text", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    apellido = table.Column<string>(type: "text", nullable: false),
                    documento = table.Column<string>(type: "text", nullable: false),
                    direccion = table.Column<string>(type: "text", nullable: false),
                    mail = table.Column<string>(type: "text", nullable: false),
                    celular = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    estado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                    table.CheckConstraint("CK_cliente_apellido_MinLength", "LENGTH(apellido) >= 3");
                    table.CheckConstraint("CK_cliente_celular_MinLength", "LENGTH(celular) >= 0");
                    table.CheckConstraint("CK_cliente_celular_RegularExpression", "celular ~ '^[0-9]+$'");
                    table.CheckConstraint("CK_cliente_documento_MinLength", "LENGTH(documento) >= 3");
                    table.CheckConstraint("CK_cliente_nombre_MinLength", "LENGTH(nombre) >= 3");
                });

            migrationBuilder.CreateTable(
                name: "factura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_cliente = table.Column<string>(type: "text", nullable: false),
                    nro_factura = table.Column<string>(type: "text", nullable: false),
                    fecha_hora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    total = table.Column<decimal>(type: "numeric", nullable: false),
                    total_iva5 = table.Column<decimal>(type: "numeric", nullable: false),
                    total_iva10 = table.Column<decimal>(type: "numeric", nullable: false),
                    total_iva = table.Column<decimal>(type: "numeric", nullable: false),
                    total_letras = table.Column<string>(type: "text", nullable: false),
                    sucursal = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factura", x => x.Id);
                    table.CheckConstraint("CK_factura_nro_factura_RegularExpression", "nro_factura ~ '^[0-9]{3}-[0-9]{3}-[0-9]{6}$'");
                    table.CheckConstraint("CK_factura_total_letras_MinLength", "LENGTH(total_letras) >= 6");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "factura");
        }
    }
}
