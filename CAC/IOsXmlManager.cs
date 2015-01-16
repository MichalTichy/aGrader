using System;
using System.Xml;
using CAC.IO_Forms.Inputs;

namespace CAC
{
    static class IOsXmlManager
    {
        /// <summary>
        /// Exports all IOs to xml file.
        /// </summary>
        /// <param name="path"></param>
        public static void ExportToXml(string path)
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

        /// <summary>
        /// Generate IONode for InputNumber.
        /// </summary>
        /// <param name="ioForm"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        private static XmlNode GenerateIONode(InputNumber ioForm, XmlDocument doc)
        {
            XmlElement inNumber = doc.CreateElement(ioForm.Name);

            XmlElement numericvalue = doc.CreateElement("numeric");
            numericvalue.InnerText = ioForm.Value.ToString();

            inNumber.AppendChild(numericvalue);
            
            return inNumber;
        }
        /// <summary>
        /// Generate IONode for InputString.
        /// </summary>
        /// <param name="ioForm"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        private static XmlNode GenerateIONode(InputString ioForm, XmlDocument doc)
        {
            XmlElement inString = doc.CreateElement(ioForm.Name);

            XmlElement stringvalue = doc.CreateElement("string");
            stringvalue.InnerText = ioForm.text;

            inString.AppendChild(stringvalue);

            return inString;
        }
        /// <summary>
        /// Generate IONode for InputRandomNumber
        /// </summary>
        /// <param name="ioForm"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        private static XmlNode GenerateIONode(InputRandomNumber ioForm, XmlDocument doc)
        {
            XmlElement inRandomNumber = doc.CreateElement(ioForm.Name);

            XmlElement minvalue = doc.CreateElement("minValue");
            minvalue.InnerText = ioForm.Min.ToString();
            XmlElement maxvalue = doc.CreateElement("maxValue");
            maxvalue.InnerText = ioForm.Max.ToString();
            XmlElement isDecimal = doc.CreateElement("isDecimal");
            isDecimal.InnerText = ioForm.Decimal.ToString();

            inRandomNumber.AppendChild(minvalue);
            inRandomNumber.AppendChild(maxvalue);
            inRandomNumber.AppendChild(isDecimal);

            return inRandomNumber;
        }
        /// <summary>
        /// Generate IONode for InputTextFile.
        /// </summary>
        /// <param name="ioForm"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        private static XmlNode GenerateIONode(InputTextFile ioForm, XmlDocument doc)
        {
            XmlElement inTextFile = doc.CreateElement(ioForm.Name);

            XmlElement path = doc.CreateElement("path");
            path.InnerText = ioForm.Path;
            XmlElement lineformat = doc.CreateElement("lineformat");
            lineformat.InnerText = ioForm.Lineformat;

            inTextFile.AppendChild(path);
            inTextFile.AppendChild(lineformat);

            return inTextFile;
        }

        /// <summary>
        /// Imports IOs from xml file.
        /// </summary>
        /// <param name="path"></param>
        public static void AddIOsFromXml(string path)
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
