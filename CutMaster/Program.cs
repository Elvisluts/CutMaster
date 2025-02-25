var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS support (for frontend connection)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS
app.UseCors("AllowAll");

// Barber Booking API Endpoints
List<Booking> bookings = new List<Booking>();

app.MapGet("/", () => "Welcome to CutMaster Barber Booking API");

// Get all bookings
app.MapGet("/bookings", () => bookings)
   .WithName("GetBookings")
   .WithOpenApi();

// Create a new booking
app.MapPost("/bookings", (Booking newBooking) =>
{
    newBooking.Id = bookings.Count + 1; // Auto-increment ID
    bookings.Add(newBooking);
    return Results.Created($"/bookings/{newBooking.Id}", newBooking);
}).WithName("CreateBooking")
  .WithOpenApi();

app.Run();

// Booking Model
record Booking
{
    public int Id { get; set; }  // Make Id mutable
    public string CustomerName { get; init; } = string.Empty;
    public string BarberName { get; init; } = string.Empty;
    public DateTime AppointmentDate { get; init; }
}
