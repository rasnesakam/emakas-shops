using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using shop_app.api.Identity;
using shop_app.data.Abstract;
using shop_app.data.Concrete.EfCore;
using shop_app.service.Abstract;
using shop_app.service.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("POSTGRES_CONNECTION"))
    );
builder.Services.AddDbContext<ShopContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("POSTGRES_CONNECTION"))
    );
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    // passwd
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;

    // Lock-out: Account locking
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers = true;

    //User Settings
    //options.User.AllowedUserNameCharacters = ""; // Allow some characters for creating user name
    options.User.RequireUniqueEmail = true;

    options.SignIn.RequireConfirmedEmail = true;
    //options.SignIn.RequireConfirmedPhoneNumber = true; // enforce phone confirmation
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";
    options.LogoutPath = "/account/logout";
    options.AccessDeniedPath = "/account/denied";
    options.SlidingExpiration = true; // renew expiration time for each requests if true, or do not renew expiration time for each requests
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.Cookie = new CookieBuilder()
    {
        HttpOnly = true, // Create cookie for only http requests
        Name = ".ShopApp.Security.Cookie"

    };
});

//builder.Services.AddScoped<ICategoryRepository,EfCoreCategoryRepository>();
//builder.Services.AddScoped<IOrderRepository,EfCoreOrderRepository>();
//builder.Services.AddScoped<IProductRepository,EfCoreProductRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService,ProductManager>();
builder.Services.AddScoped<IOrderService,OrderManager>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    SeedDatabase.Seed();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
