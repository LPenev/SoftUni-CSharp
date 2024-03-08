namespace Animals.Models
{
    public class Dog : Animal
    {
        private string name;
        private string favouriteFood;

        public Dog(string name, string favouriteFood)
        {
            this.name = name;
            this.favouriteFood = favouriteFood;
        }

        public override string ExplainSelf()
        {
            return $"I am {name} and my fovourite food is {favouriteFood} DJAAF";
        }
    }
}
