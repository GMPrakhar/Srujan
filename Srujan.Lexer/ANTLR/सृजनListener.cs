//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:/Users/plondhe/Repos/Srujan/Srujan.Lexer/ANTLR/सृजन.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="सृजनParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface IसृजनListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="सृजनParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] सृजनParser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="सृजनParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] सृजनParser.ProgramContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="सृजनParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] सृजनParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="सृजनParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] सृजनParser.StatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="सृजनParser.variableDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVariableDeclaration([NotNull] सृजनParser.VariableDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="सृजनParser.variableDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVariableDeclaration([NotNull] सृजनParser.VariableDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="सृजनParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignment([NotNull] सृजनParser.AssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="सृजनParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignment([NotNull] सृजनParser.AssignmentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="सृजनParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfStatement([NotNull] सृजनParser.IfStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="सृजनParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfStatement([NotNull] सृजनParser.IfStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="सृजनParser.elseStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElseStatement([NotNull] सृजनParser.ElseStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="सृजनParser.elseStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElseStatement([NotNull] सृजनParser.ElseStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="सृजनParser.whileLoop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhileLoop([NotNull] सृजनParser.WhileLoopContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="सृजनParser.whileLoop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhileLoop([NotNull] सृजनParser.WhileLoopContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="सृजनParser.printStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrintStatement([NotNull] सृजनParser.PrintStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="सृजनParser.printStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrintStatement([NotNull] सृजनParser.PrintStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="सृजनParser.condition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCondition([NotNull] सृजनParser.ConditionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="सृजनParser.condition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCondition([NotNull] सृजनParser.ConditionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="सृजनParser.comparisionOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterComparisionOperator([NotNull] सृजनParser.ComparisionOperatorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="सृजनParser.comparisionOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitComparisionOperator([NotNull] सृजनParser.ComparisionOperatorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="सृजनParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression([NotNull] सृजनParser.ExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="सृजनParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression([NotNull] सृजनParser.ExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="सृजनParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTerm([NotNull] सृजनParser.TermContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="सृजनParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTerm([NotNull] सृजनParser.TermContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="सृजनParser.function"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunction([NotNull] सृजनParser.FunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="सृजनParser.function"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunction([NotNull] सृजनParser.FunctionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="सृजनParser.functionName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionName([NotNull] सृजनParser.FunctionNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="सृजनParser.functionName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionName([NotNull] सृजनParser.FunctionNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="सृजनParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFactor([NotNull] सृजनParser.FactorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="सृजनParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFactor([NotNull] सृजनParser.FactorContext context);
}
