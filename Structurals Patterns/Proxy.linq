<Query Kind="Program" />


// Wzorzec Proxy jest strukturalnym wzorcem projektowym
// Jego celem jest utworzenie obiektu zastępującego inny obiekt. 
// Stosowany jest w celu kontrolowanego tworzenia na żądanie kosztownych obiektów oraz kontroli dostępu do nich.

void Main()
{
	Proxy proxy = new Proxy();
	proxy.Request();
}


abstract class Subject
{
	public abstract void Request();
}

class RealSubject : Subject
{
	public override void Request()
	{
		Console.WriteLine("Called RealSubject.Request()");
	}
}

class Proxy : Subject
{
	private RealSubject realSubject;

	public override void Request()
	{
		if (realSubject == null)
		{
			realSubject = new RealSubject();
		}

		realSubject.Request();
	}
}