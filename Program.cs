using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Challenge03.Data;
using Challenge03.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Database connection
string secretNameDBConnectionString= "db-connectionstring"; //Acessa em Key Vault > Secrets
var dbConnectionString = GetConnection(secretNameDBConnectionString);
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(dbConnectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Identity Configuration
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

//Application Insights
builder.Services.AddApplicationInsightsTelemetry();

//Azure App Configuration
string secretNameAppConfig= "app-configuration"; //Acessa em Key Vault > Secrets
var appConfigString = GetConnection(secretNameAppConfig);
//var appConfigString = builder.Configuration.GetConnectionString("AzureAppConfiguration");
builder.Host.ConfigureAppConfiguration(config => {
    var settings = config.Build();
    config.AddAzureAppConfiguration(appConfigString);
});

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
//



// Testes

Player p1 = new Player("Mateus");
Player p2 = new Player("Ana");

Card c1 = new Card("Knight", "aaa", "Arqueiro", "Fogo", "aaa.com", p1);
//p1.AdicionarCard(c1);
Card c2 = new Card("Magician", "aaa", "Mago", "Agua", "aaa.com", p2);
//p2.AdicionarCard(c2);

Batalha b0 = new Batalha(p1, c1, "Agilidade", p2, c2, "Inteligencia");

Console.WriteLine("Card1 (" + c1.Nome + "[" + c1.Forca + ", " + c1.Defesa + ", " + c1.Agilidade + ", " + c1.Inteligencia + ", " + "]" + ")");
Console.WriteLine("Card2 (" + c2.Nome + "[" + c2.Forca + ", " + c2.Defesa + ", " + c2.Agilidade + ", " + c2.Inteligencia + ", " + "]" + ")");
Console.WriteLine(b0.LogBatalha);

//Testes



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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
