using System;
using System.IO;
using System.Text;
using SumOfNumbers.Infastructure;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Classes.Processors
{
    public class ReadFileProcessor : IReadFileProcessor
    {
        public string Read(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));

            return ReadFile(path);
        }

        private static string ReadFile(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));

            if (!File.Exists(path))
                return string.Empty;

            var stringBuilder = new StringBuilder();
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.Default))
                {
                    string line;

                    while ((line = streamReader.ReadLine()) != null)
                        stringBuilder.Append(line + Environment.NewLine);
                }
            }

            return stringBuilder.ToString();
        }
    }
}