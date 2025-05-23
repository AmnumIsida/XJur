using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using XAlgiz.Controllers;
using XAlgiz.Data;
using XAlgiz.Dtos;
using XAlgiz.Security;
using XAlgiz.Services;
using XAlgiz.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("DBTeste"));

builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<ServicoService>();
builder.Services.AddScoped<NotaFiscalService>();

builder.Services.AddTransient<IValidator<CadastrarClienteRequest>, CadastrarClienteRequestValidator>();
builder.Services.AddTransient<IValidator<CadastrarServicoRequest>, CadastrarServicoRequestValidator>();
builder.Services.AddTransient<IValidator<EmitirNotaFiscalRequest>, EmitirNotaFiscalRequestValidator>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(JwtSettings.Key)
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapSecurityEndpoints();
app.MapClienteEndpoints();
app.MapServicoEndpoints();
app.MapNotaFiscalEndpoints();

app.Run();