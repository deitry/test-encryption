namespace encrpt_nunit;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    public string Encrypt(string str)
    {
        var result = string.Empty;

        for (var i = 0; i < str.Length - 1; i += 2)
        {
            result += str[i + 1];
            result += str[i];
        }

        if (str.Length % 2 == 1)
            result += str.Last();

        return result;
    }

    [Test]
    [TestCase("move", "omev")]
    [TestCase("attackattack", "taatkctaatkc")]
    [TestCase("attack", "taatkc")]
    [TestCase("attack!attack!!", "taatkca!ttca!k!")]
    [TestCase("go!", "og!")]
    [TestCase("go", "og")]
    [TestCase("o", "o")]
    [TestCase("", "")]
    public void Test1(string original, string expected)
    {
        var encrypted = Encrypt(original);

        Assert.That(encrypted, Is.EqualTo(expected));

        var decrypted = Encrypt(encrypted);

        Assert.That(decrypted, Is.EqualTo(original));
    }

    public string Encrypt2(string str)
    {
        var result = string.Empty;

        for (var i = 0; i < str.Length / 2; i++)
        {
            result += str[i * 2 + 1];
            result += str[i * 2];
        }

        if (str.Length % 2 == 1)
            result += str.Last();

        return result;
    }

    [Test]
    [TestCase("move", "omev")]
    [TestCase("attackattack", "taatkctaatkc")]
    [TestCase("attack", "taatkc")]
    [TestCase("attack!attack!!", "taatkca!ttca!k!")]
    [TestCase("go!", "og!")]
    [TestCase("go", "og")]
    [TestCase("o", "o")]
    [TestCase("", "")]
    public void Test2(string original, string expected)
    {
        var encrypted = Encrypt2(original);

        Assert.That(encrypted, Is.EqualTo(expected));

        var decrypted = Encrypt2(encrypted);

        Assert.That(decrypted, Is.EqualTo(original));
    }
}
