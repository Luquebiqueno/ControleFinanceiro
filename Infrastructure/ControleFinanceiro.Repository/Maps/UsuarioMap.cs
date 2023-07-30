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
    public class UsuarioMap : EntityBaseMap<Usuario, int>
    {
        protected override void ConfigurarMapeamento(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario", "dbo");
            builder.Property(x => x.Id).HasColumnName("UsuarioId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasColumnName("Nome").HasColumnType("varchar").HasMaxLength(128).IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Telefone).HasColumnName("Telefone").HasColumnType("varchar").HasMaxLength(20);
            builder.Property(x => x.Senha).HasColumnName("Senha").HasColumnType("varchar").HasMaxLength(400).IsUnicode().IsRequired();
            builder.Property(x => x.DataCadastro).HasColumnName("DataCadastro").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAlteracao).HasColumnName("DataAlteracao").HasColumnType("datetime");
            builder.Property(x => x.RefreshToken).HasColumnName("RefreshToken").HasColumnType("varchar").HasMaxLength(500).IsUnicode();
            builder.Property(x => x.RefreshTokenExpiryTime).HasColumnName("RefreshTokenExpiryTime").HasColumnType("datetime").IsUnicode();
            builder.Property(x => x.Ativo).HasColumnName("Ativo").HasColumnType("bit").IsRequired();

            builder.Ignore(x => x.UsuarioCadastro);
            builder.Ignore(x => x.UsuarioAlteracao);
        }
    }
}
