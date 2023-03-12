using Online_Store.Application.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;
using Online_Store.Application.Services.Users.Queries.GetUsers;
using Online_Store.Persistence.Contexts;
using Online_Store.Application.Services.Users.Queries.GetRoles;
using Online_Store.Application.Services.Users.Commands.EditUser;
using Online_Store.Application.Services.Users.Commands.RegisterUser;
using Online_Store.Application.Services.Users.Commands.RemoveUser;
using Online_Store.Application.Services.Users.Commands.UserLogin;
using Online_Store.Application.Services.Users.Commands.UserSatusChange;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IUserSatusChangeService, UserSatusChangeService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();


builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
string contectionString = @"Data Source=DESKTOP-7FRVFH5\MSSQLSERVERLAB; Initial Catalog=Online_StoreDb; Integrated Security=True;TrustServerCertificate=True";
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(contectionString));
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");


    endpoints.MapControllerRoute(
       name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

});
app.Run();
