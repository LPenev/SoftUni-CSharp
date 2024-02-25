using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private const string ArgumentExceptionMessage = " cannot be zero or negative.";
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(Length) + ArgumentExceptionMessage);
                }

                length = value;
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(Width) + ArgumentExceptionMessage);
                }

                width = value;
            }
        }
        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(Height) + ArgumentExceptionMessage);
                }

                height = value;
            }
        }

        public double LateralSurfaceArea() => 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        public double SurfaceArea() => LateralSurfaceArea() + 2 * this.Length * this.Width;
        public double Volume() => this.Length * this.Height * this.Width;

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Surface Area - {this.SurfaceArea():f2}");
            stringBuilder.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}");
            stringBuilder.AppendLine($"Volume - {this.Volume():f2}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
