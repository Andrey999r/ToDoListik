var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAddRecord,AddRecordService>();
builder.Services.AddScoped<IDeleteRecord,DeleteRecordService>();
builder.Services.AddScoped<IEditRecord,EditRecordService>();
builder.Services.AddScoped<IShowAllRecords,ShowAllRecordsService>();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.Run();
