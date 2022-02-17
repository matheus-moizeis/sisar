#region Namespaces

using Microsoft.EntityFrameworkCore;
using Sisar.Domain.Entities;
using Sisar.Infra.Context;
using Sisar.Infra.Interfaces;

#endregion

namespace Sisar.Infra.Repositories
{
    public class EmitenteRepository : BaseRepository<Emitente>, IEmitenteRepository
    {
        #region Propriedade

        private readonly SisarContext _context;

        #endregion

        #region Construtor

        public EmitenteRepository(SisarContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos

        public async Task<List<Emitente>> ListarAtivos()
        {
            var emitentesAtivos = await _context.Emitentes
                                                .Where(x => x.Ativo == true)
                                                .AsNoTracking()
                                                .ToListAsync();
            return emitentesAtivos;
        }

        #endregion
    }
}
