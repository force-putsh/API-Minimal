using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaStoreEF.Context;
using PizzaStoreEF.DTA;
using PizzaStoreEF.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var connectionString = builder.Configuration.GetConnectionString("Pizzas") ?? "Data Source=Pizzas.db";
builder.Services.AddEndpointsApiExplorer(); builder.Services.AddSqlite<PizzaDbContext>(connectionString);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() {
        Title = "Pizza Store API", 
        Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Add Routes to the pipeline
app.MapGet("/pizzas", async ([FromBody]PizzaRepository repository) => await repository.GetPizzasAsync());
app.MapGet("/pizzas/{id}", async (int id, [FromBody] PizzaRepository repository) => await repository.GetPizzaAsync(id));
//app.MapPost("/pizzas", async (Pizza pizza, PizzaRepository repository) => await repository.AddPizzaAsync(pizza));
//app.MapPut("/pizzas/{id}", async (int id, Pizza pizza, [FromBody] PizzaRepository repository) => await repository.UpdatePizzaAsync(pizza));
app.MapDelete("/pizzas/{id}", async (int id, [FromBody] PizzaRepository repository) => await repository.DeletePizzaAsync(id));


app.Run();

