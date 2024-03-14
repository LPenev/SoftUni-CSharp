using System;

namespace Models
{
    public class File : StreameableFile
    {
        private string name;

        public File(string name, int length, int bytesSent) : base(length, bytesSent)
        {
            this.name = name;
        }
    }
}
