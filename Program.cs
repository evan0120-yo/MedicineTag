using MedicineTag.Definition;
using MedicineTag.Models;
using MedicineTag.AppMedicineInfo;
using MedicineTag.AppMedicineClass;
using MedicineTag.AppMedicineInfoClass;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// autoMapper
builder.Services.AddAutoMapper(typeof(MedicineTagProfile).Assembly);

// DI
// builder.Services.AddTransient<MedicineContext>();   // 每次請求都拿到新的物件
builder.Services.AddScoped<MedicineContext>();      // 每次請求都拿到同個物件
// 各個interface
builder.Services.AddScoped(typeof(IMedicineInfoService), typeof(MedicineInfoService));
builder.Services.AddScoped(typeof(IMedicineClassService), typeof(MedicineClassService));
builder.Services.AddScoped(typeof(IMedicineInfoClassService), typeof(MedicineInfoClassService));


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
