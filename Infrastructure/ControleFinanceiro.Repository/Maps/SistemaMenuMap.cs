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
    public class SistemaMenuMap : EntityBaseMap<SistemaMenu, int>
    {
        protected override void ConfigurarMapeamento(EntityTypeBuilder<SistemaMenu> builder)
        {
            builder.ToTable("SistemaMenu", "dbo");
            builder.Property(x => x.Id).HasColumnName("SistemaMenuId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.ParentId).HasColumnName("ParentId").HasColumnType("int");
            builder.Property(x => x.Descricao).HasColumnName("Descricao").HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(x => x.Icone).HasColumnName("Icone").HasColumnType("varchar").HasMaxLength(256);
            builder.Property(x => x.RouterLink).HasColumnName("RouterLink").HasColumnType("varchar").HasMaxLength(512);
            builder.Property(x => x.Ordem).HasColumnName("Ordem").HasColumnType("int").IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("Ativo").HasColumnType("bit").IsRequired();

            builder.HasOne(x => x.SistemaMenu1).WithMany(x => x.Children).HasForeignKey(x => x.ParentId);

            builder.Ignore(x => x.DataCadastro);
            builder.Ignore(x => x.DataAlteracao);
            builder.Ignore(x => x.UsuarioCadastro);
            builder.Ignore(x => x.UsuarioAlteracao);
        }
    }
}
