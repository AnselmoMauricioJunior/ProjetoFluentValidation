using ApiProjetoFluentValidation.Core.Models;
using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace ApiProjetoFluentValidation.Core.Interfaces.Validations
{
    public abstract class IPlantaValidation : AbstractValidator<Planta>
    {
        public abstract void ValidarId();
        public abstract void ValidarNome();
        public abstract void ValidarLuzDiaria();
        public abstract void ValidarAgua();
        public abstract void ValidarPeso();
    }

    public static class IPlantaValidationUtils
    {
        public static async Task<ValidationResult> CriarValidateAsync(this IPlantaValidation pv, Planta planta)
        {
            pv.ValidarNome();
            pv.ValidarAgua();
            pv.ValidarLuzDiaria();
            pv.ValidarPeso();
            pv.ValidarId();
            return await pv.ValidateAsync(planta);
        }

        public static async Task<ValidationResult> AlterarPesoValidateAsync(this IPlantaValidation pv, Planta planta)
        {
            pv.ValidarPeso();
            return await pv.ValidateAsync(planta);
        }

        public static async Task<ValidationResult> AlterarAguaValidateAsync(this IPlantaValidation pv, Planta planta)
        {
            pv.ValidarAgua();
            return await pv.ValidateAsync(planta);
        }

        public static async Task<ValidationResult> AlterarLuzDiariaValidateAsync(this IPlantaValidation pv, Planta planta)
        {
            pv.ValidarLuzDiaria();
            return await pv.ValidateAsync(planta);
        }

        public static async Task<ValidationResult> AlterarNomeValidateAsync(this IPlantaValidation pv, Planta planta)
        {
            pv.ValidarNome();
            return await pv.ValidateAsync(planta);
        }

        public static async Task<ValidationResult> RemoverValidateAsync(this IPlantaValidation pv, Planta planta)
        {
            pv.ValidarId();
            return await pv.ValidateAsync(planta);
        }
    }
}
