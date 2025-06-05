using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullPetFlix.Migrations
{
    /// <inheritdoc />
    public partial class addAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 3, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8650));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 2, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8650));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 1, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8660));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 4,
                column: "ReviewDate",
                value: new DateTime(2025, 5, 31, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8660));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 5,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 3, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8660));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 6,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 2, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 7,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 1, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 8,
                column: "ReviewDate",
                value: new DateTime(2025, 5, 31, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 9,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 3, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 10,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 2, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 11,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 1, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 12,
                column: "ReviewDate",
                value: new DateTime(2025, 5, 31, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 6, 3, 20, 18, 17, 821, DateTimeKind.Utc).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2025, 6, 2, 20, 18, 17, 821, DateTimeKind.Utc).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 4,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 5,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 6,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 7,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8410));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 8,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 9,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 10,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 11,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 12,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 13,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 14,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 15,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 16,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 17,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 18,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 19,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 20,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 21,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 22,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 23,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 24,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 25,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 26,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 27,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 28,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 29,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 30,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 31,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 32,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 33,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 34,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 35,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 36,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 37,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 38,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 39,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 40,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 41,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 42,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 43,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 44,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 45,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 46,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 47,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 48,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 49,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 50,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 51,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 52,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 53,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 54,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 55,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8500));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 56,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8500));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 57,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8500));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 58,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8500));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 59,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8500));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 60,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 18, 17, 821, DateTimeKind.Local).AddTicks(8510));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 20, 18, 17, 821, DateTimeKind.Utc).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 20, 18, 17, 821, DateTimeKind.Utc).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 20, 18, 17, 821, DateTimeKind.Utc).AddTicks(7870), new DateTime(2025, 6, 4, 20, 18, 17, 821, DateTimeKind.Utc).AddTicks(7870) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 3, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 2, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 1, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 4,
                column: "ReviewDate",
                value: new DateTime(2025, 5, 31, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 5,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 3, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 6,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 2, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 7,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 1, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 8,
                column: "ReviewDate",
                value: new DateTime(2025, 5, 31, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 9,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 3, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 10,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 2, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 11,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 1, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.UpdateData(
                table: "AnimalReviews",
                keyColumn: "AnimalReviewId",
                keyValue: 12,
                column: "ReviewDate",
                value: new DateTime(2025, 5, 31, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 6, 3, 20, 6, 23, 3, DateTimeKind.Utc).AddTicks(6990));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2025, 6, 2, 20, 6, 23, 3, DateTimeKind.Utc).AddTicks(6990));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 4,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 5,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 6,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 7,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 8,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 9,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 10,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 11,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 12,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 13,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 14,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 15,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 16,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 17,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 18,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 19,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 20,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 21,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 22,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 23,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 24,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6680));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 25,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6680));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 26,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 27,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 28,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 29,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 30,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 31,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 32,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6710));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 33,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6710));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 34,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6710));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 35,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6710));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 36,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6710));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 37,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6710));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 38,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 39,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 40,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 41,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 42,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 43,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 44,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 45,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 46,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 47,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 48,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 49,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 50,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 51,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 52,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 53,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 54,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 55,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 56,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 57,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 58,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 59,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "ProductReviewId",
                keyValue: 60,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 20, 6, 23, 3, DateTimeKind.Utc).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 20, 6, 23, 3, DateTimeKind.Utc).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 20, 6, 23, 3, DateTimeKind.Utc).AddTicks(6140), new DateTime(2025, 6, 4, 20, 6, 23, 3, DateTimeKind.Utc).AddTicks(6140) });
        }
    }
}
