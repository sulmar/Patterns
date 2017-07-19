<Query Kind="Program" />

void Main()
{
	Console.WriteLine("Please choose an Email Account to send an Email:");
	Console.WriteLine("Choose 1 for Google");
	Console.WriteLine("Choose 2 for Yahoo");
	string choice = Console.ReadLine();
	EmailBase email = null;
	
	switch (choice)
	{
		case "1": email = new EmailGoogle(); break;
		case "2": email = new EmailYahoo(); break;
	}
		
	email.SendEmail();
}

// Define other methods and classes here

public abstract class EmailBase
{
	protected abstract bool CheckEmailAddress();
	protected abstract bool ValidateMessage();
	protected abstract bool SendMail();

	public bool SendEmail()
	{
		if (CheckEmailAddress())
		{
			if (ValidateMessage())
			{
				return SendMail();
			}
			else
				return false;
		}
		else
			return false;

	}
}

public class EmailYahoo : EmailBase
{
	protected override bool CheckEmailAddress()
	{
		Console.WriteLine("Checking Email Address : EmailYahoo");
		return true;
	}
	protected override bool ValidateMessage()
	{
		Console.WriteLine("Validating Email Message : EmailYahoo");
		return true;
	}

	protected override bool SendMail()
	{
		Console.WriteLine("Sending Email : EmailYahoo");
		return true;
	}
}

public class EmailGoogle : EmailBase
{
	protected override bool CheckEmailAddress()
	{
		Console.WriteLine("Checking Email Address : GoogleEmail");
		return true;
	}
	protected override bool ValidateMessage()
	{
		Console.WriteLine("Validating Email Message : GoogleEmail");
		return true;
	}

	protected override bool SendMail()
	{
		Console.WriteLine("Sending Email : GoogleEmail");
		return true;
	}
}

