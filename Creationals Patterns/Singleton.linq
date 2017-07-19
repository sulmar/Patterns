<Query Kind="Program" />

void Main()
{
	Singleton singleton1 = Singleton.Instance; 
	Singleton singleton2 = Singleton.Instance;

	if (singleton1 == singleton2)
	{
		Console.WriteLine("Identyczne");
	}
	else
	{
		Console.WriteLine("Różne");
	}	
}



public class Singleton
{
	private static Singleton instance;

	//kontruktor musi byc prywatny lub protected
	//aby uniemożliwić utworzenie obiektu
	//za pomocą operatora new
	protected Singleton()
	{
		"Created".Dump();
	}

	public static Singleton Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new Singleton();
			}		
			
			return instance;			
		}
	}

}