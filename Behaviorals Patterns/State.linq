<Query Kind="Program">
  <NuGetReference>Stateless</NuGetReference>
  <Namespace>Stateless</Namespace>
</Query>

// https://blogs.msdn.microsoft.com/nblumhardt/2009/04/16/state-machines-in-domain-models/


void Main()
{
	var device = new Device();
	
	Console.WriteLine(device);

	device.Start();
	device.State.Dump();
	device.Start();
	
	device.State.Dump();
	
	Thread.Sleep(TimeSpan.FromSeconds(20));
	
	device.State.Dump();
	
   // Wizualizacja diagramu: http://www.webgraphviz.com/

}

public class Device
{
	private StateMachine<State, Trigger> machine;
	
	private System.Timers.Timer timer;
	
	private const int timeout = 10; // in seconds			
	
	public Device()
	{
		machine = new StateMachine<State, Trigger>(State.Off);

		machine.Configure(State.Off)
			.Permit(Trigger.Start, State.On)
			.OnExit(() => Console.WriteLine("switch Off"));

		machine.Configure(State.On)
			.Permit(Trigger.Stop, State.Off)
			.Permit(Trigger.Start, State.Blink)			
			.OnEntry(() => Console.WriteLine("switch On"));

		machine.Configure(State.Blink)
			.Permit(Trigger.Start, State.On)
			.Permit(Trigger.Stop, State.On)
			.Permit(Trigger.ElapsedTime, State.On)
			.OnEntry(()=> timer.Start());

		machine.ToDotGraph().Dump();

		timer = new System.Timers.Timer(TimeSpan.FromSeconds(timeout).TotalMilliseconds);
		timer.AutoReset = false;
		timer.Elapsed += (sender, args) => machine.Fire(Trigger.ElapsedTime);


	}

	public void Start()
	{
		machine.Fire(Trigger.Start);			
	}
	
	public void Stop()
	{
		machine.Fire(Trigger.Stop);	
	}
	
	public State State => machine.State;

}

public enum Trigger
{
	Start,

	Stop,
	
	ElapsedTime
}


public enum State
{
	On,

	Off,
	
	Blink

}

