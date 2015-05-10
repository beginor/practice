using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace ConsoleApp.Migrations
{
    public partial class CategoryProduct : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Product",
                columns: table => new
                {
                    CategoryId = table.Column(type: "int", nullable: true),
                    Discontinued = table.Column(type: "float", nullable: false),
                    Id = table.Column(type: "int", nullable: false),
                    Name = table.Column(type: "nvarchar(max)", nullable: true),
                    Price = table.Column(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        columns: x => x.CategoryId,
                        referencedTable: "Category",
                        referencedColumn: "Id");
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Product");
        }
    }
}
