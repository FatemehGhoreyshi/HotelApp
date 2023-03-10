using Domain.Infrastructure.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Test
{
    public class ApplicationDbContextShould
    {
        [Fact]
        public void CreateDatabase()
        {
            using var db = CreateContext();
        }

        private static ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder()
                                .UseSqlite("Data Source=TestBookingHotelDB.db")
                                .Options;

            var db = new ApplicationDbContext(options);

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            return db;
        }

        [Fact]
        public void CreateApplicationUser()
        {
            using var db = CreateContext();

            var user = new ApplicationUser
            {
                Name = "John Smith",
                UserName = "smith",
                Email = "smith@gmail.com",
                IsActive = true,
                Phone = "1234567890",
                Role = ApplicationRole.Customer
            };

            // Act -> Eghdam

            db.ApplicationUsers.Add(user);
            db.SaveChanges();

            // Assert -> Ezhar, Edea

            Assert.IsType<ApplicationUser>(user);
        }

        [Fact]
        public void CreateApplicationUser_NotType()
        {
            using var db = CreateContext();

            var user = new ApplicationUser
            {
                Name = "John Smith",
                UserName = "smith",
                Email = "smith@gmail.com",
                IsActive = true,
                Phone = "1234567890",
                Role = ApplicationRole.Customer
            };

            // Act -> Eghdam

            db.ApplicationUsers.Add(user);
            db.SaveChanges();

            // Assert -> Ezhar, Edea

            Assert.IsNotType<RoomType>(user);
        }

        [Fact]
        public void CreateRoomType()
        {
            // Arrange

            using var db = CreateContext();

            var roomType = new RoomType
            {
                Title = "Royal",
                Description = "This is a royal room type.",
                IsAvailable = true,
            };

            // Act

            db.RoomTypes.Add(roomType);
            db.SaveChanges();

            // Assert

            Assert.IsType<RoomType>(roomType);
        }

        [Fact]
        public void CreateRoomType_NotType()
        {
            // Arrange

            using var db = CreateContext();

            var roomType = new RoomType
            {
                Title = "Royal",
                Description = "This is a royal room type.",
                IsAvailable = true,
            };

            // Act

            db.RoomTypes.Add(roomType);
            db.SaveChanges();

            // Assert

            Assert.IsNotType<Customer>(roomType);
        }

        [Fact]
        public void CreateRoom_With_RoomType_Entity()
        {
            // Arrange

            using var db = CreateContext();

            var room = new Room
            {
                Title = "102",
                Description = "The room number is 102.",
                Price = (decimal)20,
                Status = RoomStatus.Maintenance,
                RoomType = new RoomType
                {
                    Title = "Royal",
                    Description = "A royal room.",
                    IsAvailable = true,
                }
            };

            // Act

            db.Rooms.Add(room);
            db.SaveChanges();

            // Assert

            Assert.IsType<Room>(room);
        }

        [Fact]
        public void CreateRoom()
        {
            // Arrange

            using var db = CreateContext();

            var room = new Room
            {
                Title = "102",
                Description = "The room number is 102.",
                Price = (decimal)20,
                Status = RoomStatus.Maintenance,
                RoomType = new RoomType
                {
                    Title = "3 Bed",
                    Description = "Test",
                    IsAvailable = true,

                }
            };

            // Act

            db.Rooms.Add(room);
            db.SaveChanges();

            // Assert

            Assert.IsType<Room>(room);
        }

        [Fact]
        public void CreateRoom_NotType()
        {
            // Arrange

            using var db = CreateContext();

            var room = new Room
            {
                Title = "102",
                Description = "The room number is 102.",
                Price = (decimal)20,
                Status = RoomStatus.Maintenance,
                RoomType = new RoomType
                {
                    Title = "Royal",
                    Description = "A royal room.",
                    IsAvailable = true,
                }
            };

            // Act

            db.Rooms.Add(room);
            db.SaveChanges();

            // Assert

            Assert.IsNotType<ApplicationUser>(room);
        }

        [Fact]
        public void CreateCustomer()
        {
            // Arrange

            using var db = CreateContext();

            var customer = new Customer
            {
                FirstName = "John",
                LastName = "Doe",
                Address = new Address("laar-Berg", "1100", "Wein"),
                Email = "doe@gmail.com",
                Gender = Gender.Male,
                Phone = "5162348567",
                Category = CustomerCategory.Adult,
                CustomerDetail = new CustomerDetail
                {
                    InsuranceNumber = 1234,
                    SocialNumber = 5678

                }

            };

            // Act

            db.Customers.Add(customer);
            db.SaveChanges();

            // Assert

            Assert.IsType<Customer>(customer);
        }

        [Fact]
        public void CreateCustomer_NotType()
        {
            using var db = CreateContext();

            var customer = new Customer
            {
                FirstName = "John",
                LastName = "Doe",
                Address = new Address("laar-Berg", "1100", "Wein"),
                Email = "doe@gmail.com",
                Gender = Gender.Male,
                Phone = "5162348567",
                Category = CustomerCategory.Adult,
                CustomerDetail = new CustomerDetail
                {
                    InsuranceNumber = 1234,
                    SocialNumber = 5678

                }
            };

            db.Customers.Add(customer);
            db.SaveChanges();

            Assert.IsNotType<Room>(customer);


        }

        [Fact]
        public void CreatePayment()
        {
            // Arrange

            using var db = CreateContext();

            var payment = new Payment
            {
                Customer = new Customer
                {
                    Address = new Address("Laar-berg","1100","Wien"),
                    Category = CustomerCategory.Adult,
                    CustomerDetail = new CustomerDetail
                    {
                        InsuranceNumber = 1234,
                        SocialNumber = 5678  
                    },
                    Email = "smit@gmail.com",
                    Gender= Gender.Male,
                    FirstName = "Ali",
                    LastName = "Alizade",
                    Phone = "12345678"
                },
                NightCount = 2,
                Tax = 10,
                PricePerNight = 20,
                TotalNightPrice = 40,
                Total = 50,
                PaymentTitle = "Mr. Smith has payed.",
                PaymentDate = DateTime.Now,
                //PaymentDate = new DateTime(2008, 04, 14),
                //PaymentDate = new DateTime(2023, 01, 01)
            };

            // Act

            db.Payments.Add(payment);
            db.SaveChanges();

            // Assert

            Assert.IsType<Payment>(payment);
        }

        [Fact]
        public void CreatePayment_NotType()
        {
            // Arrange

            using var db = CreateContext();

            var payment = new Payment
            {
                Customer = new Customer
                {
                    Address = new Address("Laar-berg", "1100", "Wien"),
                    Category = CustomerCategory.Adult,
                    CustomerDetail = new CustomerDetail
                    {
                        InsuranceNumber = 1234,
                        SocialNumber = 5678
                    },
                    Email = "smit@gmail.com",
                    Gender = Gender.Male,
                    FirstName = "Ali",
                    LastName = "Alizade",
                    Phone = "12345678"
                },
                NightCount = 2,
                Tax = 10,
                PricePerNight = 20,
                TotalNightPrice = 40,
                Total = 50,
                PaymentTitle = "Mr. Smith has payed.",
                PaymentDate = DateTime.Now,
                //PaymentDate = new DateTime(2008, 04, 14),
                //PaymentDate = new DateTime(2023, 01, 01)
            };

            // Act

            db.Payments.Add(payment);
            db.SaveChanges();

            // Assert

            Assert.IsNotType<Room>(payment);
        }



    }
}
