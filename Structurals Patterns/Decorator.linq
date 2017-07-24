<Query Kind="Program" />

// Wzorzec projektowy Decorator jest wzorcem strukturalnym.

// Umożliwia dodawanie do klasy nowych funkcjonalności w trakcie działania programu (dynamiczne dziedziczenie).

// Załóżmy, że potrzebujemy tego samego obiektu w różnych wariantach.
// Na przykład przycisk z ramką, przycisk zaokrąglony, przycisk z ramką i zaokrąglony
// Gdybyśmy zastosowali klasyczne dziedziczenie wówczas musimy zaimplementować wszystkie możliwe kombinacje.
// Dodanie nowego typu np. przycisk z cieniem wymaga dodania znów kolejnych klas i dojdzie do eksplozji liczby klas. 

// Dekorator dodaje nową funkcjonalność ale bez naruszania oryginalnego obiektu - tylko go dekoruje, jak firanki okno.


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