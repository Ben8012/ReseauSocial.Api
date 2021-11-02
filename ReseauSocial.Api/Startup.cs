using BLL.Interfaces;
using BLL.Services;
using ConnectionTool;
using DAL.Interfaces;
using DAL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddSingleton<IConnection, Connection>(sp => new Connection(Configuration.GetConnectionString("Tour")));

            services.AddControllers();

            //injection user
            services.AddScoped<IUserDal, UserDalService>();
            services.AddScoped<IUserBll, UserBllService>();

            //injection article
            services.AddScoped<IArticleDal, ArticleDalService>();
            services.AddScoped<IArticleBll, ArticleBllService>();

            //injection message
            services.AddScoped<IMessageDal, MessageDalService>();
            services.AddScoped<IMessageBll, MessageBllService>();

            //injection comment
            services.AddScoped<ICommentDal, CommentDalService>();
            services.AddScoped<ICommentBll, CommentBllService>();

            //injection follower
            services.AddScoped<IFollowerDal, FollowerDalService>();
            services.AddScoped<IFollowerBll, FollowerBllService>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ReseauSocial.Api", Version = "v1" });

               /* c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n                       Enter 'Bearer' [space] and then your token in the text input below.                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                         {
                           {
                             new OpenApiSecurityScheme
                             {
                               Reference = new OpenApiReference
                               {
                                 Type = ReferenceType.SecurityScheme,
                                 Id = "Bearer"
                               },
                               Scheme = "oauth2",
                               Name = "Bearer",
                               In = ParameterLocation.Header
                             },
                             new List<string>()
                           }
                         });*/


            });


           /* services.AddAuthorization(option =>
            {
                option.AddPolicy("isConnected", policy => policy.RequireAuthenticatedUser());
            });


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenManager.secret)),
                        ValidateIssuer = true,
                        ValidIssuer = TokenManager.myIssuer,
                        ValidateAudience = true,
                        ValidAudience = TokenManager.myAudience
                    };
                });*/

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReseauSocial.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            /*app.UseAuthentication();*/

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
