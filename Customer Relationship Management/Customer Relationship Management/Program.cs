var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<CustomerDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});



builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());   
});

builder.Services.AddScoped<ContactService>();
builder.Services.AddScoped<LeadService>();
builder.Services.AddScoped<SaleService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddAuthentication().AddCookie("Cookies", authenticationOptions =>
{
    authenticationOptions.ExpireTimeSpan = TimeSpan.FromMinutes(30);

    authenticationOptions.Events.OnRedirectToLogin = (redirectContext) =>
    {
        redirectContext.Response.StatusCode = 401;
        return Task.CompletedTask;
    };

    authenticationOptions.Events.OnRedirectToAccessDenied = (redirectContext) =>
    {
        redirectContext.Response.StatusCode = 403;
        return Task.CompletedTask;
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


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
