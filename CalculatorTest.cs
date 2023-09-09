using app;
using NUnit.Framework;

namespace tests;

public class CalculatorTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestMultiply()
    {
        var kalkulator = new Calculator();

        var wynik = kalkulator.Execute("2*2");

        Assert.AreEqual(4, wynik);
    }

    [Test]
    public void TestDivide()
    {
        var kalkulator = new Calculator();

        var wynik = kalkulator.Execute("2/2");

        Assert.AreEqual(1, wynik, "2/2!=1");
    }

    [Test]
    public void TestSum()
    {
        var kalkulator = new Calculator();

        var wynik = kalkulator.Execute("2+2");

        Assert.AreEqual(4, wynik);
    }

    [Test]
    public void TestSubstraction()
    {
        var kalkulator = new Calculator();

        var wynik = kalkulator.Execute("2-2");

        Assert.AreEqual(0, wynik);
    }

    [Test]
    public void TestOrderOperation()
    {
        var kalkulator = new Calculator();

        var wynik = kalkulator.Execute("2+2*3+4/2");

        Assert.AreEqual(10, wynik);
    }

    [Test]
    public void TestForBigNumbers()
    {
        var kalkulator = new Calculator();

        var wynik = kalkulator.Execute("132+256*3+400/2");

        Assert.AreEqual(1100, wynik);
    }

    public void MinusNumber()
    {
        var kalkulator = new Calculator();

        var wynik = kalkulator.Execute("-2+2*2/2");

        Assert.AreEqual(0, wynik);
    }
}