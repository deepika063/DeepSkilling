using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

string securityKey = "mysuperdupersecret";

var symmetricSecurityKey =
    new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(securityKey));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;

    x.DefaultChallengeScheme =
        JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "mySystem",
            ValidAudience = "myUsers",
            IssuerSigningKey = symmetricSecurityKey
        };
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("MyPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
