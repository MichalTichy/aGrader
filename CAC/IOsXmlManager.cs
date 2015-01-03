using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CAC
{
    static class IOsXmlManager
    {
        public static void ExportToXML(string path)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(declaration);
            XmlElement root = doc.CreateElement("Protocol");

            foreach (dynamic IOForm in IOs.getList())
            {
                root.AppendChild(GenerateIONode(IOForm,doc));
            }
            doc.AppendChild(root);
            doc.Save(path);
        }

        private static XmlNode GenerateIONode(InputNumber IOForm, XmlDocument doc)
        {
            XmlElement InNumber = doc.CreateElement(IOForm.Name);

            XmlElement numericvalue = doc.CreateElement("numeric");
            numericvalue.InnerText = IOForm.Value.ToString();

            InNumber.AppendChild(numericvalue);

            return InNumber;
        }
        private static XmlNode GenerateIONode(InputString IOForm, XmlDocument doc)
        {
            XmlElement InString = doc.CreateElement(IOForm.Name);

            XmlElement stringvalue = doc.CreateElement("string");
            stringvalue.InnerText = IOForm.text;

            InString.AppendChild(stringvalue);

            return InString;
        }
        private static XmlNode GenerateIONode(InputRandomNumber IOForm, XmlDocument doc)
        {
            XmlElement InRandomNumber = doc.CreateElement(IOForm.Name);

            XmlElement minvalue = doc.CreateElement("minValue");
            minvalue.InnerText = IOForm.min.ToString();
            XmlElement maxvalue = doc.CreateElement("maxValue");
            maxvalue.InnerText = IOForm.max.ToString();
            XmlElement isDecimal = doc.CreateElement("isDecimal");
            isDecimal.InnerText = IOForm.Decimal.ToString();

            InRandomNumber.AppendChild(minvalue);
            InRandomNumber.AppendChild(maxvalue);
            InRandomNumber.AppendChild(isDecimal);

            return InRandomNumber;
        }
        private static XmlNode GenerateIONode(InputTextFile IOForm, XmlDocument doc)
        {
            XmlElement InTextFile = doc.CreateElement(IOForm.Name);

            XmlElement path = doc.CreateElement("path");
            path.InnerText = IOForm.path;
            XmlElement lineformat = doc.CreateElement("lineformat");
            lineformat.InnerText = IOForm.lineformat;

            InTextFile.AppendChild(path);
            InTextFile.AppendChild(lineformat);

            return InTextFile;
        }

        public static void AddIOsFromXML(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode root = doc.DocumentElement;
            if (root.Name == "Protocol")
            {
                foreach (XmlNode node in root.ChildNodes)
                {
                    XmlElement element=(XmlElement)node;
                    switch (node.Name)
                    {
                        case "InputTextFile":
                            IOs.Add(new InputTextFile(element.GetElementsByTagName("path")[0].InnerText, element.GetElementsByTagName("lineformat")[0].InnerText));
                            break;
                        case "InputNumber":
                            IOs.Add(new InputNumber(decimal.Parse(element.GetElementsByTagName("numeric")[0].InnerText)));
                            break;
                        case "InputRandomNumber":
                            IOs.Add(new InputRandomNumber(decimal.Parse(element.GetElementsByTagName("minValue")[0].InnerText), decimal.Parse(element.GetElementsByTagName("maxValue")[0].InnerText), bool.Parse(element.GetElementsByTagName("isDecimal")[0].InnerText)));
                            break;
                        case "InputString":
                            IOs.Add(new InputString(element.GetElementsByTagName("string")[0].InnerText));
                            break;
                    }
                }
            }
            else
                throw new FormatException();
        }

    }
}
