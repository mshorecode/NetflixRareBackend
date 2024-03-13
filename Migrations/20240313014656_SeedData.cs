using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetflixRareBackend.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Profile_Image_Url",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_On",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ended_On",
                table: "Subscriptions",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_On",
                table: "Subscriptions",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Publication_Date",
                table: "Posts",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Image_Url",
                table: "Posts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_On",
                table: "Comments",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 1, "Technology" },
                    { 2, "Science" },
                    { 3, "Art" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Author_Id", "Content", "Created_On", "Post_Id" },
                values: new object[,]
                {
                    { 1, 1, "Really insightful article, thanks for sharing!", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2017), 2 },
                    { 2, 2, "I never knew quantum computing was so fascinating.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1997), 1 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Approved", "Category_Id", "Content", "Image_Url", "Publication_Date", "Title", "User_Id" },
                values: new object[,]
                {
                    { 1, false, 2, "Quantum computing is set to revolutionize the way we solve complex problems. This post delves into the basics of quantum theory and its application in computing.", "https://example.com/quantum.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1996), "The Dawn of Quantum Computing", 1 },
                    { 2, true, 1, "Neural networks have become a cornerstone of modern AI. This post explores how these networks mimic the human brain to process information.", "https://example.com/neural_networks.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2018), "Exploring the Depths of the Neural Networks", 2 }
                });

            migrationBuilder.InsertData(
                table: "Reactions",
                columns: new[] { "Id", "Image_Url", "Label" },
                values: new object[,]
                {
                    { 1, "like.png", "Like" },
                    { 2, "love.png", "Love" },
                    { 3, "haha.png", "Haha" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Author_Id", "Created_On", "Ended_On", "Follower_Id" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 },
                    { 2, 2, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, 3, new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 1, "Informative" },
                    { 2, "Quick Read" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Bio", "Created_On", "Email", "First_Name", "Is_Staff", "Last_Name", "Profile_Image_Url", "Uid" },
                values: new object[,]
                {
                    { 1, true, "I'm a weird little freak", new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "dj1946@yahoo.com", "Django", true, "Reinhardt", "https://tse3.mm.bing.net/th?id=OIP.RFj9Podx_VZPomRF-Eu_xQHaHa&pid=Api&P=0&h=220", "ZP734FG" },
                    { 2, true, "I'm a hot tomato", new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "ritaskeeta@hotmail.com", "Rita", true, "Hayworth", "https://tse3.mm.bing.net/th?id=OIP.gODAc8rZRPjtRWthtwjA-AHaKK&pid=Api&P=0&h=220", "PG5H372" },
                    { 3, true, "I'm a songstress", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "midnighttrain@gmail.com", "Gladys", true, "Knight", "https://tse3.mm.bing.net/th?id=OIP.IKtEhuzNEmbk6cdHtqpYYAHaLc&pid=Api&P=0&h=220", "A83D98K" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Profile_Image_Url",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_On",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ended_On",
                table: "Subscriptions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_On",
                table: "Subscriptions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Publication_Date",
                table: "Posts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image_Url",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_On",
                table: "Comments",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);
        }
    }
}
