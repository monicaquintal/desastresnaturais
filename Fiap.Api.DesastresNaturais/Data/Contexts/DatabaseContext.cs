using Fiap.Api.DesastresNaturais.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.DesastresNaturais.Data.Contexts
{
    public class DatabaseContext : DbContext
    {

        public virtual DbSet<UsuarioModel> Usuario { get; set; }
        public virtual DbSet<RegistrarDesastreNaturalModel> DesastreNatural { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UsuarioModel>(entity =>
            {
                // Define o nome da tabela para 'Usuario'
                entity.ToTable("Usuario");
                entity.HasKey(u => u.UsuarioId);
                entity.Property(u => u.Nome).IsRequired();
                entity.Property(u => u.Sobrenome).IsRequired();
                entity.Property(u => u.Email).IsRequired();

                // Especifica o tipo de dado para DataNascimento
                entity.Property(u => u.DataNascimento).HasColumnType("date");

                entity.Property(u => u.EnderecoUsuario);

            });

            // Configuração para RegistrarDesastreNatural
            modelBuilder.Entity<RegistrarDesastreNaturalModel>(entity =>
            {
                entity.ToTable("DesastreNatural");
                entity.HasKey(dn => dn.DesastreNaturalId);
                entity.Property(dn => dn.Data).HasColumnType("DATE").IsRequired();
                entity.Property(dn => dn.EnderecoDesastre).IsRequired();
                entity.Property(dn => dn.TipoDesastre).IsRequired();
                entity.Property(dn => dn.Observacao);

                // Relacionamento com UsuarioModel
                entity.HasOne(u => u.Usuario)
                      .WithMany()
                      .HasForeignKey(u => u.UsuarioId);

            });

        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DatabaseContext()
        {
        }
    }
}