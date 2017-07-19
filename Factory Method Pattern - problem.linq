<Query Kind="Program" />


// http://www.c-sharpcorner.com/UploadFile/ankurmalik123/factory-method-pattern/

void Main()
{
	Console.WriteLine("Please choose objects from the below to built:");
	Console.WriteLine("1. Door");
	Console.WriteLine("2. Window");
	int objectType = Convert.ToInt16(Console.ReadLine());
	if (objectType == 1)
	{
		DoorFactory objectDoorFactory = new DoorFactory();
		objectDoorFactory.Print();
	}
	else if (objectType == 2)
	{
		WindowFactory objectWindowFactory = new WindowFactory();
		objectWindowFactory.Print();
	}
}

// Define other methods and classes here
class DoorFactory
{
	public void Print()
	{
		Console.WriteLine("You built a door");
	}
}
class WindowFactory
{
	public void Print()
	{
		Console.WriteLine("You built a window");
	}
}

/*
 Problem:
1. Kod jest rozproszony w kliencie w metodzie Main
2. Kod klienta musi być świadomy wszystkich typów obiektów. 
jeśli klient chce dodać tworzenie nowego typu obiektu np. "Walls", 
to musimy utworzyć obiekt 
*/

/*
Rozwiązanie:

1. Pierwszy problem występuje ze względu na bezpośredni kontakt z klientem z "WindowFactory" i "DoorFactory", 
które są przyczyną wielu nowych słów kluczowych.
Problem ten jest usuwany przez wprowadzenie nowej klasy o nazwie "ObjectFactory", 
która będzie odpowiedzialna za tworzenie obiektów. 
Nie będzie miała ona bezpośredniego kontaktu pomiędzy klientem a klasami "WindowFactory" i "DoorFactory".

2. Drugi problem wynika z tego, że klient musi być świadomy konkretnych klas.
Gdyby dodał nowy typ obiekt obiektu np. Walls wymaga to rekompilacji.
To może być usunięte poprzez wprowadzenie nowego interfejsu o nazwie "IObjectFactory".
*/


