namespace Test;
using SimpleXMLValidatorLibrary;

public class XmlComponentTest
{
    [Fact]
    public void FindNextNormalXml()
    {
        
    }

    [Theory]
    [InlineData("<a>", 0, 3, "a", XmlComponentType.StartTag)]
    [InlineData("</a>", 0, 4, "a", XmlComponentType.EndTag)]
    [InlineData("<a >", 0, 4, "a", XmlComponentType.StartTag)]
    [InlineData("xxx</a>", 0, 7, "a", XmlComponentType.EndTag)]
    [InlineData("xxx</a>", 3, 7, "a", XmlComponentType.EndTag)]
    public void FindNextTagNormal(string xml, int index, int expectNext, string expectTagName, XmlComponentType expectTagType)
    {
        XmlComponent? tag = null;
        var remainIndex = XmlComponent.FindNextTag(xml, ref tag, index);
        Assert.Equal(expectNext, remainIndex);
        Assert.NotNull(tag);
        Assert.Equal(expectTagName, tag.Value.Name);
        Assert.Equal(expectTagType, tag.Value.Type);
    }

    [Theory]
    [InlineData("", 0)]
    [InlineData(" ", 0)]
    [InlineData("a", 0)]
    [InlineData("<", 0)]
    [InlineData(">", 0)]
    [InlineData("<<a>", 0)]
    [InlineData("><a>", 0)]
    [InlineData("<a>", 1)]
    public void FindNextFails(string xml, int index)
    {
        XmlComponent? tag = null;
        var remainIndex = XmlComponent.FindNextTag(xml, ref tag, index);
        Assert.Equal(-1, remainIndex);
        Assert.Null(tag);
    }
}