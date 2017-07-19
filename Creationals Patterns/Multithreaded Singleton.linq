<Query Kind="Program" />

void Main()
{
	Singleton singleton = Singleton.Instance; 
	
	singleton.Dump();
	
	

}

// Define other methods and classes here

public sealed class Singleton
{
	private static volatile Singleton _instance;
	private static object syncRoot = new Object();

	private Singleton()
	{		
	}

	public static Singleton Instance
	{
		get
		{
			lock(syncRoot)
            {
				if (_instance == null)
				{
					_instance = new Singleton();
				}
			}
			
			
			return _instance;			
		}
	}

}