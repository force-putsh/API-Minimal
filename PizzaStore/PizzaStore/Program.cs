using PizzaStore.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "PizzaStore", Version = "v1" });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

//Ajout des routes pour l'API
app.MapGet("/api/pizzas", PizzaRepos.GetAll);
app.MapGet("/api/pizzas/{id}", PizzaRepos.GetById);
app.MapPost("/api/pizzas", PizzaRepos.Add);
app.MapPut("/api/pizzas/{id}", PizzaRepos.Update);
app.MapDelete("/api/pizzas/{id}", PizzaRepos.Delete);

app.Run();