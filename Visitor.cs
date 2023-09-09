using app;
namespace app;
public interface TreeVisitor
{
    double Add(string left, string right);

    double Sub(string left, string right);

    double Mulitiply(string left, string right);

    double Divide(string left, string right);
}

public class TreeKalkulator
{
    private TreeVisitor visitor;

    public TreeKalkulator(TreeVisitor visitor)
    {
        this.visitor = visitor;
    }

    public double Execute(TreeNode node)
    {
        if (node.IsLeaf())
        {
            switch (node.mark)
            {
                case Operation.Add:
                    return visitor.Add(node.leftNumber.Value().ToString(), node.rightNumber.Value().ToString());

                case Operation.Sub:
                    return visitor.Sub(node.leftNumber.Value().ToString(), node.rightNumber.Value().ToString());

                case Operation.Mulitiply:
                    return visitor.Mulitiply(node.leftNumber.Value().ToString(), node.rightNumber.Value().ToString());

                case Operation.Divide:
                    return visitor.Divide(node.leftNumber.Value().ToString(), node.rightNumber.Value().ToString());
            }

        }

        var t = new TreeNode();

        if (node.rightNode != null)
        {
            t.rightNumber = new Token(Execute(node.rightNode).ToString(), TokenType.Number);
        }
        else
        {
            t.rightNumber = node.rightNumber;
        }

        if (node.leftNode != null)
        {
            t.leftNumber = new Token(Execute(node.leftNode).ToString(), TokenType.Number);
        }
        else
        {
            t.leftNumber = node.leftNumber;
        }

        t.mark = node.mark;

        return Execute(t);

    }
}