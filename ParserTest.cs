using app;
using NUnit.Framework;

namespace tests;

public class ParserTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestMultiplyForTree()
    {
        var wynik = "2*2";

        var kalkulator = new Parser(wynik).ReadAll();

        Assert.AreEqual(3, kalkulator.Count);

        Assert.AreEqual("2", kalkulator[0].Value());
        Assert.AreEqual(TokenType.Number, kalkulator[0].TokenType());

        Assert.AreEqual(Operation.Mulitiply, kalkulator[1].Value());
        Assert.AreEqual(TokenType.Mark, kalkulator[1].TokenType());

        Assert.AreEqual("2", kalkulator[2].Value());
        Assert.AreEqual(TokenType.Number, kalkulator[2].TokenType());
    }

    [Test]
    public void TestDivideForTree()
    {
        var wynik = "2/2";

        var kalkulator = new Parser(wynik).ReadAll();

        Assert.AreEqual(3, kalkulator.Count);

        Assert.AreEqual("2", kalkulator[0].Value());
        Assert.AreEqual(TokenType.Number, kalkulator[0].TokenType());

        Assert.AreEqual(Operation.Divide, kalkulator[1].Value());
        Assert.AreEqual(TokenType.Mark, kalkulator[1].TokenType());

        Assert.AreEqual("2", kalkulator[2].Value());
        Assert.AreEqual(TokenType.Number, kalkulator[2].TokenType());
    }

    [Test]
    public void TestAddForTree()
    {
        var wynik = "2+2";

        var kalkulator = new Parser(wynik).ReadAll();

        Assert.AreEqual(3, kalkulator.Count);

        Assert.AreEqual("2", kalkulator[0].Value());
        Assert.AreEqual(TokenType.Number, kalkulator[0].TokenType());

        Assert.AreEqual(Operation.Add, kalkulator[1].Value());
        Assert.AreEqual(TokenType.Mark, kalkulator[1].TokenType());

        Assert.AreEqual("2", kalkulator[2].Value());
        Assert.AreEqual(TokenType.Number, kalkulator[2].TokenType());
    }

    [Test]
    public void TestSubForTree()
    {
        var wynik = "2-2";

        var kalkulator = new Parser(wynik).ReadAll();

        Assert.AreEqual(3, kalkulator.Count);

        Assert.AreEqual("2", kalkulator[0].Value());
        Assert.AreEqual(TokenType.Number, kalkulator[0].TokenType());

        Assert.AreEqual(Operation.Sub, kalkulator[1].Value());
        Assert.AreEqual(TokenType.Mark, kalkulator[1].TokenType());

        Assert.AreEqual("2", kalkulator[2].Value());
        Assert.AreEqual(TokenType.Number, kalkulator[2].TokenType());
    }

    [Test]
    public void MinusNumberForTree()
    {
        var wynik = "-2+2*2/2";

        var kalkulator = new Parser(wynik).ReadAll();

        Assert.AreEqual(8, kalkulator.Count); 
    }

    [Test]
    public void TestForBigNumbersForTree()
    {
        var wynik = "132+256*3+400/2";

        var kalkulator = new Parser(wynik).ReadAll();

        Assert.AreEqual(9, kalkulator.Count);        
    }

    [Test]
    public void TestForOperationOrderForTree()
    {
        var wynik = "2*2+7/7";

        var kalkulator = new Parser(wynik).ReadAll();

        Assert.AreEqual(7, kalkulator.Count);        
    }
}