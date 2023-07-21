using iText7Wrapper;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        IiText7Wrapper var = new iText7Wrapper.iText7Wrapper();
        var.GeneratePdfFromHtml("<h1>Hello<h1>");
    }
}