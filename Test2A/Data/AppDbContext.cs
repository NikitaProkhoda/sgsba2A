using Microsoft.EntityFrameworkCore;
using Test2A.Models;

namespace Test2A.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<WashingMachine> WashingMachines => Set<WashingMachine>();
    public DbSet<WashingProgram> Programs => Set<WashingProgram>();
    public DbSet<Purchase> Purchases => Set<Purchase>();
    public DbSet<WashingMachineProgram> WashingMachinePrograms => Set<WashingMachineProgram>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WashingMachineProgram>()
            .HasKey(wp => new { wp.WashingMachineId, wp.ProgramId });

        modelBuilder.Entity<WashingMachineProgram>()
            .HasOne(wp => wp.WashingMachine)
            .WithMany(w => w.WashingMachinePrograms)
            .HasForeignKey(wp => wp.WashingMachineId);

        modelBuilder.Entity<WashingMachineProgram>()
            .HasOne(wp => wp.Program)
            .WithMany(p => p.WashingMachinePrograms)
            .HasForeignKey(wp => wp.ProgramId);
    }
}