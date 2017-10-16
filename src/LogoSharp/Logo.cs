using Irony;
using Irony.Parsing;
using LogoSharp.EventArguments;
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

        public event EventHandler<TurnLeftEventArgs> TurnLeft;
        public event EventHandler<TurnRightEventArgs> TurnRight;
        public event EventHandler<ForwardEventArgs> Forward;
        public event EventHandler<BackwardEventArgs> Backward;
        public event EventHandler<PenColorEventArgs> SetPenColor;
        public event EventHandler PenUp;
        public event EventHandler PenDown;

        public void Execute(string source)
        {
            var syntaxTree = parser.Parse(source);
            if (syntaxTree.HasErrors())
            {
                List<ParsingError> errors = new List<ParsingError>();
                foreach (var message in syntaxTree.ParserMessages)
                {
                    errors.Add(new ParsingError(message.Location.Position, message.Location.Column, message.Location.Line, message.Message));
                }

                throw new ParsingException("Source code parsing failed, see ParsingMessages for more details.", errors);
            }

            this.ParseTree(syntaxTree.Root);
        }

        private void ParseTree(ParseTreeNode node)
        {
            switch (node.Term.Name)
            {
                case "PROGRAM":
                    foreach (var child in node.ChildNodes)
                    {
                        this.ParseTree(child);
                    }
                    break;
                case "DRAWING_COMMAND":
                    this.ParseDrawingCommand(node);
                    break;
                case "PEN_COMMAND":
                    this.ParsePenCommand(node);
                    break;
            }
        }

        private void ParseDrawingCommand(ParseTreeNode node)
        {
            var commandNode = node.ChildNodes[0];
            var commandParameterNode = node.ChildNodes[1];
            var parameter = Convert.ToSingle(commandParameterNode.Token.Value);

            switch (commandNode.Term.Name)
            {
                case "LEFT":
                    this.OnTurnLeft(new TurnLeftEventArgs(parameter));
                    break;
                case "RIGHT":
                    this.OnTurnRight(new TurnRightEventArgs(parameter));
                    break;
                case "FORWARD":
                    this.OnForward(new ForwardEventArgs(parameter));
                    break;
                case "BACKWARD":
                    this.OnBackward(new BackwardEventArgs(parameter));
                    break;
            }
        }

        private void ParsePenCommand(ParseTreeNode node)
        {
            var commandNode = node.ChildNodes[0];
            switch (commandNode.Term.Name)
            {
                case "PEN_UP":
                    this.OnPenUp(EventArgs.Empty);
                    break;
                case "PEN_DOWN":
                    this.OnPenDown(EventArgs.Empty);
                    break;
                case "SET_PEN_COLOR":
                    List<float> rgb = new List<float>();
                    ParseTupleArgs(commandNode.ChildNodes[1], rgb);
                    if (rgb.Count != 3)
                    {
                        throw new ParsingException("Incorrect command invocation.", new[]
                        {
                            new ParsingError(node.Span.Location.Position, node.Span.Location.Column, node.Span.Location.Line, $"The number of arguments must be 3, instead of {rgb.Count}.")
                        });
                    }

                    this.OnSetPenColor(new PenColorEventArgs(Convert.ToInt32(rgb[0]), Convert.ToInt32(rgb[1]), Convert.ToInt32(rgb[2])));
                    break;
            }
        }

        private void ParseTupleArgs(ParseTreeNode tupleArgs, List<float> result)
        {
            foreach (var child in tupleArgs.ChildNodes)
            {
                if (child.Term.Name == "TUPLE")
                {
                    ParseTupleArgs(child, result);
                }
                else
                {
                    result.Add(Convert.ToSingle(child.Token.Value));
                }
            }
        }

        private void OnTurnLeft(TurnLeftEventArgs e)
        {
            this.TurnLeft?.Invoke(this, e);
        }

        private void OnTurnRight(TurnRightEventArgs e)
        {
            this.TurnRight?.Invoke(this, e);
        }

        private void OnForward(ForwardEventArgs e)
        {
            this.Forward?.Invoke(this, e);
        }

        private void OnBackward(BackwardEventArgs e)
        {
            this.Backward?.Invoke(this, e);
        }

        private void OnPenUp(EventArgs e)
        {
            this.PenUp?.Invoke(this, e);
        }

        private void OnPenDown(EventArgs e)
        {
            this.PenDown?.Invoke(this, e);
        }

        private void OnSetPenColor(PenColorEventArgs e)
        {
            this.SetPenColor?.Invoke(this, e);
        }
    }
}
