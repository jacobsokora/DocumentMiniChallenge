using System;
using System.IO;

namespace Document
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Document");
            Console.Write("Enter the name of the document: ");
            string name = Console.ReadLine();
            Console.Write("Enter the content of the document: ");
            string content = Console.ReadLine();
            try 
            {
                StreamWriter streamWriter = new StreamWriter(name + ".txt");
                streamWriter.WriteLine(content);
                streamWriter.Close();
                Console.WriteLine("{0} was successfully saved. The document contains {1} characters.", name, content.Length);
            } 
            catch (Exception e) 
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        static void MainWithOptionalRequirements() 
        {
            bool go = true;
            while (go)
            {
                Console.WriteLine("Document");
                Console.Write("Enter the name of the document: ");
                string name = Console.ReadLine();
                Console.Write("Enter the content of the document: ");
                string content = Console.ReadLine();
                StreamWriter streamWriter = null;
                try
                {
                    if (!name.EndsWith(".txt"))
                    {
                        name += ".txt";
                    }
                    streamWriter = new StreamWriter(name);
                    streamWriter.WriteLine(content);
                    Console.WriteLine("{0} was successfully saved. The document contains {1} characters.", name, content.Length);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    if (streamWriter != null)
                    {
                        streamWriter.Close();
                    }
                }
                Console.Write("Would you like to save another document? (y/n): ");
                go = Console.ReadLine().ToLower().Equals("y");
            }
        }
    }
}
