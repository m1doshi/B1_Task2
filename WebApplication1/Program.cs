using Microsoft.EntityFrameworkCore;
using WebApplication1.Database;
using WebApplication1.Repositories;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services;
using WebApplication1.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBaseConfig")));
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<INewAccountService, NewAccountService>();
builder.Services.AddScoped<ITurnoverService, TurnoverService>();
builder.Services.AddScoped<IIncomingSaldoService, IncomingSaldoService>();
builder.Services.AddScoped<IOutgoingSaldoService, OutgoingSaldoService>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<INewAccountRepository, NewAccountRepository>();
builder.Services.AddScoped<ITurnoverRepository, TurnoverRepository>();
builder.Services.AddScoped<IIncomingSaldoRepository, IncomingSaldoRepository>();
builder.Services.AddScoped<IOutgoingSaldoRepository, OutgoingSaldoRepository>();
builder.Services.AddScoped<IFileInfoService, FileInfoService>();
builder.Services.AddScoped<IFileInfoRepository, FileInfoRepository>();
builder.Services.AddScoped<DataRepository>();
builder.Services.AddScoped<DataService>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = "swagger";
    });
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Import}/{action=Import}/{id?}");
});
app.UseStaticFiles();
app.Run();

