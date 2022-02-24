using ProjetoFluentValidation.Api.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFluentValidation.Api.Views
{
    public class CriarPlantaVM
    {
        [RequiredNotEmptyStringButAcceptNull]
        public string nome { get; set; }
        [Required]
        public int luzdiaria { get; set; }
        [Required]
        public int agua { get; set; }
        [Required]
        public int peso { get; set; }
    }

    public static class CriarPlantaVMUtils
    {
        public static ApiProjetoFluentValidation.Core.Models.Planta ToModel(this CriarPlantaVM vm)
        {
            return new ApiProjetoFluentValidation.Core.Models.Planta(vm.nome, vm.luzdiaria, vm.agua, vm.peso);
        }
    }
}
