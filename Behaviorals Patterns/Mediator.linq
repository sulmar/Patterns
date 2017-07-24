<Query Kind="Program" />

// Wzorzec Mediator proponuje topologię gwiazdy, w której centrum znajduje się właśnie obiekt Mediator. 
// Posiada on referencje do pozostałych obiektów (Colleague) i zna ich zakres odpowiedzialności. 
// Komunikacja pomiędzy obiektami Colleague wymaga pośrednictwa Mediatora, który potrafi przekazać komunikat do właściwego odbiorcy.

void Main()
{
	ConcreteMediator mediator = new ConcreteMediator();
	
	var col1 = new ConcreteColleague(mediator, "1");
	var col2 = new ConcreteColleague(mediator, "2");
	var col3 = new ConcreteColleague(mediator, "3");
	var col4 = new ConcreteColleague(mediator, "4");

	//dodajemy kolegow
	mediator.AddColleague(col1);
	mediator.AddColleague(col2);

	//col1 powiadamia pozostalych - rozsyla poprzez mediatora
	col1.Send("hello from 1");
}

// Mediator
public interface Mediator
{
	void NotifyAll(string message, IColleague colleague);
}

public interface IColleague
{
	void Send(string message);

	void Receive(string message);

	string Name { get; }
}


public class ConcreteColleague : IColleague
{
	private Mediator mediator;
	private string name;

	public ConcreteColleague(Mediator mediator, string name)	
	{	
		this.mediator = mediator;
		this.name = name;
	}

	public void Receive(string message)
	{
		Console.WriteLine($"[Colleague] '{this.name}' received message: {message}");
	}


	public void Send(string message)
	{
		mediator.NotifyAll(message, this);
	}
	
	public string Name => this.name;
}


public class ConcreteMediator : Mediator
{
	   private IList<IColleague> colleagues;
	   
	   public ConcreteMediator()
	   {
	   		this.colleagues = new List<IColleague>();
	   }

	public void AddColleague(IColleague colleague)
	{
		colleagues.Add(colleague);
	}

	public void NotifyAll(string message, IColleague authorColleague)
	{
		Console.WriteLine($"[Mediator] Message from author '{authorColleague.Name}' : {message}");
		
		foreach (var colleague in colleagues)
		{
			colleague.Receive(message);
		}
	}

}