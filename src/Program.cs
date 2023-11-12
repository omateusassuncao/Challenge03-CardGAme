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

    string tenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
    string keyVaultUri = Environment.GetEnvironmentVariable("AZURE_KEYVAULT_URI");
    string clientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
    string clientSecret = Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET");

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
