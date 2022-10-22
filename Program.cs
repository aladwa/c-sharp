using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Todo.Domain.Models;
//using Todo.SDK.Services.UsersService;
using Todo.SDK.Services.UsersService;
using System.Web.Http.Cors;
//using System.Web.Http;
//using System.Net.Http.Headers;
using Newtonsoft.Json.Serialization;

using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//var cors = new EnableCorsAttribute("*", "*", "*");


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var corsPolicy = "corsPolicy";
builder.Services.AddCors(option =>
{
    option.AddPolicy(corsPolicy, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
//AddNewtonsoftJson
/*builder.Services.AddControllersWithViews().AddNewtonsoftJson(Options =>
Options.serializerSetting.ReferenceLoorHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
  )
.addNewtonsoftJson(Options =>
   options.serializerSetting.contractResolver = new DefaultContractResolver()
   );
builder.Services.AddKendo();*/

/*builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.PropertyNamingPolicy = null);*/



//
//builder.Services.AddControllersWithView().AddNewtonsoftJson

builder.Services.AddScoped<ServContext>();
//builder.Services.AddScoped<UsersService, UsersService>();
builder.Services.AddScoped<IUsersService,UsersService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(corsPolicy);
}
else
{

    app.UseHttpsRedirection();

    //app.UseCors();

    app.UseAuthorization();
}
app.MapControllers();
app.Run();
