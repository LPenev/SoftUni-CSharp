using P01.Stream_Progress.Models.Interfaces;

namespace Models
{
    public abstract class StreameableFile : IStreamable
    {
        public StreameableFile(int length, int bytesSent)
        {
            Length = length;
            BytesSent = bytesSent;
        }

        public int Length { get; set; }
        public int BytesSent { get; set; }
    }
}
