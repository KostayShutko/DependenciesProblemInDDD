﻿using Quotes.Domain.BusinessRules;

namespace Quotes.Domain.Entities.ValueObjects;

public class Cost : ValueObject<decimal>
{
    public Cost(decimal cost)
        : base(cost)
    {
        BusinessRulesValidator.CheckRule(new CostMustBeGreaterThanZeroRule(cost));
    }

    public static Cost operator *(Cost cost, Quantity quantity) => new Cost(cost.Value * quantity.Value);

    public static Cost operator *(Cost cost, Tax tax) => new Cost(cost.Value * tax.Value);

    public static Cost operator *(Cost cost, Discount discount) => new Cost(cost.Value * discount.Value);

    public static Cost operator +(Cost first, Cost second) => new Cost(first.Value + second.Value);

    public static implicit operator Cost(decimal cost) => new Cost(cost);
}