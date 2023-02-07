using Microsoft.EntityFrameworkCore;
using contactsApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// connection string shouldn't be hardcoded but in appsettings.json instead
builder.Services.AddDbContext<ContactContext>(options =>
    options.UseSqlite("Data Source=contacts.db;")
);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "webapi", Version = "v1" });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(options =>
{
    // NOTE: hardcoded url because I was getting a null exceotion without it. This may be beacuse my appsettings.json file is incorrect
    var frontendURL = configuration.GetValue<string>("frontend_url");

    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Address Book API");
                c.RoutePrefix = string.Empty;
            });
}
// Necessary??
// app.UseSwagger(options =>
// {
//     options.SerializeAsV2 = true;
// });
// Add middleware
app.UseHttpsRedirection();
app.UseCors();
app.UseRouting();
app.UseAuthorization();


// warning: ASP0014: Suggest using top level route registrations
app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    });

// app.MapControllers();

app.Run();
