namespace Animals.Models
{
    public class Animal
    {
        private string name;
        private string favouriteFood;

        public virtual string ExplainSelf()
        {
            return $"I am {name} and my fovourite food is {favouriteFood} MEEOW";
        }
    }
}
