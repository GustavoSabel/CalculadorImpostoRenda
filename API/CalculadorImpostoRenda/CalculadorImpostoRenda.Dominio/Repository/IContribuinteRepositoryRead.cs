using CalculadorImpostoRenda.Dominio.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadorImpostoRenda.Dominio.Repository
{
    public interface IContribuinteRepositoryRead
    {
        ValueTask<Contribuinte> ObterAsync(int id);
        IQueryable<Contribuinte> Todos();
        Task<Contribuinte> ObterPeloCpfAsync(string cpf);
    }
}