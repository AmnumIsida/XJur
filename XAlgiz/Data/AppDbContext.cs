using Microsoft.EntityFrameworkCore;
using XAlgiz.Models;

namespace XAlgiz.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<NotaFiscal> NotasFiscais { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Definição das chaves primárias
        modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
        modelBuilder.Entity<Servico>().HasKey(s => s.Id);
        modelBuilder.Entity<NotaFiscal>().HasKey(n => n.Id);

        // Definição dos campos obrigatórios
        modelBuilder.Entity<Cliente>()
            .Property(c => c.Nome)
            .IsRequired();

        modelBuilder.Entity<Cliente>()
            .Property(c => c.CpfCnpj)
            .IsRequired();

        modelBuilder.Entity<Cliente>()
            .Property(c => c.Email)
            .IsRequired();

        modelBuilder.Entity<Cliente>()
            .Property(c => c.Telefone)
            .IsRequired();

        modelBuilder.Entity<Servico>()
            .Property(s => s.Descricao)
            .IsRequired();

        modelBuilder.Entity<Servico>()
            .Property(s => s.Valor)
            .IsRequired();
    }
}