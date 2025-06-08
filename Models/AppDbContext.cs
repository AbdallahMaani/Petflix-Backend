using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullPetflix.AnimalFiles;
using FullPetflix.AnimalReviewFiles;
using FullPetflix.UserFiles;
using Microsoft.EntityFrameworkCore;
using FullPetflix.FavoritesFiles;
using FullPetflix.FeedbackFiles;
using FullPetflix.OrderFiles;
using FullPetflix.ProductFiles;
using FullPetflix.ProductReviewFiles;
using static System.Net.WebRequestMethods;
using FullPetflix.ReportFiles;

namespace FullPetflix.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AnimalReview> AnimalReviews { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Report> Reports { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Animal>()
                 .HasOne(a => a.User)
                 .WithMany(u => u.Animals)
                 .HasForeignKey(a => a.userId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Animal>()
                .Property(a => a.ItemType)
                .IsRequired()
                .HasMaxLength(10)
                .HasDefaultValue("Animal");

            modelBuilder.Entity<Product>()
                .HasOne(p => p.User)
                .WithMany(u => u.Products)
                .HasForeignKey(p => p.userId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Product>()
                .Property(p => p.ItemType)
                .IsRequired()
                .HasMaxLength(10)
                .HasDefaultValue("Product");

            modelBuilder.Entity<ProductReview>()
                .HasOne(pr => pr.Reviewer)
                .WithMany()
                .HasForeignKey(pr => pr.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevents multiple cascade paths

            modelBuilder.Entity<ProductReview>()
                .HasOne(pr => pr.Product)
                .WithMany()
                .HasForeignKey(pr => pr.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Favorite>()
                 .HasOne(f => f.User)
                 .WithMany()
                 .HasForeignKey(f => f.UserId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Animal)
                .WithMany()
                .HasForeignKey(f => f.AnimalId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Product)
                .WithMany()
                .HasForeignKey(f => f.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CartItem>()
                .Property(ci => ci.ItemType)
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AnimalReview>()
                .HasOne(ar => ar.Reviewer)
                .WithMany()
                .HasForeignKey(ar => ar.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevents multiple cascade paths

            modelBuilder.Entity<AnimalReview>()
                .HasOne(ar => ar.Animal)
                .WithMany()
                .HasForeignKey(ar => ar.AnimalId)
                .OnDelete(DeleteBehavior.Cascade); // Deleting an Animal deletes its reviews

            // When a User is deleted, delete their Orders (and OrderItems via cascade)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade from User to Order

            // When an Order is deleted, delete its OrderItems
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade); // Cascad

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Reporter)
                .WithMany()
                .HasForeignKey(r => r.ReporterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.ReportedUser)
                .WithMany()
                .HasForeignKey(r => r.ReportedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.ReportedAnimal)
                .WithMany()
                .HasForeignKey(r => r.ReportedAnimalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.ReportedProduct)
                .WithMany()
                .HasForeignKey(r => r.ReportedProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Report>().HasData
       (
        new Report
        {
            ReportId = 1,
            ReporterId = 1,
            TargetType = ReportTargetType.User,
            ReportedUserId = 2,
            Content = "Inappropriate behavior.",
            Status = ReportStatus.Pending,
            CreatedAt = DateTime.UtcNow
        },
        new Report
        {
            ReportId = 2,
            ReporterId = 2,
            TargetType = ReportTargetType.Animal,
            ReportedAnimalId = 2,
            Content = "Animal listing seems suspicious.",
            Status = ReportStatus.UnderReview,
            CreatedAt = DateTime.UtcNow
        },
        new Report
        {
            ReportId = 3,
            ReporterId = 1,
            TargetType = ReportTargetType.Product,
            ReportedProductId = 1,
            Content = "Product description is misleading.",
            Status = ReportStatus.Resolved,
            CreatedAt = DateTime.UtcNow,
            ResolvedAt = DateTime.UtcNow,
            ResolutionNotes = "Issue addressed."
        }
    );


            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    userId = 1,
                    username = "AM_2K",
                    name = "Abdallah Maani",
                    email = "maani.2K@icloud.com",
                    password = "password123",
                    location = "Amman, Jordan",
                    gender = Gender.Male,
                    phone = "079-123-4567",
                    birthDay = new DateTime(2001, 5, 31, 0, 0, 0, DateTimeKind.Utc),
                    ProfilePic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1744125357/culuq3puy5ctzaaocvrm.jpg",
                    availableDays = "Wednesday to Friday",
                    availableHours = "9:00 AM - 5:00 PM",
                    delivery_method = "Available",
                    rating = 4.5,
                    bio = "Tech enthusiast and animal lover."
                },
                new Users
                {
                    userId = 2,
                    username = "Sal_1999",
                    name = "Salma Fayez",
                    email = "Salma.fayez@example.com",
                    password = "Pass!45",
                    location = "Irbid, Jordan",
                    gender = Gender.Female,
                    phone = "079-765-4321",
                    birthDay = new DateTime(2002, 7, 21, 0, 0, 0, DateTimeKind.Utc),
                    ProfilePic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742365135/saq6ydbxvxgclzernde3.webp",
                    availableDays = "Tuesday,Thursday",
                    availableHours = "10:00 AM - 4:00 PM",
                    delivery_method = "NotAvailable",
                    rating = 4.2,
                    bio = "Passionate about animal welfare and education."
                },
                new Users
                {
                    userId = 3,
                    username = "osama",
                    name = "Ali Hassan",
                    email = "ali.hassan@example.com",
                    password = "alihassanPWD!2021",
                    location = "Amman, Jordan",
                    gender = Gender.Male,
                    phone = "079-234-5678",
                    birthDay = new DateTime(2001, 9, 11, 0, 0, 0, DateTimeKind.Utc),
                    ProfilePic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742364836/lyumxwdia6brmfstqf4i.jpg",
                    availableDays = "Weekends",
                    availableHours = "8:00 AM - 4:00 PM",
                    delivery_method = "NotAvailable",
                    rating = 3.8,
                    bio = "Dedicated to providing quality pet care."
                },
                new Users
                {
                    userId = 4,
                    username = "Crhis_2002",
                    name = "Chris Khalil",
                    email = "Chris.khalil@example.com",
                    password = "Chrispassword#99",
                    location = "Aqaba, Jordan",
                    gender = Gender.Female,
                    phone = "079-345-6789",
                    birthDay = new DateTime(2001, 10, 7, 0, 0, 0, DateTimeKind.Utc),
                    ProfilePic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742364814/uwhvxn1p12i5atamhwur.webp",
                    availableDays = "Monday to Friday",
                    availableHours = "9:00 AM - 3:00 PM",
                    delivery_method = "Available",
                    rating = 4.7,
                    bio = "Experienced in pet training and behavior."
                },
                new Users
                {
                    userId = 5,
                    username = "AM_2K",
                    name = " Abdallah Maani",
                    email = "maani.2K@icloud.com",
                    password = "1234",
                    location = "Amman , Jordan",
                    gender = Gender.Male,
                    phone = "079-456-7890",
                    birthDay = new DateTime(2001, 5, 31, 0, 0, 0, DateTimeKind.Utc),
                    ProfilePic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1743140298/igahl03oejwajrxyz7hv.jpg",
                    availableDays = "Saturday , Sunday",
                    availableHours = "10:00 AM - 6:00 PM",
                    delivery_method = "Available",
                    rating = 4.1,
                    bio = "Loves all animals and enjoys sharing pet care tips."
                },
                new Users
                {
                    userId = 6,
                    username = "Z_2004",
                    name = "Zain Ahmad",
                    email = "zain.najjar@example.com",
                    password = "ZainPass34",
                    location = "Salt, Jordan",
                    gender = Gender.Female,
                    phone = "079-567-8901",
                    birthDay = new DateTime(2004, 1, 31, 0, 0, 0, DateTimeKind.Utc),
                    ProfilePic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742404864/ywyg8nzb9guul4clzhru.jpg",
                    availableDays = "Monday,Thursday",
                    availableHours = "12:00 PM - 5:00 PM",
                    delivery_method = "Available",
                    rating = 4.3,
                    bio = "Specializes in small animal care and grooming."
                },
                new Users
                {
                    userId = 7,
                    username = "Layla_2000",
                    name = "Layla Ali",
                    email = "layla.ali@example.com",
                    password = "LaylaPass123",
                    location = "Amman, Jordan",
                    gender = Gender.Female,
                    phone = "079-876-5432",
                    birthDay = new DateTime(2000, 3, 15, 0, 0, 0, DateTimeKind.Utc),
                    ProfilePic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742365334/hetngy5mzxd12vqzjyqw.webp",
                    availableDays = "Sunday to Thursday",
                    availableHours = "11:00 AM - 5:00 PM",
                    delivery_method = "NotAvailable",
                    rating = 4.6,
                    bio = "Provides expert advice on pet nutrition and health."
                },
                new Users
                {
                    userId = 8,
                    username = "Omar_2003",
                    name = "Omar Khalid",
                    email = "omar.khalid@example.com",
                    password = "OmarPassword456",
                    location = "Irbid, Jordan",
                    gender = Gender.Male,
                    phone = "079-987-6543",
                    birthDay = new DateTime(2003, 6, 8, 0, 0, 0, DateTimeKind.Utc),
                    ProfilePic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742428909/fpywvqyzvdnyoi0nkd70.avif",
                    availableDays = "Monday to Wednesday",
                    availableHours = "9:00 AM - 2:00 PM",
                    delivery_method = "NotAvailable",
                    rating = 4.0,
                    bio = "Focuses on creating a safe and loving environment for pets."
                },
                new Users
                {
                    userId = 9,
                    username = "Noura_1998",
                    name = "Noura Saleh",
                    email = "noura.saleh@example.com",
                    password = "NouraPass789",
                    location = "Aqaba, Jordan",
                    gender = Gender.Female,
                    phone = "079-654-3210",
                    birthDay = new DateTime(1998, 11, 22, 0, 0, 0, DateTimeKind.Utc),
                    ProfilePic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742365404/ftcdgfvefklibxtha5zj.webp",
                    availableDays = "Tuesday to Saturday",
                    availableHours = "10:00 AM - 6:00 PM",
                    delivery_method = "Available",
                    rating = 4.8,
                    bio = "Offers personalized pet care solutions and advice."
                },
                new Users
                {
                    userId = 10,
                    username = "Tamer_2001",
                    name = "Tamer Hussein",
                    email = "tamer.hussein@example.com",
                    password = "TamerPassword012",
                    location = "Salt, Jordan",
                    gender = Gender.Male,
                    phone = "079-543-2109",
                    birthDay = new DateTime(2001, 2, 5, 0, 0, 0, DateTimeKind.Utc),
                    ProfilePic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742433587/ixsid8hb8nqrscf2dgqk.avif",
                    availableDays = "Wednesday to Sunday",
                    availableHours = "12:00 PM - 7:00 PM",
                    delivery_method = "Available",
                    rating = 4.4,
                    bio = "Committed to providing exceptional pet care services."
                }
            );


            modelBuilder.Entity<Animal>().HasData
            (
                new Animal { animal_id = 1, animal_category = "Cat", animal_type = "Persian", gender = Gender.Male, age = "3 Years", vaccineStatus = "Fully Vaccinated", animal_weight = 6.0, animal_size = "Medium", health_status = "Healthy, Friendly, Calm", userId = 1, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741952757/qe3qj6cgybbix0h0p3o3.jpg", animal_title = "Fluffy Persian Cat", animal_description = "A beautiful and friendly Persian cat that loves to play and cuddle.", animal_new_price = 499.99, animal_old_price = 599.99, ItemType = "Animal" },
                new Animal { animal_id = 2, animal_category = "Dog", animal_type = "Golden Retriever", gender = Gender.Female, age = "5 Years", vaccineStatus = "Fully Vaccinated", animal_weight = 25.0, animal_size = "Large", health_status = "Healthy", userId = 2, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955302/gietcv07pxpfuy2gxq44.webp", animal_title = "Loyal Golden Retriever", animal_description = "A friendly and loyal Golden Retriever that is great with kids.", animal_new_price = 799.99, animal_old_price = 849.99, ItemType = "Animal" },
                new Animal { animal_id = 3, animal_category = "Cat", animal_type = "Siamese", gender = Gender.Female, age = "2 Years", vaccineStatus = "Partly Vaccinated", animal_weight = 4.0, animal_size = "Small", health_status = "Playful", userId = 3, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956003/slgcqoblljdnzfqkmlto.avif", animal_title = "Mischievous Siamese Cat", animal_description = "A playful and curious Siamese cat that loves to explore.", animal_new_price = 99.99, animal_old_price = 129.99, ItemType = "Animal" },
                new Animal { animal_id = 4, animal_category = "Dog", animal_type = "Labrador", gender = Gender.Male, age = "4 Years", vaccineStatus = "Fully Vaccinated", animal_weight = 30.0, animal_size = "Large", health_status = "Energetic", userId = 4, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956927/gvazuhos6kncohv4inip.webp", animal_title = "Friendly Labrador Retriever", animal_description = "An energetic and friendly Labrador Retriever that enjoys outdoor activities.", animal_new_price = 499.99, animal_old_price = 599.99, ItemType = "Animal" },
                new Animal { animal_id = 5, animal_category = "Bird", animal_type = "Parrot", gender = Gender.Male, age = "1 Year", vaccineStatus = "Not Vaccinated", animal_weight = 0.5, animal_size = "Small", health_status = "Talkative", userId = 5, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742124177/lruyr2blmiw5yomciqji.jpg", animal_title = "Colorful Talking Parrot", animal_description = "A beautiful and talkative parrot that can mimic sounds and words.", animal_new_price = 699.99, animal_old_price = 749.99, ItemType = "Animal" },
                new Animal { animal_id = 6, animal_category = "Cat", animal_type = "Ragdoll", gender = Gender.Female, age = "2 Years", vaccineStatus = "Fully Vaccinated", animal_weight = 5.0, animal_size = "Medium", health_status = "Affectionate", userId = 3, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956039/kqknbvhfhnyv35spgcm5.jpg", animal_title = "Cuddly Ragdoll Cat", animal_description = "An affectionate and gentle Ragdoll cat that loves to be held.", animal_new_price = 519.99, animal_old_price = 619.99, ItemType = "Animal" },
                new Animal { animal_id = 7, animal_category = "Dog", animal_type = "Poodle", gender = Gender.Male, age = "1 Year", vaccineStatus = "Partly Vaccinated", animal_weight = 7.0, animal_size = "Medium", health_status = "Intelligent", userId = 1, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741953374/jiedrkghartrj6cfhpqq.jpg", animal_title = "Intelligent Poodle", animal_description = "A highly intelligent and playful Poodle that is easy to train.", animal_new_price = 549.99, animal_old_price = 649.99, ItemType = "Animal" },
                new Animal { animal_id = 8, animal_category = "Bird", animal_type = "Canary", gender = Gender.Female, age = "3 Years", vaccineStatus = "Not Vaccinated", animal_weight = 0.1, animal_size = "Small", health_status = "Melodic", userId = 2, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955332/uhuci5msnirx5fdmyevi.jpg", animal_title = "Singing Canary", animal_description = "A beautiful singing Canary that fills your home with melodious tunes.", animal_new_price = 249.99, animal_old_price = 299.99, ItemType = "Animal" },
                new Animal { animal_id = 9, animal_category = "Cat", animal_type = "Sphynx", gender = Gender.Male, age = "4 Years", vaccineStatus = "Fully Vaccinated", animal_weight = 4.5, animal_size = "Small", health_status = "Curious", userId = 4, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956996/mdgonngt5v45j025ft8f.avif", animal_title = "Hairless Sphynx Cat", animal_description = "A curious and playful Sphynx cat that loves to explore and interact.", animal_new_price = 599.99, animal_old_price = 699.99, ItemType = "Animal" },
                new Animal { animal_id = 10, animal_category = "Dog", animal_type = "Beagle", gender = Gender.Female, age = "2 Years", vaccineStatus = "Fully Vaccinated", animal_weight = 10.0, animal_size = "Medium", health_status = "Friendly", userId = 5, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742004480/qilnj3oiimxdfiyd3jrm.jpg", animal_title = "Friendly Beagle", animal_description = "A friendly and energetic Beagle that enjoys playing and running.", animal_new_price = 229.99, animal_old_price = 329.99, ItemType = "Animal" },
                new Animal { animal_id = 11, animal_category = "Bird", animal_type = "Cockatiel", gender = Gender.Male, age = "5 Years", vaccineStatus = "Not Vaccinated", animal_weight = 0.2, animal_size = "Small", health_status = "Social", userId = 3, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956176/pl5libtnzlrqcfjm62va.webp", animal_title = "Social Cockatiel", animal_description = "A social and interactive Cockatiel that loves to be around people.", animal_new_price = 179.99, animal_old_price = 279.99, ItemType = "Animal" },
                new Animal { animal_id = 12, animal_category = "Fish", animal_type = "Goldfish", gender = Gender.Female, age = "1 Year", vaccineStatus = "Partly Vaccinated", animal_weight = 0.05, animal_size = "Small", health_status = "Healthy", userId = 1, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741953608/tvmanwh3w9lcigwqdbey.png", animal_title = "Common Goldfish", animal_description = "A classic and easy-to-care-for Goldfish that is perfect for beginners.", animal_new_price = 49.99, animal_old_price = 74.99, ItemType = "Animal" },
                new Animal { animal_id = 13, animal_category = "Bird", animal_type = "Cockatiel", gender = Gender.Male, age = "5 Years", vaccineStatus = "Not Vaccinated", animal_weight = 0.2, animal_size = "Small", health_status = "Social", userId = 3, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956176/pl5libtnzlrqcfjm62va.webp", animal_title = "Social Cockatiel", animal_description = "A social and interactive Cockatiel that loves to be around people.", animal_new_price = 179.99, animal_old_price = 219.99, ItemType = "Animal" },
                new Animal { animal_id = 14, animal_category = "Cat", animal_type = "Maine Coon", gender = Gender.Female, age = "3 Years", vaccineStatus = "Fully Vaccinated", animal_weight = 7.0, animal_size = "Large", health_status = "Gentle", userId = 2, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955402/fhmo848agovyyl66rn8w.jpg", animal_title = "Gentle Maine Coon", animal_description = "A large and affectionate Maine Coon that loves human company.", animal_new_price = 349.99, animal_old_price = 399.99, ItemType = "Animal" },
                new Animal { animal_id = 15, animal_category = "Dog", animal_type = "Bulldog", gender = Gender.Male, age = "4 Years", vaccineStatus = "Fully Vaccinated", animal_weight = 22.0, animal_size = "Medium", health_status = "Loyal", userId = 5, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955447/srnbfvcqr0lhpthvcsk6.jpg", animal_title = "Loyal Bulldog", animal_description = "A strong and loyal Bulldog with a calm temperament.", animal_new_price = 299.99, animal_old_price = 349.99, ItemType = "Animal" },
                new Animal { animal_id = 16, animal_category = "Bird", animal_type = "Lovebird", gender = Gender.Female, age = "2 Years", vaccineStatus = "Not Vaccinated", animal_weight = 0.15, animal_size = "Small", health_status = "Affectionate", userId = 4, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741957073/ur6c85or5un5kgqppvo1.webp", animal_title = "Chirpy Lovebird", animal_description = "A social and affectionate Lovebird that enjoys companionship.", animal_new_price = 99.99, animal_old_price = 149.99, ItemType = "Animal" },
                new Animal { animal_id = 17, animal_category = "Fish", animal_type = "Betta", gender = Gender.Male, age = "1 Year", vaccineStatus = "Not Vaccinated", animal_weight = 0.03, animal_size = "Small", health_status = "Vibrant", userId = 3, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956210/znwlufbwo9njlihhe3zy.webp", animal_title = "Colorful Betta Fish", animal_description = "A vibrant and easy-to-care-for Betta fish.", animal_new_price = 39.99, animal_old_price = 49.99, ItemType = "Animal" },
                new Animal { animal_id = 18, animal_category = "Cat", animal_type = "Bengal", gender = Gender.Male, age = "2 Years", vaccineStatus = "Partly Vaccinated", animal_weight = 6.0, animal_size = "Medium", health_status = "Energetic", userId = 1, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741953637/gcqbsifvmknnkyhhjv0h.jpg", animal_title = "Active Bengal Cat", animal_description = "A playful and energetic Bengal cat with a stunning coat.", animal_new_price = 379.99, animal_old_price = 399.99, ItemType = "Animal" },
                new Animal { animal_id = 19, animal_category = "Dog", animal_type = "Chihuahua", gender = Gender.Female, age = "1 Year", vaccineStatus = "Fully Vaccinated", animal_weight = 3.0, animal_size = "Small", health_status = "Lively", userId = 2, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955447/srnbfvcqr0lhpthvcsk6.jpg", animal_title = "Tiny Chihuahua", animal_description = "A tiny but feisty Chihuahua that is full of personality.", animal_new_price = 199.99, animal_old_price = 249.99, ItemType = "Animal" },
                new Animal { animal_id = 20, animal_category = "Bird", animal_type = "Macaw", gender = Gender.Male, age = "4 Years", vaccineStatus = "Not Vaccinated", animal_weight = 1.2, animal_size = "Large", health_status = "Intelligent", userId = 5, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1743239949/uigcjijmhenamqfmy4l5.jpg", animal_title = "Intelligent Macaw", animal_description = "A smart and social Macaw that loves attention.", animal_new_price = 349.99, animal_old_price = 399.99, ItemType = "Animal" },
                new Animal { animal_id = 21, animal_category = "Fish", animal_type = "Guppy", gender = Gender.Female, age = "1 Year", vaccineStatus = "Not Vaccinated", animal_weight = 0.02, animal_size = "Small", health_status = "Active", userId = 3, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956082/oyddcs2xjbgesbofjys4.jpg", animal_title = "Colorful Guppy", animal_description = "A bright and active Guppy, perfect for small aquariums.", animal_new_price = 29.99, animal_old_price = 39.99, ItemType = "Animal" },
                new Animal { animal_id = 22, animal_category = "Cat", animal_type = "Russian Blue", gender = Gender.Female, age = "3 Years", vaccineStatus = "Fully Vaccinated", animal_weight = 5.5, animal_size = "Medium", health_status = "Calm", userId = 4, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741957183/qervcu7unt6gcpjy2qzq.jpg", animal_title = "Elegant Russian Blue", animal_description = "A sleek and elegant Russian Blue cat with a friendly personality.", animal_new_price = 349.99, animal_old_price = 399.99, ItemType = "Animal" },
                new Animal { animal_id = 23, animal_category = "Dog", animal_type = "Shih Tzu", gender = Gender.Male, age = "2 Years", vaccineStatus = "Partly Vaccinated", animal_weight = 6.0, animal_size = "Small", health_status = "Affectionate", userId = 1, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741953690/yoilxd4lrhdhciv0gsyv.jpg", animal_title = "Fluffy Shih Tzu", animal_description = "A fluffy and affectionate Shih Tzu that loves being pampered.", animal_new_price = 299.99, animal_old_price = 349.99, ItemType = "Animal" },
                new Animal { animal_id = 24, animal_category = "Bird", animal_type = "Finch", gender = Gender.Female, age = "1 Year", vaccineStatus = "Not Vaccinated", animal_weight = 0.1, animal_size = "Small", health_status = "Melodic", userId = 2, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955486/wbs03vsiljzdkcznzihr.jpg", animal_title = "Singing Finch", animal_description = "A sweet-sounding Finch that brings music to any home.", animal_new_price = 49.99, animal_old_price = 69.99, ItemType = "Animal" },
                new Animal { animal_id = 25, animal_category = "Fish", animal_type = "Angelfish", gender = Gender.Male, age = "2 Years", vaccineStatus = "Partly Vaccinated", animal_weight = 0.08, animal_size = "Small", health_status = "Graceful", userId = 5, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741954448/v3ik0d44lxdpjay9incu.avif", animal_title = "Graceful Angelfish", animal_description = "A beautiful Angelfish with elegant fins.", animal_new_price = 69.99, animal_old_price = 89.99, ItemType = "Animal" },
                new Animal { animal_id = 26, animal_category = "Cat", animal_type = "Abyssinian", gender = Gender.Female, age = "2 Years", vaccineStatus = "Fully Vaccinated", animal_weight = 4.5, animal_size = "Medium", health_status = "Curious", userId = 3, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956125/nqutejc4wszwxetwtfc7.webp", animal_title = "Curious Abyssinian", animal_description = "A playful and curious Abyssinian cat that loves to climb.", animal_new_price = 319.99, animal_old_price = 349.99, ItemType = "Animal" },
                new Animal { animal_id = 27, animal_category = "Dog", animal_type = "Dalmatian", gender = Gender.Male, age = "3 Years", vaccineStatus = "Partly Vaccinated", animal_weight = 20.0, animal_size = "Large", health_status = "Energetic", userId = 4, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741957142/sbyy2rpcqnhkfkpuaqsk.jpg", animal_title = "Spotted Dalmatian", animal_description = "A playful and energetic Dalmatian that enjoys running and playing.", animal_new_price = 349.99, animal_old_price = 399.99, ItemType = "Animal" },
                new Animal { animal_id = 28, animal_category = "Bird", animal_type = "Budgie", gender = Gender.Female, age = "1 Year", vaccineStatus = "Not Vaccinated", animal_weight = 0.05, animal_size = "Small", health_status = "Social", userId = 5, animal_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741954517/kkkmpomoy6kzrxwbnt91.avif", animal_title = "Charming Budgie", animal_description = "A friendly and social Budgie that loves to chirp.", animal_new_price = 39.99, animal_old_price = 59.99, ItemType = "Animal" }
            );


            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    product_id = 1,
                    product_category = "Food",
                    product_type = "Dog Food",
                    product_size = "Medium",
                    product_weight = 1.5,
                    expiration = new DateTime(2025, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Daily Nutrition",
                    designedFor = "Dogs",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741953227/zltok0kmocaleqoemuys.jpg",
                    userId = 1,
                    product_title = "Premium Dog Food",
                    product_description = "Complete and balanced nutrition for medium-sized dogs, ensuring they stay healthy and active.",
                    product_new_price = 149.99,
                    product_old_price = 174.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 2,
                    product_category = "Food",
                    product_type = "Cat Food",
                    product_size = "Small",
                    product_weight = 1.2,
                    expiration = new DateTime(2026, 3, 15, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Daily Nutrition",
                    designedFor = "Cats",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741960387/zix6312xkimurxwksjst.avif",
                    userId = 1,
                    product_title = "Delicious Cat Food",
                    product_description = "Irresistible and nutritious food for cats, providing all essential vitamins and minerals.",
                    product_new_price = 119.99,
                    product_old_price = 139.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 3,
                    product_category = "Toys",
                    product_type = "Dog Toy",
                    product_size = "Medium",
                    product_weight = 0.3,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Playtime",
                    designedFor = "Dogs",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955580/b7nmjo982o1dkaqtubku.jpg",
                    userId = 2,
                    product_title = "Durable Dog Toy",
                    product_description = "A tough and durable dog toy that can withstand rough play.",
                    product_new_price = 79.99,
                    product_old_price = 94.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 4,
                    product_category = "Toys",
                    product_type = "Cat Toy",
                    product_size = "Small",
                    product_weight = 0.1,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Playtime",
                    designedFor = "Cats",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956365/gr7q1jkq8xogpqlx9o1o.jpg",
                    userId = 3,
                    product_title = "Interactive Cat Toy - Feather Wand",
                    product_description = "An interactive cat toy with a feather wand that keeps cats entertained.",
                    product_new_price = 49.99,
                    product_old_price = 59.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 5,
                    product_category = "Food",
                    product_type = "Bird Food",
                    product_size = "Small",
                    product_weight = 0.5,
                    expiration = new DateTime(2025, 9, 20, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Daily Nutrition",
                    designedFor = "Birds",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741957685/ibhil7hr2wt0ciy5zcyj.webp",
                    userId = 4,
                    product_title = "Nutritious Bird Food",
                    product_description = "A balanced seed mix for various bird species, ensuring they get all necessary nutrients.",
                    product_new_price = 59.99,
                    product_old_price = 69.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 6,
                    product_category = "Accessories",
                    product_type = "Dog Collar",
                    product_size = "Medium",
                    product_weight = 0.2,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Identification",
                    designedFor = "Dogs",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741954791/kobkb9gw1j2t72b6aatd.webp",
                    userId = 5,
                    product_title = "Stylish Dog Collar",
                    product_description = "A stylish and durable leather dog collar that is both comfortable and secure.",
                    product_new_price = 89.99,
                    product_old_price = 99.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 7,
                    product_category = "Accessories",
                    product_type = "Cat Litter",
                    product_size = "Large",
                    product_weight = 5.0,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Hygiene",
                    designedFor = "Cats",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741954193/yu68n8ma6esrgufvtx33.webp",
                    userId = 1,
                    product_title = "Clumping Cat Litter",
                    product_description = "Clumping cat litter with odor control, making it easy to clean and maintain.",
                    product_new_price = 179.99,
                    product_old_price = 199.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 8,
                    product_category = "Food",
                    product_type = "Fish Food",
                    product_size = "Small",
                    product_weight = 0.2,
                    expiration = new DateTime(2024, 11, 15, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Daily Nutrition",
                    designedFor = "Fish",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955640/uobazeneyfmnq04jfa4l.avif",
                    userId = 2,
                    product_title = "Flake Fish Food",
                    product_description = "A complete and balanced flake food for tropical fish, promoting vibrant colors and health.",
                    product_new_price = 39.99,
                    product_old_price = 49.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 9,
                    product_category = "Toys",
                    product_type = "Fish Toy",
                    product_size = "Small",
                    product_weight = 0.05,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Decoration",
                    designedFor = "Fish",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956401/lgwwur552kzaufiuoxxa.webp",
                    userId = 3,
                    product_title = "Aquarium Castle Decoration",
                    product_description = "A decorative castle for your aquarium, providing a fun and engaging environment for fish.",
                    product_new_price = 69.99,
                    product_old_price = 84.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 10,
                    product_category = "Accessories",
                    product_type = "Fish Tank",
                    product_size = "Medium",
                    product_weight = 10.0,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Housing",
                    designedFor = "Fish",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741957720/xzf1pgalohpwa7azu7pe.jpg",
                    userId = 4,
                    product_title = "20-Gallon Fish Tank",
                    product_description = "A 20-gallon glass fish tank, perfect for creating a beautiful and healthy aquatic environment.",
                    product_new_price = 249.99,
                    product_old_price = 299.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 11,
                    product_category = "Food",
                    product_type = "Rabbit Food",
                    product_size = "Medium",
                    product_weight = 1.0,
                    expiration = new DateTime(2025, 10, 10, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Daily Nutrition",
                    designedFor = "Rabbits",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741954089/monptgbpqqzhorh2gfy6.webp",
                    userId = 1,
                    product_title = "Healthy Rabbit Food",
                    product_description = "A nutritious blend of pellets and hay for rabbits, promoting healthy digestion and growth.",
                    product_new_price = 29.99,
                    product_old_price = 39.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 12,
                    product_category = "Toys",
                    product_type = "Bird Toy",
                    product_size = "Small",
                    product_weight = 0.1,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Playtime",
                    designedFor = "Birds",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955686/xaiur3dmdjsvwsngnyii.jpg",
                    userId = 2,
                    product_title = "Colorful Bird Toy",
                    product_description = "A vibrant and engaging toy for birds, encouraging physical activity and mental stimulation.",
                    product_new_price = 19.99,
                    product_old_price = 29.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 13,
                    product_category = "Accessories",
                    product_type = "Cat Bed",
                    product_size = "Large",
                    product_weight = 2.0,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Comfort",
                    designedFor = "Cats",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956435/o0uzedcounew68oukbu7.jpg",
                    userId = 3,
                    product_title = "Cozy Cat Bed",
                    product_description = "A soft and comfortable bed for cats, providing a warm and secure place to rest.",
                    product_new_price = 49.99,
                    product_old_price = 59.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 14,
                    product_category = "Food",
                    product_type = "Hamster Food",
                    product_size = "Small",
                    product_weight = 0.5,
                    expiration = new DateTime(2025, 8, 20, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Daily Nutrition",
                    designedFor = "Hamsters",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741957787/fettuiqxovj57cmi0ppu.webp",
                    userId = 4,
                    product_title = "Nutritious Hamster Food",
                    product_description = "A balanced mix of seeds and grains for hamsters, ensuring they get all essential nutrients.",
                    product_new_price = 14.99,
                    product_old_price = 19.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 15,
                    product_category = "Toys",
                    product_type = "Fish Toy",
                    product_size = "Small",
                    product_weight = 0.05,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Decoration",
                    designedFor = "Fish",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955043/rcs8vtdc8urroayazj0w.webp",
                    userId = 5,
                    product_title = "Aquarium Plant Decoration",
                    product_description = "A realistic plant decoration for aquariums, providing a natural and engaging environment for fish.",
                    product_new_price = 9.99,
                    product_old_price = 14.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 16,
                    product_category = "Accessories",
                    product_type = "Dog Leash",
                    product_size = "Medium",
                    product_weight = 0.3,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Walking",
                    designedFor = "Dogs",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741954049/tezqcas06et9honx9y86.jpg",
                    userId = 1,
                    product_title = "Durable Dog Leash",
                    product_description = "A strong and durable leash for dogs, perfect for daily walks and outdoor activities.",
                    product_new_price = 24.99,
                    product_old_price = 29.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 17,
                    product_category = "Food",
                    product_type = "Bird Food",
                    product_size = "Small",
                    product_weight = 0.5,
                    expiration = new DateTime(2025, 9, 20, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Daily Nutrition",
                    designedFor = "Birds",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955725/nfzdycfvxveqfrvchj3z.webp",
                    userId = 2,
                    product_title = "Organic Bird Food",
                    product_description = "A premium blend of organic seeds and grains for birds, promoting overall health and vitality.",
                    product_new_price = 39.99,
                    product_old_price = 49.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 18,
                    product_category = "Toys",
                    product_type = "Cat Toy",
                    product_size = "Small",
                    product_weight = 0.1,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Playtime",
                    designedFor = "Cats",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956472/ykvgrdxzmfaafbaoilue.avif",
                    userId = 3,
                    product_title = "Catnip Mouse Toy",
                    product_description = "A fun and engaging catnip mouse toy for cats, encouraging play and exercise.",
                    product_new_price = 9.99,
                    product_old_price = 14.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 19,
                    product_category = "Accessories",
                    product_type = "Bird Cage",
                    product_size = "Large",
                    product_weight = 5.0,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Housing",
                    designedFor = "Birds",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741957870/n9e5bx66dikdf5fyfxcq.jpg",
                    userId = 4,
                    product_title = "Spacious Bird Cage",
                    product_description = "A large and spacious bird cage, providing a comfortable and secure home for birds.",
                    product_new_price = 99.99,
                    product_old_price = 129.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 20,
                    product_category = "Food",
                    product_type = "Fish Food",
                    product_size = "Small",
                    product_weight = 0.2,
                    expiration = new DateTime(2024, 11, 15, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Daily Nutrition",
                    designedFor = "Fish",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741954880/srawajwhg2hvdzfjonhb.jpg",
                    userId = 5,
                    product_title = "Premium Fish Food",
                    product_description = "A high-quality flake food for tropical fish, promoting vibrant colors and overall health.",
                    product_new_price = 19.99,
                    product_old_price = 24.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 21,
                    product_category = "Toys",
                    product_type = "Dog Toy",
                    product_size = "Large",
                    product_weight = 0.5,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Playtime",
                    designedFor = "Dogs",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741953866/psz0doiximrgborkzpw7.jpg",
                    userId = 1,
                    product_title = "Squeaky Dog Toy",
                    product_description = "A fun and durable squeaky toy for dogs, perfect for playtime and keeping them entertained.",
                    product_new_price = 14.99,
                    product_old_price = 19.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 22,
                    product_category = "Accessories",
                    product_type = "Cat Scratching Post",
                    product_size = "Medium",
                    product_weight = 3.0,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Scratching",
                    designedFor = "Cats",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955790/qjlot9jgusogh3ojvouf.webp",
                    userId = 2,
                    product_title = "Cat Scratching Post",
                    product_description = "A sturdy and durable scratching post for cats, helping to keep their claws healthy and sharp.",
                    product_new_price = 39.99,
                    product_old_price = 49.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 23,
                    product_category = "Food",
                    product_type = "Dog Food",
                    product_size = "Large",
                    product_weight = 2.0,
                    expiration = new DateTime(2025, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Daily Nutrition",
                    designedFor = "Dogs",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956514/rguwh1ryedofnanavonv.png",
                    userId = 3,
                    product_title = "Grain-Free Dog Food",
                    product_description = "A nutritious and grain-free dog food, perfect for dogs with sensitive stomachs.",
                    product_new_price = 59.99,
                    product_old_price = 69.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 24,
                    product_category = "Toys",
                    product_type = "Bird Toy",
                    product_size = "Small",
                    product_weight = 0.1,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Playtime",
                    designedFor = "Birds",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741957904/xfihpgurbllxxt0lekns.webp",
                    userId = 4,
                    product_title = "Hanging Bird Toy",
                    product_description = "A colorful and engaging hanging toy for birds, encouraging physical activity and mental stimulation.",
                    product_new_price = 14.99,
                    product_old_price = 19.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 25,
                    product_category = "Accessories",
                    product_type = "Dog Bed",
                    product_size = "Large",
                    product_weight = 4.0,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Comfort",
                    designedFor = "Dogs",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956554/s7h2ba0rbo3ucft7kyby.jpg",
                    userId = 5,
                    product_title = "Orthopedic Dog Bed",
                    product_description = "A comfortable and supportive orthopedic bed for dogs, providing a restful and relaxing sleep.",
                    product_new_price = 79.99,
                    product_old_price = 99.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 26,
                    product_category = "Food",
                    product_type = "Cat Food",
                    product_size = "Medium",
                    product_weight = 1.5,
                    expiration = new DateTime(2026, 3, 15, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Daily Nutrition",
                    designedFor = "Cats",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741954134/iluy4dlkwdx3mkynui9k.jpg",
                    userId = 1,
                    product_title = "Grain-Free Cat Food",
                    product_description = "A nutritious and grain-free cat food, perfect for cats with sensitive stomachs.",
                    product_new_price = 49.99,
                    product_old_price = 59.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 27,
                    product_category = "Toys",
                    product_type = "Fish Toy",
                    product_size = "Small",
                    product_weight = 0.05,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Decoration",
                    designedFor = "Fish",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955891/tird6slrw64hjeogskki.jpg",
                    userId = 2,
                    product_title = "Aquarium Shipwreck Decoration",
                    product_description = "A realistic shipwreck decoration for aquariums, providing a fun and engaging environment for fish.",
                    product_new_price = 19.99,
                    product_old_price = 24.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 28,
                    product_category = "Accessories",
                    product_type = "Bird Perch",
                    product_size = "Medium",
                    product_weight = 0.5,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Resting",
                    designedFor = "Birds",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741956554/s7h2ba0rbo3ucft7kyby.jpg",
                    userId = 3,
                    product_title = "Natural Bird Perch",
                    product_description = "A natural and comfortable perch for birds, providing a secure place to rest and play.",
                    product_new_price = 14.99,
                    product_old_price = 19.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 29,
                    product_category = "Food",
                    product_type = "Hamster Food",
                    product_size = "Small",
                    product_weight = 0.5,
                    expiration = new DateTime(2025, 8, 20, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Daily Nutrition",
                    designedFor = "Hamsters",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741957961/sodo2bm6sbox45mpr5w1.webp",
                    userId = 4,
                    product_title = "Organic Hamster Food",
                    product_description = "A premium blend of organic seeds and grains for hamsters, promoting overall health and vitality.",
                    product_new_price = 19.99,
                    product_old_price = 24.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 30,
                    product_category = "Toys",
                    product_type = "Dog Toy",
                    product_size = "Large",
                    product_weight = 0.5,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Playtime",
                    designedFor = "Dogs",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741953866/psz0doiximrgborkzpw7.jpg",
                    userId = 5,
                    product_title = "Rope Tug Toy",
                    product_description = "A durable rope tug toy for dogs, perfect for interactive play and keeping them entertained.",
                    product_new_price = 9.99,
                    product_old_price = 14.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 101,
                    product_category = "Housing",
                    product_type = "Litter Boxes",
                    product_size = "Small",
                    product_weight = 3,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Shelter",
                    designedFor = "Cats",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1743240140/losj6asybcmbi22urkmz.jpg",
                    userId = 5,
                    product_title = "SNOW PERS Cats shelte",
                    product_description = "SNOW PERS: Where Persian cats find warmth and love",
                    product_new_price = 39.99,
                    product_old_price = 59.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 102,
                    product_category = "Other",
                    product_type = "Other",
                    product_size = "Extra Large",
                    product_weight = 6,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Comfort",
                    designedFor = "Small Animals",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742192894/fzdr5qq81ugmmeckjghw.jpg",
                    userId = 6,
                    product_title = "Pets Seat",
                    product_description = "Ensure your pet's safety and comfort on every journey with our premium Pets Seat. Designed for small dogs and cats, this seat elevates your pet, giving them a clear view of the road while keeping them securely restrained. Features include a soft, plush interior, adjustable straps for secure attachment to your car seat, and durable, easy-to-clean materials",
                    product_new_price = 79.99,
                    product_old_price = 99.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 103,
                    product_category = "Health",
                    product_type = "Vaccines",
                    product_size = "Medium",
                    product_weight = 1.3,
                    expiration = new DateTime(2028, 7, 19, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Recovery",
                    designedFor = "Dogs",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1743241554/vhs6cteezhygcbznmk1m.webp",
                    userId = 5,
                    product_title = "Dogs Vaccine",
                    product_description = "Vaccinations are a crucial part of preventative care for dogs. They stimulate the immune system to protect against potentially life-threatening diseases such as rabies, distemper, parvovirus, and others. Consult your veterinarian to determine the appropriate vaccination schedule for your dog .",
                    product_new_price = 34.99,
                    product_old_price = 39.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 104,
                    product_category = "Accessories",
                    product_type = "Carriers",
                    product_size = "Large",
                    product_weight = 2,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Handling",
                    designedFor = "Horses",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742429525/xrkg6frlfmlkanj8nck2.jpg",
                    userId = 7,
                    product_title = "Horse Gears",
                    product_description = "Horse Gears fit to all horses types.",
                    product_new_price = 39.99,
                    product_old_price = 44.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 105,
                    product_category = "Food",
                    product_type = "Supplements",
                    product_size = "Extra Large",
                    product_weight = 5,
                    expiration = new DateTime(2028, 8, 18, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Daily Nutrition",
                    designedFor = "Horses",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742433963/vlsptmakxfbzytuzb37n.webp",
                    userId = 8,
                    product_title = "Horse Suppliments",
                    product_description = "Elevate your horse’s health and performance with these premium Horse Supplements, specially formulated to support the vitality of your equine companion. Crafted from high-quality, natural ingredients, this blend is designed to enhance strength, stamina, and overall well-being. Whether your horse is a spirited Arabian racer or a gentle Quarter Horse, these supplements provide essential vitamins, minerals, and nutrients to promote strong bones, a glossy coat, and optimal muscle development.",
                    product_new_price = 119.99,
                    product_old_price = 139.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 106,
                    product_category = "Housing",
                    product_type = "Beds",
                    product_size = "Medium",
                    product_weight = 1,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Resting",
                    designedFor = "Cats",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1742193491/ujynvt9m3lmhmqmx30ag.jpg",
                    userId = 9,
                    product_title = "Pets Rest Seat",
                    product_description = "Safe, comfy, and convenient. Your pet's ideal travel companion",
                    product_new_price = 19.99,
                    product_old_price = 24.99,
                    ItemType = "Product"
                },
                new Product
                {
                    product_id = 107,
                    product_category = "Housing",
                    product_type = "Kennels",
                    product_size = "Medium",
                    product_weight = 2,
                    expiration = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    usage = "Climbing",
                    designedFor = "Cats",
                    product_pic = "https://res.cloudinary.com/dhbhh9aln/image/upload/v1741955790/qjlot9jgusogh3ojvouf.webp",
                    userId = 5,
                    product_title = "Cat House Play",
                    product_description = "A sturdy and durable scratching post for cats, helping to keep their claws healthy and sharp.",
                    product_new_price = 39.99,
                    product_old_price = 49.99,
                    ItemType = "Product"
                }
            );


            modelBuilder.Entity<ProductReview>().HasData
            (
                new ProductReview { ProductReviewId = 1, Content = "Great product! My dog loves it.", ReviewerId = 1, ProductId = 1 },
                new ProductReview { ProductReviewId = 2, Content = "Good value for the price.", ReviewerId = 2, ProductId = 1 },
                new ProductReview { ProductReviewId = 3, Content = "Excellent quality. Highly recommend.", ReviewerId = 3, ProductId = 2 },
                new ProductReview { ProductReviewId = 4, Content = "My cat is obsessed with this toy!", ReviewerId = 4, ProductId = 3 },
                new ProductReview { ProductReviewId = 5, Content = "Keeps my bird entertained for hours.", ReviewerId = 5, ProductId = 5 },
                new ProductReview { ProductReviewId = 6, Content = "This collar is so stylish and well-made.", ReviewerId = 1, ProductId = 6 },
                new ProductReview { ProductReviewId = 7, Content = "Best litter I've ever used. Controls odor perfectly.", ReviewerId = 2, ProductId = 7 },
                new ProductReview { ProductReviewId = 8, Content = "Affordable and effective.", ReviewerId = 3, ProductId = 1 }, // Another review for Product 1
                new ProductReview { ProductReviewId = 9, Content = "A must-have for cat owners.", ReviewerId = 4, ProductId = 7 }, // Another review for Product 7
                new ProductReview { ProductReviewId = 10, Content = "Highly recommend this brand.", ReviewerId = 5, ProductId = 2 }, // Another review for Product 2
                new ProductReview { ProductReviewId = 11, Content = "My hamster loves this bedding!", ReviewerId = 1, ProductId = 8 },
                new ProductReview { ProductReviewId = 12, Content = "Great for small dogs, very durable.", ReviewerId = 2, ProductId = 9 },
                new ProductReview { ProductReviewId = 13, Content = "Excellent for training puppies.", ReviewerId = 3, ProductId = 10 },
                new ProductReview { ProductReviewId = 14, Content = "My rabbit enjoys chewing on these sticks.", ReviewerId = 4, ProductId = 11 },
                new ProductReview { ProductReviewId = 15, Content = "The fish food is top-notch, my fish are thriving.", ReviewerId = 5, ProductId = 12 },
                new ProductReview { ProductReviewId = 16, Content = "This leash is very strong and comfortable.", ReviewerId = 6, ProductId = 13 },
                new ProductReview { ProductReviewId = 17, Content = "The catnip spray is a big hit with my cats.", ReviewerId = 7, ProductId = 14 },
                new ProductReview { ProductReviewId = 18, Content = "These treats are healthy and delicious.", ReviewerId = 8, ProductId = 15 },
                new ProductReview { ProductReviewId = 19, Content = "Perfect for my guinea pig's cage.", ReviewerId = 9, ProductId = 16 },
                new ProductReview { ProductReviewId = 20, Content = "Keeps my aquarium clean and clear.", ReviewerId = 6, ProductId = 17 },
                new ProductReview { ProductReviewId = 21, Content = "My dog sleeps so well on this bed.", ReviewerId = 3, ProductId = 18 },
                new ProductReview { ProductReviewId = 22, Content = "Easy to use and effective flea treatment.", ReviewerId = 6, ProductId = 19 },
                new ProductReview { ProductReviewId = 23, Content = "The birdseed mix is a great value.", ReviewerId = 5, ProductId = 20 },
                new ProductReview { ProductReviewId = 24, Content = "My kitten loves this scratching post.", ReviewerId = 1, ProductId = 21 },
                new ProductReview { ProductReviewId = 25, Content = "This vitamin supplement has improved my pet's health.", ReviewerId = 2, ProductId = 22 },
                new ProductReview { ProductReviewId = 26, Content = "Great for travel, very convenient.", ReviewerId = 3, ProductId = 23 },
                new ProductReview { ProductReviewId = 27, Content = "My reptile enjoys basking under this lamp.", ReviewerId = 4, ProductId = 24 },
                new ProductReview { ProductReviewId = 28, Content = "The dog shampoo smells amazing.", ReviewerId = 5, ProductId = 25 },
                new ProductReview { ProductReviewId = 29, Content = "These chew toys are perfect for aggressive chewers.", ReviewerId = 6, ProductId = 26 },
                new ProductReview { ProductReviewId = 30, Content = "My bird loves playing with this mirror.", ReviewerId = 7, ProductId = 27 },
                new ProductReview { ProductReviewId = 31, Content = "Excellent quality food, my dog is very happy.", ReviewerId = 2, ProductId = 28 },
                new ProductReview { ProductReviewId = 32, Content = "This carrier is sturdy and comfortable.", ReviewerId = 4, ProductId = 29 },
                new ProductReview { ProductReviewId = 33, Content = "The water fountain is a great addition to my cat's setup.", ReviewerId = 3, ProductId = 30 },
                new ProductReview { ProductReviewId = 34, Content = "These training pads are very absorbent.", ReviewerId = 4, ProductId = 1 },
                new ProductReview { ProductReviewId = 35, Content = "My hamster loves running in this wheel.", ReviewerId = 6, ProductId = 2 },
                new ProductReview { ProductReviewId = 36, Content = "This harness is very easy to put on.", ReviewerId = 5, ProductId = 3 },
                new ProductReview { ProductReviewId = 37, Content = "The cat grass is a great natural treat.", ReviewerId = 1, ProductId = 4 },
                new ProductReview { ProductReviewId = 38, Content = "These dental chews have improved my dog's breath.", ReviewerId = 2, ProductId = 5 },
                new ProductReview { ProductReviewId = 39, Content = "My guinea pig loves hiding in this tunnel.", ReviewerId = 3, ProductId = 6 },
                new ProductReview { ProductReviewId = 40, Content = "The aquarium decorations are very realistic.", ReviewerId = 4, ProductId = 7 },
                new ProductReview { ProductReviewId = 41, Content = "This bird cage is spacious and easy to clean.", ReviewerId = 5, ProductId = 8 },
                new ProductReview { ProductReviewId = 42, Content = "My dog loves playing fetch with this frisbee.", ReviewerId = 6, ProductId = 9 },
                new ProductReview { ProductReviewId = 43, Content = "The cat tree is sturdy and provides plenty of scratching posts.", ReviewerId = 7, ProductId = 10 },
                new ProductReview { ProductReviewId = 44, Content = "This food bowl is perfect for my messy eater.", ReviewerId = 8, ProductId = 11 },
                new ProductReview { ProductReviewId = 45, Content = "The grooming brush is gentle and effective.", ReviewerId = 5, ProductId = 12 },
                new ProductReview { ProductReviewId = 46, Content = "My pet loves the taste of this toothpaste.", ReviewerId = 3, ProductId = 13 },
                new ProductReview { ProductReviewId = 47, Content = "This tick and flea collar is a lifesaver.", ReviewerId = 4, ProductId = 14 },
                new ProductReview { ProductReviewId = 48, Content = "The travel carrier is lightweight and easy to carry.", ReviewerId = 10, ProductId = 15 },
                new ProductReview { ProductReviewId = 49, Content = "This playpen is perfect for keeping my puppy contained.", ReviewerId = 5, ProductId = 16 },
                new ProductReview { ProductReviewId = 50, Content = "The aquarium filter is quiet and efficient.", ReviewerId = 1, ProductId = 17 },
                new ProductReview { ProductReviewId = 51, Content = "My cat loves lounging in this hammock.", ReviewerId = 2, ProductId = 18 },
                new ProductReview { ProductReviewId = 52, Content = "This dog bed is super comfy and easy to wash.", ReviewerId = 3, ProductId = 19 },
                new ProductReview { ProductReviewId = 53, Content = "The bird perch is a great addition to my bird's cage.", ReviewerId = 4, ProductId = 20 },
                new ProductReview { ProductReviewId = 54, Content = "This cat toy is interactive and keeps my cat entertained.", ReviewerId = 5, ProductId = 21 },
                new ProductReview { ProductReviewId = 55, Content = "The dog treats are made with high-quality ingredients.", ReviewerId = 6, ProductId = 22 },
                new ProductReview { ProductReviewId = 56, Content = "This pet carrier is perfect for air travel.", ReviewerId = 7, ProductId = 23 },
                new ProductReview { ProductReviewId = 57, Content = "The reptile tank is well-ventilated and secure.", ReviewerId = 8, ProductId = 24 },
                new ProductReview { ProductReviewId = 58, Content = "This dog coat is warm and waterproof.", ReviewerId = 9, ProductId = 25 },
                new ProductReview { ProductReviewId = 59, Content = "The chew toy is durable and long-lasting.", ReviewerId = 4, ProductId = 26 },
                new ProductReview { ProductReviewId = 60, Content = "This bird swing provides hours of fun for my feathered friend.", ReviewerId = 10, ProductId = 27 }
            );

            // Seed data (adjust ItemId to match AnimalId or ProductId)
            modelBuilder.Entity<Favorite>().HasData
            (
                new Favorite { FavoriteId = 1, UserId = 1, AnimalId = 1 },
                new Favorite { FavoriteId = 2, UserId = 1, AnimalId = 2 },
                new Favorite { FavoriteId = 3, UserId = 2, ProductId = 3 },
                new Favorite { FavoriteId = 4, UserId = 2, ProductId = 4 },
                new Favorite { FavoriteId = 5, UserId = 3, AnimalId = 5 },
                new Favorite { FavoriteId = 6, UserId = 3, AnimalId = 6 },
                new Favorite { FavoriteId = 7, UserId = 4, ProductId = 7 },
                new Favorite { FavoriteId = 8, UserId = 4, ProductId = 8 },
                new Favorite { FavoriteId = 9, UserId = 5, AnimalId = 9 },
                new Favorite { FavoriteId = 10, UserId = 5, ProductId = 10 }
            );


            modelBuilder.Entity<Cart>().HasData
            (
                new Cart { CartId = 1, UserId = 1 },
                new Cart { CartId = 2, UserId = 2 },
                new Cart { CartId = 3, UserId = 3 },
                new Cart { CartId = 4, UserId = 4 },
                new Cart { CartId = 5, UserId = 5 },
                new Cart { CartId = 6, UserId = 6 },
                new Cart { CartId = 7, UserId = 7 },
                new Cart { CartId = 8, UserId = 8 },
                new Cart { CartId = 9, UserId = 9 },
                new Cart { CartId = 10, UserId = 10 }
            );            

            // Seed data for CartItem with ItemType
            modelBuilder.Entity<CartItem>().HasData
            (
                new CartItem { CartItemId = 1, CartId = 1, ItemId = 1, ItemType = "Animal", Quantity = 1 },
                new CartItem { CartItemId = 2, CartId = 1, ItemId = 2, ItemType = "Product", Quantity = 2 },
                new CartItem { CartItemId = 3, CartId = 2, ItemId = 3, ItemType = "Animal", Quantity = 1 },
                new CartItem { CartItemId = 4, CartId = 3, ItemId = 4, ItemType = "Product", Quantity = 3 },
                new CartItem { CartItemId = 5, CartId = 4, ItemId = 5, ItemType = "Animal", Quantity = 1 },
                new CartItem { CartItemId = 6, CartId = 5, ItemId = 6, ItemType = "Product", Quantity = 1 },
                new CartItem { CartItemId = 7, CartId = 6, ItemId = 7, ItemType = "Animal", Quantity = 2 },
                new CartItem { CartItemId = 8, CartId = 7, ItemId = 8, ItemType = "Product", Quantity = 3 },
                new CartItem { CartItemId = 9, CartId = 8, ItemId = 9, ItemType = "Animal", Quantity = 1 },
                new CartItem { CartItemId = 10, CartId = 9, ItemId = 10, ItemType = "Product", Quantity = 2 }
            );  

            modelBuilder.Entity<AnimalReview>().HasData
            (
                 new AnimalReview { AnimalReviewId = 1, Content = "Great pet!", ReviewerId = 2, AnimalId = 1, ReviewDate = DateTime.UtcNow.AddDays(-1) },
                 new AnimalReview { AnimalReviewId = 2, Content = "Very playful.", ReviewerId = 3, AnimalId = 2, ReviewDate = DateTime.UtcNow.AddDays(-2) },
                 new AnimalReview { AnimalReviewId = 3, Content = "Beautiful singing!", ReviewerId = 1, AnimalId = 3, ReviewDate = DateTime.UtcNow.AddDays(-3) },
                 new AnimalReview { AnimalReviewId = 4, Content = "Very friendly dog!", ReviewerId = 8, AnimalId = 1, ReviewDate = DateTime.UtcNow.AddDays(-4) },
                 new AnimalReview { AnimalReviewId = 5, Content = "Great pet!", ReviewerId = 5, AnimalId = 1, ReviewDate = DateTime.UtcNow.AddDays(-1) },
                 new AnimalReview { AnimalReviewId = 6, Content = "Very playful.", ReviewerId = 5, AnimalId = 2, ReviewDate = DateTime.UtcNow.AddDays(-2) },
                 new AnimalReview { AnimalReviewId = 7, Content = "Beautiful singing!", ReviewerId = 1, AnimalId = 8, ReviewDate = DateTime.UtcNow.AddDays(-3) },
                 new AnimalReview { AnimalReviewId = 8, Content = "Very friendly dog!", ReviewerId = 3, AnimalId = 6, ReviewDate = DateTime.UtcNow.AddDays(-4) },
                 new AnimalReview { AnimalReviewId = 9, Content = "Great pet!", ReviewerId = 5, AnimalId = 8, ReviewDate = DateTime.UtcNow.AddDays(-1) },
                 new AnimalReview { AnimalReviewId = 10, Content = "Very playful.", ReviewerId = 2, AnimalId = 6, ReviewDate = DateTime.UtcNow.AddDays(-2) },
                 new AnimalReview { AnimalReviewId = 11, Content = "Beautiful singing!", ReviewerId = 5, AnimalId = 3, ReviewDate = DateTime.UtcNow.AddDays(-3) },
                 new AnimalReview { AnimalReviewId = 12, Content = "Very friendly dog!", ReviewerId = 7, AnimalId = 9, ReviewDate = DateTime.UtcNow.AddDays(-4) }
            );


            
            modelBuilder.Entity<Order>().HasData
            (
                new Order
                {
                    OrderId = 1,
                    UserId = 5, // User5
                    IncludeDelivery = true,
                    Tip = 0.00m,
                    Status = "Processing",
                    OrderDate = DateTime.UtcNow.AddDays(-1)
                },
                new Order
                {
                    OrderId = 2,
                    UserId = 1, // User1
                    IncludeDelivery = false,
                    Tip = 0.00m,
                    Status = "Completed",
                    OrderDate = DateTime.UtcNow.AddDays(-2)
                }
            );

            // Seed OrderItems (minimal static data, owner details to be updated dynamically)
            modelBuilder.Entity<OrderItem>().HasData
            (
                    new OrderItem
                    {
                        OrderItemId = 1,
                        OrderId = 1,
                        ItemId = 1, // Animal: Dog
                        Quantity = 1,
                        OwnerId = 1, // Will update OwnerName dynamically
                   
                    },
                    new OrderItem
                    {
                        OrderItemId = 2,
                        OrderId = 1,
                        ItemId = 1, // Product: Dog Food
                        Quantity = 1,
                        OwnerId = 1, // Will update OwnerName dynamically
                    
                    },
                    new OrderItem
                    {
                        OrderItemId = 3,
                        OrderId = 2,
                        ItemId = 1, // Product: Dog Food
                        Quantity = 1,
                        OwnerId = 1, // Will update OwnerName dynamically
                  }
            );

           

            

        }
    }
}
