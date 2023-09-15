using System.ComponentModel.DataAnnotations;

namespace BCP.Distributed.CustomAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class AllowedValuesAttribute : ValidationAttribute
    {
        private readonly string[] allowedValues;

        public AllowedValuesAttribute(params string[] values)
        {
            allowedValues = values;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string strValue = value.ToString();
                if (!allowedValues.Contains(strValue))
                {
                    return new ValidationResult("El valor no está permitido.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
