using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.NETCore.Persistence.EF.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "CreatedBy", "CreatedDate", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Trzeba uczyć się bardzo dużo i systematycznie", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aby nauka nie poszła w las", "tinyurl.com/uh9kp3xx", null, null, "Jak nauczyć się C# w 3 dni?" },
                    { 2, "Dzisiaj krótka lekcja C# dla początkujących którzy chcieli by rozpocząć przygodę z tym oto językiem programowania", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# dla nowych adeptów programowania", "tinyurl.com/uh9kp3xx", null, null, "C# dla początkujących" },
                    { 3, "Dzisiaj pokaże wam kuchnię dla ludzi opornych, a co za tym idzie dla leniwych i nie posiadających zmysłu kulinarnego", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gotowanie", "tinyurl.com/3yj4twea", null, null, "Gotwanie dla opornych" },
                    { 4, "Dzisiaj pokaże Ci diete dzięki której zgubisz zbędne kilogramy siedząc przed komputerem i pisząc kod", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dieta", "tinyurl.com/3yj4twea", null, null, "Dieta cud dla programistów, jedz i chudnij" },
                    { 5, "Oprócz kodu i gotowania lubię również elektronikę użytkową, dzisiaj zaprezentuję Ci smartfony które według mnie miały najlepszy stosunekjakości do ceny w 2021 roku", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elektronika", "tinyurl.com/fvy9pp7m", null, null, "Najlepsze smartfony 2021 roku" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Author", "Content", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "PostId" },
                values: new object[,]
                {
                    { 1, "Kalamaz", "Super, daje 5 gwiazdek", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1 },
                    { 2, "KawowySmakosz", "Nie podoba mi się, zalecałbym poprawę", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1 },
                    { 3, "Samalka", "Najlepszy!!", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1 },
                    { 4, "ElektrykSamouk", "Jak łatwo nauczyć się innego języka?", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2 },
                    { 5, "Lavazza", "C# Najlepszy!", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2 },
                    { 6, "HpLover", "Jest to dla mnie najlepsza cześć tego bloga!", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3 },
                    { 7, "KuchennySmakosz", "Nie bierz się za gotowanie, zdecydowanie nie masz o tym pojęcia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3 },
                    { 8, "FanGwiezdnychWojen", "Super dieta, schudłem już 10 kg!", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4 },
                    { 9, "UveFD", "Wiecej ruchu, a nie diety i każdy z was schudnie", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4 },
                    { 10, "Omoplata", "Mi się podoba, wyprobuję", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4 },
                    { 11, "LGFan", "Dlaczego nie pojawił się LG?", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
