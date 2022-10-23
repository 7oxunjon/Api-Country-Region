using Microsoft.EntityFrameworkCore;
using ProjoctApiCountry.Context;
using ProjoctApiCountry.Extation;
using ProjoctApiCountry.Repostory;
using ProjoctApiCountry.Repostory.IRepostory;
using ProjoctApiCountry.Server;
using Newtonsoft.Json;



var builder = WebApplication.CreateBuilder(args);


Startup(builder.Services,builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

static void Startup(IServiceCollection services, ConfigurationManager manager)
{
    services.AddControllers();
   
    services.AddDbContext<AppDbContext>(p => p.UseNpgsql(manager.GetConnectionString("Defoultcontext")));
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.AddService();
    services.AddRepostory();

    services.AddControllersWithViews().AddNewtonsoftJson(options =>
  options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

}
