using CalculadorImpostoRenda.Dominio.Entidades;
using CalculadorImpostoRenda.Dominio.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadorImpostoRenda.infra.Repository
{
    public class ContribuinteRepository : IContribuinteRepository
    {
        private readonly Context _context;

        public ContribuinteRepository(Context context)
        {
            _context = context;
        }

        public ValueTask<Contribuinte> ObterAsync(int id)
        {
            return _context.Contribuintes.FindAsync(id);
        }

        public void InserirOuAtualizar(Contribuinte entidade)
        {
            if (entidade.Id == 0)
                _context.Contribuintes.Add(entidade);
            else
                _context.Contribuintes.Update(entidade);
        }

        public async Task ExcluirAsync(int id)
        {
            var contribuinte = await ObterAsync(id);
            _context.Contribuintes.Remove(contribuinte);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IQueryable<Contribuinte> Todos()
        {
            return _context.Contribuintes.AsQueryable();
        }
    }
}
