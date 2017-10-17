<Query Kind="Program" />

class Program
{
	static void Main(string[] args)
	{
		Handler h1 = new ConcreteHandler1();
		Handler h2 = new ConcreteHandler2();
		Handler h3 = new ConcreteHandler3();
		h1.SetSuccessor(h2);
		h2.SetSuccessor(h3);

		// Generate and process request
		int[] requests = { 20, 12 };

		foreach (int request in requests)
		{
			h1.HandleRequest(request);
		}
	}



	abstract class Handler
	{
		protected Handler successor;

		public void SetSuccessor(Handler successor)
		{
			this.successor = successor;
		}
		
		public abstract bool CanRequest(int request);

		public void HandleRequest(int request)
		{
			if (CanRequest(request))
			{
				Console.WriteLine($"{this.GetType().Name} handled request {request}");
			}
			else if (successor != null)
			{
				successor.HandleRequest(request);
			}

		}
		
		
	}

	// ConcreteHandler1
	class ConcreteHandler1 : Handler
	{
		public override bool CanRequest(int request)
		{
			return request >= 0 && request < 10;
		}
		
	}

	// ConcreteHandler2
	class ConcreteHandler2 : Handler
	{
		public override bool CanRequest(int request)
		{
			return request >= 10 && request < 20;
		}		
	}

	// ConcreteHandler3
	class ConcreteHandler3 : Handler
	{
		public override bool CanRequest(int request)
		{
			return request >= 20 && request < 30;
		}
		
		
	}
}
