#region Namespaces

using Microsoft.EntityFrameworkCore;
using Sisar.Domain.Entities;
using Sisar.Infra.Mappings;

#endregion

namespace Sisar.Infra.Context
{
    public class SisarContext : DbContext
    {
        #region Construtores

        public SisarContext()
        { }

        public SisarContext(DbContextOptions<SisarContext> options) : base(options)
        { }

        #endregion

        #region Config. Migrations

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=LOCAL;Initial Catalog=BANCO;User ID=USUARIO;Password=SENHA");
        //}

        #endregion

        #region Tabelas
        public virtual DbSet<Emitente> Emitentes { get; set; }

        #endregion

        #region Config. Tabelas

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmitenteMap());
        }

        #endregion
    }
}
