using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Generators.SubGenerators;
internal class VisitationsGenerator
{
    internal static Visitation[] NewVisitations(Patient patient, Doctor doctor)
    {
        Random rnd = new Random();

        int visitationCount = rnd.Next(1, 5);

        var visitations = new Visitation[visitationCount];

        for (int i = 0; i < visitationCount; i++)
        {
            var visitationDate = RandomDayGenerator.NewDay(2024);

            var visitation = new Visitation()
            {
                Date = visitationDate,
                Patient = patient,
                Doctor = doctor
            };

            visitations[i] = visitation;
        }

        return visitations;
    }
}
