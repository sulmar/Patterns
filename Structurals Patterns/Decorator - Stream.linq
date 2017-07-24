<Query Kind="Program">
  <Namespace>System.IO.Compression</Namespace>
</Query>

void Main()
{
	
	var filename = @"C:\Users\marci\Downloads\test.txt";
	
	var content = "Hello world!";
	
	// compress
	var stream = new GZipStream(new FileStream(filename, FileMode.Create), CompressionMode.Compress);
		
	byte[] bytes = System.Text.Encoding.ASCII.GetBytes(content);
		
	stream.Write(bytes, 0, bytes.Length);
	
	stream.Close();

	// decompress

	var stream2 = new GZipStream(new FileStream(filename, FileMode.Open), CompressionMode.Decompress);

	byte[] bytes2 = new byte[100];

	stream2.Read(bytes2, 0, bytes.Length);

    var content =  System.Text.Encoding.ASCII.GetString(bytes2);

	content.Dump();

}

