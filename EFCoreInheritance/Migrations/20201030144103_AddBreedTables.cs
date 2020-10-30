using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreInheritance.Migrations
{
    public partial class AddBreedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Dog_Breed",
                table: "Animals");

            migrationBuilder.AddColumn<int>(
                name: "CatBreedId",
                table: "Animals",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DogBreedId",
                table: "Animals",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CatBreeds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatBreeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DogBreeds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogBreeds", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CatBreedId",
                table: "Animals",
                column: "CatBreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_DogBreedId",
                table: "Animals",
                column: "DogBreedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_CatBreeds_CatBreedId",
                table: "Animals",
                column: "CatBreedId",
                principalTable: "CatBreeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_DogBreeds_DogBreedId",
                table: "Animals",
                column: "DogBreedId",
                principalTable: "DogBreeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_CatBreeds_CatBreedId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_DogBreeds_DogBreedId",
                table: "Animals");

            migrationBuilder.DropTable(
                name: "CatBreeds");

            migrationBuilder.DropTable(
                name: "DogBreeds");

            migrationBuilder.DropIndex(
                name: "IX_Animals_CatBreedId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_DogBreedId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "CatBreedId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "DogBreedId",
                table: "Animals");

            migrationBuilder.AddColumn<int>(
                name: "Breed",
                table: "Animals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dog_Breed",
                table: "Animals",
                type: "int",
                nullable: true);
        }
    }
}
