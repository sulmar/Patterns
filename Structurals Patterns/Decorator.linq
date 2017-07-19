<Query Kind="Program" />

void Main()
{
	Widget widget = new BorderDecorator(
					 new BorderDecorator(
					   new ScrollDecorator(
						 new TextField(80, 24))));
	widget.Draw();
}

// Define other methods and classes here

interface Widget
{
	void Draw();
}

class TextField : Widget
{
	private int width;
	private int height;

	public TextField(int w, int h)
	{
		width = w;
		height = h;
	}

	public void Draw()
	{
		System.Console.WriteLine($"TextField: ({width},{height})");
	}		
}

abstract class Decorator : Widget
{
	private Widget widget;

	public Decorator(Widget w)
	{
		this.widget = w;
	}

	public virtual void Draw()
	{
		widget.Draw();
	}
}

class BorderDecorator : Decorator	
{
	public BorderDecorator(Widget w)
		: base(w) {}

	public override void Draw()
	{
		base.Draw();
		
		Console.WriteLine("BorderDecorator");		
	}
}

class ScrollDecorator : Decorator
{
	public ScrollDecorator(Widget w)
		: base(w)
	{ }

	public override void Draw()
	{
		base.Draw();

		Console.WriteLine("ScrollDecorator");
	}
}