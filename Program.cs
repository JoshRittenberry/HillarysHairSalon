using HillarysHairSalon.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<HillarysHairSalonDbContext>(builder.Configuration["HillarysHairSalonDbConnectionString"]);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Get Endpoints

// 1. Endpoint to get all Appointments
app.MapGet("/api/appointments", (HillarysHairSalonDbContext db) =>
{
    return db.Appointments
        .Include(a => a.Stylist)
        .Include(a => a.Customer)
        .Include(a => a.AppointmentServices)
            .ThenInclude(aserv => aserv.Service)
        .Select(a => new AppointmentDTO
        {
            Id = a.Id,
            StylistId = a.StylistId,
            Stylist = new StylistDTO
            {
                Id = a.Stylist.Id,
                FirstName = a.Stylist.FirstName,
                LastName = a.Stylist.LastName,
                PhoneNumber = a.Stylist.PhoneNumber,
                Email = a.Stylist.Email,
                Password = a.Stylist.Password,
                StartDate = a.Stylist.StartDate,
                EndDate = a.Stylist.EndDate,
                IsActive = a.Stylist.IsActive,
                IsAdmin = a.Stylist.IsAdmin,
                Appointments = null
            },
            CustomerId = a.CustomerId,
            Customer = new CustomerDTO
            {
                Id = a.Customer.Id,
                FirstName = a.Customer.FirstName,
                LastName = a.Customer.LastName,
                PhoneNumber = a.Customer.PhoneNumber,
                Email = a.Customer.Email,
                Appointments = null
            },
            Scheduled = a.Scheduled,
            IsComplete = a.IsComplete,
            IsCanceled = a.IsCanceled,
            AppointmentServices = a.AppointmentServices.Select(aserv => new AppointmentServiceDTO
            {
                Id = aserv.Id,
                AppointmentId = aserv.AppointmentId,
                ServiceId = aserv.ServiceId,
                Service = new ServiceDTO
                {
                    Id = aserv.Service.Id,
                    Name = aserv.Service.Name,
                    Cost = aserv.Service.Cost
                }
            }).ToList(),
        })
        .ToList();
});

// 2. Endpoint to get an Appointment by Id
app.MapGet("/api/appointments/{id}", (HillarysHairSalonDbContext db, int id) =>
{
    var appointment = db.Appointments
        .Include(a => a.Stylist)
        .Include(a => a.Customer)
        .Include(a => a.AppointmentServices)
            .ThenInclude(aserv => aserv.Service)
        .SingleOrDefault(a => a.Id == id);

    return Results.Ok(new AppointmentDTO
    {
        Id = appointment.Id,
        StylistId = appointment.StylistId,
        Stylist = new StylistDTO
        {
            Id = appointment.Stylist.Id,
            FirstName = appointment.Stylist.FirstName,
            LastName = appointment.Stylist.LastName,
            PhoneNumber = appointment.Stylist.PhoneNumber,
            Email = appointment.Stylist.Email,
            Password = appointment.Stylist.Password,
            StartDate = appointment.Stylist.StartDate,
            EndDate = appointment.Stylist.EndDate,
            IsActive = appointment.Stylist.IsActive,
            IsAdmin = appointment.Stylist.IsAdmin,
            Appointments = null
        },
        CustomerId = appointment.CustomerId,
        Customer = new CustomerDTO
        {
            Id = appointment.Customer.Id,
            FirstName = appointment.Customer.FirstName,
            LastName = appointment.Customer.LastName,
            PhoneNumber = appointment.Customer.PhoneNumber,
            Email = appointment.Customer.Email,
            Appointments = null
        },
        Scheduled = appointment.Scheduled,
        IsComplete = appointment.IsComplete,
        IsCanceled = appointment.IsCanceled,
        AppointmentServices = appointment.AppointmentServices.Select(aserv => new AppointmentServiceDTO
        {
            Id = aserv.Id,
            AppointmentId = aserv.AppointmentId,
            ServiceId = aserv.ServiceId,
            Service = new ServiceDTO
            {
                Id = aserv.Service.Id,
                Name = aserv.Service.Name,
                Cost = aserv.Service.Cost
            }
        }).ToList(),
    });
});

// 3. Endpoint to get all Customers
app.MapGet("/api/customers", (HillarysHairSalonDbContext db) =>
{
    return db.Customers
        .Include(c => c.Appointments)
            .ThenInclude(a => a.AppointmentServices)
                .ThenInclude(aserv => aserv.Service)
            .Include(c => c.Appointments)
                .ThenInclude(a => a.Stylist)
        .Select(c => new CustomerDTO
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            PhoneNumber = c.PhoneNumber,
            Email = c.Email,
            Appointments = c.Appointments.Select(a => new AppointmentDTO
            {
                Id = a.Id,
                StylistId = a.StylistId,
                Stylist = new StylistDTO
                {
                    Id = a.Stylist.Id,
                    FirstName = a.Stylist.FirstName,
                    LastName = a.Stylist.LastName,
                    PhoneNumber = a.Stylist.PhoneNumber,
                    Email = a.Stylist.Email,
                    Password = a.Stylist.Password,
                    StartDate = a.Stylist.StartDate,
                    EndDate = a.Stylist.EndDate,
                    IsActive = a.Stylist.IsActive,
                    IsAdmin = a.Stylist.IsAdmin,
                    Appointments = null
                },
                CustomerId = a.CustomerId,
                Customer = null,
                Scheduled = a.Scheduled,
                IsComplete = a.IsComplete,
                IsCanceled = a.IsCanceled,
                AppointmentServices = a.AppointmentServices.Select(aserv => new AppointmentServiceDTO
                {
                    Id = aserv.Id,
                    AppointmentId = aserv.AppointmentId,
                    ServiceId = aserv.ServiceId,
                    Service = new ServiceDTO
                    {
                        Id = aserv.Service.Id,
                        Name = aserv.Service.Name,
                        Cost = aserv.Service.Cost
                    }
                }).ToList(),
            }).ToList()
        })
        .ToList();
});

// 4. Endpoint to get a Customer by Id
app.MapGet("/api/customers/{id}", (HillarysHairSalonDbContext db, int id) =>
{
    var customer = db.Customers
        .Include(c => c.Appointments)
            .ThenInclude(a => a.AppointmentServices)
                .ThenInclude(aserv => aserv.Service)
            .Include(c => c.Appointments)
                .ThenInclude(a => a.Stylist)
        .SingleOrDefault(a => a.Id == id);
    
    return Results.Ok(new CustomerDTO
    {
        Id = customer.Id,
        FirstName = customer.FirstName,
        LastName = customer.LastName,
        PhoneNumber = customer.PhoneNumber,
        Email = customer.Email,
        Appointments = customer.Appointments.Select(a => new AppointmentDTO
        {
            Id = a.Id,
            StylistId = a.StylistId,
            Stylist = new StylistDTO
            {
                Id = a.Stylist.Id,
                FirstName = a.Stylist.FirstName,
                LastName = a.Stylist.LastName,
                PhoneNumber = a.Stylist.PhoneNumber,
                Email = a.Stylist.Email,
                Password = a.Stylist.Password,
                StartDate = a.Stylist.StartDate,
                EndDate = a.Stylist.EndDate,
                IsActive = a.Stylist.IsActive,
                IsAdmin = a.Stylist.IsAdmin,
                Appointments = null
            },
            CustomerId = a.CustomerId,
            Customer = null,
            Scheduled = a.Scheduled,
            IsComplete = a.IsComplete,
            IsCanceled = a.IsCanceled,
            AppointmentServices = a.AppointmentServices.Select(aserv => new AppointmentServiceDTO
            {
                Id = aserv.Id,
                AppointmentId = aserv.AppointmentId,
                ServiceId = aserv.ServiceId,
                Service = new ServiceDTO
                {
                    Id = aserv.Service.Id,
                    Name = aserv.Service.Name,
                    Cost = aserv.Service.Cost
                }
            }).ToList(),
        }).ToList()
    });
});

// 5. Endpoint to get all Services
app.MapGet("/api/services", (HillarysHairSalonDbContext db) =>
{
    return db.Services
        .Select(s => new ServiceDTO
        {
            Id = s.Id,
            Name = s.Name,
            Cost = s.Cost
        }).ToList();
});

// 6. Endpoint to get all Stylists
app.MapGet("/api/stylists", (HillarysHairSalonDbContext db) =>
{
    return db.Stylists
        .Include(s => s.Appointments)
            .ThenInclude(a => a.Customer)
            .Include(s => s.Appointments)
                .ThenInclude(a => a.AppointmentServices)
                    .ThenInclude(aserv => aserv.Service)
        .Select(s => new StylistDTO
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            PhoneNumber = s.PhoneNumber,
            Email = s.Email,
            Password = s.Password,
            StartDate = s.StartDate,
            EndDate = s.EndDate,
            IsActive = s.IsActive,
            IsAdmin = s.IsAdmin,
            Appointments = s.Appointments.Select(a => new AppointmentDTO
            {
                Id = a.Id,
                StylistId =a.StylistId,
                Stylist = null,
                CustomerId = a.CustomerId,
                Customer = new CustomerDTO
                {
                    Id = a.Customer.Id,
                    FirstName = a.Customer.FirstName,
                    LastName = a.Customer.LastName,
                    PhoneNumber = a.Customer.PhoneNumber,
                    Email = a.Customer.Email,
                    Appointments = null
                },
                Scheduled = a.Scheduled,
                IsComplete = a.IsComplete,
                IsCanceled = a.IsCanceled,
                AppointmentServices = a.AppointmentServices.Select(aserv => new AppointmentServiceDTO
                {
                    Id = aserv.Id,
                    AppointmentId = aserv.AppointmentId,
                    ServiceId = aserv.ServiceId,
                    Service = new ServiceDTO
                    {
                        Id = aserv.Service.Id,
                        Name = aserv.Service.Name,
                        Cost = aserv.Service.Cost
                    }
                }).ToList()
            }).ToList()
        }).ToList();
});

// 7. Endpoint to get a Stylist by Id
app.MapGet("/api/stylists/{id}", (HillarysHairSalonDbContext db, int id) =>
{
    var stylist = db.Stylists
        .Include(s => s.Appointments)
            .ThenInclude(a => a.Customer)
            .Include(s => s.Appointments)
                .ThenInclude(a => a.AppointmentServices)
                    .ThenInclude(aserv => aserv.Service)
        .SingleOrDefault(s => s.Id == id);

    return Results.Ok(new StylistDTO
    {
        Id = stylist.Id,
        FirstName = stylist.FirstName,
        LastName = stylist.LastName,
        PhoneNumber = stylist.PhoneNumber,
        Email = stylist.Email,
        Password = stylist.Password,
        StartDate = stylist.StartDate,
        EndDate = stylist.EndDate,
        IsActive = stylist.IsActive,
        IsAdmin = stylist.IsAdmin,
        Appointments = stylist.Appointments.Select(a => new AppointmentDTO
        {
            Id = a.Id,
            StylistId = a.StylistId,
            Stylist = null,
            CustomerId = a.CustomerId,
            Customer = new CustomerDTO
            {
                Id = a.Customer.Id,
                FirstName = a.Customer.FirstName,
                LastName = a.Customer.LastName,
                PhoneNumber = a.Customer.PhoneNumber,
                Email = a.Customer.Email,
                Appointments = null
            },
            Scheduled = a.Scheduled,
            IsComplete = a.IsComplete,
            IsCanceled = a.IsCanceled,
            AppointmentServices = a.AppointmentServices.Select(aserv => new AppointmentServiceDTO
            {
                Id = aserv.Id,
                AppointmentId = aserv.AppointmentId,
                ServiceId = aserv.ServiceId,
                Service = new ServiceDTO
                {
                    Id = aserv.Service.Id,
                    Name = aserv.Service.Name,
                    Cost = aserv.Service.Cost
                }
            }).ToList()
        }).ToList()
    });
});

// Post Endpoints

// 1. Endpoint to create an Appointment
app.MapPost("/api/appointments", (HillarysHairSalonDbContext db, Appointment appointment) =>
{
    try
    {
        db.Appointments.Add(appointment);
        db.SaveChanges();

        var newAppointment = db.Appointments
            .Include(a => a.Stylist)
            .Include(a => a.Customer)
            .FirstOrDefault(a => a.Id == appointment.Id);

        if (newAppointment == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(appointment.Id);
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Invalid data submitted");
    }
});

// 2. Endpoint to create a Customer
app.MapPost("/api/customers", (HillarysHairSalonDbContext db, Customer customer) =>
{
    try
    {
        db.Customers.Add(customer);
        db.SaveChanges();

        var newCustomer = db.Customers
            .Include(c => c.Appointments)
                .ThenInclude(a => a.AppointmentServices)
                    .ThenInclude(aserv => aserv.Service)
                .Include(c => c.Appointments)
                    .ThenInclude(a => a.Stylist)
            .FirstOrDefault(c => c.Id == customer.Id);

        if (newCustomer == null)
        {
            return Results.NotFound();
        }

        return Results.Created($"/api/customers/{newCustomer.Id}", newCustomer);
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Invalid data submitted");
    }
});

// 3. Endpoint to create an AppointmentService
app.MapPost("/api/appointmentService", (HillarysHairSalonDbContext db, AppointmentService appointmentService) =>
{
    try
    {
        db.AppointmentServices.Add(appointmentService);
        db.SaveChanges();

        var newAppointmentService = db.AppointmentServices
            .FirstOrDefault(aserv => aserv.Id == appointmentService.Id);

        if (newAppointmentService == null)
        {
            return Results.NotFound();
        }

        return Results.NoContent();
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Invalid data submitted");
    }
});

// Put Endpoints

// 1. Endpiont to change an Appointment to Canceled
app.MapPut("/api/appointments/cancel/{id}", (HillarysHairSalonDbContext db, int id) =>
{
    Appointment appointmentToCancel = db.Appointments.SingleOrDefault(appointment => appointment.Id == id);
    if (appointmentToCancel == null)
    {
        return Results.NotFound();
    }
    appointmentToCancel.IsCanceled = !appointmentToCancel.IsCanceled;

    db.SaveChanges();
    return Results.NoContent();
});

// Delete Endpoints

// 1. Endpoint to delete an Appointment Service
app.MapDelete("/api/appointmentService/{id}", (HillarysHairSalonDbContext db, int id) =>
{
    AppointmentService appointmentService = db.AppointmentServices.SingleOrDefault(appointmentService => appointmentService.Id == id);
    if (appointmentService == null)
    {
        return Results.NotFound();
    }
    db.AppointmentServices.Remove(appointmentService);
    db.SaveChanges();
    return Results.NoContent();
});

app.Run();