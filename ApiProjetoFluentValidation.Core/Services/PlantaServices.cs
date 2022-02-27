using ApiProjetoFluentValidation.Core.Dtos;
using ApiProjetoFluentValidation.Core.Interfaces.Dtos;
using ApiProjetoFluentValidation.Core.Interfaces.Infra.Repository;
using ApiProjetoFluentValidation.Core.Interfaces.Services;
using ApiProjetoFluentValidation.Core.Interfaces.Validations;
using ApiProjetoFluentValidation.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoFluentValidation.Core.Services
{
    public class PlantaServices : IPlantaServices
    {
        private readonly IPlantaRepository _plantaRepository;
        private readonly IPlantaValidation _plantavalidation;

        public PlantaServices(IPlantaRepository plantaRepository, IPlantaValidation plantavalidation)
        {
            _plantaRepository = plantaRepository;
            _plantavalidation = plantavalidation;
        }
        public async Task<IResultDto> AlterarAguaAsync(int id, int agua)
        {
            var result = await _plantavalidation.AlterarAguaValidateAsync(new Planta("", 0, agua, 0));

            if (!result.IsValid)
                return ResultDto.Erro(new { id, agua }, result);

            await _plantaRepository.AlterarAguaAsync(id, agua);
            var plantaResultado = await _plantaRepository.ObterPorIdAsync(id);

            return ResultDto.Sucesso(plantaResultado);
        }

        public async Task<IResultDto> AlterarLuzDiariaAsync(int id, int luzdiaria)
        {
            var result = await _plantavalidation.AlterarLuzDiariaValidateAsync(new Planta("", luzdiaria, 0, 0));

            if (!result.IsValid)
                return ResultDto.Erro(new { id, luzdiaria }, result);

            await _plantaRepository.AlterarLuzDiariaAsync(id, luzdiaria);
            var plantaResultado = await _plantaRepository.ObterPorIdAsync(id);

            return ResultDto.Sucesso(plantaResultado);
        }

        public async Task<IResultDto> AlterarNomeAsync(int id, string nome)
        {
            var result = await _plantavalidation.AlterarNomeValidateAsync(new Planta(nome));

            if (!result.IsValid)
                return ResultDto.Erro(new { id, nome }, result);

            await _plantaRepository.AlterarNomeAsync(id, nome);
            var plantaResultado = await _plantaRepository.ObterPorIdAsync(id);

            return ResultDto.Sucesso(plantaResultado);
        }

        public async Task<IResultDto> AlterarPesoAsync(int id, int peso)
        {
            var result = await _plantavalidation.AlterarPesoValidateAsync(new Planta("", 0, 0, peso));

            if (!result.IsValid)
                return ResultDto.Erro(new { id, peso }, result);

            await _plantaRepository.AlterarPesoAsync(id, peso);
            var plantaResultado = await _plantaRepository.ObterPorIdAsync(id);

            return ResultDto.Sucesso(plantaResultado);
        }

        public async Task<IResultDto> CriarAsync(Planta planta)
        {
            var result = await _plantavalidation.CriarValidateAsync(planta);

            if (!result.IsValid)
                return ResultDto.Erro(planta, result);

            int id = await _plantaRepository.CriarAsync(planta);
            var plantaResultado = await _plantaRepository.ObterPorIdAsync(id);

            return ResultDto.Sucesso(plantaResultado);
        }

        public async Task<IEnumerable<Planta>> ObterAsync()
        {
            return await _plantaRepository.ObterAsync();
        }

        public async Task<Planta> ObterPorIdAsync(int id)
        {
            return await _plantaRepository.ObterPorIdAsync(id);
        }

        public async Task<IResultDto> RemoverAsync(int id)
        {
            var result = await _plantavalidation.RemoverValidateAsync(new Planta(id));

            if (!result.IsValid)
                return ResultDto.Erro(new { id }, result);
            await _plantaRepository.RemoverAsync(id);

            return ResultDto.Sucesso(new { id });
        }
    }
}
