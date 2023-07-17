using System;
using System.ComponentModel.DataAnnotations;

namespace SuggeBook.Framework
{
    public class RequiredIfNotAttribute : RequiredAttribute
    {
        public string PropertyName { get;}
        public object DesiredValue { get;}

        public RequiredIfNotAttribute(string propertyName, object desiredValue)
        {
            PropertyName = propertyName;
            DesiredValue = desiredValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            Object instance = context.ObjectInstance;
            Type type = instance.GetType();
            Object propertyValue = type.GetProperty(PropertyName).GetValue(instance, null);
            if (propertyValue !=null && propertyValue.ToString() != DesiredValue.ToString())
            {
                ValidationResult result = base.IsValid(value, context);
                return result;
            }
            return ValidationResult.Success;
        }
    }
}
