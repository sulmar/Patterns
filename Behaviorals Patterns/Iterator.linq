<Query Kind="Program" />

void Main()
{
	ConcreteAggregate aggr = new ConcreteAggregate();
	aggr.Add("One");
	aggr.Add("Two");
	aggr.Add("Three");
	aggr.Add("Four");
	aggr.Add("Five");

	IIterator iterator = aggr.CreateIterator();

	string item = (string)iterator.First();
	while (!iterator.IsDone())
	{
		Console.WriteLine(item);
		item = (string)iterator.Next();
	}
}

// Define other methods and classes here
public abstract class AggregateBase
{
	public abstract IIterator CreateIterator();
}


public class ConcreteAggregate : AggregateBase
{
	private ArrayList _items = new ArrayList();

	public override IIterator CreateIterator()
	{
		return new ConcreteIterator(this);
	}

	public object this[int index]
	{
		get { return _items[index]; }
	}

	public int Count
	{
		get { return _items.Count; }
	}

	public void Add(object o)
	{
		_items.Add(o);
	}
}


public interface IIterator
{
	object First();

	object Next();

	object CurrentItem();

	bool IsDone();
}


public class ConcreteIterator : IIterator
{
	private ConcreteAggregate _aggregate;
	int _position;

	public ConcreteIterator(ConcreteAggregate aggregate)
	{
		_aggregate = aggregate;
		_position = 0;
	}

	public object First()
	{
		_position = 0;
		return CurrentItem();
	}

	public object Next()
	{
		_position++;
		return CurrentItem();
	}

	public object CurrentItem()
	{
		if (_position < _aggregate.Count)
			return _aggregate[_position];
		else
			return null;
	}

	public bool IsDone()
	{
		return _position >= _aggregate.Count;
	}
}