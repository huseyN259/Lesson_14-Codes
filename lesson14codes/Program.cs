using System.Text;

// task
static class ExtensionMethod
{
	public static IEnumerator<int> GetEnumerator(this int i) => Enumerable.Range(0, i + 1).GetEnumerator();
}

class Program
{
	static void Main()
	{
		int hn = 259;

		foreach (int i in hn)
			Console.WriteLine(i);
	}
}