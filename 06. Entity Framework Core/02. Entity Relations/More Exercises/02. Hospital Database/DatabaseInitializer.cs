using P01_HospitalDatabase.Data;
using P01_HospitalDatabase.Generators;

namespace P01_HospitalDatabase;
public class DatabaseInitializer
{
    internal static void ResetDatabase(HospitalContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }

    internal static void SeedMedicaments(HospitalContext context)
    {
        MedicamentGenerator.InitialMedicamentSeed(context);
    }

    internal static void SeedPatientsRecords(HospitalContext context, int count)
    {
        for (int i = 0; i < count; i++)
        {
            context.Patients.Add(PatientRecordGenerator.NewRecord(context));
        }

        context.SaveChanges();
    }

    internal static void SeedPrescriptions(HospitalContext context)
    {
        PrescriptionGenerator.InitialPrescriptionSeed(context);
    }
}
