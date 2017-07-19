<Query Kind="Program" />

// http://www.dofactory.com/net/observer-design-pattern

void Main()
{
	// Configure Observer pattern
	Subject s = new Subject();

	s.Attach(new Observer(s, "X"));
	s.Attach(new Observer(s, "Y"));
	s.Attach(new Observer(s, "Z"));

	// Change subject and notify observers
	s.SubjectState = "ABC";
	s.Notify();

	
}

// Define other methods and classes here
/// <summary>
/// The 'Subject' abstract class
/// </summary>
public class Subject
{
	private List<IObserver> _observers = new List<IObserver>();
	
	public string SubjectState { get; set; }

	public void Attach(IObserver observer)
	{
		_observers.Add(observer);
	}

	public void Detach(IObserver observer)
	{
		_observers.Remove(observer);
	}

	public void Notify()
	{
		foreach (IObserver o in _observers)
		{
			o.Update();
		}
	}
}



/// <summary>
/// The 'Observer' abstract class
/// </summary>
public interface IObserver
{
	void Update();
}

/// <summary>
/// The 'ConcreteObserver' class
/// </summary>
class Observer : IObserver
{
	private string _name;
	private string _observerState;
	private Subject _subject;

	// Constructor
	public Observer(Subject subject, string name)
	{
		this._subject = subject;
		this._name = name;
	}

	public void Update()
	{
		_observerState = _subject.SubjectState;
		Console.WriteLine("Observer {0}'s new state is {1}",
		  _name, _observerState);
	}

	  // Gets or sets subject
    public Subject Subject
	{
		get { return _subject; }
		set { _subject = value; }
	}
}
