using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy=> policy.AllowAnyOrigin());
});
builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "images")),
//    RequestPath = "/images"
//});
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(name: "default", pattern: "{controller=CardsController}/{action=Index}/{id?}");

app.Run();
