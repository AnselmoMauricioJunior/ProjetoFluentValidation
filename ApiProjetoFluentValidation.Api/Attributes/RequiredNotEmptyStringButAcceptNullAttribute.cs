using System.ComponentModel.DataAnnotations;

namespace ProjetoFluentValidation.Api.Attributes
{
    public class RequiredNotEmptyStringButAcceptNullAttribute : RequiredAttribute
    {
        public RequiredNotEmptyStringButAcceptNullAttribute()
        {
            ErrorMessage = "Não é permitido string vazia";
        }

        public override bool IsValid(object value)
        {
            if (value is string && !string.IsNullOrWhiteSpace((string)value))
                return true;

            if (value is null)
                return true;

            return base.IsValid(value);
        }
    }
}
