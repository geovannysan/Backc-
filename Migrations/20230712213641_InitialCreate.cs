using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Backrest.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "admin");

            migrationBuilder.DropTable(name: "admins");

            migrationBuilder.DropTable(name: "bancoscon");

            migrationBuilder.DropTable(name: "Empleado");

            /*migrationBuilder.DropTable(
                name: "incrementos");*/

            migrationBuilder.DropTable(name: "Reporte");

            migrationBuilder.DropTable(name: "transacion");

            migrationBuilder.DropTable(name: "Cargos");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase().Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.DropTable(name: "admin");

            migrationBuilder.DropTable(name: "admins");

            migrationBuilder.DropTable(name: "bancoscon");

            migrationBuilder.DropTable(name: "Empleado");

            /*migrationBuilder.DropTable(
                name: "incrementos");*/

            migrationBuilder.DropTable(name: "Reporte");

            migrationBuilder.DropTable(name: "transacion");

            migrationBuilder.DropTable(name: "Cargos");
            migrationBuilder
                .CreateTable(
                    name: "admin",
                    columns: table =>
                        new
                        {
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySQL:ValueGenerationStrategy",
                                    MySQLValueGenerationStrategy.IdentityColumn
                                ),
                            username = table.Column<string>(type: "longtext", nullable: true),
                            cedula = table.Column<string>(type: "varchar(255)", nullable: true),
                            password = table.Column<string>(type: "longtext", nullable: true),
                            imag = table.Column<string>(type: "longtext", nullable: true),
                            repuestauno = table.Column<string>(type: "longtext", nullable: true),
                            respuestados = table.Column<string>(type: "longtext", nullable: true),
                            respuestatres = table.Column<string>(type: "longtext", nullable: true)
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_admin", x => x.Id);
                    }
                )
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "admins",
                    columns: table =>
                        new
                        {
                            id = table.Column<string>(type: "varchar(255)", nullable: false),
                            username = table.Column<string>(type: "longtext", nullable: false),
                            name = table.Column<string>(type: "longtext", nullable: false)
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_admins", x => x.id);
                    }
                )
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "bancoscon",
                    columns: table =>
                        new
                        {
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySQL:ValueGenerationStrategy",
                                    MySQLValueGenerationStrategy.IdentityColumn
                                ),
                            fecha = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                            codigo = table.Column<string>(type: "longtext", nullable: true),
                            documento = table.Column<string>(type: "longtext", nullable: true),
                            monto = table.Column<string>(type: "longtext", nullable: true),
                            oficina = table.Column<string>(type: "longtext", nullable: true),
                            banco = table.Column<string>(type: "longtext", nullable: true),
                            name = table.Column<string>(type: "longtext", nullable: true)
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_bancoscon", x => x.Id);
                    }
                )
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "Cargos",
                    columns: table =>
                        new
                        {
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySQL:ValueGenerationStrategy",
                                    MySQLValueGenerationStrategy.IdentityColumn
                                ),
                            Nombre = table.Column<string>(type: "longtext", nullable: true)
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Cargos", x => x.Id);
                    }
                )
                .Annotation("MySQL:Charset", "utf8mb4");

            /* migrationBuilder.CreateTable(
                 name: "incrementos",
                 columns: table => new
                 {
                     id = table.Column<int>(type: "int", nullable: false)
                         .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                     contadores = table.Column<int>(type: "int", nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_incrementos", x => x.id);
                 })
                 .Annotation("MySQL:Charset", "utf8mb4");*/

            migrationBuilder
                .CreateTable(
                    name: "Reporte",
                    columns: table =>
                        new
                        {
                            banco = table.Column<string>(type: "longtext", nullable: true),
                            name = table.Column<string>(type: "longtext", nullable: true),
                            total_compras = table.Column<string>(type: "longtext", nullable: true),
                            codigo_encontrado = table.Column<string>(
                                type: "longtext",
                                nullable: true
                            ),
                            Total = table.Column<string>(type: "longtext", nullable: true)
                        },
                    constraints: table => { }
                )
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "transacion",
                    columns: table =>
                        new
                        {
                            id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySQL:ValueGenerationStrategy",
                                    MySQLValueGenerationStrategy.IdentityColumn
                                ),
                            cliente = table.Column<string>(type: "longtext", nullable: true),
                            idtranse = table.Column<string>(type: "longtext", nullable: true),
                            factura = table.Column<string>(type: "longtext", nullable: true),
                            legal = table.Column<string>(type: "longtext", nullable: true),
                            transacciones = table.Column<string>(type: "longtext", nullable: true),
                            forma_pago = table.Column<string>(type: "longtext", nullable: true),
                            Operador = table.Column<string>(type: "longtext", nullable: true),
                            comision = table.Column<string>(type: "longtext", nullable: true),
                            neto = table.Column<string>(type: "longtext", nullable: true),
                            name = table.Column<string>(type: "longtext", nullable: true),
                            fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                            cobrado = table.Column<string>(type: "longtext", nullable: true),
                            cedula = table.Column<string>(type: "longtext", nullable: true)
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_transacion", x => x.id);
                    }
                )
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "Empleado",
                    columns: table =>
                        new
                        {
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySQL:ValueGenerationStrategy",
                                    MySQLValueGenerationStrategy.IdentityColumn
                                ),
                            Nombre = table.Column<string>(type: "longtext", nullable: true),
                            Apellido = table.Column<string>(type: "longtext", nullable: true),
                            Sueldo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                            Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                            edad = table.Column<int>(type: "int", nullable: true),
                            CargosId = table.Column<int>(type: "int", nullable: true)
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Empleado", x => x.Id);
                        table.ForeignKey(
                            name: "FK_Empleado_Cargos_CargosId",
                            column: x => x.CargosId,
                            principalTable: "Cargos",
                            principalColumn: "Id"
                        );
                    }
                )
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_admin_cedula",
                table: "admin",
                column: "cedula",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_CargosId",
                table: "Empleado",
                column: "CargosId"
            );
        }

        /// <inheritdoc />
    }
}
