using System.Net.WebSockets;
using System.Text;

class Program
{
	static void Main()
	{
		#region FileStreamWrite
		using (FileStream fs = new FileStream("hn.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
		{
			Console.Write("enter any text : ");
			string? text = Console.ReadLine();

			byte[] buffer = Encoding.Default.GetBytes(text);
			fs.Write(buffer, 0, buffer.Length);
		}
		#endregion FileStreamWrite


		#region FileStreamRead
		using (FileStream FS = new FileStream("hn.txt", FileMode.Open))
		{
			byte[] buffer = new byte[FS.Length];
			FS.Read(buffer, 0, buffer.Length);

			var str = Encoding.Default.GetString(buffer, 0, buffer.Length);
			Console.WriteLine(str);
		}
		#endregion FileStreamRead


		#region Write with StreamWriter(Adapter)
		using FileStream Fs = new FileStream("books.txt", FileMode.OpenOrCreate);
		using StreamWriter sw = new StreamWriter(Fs); // adapter

		//sw.WriteLine("book");

		List<Book> books = new()
		{
			new Book(1, "Rovshen Abdullaoglu", "Bu Sheherde Kimse Yoxdur", "Psixoloji Roman"),
			new Book(2, "Joseph Albahari", "C# in a Nutshell", "Programming"),
			new Book(3, "Robert Kiyosaki", "Rich Dad Poor Dad", "Personal Finance")
		};

		books.ForEach(book => sw.WriteLine(book));
		#endregion Write with StreamWriter(Adapter)


		#region Read with StreamReader(Adapter)
		using FileStream fS = new FileStream("books.txt", FileMode.OpenOrCreate);
		using StreamReader sr = new StreamReader(fS); // adapter

		Console.WriteLine(sr.ReadToEnd());
		#endregion Read with StreamReader(Adapter)

		#region Write(BinaryWriter)
		using FileStream fsB = new FileStream("binaryDemo.bin", FileMode.OpenOrCreate, FileAccess.Write);
		using BinaryWriter bw = new BinaryWriter(fsB);

		bw.Write(259);
		bw.Write("HuseyNuran");
		#endregion Write(BinaryWriter)


		#region Read(BinaryReader)
		using FileStream Fsb = new FileStream("binaryDemo.bin", FileMode.OpenOrCreate, FileAccess.Read);
		using BinaryReader br = new BinaryReader(Fsb);

		Console.WriteLine(br.ReadInt32());
		Console.WriteLine(br.ReadString());
		#endregion Read(BinaryReader)


		#region Write with File and FileInfo
		var book = new Book(1, "Rovshen Abdullaoglu", "Bu Sheherde Kimse Yoxdur", "Psixoloji Roman");

		File.WriteAllText("book", book.ToString());

		FileInfo fileInfo = new("bookFileInfo.txt");
		
		Console.WriteLine(fileInfo.FullName);
		Console.WriteLine(fileInfo.Exists);
		Console.WriteLine(fileInfo.Extension);
		Console.WriteLine(fileInfo.Directory);
		Console.WriteLine(fileInfo.Length);

		#endregion Write with File and FileInfo


		#region Directory and DirectoryInfo
		Directory.CreateDirectory($"C:\\Users\\{Environment.UserName}\\Desktop\\myFolder");
		Directory.CreateDirectory($"C:\\Users\\{Environment.UserName}\\Desktop\\myFolder2");

		Directory.Delete($"C:\\Users\\{Environment.UserName}\\Desktop\\myFolder2");

		foreach (var folder in Directory.GetDirectories(@$"C:\\Users\\{Environment.UserName}\\Desktop"))
			Console.WriteLine(folder);

		// . -> current
		// .. -> previous
		// ../.. -> previous of previous
		DirectoryInfo dri = new DirectoryInfo("../..");

		Console.WriteLine(dri.FullName);
		Console.WriteLine(dri.Parent);
		Console.WriteLine(dri.Name);
		Console.WriteLine(dri.Root);
		#endregion Directory and DirectoryInfo


		#region Path
		string fileName = "myself";
		string extension = ".txt";

		string fullName = fileName + extension;

		var path = Path.Combine(@"C:\Users", Environment.UserName, "Desktop", fullName);
		Console.WriteLine(path);

		var path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fullName);
		Console.WriteLine(path2);
		#endregion Path
	}
}