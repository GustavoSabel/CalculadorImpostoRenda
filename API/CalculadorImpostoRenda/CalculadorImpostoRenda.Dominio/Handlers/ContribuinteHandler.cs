using CalculadorImpostoRenda.Dominio.Commands;
using CalculadorImpostoRenda.Dominio.Repository;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async ValueTask Inserir(InserirContribuinteCommand command)
        {
            _contribuinteRepository.InserirOuAtualizar(new Entidades.Contribuinte
            {
                CPF = command.Cpf,
                Nome = command.Nome,
                NumeroDependentes = command.NumeroDependentes,
                RendaMensalBruta = command.RendaMensalBruta
            });
            await _contribuinteRepository.SaveChangesAsync();
        }

        public async ValueTask Atualizar(AtualizarContribuinteCommand command)
        {
            var contribuinte = await _contribuinteRepository.Obter(command.Id);
            if (contribuinte == null)
                throw new Exception($"Contribuinte {command.Id} não encontrado");

            contribuinte.Nome = command.Nome;
            contribuinte.NumeroDependentes = command.NumeroDependentes;
            contribuinte.RendaMensalBruta = command.RendaMensalBruta;

            _contribuinteRepository.InserirOuAtualizar(contribuinte);
            await _contribuinteRepository.SaveChangesAsync();
        }

        public async ValueTask Excluir(ExcluirContribuinteCommand excluirContribuinteCommand)
        {
            await _contribuinteRepository.Excluir(excluirContribuinteCommand.Id);
            await _contribuinteRepository.SaveChangesAsync();
        }

        public async ValueTask CalcularImpostoRenda(InserirContribuinteCommand command)
        {
            var contribuintes = await _contribuinteRepository.Todos().ToListAsync();

            foreach (var contrib in contribuintes)
            {

            }
        }
    }
}
