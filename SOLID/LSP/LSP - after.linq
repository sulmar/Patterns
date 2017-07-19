<Query Kind="Program" />

void Main()
{
	var vehicles = new List<IWheeledVehicle>
	{
		new Car(),
		new Bike(),
	//	new Boat()
	};
	
	foreach (var vehicle in vehicles)
	{	
		Console.WriteLine(vehicle.GetWheels());
	}
	
	
	
}

public interface IWheeledVehicle
{
	int GetWheels();
}

// Define other methods and classes here
public abstract class Vehicle
{
	
}

public class Car : Vehicle, IWheeledVehicle
{
	public int GetWheels()
	{
		return 4;
	}
}

public class Bike : Vehicle, IWheeledVehicle
{
	public int GetWheels()
	{
		return 2;
	}
}

public class Boat : Vehicle
{
	
}