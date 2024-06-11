using Entities.Models;
using Services;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEntities();
builder.Services.AddServices();


// Add services to the container.
builder.Services.AddScoped<IEmailService>(sp => new EmailService(
    emailFrom: "ricardoobando45@gmail.com",
    smtpServer: "smtp.gmail.com",
    smtpPort: 587,
    smtpUser: "ricardoobando45@gmail.com",
    smtpPass: "NHDnvj90"
));


builder.Services.AddControllers();

builder.Services.AddControllers();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
