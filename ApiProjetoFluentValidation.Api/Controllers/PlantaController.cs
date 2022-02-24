using ApiProjetoFluentValidation.Core.Interfaces.Infra.Repository;
using ApiProjetoFluentValidation.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFluentValidation.Api.Views;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ProjetoFluentValidation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Plantas e algumas informações básicas")]
    public class PlantaController : ControllerBase
    {
        [HttpGet("")]
        [SwaggerOperation(Summary = "Lista todas as plantas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterAsync(
           [FromServices] IPlantaServices services)
        {
            return Ok(await services.ObterAsync());
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Lista uma planta pelo id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterPorIdAsync(
            [FromServices] IPlantaServices services,
            [FromRoute] int id)
            => Ok(await services.ObterPorIdAsync(id));

        [HttpPost("")]
        [SwaggerOperation(Summary = "Cria uma planta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarAsync(
            [FromServices] IPlantaServices services,
            [FromBody] CriarPlantaVM vm)
            => Ok(await services.CriarAsync(vm.ToModel()));

        [HttpPut("{id:int}/{nome}")]
        [SwaggerOperation(Summary = "Alterar nome")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AlterarNomeAsync(
           [FromServices] IPlantaServices services,
           [FromRoute] int id,
           [FromRoute] string nome)
            => Ok(await services.AlterarNomeAsync(id, nome));

        [HttpPut("{id:int}/{luzdiaria:int}")]
        [SwaggerOperation(Summary = "Alterar luz diária")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AlterarLuzDiariaAsync(
          [FromServices] IPlantaServices services,
          [FromRoute] int id,
          [FromRoute] int luzdiaria)
           => Ok(await services.AlterarLuzDiariaAsync(id, luzdiaria));

        [HttpPut("{id:int}/{agua:int}")]
        [SwaggerOperation(Summary = "Alterar litros de água por dia")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AlterarAguaAsync(
          [FromServices] IPlantaServices services,
          [FromRoute] int id,
          [FromRoute] int agua)
           => Ok(await services.AlterarAguaAsync(id, agua));

        [HttpPut("{id:int}/{peso:int}")]
        [SwaggerOperation(Summary = "Alterar peso")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AlterarPesoAsync(
          [FromServices] IPlantaServices services,
          [FromRoute] int id,
          [FromRoute] int peso)
           => Ok(await services.AlterarPesoAsync(id, peso));

        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Remove uma planta cadastrada")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoverAsync(
          [FromServices] IPlantaServices services,
          [FromRoute] int id)
        {
            await services.RemoverAsync(id);
            return Ok();
        }
    }
}
