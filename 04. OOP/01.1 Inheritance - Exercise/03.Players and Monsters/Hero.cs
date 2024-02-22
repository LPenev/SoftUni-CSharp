namespace PlayersAndMonsters
{
    public abstract class Hero
    {
        public Hero(string username, int level)
        {
            this.Level = level;
            this.Username = username;
        }

        public string Username { get; set; }
        public int Level { get; set; }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
