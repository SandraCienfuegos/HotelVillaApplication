using System;
using System.Collections.Generic;
using System.Linq;
using API.Domain.Models;
using API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<EquipmentLanguage> EquipmentLanguages { get; set; }

        public DbSet<Extra> Extras { get; set; }

        public DbSet<ExtraLanguage> ExtraLanguages { get; set; }

        public DbSet<Formula> Formulas { get; set; }

        public DbSet<FormulaLanguage> FormulaLanguages { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<ReservationExtra> ReservationExtras { get; set; }

        public DbSet<ReservationService> ReservationServices { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<ServiceLanguage> ServiceLanguages { get; set; }

        public DbSet<Villa> Villas { get; set; }

        public DbSet<VillaEquipment> VillaEquipments { get; set; }

        public DbSet<VillaFormula> VillaFormulas { get; set; }

        public DbSet<VillaLanguage> VillaLanguages { get; set; }

        public DbSet<VillaMedia> VillaMedias { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>(entity =>
            {
                entity
                    .ToTable("Address");

                entity
                    .HasKey(x => x.AddressId);

                InitPrimaryKeyGenerator(entity.Property(x => x.AddressId));

                entity
                    .Property(x => x.LineOne)
                    .IsRequired();

                entity
                    .Property(x => x.PostCode)
                    .IsRequired();

                entity
                    .Property(x => x.City)
                    .IsRequired();

                entity
                    .HasOne(x => x.Country)
                    .WithMany(x => x.Addresses)
                    .HasForeignKey(x => x.CountryId);
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity
                    .ToTable("Admin");

                entity
                    .HasKey(x => x.AdminId);

                InitPrimaryKeyGenerator(entity.Property(x => x.AdminId));

                entity
                    .Property(x => x.FirstName)
                    .IsRequired();

                entity
                    .Property(x => x.Email)
                    .IsRequired();

                entity
                    .HasIndex(x => x.Email)
                    .IsUnique();

                entity
                    .Property(x => x.Password)
                    .IsRequired();
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity
                    .ToTable("Country");

                entity
                    .HasKey(x => x.CountryId);

                InitPrimaryKeyGenerator(entity.Property(x => x.CountryId));

                entity
                    .Property(x => x.CountryName)
                    .IsRequired();

                entity
                    .HasIndex(x => x.CountryName)
                    .IsUnique();
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity
                    .ToTable("Customer");

                entity
                    .HasKey(x => x.CustomerId);

                InitPrimaryKeyGenerator(entity.Property(x => x.CustomerId));

                entity
                    .Property(x => x.FirstName)
                    .IsRequired();

                entity
                    .Property(x => x.LastName)
                    .IsRequired();

                entity
                    .Property(x => x.PhoneNumber)
                    .IsRequired();

                entity
                    .Property(x => x.Email)
                    .IsRequired();

                entity
                    .HasIndex(x => x.Email)
                    .IsUnique();

                entity
                    .Property(x => x.Password)
                    .IsRequired();

                entity
                    .Property(x => x.BirthdayDate)
                    .IsRequired();

                entity
                    .Property(x => x.Sex)
                    .IsRequired();

                entity
                    .HasOne(x => x.Address)
                    .WithOne(x => x.Customer)
                    .HasForeignKey<Customer>(x => x.AddressId);
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity
                    .ToTable("Equipment");

                entity
                    .HasKey(x => x.EquipmentId);

                InitPrimaryKeyGenerator(entity.Property(x => x.EquipmentId));

                entity
                    .Property(x => x.IconFile)
                    .IsRequired();

                entity
                    .HasIndex(x => x.IconFile)
                    .IsUnique();
            });

            modelBuilder.Entity<EquipmentLanguage>(entity =>
            {
                entity
                    .ToTable("EquipmentLanguage");

                entity
                    .HasKey(x => new {x.EquipmentId, x.LanguageId});

                entity
                    .Property(x => x.EquipmentName)
                    .IsRequired();

                entity
                    .HasOne(x => x.Language)
                    .WithMany(x => x.EquipmentLanguages)
                    .HasForeignKey(x => x.LanguageId);

                entity
                    .HasOne(x => x.Equipment)
                    .WithMany(x => x.EquipmentLanguages)
                    .HasForeignKey(x => x.EquipmentId);
            });

            modelBuilder.Entity<Extra>(entity =>
            {
                entity
                    .ToTable("Extra");

                entity
                    .HasKey(x => x.ExtraId);

                InitPrimaryKeyGenerator(entity.Property(x => x.ExtraId));

                entity
                    .Property(x => x.ExtraPrice)
                    .IsRequired();
            });

            modelBuilder.Entity<ExtraLanguage>(entity =>
            {
                entity
                    .ToTable("ExtraLanguage");

                entity
                    .HasKey(x => new {x.ExtraId, x.LanguageId});

                entity
                    .Property(x => x.ExtraName)
                    .IsRequired();

                entity
                    .HasOne(x => x.Language)
                    .WithMany(x => x.ExtraLanguages)
                    .HasForeignKey(x => x.LanguageId);

                entity
                    .HasOne(x => x.Extra)
                    .WithMany(x => x.ExtraLanguages)
                    .HasForeignKey(x => x.ExtraId);
            });

            modelBuilder.Entity<Formula>(entity =>
            {
                entity
                    .ToTable("Formula");

                entity
                    .HasKey(x => x.FormulaId);

                InitPrimaryKeyGenerator(entity.Property(x => x.FormulaId));
            });

            modelBuilder.Entity<FormulaLanguage>(entity =>
            {
                entity
                    .ToTable("FormulaLanguage");

                entity
                    .HasKey(x => new {x.FormulaId, x.LanguageId});

                entity
                    .Property(x => x.FormulaName)
                    .IsRequired();

                entity
                    .HasOne(x => x.Language)
                    .WithMany(x => x.FormulaLanguages)
                    .HasForeignKey(x => x.LanguageId);

                entity
                    .HasOne(x => x.Formula)
                    .WithMany(x => x.FormulaLanguages)
                    .HasForeignKey(x => x.FormulaId);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity
                    .ToTable("Language");

                entity
                    .HasKey(x => x.LanguageId);

                InitPrimaryKeyGenerator(entity.Property(x => x.LanguageId));

                entity
                    .Property(x => x.IsoCode)
                    .IsRequired();

                entity
                    .HasIndex(x => x.IsoCode)
                    .IsUnique();

                entity
                    .Property(x => x.IsDefault)
                    .IsRequired();
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity
                    .ToTable("Reservation");

                entity
                    .HasKey(x => x.ReservationId);

                InitPrimaryKeyGenerator(entity.Property(x => x.ReservationId));

                entity
                    .Property(x => x.NumberAdults)
                    .IsRequired();

                entity
                    .Property(x => x.NumberChildren)
                    .IsRequired();
                entity
                    .Property(x => x.NumberBabies)
                    .IsRequired();
                entity
                    .Property(x => x.ReservationDate)
                    .IsRequired();
                entity
                    .Property(x => x.PriceChoice)
                    .IsRequired();
                entity
                    .Property(x => x.CheckInDate)
                    .IsRequired();
                entity
                    .Property(x => x.CheckOutDate)
                    .IsRequired();

                entity
                    .HasOne(x => x.Customer)
                    .WithMany(x => x.Reservations)
                    .HasForeignKey(x => x.CustomerId);

                entity
                    .HasOne(x => x.Villa)
                    .WithMany(x => x.Reservations)
                    .HasForeignKey(x => x.VillaId);

                entity
                    .HasOne(x => x.Formula)
                    .WithMany(x => x.FormulaReservations)
                    .HasForeignKey(x => x.FormulaId);
            });

            modelBuilder.Entity<ReservationExtra>(entity =>
            {
                entity
                    .ToTable("ReservationExtra");

                entity
                    .HasKey(x => new {x.ReservationId, x.ExtraId});

                entity
                    .Property(x => x.Number)
                    .IsRequired();

                entity
                    .HasOne(x => x.Reservation)
                    .WithMany(x => x.Extras)
                    .HasForeignKey(x => x.ReservationId);

                entity
                    .HasOne(x => x.Extra)
                    .WithMany(x => x.ReservationExtras)
                    .HasForeignKey(x => x.ExtraId);
            });

            modelBuilder.Entity<ReservationService>(entity =>
            {
                entity
                    .ToTable("ReservationService");

                entity
                    .HasKey(x => new {x.ReservationId, x.ServiceId});

                entity
                    .HasOne(x => x.Reservation)
                    .WithMany(x => x.Services)
                    .HasForeignKey(x => x.ReservationId);

                entity
                    .HasOne(x => x.Service)
                    .WithMany(x => x.ReservationServices)
                    .HasForeignKey(x => x.ServiceId);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity
                    .ToTable("Service");

                entity
                    .HasKey(x => x.ServiceId);

                InitPrimaryKeyGenerator(entity.Property(x => x.ServiceId));

                entity
                    .Property(x => x.ServicePrice)
                    .IsRequired();
            });

            modelBuilder.Entity<ServiceLanguage>(entity =>
            {
                entity
                    .ToTable("ServiceLanguage");

                entity
                    .HasKey(x => new {x.ServiceId, x.LanguageId});

                entity
                    .Property(x => x.ServiceName)
                    .IsRequired();

                entity
                    .HasOne(x => x.Language)
                    .WithMany(x => x.ServiceLanguages)
                    .HasForeignKey(x => x.LanguageId);

                entity
                    .HasOne(x => x.Service)
                    .WithMany(x => x.ServiceLanguages)
                    .HasForeignKey(x => x.ServiceId);
            });

            modelBuilder.Entity<Villa>(entity =>
            {
                entity
                    .ToTable("Villa");

                entity
                    .HasKey(x => x.VillaId);

                InitPrimaryKeyGenerator(entity.Property(x => x.VillaId));

                entity
                    .Property(x => x.VillaName)
                    .IsRequired();

                entity
                    .Property(x => x.VillaPath)
                    .IsRequired();

                entity
                    .Property(x => x.NumberOfBeds)
                    .IsRequired();

                entity
                    .Property(x => x.SurfaceArea)
                    .IsRequired();

                entity
                    .Property(x => x.PriceOnline)
                    .IsRequired();

                entity
                    .Property(x => x.PriceOnSite)
                    .IsRequired();
            });

            modelBuilder.Entity<VillaEquipment>(entity =>
            {
                entity
                    .ToTable("VillaEquipment");

                entity
                    .HasKey(x => new {x.VillaId, x.EquipmentId});

                entity
                    .HasOne(x => x.Villa)
                    .WithMany(x => x.Equipments)
                    .HasForeignKey(x => x.VillaId);

                entity
                    .HasOne(x => x.Equipment)
                    .WithMany(x => x.VillaEquipments)
                    .HasForeignKey(x => x.EquipmentId);
            });

            modelBuilder.Entity<VillaFormula>(entity =>
            {
                entity
                    .ToTable("VillaFormula");

                entity
                    .HasKey(x => new {x.VillaId, x.FormulaId});

                entity
                    .Property(x => x.PriceAdult)
                    .IsRequired();

                entity
                    .Property(x => x.PriceChild)
                    .IsRequired();

                entity
                    .Property(x => x.PriceBaby)
                    .IsRequired();

                entity
                    .HasOne(x => x.Villa)
                    .WithMany(x => x.Formulas)
                    .HasForeignKey(x => x.VillaId);

                entity
                    .HasOne(x => x.Formula)
                    .WithMany(x => x.VillaFormulas)
                    .HasForeignKey(x => x.FormulaId);
            });

            modelBuilder.Entity<VillaLanguage>(entity =>
            {
                entity
                    .ToTable("VillaLanguage");

                entity
                    .HasKey(x => new {x.VillaId, x.LanguageId});

                entity
                    .Property(x => x.Description)
                    .IsRequired();

                entity
                    .HasOne(x => x.Villa)
                    .WithMany(x => x.Languages)
                    .HasForeignKey(x => x.VillaId);

                entity
                    .HasOne(x => x.Language)
                    .WithMany(x => x.VillaLanguages)
                    .HasForeignKey(x => x.LanguageId);
            });

            modelBuilder.Entity<VillaMedia>(entity =>
            {
                entity
                    .ToTable("VillaMedia");

                entity
                    .HasKey(x => x.MediaId);

                InitPrimaryKeyGenerator(entity.Property(x => x.MediaId));

                entity
                    .Property(x => x.MediaName)
                    .IsRequired();

                entity
                    .HasOne(x => x.Villa)
                    .WithMany(x => x.Medias)
                    .HasForeignKey(x => x.VillaId);
            });
        }

        private static void InitPrimaryKeyGenerator(PropertyBuilder property)
        {
            property
                .IsRequired()
                .ValueGeneratedOnAdd();
        }

        public static void PopulateDatabase(AppDbContext context)
        {
            // context.Admins.AddRange(
            //     new Admin
            //     {
            //         FirstName = "Sandra",
            //         Email = "sandra@hotel.admin.com",
            //         Password = CryptographyTool.CryptSHA512("Sandra")
            //     }
            // );
            // context.SaveChanges();

            context.Countries.AddRange(
                new Country
                {
                    CountryName = "Belgium",
                },
                new Country
                {
                    CountryName = "Spain",
                },
                new Country
                {
                    CountryName = "Morocco",
                },
                new Country
                {
                    CountryName = "United Kingdom",
                }
            );
            context.SaveChanges();

            context.Addresses.AddRange(
                new Address
                {
                    CountryId = context.Countries.First(x => x.CountryName == "Spain").CountryId,
                    LineOne = "Calle Doctor Aquilino Hurle, 20",
                    PostCode = "33202",
                    City = "Gijon"
                }
            );
            context.SaveChanges();

            context.Customers.AddRange(
                new Customer
                {
                    AddressId = context.Addresses.First(x => x.LineOne == "Calle Doctor Aquilino Hurle, 20").AddressId,
                    FirstName = "Dolores",
                    LastName = "Poveda",
                    PhoneNumber = "+34684640258",
                    Email = "dolores.poveda@gmail.com",
                    Password = CryptographyTool.CryptSHA512("dpoveda"),
                    BirthdayDate = new DateTime(1948, 5, 4),
                    Sex = ESex.Female
                }
            );
            context.SaveChanges();

            context.Languages.AddRange(
                new Language
                {
                    IsoCode = "AR",
                    IsDefault = false
                },
                new Language
                {
                    IsoCode = "EN",
                    IsDefault = true
                },
                new Language()
                {
                    IsoCode = "ES",
                    IsDefault = false
                },
                new Language
                {
                    IsoCode = "FR",
                    IsDefault = false
                }
            );
            context.SaveChanges();

            context.Villas.AddRange(
                new Villa
                {
                    VillaName = "Duchess Villa",
                    VillaPath = "duchess-villa",
                    NumberOfBeds = 1,
                    SurfaceArea = 140.0,
                    PriceOnline = 372.0,
                    PriceOnSite = 472.0
                },
                new Villa
                {
                    VillaName = "Gran Duchess Villa",
                    VillaPath = "gran-duchess-villa",
                    NumberOfBeds = 1,
                    SurfaceArea = 200.0,
                    PriceOnline = 518.0,
                    PriceOnSite = 568.0
                },
                new Villa
                {
                    VillaName = "Princess Villa",
                    VillaPath = "princess-villa",
                    NumberOfBeds = 2,
                    SurfaceArea = 208.0,
                    PriceOnline = 543.0,
                    PriceOnSite = 593.0
                },
                new Villa
                {
                    VillaName = "Gran Princess Villa",
                    VillaPath = "gran-princess-villa",
                    NumberOfBeds = 2,
                    SurfaceArea = 233.0,
                    PriceOnline = 629.0,
                    PriceOnSite = 679.0
                },
                new Villa
                {
                    VillaName = "Royal Princess Villa",
                    VillaPath = "royal-princess-villa",
                    NumberOfBeds = 2,
                    SurfaceArea = 240.0,
                    PriceOnline = 740.0,
                    PriceOnSite = 790.0
                },
                new Villa
                {
                    VillaName = "Majestic Villa",
                    VillaPath = "majestic-villa",
                    NumberOfBeds = 2,
                    SurfaceArea = 260.0,
                    PriceOnline = 800.0,
                    PriceOnSite = 850.0
                },
                new Villa
                {
                    VillaName = "Gran Majestic Villa",
                    VillaPath = "gran-majestic-villa",
                    NumberOfBeds = 2,
                    SurfaceArea = 320.0,
                    PriceOnline = 843.0,
                    PriceOnSite = 893.0
                },
                new Villa
                {
                    VillaName = "Queen Villa",
                    VillaPath = "queen-villa",
                    NumberOfBeds = 3,
                    SurfaceArea = 370.0,
                    PriceOnline = 958.0,
                    PriceOnSite = 1008.0
                },
                new Villa
                {
                    VillaName = "Royal Villa",
                    VillaPath = "royal-villa",
                    NumberOfBeds = 3,
                    SurfaceArea = 355.0,
                    PriceOnline = 1000.0,
                    PriceOnSite = 1050.0
                },
                new Villa
                {
                    VillaName = "Imperial Villa",
                    VillaPath = "imperial-villa",
                    NumberOfBeds = 3,
                    SurfaceArea = 366.0,
                    PriceOnline = 1100.0,
                    PriceOnSite = 1150.0
                },
                new Villa
                {
                    VillaName = "Queen Villa With Pavillon",
                    VillaPath = "queen-villa-with-pavillon",
                    NumberOfBeds = 3,
                    SurfaceArea = 400.0,
                    PriceOnline = 2000.0,
                    PriceOnSite = 2050.0
                }
            );
            context.SaveChanges();

            context.VillaLanguages.AddRange(
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Duchess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    Description =
                        @"استمتع بإثراء ملاذك الشخصي بمسبح خاص مُدفأ، إلى جانب وسائل الراحة الفاخرة الأخرى مثل المطبخ المجهز بالكامل والشرفة المنعزلة التي تطل على المحيط وخزانة المشروبات المُجهّزة بالكامل."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Duchess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    Description =
                        @"Enjoy the pampering of your own personal hideaway with a heated private pool, along with other luxurious amenities like a fully equipped kitchen, a secluded ocean-view terrace and a fully-stocked drinks cabinet."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Duchess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    Description = @"Villa de 1 dormitorio (140 mt2), con piscina privada climatizada.

Dormitorio cama King Size y baño con bañera y ducha.

Cocina totalmente equipada con electrodomésticos y cafetera Nespresso, salón-comedor, piscina climatizada y amplia terraza con tumbonas y parasol."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Duchess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    Description =
                        @"Une véritable oasis personnelle dans laquelle se laisser choyer, avec une piscine privée chauffée et le confort le plus luxueux, dont une cuisine parfaitement équipée, une terrasse discrète avec vue sur l’océan et un coin bar bien fourni."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Gran Duchess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    Description =
                        @"استمتع بكل وسائل الراحة التي توفرها فيلا دتشيس، بما في ذلك حمام السباحة الخاص المُدفأ، حتى تنطلق بطموحاتك أبعد من ذلك. اقضِ أيام الخمول والاسترخاء مستلقيًا تحت شرفة على الطراز البالي، وتمدد في الصالة كبيرة الحجم."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Gran Duchess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    Description =
                        @"Revel in all the same amenities as the Duchess Villa, including a heated private pool, but spread your wings even further. Spend lazy days lounging under a Balinese gazebo, and stretch out in the oversized lounge."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Gran Duchess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    Description = @"Villa de 1 dormitorio (200 mt2), con piscina privada climatizada.

Dormitorio cama King Size y baño con bañera y ducha.

Cocina totalmente equipada con electrodomésticos y cafetera Nespresso, salón-comedor, piscina climatizada y amplia terraza con tumbonas, parasol y gacebo balinés."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Gran Duchess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    Description =
                        @"Tous les conforts d’une Villa Duchess, dont la piscine privée chauffée, mais avec des espaces encore plus vastes, pour passer de délicieuses journées de détente paresseusement étendus sous un pavillon de style balinais ou dans le salon clair et spacieux."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Princess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    Description =
                        @"يمكنك الاستمتاع بالرفاهية في فيلات برنسيس المكونة من غرفتي نوم وحمامين، المثالية لقضاء عطلة عائلية فاخرة في تينيريفي يمكنك الاستمتاع بدفء شبه استوائي حول حمام السباحة المُدفأ الخاص بك، واحتساء الكوكتيلات بهدوء عند غروب الشمس على الشرفة المُطلة على المحيط، والاستمتاع بوقت عائلي جيد معًا في منطقة المعيشة/تناول الطعام الأنيقة."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Princess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    Description =
                        @"Ideal for luxury family holidays in Tenerife, luxuriate in the two-bedroom, two-bathroom Princess villas. Bask in sub-tropical warmth around your heated private pool, sip slow sunset cocktails on the ocean-view terrace, and enjoy quality family time together in the chic living/dining area."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Princess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    Description = @"Villa de 2 dormitorios (208 mt2), con piscina privada climatizada.

Un dormitorio cama King Size, baño con ducha, bañera y ducha exterior. Segundo dormitorio con dos camas individuales, baño con ducha interior y ducha exterior.

Cocina totalmente equipada con electrodomésticos y cafetera Nespresso, salón-comedor, piscina climatizada y amplia terraza con tumbonas y parasol."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Princess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    Description =
                        @"Idéales pour de luxueuses vacances en famille à Ténériffe, les Villas Princess offrent deux chambres et deux salles de bains très élégantes. Une agréable tiédeur subtropicale love la piscine privée chauffée, tandis qu’au coucher du soleil, les hôtes boivent un cocktail à petites gorgées en admirant l’océan et en passant agréablement du temps de qualité en famille dans le fastueux séjour."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Gran Princess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    Description =
                        @"استمتع أنت وعائلتك/أصدقائك بترقية واحصل على مساحة أكبر في إحدى فلل جران برنسيس لدينا. يوفر ملاذك الفاخر كل ما تحتاجه لقضاء عطلة فاخرة غير عادية في تينيريفي، بما في ذلك شرفة في الهواء الطلق بإطلالات على المحيط وحمام سباحة خاص مُدفأ."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Gran Princess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    Description =
                        @"Treat you and your family/friends to an upgrade and enjoy even more space in one of our Gran Princess villas. Your lavish retreat provides everything you could possible need for an extraordinary luxury break in Tenerife, including an airy terrace with ocean views and a heated private pool."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Gran Princess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    Description = @"Villa de 2 dormitorios (233 mt2), con piscina privada climatizada.

Un dormitorio cama King Size, baño con ducha, bañera y ducha exterior. Segundo dormitorio con dos camas individuales, baño con ducha interior y ducha exterior.

Cocina totalmente equipada con electrodomésticos y cafetera Nespresso, amplio salón-comedor, piscina climatizada y amplia terraza con tumbonas, parasol y gacebo balinés."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Gran Princess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    Description =
                        @"Les familles et les groupes d’amis qui veulent ce qu’il y a de mieux trouveront dans les Villas Gran Princess un hébergement encore plus spacieux. Ces luxueuses demeures ont tout ce dont on peut rêver à l’occasion d’un séjour de luxe extraordinaire à Ténériffe, comme une grane terrasse avec vue sur l’océan et une piscine privée chauffée."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Royal Princess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    Description =
                        @"دلل نفسك في شرنقة الصفاء والهدوء الفخمة هذه، في فيلا فاخرة مكونة من غرفتي نوم مصممتين لتجربة ملكية. واستمتع بأشعة الشمس على الشرفة الضخمة، ثم استرخ في نعيم حمام السباحة الخاص المُدفأ. مع كل وسائل الراحة التي يمكن تخيلها في متناول يدك، بما في ذلك مطبخ كامل وأسِرة خارجية على الطراز البالي وشاشات تلفاز بلازما."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Royal Princess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    Description =
                        @"Spoil yourself in this opulent cocoon of serenity, a graniose 2-bedroom villa designed for royalty. Soak up the sunshine on the huge terrace, then ease into the watery bliss of your heated private pool. Every convenience imaginable is right at your fingertips, including a full kitchen, outdoor Bali beds and plasma TVs."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Royal Princess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    Description = @"Villa de 2 dormitorios (240 mt2), con piscina privada climatizada.

Un dormitorio cama King Size, baño con ducha, bañera. Segundo dormitorio con dos camas individuales, baño con ducha interior y ducha exterior.

Cocina totalmente equipada con electrodomésticos y cafetera Nespresso, salón-comedor, piscina climatizada y amplia terraza con tumbonas, parasol y gacebo balinés."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Royal Princess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    Description =
                        @"Dans cette graniose villa avec deux chambres, même un roi se sentirait comme chez lui, tour à tour lézardant sur la vaste terrasse et plongeant dans la piscine privée chauffée, en plein cœur d’un paradis aussi opulent qu’intime. De la cuisine entièrement équipée aux luxueux lits balinais disposés à l’extérieur, sans compter les téléviseurs à écran plasma, en matière de confort, rien n’a été laissé au hasard."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Majestic Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    Description =
                        @"نضمن أنك لن تستغرق الكثير من الوقت قبل الاستسلام لهدوء فيلا ماجيستك، المُزينة بعدد من التحف المنحوتة يدويًا، وتتضمن بار خاص كامل. مع تصميمات داخلية مزدوجة أنيقة تتميز بقطع الأثاث الغريبة والمفروشات الناعمة الغنية، في حين تتدفق المياه الدافئة من الشرفة إلى حمام السباحة الخاص."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Majestic Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    Description =
                        @"Embellished with hand-carved artefacts and your own complete bar, we guarantee it won’t take long before you succumb to the tranquillity of the Majestic Villa. Stylish duplex interiors feature exotic furnishings and rich soft furnishings, while the warm waters of your private pool beckon from the terrace."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Majestic Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    Description =
                        @"Villa duplex de 2 dormitorios (260 mt2) con magníficas vistas al mar y al campo de golf.

Un dormitorio cama King Size, baño con ducha y bañera. Segundo dormitorio con dos camas individuales, baño con ducha interior.

Cocina totalmente equipada con electrodomésticos y cafetera Nespresso, salón-comedor, balcón con bañera exterior y terraza con piscina climatizada, tumbonas, parasol y gacebo balinés"
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Majestic Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    Description =
                        @"Décorée avec de splendides pièces entaillées et un bar bien fourni, la Villa Majestic séduit ses hôtes par son atmosphère de profonde sérénité. Les élégants intérieurs répartis sur deux étages abritent un mobilier exotique et des accessoires raffinés, tandis que la piscine privée chauffée, où l’eau est toujours à une température idéale, vous convie à la détente."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Gran Majestic Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    Description =
                        @"انغمس في الأناقة المطلقة لفيلا جران ماجيستيك. إذا كنت تحب أفضل الأفضل، فهذه الواحة الراقية والأنيقة تتمتع بإطلالات رائعة على المحيط مع أكبر قدر من الخصوصية وأكبر شرفة وأكبر حمام خاص في جميع فيلاتنا الرائعة. ببساطة... رائعة."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Gran Majestic Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    Description =
                        @"Indulge in the ultimate luxury of the Gran Majestic Villa. If you like the best of the best, this refined oasis of elegance has the best ocean views, the most privacy, the largest terrace and the biggest private pool of all our fabulous villas. Simply put… it’s simply special."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Gran Majestic Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    Description =
                        @"Villa duplex de 2 dormitorios (320 mt2) con magníficas vistas al mar y al campo de golf.

Un dormitorio cama King Size, baño con ducha y bañera. Segundo dormitorio con dos camas individuales, baño con ducha interior.

Cocina totalmente equipada con electrodomésticos y cafetera Nespresso, salón-comedor, balcón con bañera exterior y terraza con piscina climatizada, tumbonas, parasol y gacebo balinés"
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Gran Majestic Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    Description =
                        @"La Villa Gran Majestic ou le luxe au sens propre du terme. Impossible de trouver mieux que dans cette oasis d’élégance sophistiquée, où la vue sur l’océan est sans pareille et où les hôtes peuvent jouir d’un maximum d’intimité, de la terrasse la plus vaste à la piscine privée la plus grane de tout le complexe hôtelier. Pour tout dire, elle est résolument spéciale."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Queen Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    Description =
                        @"مع مساحة تتسع لما يصل إلى ستة أفراد من العائلة أو الأصدقاء، تزيد فيلا كوين الفاخرة من الشعور بالمساحة الأنيقة والراحة مع الحفاظ على جو من الأناقة والخصوصية. من الصباح إلى المساء، توفر التصميمات الراقية مثل المسبح الخاص المُدفأ والأسِرة المريحة للغاية والديكور الغريب تدليلًا يتجاوز ما يدور في خيالك."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Queen Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    Description =
                        @"With space for up to six family members or friends, the deluxe Queen Villa maximises the feeling of stylish space and comfort while still retaining an air of secluded sophistication. From morning to night the high-end refinements such as a heated private pool, supremely comfortable beds and exotic décor provide pampering beyond your imagination."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Queen Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    Description = @"Villa de 2 dormitorios (370 mt2) con vistas al mar y a las montañas.

Un dormitorio cama King Size, baño con ducha y bañera. Segundo dormitorio con dos camas individuales, baño con ducha interior y ducha exterior.

Cocina totalmente equipada con electrodomésticos y cafetera Nespresso, salón-comedor, piscina climatizada y amplia terraza con tumbonas, parasol y gacebo balinés."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Queen Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    Description =
                        @"Avec assez de place pour accueillir un maximum de six personnes, la luxueuse Villa Queen est un parfait synonyme de confort et d’élégance auxquels s’ajoute cette touche de discrétion sophistiquée toujours si appréciée. À tout moment de la journée, la piscine privée chauffée, les lits ultra confortables et le mobilier exotique contribuent à créer autour de votre séjour une atmosphère dont le plaisir dépasse l’imagination."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Royal Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    Description =
                        @"احظ بالاسترخاء في المناطق المحيطة بالفندق في فيلا رويال، حيث تتناسب المفروشات المُختارة يدويًا والأقمشة الناعمة الحريرية ومجموعة كاملة من وسائل الراحة الفاخرة مع الشرفة الضخمة المشمسة وحمام السباحة الشخصي المُدفأ. اجعل هذه المساحة كما لو كانت منزل أحلامك."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Royal Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    Description =
                        @"Revel in the palatial surroundings of the Royal Villa, where handpicked furnishings, silky soft fabrics and a full spectrum of luxe amenities complement the huge, sun-drenched terrace and personal heated pool. Make this your space in a home that you dream of."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Royal Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    Description =
                        @"Villa duplex de 3 dormitorios (355 mt2) con vistas al mar, campo de golf y las montañas.

Un dormitorio cama King Size, baño con ducha y bañera. Segundo y tercer dormitorio con dos camas individuales y baño con ducha interior.

Cocina totalmente equipada con electrodomésticos y cafetera Nespresso, salón-comedor, piscina climatizada y amplia terraza con tumbonas, parasol y gacebo balinés."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Royal Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    Description =
                        @"Tout est possible dans les fastueux espaces de la Villa Royal où le mobilier admirablement choisi, les tissus doux et soyeux et un luxueux confort général sont le juste complément de l’immense terrasse baignée de soleil et de la piscine privée chauffée. La demeure dont vous avez toujours rêvé est bien réelle"
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Imperial Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    Description =
                        @"استرخ في فيلا إمبيريال الرائعة المكونة من 3 غرف نوم - طابقان على الطراز الآسيوي الأنيق مع شرفة واسعة تطل على حمام السباحة مقابل المساحات الخضراء لملعب كوستا أديجي للجولف والجبال البعيدة والمحيط الأطلسي المتلألئ."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Imperial Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    Description =
                        @"Relax in your exquisite, three-bedroom Imperial Villa - two floors of Asiatic chic paired with a spacious terrace featuring poolside views across the greenery of Costa Adeje Golf, the distant mountains and the sparkling Atlantic Ocean."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Imperial Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    Description =
                        @"Villa duplex de 3 dormitorios (366 mt2) con vistas al mar, campo de golf y las montañas.

Un dormitorio cama King Size, baño con ducha y bañera. Segundo y tercer dormitorio con dos camas individuales y baño con ducha interior.

Cocina totalmente equipada con electrodomésticos y cafetera Nespresso, salón-comedor, piscina climatizada y amplia terraza con tumbonas, parasol y gacebo balinés."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Imperial Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    Description =
                        @"Dans cette élégante villa avec trois chambres à coucher, le mot détente prend tout son sens. Deux étages de raffinement au style asiatique et une vaste terrasse avec piscine donnant sur la magnifique étendue verte du terrain de golf Costa Adeje, sur les montagnes lointaines et sur l’océan scintillant."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Queen Villa With Pavillon").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    Description =
                        @"احظ بالرفاهية والاسترخاء في المساحة الإضافية في ملاذ العزلة الرائع هذا. مع غرفتي النوم لتوفير أقصى درجات الراحة الشديدة، وأخرى ثالثة منفصلة توفر مزيدًا من الراحة والاستقلالية. في حين يحافظ حمام السباحة المُدفأ المُزخرف والسرير المصنوع على الطراز البالي على الهدوء الشديد في الشرفة المطلة على المحيط."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Queen Villa With Pavillon").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    Description =
                        @"Luxuriate in the extra space of this glamorous sanctuary of seclusion. Two bedrooms offer the ultimate in plush comfort, while a third, detached bedroom provides additional comfort and independence. An ornate, heated pool and a Balinese bed sustain the serene bliss on the ocean-view terrace."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Queen Villa With Pavillon").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    Description =
                        @"Villa de 2 dormitorios + pavilion privado con dormitorio extra (370 mt2) con vistas al mar y a las montañas.

Un dormitorio cama King Size, baño con ducha y bañera. Segundo dormitorio con dos camas individuales, baño con ducha interior y ducha exterior.

Cocina totalmente equipada con electrodomésticos y cafetera Nespresso, salón-comedor, piscina climatizada y amplia terraza con tumbonas, parasol y gacebo balinés.

Esta villa ofrece de forma exclusiva un Pavilion privado con dormitorio King size, vestidor y baño con ducha y bañera."
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Queen Villa With Pavillon").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    Description =
                        @"De vastes espaces et la discrétion la plus totale caractérisent cette demeure au style résolument glamour. Les deux chambres offrent un confort unique et une troisième chambre, séparée du corps principal de la villa, est entièrement indépendante. La piscine chauffée richement décorée et son lit balinais embellissent encore davantage l’extraordinaire terrasse avec vue sur l’océan."
                });
            context.SaveChanges();

            context.Equipments.AddRange(
                new Equipment
                {
                    IconFile = "wifi.png"
                },
                new Equipment
                {
                    IconFile = "tv.png"
                },
                new Equipment
                {
                    IconFile = "music.png"
                },
                new Equipment
                {
                    IconFile = "phone.png"
                },
                new Equipment
                {
                    IconFile = "tub.png"
                },
                new Equipment
                {
                    IconFile = "shower.png"
                },
                new Equipment
                {
                    IconFile = "soap.png"
                },
                new Equipment
                {
                    IconFile = "bathrobe.png"
                },
                new Equipment
                {
                    IconFile = "umbrella.png"
                },
                new Equipment
                {
                    IconFile = "pool.png"
                },
                new Equipment
                {
                    IconFile = "terrace.png"
                },
                new Equipment
                {
                    IconFile = "kitchen.png"
                },
                new Equipment
                {
                    IconFile = "wine.png"
                },
                new Equipment
                {
                    IconFile = "coffee.png"
                },
                new Equipment
                {
                    IconFile = "safebox.png"
                },
                new Equipment
                {
                    IconFile = "washer.png"
                }
            );
            context.SaveChanges();

            context.EquipmentLanguages.AddRange(
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "wifi.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    EquipmentName = @"انترنت واي فاي مجاني",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "wifi.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    EquipmentName = @"Free Wi-Fi",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "wifi.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    EquipmentName = @"Wi-Fi gratis",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "wifi.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    EquipmentName = @"WIFI Gratuit",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "tv.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    EquipmentName = @"شاشات تلفاز بلازما",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "tv.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    EquipmentName = @"Plasma TVs",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "tv.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    EquipmentName = @"Televisores de plasma",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "tv.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    EquipmentName = @"TV écran plasma",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "music.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    EquipmentName = @"مشغل دي في دي",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "music.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    EquipmentName = @"DVD Players",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "music.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    EquipmentName = @"Reproductores de DVD",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "music.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    EquipmentName = @"Lecteurs DVD",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "phone.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    EquipmentName = @"الهاتف",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "phone.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    EquipmentName = @"Telephone",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "phone.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    EquipmentName = @"Teléfono",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "phone.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    EquipmentName = @"Téléphone",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "tub.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    EquipmentName = @"حمام به حوض إستحمام",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "tub.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    EquipmentName = @"Bathroom with Bath",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "tub.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    EquipmentName = @"Baño con bañera",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "tub.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    EquipmentName = @"Salle de bain avec baignoire",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "shower.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    EquipmentName = @"دش مساج مائي",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "shower.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    EquipmentName = @"Hydro massage Shower",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "shower.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    EquipmentName = @"Ducha de hidromasaje",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "shower.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    EquipmentName = @"Douche hydromassante",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "soap.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    EquipmentName = @"منظفات صحية",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "soap.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    EquipmentName = @"Toiletries",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "soap.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    EquipmentName = @"Artículos de aseo",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "soap.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    EquipmentName = @"Accessoires de toilette",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "bathrobe.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    EquipmentName = @"روب حمام وشبشب",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "bathrobe.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    EquipmentName = @"Bathrobe and Slippers",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "bathrobe.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    EquipmentName = @"Albornoz y zapatillas",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "bathrobe.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    EquipmentName = @"Peignoir et chaussons",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "umbrella.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    EquipmentName = @"حمام شمسي واسرة شمس",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "umbrella.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    EquipmentName = @"Solarium with sun beds",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "umbrella.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    EquipmentName = @"Solárium con hamacas",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "umbrella.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    EquipmentName = @"Solarium avec chaises longues",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "pool.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    EquipmentName = @"مسبح مسخن بأشعة الشمس",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "pool.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    EquipmentName = @"Heated Private Pool",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "pool.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    EquipmentName = @"Piscina privada climatizada",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "pool.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    EquipmentName = @"Piscine privée à chauffage",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "terrace.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    EquipmentName = @"شرفة مغطاة",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "terrace.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    EquipmentName = @"Covered Terrace",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "terrace.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    EquipmentName = @"Terraza cubierta",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "terrace.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    EquipmentName = @"Terrasse couverte",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "kitchen.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    EquipmentName = @"مطبخ مجهز بجميع التجهيزات",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "kitchen.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    EquipmentName = @"Fully equipped kitchen",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "kitchen.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    EquipmentName = @"Cocina totalmente equipada",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "kitchen.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    EquipmentName = @"Cuisine équipée complète",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "wine.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    EquipmentName = @"خزانة بار",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "wine.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    EquipmentName = @"Bar cabinet",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "wine.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    EquipmentName = @"Mueble bar",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "wine.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    EquipmentName = @"Meuble Bar",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "coffee.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    EquipmentName = @"قهوة نيسبريسو",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "coffee.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    EquipmentName = @"Nespresso",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "coffee.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    EquipmentName = @"Nespresso",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "coffee.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    EquipmentName = @"Nespresso",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "safebox.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    EquipmentName = @"صندوق أمانات",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "safebox.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    EquipmentName = @"Safety deposit box",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "safebox.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    EquipmentName = @"Caja de seguridad",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "safebox.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    EquipmentName = @"Coffre-fort",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "washer.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    EquipmentName = @"غسالة ومجفف",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "washer.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    EquipmentName = @"Washing Machine",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "washer.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    EquipmentName = @"Lavadora",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "washer.png").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    EquipmentName = @"Machine à laver",
                }
            );
            context.SaveChanges();

            var villaIds = context.Villas
                .Select(x => x.VillaId)
                .ToList();

            var equipmentIds = context.Equipments
                .Select(x => x.EquipmentId)
                .ToList();

            foreach (var villaId in villaIds)
            {
                foreach (var equipmentId in equipmentIds)
                {
                    context.VillaEquipments.Add(
                        new VillaEquipment
                        {
                            VillaId = villaId,
                            EquipmentId = equipmentId,
                        }
                    );
                }
            }

            context.SaveChanges();

            var formulas = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"AR", "الإقامة مع الإفطار"},
                    {"EN", "Accommodation with Breakfast"},
                    {"ES", "Alojamiento con desayuno"},
                    {"FR", "Hébergement avec Petit-Déjeuner"}
                },
                new Dictionary<string, string>
                {
                    {"AR", "نصف المجلس"},
                    {"EN", "Half board"},
                    {"ES", "Media pensión"},
                    {"FR", "Demi-pension"}
                },
                new Dictionary<string, string>
                {
                    {"AR", "إقامة كاملة"},
                    {"EN", "Full board"},
                    {"ES", "Pensión completa"},
                    {"FR", "Pension complète"}
                },
                new Dictionary<string, string>
                {
                    {"AR", "فهمت كل شيء"},
                    {"EN", "All-inclusive"},
                    {"ES", "Todo incluido"},
                    {"FR", "Tout compris"}
                },
            };
            foreach (var formula in formulas)
            {
                var formulaEntity = new Formula();
                context.Formulas.Add(formulaEntity);
                context.SaveChanges();
                foreach (var (isoCode, translatedFormulaName) in formula)
                {
                    context.FormulaLanguages.Add(
                        new FormulaLanguage
                        {
                            FormulaId = formulaEntity.FormulaId,
                            LanguageId = context.Languages.First(x => x.IsoCode == isoCode).LanguageId,
                            FormulaName = translatedFormulaName
                        });
                }

                context.SaveChanges();
            }

            var formulaIds = context.Formulas
                .OrderBy(x => x.FormulaId)
                .Select(x => x.FormulaId)
                .ToList();

            foreach (var villaId in villaIds)
            {
                foreach (var formulaId in formulaIds)
                {
                    context.Add(
                        new VillaFormula
                        {
                            VillaId = villaId,
                            FormulaId = formulaId,
                            PriceAdult = formulaId * 50,
                            PriceChild = formulaId * 25,
                            PriceBaby = 0,
                        }
                    );
                }
            }

            context.SaveChanges();

            var services = new Dictionary<double, Dictionary<string, string>>
            {
                {
                    50.0, new Dictionary<string, string>
                    {
                        {"AR", "نقل المطار"},
                        {"EN", "Airport transfers"},
                        {"ES", "Traslados aeropuerto"},
                        {"FR", "Transferts aéroport"}
                    }
                },
                {
                    25.0, new Dictionary<string, string>
                    {
                        {"AR", "قاعة الرياضة"},
                        {"EN", "Fitness hall"},
                        {"ES", "Sala de deportes"},
                        {"FR", "Salle de sport"}
                    }
                },
                {
                    20.0, new Dictionary<string, string>
                    {
                        {"AR", "بطاقة وسادة"},
                        {"EN", "Pillow card"},
                        {"ES", "Tarjeta de almohada"},
                        {"FR", "Carte d'oreillers"}
                    }
                },
            };
            foreach (var (price, languages) in services)
            {
                var serviceEntity = new Service
                {
                    ServicePrice = price
                };
                context.Services.Add(serviceEntity);
                context.SaveChanges();
                foreach (var (isoCode, translatedServiceName) in languages)
                {
                    context.ServiceLanguages.Add(
                        new ServiceLanguage
                        {
                            ServiceId = serviceEntity.ServiceId,
                            LanguageId = context.Languages.First(x => x.IsoCode == isoCode).LanguageId,
                            ServiceName = translatedServiceName
                        });
                }

                context.SaveChanges();
            }

            var extras = new Dictionary<double, Dictionary<string, string>>
            {
                {
                    50.0, new Dictionary<string, string>
                    {
                        {"AR", "تدليك"},
                        {"EN", "Massage"},
                        {"ES", "Masaje"},
                        {"FR", "Massage"}
                    }
                },
                {
                    35.0, new Dictionary<string, string>
                    {
                        {"AR", "الراحة النفسية"},
                        {"EN", "SPA and wellness"},
                        {"ES", "SPA y bien estar"},
                        {"FR", "SPA et bien-être"}
                    }
                },
            };
            foreach (var (price, languages) in extras)
            {
                var extraEntity = new Extra
                {
                    ExtraPrice = price
                };
                context.Extras.Add(extraEntity);
                context.SaveChanges();
                foreach (var (isoCode, translatedServiceName) in languages)
                {
                    context.ExtraLanguages.Add(
                        new ExtraLanguage
                        {
                            ExtraId = extraEntity.ExtraId,
                            LanguageId = context.Languages.First(x => x.IsoCode == isoCode).LanguageId,
                            ExtraName = translatedServiceName
                        });
                }

                context.SaveChanges();
            }

            context.VillaMedias.AddRange(
                new VillaMedia
                {
                    MediaName = "duchess-villa-1",
                    VillaId = context.Villas.Single(x => x.VillaPath == "duchess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "duchess-villa-2",
                    VillaId = context.Villas.Single(x => x.VillaPath == "duchess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "duchess-villa-3",
                    VillaId = context.Villas.Single(x => x.VillaPath == "duchess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "duchess-villa-4",
                    VillaId = context.Villas.Single(x => x.VillaPath == "duchess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "duchess-villa-5",
                    VillaId = context.Villas.Single(x => x.VillaPath == "duchess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "duchess-villa-6",
                    VillaId = context.Villas.Single(x => x.VillaPath == "duchess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "duchess-villa-7",
                    VillaId = context.Villas.Single(x => x.VillaPath == "duchess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "gran-duchess-villa-1",
                    VillaId = context.Villas.Single(x => x.VillaPath == "gran-duchess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "gran-duchess-villa-2",
                    VillaId = context.Villas.Single(x => x.VillaPath == "gran-duchess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "gran-duchess-villa-3",
                    VillaId = context.Villas.Single(x => x.VillaPath == "gran-duchess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "gran-duchess-villa-4",
                    VillaId = context.Villas.Single(x => x.VillaPath == "gran-duchess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "gran-duchess-villa-5",
                    VillaId = context.Villas.Single(x => x.VillaPath == "gran-duchess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "princess-villa-1",
                    VillaId = context.Villas.Single(x => x.VillaPath == "princess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "princess-villa-2",
                    VillaId = context.Villas.Single(x => x.VillaPath == "princess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "princess-villa-3",
                    VillaId = context.Villas.Single(x => x.VillaPath == "princess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "princess-villa-4",
                    VillaId = context.Villas.Single(x => x.VillaPath == "princess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "gran-princess-villa-1",
                    VillaId = context.Villas.Single(x => x.VillaPath == "gran-princess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "gran-princess-villa-2",
                    VillaId = context.Villas.Single(x => x.VillaPath == "gran-princess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "gran-princess-villa-3",
                    VillaId = context.Villas.Single(x => x.VillaPath == "gran-princess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "gran-princess-villa-4",
                    VillaId = context.Villas.Single(x => x.VillaPath == "gran-princess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "royal-princess-villa-1",
                    VillaId = context.Villas.Single(x => x.VillaPath == "royal-princess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "royal-princess-villa-2",
                    VillaId = context.Villas.Single(x => x.VillaPath == "royal-princess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "royal-princess-villa-3",
                    VillaId = context.Villas.Single(x => x.VillaPath == "royal-princess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "royal-princess-villa-4",
                    VillaId = context.Villas.Single(x => x.VillaPath == "royal-princess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "royal-princess-villa-5",
                    VillaId = context.Villas.Single(x => x.VillaPath == "royal-princess-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "majestic-villa-1",
                    VillaId = context.Villas.Single(x => x.VillaPath == "majestic-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "majestic-villa-2",
                    VillaId = context.Villas.Single(x => x.VillaPath == "majestic-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "majestic-villa-3",
                    VillaId = context.Villas.Single(x => x.VillaPath == "majestic-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "majestic-villa-4",
                    VillaId = context.Villas.Single(x => x.VillaPath == "majestic-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "majestic-villa-5",
                    VillaId = context.Villas.Single(x => x.VillaPath == "majestic-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "majestic-villa-6",
                    VillaId = context.Villas.Single(x => x.VillaPath == "majestic-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "majestic-villa-7",
                    VillaId = context.Villas.Single(x => x.VillaPath == "majestic-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "majestic-villa-8",
                    VillaId = context.Villas.Single(x => x.VillaPath == "majestic-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "gran-majestic-villa-1",
                    VillaId = context.Villas.Single(x => x.VillaPath == "gran-majestic-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "gran-majestic-villa-2",
                    VillaId = context.Villas.Single(x => x.VillaPath == "gran-majestic-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "gran-majestic-villa-3",
                    VillaId = context.Villas.Single(x => x.VillaPath == "gran-majestic-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "gran-majestic-villa-4",
                    VillaId = context.Villas.Single(x => x.VillaPath == "gran-majestic-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "gran-majestic-villa-5",
                    VillaId = context.Villas.Single(x => x.VillaPath == "gran-majestic-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "queen-villa-1",
                    VillaId = context.Villas.Single(x => x.VillaPath == "queen-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "queen-villa-2",
                    VillaId = context.Villas.Single(x => x.VillaPath == "queen-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "queen-villa-3",
                    VillaId = context.Villas.Single(x => x.VillaPath == "queen-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "queen-villa-4",
                    VillaId = context.Villas.Single(x => x.VillaPath == "queen-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "queen-villa-5",
                    VillaId = context.Villas.Single(x => x.VillaPath == "queen-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "queen-villa-6",
                    VillaId = context.Villas.Single(x => x.VillaPath == "queen-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "queen-villa-7",
                    VillaId = context.Villas.Single(x => x.VillaPath == "queen-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "queen-villa-8",
                    VillaId = context.Villas.Single(x => x.VillaPath == "queen-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "royal-villa-1",
                    VillaId = context.Villas.Single(x => x.VillaPath == "royal-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "royal-villa-2",
                    VillaId = context.Villas.Single(x => x.VillaPath == "royal-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "royal-villa-3",
                    VillaId = context.Villas.Single(x => x.VillaPath == "royal-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "royal-villa-4",
                    VillaId = context.Villas.Single(x => x.VillaPath == "royal-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "imperial-villa-1",
                    VillaId = context.Villas.Single(x => x.VillaPath == "imperial-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "imperial-villa-2",
                    VillaId = context.Villas.Single(x => x.VillaPath == "imperial-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "imperial-villa-3",
                    VillaId = context.Villas.Single(x => x.VillaPath == "imperial-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "imperial-villa-4",
                    VillaId = context.Villas.Single(x => x.VillaPath == "imperial-villa").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "queen-villa-with-pavillon-1",
                    VillaId = context.Villas.Single(x => x.VillaPath == "queen-villa-with-pavillon").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "queen-villa-with-pavillon-2",
                    VillaId = context.Villas.Single(x => x.VillaPath == "queen-villa-with-pavillon").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "queen-villa-with-pavillon-3",
                    VillaId = context.Villas.Single(x => x.VillaPath == "queen-villa-with-pavillon").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "queen-villa-with-pavillon-4",
                    VillaId = context.Villas.Single(x => x.VillaPath == "queen-villa-with-pavillon").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "queen-villa-with-pavillon-5",
                    VillaId = context.Villas.Single(x => x.VillaPath == "queen-villa-with-pavillon").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "queen-villa-with-pavillon-6",
                    VillaId = context.Villas.Single(x => x.VillaPath == "queen-villa-with-pavillon").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "queen-villa-with-pavillon-7",
                    VillaId = context.Villas.Single(x => x.VillaPath == "queen-villa-with-pavillon").VillaId,
                },
                new VillaMedia
                {
                    MediaName = "queen-villa-with-pavillon-8",
                    VillaId = context.Villas.Single(x => x.VillaPath == "queen-villa-with-pavillon").VillaId,
                });

            context.SaveChanges();

            var bookedVilla = context.Villas.Take(1).First();

            context.Reservations.AddRange(
                new Reservation
                {
                    CustomerId = context
                        .Customers
                        .Single(x => x.Email == "dolores.poveda@gmail.com")
                        .CustomerId,
                    VillaId = bookedVilla.VillaId,
                    FormulaId = context.VillaFormulas
                        .Where(x => x.VillaId == bookedVilla.VillaId)
                        .Take(1)
                        .First()
                        .FormulaId,
                    NumberAdults = 2,
                    NumberChildren = 0,
                    NumberBabies = 0,
                    ReservationDate = DateTime.Now,
                    ReservationPrice = 0.0,
                    PriceChoice = EPriceChoice.PriceOnline,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(8),
                });

            context.SaveChanges();
        }
    }
}
/*
      new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "ICON").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    EquipmentName = @"",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "ICON").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    EquipmentName = @"",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "ICON").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    EquipmentName = @"",
                },
                new EquipmentLanguage
                {
                    EquipmentId = context.Equipments.First(x => x.IconFile == "ICON").EquipmentId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    EquipmentName = @"",
                }
 */
/*
                 new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Gran Duchess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "AR").LanguageId,
                    Description = @""
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Gran Duchess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "EN").LanguageId,
                    Description = @""
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Gran Duchess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "ES").LanguageId,
                    Description = @""
                },
                new VillaLanguage
                {
                    VillaId = context.Villas.First(x => x.VillaName == "Gran Duchess Villa").VillaId,
                    LanguageId = context.Languages.First(x => x.IsoCode == "FR").LanguageId,
                    Description = @""
                }
*/