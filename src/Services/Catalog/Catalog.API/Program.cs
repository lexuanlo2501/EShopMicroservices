var builder = WebApplication.CreateBuilder(args);

// Add services to the container

var app = builder.Build();

// Configure tje HTTP request pipeline


app.Run();
