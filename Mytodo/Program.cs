using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
void ConfigureServices(IServiceCollection services)
{

	services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
	services.AddSingleton<ITempDataDictionaryFactory, TempDataDictionaryFactory>();

}

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
  //  app.UseSwagger();
   // app.UseSwaggerUI();
//}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=ToDo}/{action=Index}/{id?}"
        );
});

app.Run();
