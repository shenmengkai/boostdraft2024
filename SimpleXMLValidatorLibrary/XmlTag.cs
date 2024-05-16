
namespace SimpleXMLValidatorLibrary
{
    public struct XmlTag
    {
        public string Name { get; set; }
        public bool IsStartTag { get; set; }

        public XmlTag(string name, bool isStartTag = true)
        {
            Name = name;
            IsStartTag = isStartTag;
        }

        public override string ToString()
        {
            return IsStartTag ? $"<{Name}>" : $"</{Name}>";
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
        public static int FindNext(string input, ref XmlTag? next, int index = 0)
        {
            if (string.IsNullOrEmpty(input) || index >= input.Length - 1)
            {
                return -1;
            }

            if (index < 0)
            {
                index = 0;
            }

            int startIndex = input.IndexOf('<', index);
            if (startIndex == -1)
            {
                return -1;
            }

            int endIndex = input.IndexOf('>', startIndex);
            if (endIndex == -1)
            {
                return -1;
            }

            int len = endIndex - startIndex - 1;

            bool isStartTag = true;
            if (input[startIndex + 1] == '/')
            {
                isStartTag = false;
                startIndex++;
                len--;
            }

            var name = input.Substring(startIndex + 1, len);

            next = new XmlTag(name, isStartTag);
            return endIndex + 1;
        }
    }
}