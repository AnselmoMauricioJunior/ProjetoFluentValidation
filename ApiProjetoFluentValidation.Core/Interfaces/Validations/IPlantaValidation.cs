using ApiProjetoFluentValidation.Core.Models;
using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace ApiProjetoFluentValidation.Core.Interfaces.Validations
{
    public abstract class IPlantaValidation : AbstractValidator<Planta>
    {

        public abstract Task<ValidationResult> CriarValidateAsync(Planta planta);
        public abstract Task<ValidationResult> AlterarPesoValidateAsync(Planta planta);
        public abstract Task<ValidationResult> AlterarAguaValidateAsync(Planta planta);
        public abstract Task<ValidationResult> AlterarLuzDiariaValidateAsync(Planta planta);
        public abstract Task<ValidationResult> AlterarNomeValidateAsync(Planta planta);
        public abstract Task<ValidationResult> RemoverValidateAsync(Planta planta);

    }

}
