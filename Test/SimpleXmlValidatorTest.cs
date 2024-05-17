namespace Test;
using SimpleXMLValidatorLibrary;

public class SimpleXMLValidatorTest
{
    [Theory]
    [InlineData("<a></a>")]
    [InlineData("<a/>")]
    [InlineData("<a>x</a>")]
    [InlineData("<a><b/></a>")]
    [InlineData("<a><b></b></a>")]
    [InlineData("<a><b>x</b></a>")]
    [InlineData("<a><b></b>x</a>")]
    [InlineData("<a><b/>x</a>")]
    public void DetermineXmlValids(string input)
    {
        Assert.True(SimpleXmlValidator.DetermineXml(input));
    }

    [Theory]
    [InlineData("<>")]
    [InlineData("<a>")]
    [InlineData("<a></a><")]
    [InlineData("<a></a>x")]
    [InlineData("<a>x</a><")]
    [InlineData("<a t=\"1\"></a>")]
    [InlineData("<a><b></b>")]
    [InlineData("<a><b></a>")]
    [InlineData("<a></a><b></b>")]
    public void DetermineXmlInvalids(string input)
    {
        Assert.False(SimpleXmlValidator.DetermineXml(input));
    }
}