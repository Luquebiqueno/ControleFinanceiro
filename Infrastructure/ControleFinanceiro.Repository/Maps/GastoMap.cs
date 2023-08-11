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
    public class GastoMap : EntityBaseMap<Gasto, int>
    {
        protected override void ConfigurarMapeamento(EntityTypeBuilder<Gasto> builder)
        {
            builder.ToTable("Gasto", "dbo");
            builder.Property(x => x.Id).HasColumnName("GastoId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Item).HasColumnName("Item").HasColumnType("varchar").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Valor).HasColumnName("Valor").HasColumnType("decimal").IsRequired();
            builder.Property(x => x.DataCompra).HasColumnName("DataCompra").HasColumnType("date").IsRequired();
            builder.Property(x => x.GastoTipoId).HasColumnName("GastoTipoId").HasColumnType("int").IsRequired();
            builder.Property(x => x.DataCadastro).HasColumnName("DataCadastro").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.UsuarioCadastro).HasColumnName("UsuarioCadastro").HasColumnType("int").IsRequired();
            builder.Property(x => x.DataAlteracao).HasColumnName("DataAlteracao").HasColumnType("datetime");
            builder.Property(x => x.UsuarioAlteracao).HasColumnName("UsuarioAlteracao").HasColumnType("int");
            builder.Property(x => x.Ativo).HasColumnName("Ativo").HasColumnType("bit").IsRequired();
        }
    }
}
