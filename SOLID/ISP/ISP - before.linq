<Query Kind="Program" />

void Main()
{
	ICashMachine machine = new CashDepositMachine();

	machine.Deposit(200);

	machine.Withdraw(100);
}

// Define other methods and classes here

public interface ICashMachine
{
	void Withdraw(decimal amount);

	void Deposit(decimal amount);
}

public class CashDepositMachine : ICashMachine
{
	private decimal saldo;

	public void Deposit(decimal amount)
	{
		saldo = saldo + amount;
	}

	public void Withdraw(decimal amount)
	{
		throw new NotSupportedException();
	}
}

public class MyCashMachine : ICashMachine
{
	private decimal saldo;

	public void Deposit(decimal amount)
	{
		saldo = saldo + amount;
	}

	public decimal GetSaldo()
	{
		return saldo;
	}

	public void Withdraw(decimal amount)
	{
		saldo = saldo - amount;
	}
}