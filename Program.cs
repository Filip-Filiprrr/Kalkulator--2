using app;
namespace app;
internal class Program
{
    private static void Main(string[] args)
    {
        //var calculator = new Calculator();

        // System.Console.WriteLine("Wpisz dzialanie:");
        
        // string? operation = "((7-2)+16)";
        
        // double a = 0;
        
        // if (operation != null)
        // {
        //     a = calculator.Execute(operation);
        // }

        // System.Console.WriteLine(a);

        string exp = "(12+34)*56";

        var p = new Parser(exp);
        
        var l = p.ReadAll();

        var root = new TreeBuilder().Build(l);

        var wynik = new TreeKalkulator(new DecimalVisitor()).Execute(root);

        System.Console.WriteLine(wynik);

        // foreach(var t in l)
        // {
        //     System.Console.WriteLine("{0} - {1}", t.Value(), t.TokenType());
        // }

        // var r = new Reader(exp);

        // while(r.MoveNext())
        // {
        //     var t = r.Current;
        //     System.Console.WriteLine("{0} - {1}", t.Value(), t.TokenType());
        // }
    }
}