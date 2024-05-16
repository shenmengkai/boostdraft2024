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
                    System.Console.WriteLine($"No tag found");
                    break;
                }

                if (next.Value.IsStartTag()) {
                    if (root == null) {
                        root = next;
                    }
                    else if (stack.Count == 0) {
                        System.Console.WriteLine($"Extra content after end of document");
                        return false;
                    }
                    stack.Push(next.Value);
                    System.Console.WriteLine($"Push: {next}");
                    continue;
                }

                if (stack.Count == 0) {
                    System.Console.WriteLine($"Empty stack");
                    return false;
                }

                var startTag = stack.Pop();
                if (startTag.Name != next.Value.Name) {
                    System.Console.WriteLine($"Tag not match: {startTag}, {next}");
                    return false;
                }
                System.Console.WriteLine($" Pop: {startTag}");
            }
            return true;
        }
    }
}