using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VolleyForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    ShortName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000001"), "Associação Desportiva e Recreativa Escolar Praiense", "ADREP" },
                    { new Guid("a1000000-0000-0000-0000-000000000002"), "Fayal Sport Club", "FSC" },
                    { new Guid("a1000000-0000-0000-0000-000000000003"), "Clube Desportivo Escolar das Flores", "CDEF" },
                    { new Guid("a1000000-0000-0000-0000-000000000004"), "Grupo Desportivo Velense", "GDV" },
                    { new Guid("a1000000-0000-0000-0000-000000000005"), "Futebol Clube Calheta", "FCC" },
                    { new Guid("a1000000-0000-0000-0000-000000000006"), "Castelo Branco Sport Clube", "CBSC" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
