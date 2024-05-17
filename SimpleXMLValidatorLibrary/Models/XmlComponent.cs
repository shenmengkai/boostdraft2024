namespace SimpleXMLValidatorLibrary
{
    public enum XmlComponentType
    {
        StartTag,
        EndTag,
        SelfClosingTag,
    }

    public struct XmlComponent
    {
        public string Name { get; set; }
        public XmlComponentType Type { get; set; }

        public XmlComponent(string name, XmlComponentType type)
        {
            Name = name.Trim();
            Type = type;
        }

        public override string ToString()
        {
            switch(Type)
            {
                case XmlComponentType.StartTag:
                    return $"<{Name}>";
                case XmlComponentType.EndTag:
                    return $"</{Name}>";
                case XmlComponentType.SelfClosingTag:
                    return $"<{Name}/>";
                default:
                    return "";
            }
        }

        public bool IsStartTag()
        {
            return Type == XmlComponentType.StartTag;
        }

        public bool IsSelfClosingTag()
        {
            return Type == XmlComponentType.SelfClosingTag;
        }

        /// <summary>
        /// Finds the next XML tag pattern in the input string starting from the specified index.
        /// </summary>
        /// <param name="input">The input string to search for the XML tag.</param>
        /// <param name="tag">The reference to the XmlTag structure to assign the found tag.</param>
        /// <param name="index">The starting index to search for the tag. Defaults to 0.</param>
        /// <returns>
        /// The index after the closing '>' of the found tag, or -1 if no tag is found.
        /// </returns>
        public static int FindNextTag(string input, ref XmlComponent? next, int index = 0)
        {
            if (string.IsNullOrEmpty(input) || index >= input.Length - 1)
            {
                return -1;
            }

            if (index < 0)
            {
                index = 0;
            }

            int startBracket = input.IndexOf('<', index);
            if (startBracket == -1)
            {
                return -1;
            }

            int endBracket = input.IndexOf('>', startBracket);
            if (endBracket == -1)
            {
                return -1;
            }

            // must no '>' in front of tag
            if (input.Substring(index, startBracket - index).IndexOf('>') > -1)
            {
                return -1;
            }

            // int len = endBracket - startBracket - 1;

            var type = XmlComponentType.StartTag;
            var nameStart = startBracket + 1;
            var nameEnd = endBracket - 1;
            if (input[nameStart] == '/')
            {
                type = XmlComponentType.EndTag;
                nameStart++;
                // len--;
            }
            else if (input[nameEnd] == '/')
            {
                type = XmlComponentType.SelfClosingTag;
                nameEnd--;
            }

            var name = input.Substring(nameStart, nameEnd + 1 - nameStart);
            // must no '<' in tag
            if (name.IndexOf('<') > -1)
            {
                return -1;
            }

            next = new XmlComponent(name, type);
            return endBracket + 1;
        }
    }
}