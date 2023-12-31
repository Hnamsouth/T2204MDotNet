using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add cors

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
         policy =>
         {
             //policy.WithOrigins("domain or id"); chi dinh noi dc phep truy cap den
             policy.AllowAnyOrigin();
             policy.AllowAnyMethod();
             policy.AllowAnyHeader();
         }
         );
});


// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options
    => options.SerializerSettings.ReferenceLoopHandling
    = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WebApi.Entities.Sem3DotnetApiContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SEM3_DOTNET_API"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
// use cors
app.UseCors();

app.Run();
