using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Challenge03.Data;
using Challenge03.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//
//Database connection
//
string secretNameDBConnectionString= "dbconnectionstring"; //Acessa em Key Vault > Secrets
var dbConnectionString = GetConnection(secretNameDBConnectionString);
//var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(dbConnectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//
//Identity Configuration
//
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

//
//Application Insights
//
builder.Services.AddApplicationInsightsTelemetry();

//
//Azure App Configuration
//
string secretNameAppConfig= "app-configuration"; //Acessa em Key Vault > Secrets
var appConfigString = GetConnection(secretNameAppConfig);
//var appConfigString = builder.Configuration.GetConnectionString("AzureAppConfiguration");
builder.Host.ConfigureAppConfiguration(config => {
    var settings = config.Build();
    config.AddAzureAppConfiguration(appConfigString);
});


//
builder.Services.AddTransient<IRepository<Card>, Repository<Card>>();
builder.Services.AddTransient<IRepository<Player>, Repository<Player>>();
builder.Services.AddTransient<IRepository<Batalha>, Repository<Batalha>>();
//


//
// Passar esse código para uma classe 
//
string GetConnection(string secretName){

    //Acesso via Entra ID > Overview
    string tenantId = "7b03aeda-dc27-47c7-ad10-d4f6a5039313";
    //Acesso no Key vault > Overview
    string keyVaultUri= "https://keyvault-challenge03.vault.azure.net/";
    //Acesso no App Registration > Overview
    string clientId= "afc3c215-8433-4069-a97e-fdf3d34f1a7d";
    //Acesso no App Registration > Certificates & secrets
    string clientSecret= "u.q8Q~8mkXRWSiXDev4w8J5UZ6jdIrh1GpDK_a4H";

    var credentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
	var client = new SecretClient(new Uri(keyVaultUri), credentials);

	KeyVaultSecret secret = client.GetSecret(secretName);
  
	var conn = secret.Value;
	//var conn = _configuration.GetSection("ConnectionString").Value;
	return conn;
}
//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
