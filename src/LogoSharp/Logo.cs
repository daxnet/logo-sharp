using Irony;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp
{
    public sealed class Logo
    {
        private static readonly LanguageData language = new LanguageData(new LogoGrammar());
        private static readonly Parser parser = new Parser(language);

        public void Execute(string source)
        {
            var syntaxTree = parser.Parse(source);
            if (syntaxTree.HasErrors())
            {
                List<ParsingError> errors = new List<ParsingError>();
                foreach(var message in syntaxTree.ParserMessages)
                {
                    errors.Add(new ParsingError(message.Location.Position, message.Location.Column, message.Location.Line, message.Message));
                }

                throw new ParsingException("Source code parsing failed, see ParsingMessages for more details.", errors);
            }

            this.ParseTree(syntaxTree.Root);
        }

        private void ParseTree(ParseTreeNode node)
        {
            switch(node.Term.Name)
            {
                case "PROGRAM":
                    foreach (var child in node.ChildNodes)
                    {
                        this.ParseTree(child);
                    }
                    break;
            }
        }
    }
}
