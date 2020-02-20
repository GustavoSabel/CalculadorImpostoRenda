using CalculadorImpostoRenda.Dominio.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadorImpostoRenda.Dominio.Repository
{
    public interface IContribuinteRepository : IContribuinteRepositoryRead
    {
        Task Excluir(int id);
        void InserirOuAtualizar(Contribuinte entidade);
        Task SaveChangesAsync();
    }
}