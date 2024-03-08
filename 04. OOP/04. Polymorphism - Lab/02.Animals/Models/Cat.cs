using System.Xml.Linq;

namespace Animals.Models
{
    public class Cat : Animal
    {
        private string name;
        private string favouriteFood;

        public Cat(string name, string favouriteFood)
        {
            this.name = name;
            this.favouriteFood = favouriteFood;
        }

        public override string ExplainSelf()
        {
            return $"I am {name} and my fovourite food is {favouriteFood} MEEOW";
        }
    }
}
