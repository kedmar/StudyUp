using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StudyUpController
{
    public class DocxReader
    {
        protected const string MainDocumentRelationshipType =
                    "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument";
        private readonly Package package;
        private readonly PackagePart mainDocumentPart;

        public DocxReader(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            this.package = Package.Open(stream, FileMode.Open, FileAccess.Read);

            foreach (var relationship in
               this.package.GetRelationshipsByType(MainDocumentRelationshipType))
            {
                this.mainDocumentPart =
                  package.GetPart(PackUriHelper.CreatePartUri(relationship.TargetUri));
                break;
            }
        }


        protected virtual void ReadDocument(XmlReader reader)
        {
            while (reader.Read())
                if (reader.NodeType == XmlNodeType.Element && reader.NamespaceURI ==
                  WordprocessingMLNamespace && reader.LocalName == BodyElement)
                {
                    ReadXmlSubtree(reader, this.ReadBody);
                    break;
                }
        }

        private void ReadBody(XmlReader reader) {}
        private void ReadBlockLevelElement(XmlReader reader) {}
        protected virtual void ReadParagraph(XmlReader reader) {}
        private void ReadInlineLevelElement(XmlReader reader) {}
        protected virtual void ReadRun(XmlReader reader) {}
        private void ReadRunContentElement(XmlReader reader) {}
        protected virtual void ReadText(XmlReader reader) {}
    }
}
