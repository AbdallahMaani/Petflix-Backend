using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullPetFlix.Migrations
{
    /// <inheritdoc />
    public partial class FixDateTimeKind : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 7, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8280));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 6, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8280));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 5, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 4,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 5,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 7, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 6,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 6, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 7,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 5, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 8,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 9,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 7, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8300));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 10,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 6, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8300));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 11,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 5, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8300));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 12,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8300));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 6, 7, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2025, 6, 6, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 4,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 5,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 6,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 7,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 8,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 9,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 10,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 11,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 12,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 13,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 14,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 15,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 16,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 17,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 18,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 19,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 20,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 21,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 22,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 23,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 24,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 25,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 26,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 27,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 28,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 29,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 30,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 31,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 32,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 33,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 34,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 35,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 36,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 37,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 38,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 39,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 40,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 41,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 42,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 43,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 44,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 45,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 46,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 47,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 48,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 49,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 50,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 51,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 52,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 53,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 54,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 55,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 56,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 57,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 58,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 59,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 60,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(7580), new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(7580) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(7580), new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(7580) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(7590), new DateTime(2025, 6, 8, 11, 11, 0, 88, DateTimeKind.Utc).AddTicks(7590) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 7, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5660));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 6, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5660));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 5, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5660));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 4,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 5,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 7, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 6,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 6, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 7,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 5, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 8,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 9,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 7, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 10,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 6, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 11,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 5, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5680));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 12,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5680));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 6, 7, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5700));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2025, 6, 6, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5710));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5460));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5460));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5460));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 4,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5460));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 5,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5460));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 6,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5460));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 7,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 8,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 9,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 10,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 11,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 12,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 13,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 14,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 15,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 16,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 17,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 18,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 19,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 20,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 21,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 22,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 23,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 24,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 25,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 26,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 27,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 28,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 29,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 30,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 31,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 32,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 33,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 34,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 35,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 36,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 37,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 38,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 39,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 40,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 41,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 42,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 43,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 44,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 45,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 46,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 47,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 48,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 49,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 50,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 51,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 52,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 53,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 54,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 55,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 56,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 57,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 58,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 59,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 60,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5520));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(4990), new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(4990) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(4990), new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(4990) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5000), new DateTime(2025, 6, 8, 11, 9, 8, 208, DateTimeKind.Utc).AddTicks(5000) });
        }
    }
}
