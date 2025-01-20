namespace P01_HospitalDatabase.Generators.SubGenerators;
internal class SpecialtyGenerator
{
    private static Random rnd = new Random();

    private static string[] Specialties =
        {
            "Neurosurgery",
            "Thoracic surgery",
            "Cardiology",
            "Oral and maxillofacial surgery",
            "Orthopedic Surgery",
            "Gastroenterology",
            "Urology",
            "ENT",
        };

    internal static string NewSpecialty()
    {
        string specialty = Specialties[rnd.Next(Specialties.Length)];
        return specialty;
    }
}
