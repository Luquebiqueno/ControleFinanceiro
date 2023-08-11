using ControleFinanceiro.Common.Infrastructure.Map;
using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Repository.Maps
{
    public class GastoTipoMap : EntityBaseMap<GastoTipo, int>
    {
        protected override void ConfigurarMapeamento(EntityTypeBuilder<GastoTipo> builder)
        {
            builder.ToTable("GastoTipo", "dbo");
            builder.Property(x => x.Id).HasColumnName("GastoTipoId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Descricao).HasColumnName("Descricao").HasColumnType("varchar").HasMaxLength(30).IsRequired();

            builder.Ignore(x => x.UsuarioCadastro);
            builder.Ignore(x => x.UsuarioAlteracao);
            builder.Ignore(x => x.DataCadastro);
            builder.Ignore(x => x.DataAlteracao);
            builder.Ignore(x => x.Ativo);
        }
    }
}
