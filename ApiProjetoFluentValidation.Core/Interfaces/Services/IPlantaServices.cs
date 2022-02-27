using ApiProjetoFluentValidation.Core.Interfaces.Dtos;
using ApiProjetoFluentValidation.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoFluentValidation.Core.Interfaces.Services
{
    public interface IPlantaServices
    {
        Task<IEnumerable<Planta>> ObterAsync();
        Task<Planta> ObterPorIdAsync(int id);
        Task<IResultDto> CriarAsync(Planta planta);
        Task<IResultDto> AlterarNomeAsync(int id, string nome);
        Task<IResultDto> AlterarLuzDiariaAsync(int id, int luzdiaria);
        Task<IResultDto> AlterarAguaAsync(int id, int agua);
        Task<IResultDto> AlterarPesoAsync(int id, int peso);
        Task<IResultDto> RemoverAsync(int id);
    }
}
