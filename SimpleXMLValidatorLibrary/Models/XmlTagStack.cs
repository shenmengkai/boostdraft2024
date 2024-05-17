namespace SimpleXMLValidatorLibrary
{
    public class XmlTagStack : Stack<XmlComponent>
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