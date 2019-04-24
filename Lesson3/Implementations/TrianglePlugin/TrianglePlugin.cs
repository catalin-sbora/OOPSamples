using Lesson2.Abstractions;
using Lesson2.Common;

namespace Lesson2.Implementations.TrianglePlugin
{
    
    public class TrianglePlugin: GenericPlugin<Triangle>
    {
        public TrianglePlugin():base("Triangle")
        {

        }
    }
}
