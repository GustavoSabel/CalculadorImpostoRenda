using CalculadorImpostoRenda.Dominio.Commands;
using CalculadorImpostoRenda.Dominio.Entidades;
using CalculadorImpostoRenda.Dominio.Handlers;
using CalculadorImpostoRenda.Dominio.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalculadorImpostoRenda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuinteController : ControllerBase
    {
        [HttpGet]
        public Task<List<Contribuinte>> Get([FromServices] IContribuinteRepositoryRead repository)
        {
            return repository.Todos().ToListAsync();
        }

        [HttpGet("{id}")]
        public ValueTask<Contribuinte> Get(int id, [FromServices] IContribuinteRepositoryRead repository)
        {
            return repository.ObterAsync(id);
        }

        [HttpPost]
        public ValueTask<Contribuinte> Post([FromBody] InserirContribuinteCommand command, [FromServices] ContribuinteHandler handler)
        {
            return handler.HandleAsync(command);
        }

        [HttpPut]
        public ValueTask Put([FromBody] AtualizarContribuinteCommand command, [FromServices] ContribuinteHandler handler)
        {
            return handler.HandleAsync(command);
        }

        [HttpDelete("{id}")]
        public ValueTask Delete(int id, [FromServices] ContribuinteHandler handler)
        {
            return handler.HandleAsync(new ExcluirContribuinteCommand() { Id = id });
        }

        [HttpPost("calcularImpostoRenda")]
        public ValueTask<IReadOnlyList<Contribuinte>> Post([FromBody] CalcularImpostoRendaCommand command, [FromServices] ContribuinteHandler handler)
        {
            return handler.HandleAsync(command);
        }
    }
}
