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
    public DbSet<Doctor> Doctors { get; set; }

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
        modelBuilder.Entity<Diagnose>( d =>
        {
            d.HasKey( d => d.DiagnoseId);

            d.Property(d => d.Name)
                .HasMaxLength(50);

            d.Property(d => d.Comments)
                .HasMaxLength(250);

            d.HasOne( d => d.Patient)
                .WithMany(d => d.Diagnoses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Diagnose_Patients");
        });

        modelBuilder.Entity<Doctor>(d =>
        {
            d.HasKey( d => d.DoctorId);
            d.Property( d => d.Name)
                .HasMaxLength(100)
                .IsRequired();

            d.Property(d => d.Specialty)
                .HasMaxLength(100)
                .IsRequired();
        });

        modelBuilder.Entity<Medicament>(m =>
        {
            m.HasKey(m => m.MedicamentId);
            m.Property(m => m.Name)
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Patient>(p =>
        {
            p.HasKey(p => p.PatientId);

            p.Property(p => p.FirstName)
                .HasMaxLength(50);

            p.Property(p => p.LastName)
                .HasMaxLength(50);

            p.Property(p => p.Address)
                .HasMaxLength (250);

            p.Property (p => p.Email)
                .HasMaxLength(80)
                .IsUnicode(false);
        });
        
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

        modelBuilder.Entity<Visitation>(v => 
        {
            v.HasKey(v => v.VisitationId);

            v.Property(v => v.Date)
                .IsRequired();

            v.Property(v => v.Comments)
                .HasMaxLength(250);

            v.HasOne(v => v.Doctor)
                .WithMany( d => d.Visitations)
                .HasForeignKey(v => v.DoctorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Visitations_Doctors");

            v.HasOne(v => v.Patient)
                .WithMany(v => v.Visitations)
                .HasForeignKey(v => v.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Visitations_Patients");
         });
        //
        base.OnModelCreating(modelBuilder);
    }
}
