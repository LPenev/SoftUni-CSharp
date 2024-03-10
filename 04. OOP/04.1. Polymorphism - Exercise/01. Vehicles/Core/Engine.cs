using Vehicles.Core.Interfaces;
using Vehicles.IO.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer) 
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            
        }
    }
}
