using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace CAC
{
    public static class IOs
    {
        private static List<dynamic> IOForms = new List<dynamic>();

        public static List<dynamic> getList()
        {
            return IOForms;
        }

        public static void Add(dynamic IOForm)
        {
            if (SideFormManager.IsValidDataType(IOForm.GetType()))
                IOForms.Add(IOForm);
        }
        public static void Swap(int index1,int index2)
        {
            dynamic temp = IOForms[index1];
            IOForms[index1] = IOForms[index2];
            IOForms[index2] = temp;
        }

        public static XmlDocument GenerateXMLDocument()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(declaration);
            XmlElement root = doc.CreateElement("TestProtocol");

            foreach (dynamic IOForm in IOForms)
            {
                XmlElement IOMethod = doc.CreateElement(IOForm.Name);
                switch (IOForm.Name as string)
                {
                    case "InputString":
                        XmlElement stringvalue = doc.CreateElement("string");
                        stringvalue.InnerText = IOForm.text;

                        IOMethod.AppendChild(stringvalue);
                        break;
                    case "InputNumber":
                        XmlElement numericvalue = doc.CreateElement("numeric");
                        numericvalue.InnerText = IOForm.Value.ToString();

                        IOMethod.AppendChild(numericvalue);
                        break;
                    case "InputRandomNumber":
                        XmlElement minvalue = doc.CreateElement("minValue");
                        minvalue.InnerText = IOForm.min.ToString();
                        XmlElement maxvalue = doc.CreateElement("maxValue");
                        maxvalue.InnerText = IOForm.max.ToString();
                        XmlElement isDecimal = doc.CreateElement("isDecimal");
                        isDecimal.InnerText = IOForm.Decimal.ToString();

                        IOMethod.AppendChild(minvalue);
                        IOMethod.AppendChild(maxvalue);
                        IOMethod.AppendChild(isDecimal);
                        break;
                    case "InputFile":
                        XmlElement path = doc.CreateElement("path");
                        path.InnerText = IOForm.path;
                        XmlElement lineformat = doc.CreateElement("lineformat");
                        lineformat.InnerText = IOForm.lineformat;

                        IOMethod.AppendChild(path);
                        IOMethod.AppendChild(lineformat);
                        break;
                }
                root.AppendChild(IOMethod);
            }
            doc.AppendChild(root);
            return doc;
        }

    }
}
