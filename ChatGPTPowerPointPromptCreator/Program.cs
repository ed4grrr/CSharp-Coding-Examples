using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Path to the docx file

        
        string filePath = args[0];

        Thread.Sleep(1000);

        // Create a StringBuilder to store the extracted text
        StringBuilder sb = new StringBuilder();

        string fileName;

        // Open the docx file as a zip archive
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            using (ZipArchive archive = new ZipArchive(fs, ZipArchiveMode.Read))
            {
                // Find the document.xml part within the zip (where the main text is stored)
                ZipArchiveEntry entry = archive.GetEntry("word/document.xml");

                fileName = entry.Name;
                if (entry != null)
                {
                    using (Stream entryStream = entry.Open())
                    {
                        // Load the XML from document.xml
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(entryStream);

                        Console.WriteLine(xmlDoc.OuterXml + "\n");

                        // Extract all text nodes within the XML (word/document.xml)
                        XmlNodeList nodeList = xmlDoc.GetElementsByTagName("w:t");
                        foreach (XmlNode node in nodeList)
                        {
                            sb.Append(node.InnerText + "\n");
                            
                        }
                    }
                }
            }
        }

        Console.WriteLine(sb.ToString());



        // Output the extracted text or use sb as needed
        Console.WriteLine(sb.ToString());

        // Ensure that the "results" folder exists


        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Create a path to the "results" folder inside the base directory
        StringBuilder resultsFolder = new StringBuilder(baseDirectory  + $"Results\\{fileName.Replace(".xml","_")}");

        Console.WriteLine(resultsFolder);



        if (!Directory.Exists(resultsFolder.ToString()))
        {
            Directory.CreateDirectory(resultsFolder.ToString());
        }
        DateTime currentTime = DateTime.UtcNow;
        long unixTime = ((DateTimeOffset)currentTime).ToUnixTimeSeconds();
        StringBuilder filename = new StringBuilder(($"Module {args[1]}-{unixTime}"));

        SaveTextFile(sb, filename);



        //Console.ReadLine();
    }



    static void SaveTextFile(StringBuilder content, StringBuilder fileName)
    {
        // Get the base directory of the script (or executable)
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Define the path to the "Results" folder inside the base directory
        string resultsFolder = Path.Combine(baseDirectory, "Results");

        // Ensure that the "Results" folder exists, create if it doesn't
        if (!Directory.Exists(resultsFolder))
        {
            Directory.CreateDirectory(resultsFolder);
        }

        // Construct the full file path with the provided filename (add .txt extension)
        string outputFilePath = Path.Combine(resultsFolder, $"{fileName}.txt");

        // Write the content to the specified file
        File.WriteAllText(outputFilePath, content.ToString());

        // Optionally print a confirmation message
        Console.WriteLine($"File saved to: {outputFilePath}");
    }
}