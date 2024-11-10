var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(opst =>
{
    opst.Connection(builder.Configuration.GetConnectionString("database")!);  
}).UseLightweightSessions();

var app = builder.Build();

// Configure tje HTTP request pipeline
app.MapCarter();


app.Run();
