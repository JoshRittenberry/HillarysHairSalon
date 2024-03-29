using Microsoft.EntityFrameworkCore;
using HillarysHairSalon.Models;

public class HillarysHairSalonDbContext : DbContext
{
    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<AppointmentService> AppointmentServices { get; set; }

    public HillarysHairSalonDbContext(DbContextOptions<HillarysHairSalonDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stylist>().HasData(new Stylist[]
        {
            new Stylist { Id = 1, FirstName = "Hillary", LastName = "Johnson", PhoneNumber = 1234567890, Email = "hillary@example.com", Password = "password1", StartDate = new DateTime(2018, 1, 1), EndDate = null, IsActive = true, IsAdmin = true },
            new Stylist { Id = 2, FirstName = "James", LastName = "Smith", PhoneNumber = 1234567891, Email = "james@example.com", Password = "password2", StartDate = new DateTime(2019, 5, 10), EndDate = null, IsActive = true, IsAdmin = false },
            new Stylist { Id = 3, FirstName = "Emily", LastName = "Davis", PhoneNumber = 1234567892, Email = "emily@example.com", Password = "password3", StartDate = new DateTime(2020, 6, 15), EndDate = null, IsActive = true, IsAdmin = false },
            new Stylist { Id = 4, FirstName = "Michael", LastName = "Brown", PhoneNumber = 1234567893, Email = "michael@example.com", Password = "password4", StartDate = new DateTime(2021, 3, 20), EndDate = null, IsActive = true, IsAdmin = false },
            new Stylist { Id = 5, FirstName = "Sophia", LastName = "Miller", PhoneNumber = 1234567894, Email = "sophia@example.com", Password = "password5", StartDate = new DateTime(2022, 7, 30), EndDate = new DateTime(2023, 12, 31), IsActive = false, IsAdmin = false },
            new Stylist { Id = 6, FirstName = "Lucas", LastName = "Wilson", PhoneNumber = 1234567895, Email = "lucas@example.com", Password = "password6", StartDate = new DateTime(2023, 1, 25), EndDate = new DateTime(2023, 11, 5), IsActive = false, IsAdmin = false }
        });

        modelBuilder.Entity<Customer>().HasData(new Customer[]
        {
            new Customer { Id = 1, FirstName = "John", LastName = "Doe", PhoneNumber = 1000000001, Email = "john.doe@example.com" },
            new Customer { Id = 2, FirstName = "Jane", LastName = "Smith", PhoneNumber = 1000000002, Email = "jane.smith@example.com" },
            new Customer { Id = 3, FirstName = "Emily", LastName = "Johnson", PhoneNumber = 1000000003, Email = "emily.johnson@example.com" },
            new Customer { Id = 4, FirstName = "Michael", LastName = "Williams", PhoneNumber = 1000000004, Email = "michael.williams@example.com" },
            new Customer { Id = 5, FirstName = "David", LastName = "Brown", PhoneNumber = 1000000005, Email = "david.brown@example.com" },
            new Customer { Id = 6, FirstName = "Sarah", LastName = "Davis", PhoneNumber = 1000000006, Email = "sarah.davis@example.com" },
            new Customer { Id = 7, FirstName = "Chris", LastName = "Miller", PhoneNumber = 1000000007, Email = "chris.miller@example.com" },
            new Customer { Id = 8, FirstName = "Anna", LastName = "Wilson", PhoneNumber = 1000000008, Email = "anna.wilson@example.com" },
            new Customer { Id = 9, FirstName = "James", LastName = "Moore", PhoneNumber = 1000000009, Email = "james.moore@example.com" },
            new Customer { Id = 10, FirstName = "Linda", LastName = "Taylor", PhoneNumber = 1000000010, Email = "linda.taylor@example.com" },
            new Customer { Id = 11, FirstName = "Robert", LastName = "Anderson", PhoneNumber = 1000000011, Email = "robert.anderson@example.com" },
            new Customer { Id = 12, FirstName = "Patricia", LastName = "Thomas", PhoneNumber = 1000000012, Email = "patricia.thomas@example.com" },
            new Customer { Id = 13, FirstName = "Mark", LastName = "Jackson", PhoneNumber = 1000000013, Email = "mark.jackson@example.com" },
            new Customer { Id = 14, FirstName = "Elizabeth", LastName = "White", PhoneNumber = 1000000014, Email = "elizabeth.white@example.com" },
            new Customer { Id = 15, FirstName = "Joseph", LastName = "Harris", PhoneNumber = 1000000015, Email = "joseph.harris@example.com" },
            new Customer { Id = 16, FirstName = "Susan", LastName = "Martin", PhoneNumber = 1000000016, Email = "susan.martin@example.com" },
            new Customer { Id = 17, FirstName = "Thomas", LastName = "Garcia", PhoneNumber = 1000000017, Email = "thomas.garcia@example.com" },
            new Customer { Id = 18, FirstName = "Jessica", LastName = "Rodriguez", PhoneNumber = 1000000018, Email = "jessica.rodriguez@example.com" }
        });

        modelBuilder.Entity<Appointment>().HasData(new Appointment[]
        {
            new Appointment { Id = 1, StylistId = 4, CustomerId = 15, Scheduled = new DateTime(2024, 1, 1, 9, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 2, StylistId = 3, CustomerId = 8, Scheduled = new DateTime(2024, 1, 1, 9, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 3, StylistId = 1, CustomerId = 5, Scheduled = new DateTime(2024, 1, 1, 10, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 4, StylistId = 2, CustomerId = 18, Scheduled = new DateTime(2024, 1, 1, 14, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 5, StylistId = 6, CustomerId = 4, Scheduled = new DateTime(2024, 1, 1, 16, 0, 0), IsComplete = true, IsCanceled = true },
            new Appointment { Id = 6, StylistId = 5, CustomerId = 2, Scheduled = new DateTime(2024, 1, 1, 15, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 7, StylistId = 4, CustomerId = 11, Scheduled = new DateTime(2024, 1, 1, 11, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 8, StylistId = 3, CustomerId = 16, Scheduled = new DateTime(2024, 1, 1, 11, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 9, StylistId = 1, CustomerId = 6, Scheduled = new DateTime(2024, 1, 1, 12, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 10, StylistId = 2, CustomerId = 17, Scheduled = new DateTime(2024, 1, 1, 15, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 11, StylistId = 6, CustomerId = 14, Scheduled = new DateTime(2024, 1, 1, 13, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 12, StylistId = 5, CustomerId = 10, Scheduled = new DateTime(2024, 1, 1, 14, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 13, StylistId = 4, CustomerId = 9, Scheduled = new DateTime(2024, 1, 1, 10, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 14, StylistId = 3, CustomerId = 13, Scheduled = new DateTime(2024, 1, 2, 10, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 15, StylistId = 1, CustomerId = 7, Scheduled = new DateTime(2024, 1, 2, 11, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 16, StylistId = 2, CustomerId = 1, Scheduled = new DateTime(2024, 1, 2, 1, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 17, StylistId = 1, CustomerId = 3, Scheduled = new DateTime(2024, 1, 2, 13, 0, 0), IsComplete = true, IsCanceled = true },
            new Appointment { Id = 18, StylistId = 5, CustomerId = 1, Scheduled = new DateTime(2024, 1, 2, 14, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 19, StylistId = 4, CustomerId = 12, Scheduled = new DateTime(2024, 1, 2, 9, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 20, StylistId = 3, CustomerId = 5, Scheduled = new DateTime(2024, 1, 2, 11, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 21, StylistId = 1, CustomerId = 11, Scheduled = new DateTime(2024, 1, 2, 12, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 22, StylistId = 2, CustomerId = 3, Scheduled = new DateTime(2024, 1, 2, 2, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 23, StylistId = 1, CustomerId = 5, Scheduled = new DateTime(2024, 1, 2, 13, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 24, StylistId = 5, CustomerId = 6, Scheduled = new DateTime(2024, 1, 3, 14, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 25, StylistId = 4, CustomerId = 7, Scheduled = new DateTime(2024, 1, 3, 9, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 26, StylistId = 3, CustomerId = 1, Scheduled = new DateTime(2024, 1, 3, 10, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 27, StylistId = 1, CustomerId = 2, Scheduled = new DateTime(2024, 1, 3, 11, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 28, StylistId = 2, CustomerId = 3, Scheduled = new DateTime(2024, 1, 3, 1, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 29, StylistId = 1, CustomerId = 4, Scheduled = new DateTime(2024, 1, 3, 13, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 30, StylistId = 5, CustomerId = 5, Scheduled = new DateTime(2024, 1, 3, 14, 0, 0), IsComplete = true, IsCanceled = true },
            new Appointment { Id = 31, StylistId = 4, CustomerId = 6, Scheduled = new DateTime(2024, 1, 3, 10, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 32, StylistId = 3, CustomerId = 7, Scheduled = new DateTime(2024, 1, 3, 11, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 33, StylistId = 1, CustomerId = 8, Scheduled = new DateTime(2024, 1, 3, 12, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 34, StylistId = 2, CustomerId = 9, Scheduled = new DateTime(2024, 1, 3, 12, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 35, StylistId = 1, CustomerId = 10, Scheduled = new DateTime(2024, 1, 3, 14, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 36, StylistId = 3, CustomerId = 11, Scheduled = new DateTime(2024, 1, 4, 14, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 37, StylistId = 4, CustomerId = 12, Scheduled = new DateTime(2024, 1, 4, 9, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 38, StylistId = 3, CustomerId = 13, Scheduled = new DateTime(2024, 1, 4, 10, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 39, StylistId = 1, CustomerId = 14, Scheduled = new DateTime(2024, 1, 4, 11, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 40, StylistId = 2, CustomerId = 15, Scheduled = new DateTime(2024, 1, 4, 12, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 41, StylistId = 1, CustomerId = 16, Scheduled = new DateTime(2024, 1, 4, 13, 0, 0), IsComplete = true, IsCanceled = true },
            new Appointment { Id = 42, StylistId = 3, CustomerId = 17, Scheduled = new DateTime(2024, 1, 4, 15, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 43, StylistId = 4, CustomerId = 18, Scheduled = new DateTime(2024, 1, 4, 10, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 44, StylistId = 3, CustomerId = 1, Scheduled = new DateTime(2024, 1, 4, 11, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 45, StylistId = 1, CustomerId = 2, Scheduled = new DateTime(2024, 1, 4, 12, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 46, StylistId = 2, CustomerId = 1, Scheduled = new DateTime(2024, 1, 4, 13, 0, 0), IsComplete = true, IsCanceled = false },
            new Appointment { Id = 47, StylistId = 1, CustomerId = 2, Scheduled = new DateTime(2024, 1, 5, 13, 0, 0), IsComplete = false, IsCanceled = false },
            new Appointment { Id = 48, StylistId = 3, CustomerId = 3, Scheduled = new DateTime(2024, 1, 5, 14, 0, 0), IsComplete = false, IsCanceled = false },
            new Appointment { Id = 49, StylistId = 4, CustomerId = 4, Scheduled = new DateTime(2024, 1, 5, 9, 0, 0), IsComplete = false, IsCanceled = false },
            new Appointment { Id = 50, StylistId = 3, CustomerId = 5, Scheduled = new DateTime(2024, 1, 5, 10, 0, 0), IsComplete = false, IsCanceled = false },
            new Appointment { Id = 51, StylistId = 1, CustomerId = 6, Scheduled = new DateTime(2024, 1, 5, 11, 0, 0), IsComplete = false, IsCanceled = false },
            new Appointment { Id = 52, StylistId = 2, CustomerId = 7, Scheduled = new DateTime(2024, 1, 5, 12, 0, 0), IsComplete = false, IsCanceled = false },
            new Appointment { Id = 53, StylistId = 1, CustomerId = 8, Scheduled = new DateTime(2024, 1, 5, 14, 0, 0), IsComplete = false, IsCanceled = false },
            new Appointment { Id = 54, StylistId = 3, CustomerId = 9, Scheduled = new DateTime(2024, 1, 5, 15, 0, 0), IsComplete = false, IsCanceled = false },
            new Appointment { Id = 55, StylistId = 4, CustomerId = 10, Scheduled = new DateTime(2024, 1, 8, 9, 0, 0), IsComplete = false, IsCanceled = false },
            new Appointment { Id = 56, StylistId = 3, CustomerId = 11, Scheduled = new DateTime(2024, 1, 8, 10, 0, 0), IsComplete = false, IsCanceled = false },
            new Appointment { Id = 57, StylistId = 1, CustomerId = 12, Scheduled = new DateTime(2024, 1, 9, 11, 0, 0), IsComplete = false, IsCanceled = false },
            new Appointment { Id = 58, StylistId = 2, CustomerId = 13, Scheduled = new DateTime(2024, 1, 12, 12, 0, 0), IsComplete = false, IsCanceled = false },
            new Appointment { Id = 59, StylistId = 1, CustomerId = 14, Scheduled = new DateTime(2024, 1, 10, 13, 0, 0), IsComplete = false, IsCanceled = true },
            new Appointment { Id = 60, StylistId = 3, CustomerId = 15, Scheduled = new DateTime(2024, 1, 12, 14, 0, 0), IsComplete = false, IsCanceled = false },
        });


        modelBuilder.Entity<Service>().HasData(new Service[]
        {
            new Service { Id = 1, Name = "Women's Haircut", Cost = 45.0m },
            new Service { Id = 2, Name = "Men's Haircut", Cost = 25.0m },
            new Service { Id = 3, Name = "Hair Coloring", Cost = 70.0m },
            new Service { Id = 4, Name = "Partial Highlights", Cost = 55.0m },
            new Service { Id = 5, Name = "Full Highlights", Cost = 85.0m },
            new Service { Id = 6, Name = "Blow Dry", Cost = 20.0m },
            new Service { Id = 7, Name = "Keratin Treatment", Cost = 120.0m },
            new Service { Id = 8, Name = "Deep Conditioning Treatment", Cost = 30.0m },
            new Service { Id = 9, Name = "Simple Updo", Cost = 40.0m },
            new Service { Id = 10, Name = "Elaborate Updo", Cost = 60.0m },
            new Service { Id = 11, Name = "Perm", Cost = 60.0m },
            new Service { Id = 12, Name = "Beard Trim", Cost = 15.0m },
            new Service { Id = 13, Name = "Men's Shave", Cost = 20.0m },
            new Service { Id = 14, Name = "Men's Hair and Beard Package", Cost = 35.0m },
            new Service { Id = 15, Name = "Eyebrow Shaping", Cost = 15.0m }
        });

        modelBuilder.Entity<AppointmentService>().HasData(new AppointmentService[]
        {
            new AppointmentService { Id = 1, AppointmentId = 1, ServiceId = 1 },
            new AppointmentService { Id = 2, AppointmentId = 1, ServiceId = 3 },
            new AppointmentService { Id = 3, AppointmentId = 2, ServiceId = 2 },
            new AppointmentService { Id = 4, AppointmentId = 2, ServiceId = 12 },
            new AppointmentService { Id = 5, AppointmentId = 3, ServiceId = 5 },
            new AppointmentService { Id = 6, AppointmentId = 4, ServiceId = 4 },
            new AppointmentService { Id = 7, AppointmentId = 4, ServiceId = 6 },
            new AppointmentService { Id = 8, AppointmentId = 5, ServiceId = 7 },
            new AppointmentService { Id = 9, AppointmentId = 6, ServiceId = 8 },
            new AppointmentService { Id = 10, AppointmentId = 7, ServiceId = 9 },
            new AppointmentService { Id = 11, AppointmentId = 7, ServiceId = 11 },
            new AppointmentService { Id = 12, AppointmentId = 8, ServiceId = 10 },
            new AppointmentService { Id = 13, AppointmentId = 9, ServiceId = 1 },
            new AppointmentService { Id = 14, AppointmentId = 9, ServiceId = 3 },
            new AppointmentService { Id = 15, AppointmentId = 10, ServiceId = 2 },
            new AppointmentService { Id = 16, AppointmentId = 11, ServiceId = 4 },
            new AppointmentService { Id = 17, AppointmentId = 12, ServiceId = 5 },
            new AppointmentService { Id = 18, AppointmentId = 13, ServiceId = 6 },
            new AppointmentService { Id = 19, AppointmentId = 14, ServiceId = 1 },
            new AppointmentService { Id = 20, AppointmentId = 14, ServiceId = 6 },
            new AppointmentService { Id = 21, AppointmentId = 15, ServiceId = 2 },
            new AppointmentService { Id = 22, AppointmentId = 15, ServiceId = 5 },
            new AppointmentService { Id = 23, AppointmentId = 16, ServiceId = 3 },
            new AppointmentService { Id = 24, AppointmentId = 16, ServiceId = 8 },
            new AppointmentService { Id = 25, AppointmentId = 17, ServiceId = 7 },
            new AppointmentService { Id = 26, AppointmentId = 17, ServiceId = 9 },
            new AppointmentService { Id = 27, AppointmentId = 18, ServiceId = 4 },
            new AppointmentService { Id = 28, AppointmentId = 18, ServiceId = 10 },
            new AppointmentService { Id = 29, AppointmentId = 19, ServiceId = 11 },
            new AppointmentService { Id = 30, AppointmentId = 19, ServiceId = 12 },
            new AppointmentService { Id = 31, AppointmentId = 20, ServiceId = 13 },
            new AppointmentService { Id = 32, AppointmentId = 20, ServiceId = 1 },
            new AppointmentService { Id = 33, AppointmentId = 21, ServiceId = 2 },
            new AppointmentService { Id = 34, AppointmentId = 21, ServiceId = 3 },
            new AppointmentService { Id = 35, AppointmentId = 22, ServiceId = 5 },
            new AppointmentService { Id = 36, AppointmentId = 22, ServiceId = 6 },
            new AppointmentService { Id = 37, AppointmentId = 23, ServiceId = 7 },
            new AppointmentService { Id = 38, AppointmentId = 23, ServiceId = 8 },
            new AppointmentService { Id = 39, AppointmentId = 24, ServiceId = 1 },
            new AppointmentService { Id = 40, AppointmentId = 24, ServiceId = 7 },
            new AppointmentService { Id = 41, AppointmentId = 25, ServiceId = 2 },
            new AppointmentService { Id = 42, AppointmentId = 25, ServiceId = 6 },
            new AppointmentService { Id = 43, AppointmentId = 26, ServiceId = 3 },
            new AppointmentService { Id = 44, AppointmentId = 27, ServiceId = 4 },
            new AppointmentService { Id = 45, AppointmentId = 27, ServiceId = 8 },
            new AppointmentService { Id = 46, AppointmentId = 28, ServiceId = 5 },
            new AppointmentService { Id = 47, AppointmentId = 29, ServiceId = 9 },
            new AppointmentService { Id = 48, AppointmentId = 30, ServiceId = 10 },
            new AppointmentService { Id = 49, AppointmentId = 31, ServiceId = 11 },
            new AppointmentService { Id = 50, AppointmentId = 32, ServiceId = 12 },
            new AppointmentService { Id = 51, AppointmentId = 33, ServiceId = 13 },
            new AppointmentService { Id = 52, AppointmentId = 33, ServiceId = 1 },
            new AppointmentService { Id = 53, AppointmentId = 34, ServiceId = 2 },
            new AppointmentService { Id = 54, AppointmentId = 35, ServiceId = 3 },
            new AppointmentService { Id = 55, AppointmentId = 35, ServiceId = 4 },
            new AppointmentService { Id = 56, AppointmentId = 36, ServiceId = 6 },
            new AppointmentService { Id = 57, AppointmentId = 36, ServiceId = 7 },
            new AppointmentService { Id = 58, AppointmentId = 37, ServiceId = 9 },
            new AppointmentService { Id = 59, AppointmentId = 37, ServiceId = 12 },
            new AppointmentService { Id = 60, AppointmentId = 38, ServiceId = 7 },
            new AppointmentService { Id = 61, AppointmentId = 38, ServiceId = 4 },
            new AppointmentService { Id = 62, AppointmentId = 38, ServiceId = 5 },
            new AppointmentService { Id = 63, AppointmentId = 39, ServiceId = 7 },
            new AppointmentService { Id = 64, AppointmentId = 40, ServiceId = 3 },
            new AppointmentService { Id = 65, AppointmentId = 41, ServiceId = 8 },
            new AppointmentService { Id = 66, AppointmentId = 41, ServiceId = 11 },
            new AppointmentService { Id = 67, AppointmentId = 41, ServiceId = 7 },
            new AppointmentService { Id = 68, AppointmentId = 42, ServiceId = 15 },
            new AppointmentService { Id = 69, AppointmentId = 42, ServiceId = 6 },
            new AppointmentService { Id = 70, AppointmentId = 42, ServiceId = 8 },
            new AppointmentService { Id = 71, AppointmentId = 43, ServiceId = 1 },
            new AppointmentService { Id = 72, AppointmentId = 43, ServiceId = 5 },
            new AppointmentService { Id = 73, AppointmentId = 43, ServiceId = 10 },
            new AppointmentService { Id = 74, AppointmentId = 44, ServiceId = 3 },
            new AppointmentService { Id = 75, AppointmentId = 44, ServiceId = 4 },
            new AppointmentService { Id = 76, AppointmentId = 45, ServiceId = 14 },
            new AppointmentService { Id = 77, AppointmentId = 45, ServiceId = 10 },
            new AppointmentService { Id = 78, AppointmentId = 45, ServiceId = 5 },
            new AppointmentService { Id = 79, AppointmentId = 46, ServiceId = 6 },
            new AppointmentService { Id = 80, AppointmentId = 46, ServiceId = 11 },
            new AppointmentService { Id = 81, AppointmentId = 47, ServiceId = 1 },
            new AppointmentService { Id = 82, AppointmentId = 48, ServiceId = 14 },
            new AppointmentService { Id = 83, AppointmentId = 49, ServiceId = 12 },
            new AppointmentService { Id = 84, AppointmentId = 50, ServiceId = 9 },
            new AppointmentService { Id = 85, AppointmentId = 51, ServiceId = 13 },
            new AppointmentService { Id = 86, AppointmentId = 51, ServiceId = 8 },
            new AppointmentService { Id = 87, AppointmentId = 51, ServiceId = 2 },
            new AppointmentService { Id = 88, AppointmentId = 52, ServiceId = 11 },
            new AppointmentService { Id = 89, AppointmentId = 52, ServiceId = 12 },
            new AppointmentService { Id = 90, AppointmentId = 52, ServiceId = 6 },
            new AppointmentService { Id = 91, AppointmentId = 53, ServiceId = 8 },
            new AppointmentService { Id = 92, AppointmentId = 54, ServiceId = 10 },
            new AppointmentService { Id = 93, AppointmentId = 55, ServiceId = 15 },
            new AppointmentService { Id = 94, AppointmentId = 56, ServiceId = 6 },
            new AppointmentService { Id = 95, AppointmentId = 56, ServiceId = 14 },
            new AppointmentService { Id = 96, AppointmentId = 56, ServiceId = 7 },
            new AppointmentService { Id = 97, AppointmentId = 57, ServiceId = 3 },
            new AppointmentService { Id = 98, AppointmentId = 58, ServiceId = 8 },
            new AppointmentService { Id = 99, AppointmentId = 58, ServiceId = 4 },
            new AppointmentService { Id = 100, AppointmentId = 59, ServiceId = 13 },
            new AppointmentService { Id = 101, AppointmentId = 59, ServiceId = 9 },
            new AppointmentService { Id = 102, AppointmentId = 60, ServiceId = 5 }
        });

    }
}