namespace Models
{
    public class StreamProgressInfo
    {
        private StreameableFile file;

        public StreamProgressInfo(StreameableFile file)
        {
            this.file = file;
        }

        public int CalculateCurrentPercent()
        {
            return file.BytesSent * 100 / file.Length;
        }
    }
}
