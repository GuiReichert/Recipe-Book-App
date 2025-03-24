using MyRecipeApp.API.Filters;
using MyRecipeApp.API.Middleware;
using MyRecipeApp.Apllication;
using MyRecipeApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));           // sempre que uma exceção ocorrer, ele será tratado como um ExceptionFilter



builder.Services.AddInfrastructure();                                                       // Extension methods to add dependency injection coming from the Infrastructure and Application Solutions
builder.Services.AddApplication();                                                          













var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CultureMiddleware>(); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
