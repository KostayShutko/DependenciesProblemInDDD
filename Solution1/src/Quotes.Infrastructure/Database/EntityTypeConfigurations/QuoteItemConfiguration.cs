using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quotes.Domain.Entities.Quotes;
using Quotes.Domain.Entities.ValueObjects;
using Quotes.Infrastructure.Database.Converters;

namespace Quotes.Infrastructure.Database.EntityTypeConfigurations;

public class QuoteItemConfiguration : IEntityTypeConfiguration<QuoteItem>
{
    public void Configure(EntityTypeBuilder<QuoteItem> builder)
    {
        builder.HasKey(quoteItem => quoteItem.Id);

        builder.Property(quoteItem => quoteItem.Id)
            .HasConversion<ValueObjectConverter<EntityId, Guid>>();

        builder.Property(quoteItem => quoteItem.QuoteId)
            .HasConversion<ValueObjectConverter<EntityId, Guid>>();

        builder.Property(quoteItem => quoteItem.Name)
            .HasConversion<ValueObjectConverter<Title, string>>();

        builder.Property(quoteItem => quoteItem.Code)
            .HasConversion<ValueObjectConverter<Code, string>>();

        builder.Property(quoteItem => quoteItem.Quantity)
            .HasConversion<ValueObjectConverter<Quantity, int>>();

        builder.Property(quoteItem => quoteItem.Cost)
            .HasConversion<ValueObjectConverter<Cost, decimal>>();
    }
}
