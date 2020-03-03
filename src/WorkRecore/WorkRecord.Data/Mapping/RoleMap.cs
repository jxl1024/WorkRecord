using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkRecord.Model.Entity;

namespace WorkRecord.Data.Mapping
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("T_Role");
            builder.HasKey(p => p.RoleID);
            // 设置主键最大长度
            builder.Property(p => p.RoleID).HasMaxLength(50);
            builder.Property(p => p.RoleCode).HasMaxLength(16);
            builder.Property(p => p.RoleName).HasMaxLength(32);
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
