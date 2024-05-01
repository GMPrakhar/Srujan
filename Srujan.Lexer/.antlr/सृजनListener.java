// Generated from c:/Users/prakh/source/repos/Srujan/Srujan.Lexer/सृजन.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link सृजनParser}.
 */
public interface सृजनListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link सृजनParser#program}.
	 * @param ctx the parse tree
	 */
	void enterProgram(सृजनParser.ProgramContext ctx);
	/**
	 * Exit a parse tree produced by {@link सृजनParser#program}.
	 * @param ctx the parse tree
	 */
	void exitProgram(सृजनParser.ProgramContext ctx);
	/**
	 * Enter a parse tree produced by {@link सृजनParser#statement}.
	 * @param ctx the parse tree
	 */
	void enterStatement(सृजनParser.StatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link सृजनParser#statement}.
	 * @param ctx the parse tree
	 */
	void exitStatement(सृजनParser.StatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link सृजनParser#variableDeclaration}.
	 * @param ctx the parse tree
	 */
	void enterVariableDeclaration(सृजनParser.VariableDeclarationContext ctx);
	/**
	 * Exit a parse tree produced by {@link सृजनParser#variableDeclaration}.
	 * @param ctx the parse tree
	 */
	void exitVariableDeclaration(सृजनParser.VariableDeclarationContext ctx);
	/**
	 * Enter a parse tree produced by {@link सृजनParser#assignment}.
	 * @param ctx the parse tree
	 */
	void enterAssignment(सृजनParser.AssignmentContext ctx);
	/**
	 * Exit a parse tree produced by {@link सृजनParser#assignment}.
	 * @param ctx the parse tree
	 */
	void exitAssignment(सृजनParser.AssignmentContext ctx);
	/**
	 * Enter a parse tree produced by {@link सृजनParser#ifStatement}.
	 * @param ctx the parse tree
	 */
	void enterIfStatement(सृजनParser.IfStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link सृजनParser#ifStatement}.
	 * @param ctx the parse tree
	 */
	void exitIfStatement(सृजनParser.IfStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link सृजनParser#whileLoop}.
	 * @param ctx the parse tree
	 */
	void enterWhileLoop(सृजनParser.WhileLoopContext ctx);
	/**
	 * Exit a parse tree produced by {@link सृजनParser#whileLoop}.
	 * @param ctx the parse tree
	 */
	void exitWhileLoop(सृजनParser.WhileLoopContext ctx);
	/**
	 * Enter a parse tree produced by {@link सृजनParser#printStatement}.
	 * @param ctx the parse tree
	 */
	void enterPrintStatement(सृजनParser.PrintStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link सृजनParser#printStatement}.
	 * @param ctx the parse tree
	 */
	void exitPrintStatement(सृजनParser.PrintStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link सृजनParser#condition}.
	 * @param ctx the parse tree
	 */
	void enterCondition(सृजनParser.ConditionContext ctx);
	/**
	 * Exit a parse tree produced by {@link सृजनParser#condition}.
	 * @param ctx the parse tree
	 */
	void exitCondition(सृजनParser.ConditionContext ctx);
	/**
	 * Enter a parse tree produced by {@link सृजनParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterExpression(सृजनParser.ExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link सृजनParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitExpression(सृजनParser.ExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link सृजनParser#term}.
	 * @param ctx the parse tree
	 */
	void enterTerm(सृजनParser.TermContext ctx);
	/**
	 * Exit a parse tree produced by {@link सृजनParser#term}.
	 * @param ctx the parse tree
	 */
	void exitTerm(सृजनParser.TermContext ctx);
	/**
	 * Enter a parse tree produced by {@link सृजनParser#function}.
	 * @param ctx the parse tree
	 */
	void enterFunction(सृजनParser.FunctionContext ctx);
	/**
	 * Exit a parse tree produced by {@link सृजनParser#function}.
	 * @param ctx the parse tree
	 */
	void exitFunction(सृजनParser.FunctionContext ctx);
	/**
	 * Enter a parse tree produced by {@link सृजनParser#functionName}.
	 * @param ctx the parse tree
	 */
	void enterFunctionName(सृजनParser.FunctionNameContext ctx);
	/**
	 * Exit a parse tree produced by {@link सृजनParser#functionName}.
	 * @param ctx the parse tree
	 */
	void exitFunctionName(सृजनParser.FunctionNameContext ctx);
	/**
	 * Enter a parse tree produced by {@link सृजनParser#factor}.
	 * @param ctx the parse tree
	 */
	void enterFactor(सृजनParser.FactorContext ctx);
	/**
	 * Exit a parse tree produced by {@link सृजनParser#factor}.
	 * @param ctx the parse tree
	 */
	void exitFactor(सृजनParser.FactorContext ctx);
}