using app;
namespace app;

public class DecimalVisitor : TreeVisitor
{
    public double Add(string left, string right)
    {
        double l = Double.Parse(left);
        double r = Double.Parse(right);

        return l + r;
    }

    public double Sub(string left, string right)
    {
        double l = Double.Parse(left);
        double r = Double.Parse(right);

        return l - r;
    }

    public double Mulitiply(string left, string right)
    {
        double l = Double.Parse(left);
        double r = Double.Parse(right);

        return l * r;
    }

    public double Divide(string left, string right)
    {
        double l = Double.Parse(left);
        double r = Double.Parse(right);

        return l / r;
    }
    
}