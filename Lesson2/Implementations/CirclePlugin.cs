using Lesson2.Abstractions;

namespace Lesson2.Implementations
{
    public class CirclePlugin : IShapePlugin
    {
        public string GetName()
        {
            return "Circle";
        }

        public IDrawableShape ReadShape()
        {
            var newCircle = new Circle();
            newCircle.Read();
            return newCircle;
        }
    }
}