<Query Kind="Program" />

void Main()
{
	IWashMachine washmachine = new WashMachine(
		new EngineController(), 
		new HeaterController(), 
		new PumpController());

	washmachine.Start();
	
	
	
	washmachine.Stop();
}

// Define other methods and classes here

// Facade



interface IWashMachine
{	
	void Start();
	
	void Stop();
	
}


public interface IWashStrategy
{
	void Wash();
}

public class QuickWashStrategy : IWashStrategy
{
	public void Wash()
	{
	
	}
	
}

public interface IEngineController
{
	bool Running { get; }
	void Start();
	void Stop();

}

public interface IHeaterController
{
	int Temperature { get; }
	void On();
	void Off();

}

public interface IPumpController
{
	void Start();
	void Stop();
}


public class HeaterController : IHeaterController
{
	public int Temperature { get; private set; }

	public void On()
	{
		Console.WriteLine("Heater on");
	}

	public void Off()
	{
		Console.WriteLine("Heater off");
	}

}


public class PumpController : IPumpController
{
	public void Start()
	{
		Console.WriteLine("Pump started");
	}

	public void Stop()
	{
		Console.WriteLine("Pump stopped");
	}

}


public class EngineController : IEngineController
{
	public bool Running { get; private set; }

	public void Start()
	{
		Running = true;
		Console.WriteLine("Engine started");
	}

	public void Stop()
	{
		Running = false;
		Console.WriteLine("Engine stopped");
	}
}

class WashMachine : IWashMachine
{
	private readonly IEngineController _engineController;
	private readonly IHeaterController _heaterController;
	private readonly IPumpController _pumpController;

	public WashMachine(
		IEngineController engineController, 
		IHeaterController heaterController,
		IPumpController pumpController)
	{
		_engineController = engineController;
		_heaterController = heaterController;
		_pumpController = pumpController;
	}

	public void Start()
	{
		_pumpController.Start();
		_engineController.Start();
		_heaterController.On();
		_pumpController.Stop();
		
	}

	public void Stop()
	{
		_engineController.Stop();
		_heaterController.Off();
		_pumpController.Stop();
	}

}