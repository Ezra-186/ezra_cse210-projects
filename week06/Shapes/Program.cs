using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 5f));         
        shapes.Add(new Rectangle("Blue", 4f, 6f)); 
        shapes.Add(new Circle("Green", 3f));    

        foreach (Shape shape in shapes)
        {
            string typeName = shape.GetType().Name;
            string color = shape.GetColor();
            float area = shape.GetArea();

            Console.WriteLine($"{typeName} (Color: {color}) — Area: {area:F2}");
        }
    }
}