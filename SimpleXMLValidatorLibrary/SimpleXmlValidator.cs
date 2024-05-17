namespace SimpleXMLValidatorLibrary
{
    public class SimpleXmlValidator
    {
        //Please implement this method
        public static bool DetermineXml(string xml)
        {
            TagStack tagStack = new TagStack();
            
            xml = xml.Trim();
            var index = 0;
            while (index > -1 && index < xml.Length) {
                XmlComponent? next = null;
                index = XmlComponent.FindNextTag(xml, ref next, index);
                if (next == null || index < 0) {
                    return false;
                }

                if (next.Value.IsSelfClosingTag()) {
                    continue;
                }

                if (next.Value.IsStartTag()) {
                    if (tagStack.isDocumentClosed) {
                        return false;
                    }
                    tagStack.Push(next.Value);
                    continue;
                }

                if (tagStack.NoMatchedTag(next.Value.Name)) {
                    return false;
                }

                tagStack.Pop();
            }

            if (tagStack.Count > 0)
            {
                return false;
            }
            return true;
        }
    }

    class TagStack : Stack<XmlComponent>
    {
        public XmlComponent? Root { get; private set; }

        public bool isDocumentClosed
        {
            get
            {
                return Root.HasValue && Count == 0;
            }
        }

        public new void Push(XmlComponent tag)
        {
            if (isDocumentClosed) {
                return;
            }

            Root = tag;
            base.Push(tag);
        }

        public bool NoMatchedTag(string name)
        {
            if (Count == 0) {
                return true;
            }

            if (Peek().Name != name) {
                return true;
            }

            return false;
        }
    }
}