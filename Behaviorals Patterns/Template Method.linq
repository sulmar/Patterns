<Query Kind="Program" />


// Wzorzec projektowy Template Method jest wzorcem czynnościowym.

// Definiuje on za pomocą abstrakcji szkielet algorytmu, który jest w pełni realizowany dopiero w klasach potomnych.
// Na początku tworzona jest klasa zawierająca ogólne kroki algorytmu zapisane jako metody abstrakcyjne. 
// Klasy potomne nadpisują te abstrakcyjne metody implementując rzeczywiste akcje.

// Dzięki takiemu podejściu szkielet algorytmu trzymany jest w jednym miejscu, 
// a jego mniejsze kroki mogą być zmieniane w podklasach.

void Main()
{

	Calculator calculator = new NoDiscountCalculator();

	var result = calculator.Calculate(100);

	result.Dump("NoDiscountCalculator");

	calculator = new PercentageDiscountCalculator(0.2f, 50);

	result = calculator.Calculate(100);

	result.Dump("PercentageDiscountCalculator");

	calculator = new FixAmountDiscountCalculator(20);

	result = calculator.Calculate(100);

	result.Dump("FixAmountDiscountCalculator");
}

public abstract class Calculator
{
	public decimal Calculate(decimal amount)
	{		
		if (CanDiscount(amount))
		{
			amount = amount - Discount(amount);
		}
		
		return amount;
		
	}
	
	public abstract bool CanDiscount(decimal amount);
	
	public abstract decimal Discount(decimal amount);
}

public class NoDiscountCalculator : Calculator
{
	public override bool CanDiscount(decimal amount)
	{
		return false;
	}
	
	public override decimal Discount(decimal amount)
	{
		return amount;
	}

}

public class PercentageDiscountCalculator : Calculator
{
	private readonly decimal minimumAmount;
	private readonly float ratio;

	public PercentageDiscountCalculator(float ratio, decimal minimumAmount)
	{
		this.ratio = ratio;
		this.minimumAmount = minimumAmount;
	}

	public override bool CanDiscount(decimal amount)
	{
		return amount > minimumAmount;
	}

	public override decimal Discount(decimal amount)
	{
		return amount * (decimal)ratio;
	}


}

public class FixAmountDiscountCalculator : Calculator
{
	private readonly decimal discountAmount;

	public FixAmountDiscountCalculator(decimal discountAmount)
	{
		this.discountAmount = discountAmount;
	}

	public override bool CanDiscount(decimal amount)
	{
		return amount > discountAmount;
	}

	public override decimal Discount(decimal amount)
	{
		return discountAmount;
	}


}