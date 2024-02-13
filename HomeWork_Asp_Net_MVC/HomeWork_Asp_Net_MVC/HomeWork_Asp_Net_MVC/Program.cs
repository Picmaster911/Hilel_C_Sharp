using DAL;
using HomeWork_Asp_Net_MVC.ViewModels;
using Microsoft.EntityFrameworkCore;
using NoteContracs;
using MyNoteProcessor;
using HomeWork_Asp_Net_MVC.Extantion;


var builder = WebApplication.CreateBuilder(args);


#region connected certificate
//string certPath = @"C:\Users\picma\Desktop\c#\HomeWork_Asp_Net_MVC\HomeWork_Asp_Net_MVC\HomeWork_Asp_Net_MVC\certificate.pfx";
//string certKeyPath = @"C:\Users\picma\Desktop\c#\HomeWork_Asp_Net_MVC\HomeWork_Asp_Net_MVC\HomeWork_Asp_Net_MVC\private.key"; ;

//X509Certificate2 currentCertificate = X509Certificate2.CreateFromPemFile(certPath, certKeyPath);

//// Configure Kestrel to use the certificate
//builder.WebHost.ConfigureKestrel(serverOptions =>
//{
//    serverOptions.ConfigureHttpsDefaults(listenOptions =>
//    {
//        listenOptions.ServerCertificateSelector = (context, name) => currentCertificate;
//    });
//});

#endregion

string connection = builder.Configuration.GetConnectionString("AppDbContext");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlite(connection));

builder.Services.AddControllersWithViews();
//builder.Services.AddScoped<IDataWorker<MyNote>, DataWorker>();
//builder.Services.AddScoped<INoteProcessor, NoteProcessor>();
//builder.Services.AddScoped<NotesViewModel>();
builder.Services.AddDI();
var app = builder.Build();





using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dataContext.Database.EnsureCreated();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
