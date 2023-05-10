﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOfSweets_DataAccess.Migrations
{
    public partial class AddApplicationTypeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "ApplicationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationType", x => x.Id);
                });
        }

       
    }
}
