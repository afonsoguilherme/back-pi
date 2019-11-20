﻿using System;
using System.IO;
using System.Text;
using AutoMapper;
using back_pi.BLL;
using back_pi.DAL.DAO;
using back_pi.Extensions;
using back_pi.Extensions.Filters;
using back_pi.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using NLog;
using Swashbuckle.AspNetCore.Swagger;

namespace back_pi
{
    public class Startup
    {
        private readonly MapperConfiguration _mapperConfiguration;
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            // AUTOMAPPER PARA MAPEAR DTO E MODEL
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Configuracoes>(
                options =>
                {
                    options.ConnectionString =
                        Configuration.GetSection("MongoDb:ConnectionString").Value;
                    options.Database = Configuration.GetSection("MongoDb:Database").Value;
                });

            services.AddSingleton<IMongoClient, MongoClient>(
                _ => new MongoClient(Configuration.GetSection("MongoDb:ConnectionString").Value));

            services.AddMvc(options => 
            {
                options.Filters.Add(new ApiValidationFilterAttribute());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // JWT
            services.AddAuthentication(o =>
            {
                o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                // options.AccessDeniedPath = new PathString("/Account/Login/");
                // options.LoginPath = new PathString("/Account/Login/");
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HJaM5dvQy5WUEQ6LPR7yRrcO4m2Mse4u94FMsgXtMjrc66XeM34sdPWQ2ilEA9fo")),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromDays(1)
                };
            });

            // Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Projeto Integrador",
                        Version = "v1",
                        Description = "Projeto Integrador 6° Periodo",
                        Contact = new Contact
                        {
                            Name = "Projeto Integrador"
                        }
                    });
            });    

            // Log
            services.AddSingleton<ILoggerManager, LoggerManager>();

            // AUTOMAPPER
            services.AddSingleton(sp => _mapperConfiguration.CreateMapper());

            // DI
            services.AddScoped<IMongoContext, MongoContext>();

            services.AddScoped<IVendedorDAO, VendedorDAO>();
            services.AddScoped<IVendedorBll, VendedorBll>();

            services.AddScoped<IMovimentoDAO, MovimentoDAO>();
            services.AddScoped<IMovimentoBll, MovimentoBll>();

            services.AddScoped<IVendaNaoSucedidaDAO, VendaNaoSucedidaDAO>();
            services.AddScoped<IVendaNaoSucedidaBll, VendaNaoSucedidaBll>();

            services.AddScoped<IUsuarioDAO, UsuarioDAO>();
            services.AddScoped<IUsuarioBll, UsuarioBll>();

            services.AddScoped<IFilaEsperaDAO, FilaEsperaDAO>();
            services.AddScoped<IFilaEsperaBll, FilaEsperaBll>();

            services.AddScoped<IFilaAtendimentoDAO, FilaAtendimentoDAO>();
            services.AddScoped<IFilaAtendimentoBll, FilaAtendimentoBll>();

            services.AddScoped<IFilaAusenciaDAO, FilaAusenciaDAO>();
            services.AddScoped<IFilaAusenciaBll, FilaAusenciaBll>();

            services.AddScoped<IMarcaDAO, MarcaDAO>();
            services.AddScoped<IMarcaBll, MarcaBll>();

            services.AddScoped<ICorDAO, CorDAO>();
            services.AddScoped<ICorBll, CorBll>();

            services.AddScoped<ITipoDAO, TipoDAO>();
            services.AddScoped<ITipoBll, TipoBll>();

            services.AddScoped<ITamanhoDAO, TamanhoDAO>();
            services.AddScoped<ITamanhoBll, TamanhoBll>();

            services.AddScoped<SeedingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedingService seedingService, ILoggerManager logger)
        {
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seedingService.Seed();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto Integrador");
            });

            // Middleware
            app.ConfigureCustomExceptionMiddleware();
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
