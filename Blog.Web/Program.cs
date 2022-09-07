using Blog.Data;
using Blog.Entities;
using Blog.Web;
using Microsoft.EntityFrameworkCore;
using Blog.Web.Data;
using Blog.Web.Services;
using Hangfire;
using Hangfire.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<BlogUser>(
    options => { options.SignIn.RequireConfirmedAccount = false; options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6; options.Password.RequireNonAlphanumeric = false; options.Password.RequireUppercase = false; }
   
    )
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IRestApiService, RestApiService>();

var HangfireconnectionString = builder.Configuration.GetConnectionString("HangfireConnection");
builder.Services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(HangfireconnectionString, new SqlServerStorageOptions
        {
            CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            QueuePollInterval = TimeSpan.Zero,
            UseRecommendedIsolationLevel = true,
            DisableGlobalLocks = true
        }));

// Add the processing server as IHostedService
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHangfireDashboard();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHangfireDashboard();
app.MapRazorPages();

app.Run();
