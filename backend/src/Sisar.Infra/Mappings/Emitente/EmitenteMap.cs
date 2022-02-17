#region Namespaces

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sisar.Domain.Entities;

#endregion

namespace Sisar.Infra.Mappings
{
    public class EmitenteMap : IEntityTypeConfiguration<Emitente>
    {
        public void Configure(EntityTypeBuilder<Emitente> builder)
        {
            builder.ToTable("Emitente");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .UseIdentityColumn()
                   .HasColumnType("BIGINT");

            builder.Property(x => x.RazaoSocial)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("RazaoSocial")
                   .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.NomeFantasia)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("NomeFantasia")
                   .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Cnpj)
                   .IsRequired()
                   .HasMaxLength(25)
                   .HasColumnName("Cnpj")
                   .HasColumnType("VARCHAR(25)");

            builder.Property(x => x.DtCriacao)
                    .HasColumnName("DtCriacao")
                    .HasColumnType("smalldatetime");

            builder.Property(x => x.DtEdicao)
                    .HasColumnName("DtEdicao")
                    .HasColumnType("smalldatetime");

            builder.Property(x => x.Ativo)
                   .IsRequired()
                   .HasColumnName("ativo")
                   .HasColumnType("BIT");
        }
    }
}
