using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Generators.SubGenerators;
internal class DoctorGenetator
{
    internal static Doctor NewDoctor() 
    {
        string firstName = NameGenerator.FirstName();
        string lastName = NameGenerator.LastName();
        
        var doctor = new Doctor()
        {
            Name = firstName + "" + lastName,
            Specialty = SpecialtyGenerator.NewSpecialty(),
        };

        return doctor;
    }
}
