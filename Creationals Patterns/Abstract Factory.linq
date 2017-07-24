<Query Kind="Program" />

// Wzorzec projektowy Factory jest wzorcem kreacyjnym.


// Przykład tworzenia wyrażenia za pomocą fabryki

void Main()
{
	string expression = "2 3 + 5 *";
	
	var parser = new Parser(new ExpressionFactory());
	
	var result = parser.Evaluate(expression);
	
	Console.WriteLine(result);
	
}

// Abstract product interface
public interface IExpression
{
	 void Interpret(Stack<int> s);
}

// Concrete product

public class NumberExpression : IExpression
{
	private int number;
	
	public NumberExpression(int number) 
	{ 
		this.number = number; 
	}
	
	public void Interpret(Stack<int> s) 
	{ 
		s.Push(number); 
	}
}

public class PlusExpression : IExpression
{	
	public void Interpret(Stack<int> s) 
	{ 
		s.Push(s.Pop() + s.Pop()); 
	}
}

public class MinusExpression : IExpression
{
	public void Interpret(Stack<int> s)
	{
		s.Push(-s.Pop() + s.Pop()); 
	}
}

public class MultiplyExpression : IExpression
{
	public void Interpret(Stack<int> s)
	{
		s.Push(s.Pop() * s.Pop());
	}
}

// Abstract Factory
interface IExpressionFactory
{
	IExpression Create(string token);	
}

// Concret Factory
class ExpressionFactory : IExpressionFactory
{
	public IExpression Create(string token)
	{
		switch (token)
		{
			case "+": return new PlusExpression(); break;
			case "-": return new MinusExpression(); break;
			case "*": return new MultiplyExpression(); break;

			default: return new NumberExpression(int.Parse(token));

		}
	}
}

class Parser
{
	private IList<IExpression> parseTree = new List<IExpression>();
	private readonly IExpressionFactory factory;
	
	public Parser(IExpressionFactory factory)
	{
		this.factory = factory;		
	}
	
	private void Parse(string s)
	{
		var tokens = s.Split(' ');

		foreach (var token in tokens)
		{
			
//			if (token == "+")
//				parseTree.Add(new PlusExpression());
//			else
//			if (token == "-")
//				parseTree.Add(new MinusExpression());
//			else
//			if (token == "*")
//				parseTree.Add(new MultiplyExpression());
//			// ...
//			else
//				parseTree.Add(new NumberExpression(int.Parse(token)));

			var expression = factory.Create(token);
		 	parseTree.Add(expression);
		}
	}

	

	public int Evaluate(string s)
	{
		Parse(s);

		Stack<int> context = new Stack<int>();

		foreach (var expression in parseTree)
		{
			expression.Interpret(context);
		}

		return context.Pop();
	}
}