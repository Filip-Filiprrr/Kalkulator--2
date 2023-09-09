
namespace app;

public class TreeNode
{
    public Token leftNumber;
    public Operation mark;
    public Token rightNumber;
    public TreeNode rightNode;
    public TreeNode parent;
    public TreeNode leftNode;

    public bool IsLeaf()
    {
        return rightNode == null && leftNode == null;

    }

    public bool IsRoot()
    {
        return parent == null;
    }

    public TreeNode GetRoot()
    {
        if (IsRoot())
        {
            return this;
        }
        return parent.GetRoot();
    }


}

public class TreeBuilder
{
    public TreeNode Build(List<Token> tokens)
    {
        return Attach(tokens, 0, null).GetRoot();
    }

    private TreeNode Attach(List<Token> tokens, int i, TreeNode prev)
    {
        var prevPrio = 0;

        if (prev != null)
        {
            //ustawic priorytet w TreeNode
            prevPrio = prios[prev.mark];
        }

        for (; i < tokens.Count; i++)
        {
            if (tokens[i].TokenType() == TokenType.GroupOpen)
            {
                var group = new List<Token>();

                i++;

                for (; i < tokens.Count; i++)
                {
                    if (tokens[i].TokenType() != TokenType.GroupClose)
                    {
                        group.Add(tokens[i]);
                    }
                    else
                    {
                        i++;
                        break;
                    }
                }
                var groupRoot = Attach(group, 0, null).GetRoot();

                if (prev == null)
                {
                    return Attach(tokens, i, groupRoot);
                }
                else
                {
                    prev.rightNode = groupRoot;
                    return Attach(tokens, i, prev);
                }
            }
            else if (tokens[i].TokenType() == TokenType.Mark)
            {

                var node = new TreeNode();

                node.mark = (Operation)tokens[i].Value();
                node.leftNumber = tokens[i - 1];
                node.rightNumber = tokens[i + 1];

                var nodePrio = prios[node.mark];

                if (prev != null)
                {
                    if (prevPrio >= nodePrio)
                    {
                        node.leftNumber = null;
                        node.leftNode = prev;
                        prev.parent = node;
                    }
                    else
                    {
                        prev.rightNumber = null;
                        prev.rightNode = node;
                        node.parent = prev;
                    }
                }

                return Attach(tokens, i + 1, node);
            }

        }

        return prev;
    }

    Dictionary<Operation, Int32> prios = new Dictionary<Operation, Int32>()
    {
        { Operation.Mulitiply, 1 },
        { Operation.Divide, 1 },
        { Operation.Add, 0 },
        { Operation.Sub, 0 }

    };

}
