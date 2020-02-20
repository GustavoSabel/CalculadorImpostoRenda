using CalculadorImpostoRenda.Dominio.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadorImpostoRenda.Dominio.Repository
{
    public interface IContribuinteRepositoryRead
    {
        ValueTask<Contribuinte> Obter(int id);
        IQueryable<Contribuinte> Todos();
    }
}