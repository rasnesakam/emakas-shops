using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using shop_app.api.Configurations;
using shop_app.api.DataValidators;
using shop_app.api.Models;
using shop_app.data.Abstract;
using shop_app.data.Concrete.EfCore;
using shop_app.service.Abstract;
using shop_app.service.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using shop_app.entity;
using shop_app.contract.Validation;
using shop_app.contract.DTO;
using shop_app.contract.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddDbContext<ShopContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("POSTGRES_CONNECTION"))
    );
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<ShopContext>()
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
    options.LoginPath = "/auth/login";
    options.LogoutPath = "/auth/logout";
    options.AccessDeniedPath = "/auth/denied";
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

//TODO: Fluent validation ekle
builder.Services.AddScoped<IValidator<OrderDto>, OrderDtoValidator>();
builder.Services.AddScoped<IValidator<UserLoginDto>, UserLoginDtoValidator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program));

//var assembly = AppDomain.CurrentDomain.Load("shop-app.contract");

builder.Services.AddMediatR(typeof (GetAllOrdersRequestHandler).Assembly);
builder.Services.AddMediatR(typeof (GetAllOrdersRequestHandler).Assembly);
builder.Services.AddMediatR(typeof (GetProductRequestHandler).Assembly);
builder.Services.AddMediatR(typeof (SubmitOrderHandler).Assembly);

var serviceProvider = builder.Services.BuildServiceProvider();
var logger = serviceProvider.GetService<ILogger<AnyType>>();

builder.Services.AddSingleton(typeof(ILogger), logger);

//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        /**
         * JWT G�vdesinde bulunmas� gereken claimler
         * * iss -> servisin kendisi
         * * sub -> servisin kullan�m amac� (customer / seller) olabilir
         * * aud -> servisi kullanan taraflar (kullan�c�, uygulama)
         * * exp -> tokenin ge�erlilik s�resi
         * 
         */
        options.SaveToken = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    SeedDatabase.Seed();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalErrorHandlingMiddleware>();

app.UseHttpsRedirection();


app.UseAuthentication();


app.UseRouting();


app.UseAuthorization();


app.MapControllers();


app.Run();
