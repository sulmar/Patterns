<Query Kind="Program" />

// Wzorzec Visitor umożliwia przejście po złożonym obiekcie i przetworzenie go a przy tym zapewnia odseparowanie przetwarzanego obiektu od logiki

void Main()
{
	var document = new Document();
	document.Attach(new PlainText());
	document.Attach(new BoldText());
	document.Attach(new Hyperlink());
	
	IVisitor visitor = new HtmlVisitor();
	
	document.Accept(visitor);
	
	Console.WriteLine(visitor.Output);

}

// Define other methods and classes here

public interface IVisitor 
{   
	void Visit(PlainText docPart);   
	void Visit(BoldText docPart);   
	void Visit(Hyperlink docPart);

	string Output { get; }
}

public abstract class DocumentPart
{
	public string Text { get; private set; }
	public abstract void Accept(IVisitor visitor);
}

public class PlainText : DocumentPart
{
	public override void Accept(IVisitor visitor)
	{
		visitor.Visit(this);
	}
}
public class BoldText : DocumentPart
{
	public override void Accept(IVisitor visitor)
	{
		visitor.Visit(this);
	}
}
public class Hyperlink : DocumentPart
{
	public string Url { get; private set; }
	public override void Accept(IVisitor visitor)
	{
		visitor.Visit(this);
	}
}
public class Document
{
	private IList<DocumentPart> parts = new List<DocumentPart>();

	public void Attach(DocumentPart part)
	{
		parts.Add(part);
	}

	public void Accept(IVisitor visitor)
	{
		foreach (DocumentPart part in this.parts)
		{
			part.Accept(visitor);
		}
	}
}

public class HtmlVisitor : IVisitor
{
	private string output;
	
	public string Output => output;

	public void Visit(PlainText docPart)
	{
		this.output += docPart.Text;	
	}
	
	public void Visit(BoldText docPart)
	{
	  	this.output += "<b>" + docPart.Text + "</b>";	
	}
	
	public void Visit(Hyperlink docPart)
	{
		this.output += "<a href=\"" + docPart.Url + "\">" + docPart.Text + "</a>";
	}

}