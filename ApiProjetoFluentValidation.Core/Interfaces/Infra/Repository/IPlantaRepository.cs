using ApiProjetoFluentValidation.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoFluentValidation.Core.Interfaces.Infra.Repository
{
    public interface IPlantaRepository
    {
        Task<IEnumerable<Planta>> ObterAsync();
        Task<Planta> ObterPorIdAsync(int id);
        Task<Planta> ObterPorNomeAsync(string nome);
        Task<int> CriarAsync(Planta planta);
        Task AlterarNomeAsync(int id,string nome);
        Task AlterarLuzDiariaAsync(int id, int luzdiaria);
        Task AlterarAguaAsync(int id, int agua);
        Task AlterarPesoAsync(int id, int peso);
        Task RemoverAsync(int id);
    }
}
