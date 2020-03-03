using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkRecord.Model.Entity;

namespace WorkRecord.Data.Mapping
{
    public class WorkItemMap : IEntityTypeConfiguration<WorkItem>
    {
        public void Configure(EntityTypeBuilder<WorkItem> builder)
        {
            builder.ToTable("T_WorkItem");
            // 主键
            builder.HasKey(p => p.WorkID);
            builder.Property(p => p.WorkID).HasMaxLength(50);
            // 记录日期
            builder.Property(p => p.RecordTime).HasColumnType("DATETIME");
            // 备注
            builder.Property(p => p.Memos).HasMaxLength(128);
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
