<Query Kind="Program" />

void Main()
{
	
	Calculator calculator = new Calculator(new NoDiscountStrategy());
	
	var result = calculator.Calculate(100);
	
	result.Dump("NoDiscountStrategy");

	calculator = new Calculator(new PercentageDiscountStrategy(0.2f, 50));

	result = calculator.Calculate(100);

	result.Dump("PercentageDiscountStrategy");

	calculator = new Calculator(new FixAmountDiscountStrategy(90));

	result = calculator.Calculate(30);

	result.Dump("FixAmountDiscountStrategy");
}

public class Calculator
{
	private readonly IStrategy CurrentStrategy;

	public Calculator(IStrategy strategy)
	{
		this.CurrentStrategy = strategy;
	}

	public decimal Calculate(decimal amount)
	{
		if (CurrentStrategy.CanDiscount(amount))
		{
			amount = amount - CurrentStrategy.Discount(amount);
		}
		
		return amount;
	}
	
}

// Define other methods and classes here
public interface IStrategy
{
	bool CanDiscount(decimal amount);
	
	decimal Discount(decimal amount);
}

public class NoDiscountStrategy : IStrategy
{
	public bool CanDiscount(decimal amount)
	{
		return false;		
	}
	
	public decimal Discount(decimal amount)
	{
		return 0;
	}

}

public class PercentageDiscountStrategy : IStrategy
{
	private readonly decimal minimumAmount;
	private readonly float ratio;

	public PercentageDiscountStrategy(float ratio, decimal minimumAmount)
	{
		this.minimumAmount = minimumAmount;
		this.ratio = ratio;
	}
	
	public bool CanDiscount(decimal amount)
	{
		return amount > minimumAmount;
	}
	
	public decimal Discount(decimal amount)
	{
		return amount * (decimal) ratio;
	}
}

public class FixAmountDiscountStrategy : IStrategy
{
	private readonly decimal discountAmount;
	
	public FixAmountDiscountStrategy(decimal discountAmount)
	{
		this.discountAmount = discountAmount;		
	}


	public bool CanDiscount(decimal amount)
	{	
		return amount > discountAmount;
	}
	
	public decimal Discount(decimal amount)
	{
		return discountAmount;
	}
}