using Microsoft.EntityFrameworkCore;
using contactsApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ContactContext>(opt =>
    opt.UseInMemoryDatabase("Contacts")
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
