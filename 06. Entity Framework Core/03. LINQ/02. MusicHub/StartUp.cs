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
            //var output = ExportAlbumsInfo(context, 9);

            // Task 03
            var output = ExportSongsAboveDuration(context, 4);

            Console.WriteLine(output);


        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();
            var AllAlbumsByProducer = context
                .Producers
                .First(p => p.Id == producerId)
                .Albums
                .Select(p => new
                {
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

            var songsAboveDuration = context.Songs
                .AsEnumerable()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new
                {
                    Name = x.Name,
                    WriterName = x.Writer.Name,
                    Proformers = x.SongPerformers.Select(p => new
                    {
                        PerformerFullName = $"{p.Performer.FirstName} {p.Performer.LastName}"
                    })
                        .OrderBy(x => x.PerformerFullName)
                        .ToArray(),
                    AlbumProducer = x.Album.Producer.Name.ToString(),
                    Duration = x.Duration.ToString("c"),
                })
                .OrderBy(x => x.Name).ThenBy(x => x.WriterName);

            var sb = new StringBuilder();
            int songsCounter = 0;

            foreach (var song in songsAboveDuration)
            {
                songsCounter++;
                sb.AppendLine($"-Song #{songsCounter}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.WriterName}");

                foreach (var performer in song.Proformers)
                {
                    sb.AppendLine($"---Performer: {performer.PerformerFullName}");
                }

                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");
            }


            return sb.ToString().TrimEnd();
        }
    }
}
