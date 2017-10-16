<Query Kind="Program" />

void Main()
{
	Director director = new Director();

	Builder builder1 = new ConcreteBuilder1();
	Builder builder2 = new ConcreteBuilder2();

	// Construct two products
	director.Construct(builder1);
	Product product1 = builder1.GetResult();
	product1.Show();

	director.Construct(builder2);
	Product product2 = builder2.GetResult();
	product2.Show();
}

// Define other methods and classes here
// Director
class Director
{
	// Builder uses a complex series of steps
	public void Construct(Builder builder)
	{
		builder.BuildPartA();
		builder.BuildPartB();
	}
}

// Abstract Builder
abstract class Builder
{
	public abstract void BuildPartA();
	public abstract void BuildPartB();
	public abstract Product GetResult();
}

// Concrete Builder
class ConcreteBuilder1 : Builder
{
	private Product _product = new Product();

	public override void BuildPartA()
	{
		_product.Add("PartA");
	}

	public override void BuildPartB()
	{
		_product.Add("PartB");
	}

	public override Product GetResult()
	{
		return _product;
	}
}


class ConcreteBuilder2 : Builder
{
	private Product _product = new Product();

	public override void BuildPartA()
	{
		_product.Add("PartX");
	}

	public override void BuildPartB()
	{
		_product.Add("PartY");
	}

	public override Product GetResult()
	{
		return _product;
	}
}

class Product
{
	private List<string> _parts = new List<string>();

	public void Add(string part)
	{
		_parts.Add(part);
	}

	public void Show()
	{
		Console.WriteLine("\nProduct Parts -------");
		foreach (string part in _parts)
			Console.WriteLine(part);
	}
}