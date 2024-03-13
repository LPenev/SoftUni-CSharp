namespace Models
{
    public class Music : StreameableFile
    {
        private string artist;
        private string album;

        public Music(string artist, string album, int length, int bytesSent) : base(length, bytesSent)
        {
            this.artist = artist;
            this.album = album;
        }
    }
}
