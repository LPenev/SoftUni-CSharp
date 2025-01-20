using P01_HospitalDatabase.Data;
using P01_HospitalDatabase.Data.Models;
using P01_HospitalDatabase.Generators.SubGenerators;

namespace P01_HospitalDatabase.Generators;
public class PatientRecordGenerator
{
    
    internal static Patient NewRecord(HospitalContext context)
    {
        var patient = PatientGenetator.NewPatient();
        var doctor = DoctorGenetator.NewDoctor();
        patient.Visitations = VisitationsGenerator.NewVisitations(patient, doctor);
        patient.Diagnoses = DiagnoseGenerator.NewDiagnose(patient);

        return patient;
    }    

}
