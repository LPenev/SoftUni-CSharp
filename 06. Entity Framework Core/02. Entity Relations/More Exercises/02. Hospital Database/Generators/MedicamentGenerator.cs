using P01_HospitalDatabase.Data;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Generators;
public class MedicamentGenerator
{
    internal static void InitialMedicamentSeed(HospitalContext context)
    {
        var medicamentNames = new String[] {
            "Biseptol",
            "Ciclobenzaprina",
            "Curam",
            "Diclofenaco",
            "Disflatyl",
            "Duvadilan",
            "Efedrin",
            "Flanax",
            "Fluimucil",
            "Navidoxine",
            "Nistatin",
            "Olfen",
            "Pentrexyl",
            "Primolut Nor",
            "Primperan",
            "Propoven",
            "Reglin",
            "Terramicina Oftalmica",
            "Ultran",
            "Viartril-S",
        };

        for (int i = 0; i < medicamentNames.Length; i++)
        {
            context.Medicaments.Add(new Medicament { Name = medicamentNames[i] });
        }

        context.SaveChanges();
    }
}
