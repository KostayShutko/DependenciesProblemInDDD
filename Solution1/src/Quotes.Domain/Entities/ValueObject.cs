using System.Reflection;

namespace Quotes.Domain.Entities;

public abstract class ValueObject<TValue> : ValueObject
{
    protected ValueObject()
    {
    }

    protected ValueObject(TValue value)
    {
        Value = value;
    }

    public TValue Value { get; set; }

    public static implicit operator TValue(ValueObject<TValue> valueObject) => valueObject.Value;
}

public abstract class ValueObject
{
    private readonly BindingFlags privateBindingFlags =
        BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

    public override bool Equals(object? other)
    {
        if (other == null)
        {
            return false;
        }

        var type = GetType();
        var otherType = other.GetType();

        if (type != otherType)
        {
            return false;
        }

        var fields = type.GetFields(privateBindingFlags);

        foreach (var field in fields)
        {
            var firstValue = field.GetValue(other);
            var secondValue = field.GetValue(this);

            if (firstValue == null)
            {
                if (secondValue != null)
                {
                    return false;
                }
            }
            else if (!firstValue.Equals(secondValue))
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        var fields = GetFields();

        const int startValue = 17;
        const int multiplier = 59;

        return fields
            .Select(field => field.GetValue(this))
            .Where(value => value != null)
            .Aggregate(startValue, (current, value) => current * multiplier + value!.GetHashCode());
    }

    public static bool operator ==(ValueObject? first, ValueObject? second)
    {
        if (first is null && second is null)
        {
            return true;
        }

        if (first is null || second is null)
        {
            return false;
        }

        return first.Equals(second);
    }

    public static bool operator !=(ValueObject first, ValueObject second) => !(first == second);

    private IEnumerable<FieldInfo> GetFields()
    {
        var type = GetType();

        var fields = new List<FieldInfo>();

        while (type != typeof(object) && type != null)
        {
            fields.AddRange(type.GetFields(privateBindingFlags));

            type = type.BaseType!;
        }

        return fields;
    }
}
