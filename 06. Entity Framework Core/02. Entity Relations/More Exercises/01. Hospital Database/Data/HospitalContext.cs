using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data;
public class HospitalContext : DbContext
{
    public HospitalContext(DbContextOptions options) : base(options) { }

    public DbSet<Diagnose> Diagnoses { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PatientMedicament> Prescriptions { get; set; }
    public DbSet<Visitation> Visitations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=FootballBetting;User=demo;Password=Demo1234");
            base.OnConfiguring(optionsBuilder);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<PatientMedicament>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.MedicamentId });

            entity.HasOne(e => e.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(e => e.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PatientMedicament_Patients");

            entity.HasOne(e => e.Medicament)
                .WithMany(m => m.Prescriptions)
                .HasForeignKey(e => e.MedicamentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PatientMedicament_Medicaments");
        });
        //
        base.OnModelCreating(modelBuilder);
    }
}
