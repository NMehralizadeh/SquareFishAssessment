using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SquareFish.Assessment.Domain.Entities;

namespace SquareFish.Assessment.Infrastructure.Configurations
{
    public class BaseEntityConfigurations<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}