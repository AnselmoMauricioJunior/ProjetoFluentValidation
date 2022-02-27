using ApiProjetoFluentValidation.Core.Interfaces.Infra.Repository;
using ApiProjetoFluentValidation.Core.Interfaces.Validations;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
namespace ApiProjetoFluentValidation.Core.Validations
{
    public class PlantaValidation : IPlantaValidation
    {
        private readonly IPlantaRepository _plantaRepository;
        public PlantaValidation(IPlantaRepository plantaRepository)
        {
            _plantaRepository = plantaRepository;
        }

        public override void ValidarAgua()
        {
            RuleFor(o => o.agua)
             .Must(agua => agua > 0).WithMessage("O valor da água deve ser maior que zero, valor enviado '{PropertyValue}'");

        }

        public override void ValidarLuzDiaria()
        {
            RuleFor(o => o.luzdiaria)
            .Must(luzdiaria => luzdiaria > 0).WithMessage("O valor da luz diária deve ser maior que zero, valor enviado '{PropertyValue}'");

        }

        public override void ValidarNome()
        {
            RuleFor(o => o.nome)
                .NotEmpty().WithMessage("Nome da planta deve ser informado")
                .MustAsync(NomeJaCadastradoAsync).WithMessage("Planta com o nome '{PropertyValue}' já existe");
        }

        public override void ValidarPeso()
        {
            RuleFor(o => o.peso)
           .Must(peso => peso > 0).WithMessage("O valor do peso deve ser maior que zero, valor enviado '{PropertyValue}'");

        }

        public override void ValidarId()
        {
            RuleFor(o => o.ID)
               .MustAsync(IdNaoCadastradoAsync).WithMessage("Não existe planta com id: '{PropertyValue}'");

        }

        private async Task<bool> NomeJaCadastradoAsync(string nome, CancellationToken ct)
        {
            var planta = await _plantaRepository.ObterPorNomeAsync(nome);

            return planta == null;
        }

        private async Task<bool> IdNaoCadastradoAsync(int id, CancellationToken ct)
        {
            var planta = await _plantaRepository.ObterPorIdAsync(id);

            return planta != null;
        }
    }
}
