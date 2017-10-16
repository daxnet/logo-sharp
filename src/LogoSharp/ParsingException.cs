using Irony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp
{
    public sealed class ParsingException : Exception
    {
        private readonly List<ParsingError> parsingErrors = new List<ParsingError>();

        public ParsingException(string message, IEnumerable<ParsingError> parsingErrors)
            : base(message)
        {
            this.parsingErrors.AddRange(parsingErrors);
        }

        public IEnumerable<ParsingError> ParsingErrors { get => this.parsingErrors; }
    }
}
