<Query Kind="Program" />



// Wzorzec projektowy Most (ang. bridge) jest wzorcem strukturalnym.

// Pozwala na modyfikowanie implementacji w czasie działania programu. 
// Interfejs zostaje całkowicie odizolowany od swojej implementacji.
// Dzięki temu zyskujemy możliwość oddzielnego modyfikowania abstrakcji oraz oddzielnej modyfikacji implementacji. 

// Przydatny może być w sytuacji, gdy graficzny interfejs użytkownika (GUI) musi wyglądać inaczej 
// w zależności od posiadanego systemu operacyjnego. 

// Zmiany w kodzie mają charakter dynamiczny (wszystkie modyfikacje dokonywane są w trakcie działania programu). 
// Dodatkowo wzorzec ten może służyć do odseparowania klienta od implementacji określonego interfejsu.

// Elementy:
// Abstraction - definiuje interfejs abstracji oraz posiada referencję do implementacji 
// RefinedAbstraction - rozszerza interfejs zdefiniowany przez abstrakcję
// Implementator - definiuje interfejs implementatora. Abstrakcja operuje na tym interfejsie.
// ConcreteImplementator - implementuje interfejs Implementator i definiuje konkretną implementację.

void Main()
{
	Abstraction ab = new RefinedAbstraction();

	// Ustawienie implementacji
	ab.Implementor = new ConcreteImplementorA();
	ab.Operation();

	// Zmiana implementacji i wywołanie metody
	ab.Implementor = new ConcreteImplementorB();
	ab.Operation();

}


// Abstraction
class Abstraction
{
	protected Implementor implementor;

	// Property
	public Implementor Implementor
	{
		set { implementor = value; }
	}

	public virtual void Operation()
	{
		implementor.Operation();
	}
}

// Implementor
abstract class Implementor
{
	public abstract void Operation();
}
// RefinedAbstraction
class RefinedAbstraction : Abstraction
{
	public override void Operation()
	{
		implementor.Operation();
	}
}


class ConcreteImplementorA : Implementor
{
	public override void Operation()
	{
		Console.WriteLine("ConcreteImplementorA Operation");
	}
}


class ConcreteImplementorB : Implementor
{
	public override void Operation()
	{
		Console.WriteLine("ConcreteImplementorB Operation");
	}
}
