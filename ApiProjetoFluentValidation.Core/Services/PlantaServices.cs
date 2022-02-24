
using ApiProjetoFluentValidation.Core.Interfaces.Infra.Repository;
using ApiProjetoFluentValidation.Core.Interfaces.Services;
using ApiProjetoFluentValidation.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoFluentValidation.Core.Services
{
    public class PlantaServices : IPlantaServices
    {
        private IPlantaRepository _plantaRepository;

        public PlantaServices(IPlantaRepository plantaRepository)
        {
            _plantaRepository = plantaRepository;
        }
        public async Task<Planta> AlterarAguaAsync(int id, int agua)
        {
            //TODO Validações
            await _plantaRepository.AlterarAguaAsync(id, agua);
            return await _plantaRepository.ObterPorIdAsync(id);
        }

        public async Task<Planta> AlterarLuzDiariaAsync(int id, int luzdiaria)
        {
            //TODO Validações
            await _plantaRepository.AlterarLuzDiariaAsync(id, luzdiaria);
            return await _plantaRepository.ObterPorIdAsync(id);
        }

        public async Task<Planta> AlterarNomeAsync(int id, string nome)
        {
            //TODO Validações
            await _plantaRepository.AlterarNomeAsync(id, nome);
            return await _plantaRepository.ObterPorIdAsync(id);
        }

        public async Task<Planta> AlterarPesoAsync(int id, int peso)
        {
            //TODO Validações
            await _plantaRepository.AlterarPesoAsync(id, peso);
            return await _plantaRepository.ObterPorIdAsync(id);
        }

        public async Task<Planta> CriarAsync(Planta planta)
        {
            //TODO Validações
            int id = await _plantaRepository.CriarAsync(planta);
            return await _plantaRepository.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<Planta>> ObterAsync()
        {
            return await _plantaRepository.ObterAsync();
        }

        public async Task<Planta> ObterPorIdAsync(int id)
        {
            return await _plantaRepository.ObterPorIdAsync(id);
        }

        public async Task RemoverAsync(int id)
        {
            await _plantaRepository.RemoverAsync(id);
        }
    }
}
