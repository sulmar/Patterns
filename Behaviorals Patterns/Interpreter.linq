<Query Kind="Program" />

// Wzorzec projektowy Interpreter jest wzorcem czynnościowym.


// Jego zadaniem jest interpretacja poleceń innego języka.
// Dany język rokładany jest na części gramatyczne i potem na zorientowaną obiektowo hierarchię.

// Interpreter składa się z następujących elementów:
// - Context: przetrzymuje dane, które powinny poddać się interpretacji
// - Abstract Expression: klasa abstrakcyjna która interpretuje polecenia, 
// - Expression – konkretne klasy, które interpretują treść Contextu dla poszczególnych przypadków.


// na przykładzie odwrotnej notacji polskiej
// https://pl.wikipedia.org/wiki/Odwrotna_notacja_polska
void Main()
{
	string expression = "2 3 + 5 *";
	
	var parser = new Parser();
	
	var result = parser.Evaluate(expression);
	
	Console.WriteLine(result);
	
}

// Define other methods and classes here

public interface IExpression
{
	 void Interpret(Stack<int> s);
}

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

class ExpressionFactory
{
	static public IExpression Create(string token)
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

			var expression = ExpressionFactory.Create(token);
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