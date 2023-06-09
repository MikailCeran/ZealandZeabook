using ZealandBook.Services.ADONETService;
using ZealandBook.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession(); // Add this line to configure session services

builder.Services.AddTransient<IBookingService, BookingService>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<ITeacherService, TeacherService>();
builder.Services.AddTransient<IRoomService, RoomService>();
builder.Services.AddTransient<ILogInService, LogInService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession(); // Add this line to enable session middleware

app.MapRazorPages();

app.Run();

