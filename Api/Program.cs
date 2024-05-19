using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public void ConfigureServices(IServiceCollection services)
{
    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
    });

    // Добавление других сервисов...

var builder = WebApplication.CreateBuilder(args);
var builder = WebApplication.CreateBuilder(args);
[ApiController]
[Route("[controller]")]
public class RecordsController : ControllerBase
{
    [HttpPost]
    [Route("addRecord")] // POST: /Records/addRecord
    public IActionResult AddRecord([FromBody] Record record)
    {
        // Логика добавления записи в базу данных
        return Ok();
    }

    [HttpDelete]
    [Route("deleteRecord/{id}")] // DELETE: /Records/deleteRecord/1
    public IActionResult DeleteRecord(int id)
    {
        // Логика удаления записи из базы данных
        return Ok();
    }
}
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:5173") // Измените порт, если клиент на другом
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddControllers();
// Add other services

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseCors("AllowSpecificOrigin"); // Используйте добавленную политику CORS

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

var connectionString=builder.Configuration.GetSection("connectionString").Value;
builder.Services.AddDbContext<ToDoDbContext>(options =>options.UseSqlServer(connectionString));
builder.Services.AddScoped<IAddRecord,AddRecordService>();
builder.Services.AddScoped<IDeleteRecord,DeleteRecordService>();
builder.Services.AddScoped<IEditRecord,EditRecordService>();
builder.Services.AddScoped<IShowAllRecords,ShowAllRecordsService>();


var app = builder.Build();

await using (var scope = app.Services.CreateAsyncScope()) {
var context = scope.ServiceProvider.GetRequiredService<ToDoDbContext>();
context.Database.EnsureCreated();
}

app.MapGet("/showAllRecords", ([FromServices]IShowAllRecords showAllRecords) =>Results.Ok(showAllRecords.ShowAllRecords()));

app.MapDelete("/deleteRecord/{id}", 
(int id,[FromServices]IDeleteRecord deleteRecord) =>
{
    int status=deleteRecord.DeleteRecord(id);
    return status==0?Results.Ok():Results.Problem(statusCode:400);
});


app.MapPost("/addRecord/{title}/{content}", 
(string title,string content,[FromServices]IAddRecord addRecord) => 
{
    int status=addRecord.AddRecord(title,content);
    return status==0?Results.Ok():Results.Problem(statusCode:400);
});

app.MapPut("/editRecord/{id}/{title}/{content}", 
(int id,string title,string content, [FromServices]IEditRecord editRecord) => 
{
    int status=editRecord.EditRecord(id, title, content);
    return status==0?Results.Ok():Results.Problem(statusCode:400);
});

app.Run();
