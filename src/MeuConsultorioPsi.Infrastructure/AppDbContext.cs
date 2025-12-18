using MeuConsultorioPsi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeuConsultorioPsi.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Therapist> Therapists { get; set; }
    public DbSet<Treatment> Treatments { get; set; }
    public DbSet<RecurrenceRule> RecurrenceRules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // mapeamentos e constraints (ex.: índices, tipos, relações)
        base.OnModelCreating(modelBuilder);
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

}
