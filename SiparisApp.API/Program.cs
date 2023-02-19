using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SiparisApp.API.Modules;
using SiparisApp.Repository;
using SiparisApp.Service.MapProfile;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });

});


builder.Services.AddLogging(x =>
{
    x.ClearProviders();
    x.SetMinimumLevel(LogLevel.Debug);
    x.AddDebug(); //Output penceresinde gösterir.

});

builder.Services.AddHttpClient();

builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());


builder.Host.ConfigureContainer<ContainerBuilder>
    (containerBuilder => containerBuilder.RegisterModule(new RepositoryServiceModule()));


var app = builder.Build();

// LOGLAMA ÝÞLEMÝ BÝR KLASÖR OLUÞTURULUR. ONUN ÝÇÝNE KAYIT ATILIR....
// SERÝLOG PAKETÝ ÝLE YAPILIR.
using (var scope = app.Services.CreateScope())
{
    var loggerFactory = app.Services.GetService<ILoggerFactory>();
    var path = Directory.GetCurrentDirectory(); //Aktif yol deðerini al
    loggerFactory.AddFile($"{path}\\Logs\\Log.text");
}


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
