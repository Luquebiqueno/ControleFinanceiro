using ControleFinanceiro.Domain.Entities;
using Generics.Infra.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Repository.Maps
{
    public class UsuarioMap : EntityBaseMap<Usuario, int>
    {
        protected override void ConfigurarMapeamento(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.Id).HasColumnName("UsuarioId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasColumnName("Nome").HasColumnType("varchar").HasMaxLength(128).IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.Telefone).HasColumnName("Telefone").HasColumnType("bigint");
            builder.Property(x => x.Login).HasColumnName("Login").HasColumnType("varchar").HasMaxLength(128).IsUnicode().IsRequired();
            builder.Property(x => x.Senha).HasColumnName("Senha").HasColumnType("varchar").HasMaxLength(400).IsUnicode().IsRequired();
            builder.Property(x => x.DataCadastro).HasColumnName("DataCadastro").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAlteracao).HasColumnName("DataAlteracao").HasColumnType("datetime");
            builder.Property(x => x.UsuarioAlteracao).HasColumnName("UsuarioAlteracao").HasColumnType("int");

            builder.Ignore(x => x.UsuarioCadastro);
            builder.Ignore(x => x.Ativo);
        }
    }
}
