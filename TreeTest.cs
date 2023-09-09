using app;
using NUnit.Framework;

namespace tests;

public class TreeTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestForTree()
    {
        var tokens = new List<Token>();

        var number2 = new Token("2", TokenType.Number);
        tokens.Add(number2);

        tokens.Add(new Token(Operation.Add, TokenType.Mark));

        var number = new Token("2", TokenType.Number);
        tokens.Add(number);
        
        var builder = new TreeBuilder();
        var root = builder.Build(tokens);
        
        Assert.AreEqual(number, root.rightNumber);
        Assert.AreEqual(number2, root.leftNumber);
        Assert.AreEqual(Operation.Add, root.mark);
    }

    [Test]
    public void TestForTree2()
    {
        var tokens = new List<Token>();

        var number1 = new Token("2", TokenType.Number);
        tokens.Add(number1);

        tokens.Add(new Token(Operation.Add, TokenType.Mark));

        var number2 = new Token("3", TokenType.Number);
        tokens.Add(number2);

        tokens.Add(new Token(Operation.Mulitiply, TokenType.Mark));

        var number3 = new Token("4", TokenType.Number);
        tokens.Add(number3);
        
        var builder = new TreeBuilder();
        var root = builder.Build(tokens);
        
        Assert.AreEqual(number1, root.leftNumber);
        Assert.AreEqual(Operation.Add, root.mark);
        Assert.AreEqual(number2, root.rightNode.leftNumber);
        Assert.AreEqual(Operation.Mulitiply, root.rightNode.mark); 
        Assert.AreEqual(number3, root.rightNode.rightNumber);
    }

    [Test]
    public void TestForTree3()
    {
    }
}