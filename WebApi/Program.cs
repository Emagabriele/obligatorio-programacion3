using AccesData.SqlRepositorios;
using Dominio;
using Dominio.Interfaces;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesUC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var rutaArchivo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WebApi.xml");
builder.Services.AddSwaggerGen(opciones =>
{
    //Se agrega la opcion de autenticarse en Swagger
    opciones.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
    {
        Description = "Autorizacion estandar mediante esquema Bearer",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    opciones.OperationFilter<SecurityRequirementsOperationFilter>();

    opciones.IncludeXmlComments(rutaArchivo);
    opciones.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Documentación de Obligatorio.Api",
        Description = "Aqui se encuentran todos los endpoint activos para utilizar los servicios del proyecto Obligatorio ",
        Contact = new OpenApiContact
        {
            Email = "emanuellegabriele8@gmail.com"
        },
        Version = "v1"
    });
});

// Configurar de la autenticacion
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opciones =>
{
    opciones.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:SecretTokenKey").Value!)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

/**************************** REPOSITORIOS **********************************/
builder.Services.AddScoped<ICabañaRepository, CabañaRepository>();
builder.Services.AddScoped<IMantenimientoRepository, MantenimientoRepository>();
builder.Services.AddScoped<ITipoRepository, TipoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepositorio>();

/**************************** CASOS DE USO **********************************/
builder.Services.AddScoped<ICabañaUC, CabaniaUC>();
builder.Services.AddScoped<ITipoUC, TipoUC>();
builder.Services.AddScoped<IUsuarioUC, UsuarioUC>();
builder.Services.AddScoped<IMantenimientoUC, MantenimientoUC>();


// Configurar la autorización
builder.Services.AddAuthorization(opciones =>
{
    opciones.DefaultPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
});

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
