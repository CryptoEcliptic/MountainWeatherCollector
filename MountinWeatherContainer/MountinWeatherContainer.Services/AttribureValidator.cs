namespace MountinWeatherContainer.Services
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    internal static class AttribureValidator
    {
        internal static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, results, true);
        }
    }
}
