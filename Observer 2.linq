<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here

public interface IObserver<in T>
		where T : EventArgs
{
	void Update(Object sender, T e);
}

public interface ISubject<out T>
		where T : EventArgs
{
	void Attach(IObserver<T> observer);
	void Detach(IObserver<T> observer);
}

public class EmailChangedEventArgs : EventArgs
{
	public string Email { get; set; }
}

public class Person : ISubject<EmailChangedEventArgs>
{
	private string _email;
	public event EventHandler<EmailChangedEventArgs> EmailChanged;

	public string FirstName { get; set; }
	public string LastName { get; set; }

	public string Email
	{
		get { return _email; }
		set
		{
			_email = value;
			OnEmailChanged(value);
		}
	}

	private void OnEmailChanged(string value)
	{
		if (EmailChanged != null)
		{
			EmailChanged(this, new EmailChangedEventArgs() { Email = value });
		}
	}

	public void Attach(IObserver<EmailChangedEventArgs> observer)
	{
		EmailChanged += observer.Update;
	}

	public void Detach(IObserver<EmailChangedEventArgs> observer)
	{
		EmailChanged -= observer.Update;
	}

}