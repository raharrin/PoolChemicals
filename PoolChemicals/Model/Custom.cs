using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public sealed class BetweenAttribute : ValidationAttribute
{
    public BetweenAttribute(string propertyNameLow, string propertyNameHigh)
    {
        PropertyNameLow = propertyNameLow;
        PropertyNameHigh = propertyNameHigh;
    }

    public string PropertyNameLow { get; }
    public string PropertyNameHigh { get; }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        object instance = validationContext.ObjectInstance;
        object otherValueLow = instance.GetType().GetProperty(PropertyNameLow)?.GetValue(instance);
        object otherValueHigh = instance.GetType().GetProperty(PropertyNameHigh)?.GetValue(instance);

        if (otherValueLow == null || otherValueHigh == null)
        {
            return new ValidationResult("Referenced property values cannot be null.");
        }

        if (((IComparable)value).CompareTo(otherValueLow) >= 0 && ((IComparable)value).CompareTo(otherValueHigh) <= 0)
        {
            return ValidationResult.Success;
        }

        // return new ValidationResult(ErrorMessage ?? "The current value is out of range.");
        return new(validationContext.DisplayName + " must be between " + otherValueLow + " and " + otherValueHigh);
    }
}

public sealed class LessThanAttribute : ValidationAttribute
{
    public LessThanAttribute(string propertyName)
    {
        PropertyName = propertyName;
    }

    public string PropertyName { get; }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        object instance = validationContext.ObjectInstance;
        object otherValue = instance.GetType().GetProperty(PropertyName)?.GetValue(instance);

        if (otherValue == null)
        {
            return new ValidationResult("Referenced property value cannot be null.");
        }

        if (((IComparable)value).CompareTo(otherValue) < 0)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "The current value is greater than the other one.");
    }
}

public sealed class GreaterThanAttribute : ValidationAttribute
{
    public GreaterThanAttribute(string propertyName)
    {
        PropertyName = propertyName;
    }

    public GreaterThanAttribute(string propertyName, Single propertyValue)
    {
        PropertyName = propertyName;
        PropertyValue = propertyValue;
    }

    public string PropertyName { get; }
    public Single PropertyValue { get; }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        object instance = validationContext.ObjectInstance;
        object otherValue = instance.GetType().GetProperty(PropertyName)?.GetValue(instance);

        if (otherValue == null)
        {
            return new ValidationResult("Referenced property value cannot be null.");
        }

        if (((IComparable)value).CompareTo(otherValue) > 0)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "The current value is smaller than the other one.");
    }
}
