using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Services.Mappings;
using Services.Services;
using Services.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>(); /// bunu login registr ucun yazriq


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 8; // bu paswordun lensi en azi 8 olmalidir yeni girilen sifreye en azi 8 simvol daxil elemlidir
    options.Password.RequireDigit = true; // passworda reqem mutleq sekilde olsun
    options.Password.RequireLowercase = true; // balaca herifler mutlreq sekilde olsun
    options.Password.RequireUppercase = true; // boyuk herif en azi 1 dene olsun
    options.Password.RequireNonAlphanumeric = true;  // simvolar en azi 1 dene oslun yeni herif ve reqemden basqa  altdan xet meselcun noqte ve s

    options.User.RequireUniqueEmail = true; // her istifadeci ucun bir emale olmalidir yeni bir emailden 2 istifadeci istifade edib registir ola bilmez
    options.SignIn.RequireConfirmedEmail = true;  /// bunu yazanda emila mesaj gedirki tesdiqle

    options.Lockout.MaxFailedAccessAttempts = 3; // 3 defe   logini tekrar tekerar kece  biler en azi 3 defe sehv ede biler

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);  // bu ise 2 defe sehv edenden sonra bloklayir 30 deqiqelik

    options.Lockout.AllowedForNewUsers = true; // bu ise odurki yeni registerden kecen adam en azi 1 defe login olmalidir yuxarida yazilanlar ona ait deyil yeni sehv ede biler

});


builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICityService, CityService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();
