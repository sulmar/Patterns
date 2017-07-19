<Query Kind="Program" />

void Main()
{
	var vehicles = new List<Vehicle>
	{
		new Car(),
		new Bike(),
		new Boat()
	};
	
	foreach (var vehicle in vehicles)
	{
		if (vehicle is Boat)
			break;
			
		Console.WriteLine(vehicle.GetWheels());
	}
	
}

// Define other methods and classes here
public abstract class Vehicle
{
	public abstract int GetWheels();
}

public class Car : Vehicle
{
	public override int GetWheels()
	{
		return 4;
	}
}

public class Bike : Vehicle
{
	public override int GetWheels()
	{
		return 2;
	}
}

public class Boat : Vehicle
{
	public override int GetWheels()
	{
		throw new NotSupportedException();
	}
}