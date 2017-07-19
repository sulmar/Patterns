<Query Kind="Program" />

void Main()
{
	var investor1 = new Investor("Sorros");
	var investor2 = new Investor("Berkshire");
	
	// Create IBM stock and attach investors
	Stock stock = new Stock("IBM", 120.00);
	stock.Attach(investor1);
	stock.Attach(investor2);

	// Fluctuating prices will notify investors
	stock.Price = 120.10;
	stock.Price = 121.00;
	stock.Price = 120.50;
	
	stock.Detach(investor1);
	stock.Price = 120.75;
	stock.Price = 120.95;
}

/// <summary>
/// The 'Observer' interface
/// </summary>
public interface IInvestor
{
	void Update(Stock stock);
}

// Define other methods and classes here
/// <summary>
/// The 'Subject' abstract class
/// </summary>
public class Stock
{
	private string _symbol;
	private double _price;
	private IList<IInvestor> _investors = new List<IInvestor>();

	// Constructor
	public Stock(string symbol, double price)
	{
		this._symbol = symbol;
		this._price = price;
	}

	public void Attach(IInvestor investor)
	{
		_investors.Add(investor);
	}

	public void Detach(IInvestor investor)
	{
		_investors.Remove(investor);
	}

	public void Notify()
	{
		foreach (IInvestor investor in _investors)
		{
			investor.Update(this);
		}

		Console.WriteLine("");
	}

	// Gets or sets the price
	public double Price
	{
		get { return _price; }
		set
		{
			if (_price != value)
			{
				_price = value;
				Notify();
			}
		}
	}

	// Gets the symbol
	public string Symbol
	{
		get { return _symbol; }
	}
}


/// <summary>
/// The 'ConcreteObserver' class
/// </summary>
class Investor : IInvestor
{
	private string _name;
	private Stock _stock;

	// Constructor
	public Investor(string name)
	{
		this._name = name;
	}

	public void Update(Stock stock)
	{
		Console.WriteLine("Notified {0} of {1}'s " +
		  "change to {2:C}", _name, stock.Symbol, stock.Price);
	}

	// Gets or sets the stock
	public Stock Stock
	{
		get { return _stock; }
		set { _stock = value; }
	}
}