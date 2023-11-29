namespace _4._01._Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double Qntyfood = double.Parse(Console.ReadLine());
            double QntyHay = double.Parse(Console.ReadLine());
            double QntyCover = double.Parse(Console.ReadLine());
            double weightPig = double.Parse(Console.ReadLine());

            // Kg to gr
            Qntyfood *= 1000;
            QntyHay *= 1000;
            QntyCover *= 1000;
            weightPig *= 1000;

            int eatDaily = 300; //gr

            int DaysProMonat = 30;
            int coverTag = 1, hayTag = 1;
            for (int i = 0; i < DaysProMonat; i++)
            {
                Qntyfood -= eatDaily;

                if (hayTag == 2)
                {
                    QntyHay -= Qntyfood * 0.05;
                    hayTag = 0;
                }

                if (coverTag == 3)
                {
                    QntyCover -= weightPig / 3;
                    coverTag = 0;
                }

                if (Qntyfood <= 0 || QntyHay <= 0 || QntyCover <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }

                hayTag++;
                coverTag++;
            }

            Qntyfood /= 1000;
            QntyHay /= 1000;
            QntyCover /= 1000;

            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {Qntyfood:f2}, Hay: {QntyHay:f2}, Cover: {QntyCover:f2}.");
        }
    }
}