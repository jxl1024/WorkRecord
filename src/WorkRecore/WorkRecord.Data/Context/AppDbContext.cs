using Microsoft.EntityFrameworkCore;
using System;
using WorkRecord.Common.Helper;
using WorkRecord.Data.Mapping;
using WorkRecord.Model.Entity;

namespace WorkRecord.Data.Context
{
    /// <summary>
    /// 数据上下文类，继承自DbContext
    /// </summary>
    public class AppDbContext:DbContext
    {
        /// <summary>
        /// 通过构造函数给父类传参
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        /// <summary>
        /// 重写OnModelCreating方法
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 应用配置类
            modelBuilder.ApplyConfiguration<User>(new UserMap());
            modelBuilder.ApplyConfiguration<Role>(new RoleMap());
            modelBuilder.ApplyConfiguration<Department>(new DepartmentMap());
            modelBuilder.ApplyConfiguration<WorkItem>(new WorkItemMap());
            #endregion

            // 加密密码
            string strEncryPwd = MD5Helper.Get32UpperMD5("123456");
            // 系统管理员Id
            string strSystemId = Guid.NewGuid().ToString();


            #region 部门
            // 开发部ID
            string strDevId = Guid.NewGuid().ToString();
            // 综合管理部ID
            string strManageId = Guid.NewGuid().ToString();
            #endregion

            #region 角色
            // 系统管理员
            string strSystemRoleId = Guid.NewGuid().ToString();
            // 部门管理员
            string strDeptRoleId = Guid.NewGuid().ToString();
            // 普通员工
            string strGeneralRoleId = Guid.NewGuid().ToString();
            #endregion

            #region 添加种子数据

            #region 部门数据
            // 部门
            modelBuilder.Entity<Department>().HasData(
                new Department()
                {
                    DeptID = strDevId,
                    DeptCode = "1001",
                    DeptName = "开发部",
                    CreatedUserId= strSystemId,
                    UpdatedUserId= strSystemId
                },
                new Department()
                {
                    DeptID = strManageId,
                    DeptCode = "2001",
                    DeptName = "综合管理部",
                    CreatedUserId = strSystemId,
                    UpdatedUserId = strSystemId
                }
                );
            #endregion

            #region 用户数据
            //  
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserID = strSystemId,
                    Account = "System",
                    Password = strEncryPwd,
                    Name = "系统管理员",
                    // 管理员
                    RoleID = strSystemRoleId,
                    DepartmentID = strManageId,
                    CreatedUserId = strSystemId,
                    UpdatedUserId = strSystemId
                },
                new User()
                {
                    UserID = Guid.NewGuid().ToString(),
                    Account = "admin",
                    Password = strEncryPwd,
                    Name = "admin",
                    // 管理员
                    RoleID = strDeptRoleId,
                    DepartmentID = strDevId,
                    CreatedUserId = strSystemId,
                    UpdatedUserId = strSystemId
                },
                new User()
                {
                    UserID = Guid.NewGuid().ToString(),
                    Account = "张三",
                    Password = strEncryPwd,
                    Name = "张三",
                    // 普通员工
                    RoleID = strGeneralRoleId,
                    DepartmentID = strDevId,
                    CreatedUserId = strSystemId,
                    UpdatedUserId = strSystemId
                }
            );
            #endregion


            #region 角色数据
            // 
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    RoleID = strSystemRoleId,
                    RoleCode = "1",
                    RoleName = "系统管理员",
                    CreatedUserId = strSystemId,
                    UpdatedUserId = strSystemId
                },
                new Role()
                {
                    RoleID = strDeptRoleId,
                    RoleCode = "2",
                    RoleName = "部门管理员",
                    CreatedUserId = strSystemId,
                    UpdatedUserId = strSystemId
                },
                new Role()
                {
                    RoleID = strGeneralRoleId,
                    RoleCode = "3",
                    RoleName = "普通员工",
                    CreatedUserId = strSystemId,
                    UpdatedUserId = strSystemId
                }
                ); 
            #endregion
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        #region DbSet属性
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        #endregion
    }
}
