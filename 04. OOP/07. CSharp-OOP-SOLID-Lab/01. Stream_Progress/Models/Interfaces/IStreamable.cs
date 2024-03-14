namespace P01.Stream_Progress.Models.Interfaces
{
    public interface IStreamable
    {
        public int Length { get; }
        public int BytesSent { get; }
    }
}
