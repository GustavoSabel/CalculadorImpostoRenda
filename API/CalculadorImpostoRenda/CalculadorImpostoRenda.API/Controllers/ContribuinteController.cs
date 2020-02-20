using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculadorImpostoRenda.Dominio.Commands;
using CalculadorImpostoRenda.Dominio.Entidades;
using CalculadorImpostoRenda.Dominio.Handlers;
using CalculadorImpostoRenda.Dominio.Repository;
using CalculadorImpostoRenda.infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return repository.Obter(id);
        }

        [HttpPost]
        public Task Post([FromBody] InserirContribuinteCommand command, [FromServices] ContribuinteHandler handler)
        {
            return handler.Inserir(command);
        }

        [HttpPut]
        public Task Put([FromBody] AtualizarContribuinteCommand command, [FromServices] ContribuinteHandler handler)
        {
            return handler.Atualizar(command);
        }

        [HttpDelete("{id}")]
        public Task Delete(int id, [FromServices] ContribuinteHandler handler)
        {
            return handler.Excluir(new ExcluirContribuinteCommand() { Id = id });
        }
    }
}
