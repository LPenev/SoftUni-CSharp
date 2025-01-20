using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Generators.SubGenerators;

internal class DiagnoseGenerator
{
    internal static Diagnose[] NewDiagnose(Patient patient)
    {
        var radandom = new Random();

        var diagnoseNames = new string[]
        {
                "Limp Scurvy",
                "Fading Infection",
                "Cow Feet",
                "Incurable Ebola",
                "Snake Blight",
                "Spider Asthma",
                "Sinister Body",
                "Spine Diptheria",
                "Pygmy Decay",
                "King's Arthritis",
                "Desert Rash",
                "Deteriorating Salmonella",
                "Shadow Anthrax",
                "Hiccup Meningitis",
                "Fading Depression",
                "Lion Infertility",
                "Wolf Delirium",
                "Humming Measles",
                "Incurable Stomach",
                "Grave Heart",
        };
        //var diagnoseNames = File.ReadAllLines("<INSERT DIR HERE>");

        int diagnoseCount = radandom.Next(1, 4);
        var diagnoses = new Diagnose[diagnoseCount];
        for (int i = 0; i < diagnoseCount; i++)
        {
            string diagnoseName = diagnoseNames[radandom.Next(diagnoseNames.Length)];

            var diagnose = new Diagnose()
            {
                Name = diagnoseName,
                Patient = patient
            };

            diagnoses[i] = diagnose;
        }

        return diagnoses;
    }
}
