<Query Kind="Program" />

void Main()
{
	var singleton1 = Singleton<Application>.Instance; 
	var singleton2 = Singleton<Application>.Instance;

	if (singleton1 == singleton2)
	{
		Console.WriteLine("Identyczne");
	}
	else
	{
		Console.WriteLine("Różne");
	}	
}

public class Application
{
	public string Login { get; set; }
	
}


public class Singleton<T>
	where T : class, new()
{
	private static readonly object syncLock = new object();
	private static T instance;

	//kontruktor musi byc prywatny lub protected
	//aby uniemożliwić utworzenie obiektu
	//za pomocą operatora new
	protected Singleton()
	{
		"Created".Dump();
	}

	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				lock (syncLock)
				{
					instance = new T();
				}
			}		
			
			return instance;			
		}
	}

}