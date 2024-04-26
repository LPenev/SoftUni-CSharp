using System;

namespace ClothesMagazine
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Initialize the repository (Magazine)
            Magazine magazine = new Magazine("Zara", 20);
            //Initialize entity (Cloth)
            Cloth cloth1 = new Cloth("red", 36, "dress");
            //Print Cloth
            Console.WriteLine(cloth1);
            //Add Cloth
            magazine.AddCloth(cloth1);
            //Remove Cloth
            Console.WriteLine(magazine.RemoveCloth("black"));
            Cloth cloth2 = new Cloth("brown", 34, "t-shirt");
            Cloth cloth3 = new Cloth("blue", 32, "jeans");
            //Add Cloth
            magazine.AddCloth(cloth2);
            magazine.AddCloth(cloth3);
            //Get smallest cloth
            Cloth smallestCloth = magazine.GetSmallestCloth();
            Console.WriteLine(smallestCloth); 
            
            Cloth getCloth = magazine.GetCloth("brown");
            Console.WriteLine(getCloth);
            Console.WriteLine(magazine.Report());

        }
    }
}
