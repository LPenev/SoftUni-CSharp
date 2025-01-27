namespace MusicHub
{
    using System;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            // Task 02
            var output = ExportAlbumsInfo(context, 9);
            Console.WriteLine(output);


        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();
            var AllAlbumsByProducer = context
                .Producers
                .First(p => p.Id == producerId)
                .Albums
                .Select(p => new {
                    AlbumName = p.Name,
                    AlbumReleaseDate = p.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = p.Producer.Name,
                    Songs = p.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price.ToString("f2"),
                        Writer = s.Writer.Name
                    }).OrderByDescending(x => x.SongName)
                    .ThenBy(x => x.Writer),
                    AlbumPrice = p.Price
                })
                .OrderByDescending(p => p.AlbumPrice)
                .ToArray();


            foreach (var album in AllAlbumsByProducer)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.AlbumReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");

                if (album.Songs.Any())
                {
                    sb.AppendLine($"-Songs:");
                    int songsCounter = 0;
                    foreach (var song in album.Songs)
                    {
                        songsCounter++;
                        sb.AppendLine($"---#{songsCounter}");
                        sb.AppendLine($"---SongName: {song.SongName}");
                        sb.AppendLine($"---Price: {song.Price}");
                        sb.AppendLine($"---Writer: {song.Writer}");
                    }
                    sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
