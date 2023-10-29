using MassTransit;
using MessageBusConnection.ServiceExtension;
using SmsCore.Interface;
using SmsCore.Repository;
using SmsDomain.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMessagingBus(builder.Configuration);
builder.Services.AddScoped<ISmsNotification, TwillioService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<ISmsStrategyProcessor, SmsStrategyProcessor>();
builder.Services.AddScoped<IHostedService, MessagingBusService>();
builder.Services.AddScoped<IConsumer<SmsNotificationRequestMessage>, SendSmsConsumer>();
var app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
