using System;
using System.IO;
using System.Web;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Classes.Commands
{
    public class ReadLogFileCommand : ICommandWithResult<string>
    {
        private readonly IReadFileProcessor _readFileProcessor;

        public ReadLogFileCommand(IReadFileProcessor readFileProcessor)
        {
            _readFileProcessor = readFileProcessor ?? throw new ArgumentNullException(nameof(readFileProcessor));
        }

        public void Execute(object[] args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var filePath = GetFullPath(args[0].ToString());
            Result = _readFileProcessor.Read(filePath);
        }

        public string Result { get; private set; }

        private static string GetFullPath(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));

            return Path.Combine(HttpContext.Current.Server.MapPath("~/"), fileName);
        }
    }
}