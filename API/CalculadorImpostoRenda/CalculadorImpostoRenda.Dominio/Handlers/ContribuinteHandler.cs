using CalculadorImpostoRenda.Dominio.Commands;
using CalculadorImpostoRenda.Dominio.Entidades;
using CalculadorImpostoRenda.Dominio.Exceptions;
using CalculadorImpostoRenda.Dominio.Helpers;
using CalculadorImpostoRenda.Dominio.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
            await ValidarAsync(command);

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

        private async Task ValidarAsync(InserirContribuinteCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Nome))
                throw new ValidacaoException("Nome é obrigatório");

            if (command.RendaMensalBruta <= 0)
                throw new ValidacaoException("Renda Mensal Bruta é obrigatória");

            if (string.IsNullOrWhiteSpace(command.Cpf))
                throw new ValidacaoException("CPF é obrigatório");

            var cpf = Regex.Replace(command.Cpf, @"[^\d]", "");
            if (cpf.Length != Contribuinte.TamanhoCPF)
                throw new ValidacaoException($"CPF deve ter {Contribuinte.TamanhoCPF} números, mas tem somente {cpf.Length}");

            var contribuinteExistente = await _contribuinteRepository.ObterPeloCpfAsync(command.Cpf);
            if (contribuinteExistente != null)
                throw new ValidacaoException($"Já existe um contribuinte com esse CNPJ");
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

        public async ValueTask<IReadOnlyList<Contribuinte>> HandleAsync(CalcularImpostoRendaCommand command)
        {
            var contribuintes = await _contribuinteRepository.Todos().ToListAsync();

            foreach (var contrib in contribuintes)
                contrib.ImpostoRenda = CalculadoraImpostoRenda.Calcular(command.SalarioMinimo, contrib);

            await _contribuinteRepository.SaveChangesAsync();

            return contribuintes;
        }
    }
}
