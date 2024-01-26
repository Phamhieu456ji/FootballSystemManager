using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastConnectFootballSystem.Migrations
{
    /// <inheritdoc />
    public partial class Added_Field_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    FieldID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FieldStatus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disease", x => x.FieldID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Field");
        }
    }
}
