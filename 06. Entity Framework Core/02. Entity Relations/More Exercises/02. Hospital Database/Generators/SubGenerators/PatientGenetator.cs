using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Generators.SubGenerators;

internal class PatientGenetator
{
    internal static Patient NewPatient()
    {
        string firstName = NameGenerator.FirstName();
        string lastName = NameGenerator.LastName();

        var patient = new Patient()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = EmailGenerator.NewEmail(firstName + lastName),
            Address = AddressGenerator.NewAddress(),
            HasInsurance = BooleanRandomGenerator.Next(),
        };

        return patient;
    }
}
