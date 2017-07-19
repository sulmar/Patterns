<Query Kind="Program" />

void Main()
{

	Invoice invoice = new Invoice
	{
		InvoiceNumber = "FV 1/2016",
		OrderDate = DateTime.Parse("2016-01-04"),
		Customer = new Customer { Name = "Company" }
	};
	
	
	
	Invoice newInvoice = (Invoice) invoice.Clone();
	
	newInvoice.OrderDate = DateTime.Parse("2016-01-04");
	newInvoice.InvoiceNumber = "FV 10/2016";

	invoice.Dump("Original");
	newInvoice.Dump("Copy");



}

// Define other methods and classes here


class Invoice : ICloneable 
{
	public string InvoiceNumber { get; set; }

	public DateTime OrderDate { get; set; }

	public Customer Customer { get; set; }

	public object Clone()
	{
		var newInvoice = (Invoice) this.MemberwiseClone();
		newInvoice.Customer = (Customer) this.Customer.Clone();
		
		return newInvoice;
	}
	
}

class Customer : ICloneable
{
	public string Name { get; set; }

	public object Clone()
	{
		return this.MemberwiseClone();
	}
}
