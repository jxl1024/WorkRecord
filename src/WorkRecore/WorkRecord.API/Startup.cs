using Autofac;
using Autofac.Extras.DynamicProxy;
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
using WorkRecord.API.AOP;
using WorkRecord.API.Filter;
using WorkRecord.Common.Helper;
using WorkRecord.Common.Log;
using WorkRecord.Data.Context;
using WorkRecord.Model.Jwt;
using WorkRecord.Service.Service;

namespace WorkRecord.API
{
   

    public class Startup
    {
        // 定义log4net仓储
        public static ILoggerRepository repository { get; set; }
        // 全局跨域策略
        readonly string MyAllowSpecificOrigins = "MyAllowSpecificOrigins";
        public Startup(IConfiguration configuration,IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;

            #region 配置使用log4net
            // NETCoreRepository是log4net的仓储名
            repository = LogManager.CreateRepository("NETCoreRepository");
            // 读取log4net配置文件
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));

            InitRepository.LogRepository = repository; 
            #endregion
        }

        public IConfiguration Configuration { get; }
        // 当前Web Hosting环境
        public IWebHostEnvironment Env { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // 注入当前json文件
            services.AddSingleton(new AppsettingHelper(Env.ContentRootPath, "appsettings.json"));
            #region 读取配置
            JWTConfig config = new JWTConfig();
            Configuration.GetSection("JWT").Bind(config);
            #endregion

            #region 添加跨域服务
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    // 这里设置的是允许所有的跨域，允许访问Get、Post、Put、Delete方法
                    builder => builder.AllowAnyOrigin()
                    .WithMethods("GET", "POST", "PUT", "DELETE"));
            }); 
            #endregion

            #region 启用JWT认证
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


            #region 使用AutoMapper
            // 参数类型是Assembly类型的数组 表示AutoMapper将在这些程序集数组里面遍历寻找所有继承了Profile类的配置文件
            // 在当前作用域的所有程序集里面扫描AutoMapper的配置文件
            // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(Assembly.Load("WorkRecord.API"));
            #endregion

            #region 配置数据库连接
            string connectionString = Configuration.GetSection("ConnectionString").GetSection("DbConnection").Value;
            services.AddDbContext<AppDbContext>(options =>
                    {
                       
                        options.UseSqlServer(connectionString);
                    });
            #endregion

            #region 依赖注入
            //// 使用作用域生命周期
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region 添加Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "WorkRecord", Version = "v1" });
                // 获取xml文件名
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // 获取xml文件路径
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // 添加控制器层注释，true表示显示控制器注释
                options.IncludeXmlComments(xmlPath, true);
            });
            #endregion

            // 添加异常过滤器
            services.AddControllers(options => 
            {
                options.Filters.Add<GlobalExceptionFilter>();
                // options.Filters.Add<GlobalActionFilter>();
            });
        }

        /// <summary>
        /// 使用Autofac替换依赖注入容器
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // 获取当前程序运行路径
            var basePath = AppContext.BaseDirectory;

            builder.RegisterType<LogAOP>().EnableInterfaceInterceptors();

            // 获取程序集的完整路径
            var repositoryDllPath =Path.Combine(basePath,AppsettingHelper.GetValueByKey(new string[] { "DIInfo", "RepositoryDllName" }));
            var serviceDllPath =Path.Combine(basePath, AppsettingHelper.GetValueByKey(new string[] { "DIInfo", "ServiceDllName" }));

            //通过反射的方式获取WordRecord.Repository.dll程序集信息 批量注册Repository
            builder.RegisterAssemblyTypes(Assembly.LoadFrom(repositoryDllPath))
                .AsImplementedInterfaces()
                .InstancePerDependency()
                .EnableInterfaceInterceptors();//引入Autofac.Extras.DynamicProxy

            builder.RegisterAssemblyTypes(Assembly.LoadFrom(serviceDllPath))
              .AsImplementedInterfaces()
              .InstancePerDependency();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 添加Swagger有关中间件
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WorkRecord v1");
            });



            #region 启用身份认证
            // 启用身份认证
            //app.UseAuthentication(); 
            #endregion

            app.UseRouting();

            #region 启用跨域中间件
            // 启用跨域中间件
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
