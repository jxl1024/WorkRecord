using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using WordRecord.IRepository.Repository;
using WordRecord.Repository.Repositories;
using WorkRecord.Data.Context;
using WorkRecord.IService.Service;
using WorkRecord.Service.Service;

namespace WorkRecord.API
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

            services.AddControllers();
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
