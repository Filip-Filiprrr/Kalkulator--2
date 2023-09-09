using System.Collections;
using app;
namespace app;

public class Parser : IEnumerable<Token>
{
    private string exp;

    public Parser(string exp)
    {
        this.exp = exp;
    }

    public IEnumerator<Token> GetEnumerator()
    {
        return new Reader(exp);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new Reader(exp);
    }

    public List<Token> ReadAll()
    {
        var l = new List<Token>();

        foreach (var t in this)
        {
            l.Add(t);
        }

        return l;

    }
}

public class Reader : IEnumerator<Token>
{
    private string exp;
    private int i = 0;
    private string buffer = "";
    private Token current;

    private static IReadOnlySet<char> MARKS = new HashSet<char>() { '+', '-', '*', '/', '(', ')' };

    public Reader(string exp) => this.exp = exp;

    public Token Current => current;

    object IEnumerator.Current => throw new NotImplementedException();

    public void Dispose()
    {
        this.Reset();
    }

    public bool MoveNext()
    {
        for (; i < exp.Length; i++)
        {
            if (MARKS.Contains(exp[i]))
            {
                if (buffer.Length > 0)
                {
                    this.current = new Token(buffer, TokenType.Number);
                    buffer = "";
                }
                else
                {
                    if (exp[i] == '(')
                    {
                        this.current = new Token(exp[i], TokenType.GroupOpen);

                    }
                    else if (exp[i] == ')')
                    {
                        this.current = new Token(exp[i], TokenType.GroupClose);

                    }
                    else
                    {
                        this.current = new Token(ValueOf(exp[i]), TokenType.Mark);

                    }

                    i++;
                }
                return true;
            }

            buffer += exp[i];

        }

        if (buffer.Length > 0)
        {
            this.current = new Token(buffer, TokenType.Number);
            buffer = "";

            return true;
        }

        return false;
    }

    public void Reset()
    {
        this.i = 0;
        this.buffer = "";
        this.current = null;
    }

    private Operation ValueOf(char c)
    {
        switch (c)
        {
            case '*':

                return Operation.Mulitiply;

            case '/':

                return Operation.Divide;

            case '+':

                return Operation.Add;

            case '-':

                return Operation.Sub;

            default: throw new ArgumentException("unknown operation: " + c);
        }
    }
}

public class Token
{
    private Object value;
    private TokenType tokenType;

    public Token(Object value, TokenType tokenType)
    {
        this.tokenType = tokenType;
        this.value = value;
    }

    public object Value()
    {
        return this.value;
    }

    public TokenType TokenType()
    {
        return this.tokenType;
    }
}
public enum TokenType
{
    Mark,
    Number,
    GroupOpen,
    GroupClose
}

public enum Operation
{
    Add,
    Sub,
    Mulitiply,
    Divide,
}


