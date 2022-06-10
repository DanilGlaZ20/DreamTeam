using DreamTeam.Data;
using DreamTeam.GraphQL.Schema;
using DreamTeam.GraphQL.Services;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DreamTeamContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DreamTeamContext")));

//Add GraphQL
builder.Services.AddScoped<ISchema, PlayerSchema>();
builder.Services.AddGraphQL(options => { options.EnableMetrics = true; }).AddSystemTextJson();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseGraphQLAltair();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseGraphQL<ISchema>();
app.MapControllers();

app.Run();