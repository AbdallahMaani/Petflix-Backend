using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullPetFlix.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isAdmin = table.Column<bool>(type: "bit", nullable: true),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    password = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delivery_method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<int>(type: "int", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    birthDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BirthDayFormatted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    availableDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    availableHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rating = table.Column<double>(type: "float", nullable: true),
                    bio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    animal_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: "Animal"),
                    animal_new_price = table.Column<double>(type: "float", nullable: true),
                    animal_old_price = table.Column<double>(type: "float", nullable: true),
                    animal_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    animal_category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    animal_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    animal_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: true),
                    age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vaccineStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    animal_weight = table.Column<double>(type: "float", nullable: true),
                    animal_size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    health_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    animal_pic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.animal_id);
                    table.ForeignKey(
                        name: "FK_Animals_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FeedbackType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Response = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IncludeDelivery = table.Column<bool>(type: "bit", nullable: true),
                    Tip = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: "Product"),
                    product_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_new_price = table.Column<double>(type: "float", nullable: true),
                    product_old_price = table.Column<double>(type: "float", nullable: true),
                    product_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    product_weight = table.Column<double>(type: "float", nullable: true),
                    expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    designedFor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_pic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_Products_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimalReviews",
                columns: table => new
                {
                    AnimalReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewerId = table.Column<int>(type: "int", nullable: true),
                    AnimalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalReviews", x => x.AnimalReviewId);
                    table.ForeignKey(
                        name: "FK_AnimalReviews_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "animal_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalReviews_Users_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    ItemType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    FavoriteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    AnimalId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.FavoriteId);
                    table.ForeignKey(
                        name: "FK_Favorites_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "animal_id");
                    table.ForeignKey(
                        name: "FK_Favorites_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    ProductReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewerId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.ProductReviewId);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Users_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReporterId = table.Column<int>(type: "int", nullable: false),
                    TargetType = table.Column<int>(type: "int", nullable: false),
                    ReportedUserId = table.Column<int>(type: "int", nullable: true),
                    ReportedAnimalId = table.Column<int>(type: "int", nullable: true),
                    ReportedProductId = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResolutionNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_Animals_ReportedAnimalId",
                        column: x => x.ReportedAnimalId,
                        principalTable: "Animals",
                        principalColumn: "animal_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Products_ReportedProductId",
                        column: x => x.ReportedProductId,
                        principalTable: "Products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Users_ReportedUserId",
                        column: x => x.ReportedUserId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Users_ReporterId",
                        column: x => x.ReporterId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "BirthDayFormatted", "ProfilePic", "availableDays", "availableHours", "bio", "birthDay", "delivery_method", "email", "gender", "isAdmin", "location", "name", "password", "phone", "rating", "username" },
                values: new object[,]
                {
                    { 1, "2001-05-31", "https://res.cloudinary.com/dhbhh9aln/image/upload/v1744125357/culuq3puy5ctzaaocvrm.jpg", "Wednesday to Friday", "9:00 AM - 5:00 PM", "Tech enthusiast and animal lover.", new DateTime(2001, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "maani.2K@icloud.com", 0, false, "Amman, Jordan", "Abdallah Maani", "password123", "079-123-4567", 4.5, "AM_2K" },
                    { 2, "2002-07-21", "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742365135/saq6ydbxvxgclzernde3.webp", "Tuesday,Thursday", "10:00 AM - 4:00 PM", "Passionate about animal welfare and education.", new DateTime(2002, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "NotAvailable", "Salma.fayez@example.com", 1, false, "Irbid, Jordan", "Salma Fayez", "Pass!45", "079-765-4321", 4.2000000000000002, "Sal_1999" },
                    { 3, "2001-09-11", "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742364836/lyumxwdia6brmfstqf4i.jpg", "Weekends", "8:00 AM - 4:00 PM", "Dedicated to providing quality pet care.", new DateTime(2001, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "NotAvailable", "ali.hassan@example.com", 0, false, "Amman, Jordan", "Ali Hassan", "alihassanPWD!2021", "079-234-5678", 3.7999999999999998, "osama" },
                    { 4, "2001-10-07", "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742364814/uwhvxn1p12i5atamhwur.webp", "Monday to Friday", "9:00 AM - 3:00 PM", "Experienced in pet training and behavior.", new DateTime(2001, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "Chris.khalil@example.com", 1, false, "Aqaba, Jordan", "Chris Khalil", "Chrispassword#99", "079-345-6789", 4.7000000000000002, "Crhis_2002" },
                    { 5, "2001-05-31", "https://res.cloudinary.com/dhbhh9aln/image/upload/v1743140298/igahl03oejwajrxyz7hv.jpg", "Saturday , Sunday", "10:00 AM - 6:00 PM", "Loves all animals and enjoys sharing pet care tips.", new DateTime(2001, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "maani.2K@icloud.com", 0, false, "Amman , Jordan", " Abdallah Maani", "1234", "079-456-7890", 4.0999999999999996, "AM_2K" },
                    { 6, "2004-01-31", "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742404864/ywyg8nzb9guul4clzhru.jpg", "Monday,Thursday", "12:00 PM - 5:00 PM", "Specializes in small animal care and grooming.", new DateTime(2004, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "zain.najjar@example.com", 1, false, "Salt, Jordan", "Zain Ahmad", "ZainPass34", "079-567-8901", 4.2999999999999998, "Z_2004" },
                    { 7, "2000-03-15", "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742365334/hetngy5mzxd12vqzjyqw.webp", "Sunday to Thursday", "11:00 AM - 5:00 PM", "Provides expert advice on pet nutrition and health.", new DateTime(2000, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "NotAvailable", "layla.ali@example.com", 1, false, "Amman, Jordan", "Layla Ali", "LaylaPass123", "079-876-5432", 4.5999999999999996, "Layla_2000" },
                    { 8, "2003-06-08", "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742428909/fpywvqyzvdnyoi0nkd70.avif", "Monday to Wednesday", "9:00 AM - 2:00 PM", "Focuses on creating a safe and loving environment for pets.", new DateTime(2003, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "NotAvailable", "omar.khalid@example.com", 0, false, "Irbid, Jordan", "Omar Khalid", "OmarPassword456", "079-987-6543", 4.0, "Omar_2003" },
                    { 9, "1998-11-22", "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742365404/ftcdgfvefklibxtha5zj.webp\r\n", "Tuesday to Saturday", "10:00 AM - 6:00 PM", "Offers personalized pet care solutions and advice.", new DateTime(1998, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "noura.saleh@example.com", 1, false, "Aqaba, Jordan", "Noura Saleh", "NouraPass789", "079-654-3210", 4.7999999999999998, "Noura_1998" },
                    { 10, "2001-02-05", "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742433587/ixsid8hb8nqrscf2dgqk.avif", "Wednesday to Sunday", "12:00 PM - 7:00 PM", "Committed to providing exceptional pet care services.", new DateTime(2001, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "tamer.hussein@example.com", 0, false, "Salt, Jordan", "Tamer Hussein", "TamerPassword012", "079-543-2109", 4.4000000000000004, "Tamer_2001" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "animal_id", "ItemType", "age", "animal_category", "animal_description", "animal_new_price", "animal_old_price", "animal_pic", "animal_size", "animal_title", "animal_type", "animal_weight", "gender", "health_status", "userId", "vaccineStatus" },
                values: new object[,]
                {
                    { 1, "Animal", "3 Years", "Cat", "A beautiful and friendly Persian cat that loves to play and cuddle.", 499.99000000000001, 599.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741952757/qe3qj6cgybbix0h0p3o3.jpg", "Medium", "Fluffy Persian Cat", "Persian", 6.0, 0, "Healthy, Friendly, Calm", 1, "Fully Vaccinated" },
                    { 2, "Animal", "5 Years", "Dog", "A friendly and loyal Golden Retriever that is great with kids.", 799.99000000000001, 849.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955302/gietcv07pxpfuy2gxq44.webp", "Large", "Loyal Golden Retriever", "Golden Retriever", 25.0, 1, "Healthy", 2, "Fully Vaccinated" },
                    { 3, "Animal", "2 Years", "Cat", "A playful and curious Siamese cat that loves to explore.", 99.989999999999995, 129.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956003/slgcqoblljdnzfqkmlto.avif", "Small", "Mischievous Siamese Cat", "Siamese", 4.0, 1, "Playful", 3, "Partly Vaccinated" },
                    { 4, "Animal", "4 Years", "Dog", "An energetic and friendly Labrador Retriever that enjoys outdoor activities.", 499.99000000000001, 599.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956927/gvazuhos6kncohv4inip.webp", "Large", "Friendly Labrador Retriever", "Labrador", 30.0, 0, "Energetic", 4, "Fully Vaccinated" },
                    { 5, "Animal", "1 Year", "Bird", "A beautiful and talkative parrot that can mimic sounds and words.", 699.99000000000001, 749.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742124177/lruyr2blmiw5yomciqji.jpg", "Small", "Colorful Talking Parrot", "Parrot", 0.5, 0, "Talkative", 5, "Not Vaccinated" },
                    { 6, "Animal", "2 Years", "Cat", "An affectionate and gentle Ragdoll cat that loves to be held.", 519.99000000000001, 619.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956039/kqknbvhfhnyv35spgcm5.jpg", "Medium", "Cuddly Ragdoll Cat", "Ragdoll", 5.0, 1, "Affectionate", 3, "Fully Vaccinated" },
                    { 7, "Animal", "1 Year", "Dog", "A highly intelligent and playful Poodle that is easy to train.", 549.99000000000001, 649.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741953374/jiedrkghartrj6cfhpqq.jpg", "Medium", "Intelligent Poodle", "Poodle", 7.0, 0, "Intelligent", 1, "Partly Vaccinated" },
                    { 8, "Animal", "3 Years", "Bird", "A beautiful singing Canary that fills your home with melodious tunes.", 249.99000000000001, 299.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955332/uhuci5msnirx5fdmyevi.jpg", "Small", "Singing Canary", "Canary", 0.10000000000000001, 1, "Melodic", 2, "Not Vaccinated" },
                    { 9, "Animal", "4 Years", "Cat", "A curious and playful Sphynx cat that loves to explore and interact.", 599.99000000000001, 699.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956996/mdgonngt5v45j025ft8f.avif", "Small", "Hairless Sphynx Cat", "Sphynx", 4.5, 0, "Curious", 4, "Fully Vaccinated" },
                    { 10, "Animal", "2 Years", "Dog", "A friendly and energetic Beagle that enjoys playing and running.", 229.99000000000001, 329.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742004480/qilnj3oiimxdfiyd3jrm.jpg", "Medium", "Friendly Beagle", "Beagle", 10.0, 1, "Friendly", 5, "Fully Vaccinated" },
                    { 11, "Animal", "5 Years", "Bird", "A social and interactive Cockatiel that loves to be around people.", 179.99000000000001, 279.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956176/pl5libtnzlrqcfjm62va.webp", "Small", "Social Cockatiel", "Cockatiel", 0.20000000000000001, 0, "Social", 3, "Not Vaccinated" },
                    { 12, "Animal", "1 Year", "Fish", "A classic and easy-to-care-for Goldfish that is perfect for beginners.", 49.990000000000002, 74.989999999999995, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741953608/tvmanwh3w9lcigwqdbey.png", "Small", "Common Goldfish", "Goldfish", 0.050000000000000003, 1, "Healthy", 1, "Partly Vaccinated" },
                    { 13, "Animal", "5 Years", "Bird", "A social and interactive Cockatiel that loves to be around people.", 179.99000000000001, 219.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956176/pl5libtnzlrqcfjm62va.webp", "Small", "Social Cockatiel", "Cockatiel", 0.20000000000000001, 0, "Social", 3, "Not Vaccinated" },
                    { 14, "Animal", "3 Years", "Cat", "A large and affectionate Maine Coon that loves human company.", 349.99000000000001, 399.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955402/fhmo848agovyyl66rn8w.jpg", "Large", "Gentle Maine Coon", "Maine Coon", 7.0, 1, "Gentle", 2, "Fully Vaccinated" },
                    { 15, "Animal", "4 Years", "Dog", "A strong and loyal Bulldog with a calm temperament.", 299.99000000000001, 349.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955447/srnbfvcqr0lhpthvcsk6.jpg", "Medium", "Loyal Bulldog", "Bulldog", 22.0, 0, "Loyal", 5, "Fully Vaccinated" },
                    { 16, "Animal", "2 Years", "Bird", "A social and affectionate Lovebird that enjoys companionship.", 99.989999999999995, 149.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741957073/ur6c85or5un5kgqppvo1.webp", "Small", "Chirpy Lovebird", "Lovebird", 0.14999999999999999, 1, "Affectionate", 4, "Not Vaccinated" },
                    { 17, "Animal", "1 Year", "Fish", "A vibrant and easy-to-care-for Betta fish.", 39.990000000000002, 49.990000000000002, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956210/znwlufbwo9njlihhe3zy.webp", "Small", "Colorful Betta Fish", "Betta", 0.029999999999999999, 0, "Vibrant", 3, "Not Vaccinated" },
                    { 18, "Animal", "2 Years", "Cat", "A playful and energetic Bengal cat with a stunning coat.", 379.99000000000001, 399.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741953637/gcqbsifvmknnkyhhjv0h.jpg", "Medium", "Active Bengal Cat", "Bengal", 6.0, 0, "Energetic", 1, "Partly Vaccinated" },
                    { 19, "Animal", "1 Year", "Dog", "A tiny but feisty Chihuahua that is full of personality.", 199.99000000000001, 249.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955447/srnbfvcqr0lhpthvcsk6.jpg", "Small", "Tiny Chihuahua", "Chihuahua", 3.0, 1, "Lively", 2, "Fully Vaccinated" },
                    { 20, "Animal", "4 Years", "Bird", "A smart and social Macaw that loves attention.", 349.99000000000001, 399.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1743239949/uigcjijmhenamqfmy4l5.jpg", "Large", "Intelligent Macaw", "Macaw", 1.2, 0, "Intelligent", 5, "Not Vaccinated" },
                    { 21, "Animal", "1 Year", "Fish", "A bright and active Guppy, perfect for small aquariums.", 29.989999999999998, 39.990000000000002, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956082/oyddcs2xjbgesbofjys4.jpg", "Small", "Colorful Guppy", "Guppy", 0.02, 1, "Active", 3, "Not Vaccinated" },
                    { 22, "Animal", "3 Years", "Cat", "A sleek and elegant Russian Blue cat with a friendly personality.", 349.99000000000001, 399.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741957183/qervcu7unt6gcpjy2qzq.jpg", "Medium", "Elegant Russian Blue", "Russian Blue", 5.5, 1, "Calm", 4, "Fully Vaccinated" },
                    { 23, "Animal", "2 Years", "Dog", "A fluffy and affectionate Shih Tzu that loves being pampered.", 299.99000000000001, 349.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741953690/yoilxd4lrhdhciv0gsyv.jpg", "Small", "Fluffy Shih Tzu", "Shih Tzu", 6.0, 0, "Affectionate", 1, "Partly Vaccinated" },
                    { 24, "Animal", "1 Year", "Bird", "A sweet-sounding Finch that brings music to any home.", 49.990000000000002, 69.989999999999995, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955486/wbs03vsiljzdkcznzihr.jpg", "Small", "Singing Finch", "Finch", 0.10000000000000001, 1, "Melodic", 2, "Not Vaccinated" },
                    { 25, "Animal", "2 Years", "Fish", "A beautiful Angelfish with elegant fins.", 69.989999999999995, 89.989999999999995, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741954448/v3ik0d44lxdpjay9incu.avif", "Small", "Graceful Angelfish", "Angelfish", 0.080000000000000002, 0, "Graceful", 5, "Partly Vaccinated" },
                    { 26, "Animal", "2 Years", "Cat", "A playful and curious Abyssinian cat that loves to climb.", 319.99000000000001, 349.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956125/nqutejc4wszwxetwtfc7.webp", "Medium", "Curious Abyssinian", "Abyssinian", 4.5, 1, "Curious", 3, "Fully Vaccinated" },
                    { 27, "Animal", "3 Years", "Dog", "A playful and energetic Dalmatian that enjoys running and playing.", 349.99000000000001, 399.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741957142/sbyy2rpcqnhkfkpuaqsk.jpg", "Large", "Spotted Dalmatian", "Dalmatian", 20.0, 0, "Energetic", 4, "Partly Vaccinated" },
                    { 28, "Animal", "1 Year", "Bird", "A friendly and social Budgie that loves to chirp.", 39.990000000000002, 59.990000000000002, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741954517/kkkmpomoy6kzrxwbnt91.avif", "Small", "Charming Budgie", "Budgie", 0.050000000000000003, 1, "Social", 5, "Not Vaccinated" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "IncludeDelivery", "OrderDate", "Status", "Tip", "UserId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 6, 3, 20, 6, 23, 3, DateTimeKind.Utc).AddTicks(6990), "Processing", 0.00m, 5 },
                    { 2, false, new DateTime(2025, 6, 2, 20, 6, 23, 3, DateTimeKind.Utc).AddTicks(6990), "Completed", 0.00m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "product_id", "ItemType", "designedFor", "expiration", "product_category", "product_description", "product_new_price", "product_old_price", "product_pic", "product_size", "product_title", "product_type", "product_weight", "usage", "userId" },
                values: new object[,]
                {
                    { 1, "Product", "Dogs", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Food", "Complete and balanced nutrition for medium-sized dogs, ensuring they stay healthy and active.", 149.99000000000001, 174.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741953227/zltok0kmocaleqoemuys.jpg", "Medium", "Premium Dog Food", "Dog Food", 1.5, "Daily Nutrition", 1 },
                    { 2, "Product", "Cats", new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Food", "Irresistible and nutritious food for cats, providing all essential vitamins and minerals.", 119.98999999999999, 139.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741960387/zix6312xkimurxwksjst.avif", "Small", "Delicious Cat Food", "Cat Food", 1.2, "Daily Nutrition", 1 },
                    { 3, "Product", "Dogs", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Toys", "A tough and durable dog toy that can withstand rough play.", 79.989999999999995, 94.989999999999995, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955580/b7nmjo982o1dkaqtubku.jpg", "Medium", "Durable Dog Toy", "Dog Toy", 0.29999999999999999, "Playtime", 2 },
                    { 4, "Product", "Cats", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Toys", "An interactive cat toy with a feather wand that keeps cats entertained.", 49.990000000000002, 59.990000000000002, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956365/gr7q1jkq8xogpqlx9o1o.jpg", "Small", "Interactive Cat Toy - Feather Wand", "Cat Toy", 0.10000000000000001, "Playtime", 3 },
                    { 5, "Product", "Birds", new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Food", "A balanced seed mix for various bird species, ensuring they get all necessary nutrients.", 59.990000000000002, 69.989999999999995, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741957685/ibhil7hr2wt0ciy5zcyj.webp", "Small", "Nutritious Bird Food", "Bird Food", 0.5, "Daily Nutrition", 4 },
                    { 6, "Product", "Dogs", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Accessories", "A stylish and durable leather dog collar that is both comfortable and secure.", 89.989999999999995, 99.989999999999995, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741954791/kobkb9gw1j2t72b6aatd.webp", "Medium", "Stylish Dog Collar", "Dog Collar", 0.20000000000000001, "Identification", 5 },
                    { 7, "Product", "Cats", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Accessories", "Clumping cat litter with odor control, making it easy to clean and maintain.", 179.99000000000001, 199.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741954193/yu68n8ma6esrgufvtx33.webp", "Large", "Clumping Cat Litter", "Cat Litter", 5.0, "Hygiene", 1 },
                    { 8, "Product", "Fish", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Food", "A complete and balanced flake food for tropical fish, promoting vibrant colors and health.", 39.990000000000002, 49.990000000000002, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955640/uobazeneyfmnq04jfa4l.avif", "Small", "Flake Fish Food", "Fish Food", 0.20000000000000001, "Daily Nutrition", 2 },
                    { 9, "Product", "Fish", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Toys", "A decorative castle for your aquarium, providing a fun and engaging environment for fish.", 69.989999999999995, 84.989999999999995, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956401/lgwwur552kzaufiuoxxa.webp", "Small", "Aquarium Castle Decoration", "Fish Toy", 0.050000000000000003, "Decoration", 3 },
                    { 10, "Product", "Fish", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Accessories", "A 20-gallon glass fish tank, perfect for creating a beautiful and healthy aquatic environment.", 249.99000000000001, 299.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741957720/xzf1pgalohpwa7azu7pe.jpg", "Medium", "20-Gallon Fish Tank", "Fish Tank", 10.0, "Housing", 4 },
                    { 11, "Product", "Rabbits", new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Food", "A nutritious blend of pellets and hay for rabbits, promoting healthy digestion and growth.", 29.989999999999998, 39.990000000000002, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741954089/monptgbpqqzhorh2gfy6.webp", "Medium", "Healthy Rabbit Food", "Rabbit Food", 1.0, "Daily Nutrition", 1 },
                    { 12, "Product", "Birds", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Toys", "A vibrant and engaging toy for birds, encouraging physical activity and mental stimulation.", 19.989999999999998, 29.989999999999998, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955686/xaiur3dmdjsvwsngnyii.jpg", "Small", "Colorful Bird Toy", "Bird Toy", 0.10000000000000001, "Playtime", 2 },
                    { 13, "Product", "Cats", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Accessories", "A soft and comfortable bed for cats, providing a warm and secure place to rest.", 49.990000000000002, 59.990000000000002, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956435/o0uzedcounew68oukbu7.jpg", "Large", "Cozy Cat Bed", "Cat Bed", 2.0, "Comfort", 3 },
                    { 14, "Product", "Hamsters", new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Food", "A balanced mix of seeds and grains for hamsters, ensuring they get all essential nutrients.", 14.99, 19.989999999999998, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741957787/fettuiqxovj57cmi0ppu.webp", "Small", "Nutritious Hamster Food", "Hamster Food", 0.5, "Daily Nutrition", 4 },
                    { 15, "Product", "Fish", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Toys", "A realistic plant decoration for aquariums, providing a natural and engaging environment for fish.", 9.9900000000000002, 14.99, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955043/rcs8vtdc8urroayazj0w.webp", "Small", "Aquarium Plant Decoration", "Fish Toy", 0.050000000000000003, "Decoration", 5 },
                    { 16, "Product", "Dogs", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Accessories", "A strong and durable leash for dogs, perfect for daily walks and outdoor activities.", 24.989999999999998, 29.989999999999998, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741954049/tezqcas06et9honx9y86.jpg", "Medium", "Durable Dog Leash", "Dog Leash", 0.29999999999999999, "Walking", 1 },
                    { 17, "Product", "Birds", new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Food", "A premium blend of organic seeds and grains for birds, promoting overall health and vitality.", 39.990000000000002, 49.990000000000002, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955725/nfzdycfvxveqfrvchj3z.webp", "Small", "Organic Bird Food", "Bird Food", 0.5, "Daily Nutrition", 2 },
                    { 18, "Product", "Cats", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Toys", "A fun and engaging catnip mouse toy for cats, encouraging play and exercise.", 9.9900000000000002, 14.99, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956472/ykvgrdxzmfaafbaoilue.avif", "Small", "Catnip Mouse Toy", "Cat Toy", 0.10000000000000001, "Playtime", 3 },
                    { 19, "Product", "Birds", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Accessories", "A large and spacious bird cage, providing a comfortable and secure home for birds.", 99.989999999999995, 129.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741957870/n9e5bx66dikdf5fyfxcq.jpg", "Large", "Spacious Bird Cage", "Bird Cage", 5.0, "Housing", 4 },
                    { 20, "Product", "Fish", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Food", "A high-quality flake food for tropical fish, promoting vibrant colors and overall health.", 19.989999999999998, 24.989999999999998, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741954880/srawajwhg2hvdzfjonhb.jpg", "Small", "Premium Fish Food", "Fish Food", 0.20000000000000001, "Daily Nutrition", 5 },
                    { 21, "Product", "Dogs", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Toys", "A fun and durable squeaky toy for dogs, perfect for playtime and keeping them entertained.", 14.99, 19.989999999999998, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741953866/psz0doiximrgborkzpw7.jpg", "Large", "Squeaky Dog Toy", "Dog Toy", 0.5, "Playtime", 1 },
                    { 22, "Product", "Cats", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Accessories", "A sturdy and durable scratching post for cats, helping to keep their claws healthy and sharp.", 39.990000000000002, 49.990000000000002, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955790/qjlot9jgusogh3ojvouf.webp", "Medium", "Cat Scratching Post", "Cat Scratching Post", 3.0, "Scratching", 2 },
                    { 23, "Product", "Dogs", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Food", "A nutritious and grain-free dog food, perfect for dogs with sensitive stomachs.", 59.990000000000002, 69.989999999999995, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956514/rguwh1ryedofnanavonv.png", "Large", "Grain-Free Dog Food", "Dog Food", 2.0, "Daily Nutrition", 3 },
                    { 24, "Product", "Birds", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Toys", "A colorful and engaging hanging toy for birds, encouraging physical activity and mental stimulation.", 14.99, 19.989999999999998, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741957904/xfihpgurbllxxt0lekns.webp", "Small", "Hanging Bird Toy", "Bird Toy", 0.10000000000000001, "Playtime", 4 },
                    { 25, "Product", "Dogs", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Accessories", "A comfortable and supportive orthopedic bed for dogs, providing a restful and relaxing sleep.", 79.989999999999995, 99.989999999999995, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956554/s7h2ba0rbo3ucft7kyby.jpg", "Large", "Orthopedic Dog Bed", "Dog Bed", 4.0, "Comfort", 5 },
                    { 26, "Product", "Cats", new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Food", "A nutritious and grain-free cat food, perfect for cats with sensitive stomachs.", 49.990000000000002, 59.990000000000002, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741954134/iluy4dlkwdx3mkynui9k.jpg", "Medium", "Grain-Free Cat Food", "Cat Food", 1.5, "Daily Nutrition", 1 },
                    { 27, "Product", "Fish", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Toys", "A realistic shipwreck decoration for aquariums, providing a fun and engaging environment for fish.", 19.989999999999998, 24.989999999999998, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955891/tird6slrw64hjeogskki.jpg", "Small", "Aquarium Shipwreck Decoration", "Fish Toy", 0.050000000000000003, "Decoration", 2 },
                    { 28, "Product", "Birds", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Accessories", "A natural and comfortable perch for birds, providing a secure place to rest and play.", 14.99, 19.989999999999998, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956554/s7h2ba0rbo3ucft7kyby.jpg", "Medium", "Natural Bird Perch", "Bird Perch", 0.5, "Resting", 3 },
                    { 29, "Product", "Hamsters", new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Food", "A premium blend of organic seeds and grains for hamsters, promoting overall health and vitality.", 19.989999999999998, 24.989999999999998, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741957961/sodo2bm6sbox45mpr5w1.webp", "Small", "Organic Hamster Food", "Hamster Food", 0.5, "Daily Nutrition", 4 },
                    { 30, "Product", "Dogs", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Toys", "A durable rope tug toy for dogs, perfect for interactive play and keeping them entertained.", 9.9900000000000002, 14.99, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741953866/psz0doiximrgborkzpw7.jpg", "Large", "Rope Tug Toy", "Dog Toy", 0.5, "Playtime", 5 },
                    { 101, "Product", "Cats", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Housing", "SNOW PERS: Where Persian cats find warmth and love", 39.990000000000002, 59.990000000000002, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1743240140/losj6asybcmbi22urkmz.jpg", "Small", "SNOW PERS Cats shelte", "Litter Boxes", 3.0, "Shelter", 5 },
                    { 102, "Product", "Small Animals", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Other", "Ensure your pet's safety and comfort on every journey with our premium Pets Seat. Designed for small dogs and cats, this seat elevates your pet, giving them a clear view of the road while keeping them securely restrained. Features include a soft, plush interior, adjustable straps for secure attachment to your car seat, and durable, easy-to-clean materials", 79.989999999999995, 99.989999999999995, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742192894/fzdr5qq81ugmmeckjghw.jpg", "Extra Large", "Pets Seat", "Other", 6.0, "Comfort", 6 },
                    { 103, "Product", "Dogs", new DateTime(2028, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Health", "Vaccinations are a crucial part of preventative care for dogs. They stimulate the immune system to protect against potentially life-threatening diseases such as rabies, distemper, parvovirus, and others. Consult your veterinarian to determine the appropriate vaccination schedule for your dog .", 34.990000000000002, 39.990000000000002, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1743241554/vhs6cteezhygcbznmk1m.webp", "Medium", "Dogs Vaccine", "Vaccines", 1.3, "Recovery", 5 },
                    { 104, "Product", "Horses", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Accessories", "Horse Gears fit to all horses types.", 39.990000000000002, 44.990000000000002, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742429525/xrkg6frlfmlkanj8nck2.jpg", "Large", "Horse Gears", "Carriers", 2.0, "Handling", 7 },
                    { 105, "Product", "Horses", new DateTime(2028, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Food", "Elevate your horse’s health and performance with these premium Horse Supplements, specially formulated to support the vitality of your equine companion. Crafted from high-quality, natural ingredients, this blend is designed to enhance strength, stamina, and overall well-being. Whether your horse is a spirited Arabian racer or a gentle Quarter Horse, these supplements provide essential vitamins, minerals, and nutrients to promote strong bones, a glossy coat, and optimal muscle development.", 119.98999999999999, 139.99000000000001, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742433963/vlsptmakxfbzytuzb37n.webp", "Extra Large", "Horse Suppliments", "Supplements", 5.0, "Daily Nutrition", 8 },
                    { 106, "Product", "Cats", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Housing", "Safe, comfy, and convenient. Your pet's ideal travel companion", 19.989999999999998, 24.989999999999998, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742193491/ujynvt9m3lmhmqmx30ag.jpg", "Medium", "Pets Rest Seat", "Beds", 1.0, "Resting", 9 },
                    { 107, "Product", "Cats", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Housing", "A sturdy and durable scratching post for cats, helping to keep their claws healthy and sharp.", 39.990000000000002, 49.990000000000002, "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955790/qjlot9jgusogh3ojvouf.webp", "Medium", "Cat House Play", "Kennels", 2.0, "Climbing", 5 }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "Content", "CreatedAt", "ReportedAnimalId", "ReportedProductId", "ReportedUserId", "ReporterId", "ResolutionNotes", "ResolvedAt", "Status", "TargetType" },
                values: new object[] { 1, "Inappropriate behavior.", new DateTime(2025, 6, 4, 20, 6, 23, 3, DateTimeKind.Utc).AddTicks(6130), null, null, 2, 1, null, null, 0, 0 });

            migrationBuilder.InsertData(
                table: "AnimalReviews",
                columns: new[] { "AnimalReviewId", "AnimalId", "Content", "ReviewDate", "ReviewerId" },
                values: new object[,]
                {
                    { 1, 1, "Great pet!", new DateTime(2025, 6, 3, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6930), 2 },
                    { 2, 2, "Very playful.", new DateTime(2025, 6, 2, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6930), 3 },
                    { 3, 3, "Beautiful singing!", new DateTime(2025, 6, 1, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6940), 1 },
                    { 4, 1, "Very friendly dog!", new DateTime(2025, 5, 31, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6940), 8 },
                    { 5, 1, "Great pet!", new DateTime(2025, 6, 3, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6940), 5 },
                    { 6, 2, "Very playful.", new DateTime(2025, 6, 2, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6950), 5 },
                    { 7, 8, "Beautiful singing!", new DateTime(2025, 6, 1, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6950), 1 },
                    { 8, 6, "Very friendly dog!", new DateTime(2025, 5, 31, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6950), 3 },
                    { 9, 8, "Great pet!", new DateTime(2025, 6, 3, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6950), 5 },
                    { 10, 6, "Very playful.", new DateTime(2025, 6, 2, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6960), 2 },
                    { 11, 3, "Beautiful singing!", new DateTime(2025, 6, 1, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6960), 5 },
                    { 12, 9, "Very friendly dog!", new DateTime(2025, 5, 31, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6960), 7 }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "CartItemId", "CartId", "ItemId", "ItemType", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, "Animal", 1 },
                    { 2, 1, 2, "Product", 2 },
                    { 3, 2, 3, "Animal", 1 },
                    { 4, 3, 4, "Product", 3 },
                    { 5, 4, 5, "Animal", 1 },
                    { 6, 5, 6, "Product", 1 },
                    { 7, 6, 7, "Animal", 2 },
                    { 8, 7, 8, "Product", 3 },
                    { 9, 8, 9, "Animal", 1 },
                    { 10, 9, 10, "Product", 2 }
                });

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "FavoriteId", "AnimalId", "ItemId", "ProductId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, null, null, 1 },
                    { 2, 2, null, null, 1 },
                    { 3, null, null, 3, 2 },
                    { 4, null, null, 4, 2 },
                    { 5, 5, null, null, 3 },
                    { 6, 6, null, null, 3 },
                    { 7, null, null, 7, 4 },
                    { 8, null, null, 8, 4 },
                    { 9, 9, null, null, 5 },
                    { 10, null, null, 10, 5 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "ItemId", "OrderId", "OwnerId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1 },
                    { 2, 1, 1, 1, 1 },
                    { 3, 1, 2, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductReviews",
                columns: new[] { "ProductReviewId", "Content", "ProductId", "ReviewDate", "ReviewerId" },
                values: new object[,]
                {
                    { 1, "Great product! My dog loves it.", 1, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6600), 1 },
                    { 2, "Good value for the price.", 1, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6630), 2 },
                    { 3, "Excellent quality. Highly recommend.", 2, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6640), 3 },
                    { 4, "My cat is obsessed with this toy!", 3, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6640), 4 },
                    { 5, "Keeps my bird entertained for hours.", 5, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6640), 5 },
                    { 6, "This collar is so stylish and well-made.", 6, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6640), 1 },
                    { 7, "Best litter I've ever used. Controls odor perfectly.", 7, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6640), 2 },
                    { 8, "Affordable and effective.", 1, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6650), 3 },
                    { 9, "A must-have for cat owners.", 7, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6650), 4 },
                    { 10, "Highly recommend this brand.", 2, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6650), 5 },
                    { 11, "My hamster loves this bedding!", 8, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6650), 1 },
                    { 12, "Great for small dogs, very durable.", 9, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6650), 2 },
                    { 13, "Excellent for training puppies.", 10, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6660), 3 },
                    { 14, "My rabbit enjoys chewing on these sticks.", 11, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6660), 4 },
                    { 15, "The fish food is top-notch, my fish are thriving.", 12, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6660), 5 },
                    { 16, "This leash is very strong and comfortable.", 13, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6660), 6 },
                    { 17, "The catnip spray is a big hit with my cats.", 14, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6660), 7 },
                    { 18, "These treats are healthy and delicious.", 15, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6660), 8 },
                    { 19, "Perfect for my guinea pig's cage.", 16, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6670), 9 },
                    { 20, "Keeps my aquarium clean and clear.", 17, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6670), 6 },
                    { 21, "My dog sleeps so well on this bed.", 18, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6670), 3 },
                    { 22, "Easy to use and effective flea treatment.", 19, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6670), 6 },
                    { 23, "The birdseed mix is a great value.", 20, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6670), 5 },
                    { 24, "My kitten loves this scratching post.", 21, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6680), 1 },
                    { 25, "This vitamin supplement has improved my pet's health.", 22, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6680), 2 },
                    { 26, "Great for travel, very convenient.", 23, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6690), 3 },
                    { 27, "My reptile enjoys basking under this lamp.", 24, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6700), 4 },
                    { 28, "The dog shampoo smells amazing.", 25, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6700), 5 },
                    { 29, "These chew toys are perfect for aggressive chewers.", 26, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6700), 6 },
                    { 30, "My bird loves playing with this mirror.", 27, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6700), 7 },
                    { 31, "Excellent quality food, my dog is very happy.", 28, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6700), 2 },
                    { 32, "This carrier is sturdy and comfortable.", 29, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6710), 4 },
                    { 33, "The water fountain is a great addition to my cat's setup.", 30, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6710), 3 },
                    { 34, "These training pads are very absorbent.", 1, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6710), 4 },
                    { 35, "My hamster loves running in this wheel.", 2, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6710), 6 },
                    { 36, "This harness is very easy to put on.", 3, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6710), 5 },
                    { 37, "The cat grass is a great natural treat.", 4, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6710), 1 },
                    { 38, "These dental chews have improved my dog's breath.", 5, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6720), 2 },
                    { 39, "My guinea pig loves hiding in this tunnel.", 6, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6720), 3 },
                    { 40, "The aquarium decorations are very realistic.", 7, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6720), 4 },
                    { 41, "This bird cage is spacious and easy to clean.", 8, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6720), 5 },
                    { 42, "My dog loves playing fetch with this frisbee.", 9, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6720), 6 },
                    { 43, "The cat tree is sturdy and provides plenty of scratching posts.", 10, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6730), 7 },
                    { 44, "This food bowl is perfect for my messy eater.", 11, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6730), 8 },
                    { 45, "The grooming brush is gentle and effective.", 12, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6730), 5 },
                    { 46, "My pet loves the taste of this toothpaste.", 13, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6730), 3 },
                    { 47, "This tick and flea collar is a lifesaver.", 14, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6740), 4 },
                    { 48, "The travel carrier is lightweight and easy to carry.", 15, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6740), 10 },
                    { 49, "This playpen is perfect for keeping my puppy contained.", 16, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6750), 5 },
                    { 50, "The aquarium filter is quiet and efficient.", 17, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6750), 1 },
                    { 51, "My cat loves lounging in this hammock.", 18, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6750), 2 },
                    { 52, "This dog bed is super comfy and easy to wash.", 19, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6750), 3 },
                    { 53, "The bird perch is a great addition to my bird's cage.", 20, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6750), 4 },
                    { 54, "This cat toy is interactive and keeps my cat entertained.", 21, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6760), 5 },
                    { 55, "The dog treats are made with high-quality ingredients.", 22, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6760), 6 },
                    { 56, "This pet carrier is perfect for air travel.", 23, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6760), 7 },
                    { 57, "The reptile tank is well-ventilated and secure.", 24, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6760), 8 },
                    { 58, "This dog coat is warm and waterproof.", 25, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6770), 9 },
                    { 59, "The chew toy is durable and long-lasting.", 26, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6770), 4 },
                    { 60, "This bird swing provides hours of fun for my feathered friend.", 27, new DateTime(2025, 6, 4, 23, 6, 23, 3, DateTimeKind.Local).AddTicks(6770), 10 }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "Content", "CreatedAt", "ReportedAnimalId", "ReportedProductId", "ReportedUserId", "ReporterId", "ResolutionNotes", "ResolvedAt", "Status", "TargetType" },
                values: new object[,]
                {
                    { 2, "Animal listing seems suspicious.", new DateTime(2025, 6, 4, 20, 6, 23, 3, DateTimeKind.Utc).AddTicks(6130), 2, null, null, 2, null, null, 1, 1 },
                    { 3, "Product description is misleading.", new DateTime(2025, 6, 4, 20, 6, 23, 3, DateTimeKind.Utc).AddTicks(6140), null, 1, null, 1, "Issue addressed.", new DateTime(2025, 6, 4, 20, 6, 23, 3, DateTimeKind.Utc).AddTicks(6140), 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalReviews_AnimalId",
                table: "AnimalReviews",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalReviews_ReviewerId",
                table: "AnimalReviews",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_userId",
                table: "Animals",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_AnimalId",
                table: "Favorites",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ProductId",
                table: "Favorites",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ReviewerId",
                table: "ProductReviews",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_userId",
                table: "Products",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportedAnimalId",
                table: "Reports",
                column: "ReportedAnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportedProductId",
                table: "Reports",
                column: "ReportedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportedUserId",
                table: "Reports",
                column: "ReportedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReporterId",
                table: "Reports",
                column: "ReporterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalReviews");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
