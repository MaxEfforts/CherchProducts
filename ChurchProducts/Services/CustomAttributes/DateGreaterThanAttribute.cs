using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectBase.Services.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateGreaterThanAttribute : ValidationAttribute
    {

        private string DateToCompareFieldName { get; set; }
        public string _errorMessage { get; set; }
        public DateGreaterThanAttribute(string dateToCompareFieldName, string ErrorMessage)
        {
            _errorMessage = ErrorMessage;
            DateToCompareFieldName = dateToCompareFieldName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime laterDate = (DateTime)value;

            DateTime earlierDate = (DateTime)validationContext.ObjectType.GetProperty(DateToCompareFieldName).GetValue(validationContext.ObjectInstance, null);

            if (laterDate > earlierDate)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(_errorMessage);
            }
        }

    }
}