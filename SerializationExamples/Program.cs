using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization.Json;
using SerializationExamples.BinaryFormat;
using SerializationExamples.CustomFormat;
using SerializationExamples.JSONOld;
using SerializationExamples.JSONTextFormat;

namespace SerializationExamples
{
    class Program
    {
        static void SaveAsBinaryFormat(object objGraph, string fileName)
        {
            // Save object to a file named CarData.dat in binary
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
            //Console.WriteLine("=> Saved car in binary format!");
        }
        static JamesBondCar LoadFromBinaryFile(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            // Read the JamesBondCar from the binary file.
            Stream fStream = File.OpenRead(fileName);
            JamesBondCar carFromDisk = (JamesBondCar)binFormat.Deserialize(fStream);
            fStream.Close();
            // Console.WriteLine("Can this car fly? : {0}", carFromDisk.CanFly);
            return carFromDisk;
        }
        static void SaveAsSoapFormat(object objGraph, string fileName)
        {
            // Save object to a file named CarData.soap in SOAP format.
            SoapFormatter soapFormat = new SoapFormatter();
            using (Stream fStream = new FileStream(fileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fStream, objGraph);
            }
            //Console.WriteLine("=> Saved car in SOAP format!");
        }
        static JamesBondCar LoadFromSoapFile(string fileName)
        {
            SoapFormatter soapFormat = new SoapFormatter();
            Stream fStream = File.OpenRead(fileName);
            JamesBondCar carFromDisk = (JamesBondCar)soapFormat.Deserialize(fStream);
            fStream.Close();
            return carFromDisk;
        }
        static void SaveAsXmlFormat(object objGraph, string fileName)
        {
            // Save object to a file named CarData.xml in XML format.
            XmlSerializer xmlFormat = new XmlSerializer(typeof(JamesBondCar));
            using (Stream fStream = new FileStream(fileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, objGraph);
            }
           // Console.WriteLine("=> Saved car in XML format!");
        }
        static JamesBondCar LoadFromXmlFormat(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(JamesBondCar));
            Stream fStream = File.OpenRead(fileName);
            JamesBondCar carFromDisk = (JamesBondCar)xmlFormat.Deserialize(fStream);
            fStream.Close();
            return carFromDisk;
            // Console.WriteLine("=> Saved car in XML format!");
        }


        static void Main(string[] args)
        {
            #region Binary Serialization

            UserPrefs userData = new UserPrefs();
            userData.WindowColor = "Yellow";
            userData.FontSize = 50;

            // The BinaryFormatter persists state data in a binary format.
            BinaryFormatter binFormat = new BinaryFormatter();

            // Store object in a local file
            Stream fStream = new FileStream("user.dat",
                FileMode.Create, FileAccess.Write, FileShare.None);
            binFormat.Serialize(fStream, userData);
            fStream.Close();

            //serialization
            MyClass obj = new MyClass();

            obj.N1 = 100;
            obj.N2 = 250;
            obj.Str1 = "This string will be serialized";
            obj.Str2 = "This string will be lost soon";

            IFormatter formatter1 = new BinaryFormatter();

            Stream fStream2 = new FileStream("MyFile.bin",
                FileMode.Create, FileAccess.Write, FileShare.None);
            formatter1.Serialize(fStream2, obj);
            fStream2.Close();

            //deserialization
            IFormatter formatter2 = new BinaryFormatter();

            Stream fStream3 = new FileStream("MyFile.bin",
                FileMode.Open, FileAccess.Read, FileShare.Read);
            MyClass obj2 = (MyClass)formatter2.Deserialize(fStream3);
            fStream3.Close();

            //deserialization
            IFormatter formatter3 = new BinaryFormatter();

            Stream fStream4 = new FileStream("user.dat",
                FileMode.Open, FileAccess.Read, FileShare.Read);
            UserPrefs userData2 = (UserPrefs)formatter3.Deserialize(fStream4);
            fStream4.Close();

            Console.WriteLine(obj2);
            Console.WriteLine(userData2);

            // ----
            // Make a JamesBondCar and set state
            JamesBondCar jbc = new JamesBondCar();
            jbc.CanFly = true;
            jbc.CanSubmerge = false;
            jbc.TheRadio.StationPresets = new double[] { 89.3, 105.1, 97.1 };
            jbc.TheRadio.HasTweeters = true;

            // Now save the car to a specific file in a binary format
            SaveAsBinaryFormat(jbc, "CarData.dat");
            //Now load the car data from the file
            JamesBondCar jbc2 = LoadFromBinaryFile("CarData.dat");

            Console.WriteLine(jbc2);
            #endregion

            #region SOAP serialization
            SaveAsSoapFormat(jbc, "CarData.soap");
            JamesBondCar jbc3 = LoadFromSoapFile("CarData.soap");
            Console.WriteLine(jbc3);

            #endregion

            #region XMLSerialization
            SaveAsXmlFormat(jbc,"CarData.xml");
            JamesBondCar jbc4 = LoadFromXmlFormat("CarData.xml");
            Console.WriteLine(jbc4);

            #endregion

            #region New JSON serialization
            var options = new JsonSerializerOptions
            {
                IgnoreReadOnlyProperties = false,
                IgnoreNullValues = true,
                WriteIndented = true,
            };
            WeatherForecast weatherForecast = new WeatherForecast();
            weatherForecast.Summary = "Sunny day";
            weatherForecast.TemperatureCelsius = 25;
            weatherForecast.X = 5;
            string jsonString = JsonSerializer.Serialize(weatherForecast);
            Console.WriteLine(jsonString);
            File.WriteAllText("temps.json", jsonString);
            #endregion

            #region CustomSerialization

            StringData myData = new StringData();
            // Save to a local file in Binary format.
            IFormatter customFormat = new BinaryFormatter();
            Stream fS5 = new FileStream("SData.dat",
                FileMode.Create, FileAccess.Write, FileShare.None);

            customFormat.Serialize(fS5, myData);

            fS5.Close();

            //deserialization
            IFormatter f6 = new BinaryFormatter();

            Stream fS6 = new FileStream("SData.dat",
                FileMode.Open, FileAccess.Read, FileShare.Read);
            StringData userData6 = (StringData)f6.Deserialize(fS6);
            fS6.Close();

            #endregion

            #region JSON Old serialization
            HighLowTemps cold = new HighLowTemps();
            cold.High = 15;
            cold.Low = -10;
            HighLowTemps hot = new HighLowTemps();
            hot.High = 42;
            hot.Low = 20;
            WeatherForecastWithPocos wfp = new WeatherForecastWithPocos();
            wfp.Date = DateTimeOffset.Now;
            wfp.TemperatureCelsius = 25;
            wfp.Summary = "Sunny";
            wfp.DatesAvailable = new List<DateTimeOffset>();
            wfp.DatesAvailable.Add(DateTimeOffset.Parse("2019-08-01T00:00:00-07:00"));
            wfp.DatesAvailable.Add(DateTimeOffset.Parse("2019-08-02T00:00:00-07:00"));
            wfp.TemperatureRanges = new Dictionary<string, HighLowTemps>();
            wfp.TemperatureRanges.Add("Cold", cold);
            wfp.TemperatureRanges.Add("Hot", hot);
            wfp.SummaryWords = new string[]{
                "Cool",
                "Windy",
                "Humid"
            };

            //serialize
            var stream1 = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(WeatherForecastWithPocos));
            ser.WriteObject(stream1, wfp);

            stream1.Position = 0;
            var sr = new StreamReader(stream1);
            Console.Write("JSON form of WeatherForeCastWithPocos object: ");
            Console.WriteLine(sr.ReadToEnd());

            //deserialize
            stream1.Position = 0;
            var p2 = (WeatherForecastWithPocos)ser.ReadObject(stream1);
            Console.WriteLine($"Deserialized back, got summary={wfp.Summary}, temperature={wfp.TemperatureCelsius}");
            Console.WriteLine(wfp);
            #endregion
            Console.ReadLine();
        }
    }
}
