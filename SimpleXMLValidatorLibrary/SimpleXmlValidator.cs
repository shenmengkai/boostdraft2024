namespace SimpleXMLValidatorLibrary
{
    public class SimpleXmlValidator
    {
        //Please implement this method
        public static bool DetermineXml(string xml)
        {
            XmlTagStack tagStack = new XmlTagStack();
            
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
}