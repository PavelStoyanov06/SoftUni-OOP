using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        private List<IShape> shapes = new List<IShape>();

        public GraphicEditor()
        {
            this.shapes = new List<IShape>()
            {
                new Circle(),
                new Rectangle(),
                new Square()
            };
        }

        public void DrawShape(IShape shape)
        {
            IShape child = shapes.FirstOrDefault(s => s.GetType().Name == shape.GetType().Name);
            if(child is not null)
            {
                Console.WriteLine($"I'm {child.GetType().Name}!");
            }
        }
    }
}
