using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkRecord.Model.Entity;

namespace WorkRecord.Data.Mapping
{
    public class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // 设置生成的表名
            builder.ToTable("T_Department");
            // 设置主键
            builder.HasKey(p => p.DeptID);
            // 设置主键最大长度
            builder.Property(p => p.DeptID).HasMaxLength(50);
            // 设置部门编码最大长度
            builder.Property(p => p.DeptCode).HasMaxLength(16);
            // 设置部门名称最大长度
            builder.Property(p=>p.DeptName).HasMaxLength(32);
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
