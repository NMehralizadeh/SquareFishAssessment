using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SquareFish.Assessment.Domain.Entities;

namespace SquareFish.Assessment.Infrastructure.Configurations
{
    public class CurrencyConfigurations : BaseEntityConfigurations<Currency>
    {
        public override void Configure(EntityTypeBuilder<Currency> builder)
        {
            base.Configure(builder);
        }
    }
}