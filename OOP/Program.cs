using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOP.Program;

namespace OOP
{
    public class Program
    {
        public class Vehicle
        {
            public string Make { get; set; }
            public int Year { get; set; }
            public string Type { get; set; }
            public string Model { get; set; }
            public string PalletNo { get; set; }
            public string Color { get; set; }

            public Vehicle(string make, int year, string type, string model, string palletNo, string color)
            {
                Make = make;
                Year = year;
                Type = type;
                Model = model;
                PalletNo = palletNo;
                Color = color;
            }

            public string GetDetails()
            {
                return $"Make: {Make}, Year: {Year}, Type: {Type}, Model: {Model}, Pallet No: {PalletNo}, Color: {Color}";
            }
        }
        public class Car : Vehicle
        {
            public Car(string make, int year, string type, string model, string palletNo, string color)
                : base(make, year, type, model, palletNo, color)
            {

            }

            public void StartEngine()
            {
                Console.WriteLine("Engine started.");
            }

            public void StopEngine()
            {
                Console.WriteLine("Engine stopped.");
            }

        }
        public static void ReadAndWrite(string fileToRead, string fileToWrite)
        {
            int noOfChar = 0;
            int noOfWords = 0;
            try
            {
                using (StreamReader reader = new StreamReader(fileToRead))
                {
                    using (StreamWriter writer = new StreamWriter(fileToWrite))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            writer.WriteLine(line);

                            int lineTotalCharacters = line.Count(char.IsLetterOrDigit);
                            noOfChar += lineTotalCharacters;

                            int lineTotalWords = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Length;
                            noOfWords += lineTotalWords;
                        }
                    }
                }
                Console.WriteLine($"Total characters (excluding spaces): {noOfChar}");
                Console.WriteLine($"Total words (excluding spaces): {noOfWords}");


            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void Main(string[] args)
        {
            Car myCar = new Car("Toyota", 2023, "Sedan", "Camry", "ABC123", "Blue");

            Console.WriteLine(myCar.GetDetails());

            myCar.StartEngine();
            myCar.StopEngine();
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////");

            string fileToRead = "C:\\Users\\HP\\OneDrive - Hashemite University\\Desktop\\Orange Coding School\\C#\\last OOP\\OOPFlastTopics\\info.txt";
            string fileToWrite = "C:\\Users\\HP\\OneDrive - Hashemite University\\Desktop\\Orange Coding School\\C#\\last OOP\\OOPFlastTopics\\info - Copy.txt";

            ReadAndWrite (fileToRead, fileToWrite);
        }
    }
}

