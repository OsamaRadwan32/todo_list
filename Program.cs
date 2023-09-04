using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// Register your service
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
// Add controllers
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers(); // Map controllers

app.Run();

