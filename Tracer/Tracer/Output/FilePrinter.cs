using System;
using System.IO;

namespace App.Output
{
    class FilePrinter : IPrinter
    {
        private readonly string _filePath;

        public FilePrinter(string filePath)
        {
            _filePath = filePath;
        }

        public void PrintResult(string data)
        {
            try
            {
                using (var fstream = new FileStream(_filePath, FileMode.OpenOrCreate))
                {
                    var array = System.Text.Encoding.Default.GetBytes(data);
                    fstream.Write(array, 0, array.Length);
                }
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}