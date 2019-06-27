using Irony;
using Irony.Parsing;
using LogoSharp.Evaluations;
using LogoSharp.Evaluations.Functions;
using LogoSharp.EventArguments;
using LogoSharp.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp
{
    public sealed class Logo
    {
        #region Private Fields

        private static readonly Stack<ProcedureScope> procedureScopes = new Stack<ProcedureScope>();
        private static readonly Stack<RepeatScope> repeatScopes = new Stack<RepeatScope>();
        private static readonly List<Procedure> procedures = new List<Procedure>();
        private static readonly LanguageData language = new LanguageData(new LogoGrammar());
        private static readonly Parser parser = new Parser(language);
        private static readonly Dictionary<int, Tuple<int, int, int>> colorTable = new Dictionary<int, Tuple<int, int, int>>
        {
            { 0, new Tuple<int, int, int>(0, 0, 0) },
            { 1, new Tuple<int, int, int>(0, 0, 255) },
            { 2, new Tuple<int, int, int>(0, 255, 0) },
            { 3, new Tuple<int, int, int>(0, 2255, 255) },
            { 4, new Tuple<int, int, int>(255, 0, 0) },
            { 5, new Tuple<int, int, int>(255, 0, 255) },
            { 6, new Tuple<int, int, int>(255, 255, 0) },
            { 7, new Tuple<int, int, int>(255, 255, 255) },
            { 8, new Tuple<int, int, int>(155, 96, 59) },
            { 9, new Tuple<int, int, int>(197,136, 18) },
            { 10, new Tuple<int, int, int>(100, 162, 64) },
            { 11, new Tuple<int, int, int>(120, 187, 187) },
            { 12, new Tuple<int, int, int>(255, 149, 119) },
            { 13, new Tuple<int, int, int>(144, 113, 208) },
            { 14, new Tuple<int, int, int>(255, 163, 0) },
            { 15, new Tuple<int, int, int>(183, 183, 183) }
        };

        #endregion Private Fields

        #region Public Events

        public event EventHandler<BackwardEventArgs> Backward;

        public event EventHandler ClearScreen;

        public event EventHandler<DelayEventArgs> Delay;

        public event EventHandler<ForwardEventArgs> Forward;

        public event EventHandler GoHome;

        public event EventHandler HideTurtle;

        public event EventHandler PenDown;

        public event EventHandler PenUp;

        public event EventHandler<PenColorEventArgs> SetPenColor;

        public event EventHandler ShowTurtle;

        public event EventHandler<TurnLeftEventArgs> TurnLeft;

        public event EventHandler<TurnRightEventArgs> TurnRight;

        #endregion Public Events

        #region Public Methods

        public void Execute(string source)
        {
            procedureScopes.Clear();
            procedures.Clear();

            procedureScopes.Push(new ProcedureScope("Root"));

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

        public void OnHideTurtle(EventArgs e) => this.HideTurtle?.Invoke(this, e);

        public void OnShowTurtle(EventArgs e) => this.ShowTurtle?.Invoke(this, e);

        public void ParseBasicControlCommand(ParseTreeNode node)
        {
            var commandNode = node.ChildNodes[0];
            switch (commandNode.Term.Name)
            {
                case "HOME":
                    this.OnGoHome(EventArgs.Empty);
                    break;
                case "SHOWTURTLE":
                    this.OnShowTurtle(EventArgs.Empty);
                    break;
                case "HIDETURTLE":
                    this.OnHideTurtle(EventArgs.Empty);
                    break;
            }
        }

        #endregion Public Methods

        #region Private Methods

        private ProcedureScope CurrentProcedureScope => procedureScopes.Peek();

        private RepeatScope CurrentRepeatScope => repeatScopes.Count > 0 ? repeatScopes.Peek() : null;

        private Evaluation EvaluateArithmeticExpression(ParseTreeNode expression)
        {
            switch (expression.Term.Name)
            {
                case "EXPRESSION":
                    return EvaluateArithmeticExpression(expression.ChildNodes[0]);

                case "VARIABLE":
                    var variableName = expression.ChildNodes[1].Token.Text;
                    if (!CurrentProcedureScope.Exists(variableName))
                    {
                        throw new ParsingException("Variable has not been defined.", new[] { ParsingError.FromParseTreeNode(expression, $"The requested parameter '{variableName}' is not defined.") });
                    }

                    return new ConstantEvaluation(Convert.ToSingle(CurrentProcedureScope[variableName]));

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

                case "REP_COUNT":
                    if (CurrentRepeatScope != null)
                    {
                        return new ConstantEvaluation(CurrentRepeatScope.RepCount);
                    }

                    throw new ParsingException("Variable repCount doesn't have a valid value.", new[] { ParsingError.FromParseTreeNode(expression, "Reference to repCount variable is not in a valid REPEAT scope.") });

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

        private void OnBackward(BackwardEventArgs e)
        {
            this.Backward?.Invoke(this, e);
        }

        private void OnClearScreen(EventArgs e)
        {
            this.ClearScreen?.Invoke(this, e);
        }

        private void OnDelay(DelayEventArgs e)
        {
            this.Delay?.Invoke(this, e);
        }

        private void OnForward(ForwardEventArgs e)
        {
            this.Forward?.Invoke(this, e);
        }

        private void OnGoHome(EventArgs e)
        {
            this.GoHome?.Invoke(this, e);
        }

        private void OnPenDown(EventArgs e)
        {
            this.PenDown?.Invoke(this, e);
        }

        private void OnPenUp(EventArgs e)
        {
            this.PenUp?.Invoke(this, e);
        }

        private void OnSetPenColor(PenColorEventArgs e)
        {
            this.SetPenColor?.Invoke(this, e);
        }

        private void OnTurnLeft(TurnLeftEventArgs e)
        {
            this.TurnLeft?.Invoke(this, e);
        }

        private void OnTurnRight(TurnRightEventArgs e)
        {
            this.TurnRight?.Invoke(this, e);
        }

        private void ParseAssignment(ParseTreeNode assignmentNode)
        {
            var variable = assignmentNode.ChildNodes[1].ChildNodes[1].Token.Text;
            var expressionNode = assignmentNode.ChildNodes[2];
            var expression = EvaluateArithmeticExpression(expressionNode);
            CurrentProcedureScope[variable] = expression.Value;
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
                    switch (commandNode.ChildNodes[1].Term.Name)
                    {
                        case "TUPLE":
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
                        case "EXPRESSION":
                            var evaluation = this.EvaluateArithmeticExpression(commandNode.ChildNodes[1]);
                            var colorIndex = Convert.ToInt32(evaluation.Value) % 16;
                            var colorValue = colorTable[colorIndex];
                            this.OnSetPenColor(new PenColorEventArgs(colorValue.Item1, colorValue.Item2, colorValue.Item3));
                            break;
                    }

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
            repeatScopes.Push(new RepeatScope(Guid.NewGuid().ToString()));
            for (var i = 0; i < repeatCount; i++)
            {
                CurrentRepeatScope.RepCount = i + 1;
                foreach (var childNode in repeatNode.ChildNodes[2].ChildNodes)
                {
                    this.ParseTree(childNode);
                }
            }

            repeatScopes.Pop();
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
                case "PROCEDURE":
                    this.ParseProcedure(node);
                    break;
                case "PROCEDURE_BODY":
                    foreach (var child in node.ChildNodes)
                    {
                        this.ParseTree(child);
                    }
                    break;
                case "DRAWING_COMMAND":
                    this.ParseDrawingCommand(node);
                    break;
                case "BASIC_CONTROL_COMMAND":
                    this.ParseBasicControlCommand(node);
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
                case "PROCEDURE_CALL":
                    this.ParseProcedureCall(node);
                    break;
            }
        }

        private void ParseProcedure(ParseTreeNode procedureNode)
        {
            var name = procedureNode.ChildNodes[0].ChildNodes[1].Token.Text;
            var bodyNode = procedureNode.ChildNodes[1];
            procedures.Add(new Procedure(name, bodyNode));
        }

        private void ParseProcedureCall(ParseTreeNode procedureNode)
        {
            var callingProcedureName = procedureNode.ChildNodes[0].Token.Text;
            var procedure = procedures.FirstOrDefault(x => string.Equals(callingProcedureName, x.Name, StringComparison.InvariantCultureIgnoreCase));
            if (procedure != null)
            {
                procedureScopes.Push(new ProcedureScope(callingProcedureName));
                ParseTree(procedure.Body);
                procedureScopes.Pop();
            }
            else
            {
                throw new RuntimeException($"The calling procedure {callingProcedureName} is not defined.");
            }
        }

        private void ParseTupleValues(ParseTreeNode tupleNode, List<float> result)
        {
            foreach (var child in tupleNode.ChildNodes)
            {
                result.Add(EvaluateArithmeticExpression(child).Value);
            }
        }

        #endregion Private Methods
    }
}
