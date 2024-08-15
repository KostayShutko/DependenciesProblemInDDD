using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quotes.Domain.Entities;

namespace Quotes.Infrastructure.Database.Converters;

public class ValueObjectConverter<TValueObject, TType> : ValueConverter<TValueObject, TType>
    where TValueObject : ValueObject<TType>
{
    public ValueObjectConverter() 
        : base(valueObject => valueObject.Value, value => CreateInstance(value)) 
    {
    }

    private static TValueObject CreateInstance(TType value) => 
        (TValueObject)Activator.CreateInstance(typeof(TValueObject), value);
}
