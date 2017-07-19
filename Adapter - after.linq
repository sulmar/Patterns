<Query Kind="Program" />

void Main()
{
	IShape[] shapes =
		{
			new Line(), new Rectangle()
		};
	// A begin and end point from a graphical editor
	int x1 = 10, y1 = 20;
	int x2 = 30, y2 = 60;
	for (int i = 0; i < shapes.Length; ++i)
		shapes[i].Draw(x1, y1, x2, y2);

}

// Define other methods and classes here

class LegacyLine
{
	public void draw(int x1, int y1, int x2, int y2)
	{
		System.Console.WriteLine($"line from ({x1},{y1}) to ({x2},{y2})");
	}
}

class LegacyRectangle
{
	public void draw(int x, int y, int w, int h)
	{
		System.Console.WriteLine($"rectangle at ({x},{y}) with width {w} and height {h}");
	}
}

interface IShape
{
	void Draw(int x1, int y1, int x2, int y2);
}

class Line : IShape
{
	private LegacyLine adaptee = new LegacyLine();
	
	public void Draw(int x1, int y1, int x2, int y2)
    {
		adaptee.draw(x1, y1, x2, y2);
	}
}

class Rectangle : IShape
{
	private LegacyRectangle adaptee = new LegacyRectangle();
	public void Draw(int x1, int y1, int x2, int y2)
    {
		adaptee.draw(Math.Min(x1, x2), Math.Min(y1, y2), Math.Abs(x2 - x1),
		  Math.Abs(y2 - y1));
	}
}