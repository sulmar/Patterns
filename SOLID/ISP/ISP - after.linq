<Query Kind="Program" />

void Main()
{
	ICashWithdrawMachine machine = new MyCashMachine();

	machine.Withdraw(100);
}

// Define other methods and classes here

public interface ICashDepositMachine
{
	void Deposit(decimal amount);
}

public interface ICashWithdrawMachine
{
	void Withdraw(decimal amount);
}

public interface IRecharger
{
	void Recharge(decimal amoount);
}

public class MyCashMachine : ICashWithdrawMachine, ICashDepositMachine
{
	private decimal saldo;

	public void Deposit(decimal amount)
	{
		saldo = saldo - amount;
	}

	public void Withdraw(decimal amount)
	{
		saldo = saldo + amount;
	}
}