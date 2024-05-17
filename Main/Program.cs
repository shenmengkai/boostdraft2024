using SimpleXMLValidatorLibrary;

class Program
{
    static void Main(string[] args)
    {
        string input = args.FirstOrDefault("");
        bool result = SimpleXmlValidator.DetermineXml(input);
        Environment.ExitCode = result ? 0 : 1;
        Console.WriteLine(result ? "Valid" : "Invalid");
    }
}