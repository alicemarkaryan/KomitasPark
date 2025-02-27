using KomitasPark.KomitasParkDAL.Data;
using KomitasPark.KomitasParkDAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

// void ConfigureServices(IServiceCollection services)
//{
//    services.AddDbContext<RealEstateContext>(options =>
//        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

//    services.AddScoped(typeof(IRepository<>), typeof(AbstractRepository<>));
//    services.AddScoped<IRepository<Project>, ProjectRepository>();

//    services.AddControllers();
//}
