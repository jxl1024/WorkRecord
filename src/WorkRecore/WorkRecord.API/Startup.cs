using Autofac;
using AutoMapper;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using WordRecord.Repository.Repositories;
using WorkRecord.API.Filter;
using WorkRecord.Common.Log;
using WorkRecord.Data.Context;
using WorkRecord.Model.Jwt;
using WorkRecord.Service.Service;

namespace WorkRecord.API
{
   

    public class Startup
    {
        // ����log4net�ִ�
        public static ILoggerRepository repository { get; set; }
        // ȫ�ֿ������
        readonly string MyAllowSpecificOrigins = "MyAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            #region ����ʹ��log4net
            // NETCoreRepository��log4net�Ĳִ���
            repository = LogManager.CreateRepository("NETCoreRepository");
            // ��ȡlog4net�����ļ�
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));

            InitRepository.LogRepository = repository; 
            #endregion
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region ��ȡ����
            JWTConfig config = new JWTConfig();
            Configuration.GetSection("JWT").Bind(config);
            #endregion

            #region ��ӿ������
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    // �������õ����������еĿ����������Get��Post��Put��Delete����
                    builder => builder.AllowAnyOrigin()
                    .WithMethods("GET", "POST", "PUT", "DELETE"));
            }); 
            #endregion

            #region ����JWT��֤
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidIssuer = config.Issuer,
            //        ValidAudience = config.Audience,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.IssuerSigningKey)),
            //        ClockSkew = TimeSpan.FromMinutes(config.AccessTokenExpiresMinutes)

            //    };
            //});
            #endregion


            #region ʹ��AutoMapper
            // ����������Assembly���͵����� ��ʾAutoMapper������Щ���������������Ѱ�����м̳���Profile��������ļ�
            // �ڵ�ǰ����������г�������ɨ��AutoMapper�������ļ�
            // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(Assembly.Load("WorkRecord.API"));
            #endregion

            #region �������ݿ�����
            string connectionString = Configuration.GetSection("ConnectionString").GetSection("DbConnection").Value;
            services.AddDbContext<AppDbContext>(options =>
                    {
                       
                        options.UseSqlServer(connectionString);
                    });
            #endregion

            #region ����ע��
            //// ʹ����������������
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region ���Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "WorkRecord", Version = "v1" });
                // ��ȡxml�ļ���
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // ��ȡxml�ļ�·��
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // ��ӿ�������ע�ͣ�true��ʾ��ʾ������ע��
                options.IncludeXmlComments(xmlPath, true);
            });
            #endregion

            // ����쳣������
            services.AddControllers(options => 
            {
                options.Filters.Add<GlobalExceptionFilter>();
            });
        }

        /// <summary>
        /// ʹ��Autofac�滻����ע������
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // ����ע��Repository
            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            // ����ע��Service
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
             .Where(t => t.Name.EndsWith("Service"))
             .AsImplementedInterfaces();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // ���Swagger�й��м��
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WorkRecord v1");
            });



            #region ���������֤
            // ���������֤
            //app.UseAuthentication(); 
            #endregion

            app.UseRouting();

            #region ���ÿ����м��
            // ���ÿ����м��
            app.UseCors(MyAllowSpecificOrigins);
            #endregion

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
