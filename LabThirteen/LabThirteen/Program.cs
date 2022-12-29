using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LabThirteen
{
    class Program
    {
        static void Main()
        {
            Circle circle = new Circle(10);

            //BIN
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            using (FileStream binarySerializerStream = new FileStream(@"D:\OOP\OOP\LabThirteen\LabThirteen\Binary.bin", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(binarySerializerStream, circle);
            }

            using (FileStream binaryDeserializer = new FileStream(@"D:\OOP\OOP\LabThirteen\LabThirteen\Binary.bin", FileMode.OpenOrCreate))
            {
                Circle binaryDeserialized = (Circle)binaryFormatter.Deserialize(binaryDeserializer);
                Console.WriteLine($"BIN Circle radius: {binaryDeserialized.Radius}");
            }

            //SOAP
            SoapFormatter soapFormatter = new SoapFormatter();

            using (FileStream soapSerializer = new FileStream(@"D:\OOP\OOP\LabThirteen\LabThirteen\SOAP.xml", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(soapSerializer, circle);
            }

            using (FileStream soapDeserializer = new FileStream(@"D:\OOP\OOP\LabThirteen\LabThirteen\SOAP.xml", FileMode.OpenOrCreate))
            {
                Circle soapDeserialized = (Circle)soapFormatter.Deserialize(soapDeserializer);
                Console.WriteLine($"SOAP Circle radius: {soapDeserialized.Radius}");
            }

            //JSON
            string filePath = @"D:\OOP\OOP\LabThirteen\LabThirteen\JSON.json";
            string jsonFormat = JsonConvert.SerializeObject(circle);
            File.WriteAllText(filePath, jsonFormat);

            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists && fileInfo.Length != 0)
            {
                string json = File.ReadAllText(filePath);
                Circle obj = JsonConvert.DeserializeObject<Circle>(json);
                Console.WriteLine("JSON Circle radius: " + obj.Radius);
            }

            //XML
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Circle));

            using (FileStream xmlSerializerStream = new FileStream(@"D:\OOP\OOP\LabThirteen\LabThirteen\XML.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(xmlSerializerStream, circle);
            }

            using (FileStream xmlDeserializerStream = new FileStream(@"D:\OOP\OOP\LabThirteen\LabThirteen\XML.xml", FileMode.OpenOrCreate))
            {
                Circle xmlDeserialized = xmlSerializer.Deserialize(xmlDeserializerStream) as Circle;
                Console.WriteLine($"XML Circle radius: {xmlDeserialized.Radius}\n\n");
            }

            //Second task
            Circle circle1 = new Circle(9);
            Circle circle2 = new Circle(8);
            Circle[] circles = { circle, circle1, circle2 };

            DataContractJsonSerializer jsonArraySerializer = new DataContractJsonSerializer(typeof(Circle[]));

            using (FileStream jsonStream = new FileStream(@"D:\OOP\OOP\LabThirteen\LabThirteen\JsonArray.json", FileMode.OpenOrCreate))
            {
                jsonArraySerializer.WriteObject(jsonStream, circles);
            }

            using (FileStream jsonDeserializerStream = new FileStream(@"D:\OOP\OOP\LabThirteen\LabThirteen\JsonArray.json", FileMode.OpenOrCreate))
            {
                Circle[] jsonDeserialized = (Circle[])jsonArraySerializer.ReadObject(jsonDeserializerStream);
                foreach (var item in jsonDeserialized)
                {
                    Console.WriteLine($"Circle radius: {item.Radius}");
                }
            }

            //Third task
            XmlDocument newDocument = new XmlDocument();
            newDocument.Load(@"D:\OOP\OOP\LabThirteen\LabThirteen\XML.xml");
            XmlElement root = newDocument.DocumentElement;
            XmlNodeList nodes = root?.SelectNodes("*");
            Console.WriteLine("\nNodes in XML:");
            if (nodes != null)
            {
                foreach (XmlNode node in nodes)
                {
                    Console.WriteLine(node.Name);
                }
            }
            else
            {
                Console.WriteLine("Empty nodes...");
            }

            Console.WriteLine("\nЧто находится в теге Radius:");
            XmlNodeList nameOfThePrintPublicationNodes = root?.SelectNodes("Radius");
            if (nameOfThePrintPublicationNodes != null)
            {
                foreach (XmlNode node in nameOfThePrintPublicationNodes)
                {
                    Console.WriteLine(node.InnerText);
                }
            }
            else
            {
                Console.WriteLine("Empty nodes...");
            }

            //Task 4
            XDocument xDocument = new XDocument();
            XElement rootElement = new XElement("Figures");

            //figure1
            XElement figure1 = new XElement("Figure");
            XElement figure1Name = new XElement("Name", "Circle1");
            XElement figure1Radius = new XElement("Radius", 7);
            figure1.Add(figure1Name);
            figure1.Add(figure1Radius);

            //figure2
            XElement figure2 = new XElement("Figure");
            XElement figure2Name = new XElement("Name", "Circle2");
            XElement figure2Radius = new XElement("Radius", 19);
            figure2.Add(figure2Name);
            figure2.Add(figure2Radius);

            //figure3
            XElement figure3 = new XElement("Figure");
            XElement figure3Name = new XElement("Name", "Circle3");
            XElement figure3Radius = new XElement("Radius", 25.6);
            figure3.Add(figure3Name);
            figure3.Add(figure3Radius);

            rootElement.Add(figure1);
            rootElement.Add(figure2);
            rootElement.Add(figure3);

            xDocument.Add(rootElement);
            xDocument.Save(@"D:\OOP\OOP\LabThirteen\LabThirteen\LinqToXML.xml");

            XDocument documentForQueries = XDocument.Load(@"D:\OOP\OOP\LabThirteen\LabThirteen\LinqToXML.xml");
            Console.WriteLine("\nCircles with Radius > 10:\n");

            var radiusGreaterThanTen = documentForQueries.Element("Figures")
                                        .Elements("Figure")
                                        .Where(figure => Convert.ToDouble(figure.Element("Radius").Value) > 10)
                                        .Select(figure => new
                                        {
                                            Name = figure.Element("Name")?.Value,
                                            Radius = figure.Element("Radius")?.Value
                                        }
            );

            foreach (var figure in radiusGreaterThanTen)
            {
                Console.WriteLine($"Figure: {figure.Name}\nRadius: {figure.Radius}\n-----");
            }
        }
    }
}
