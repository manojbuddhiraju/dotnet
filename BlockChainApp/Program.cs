using BlockChainApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen( c => { c.SwaggerDoc("v1",new OpenApiInfo { Title = "BlockChain"}); });

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddDbContext<BlockChainAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "BlockChainCors", policy => policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI( c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlockChain");
        c.RoutePrefix = "";
    });
}

app.UseHttpsRedirection();

app.UseCors("BlockChainCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
