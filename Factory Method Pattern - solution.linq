<Query Kind="Program" />

void Main()
{
	Console.WriteLine("Please choose objects from the below to built:");
	Console.WriteLine("1. Door");
	Console.WriteLine("2. Window");
	Console.WriteLine("3. Walls");
	int objectType = Convert.ToInt16(Console.ReadLine());

	IObjectFactory objectFactory = ObjectFactory.GetObject(objectType);

	objectFactory.Print()

}

// Define other methods and classes here
public interface IObjectFactory
{
	void Print();
}

class DoorFactory : IObjectFactory
{
	#region IObjectFactory Members
	public void Print()
	{
		Console.WriteLine("You built a door");
	}
	#endregion
}

class WindowFactory : IObjectFactory
{
	#region IObjectFactory Members
	public void Print()
	{
		Console.WriteLine("You built a window");
	}
	#endregion
}

class WallFactory : IObjectFactory
{
	#region IObjectFactory Members
	public void Print()
	{
		Console.WriteLine("You built walls");
	}
	#endregion
}


class ObjectFactory
{
	static public IObjectFactory GetObject(int objectType)
	{
		if (objectType == 1)
		{ return (new DoorFactory()); }
		else if (objectType == 2)
		{ return (new WindowFactory()); }
		else if (objectType == 3)
		{ return (new WallFactory()); }
		else
			return null;
	}
}