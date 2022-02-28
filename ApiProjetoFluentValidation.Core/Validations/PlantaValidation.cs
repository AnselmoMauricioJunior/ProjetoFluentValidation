using ApiProjetoFluentValidation.Core.Interfaces.Infra.Repository;
using ApiProjetoFluentValidation.Core.Interfaces.Validations;
using ApiProjetoFluentValidation.Core.Models;
using FluentValidation;
using FluentValidation.Results;
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

        public async override Task<ValidationResult> CriarValidateAsync(Planta planta)
        {
            ValidarNome();
            ValidarAgua();
            ValidarLuzDiaria();
            ValidarPeso();
            return await ValidateAsync(planta);
        }

        public async override Task<ValidationResult> AlterarPesoValidateAsync(Planta planta)
        {
            ValidarPeso();
            return await ValidateAsync(planta);
        }

        public async override Task<ValidationResult> AlterarAguaValidateAsync(Planta planta)
        {
            ValidarAgua();
            return await ValidateAsync(planta);
        }

        public async override Task<ValidationResult> AlterarLuzDiariaValidateAsync(Planta planta)
        {
            ValidarLuzDiaria();
            return await ValidateAsync(planta);
        }

        public async override Task<ValidationResult> AlterarNomeValidateAsync(Planta planta)
        {
            ValidarNome();
            return await ValidateAsync(planta);
        }

        public async override Task<ValidationResult> RemoverValidateAsync(Planta planta)
        {
            ValidarId();
            return await ValidateAsync(planta);
        }
        private void ValidarAgua()
        {
            RuleFor(o => o.agua)
             .Must(agua => agua > 0).WithMessage("O valor da água deve ser maior que zero, valor enviado '{PropertyValue}'");

        }

        private void ValidarLuzDiaria()
        {
            RuleFor(o => o.luzdiaria)
            .Must(luzdiaria => luzdiaria > 0).WithMessage("O valor da luz diária deve ser maior que zero, valor enviado '{PropertyValue}'");

        }

        private void ValidarNome()
        {
            RuleFor(o => o.nome)
                .NotEmpty().WithMessage("Nome da planta deve ser informado")
                .MustAsync(NomeJaCadastradoAsync).WithMessage("Planta com o nome '{PropertyValue}' já existe");
        }

        private void ValidarPeso()
        {
            RuleFor(o => o.peso)
           .Must(peso => peso > 0).WithMessage("O valor do peso deve ser maior que zero, valor enviado '{PropertyValue}'");

        }

        private void ValidarId()
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
