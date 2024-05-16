namespace SimpleXMLValidatorLibrary
{
    public class SimpleXmlValidator
    {
        //Please implement this method
        public static bool DetermineXml(string xml)
        {
            Stack<XmlComponent> stack = new Stack<XmlComponent>();
            xml = xml.Trim();
            XmlComponent? root = null;
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
                else if (next.Value.IsStartTag()) {
                    if (root == null) {
                        root = next;
                    }
                    else if (stack.Count == 0) {
                        return false;
                    }
                    stack.Push(next.Value);
                    continue;
                }

                if (stack.Count == 0) {
                    return false;
                }

                var startTag = stack.Pop();
                if (startTag.Name != next.Value.Name) {
                    return false;
                }
            }

            if (stack.Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}