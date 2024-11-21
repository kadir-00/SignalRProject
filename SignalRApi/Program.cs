using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SignalR.BussinesLayer.Abstract;
using SignalR.BussinesLayer.Concrete;
using SignalR.BussinesLayer.Container;
using SignalR.BussinesLayer.ValidationRules.BookingValidations;
using SignalR.DataAccesLayer.Abstract;
using SignalR.DataAccesLayer.Concrete;
using SignalR.DataAccesLayer.EntityFramework;
using SignalRApi.Hubs;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder => 
    {
        builder.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials();
    });
});
builder.Services.AddSignalR();

builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.ContainerDependencies();
// buradan dep.'leri aldik

builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingValidation>();

builder.Services.AddControllersWithViews()
.AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");
// yukaridaki endpoint ne ise yariyor? Normalde soyle yaziyoruz: //localhost://1234/swagger/category/index bunu yazmak yerine endpoint
// sayesinde //localhost://1234/signalrhub 'a istekte bulunabilecegiz
// 
app.Run();