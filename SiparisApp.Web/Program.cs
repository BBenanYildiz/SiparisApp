using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.EntityFrameworkCore;
using SiparisApp.Repository;
using SiparisApp.Service.MapProfile;
using SiparisApp.Web.Modules;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    //Klasör oluþturulur ü text dosyasý üzerinde tutulur.
    //ilgili logun seviyesinin belirlendipði yer.Debugdan itibariyle
    // loglama baþlar.
    x.SetMinimumLevel(LogLevel.Debug);
    x.AddDebug(); //Output penceresinde gösterir.

});

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
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Orders}/{action=Index}/{id?}");

app.Run();
