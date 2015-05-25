using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using CAC.IO_Forms;

namespace CAC
{
    internal static class InOutXmlManager
    {
        public static void ExportToXml(string path)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(declaration);
            XmlElement root = doc.CreateElement("Protocol");

            foreach (dynamic formIO in InputsOutputs.GetList())
            {
                root.AppendChild(GenerateIONode(formIO, doc));
            }
            doc.AppendChild(root);
            doc.Save(path);
        }

        private static XmlNode GenerateIONode(InputNumber ioForm, XmlDocument document)
        {
            XmlElement inNumber = document.CreateElement(ioForm.Name);

            XmlElement numericvalue = document.CreateElement("numeric");
            numericvalue.InnerText = ioForm.Value.ToString();

            inNumber.AppendChild(numericvalue);

            return inNumber;
        }

        private static XmlNode GenerateIONode(InputString ioForm, XmlDocument document)
        {
            XmlElement inString = document.CreateElement(ioForm.Name);

            XmlElement stringvalue = document.CreateElement("string");
            stringvalue.InnerText = ioForm.Text;

            inString.AppendChild(stringvalue);

            return inString;
        }

        private static XmlNode GenerateIONode(InputRandomNumber ioForm, XmlDocument document)
        {
            XmlElement inRandomNumber = document.CreateElement(ioForm.Name);

            XmlElement minvalue = document.CreateElement("minValue");
            minvalue.InnerText = ioForm.Min.ToString();

            XmlElement maxvalue = document.CreateElement("maxValue");
            maxvalue.InnerText = ioForm.Max.ToString();

            XmlElement isDecimal = document.CreateElement("isDecimal");
            isDecimal.InnerText = ioForm.Decimal.ToString();

            XmlElement ID = document.CreateElement("ID");
            ID.InnerText = ioForm.ID.ToString();

            inRandomNumber.AppendChild(ID);
            inRandomNumber.AppendChild(minvalue);
            inRandomNumber.AppendChild(maxvalue);
            inRandomNumber.AppendChild(isDecimal);

            return inRandomNumber;
        }

        private static XmlNode GenerateIONode(InputTextFile ioForm, XmlDocument document)
        {
            XmlElement inTextFile = document.CreateElement(ioForm.Name);

            XmlElement path = document.CreateElement("path");
            path.InnerText = ioForm.Path;
            XmlElement lineformat = document.CreateElement("lineformat");
            lineformat.InnerText = ioForm.Lineformat;

            inTextFile.AppendChild(path);
            inTextFile.AppendChild(lineformat);

            return inTextFile;
        }

        private static XmlNode GenerateIONode(OutputNumber ioForm, XmlDocument document)
        {
            XmlElement outNumber = document.CreateElement(ioForm.Name);

            XmlElement numericvalue = document.CreateElement("numeric");
            numericvalue.InnerText = ioForm.Value.ToString();

            outNumber.AppendChild(numericvalue);

            return outNumber;
        }

        private static XmlNode GenerateIONode(OutputNumberBasedOnRandomInput ioForm, XmlDocument document)
        {
            XmlElement outRandom = document.CreateElement(ioForm.Name);

            XmlElement jahoda = document.CreateElement("jahoda"); //todo jahoda found
            jahoda.InnerText = ioForm.jahoda;

            outRandom.AppendChild(jahoda);

            return outRandom;
        }

        private static XmlNode GenerateIONode(OutputNumberMatchingConditions ioForm, XmlDocument document)
        {
            XmlElement outNum = document.CreateElement(ioForm.Name);

            foreach (string condition in ioForm.Conditions)
            {
                XmlElement conditionElement = document.CreateElement("condition");
                conditionElement.InnerText = condition;
                outNum.AppendChild(conditionElement);
            }
            return outNum;
        }

        private static XmlNode GenerateIONode(OutputString ioForm, XmlDocument document)
        {
            XmlElement outString = document.CreateElement(ioForm.Name);

            XmlElement stringvalue = document.CreateElement("string");
            stringvalue.InnerText = ioForm.Text;

            outString.AppendChild(stringvalue);

            return outString;
            
        }

        private static XmlNode GenerateIONode(SettingsDeviation ioForm, XmlDocument document)
        {
            XmlElement SettDeviation = document.CreateElement(ioForm.Name);

            XmlElement Deviation = document.CreateElement("deviation");
            Deviation.InnerText = ioForm.deviation.ToString();

            SettDeviation.AppendChild(Deviation);

            return SettDeviation;
        }

        private static XmlNode GenerateIONode(SettingsProhibitedCommand ioForm, XmlDocument document)
        {
            XmlElement settProhibitedCommand = document.CreateElement(ioForm.Name);

            XmlElement stringvalue = document.CreateElement("prohibitedCommand");
            stringvalue.InnerText = ioForm.Text;

            settProhibitedCommand.AppendChild(stringvalue);

            return settProhibitedCommand;
        }

        private static XmlNode GenerateIONode(SettingsRequiedCommand ioForm, XmlDocument document)
        {
            XmlElement settRequiedCommand = document.CreateElement(ioForm.Name);

            XmlElement stringvalue = document.CreateElement("requiedCommand");
            stringvalue.InnerText = ioForm.Text;

            settRequiedCommand.AppendChild(stringvalue);

            return settRequiedCommand;
        }

        private static XmlNode GenerateIONode(ActionRepeatLast ioForm, XmlDocument document)
        {
            XmlElement ActionRepeatLast = document.CreateElement(ioForm.Name);

            XmlElement repetitions = document.CreateElement("repetitions");
            repetitions.InnerText = ioForm.Repetitions.ToString();

            ActionRepeatLast.AppendChild(repetitions);

            return ActionRepeatLast;
        }

        public static void AddIOsFromXml(string path)
        {
            //TODO REFAKTOROVAT!!!!!!!!
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode root = doc.DocumentElement;
            if (root.Name == "Protocol")
            {
                foreach (XmlNode node in root.ChildNodes)
                {
                    XmlElement element = (XmlElement) node;
                    switch (node.Name)
                    {
                        case "InputTextFile":
                            InputsOutputs.Add(new InputTextFile(element.GetElementsByTagName("path")[0].InnerText,
                                element.GetElementsByTagName("lineformat")[0].InnerText));
                            break;
                        case "InputNumber":
                            InputsOutputs.Add(
                                new InputNumber(decimal.Parse(element.GetElementsByTagName("numeric")[0].InnerText)));
                            break;
                        case "InputRandomNumber":
                            InputsOutputs.Add(
                                new InputRandomNumber(
                                    decimal.Parse(element.GetElementsByTagName("minValue")[0].InnerText),
                                    decimal.Parse(element.GetElementsByTagName("maxValue")[0].InnerText),
                                    bool.Parse(element.GetElementsByTagName("isDecimal")[0].InnerText),
                                    int.Parse(element.GetElementsByTagName("ID")[0].InnerText)));
                            break;
                        case "InputString":
                            InputsOutputs.Add(new InputString(element.GetElementsByTagName("string")[0].InnerText));
                            break;

                        case "OutputNumber":
                            InputsOutputs.Add(
                                new OutputNumber(decimal.Parse(element.GetElementsByTagName("numeric")[0].InnerText)));
                            break;

                        case "OutputNumberBasedOnRandomInput":
                            InputsOutputs.Add(
                                new OutputNumberBasedOnRandomInput(element.GetElementsByTagName("jahoda")[0].InnerText));
                            break;
                        case "OutputNumberMatchingConditions":
                            List<string> conditions= (from XmlElement condition in element.GetElementsByTagName("condition") select condition.InnerText).ToList();
                            InputsOutputs.Add(new OutputNumberMatchingConditions(conditions));
                            break;
                        case "OutputString":
                            InputsOutputs.Add(new OutputString(element.GetElementsByTagName("string")[0].InnerText));
                            break;
                        case "SettingsDeviation":
                            InputsOutputs.Add(new SettingsDeviation(Double.Parse(element.GetElementsByTagName("deviation")[0].InnerText)));
                            break;
                        case "SettingsProhibitedCommand":
                            InputsOutputs.Add(new SettingsProhibitedCommand((element.GetElementsByTagName("prohibitedCommand")[0].InnerText)));
                            break;
                        case "SettingsRequiedCommand":
                            InputsOutputs.Add(new SettingsRequiedCommand((element.GetElementsByTagName("requiedCommand")[0].InnerText)));
                            break;
                        case "ActionRepeatLast":
                            InputsOutputs.Add(new ActionRepeatLast(int.Parse(element.GetElementsByTagName("repetitions")[0].InnerText)));
                            break;
                    }
                }
            }
            else
                throw new FormatException();
        }
    }
}