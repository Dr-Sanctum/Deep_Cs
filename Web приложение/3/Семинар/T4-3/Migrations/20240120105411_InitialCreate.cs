using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace T4_1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Категория",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Название = table.Column<string>(type: "text", nullable: true),
                    Описание = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Категория", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Склад",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Количество = table.Column<int>(type: "integer", nullable: false),
                    Название = table.Column<string>(type: "text", nullable: true),
                    Описание = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Склад", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Продукт",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Цена = table.Column<int>(type: "integer", nullable: false),
                    Category_Id = table.Column<int>(type: "integer", nullable: true),
                    Store_Id = table.Column<int>(type: "integer", nullable: true),
                    Название = table.Column<string>(type: "text", nullable: true),
                    Описание = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Продукт", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Продукт_Категория_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Категория",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Продукт_Склад_Store_Id",
                        column: x => x.Store_Id,
                        principalTable: "Склад",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Продукт_Category_Id",
                table: "Продукт",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Продукт_Store_Id",
                table: "Продукт",
                column: "Store_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Продукт");

            migrationBuilder.DropTable(
                name: "Категория");

            migrationBuilder.DropTable(
                name: "Склад");
        }
    }
}
