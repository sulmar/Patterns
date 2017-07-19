<Query Kind="Program">
  <NuGetReference>Stateless</NuGetReference>
  <Namespace>Stateless</Namespace>
</Query>

// https://blogs.msdn.microsoft.com/nblumhardt/2009/04/16/state-machines-in-domain-models/

void Main()
{
	string on = "On", off = "Off", blink = "Blink";
	var space = ' ';

	var onOffSwitch = new StateMachine<string, char>(off);

	onOffSwitch.Configure(off).Permit(space, on);
	onOffSwitch.Configure(on).Permit(space, off);
	onOffSwitch.Configure(on).Permit('b', blink);
	onOffSwitch.Configure(blink).Permit(space, on);
	

	onOffSwitch.Fire(' ');	
	onOffSwitch.Fire(' ');	
	onOffSwitch.Fire(' ');	
	onOffSwitch.Fire('b');
	onOffSwitch.Fire(' ');
	onOffSwitch.Fire('b');
	
	
	onOffSwitch.State.Dump("State");
	
	onOffSwitch.ToDotGraph().Dump("Graph");	
}

// Define other methods and classes here