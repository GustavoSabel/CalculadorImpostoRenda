using CalculadorImpostoRenda.Dominio.Commands;
using CalculadorImpostoRenda.Dominio.Entidades;
using CalculadorImpostoRenda.Dominio.Helpers;
using CalculadorImpostoRenda.Dominio.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalculadorImpostoRenda.Dominio.Handlers
{
    public class ContribuinteHandler
    {
        private readonly IContribuinteRepository _contribuinteRepository;

        public ContribuinteHandler(IContribuinteRepository contribuinteRepository)
        {
            _contribuinteRepository = contribuinteRepository;
        }

        public async ValueTask<Contribuinte> HandleAsync(InserirContribuinteCommand command)
        {
            var contribuinte = new Contribuinte
            {
                CPF = command.Cpf,
                Nome = command.Nome,
                NumeroDependentes = command.NumeroDependentes,
                RendaMensalBruta = command.RendaMensalBruta
            };
            _contribuinteRepository.InserirOuAtualizar(contribuinte);
            await _contribuinteRepository.SaveChangesAsync();
            return contribuinte;
        }

        public async ValueTask HandleAsync(AtualizarContribuinteCommand command)
        {
            var contribuinte = await _contribuinteRepository.ObterAsync(command.Id);
            if (contribuinte == null)
                throw new Exception($"Contribuinte {command.Id} não encontrado");

            contribuinte.Nome = command.Nome;
            contribuinte.NumeroDependentes = command.NumeroDependentes;
            contribuinte.RendaMensalBruta = command.RendaMensalBruta;

            _contribuinteRepository.InserirOuAtualizar(contribuinte);
            await _contribuinteRepository.SaveChangesAsync();
        }

        public async ValueTask HandleAsync(ExcluirContribuinteCommand excluirContribuinteCommand)
        {
            await _contribuinteRepository.ExcluirAsync(excluirContribuinteCommand.Id);
            await _contribuinteRepository.SaveChangesAsync();
        }

        public async ValueTask<IReadOnlyList<Contribuinte>> CalcularImpostoRenda(CalcularImpostoRendaCommand command)
        {
            var contribuintes = await _contribuinteRepository.Todos().ToListAsync();

            foreach (var contrib in contribuintes)
                contrib.ImpostoRenda = CalculadoraImpostoRenda.Calcular(command.SalarioMinimo, contrib);

            return contribuintes;
        }
    }
}
