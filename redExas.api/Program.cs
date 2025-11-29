
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Application.MappingProfiles;
using Application.Interfaces.Repositories;
using Infrastructure.Repositories;
using Application.Interfaces.UseCases.ExAlumnos;
using Application.UseCases.ExAlumnos;
using Application.Interfaces.UseCases.Emprendimientos;
using Application.UseCases.Emprendimientos;
using Microsoft.OpenApi.Models;
using Application.Interfaces.UseCases.Auth;
using Application.UseCases.Usuarios;
using Api.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.UseCases.Empresas;
using Application.Interfaces.UseCases.Empresas;

namespace redExas.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // ESTO PERMITE USAR JWT EN SWAGGER, NO NECESARIO EN PRODUCCION
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fintor", Version = "v1" });

                // ?? Configurar soporte para JWT
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Ingrese el token JWT en este formato: Bearer {token}"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
            });



            // Add services to the container.
            builder.Services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var jwt = builder.Configuration.GetSection("JwtSettings");
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwt["Issuer"],
                    ValidAudience = jwt["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwt["Secret"]!)
                    ),
                    // Si usás claim "role" plano:
                    RoleClaimType = "role" // o ClaimTypes.Role si agregaste ese
                };
            });

            builder.Services.AddAuthorization();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                builder.Configuration.GetConnectionString("DefaultConnection")
            ));

            // Configuracion de CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:4200") // URL del frontend
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });


            builder.Services.AddScoped<IPasswordService, PasswordService>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EmprendimientoProfile>();
                cfg.AddProfile <ExAlumnoProfile>();
                cfg.AddProfile <EmpresaProfile>();
                cfg.AddProfile <DisponibilidadProfile>();
                cfg.AddProfile <EstudioProfile>();
            });

            IMapper mapper = mapperConfig.CreateMapper();

            builder.Services.AddSingleton(mapper);

            // Inyeccion de dependencias de Repositories

            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IEmprendimientoRepository, EmprendimientoRepository>();
            builder.Services.AddScoped<IExAlumnoRepository, ExAlumnoRepository>();
            builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            // Inyeccion de dependencias UseCases de ExAlumno
            builder.Services.AddScoped<ICreateExAlumno, CreateExAlumno>();
            builder.Services.AddScoped<IGetAllExAlumnos, GetAllExAlumnos>();

            // Inyeccion de dependencias UseCases de Emprendimiento
            builder.Services.AddScoped<ICreateEmprendimiento, CreateEmprendimiento>();
            builder.Services.AddScoped<IGetAllEmprendimientos, GetAllEmprendimientos>();
            builder.Services.AddScoped<IGetEmprendimientosDeExAlumno, GetEmprendimientosDeExAlumno>();
            builder.Services.AddScoped<ISearchEmprendimiento, SearchEmprendimiento>();

            // Inyeccion de dependencias UseCases de Usuario
            builder.Services.AddScoped<ISignIn, SignIn>();

            // Inyeccion de dependencias UseCases de Empresas
            builder.Services.AddScoped<ICreateEmpresa, CreateEmpresa>();

            // Inyeccion de dependencias UseCases de Servicios
            builder.Services.AddScoped<IJwtService, JwtService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseMiddleware<ExceptionMiddleware>();

            app.Run();
        }
    }
}
