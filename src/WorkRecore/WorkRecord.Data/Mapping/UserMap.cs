using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkRecord.Model.Entity;

namespace WorkRecord.Data.Mapping
{
    /// <summary>
    /// User实体类的配置信息 继承自IEntityTypeConfiguration接口
    /// </summary>
    public class UserMap : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// 重写Configure方法，具体的配置信息写在这里
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // 配置生成的表名
            builder.ToTable("T_User");
            // 配置主键
            builder.HasKey(p => p.UserID);
            builder.Property(p => p.UserID).HasMaxLength(50);
            // 配置账户最大长度为32，并且不能为空
            builder.Property(p => p.Account).HasMaxLength(32).IsRequired();
            // 配置密码最大长度为32，并且不能为空
            builder.Property(p => p.Password).HasMaxLength(32).IsRequired();
            // 配置姓名最大长度为32，并且不能为空
            builder.Property(p => p.Name).HasMaxLength(32).IsRequired();
            // 配置RoleID不能为空
            builder.Property(p => p.RoleID).HasMaxLength(50).IsRequired();
            // 配置DepartmentID不能为空
            builder.Property(p => p.DepartmentID).HasMaxLength(50).IsRequired();
            // 设置CreatedUserId和UpdatedUserId
            builder.Property(p => p.CreatedUserId).HasMaxLength(50).IsRequired();
            builder.Property(p => p.UpdatedUserId).HasMaxLength(50).IsRequired();
            // 配置CreatedTime列的类型
            builder.Property(p => p.CreatedTime).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()");
            // 配置UpdatedTime列为计算列
            builder.Property(p => p.UpdatedTime).HasColumnType("DATETIME").HasComputedColumnSql("GETDATE()");
        }
    }
}
