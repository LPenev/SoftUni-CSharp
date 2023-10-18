namespace _03._Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for(int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split("_");
                
                Song song = new Song();

                song.TypeList = input[0];
                song.Name = input[1];
                song.Time = input[2];

                songs.Add(song);
            }

            string typeList = Console.ReadLine();
            if (typeList == "all")
            {
                Console.WriteLine(string.Join(Environment.NewLine, songs.Select(x => x.Name)));
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine, songs.Where(x => x.TypeList == typeList).Select(x => x.Name)));
            }

        }
    }

    public class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}