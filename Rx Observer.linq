<Query Kind="Program">
  <NuGetReference>Stateless</NuGetReference>
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Joins</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.PlatformServices</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
  <Namespace>System.Reactive.Threading.Tasks</Namespace>
</Query>

void Main()
{
	
	var items = GetItems();
	
	IObservable<string> observable = items.ToObservable();
	
	observable.Subscribe(item => Console.WriteLine(item));
	
	
	
}

// Define other methods and classes here



private IEnumerable<string> GetItems()
{	
	yield return "Hello 1";	
	yield return "Hello 2";	
	yield return "Hello 3";		
	yield return "Hello 4";	
	yield return "Hello 5";	
}
