namespace FoodShortage.Models.Interfaces
{
    public interface IBuyer : INameable
    {
        public int Food { get; }
        void BuyFood();
    }
}
