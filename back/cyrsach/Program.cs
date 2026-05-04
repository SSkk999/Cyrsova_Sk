
using cyrsach.BLL.Services.Answer;
using cyrsach.BLL.Services.Auth;
using cyrsach.BLL.Services.Crystal;
using cyrsach.DAL;
using cyrsach.DAL.Repositories.Answer;
using cyrsach.DAL.Repositories.Test;
using cyrsach.DAL.Repositories.User;
using Microsoft.EntityFrameworkCore;
using cyrsach.BLL.Services.Question;
using cyrsach.BLL.Services.Test;
using cyrsach.DAL.Repositories.Question;
using cyrsach.DAL.Initializer;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddAutoMapper(options =>
{
    options.LicenseKey = builder.Configuration["Automapper:LicenseKey"];
}, AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultDb"))
);

// Add repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped< IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped< ITestRepository, TestRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
// Add Services
builder.Services.AddScoped< IAuthService, AuthService>();
builder.Services.AddScoped<ICrystalService, CrystalService>();
builder.Services.AddScoped<IAnswerService, AnswerService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<ITestService, TestService>();



builder.Services.AddAutoMapper(options =>
{
    options.LicenseKey = builder.Configuration["Automapper:LicenseKey"];
}, AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendCorsPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173", "http://127.0.0.1:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("FrontendCorsPolicy");
app.UseAuthorization();
app.MapControllers();



app.Seed();

app.Run();
