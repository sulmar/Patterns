<Query Kind="Program" />

void Main()
{
	var textfield = new TextFieldBuilder()
		.Required()
		.MaxLength(100)
		.DefaultValue("aaa")
		.Build();
		
		textfield.Dump();

}


// Define other methods and classes here

public interface FormFieldBuilder
{
	FormFieldBuilder Required();
	FormFieldBuilder MaxLength(int length);
	FormFieldBuilder DefaultValue(string value);
	
	FormField Build();

}



public class FormField
{
	public int MaxSize { get; set; }

	public string Value { get; set; }
	
	public bool IsRequired { get; set; }
}

public class TextFieldBuilder : FormFieldBuilder
{
	private bool isRequired;
	private int length;
	private string defaultValue;

	public FormFieldBuilder Required()
	{				
		// field is set required
		this.isRequired = true;
		
		return this;
	}
	
	public FormFieldBuilder MaxLength(int length)
	{
		// max length is set
		
		this.length = length;
		
		return this;
	}

	public FormFieldBuilder DefaultValue(string value)
	{
		// add default value
		
		this.defaultValue = value;
		
		return this;
	}

	public FormField Build()
	{
		// build field finally

		return new FormField { IsRequired = isRequired, MaxSize = length, Value = defaultValue };
	}


}