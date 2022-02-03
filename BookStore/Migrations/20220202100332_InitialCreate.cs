using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookStores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Book_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Book_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Published_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    No_of_Pages = table.Column<int>(type: "int", nullable: false),
                    Book_Rating = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStores", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookStores");
        }
    }
}
