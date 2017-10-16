using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp
{
    public sealed class ParsingError
    {
        public ParsingError(int position, int column, int line, string message)
        {
            this.Position = position;
            this.Column = column;
            this.Line = line;
            this.Message = message;
        }

        public int Position { get; }

        public int Column { get; }

        public int Line { get; }

        public string Message { get; }

        public override string ToString()
        {
            return $"(Pos: {Position}, Line: {Line}, Col: {Column}) - {Message}";
        }
    }
}
