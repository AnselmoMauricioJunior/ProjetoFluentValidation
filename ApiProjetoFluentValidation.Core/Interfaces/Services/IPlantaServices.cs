using ApiProjetoFluentValidation.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoFluentValidation.Core.Interfaces.Services
{
    public interface IPlantaServices
    {
        Task<IEnumerable<Planta>> ObterAsync();
        Task<Planta> ObterPorIdAsync(int id);
        Task<Planta> CriarAsync(Planta planta);
        Task<Planta> AlterarNomeAsync(int id, string nome);
        Task<Planta> AlterarLuzDiariaAsync(int id, int luzdiaria);
        Task<Planta> AlterarAguaAsync(int id, int agua);
        Task<Planta> AlterarPesoAsync(int id, int peso);
        Task RemoverAsync(int id);
    }
}
