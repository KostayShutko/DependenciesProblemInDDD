using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quotes.Domain.Entities.Quotes;
using Quotes.Domain.Entities.ValueObjects;
using Quotes.Infrastructure.Database.Converters;

namespace Quotes.Infrastructure.Database.EntityTypeConfigurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(payment => payment.Id);

        builder.Property(payment => payment.Id)
            .HasConversion<ValueObjectConverter<EntityId, Guid>>();

        builder.Property(payment => payment.QuoteId)
            .HasConversion<ValueObjectConverter<EntityId, Guid>>();
    }
}
