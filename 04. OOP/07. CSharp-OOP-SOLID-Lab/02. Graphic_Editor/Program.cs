using Models;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor graphicEditor = new GraphicEditor();
            Circle circle = new Circle();
            graphicEditor.DrawShape(circle);

            Square square = new Square();
            graphicEditor.DrawShape(square);

            Rectangle rectangle = new Rectangle();
            graphicEditor.DrawShape(rectangle);
        }
    }
}
