<Query Kind="Program" />

void Main()
{
	IWashMachine washmachine = new WashMachine(
		new EngineController(),
		new HeaterController(), 
		new PumpController());

    washmachine.SetProgram(1);
	
	washmachine.Start();
	
	
	
	//washmachine.Stop();
}

// Define other methods and classes here

// Facade



interface IWashMachine
{	
	void Start();
	
	void Stop();
	
	void SetProgram(int program);
	
}


public interface IWashStrategy
{		
	IEngineController _engineController { get; set; }
	IHeaterController _heaterController { get; set; }
	IPumpController _pumpController { get; set; }

	void Wash();
}

public class QuickWashStrategy : IWashStrategy
{
	public IEngineController _engineController { get; set; }
	public IHeaterController _heaterController { get; set; }
	public IPumpController _pumpController { get; set; }

	
	public void Wash()
	{
		"Quick program starded".Dump();
	
		_pumpController.Start();
		_engineController.Start();
		_heaterController.On();
		_pumpController.Stop();
	}

}

public class SportWashStrategy : IWashStrategy
{
	public IEngineController _engineController { get; set; }
	public IHeaterController _heaterController { get; set; }
	public IPumpController _pumpController { get; set; }	

	public void Wash()
	{
		"Sport program starded".Dump();
		
		_engineController.Start();
		
		_heaterController.On();
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
	
	private IWashStrategy _currentWashStrategy;

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

		if (_currentWashStrategy == null)
		{
			throw new ArgumentNullException("Nie wybrany program");
		}
		
		_currentWashStrategy.Wash();
		
		
		
	}

	public void Stop()
	{
		_engineController.Stop();
		_heaterController.Off();
		_pumpController.Stop();
	}

	public void SetProgram(int program)
	{
	
		this._currentWashStrategy = FabricStrategy.GetStrategy(program);
		
		this._currentWashStrategy._engineController = this._engineController;
		this._currentWashStrategy._heaterController = this._heaterController;
		this._currentWashStrategy._pumpController = this._pumpController;
	}

}


public class FabricStrategy
{

	public static IWashStrategy GetStrategy(int program)
	{
		IWashStrategy _currentWashStrategy;
		
		if (program == 1)
		{
			_currentWashStrategy = new QuickWashStrategy();
		}
		else
		{
			_currentWashStrategy = new SportWashStrategy();
		}
		
		return _currentWashStrategy;
	}

}