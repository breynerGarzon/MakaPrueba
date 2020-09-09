using Microsoft.EntityFrameworkCore.Migrations;

namespace MakaPrueba.Datos.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    Age = table.Column<int>(nullable: false),
                    PersonTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PersonTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Teacher" });

            migrationBuilder.InsertData(
                table: "PersonTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Students" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Age", "Name", "PersonTypeId" },
                values: new object[,]
                {
                    { 1, 20, "Usuario1", 1 },
                    { 3, 22, "Usuario3", 1 },
                    { 2, 21, "Usuario2", 2 },
                    { 4, 23, "Usuario4", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonTypeId",
                table: "Persons",
                column: "PersonTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "PersonTypes");
        }
    }
}
