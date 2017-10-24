﻿using Irony;
using Irony.Parsing;
using LogoSharp.Evaluations;
using LogoSharp.Evaluations.Functions;
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
        private static readonly Dictionary<string, object> variables = new Dictionary<string, object>();

        public event EventHandler<TurnLeftEventArgs> TurnLeft;
        public event EventHandler<TurnRightEventArgs> TurnRight;
        public event EventHandler<ForwardEventArgs> Forward;
        public event EventHandler<BackwardEventArgs> Backward;
        public event EventHandler<PenColorEventArgs> SetPenColor;
        public event EventHandler<DelayEventArgs> Delay;
        public event EventHandler PenUp;
        public event EventHandler PenDown;
        public event EventHandler ClearScreen;

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
                case "REPEAT_COMMAND":
                    this.ParseRepeatCommand(node);
                    break;
                case "ASSIGNMENT":
                    this.ParseAssignment(node);
                    break;
            }
        }

        private void ParseDrawingCommand(ParseTreeNode node)
        {
            var commandNode = node.ChildNodes[0];
            ParseTreeNode parameterNode = null;
            var evaluatedValue = 0F;
            if (node.ChildNodes.Count > 1)
            {
                parameterNode = node.ChildNodes[1];
                evaluatedValue = EvaluateArithmeticExpression(parameterNode).Value;
            }

            switch (commandNode.Term.Name)
            {
                case "LEFT":
                    this.OnTurnLeft(new TurnLeftEventArgs(evaluatedValue));
                    break;
                case "RIGHT":
                    this.OnTurnRight(new TurnRightEventArgs(evaluatedValue));
                    break;
                case "FORWARD":
                    this.OnForward(new ForwardEventArgs(evaluatedValue));
                    break;
                case "BACKWARD":
                    this.OnBackward(new BackwardEventArgs(evaluatedValue));
                    break;
                case "DELAY":
                    this.OnDelay(new DelayEventArgs(Convert.ToInt32(evaluatedValue)));
                    break;
                case "DRAW":
                    this.OnClearScreen(EventArgs.Empty);
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
                    var rgb = new List<float>();
                    ParseTupleValues(commandNode.ChildNodes[1], rgb);
                    if (rgb.Count != 3)
                    {
                        throw new ParsingException("Incorrect command invocation.", new[]
                        {
                            ParsingError.FromParseTreeNode(node, $"The number of arguments must be 3, instead of {rgb.Count}.")
                        });
                    }

                    if (rgb.Any(v => v < 0 || v > 255))
                    {
                        throw new ParsingException("Command parameters are out of range.", new[]
                        {
                            ParsingError.FromParseTreeNode(node, "The parameter value should be greater than or equal to 0 and less than or equal to 255.")
                        });
                    }

                    this.OnSetPenColor(new PenColorEventArgs(Convert.ToInt32(rgb[0]), Convert.ToInt32(rgb[1]), Convert.ToInt32(rgb[2])));
                    break;
            }
        }

        private void ParseRepeatCommand(ParseTreeNode repeatNode)
        {
            if (repeatNode.ChildNodes[2]?.ChildNodes?.Count == 0)
            {
                return;
            }

            var repeatCount = Convert.ToInt32(EvaluateArithmeticExpression(repeatNode.ChildNodes[1]).Value);
            for (var i = 0; i < repeatCount; i++)
            {
                foreach (var childNode in repeatNode.ChildNodes[2].ChildNodes)
                {
                    this.ParseTree(childNode);
                }
            }
        }

        private void ParseAssignment(ParseTreeNode assignmentNode)
        {
            var variable = assignmentNode.ChildNodes[0].Token.Text;
            var expressionNode = assignmentNode.ChildNodes[2];
            var expression = EvaluateArithmeticExpression(expressionNode);
            if (variables.Any(kvp => kvp.Key.Equals(variable, StringComparison.InvariantCultureIgnoreCase)))
            {
                variables[variable] = expression.Value;
            }
            else
            {
                variables.Add(variable, expression.Value);
            }
        }

        private void ParseTupleValues(ParseTreeNode tupleNode, List<float> result)
        {
            foreach (var child in tupleNode.ChildNodes)
            {
                result.Add(Convert.ToSingle(child.Token.Value));
            }
        }

        private Evaluation EvaluateArithmeticExpression(ParseTreeNode expression)
        {
            switch (expression.Term.Name)
            {
                case "IDENTIFIER":
                    var variableName = expression.Token.Text;
                    if (!variables.Any(kvp => kvp.Key.Equals(variableName, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        throw new ParsingException("Variable has not been defined.", new[] { ParsingError.FromParseTreeNode(expression, $"The requested parameter '{variableName}' is not defined.") });
                    }

                    return new ConstantEvaluation(Convert.ToSingle(variables.First(kvp => kvp.Key.Equals(variableName)).Value));
                case "BINARY_EXPRESSION":
                    var leftNode = expression.ChildNodes[0];
                    var operatorNode = expression.ChildNodes[1];
                    var rightNode = expression.ChildNodes[2];
                    var leftEvaluation = EvaluateArithmeticExpression(leftNode);
                    var rightEvaluation = EvaluateArithmeticExpression(rightNode);
                    var binaryOperation = BinaryOperation.Add;
                    switch (operatorNode.Term.Name)
                    {
                        case "+":
                            binaryOperation = BinaryOperation.Add;
                            break;
                        case "-":
                            binaryOperation = BinaryOperation.Sub;
                            break;
                        case "*":
                            binaryOperation = BinaryOperation.Mul;
                            break;
                        case "/":
                            binaryOperation = BinaryOperation.Div;
                            break;
                    }
                    return new BinaryEvaluation(leftEvaluation, rightEvaluation, binaryOperation);
                case "FUNCTION_CALL":
                    var funcName = expression.ChildNodes[0].Token.Text;
                    var funcParameters = new List<float>();
                    if (expression.ChildNodes.Count > 1)
                    {
                        var functionArgsNode = expression.ChildNodes[1];
                        for (var idx = 0; idx < functionArgsNode.ChildNodes.Count; idx++)
                        {
                            funcParameters.Add(EvaluateArithmeticExpression(functionArgsNode.ChildNodes[idx]).Value);
                        }
                    }
                    return FunctionRegistry.Call(expression, funcName, funcParameters);
                default:
                    return new ConstantEvaluation(Convert.ToSingle(expression.Token.Text));
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

        private void OnDelay(DelayEventArgs e)
        {
            this.Delay?.Invoke(this, e);
        }

        private void OnClearScreen(EventArgs e)
        {
            this.ClearScreen?.Invoke(this, e);
        }
    }
}
