<Query Kind="Program" />

void Main()
{
		
	
}

// Define other methods and classes here
abstract class Product { }
class ProductA : Product { }
class ProductB : Product { }


abstract class Factory
{
	public abstract Product Create();
}

class ConcreteFactoryA : Factory
{
	public override Product Create()
	{
		return new ProductA();
	}
}
class ConcreteFactoryB : Factory
{
	public override Product Create()
	{
		return new ProductB();
	}
}