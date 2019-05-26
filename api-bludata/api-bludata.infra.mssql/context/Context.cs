using api_bludata.domain.domain.models;
using Microsoft.EntityFrameworkCore;

namespace api_bludata.infra.mssql.context
{
    public class Context : DbContext
    {
        public DbSet<empresa> Empresa { get; set; }
        public DbSet<estado> Estado { get; set; }
        public DbSet<pessoa_fisica> Pessoa_fisica { get; set; }
        public DbSet<fornecedor> Fornecedor { get; set; }
        public DbSet<telefone> Telefone { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<empresa>(o =>
            {
                o.HasKey(x => x.cnpj);

                o.HasOne(x => x.estado)
                    .WithMany()
                    .HasForeignKey(x => x.estado_id);
            });

            modelBuilder.Entity<estado>(o =>
            {
                o.HasKey(x => x.estado_id);
            });

            modelBuilder.Entity<pessoa_fisica>(o =>
            {
                o.HasKey(x => x.cpf);
            });

            modelBuilder.Entity<fornecedor>(o =>
            {
                o.HasKey(x => x.fornecedor_id);

                o.HasOne(x => x.empresa)
                    .WithMany()
                    .HasForeignKey(x => x.empresa_cnpj);

                o.HasOne(x => x.pessoa_fisica)
                    .WithMany()
                    .HasForeignKey(x => x.cpf);

                o.HasMany(x => x.telefones)
                    .WithOne(x => x.fornecedor)
                    .HasForeignKey(x => x.fornecedor_id);
            });

            modelBuilder.Entity<telefone>(o =>
            {
                o.HasKey(x => x.telefone_id);

                o.HasOne(x => x.fornecedor)
                    .WithMany(x => x.telefones)
                    .HasForeignKey(x => x.fornecedor_id);
            });
        }

    }
}
