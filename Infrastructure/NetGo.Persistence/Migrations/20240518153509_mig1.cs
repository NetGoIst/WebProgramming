using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetGo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bodies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Element",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Style = table.Column<string>(type: "TEXT", nullable: true),
                    BodyId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    ParentId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Element", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Element_Bodies_BodyId",
                        column: x => x.BodyId,
                        principalTable: "Bodies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Element_Element_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Element",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Element_BodyId",
                table: "Element",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_ParentId",
                table: "Element",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Element");

            migrationBuilder.DropTable(
                name: "Bodies");
        }
    }
}
