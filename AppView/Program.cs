
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();

// Add INotyfService
builder.Services.AddScoped<INotyfService, NotyfService>();
// Add Notyf // Đây là thông báo
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
});
builder.Services.AddDistributedMemoryCache();
// thêm AddAuthentication 
builder.Services.AddAuthentication("CookieCuaDung").AddCookie("CookieCuaDung", options =>
{
    options.AccessDeniedPath = new PathString("/Admin/Home/Index"); // cấm người dùng được vào trang nào đó thì ghi ra đây
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true, //chid được nhật các giao thức Http
        Name = "CookieCuaDung",
        Path = "/",


    };
    // chỉ định đường dẫn login
    options.LoginPath = new PathString( "/Admin/Home/Login");
    options.LogoutPath = new PathString("/Admin/Home/Logout");
    // tham số redirect
    options.ReturnUrlParameter = "urlRedirect";
    //thời gian hết hạn
    options.SlidingExpiration = true;
});
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(2);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRouting();

app.UseSession();
app.UseCookiePolicy();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization(); // Đảm bảo gọi app.UseAuthorization() sau app.UseStaticFiles() và trước app.UseEndpoints(...)

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});
app.Run();



