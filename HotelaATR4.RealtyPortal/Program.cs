using HotelaATR4.RealtyPortal.AppMiddleware;
using HotelaATR4.RealtyPortal.Filters;
using HotelaATR4.RealtyPortal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Context;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using static HotelaATR4.RealtyPortal.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options=>
{
	options.Filters.Add<CustomeHeaderResourfeFilter>();
	options.Filters.Add<CatchError>();
});


//string connection = builder.Configuration["ConnectionStrings:DefaultConnection"];
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppIdentityDbContext>
	(options => options.UseSqlServer(connection));

builder.Services.AddIdentity<AppUser, IdentityRole>()
	.AddEntityFrameworkStores<AppIdentityDbContext>()
	.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie
	(option => option.LoginPath = "/Account/Login");


//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();
//builder.Logging.AddDebug();

var colOptions = new ColumnOptions();
colOptions.Store.Remove(StandardColumn.Properties);
colOptions.Store.Add(StandardColumn.Properties);
colOptions.AdditionalColumns = new Collection<SqlColumn>
{
	new SqlColumn("ActionName", System.Data.SqlDbType.NVarChar),
	new SqlColumn("IP", System.Data.SqlDbType.NVarChar)
};

Log.Logger = new LoggerConfiguration()
	.WriteTo.Console()
	.WriteTo.File("Logs/hotealtllog_.txt", rollingInterval: RollingInterval.Day)
	.WriteTo.MSSqlServer(
	connectionString: connection,
	sinkOptions: new MSSqlServerSinkOptions()
	{
		TableName = "Log"
	},
	columnOptions: colOptions)
	.WriteTo.Seq("http://localhost:5341/")
	.MinimumLevel.Information()
	.Enrich.FromLogContext()
	.CreateLogger();

builder.Host.UseSerilog();







var app = builder.Build();

//app.Use(async (httpContext, next) =>
//{
//	string ipAddress = httpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknowk";

//	using (LogContext.PushProperty("IP", ipAddress))
//	{
//		Log.Information("запрос от пользователя с {IP} для {Path}",
//			ipAddress, httpContext.Request.Path);

//		await next.Invoke();
//	}
//});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//app.Use(async (context, next) =>
//{
//	///TODO:
//    await next.Invoke();
//});

//app.UseMiddleware<UseWorkTime>();

app.UseAuthorization();
app.UseAuthentication();

//app.UseMiddleware<LogRequestMiddleware>();
//app.LogRequest();

#region routing template
//app.MapControllerRoute(
//	name: "contactus",
//	pattern: "count-us",
//	defaults: new { controller = "Home", action = "Contact" });

//app.MapControllerRoute(
//	name: "roomdetailbyid",
//	pattern: "room/details/{roomId:int:min(1)}",
//	defaults: new { controller = "Room", action = "RoomDetails" });

////rooms → Показать все номера
//app.MapControllerRoute(
//	name: "getallrooms",
//	pattern: "all-rooms",
//	defaults: new { controller = "Room", action = "Index" });

//app.MapControllerRoute(
//	name: "roocategory",
//	pattern: "rooms/{category=standart}",
//	defaults: new { controller = "Room", action = "RoomList" });
#endregion

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
