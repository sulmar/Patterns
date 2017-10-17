<Query Kind="Program" />

void Main()
{
	var document = new Document();
	document.Attach(new PlainText("Hello"));
	document.Attach(new BoldText("World"));
	document.Attach(new Hyperlink("World", "microsoft.com"));
	
	var output = document.ToHTML();
	
	Console.WriteLine(output);
	
}

// Define other methods and classes here

public abstract class DocumentPart 
{   
	public string Text	{ get; protected set; }
	
	public abstract string ToHTML();
	
	
} 


// Przykładowe części dokumentu

public class PlainText : DocumentPart 
{
	public PlainText(string text)
	{
		this.Text = text;
	}


	public override string ToHTML()
	{
		return this.Text;
	}
} 

public class BoldText : DocumentPart
{
	public BoldText(string text)
	{
		this.Text = text;
	}
	
	public override string ToHTML()
	{
		return "<b>" + this.Text + "</b>";
	}
} 

public class Hyperlink : DocumentPart
{   
	public string Url { get; private set; }

	public Hyperlink(string text, string url)
	{
		this.Text = text;
		this.Url = url;
	}

	public override string ToHTML() 
	{     
		return "<a href=\"" + this.Url + "\">" + this.Text + "</a>";   
	}
}

// Dokument 
public class Document
{
	private IList<DocumentPart> parts = new List<UserQuery.DocumentPart>();
	
	public void Attach(DocumentPart part)
	{
		parts.Add(part);
	}

	public string ToHTML()
	{
		string output = "";
		foreach (DocumentPart part in parts)
		{
			output += part.ToHTML();
		}
		return output;
	}
}


