using P01_HospitalDatabase.Data;
using P01_HospitalDatabase.Generators;

namespace P01_HospitalDatabase;
public class StartUp
{
    static void Main(string[] args)
    {
        using (var dbContext = new HospitalContext())
        {
            DatabaseInitializer.ResetDatabase(dbContext);

            InitialSeed(dbContext);
        }
    }

    public static void InitialSeed(HospitalContext context)
    {
        SeedMedicaments(context);
        Console.WriteLine("Created Medicaments...");
        
        SeedPatientsRecords(context, 200);
        Console.WriteLine("Created Patients Records...");

        SeedPrescriptions(context);
        Console.WriteLine("Created Prescriptions...");
    }

    private static void SeedMedicaments(HospitalContext context)
    {
        DatabaseInitializer.SeedMedicaments(context);
    }

    public static void SeedPatientsRecords(HospitalContext context, int count)
    {
        for (int i = 0; i < count; i++)
        {
            context.Patients.Add(PatientRecordGenerator.NewRecord(context));
        }

        context.SaveChanges();
    }

    public static void SeedPrescriptions(HospitalContext context)
    {
        DatabaseInitializer.SeedPrescriptions(context);
    }
}

