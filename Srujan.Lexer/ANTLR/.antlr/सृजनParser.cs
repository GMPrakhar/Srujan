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

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class सृजनParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, TYPE=11, MAIN=12, IF=13, THEN=14, ELSE=15, WHILE=16, PRINT=17, 
		RETURN=18, ID=19, INT=20, DECIMAL=21, CHAR=22, STRING=23, PLUS=24, MINUS=25, 
		MULTIPLY=26, DIVIDE=27, EQUALS=28, LPAREN=29, RPAREN=30, SEMICOLON=31, 
		WS=32;
	public const int
		RULE_program = 0, RULE_statement = 1, RULE_variableDeclaration = 2, RULE_assignment = 3, 
		RULE_ifStatement = 4, RULE_elseStatement = 5, RULE_whileLoop = 6, RULE_printStatement = 7, 
		RULE_condition = 8, RULE_comparisionOperator = 9, RULE_expression = 10, 
		RULE_term = 11, RULE_function = 12, RULE_functionName = 13, RULE_factor = 14;
	public static readonly string[] ruleNames = {
		"program", "statement", "variableDeclaration", "assignment", "ifStatement", 
		"elseStatement", "whileLoop", "printStatement", "condition", "comparisionOperator", 
		"expression", "term", "function", "functionName", "factor"
	};

	private static readonly string[] _LiteralNames = {
		null, "':'", "'{'", "'}'", "'<'", "'>'", "'=='", "'!='", "'>='", "'<='", 
		"','", null, "'\\u092A\\u094D\\u0930\\u0935\\u0947\\u0936'", "'\\u0905\\u0917\\u0930'", 
		"'\\u0924\\u094B'", "'\\u092F\\u093E'", "'\\u091C\\u092C\\u0924\\u0915'", 
		"'\\u0926\\u093F\\u0916\\u093E\\u090F\\u0901'", "'\\u0909\\u0924\\u094D\\u0924\\u0930'", 
		null, null, null, null, null, "'+'", "'-'", "'*'", "'/'", "'='", "'('", 
		"')'", "';'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, "TYPE", 
		"MAIN", "IF", "THEN", "ELSE", "WHILE", "PRINT", "RETURN", "ID", "INT", 
		"DECIMAL", "CHAR", "STRING", "PLUS", "MINUS", "MULTIPLY", "DIVIDE", "EQUALS", 
		"LPAREN", "RPAREN", "SEMICOLON", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "सृजन.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static सृजनParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public सृजनParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public सृजनParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class ProgramContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext[] statement() {
			return GetRuleContexts<StatementContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext statement(int i) {
			return GetRuleContext<StatementContext>(i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_program; } }
	}

	[RuleVersion(0)]
	public ProgramContext program() {
		ProgramContext _localctx = new ProgramContext(Context, State);
		EnterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 31;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 30;
				statement();
				}
				}
				State = 33;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & 731136L) != 0) );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class StatementContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public VariableDeclarationContext variableDeclaration() {
			return GetRuleContext<VariableDeclarationContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public AssignmentContext assignment() {
			return GetRuleContext<AssignmentContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public IfStatementContext ifStatement() {
			return GetRuleContext<IfStatementContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public WhileLoopContext whileLoop() {
			return GetRuleContext<WhileLoopContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public PrintStatementContext printStatement() {
			return GetRuleContext<PrintStatementContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public FunctionContext function() {
			return GetRuleContext<FunctionContext>(0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_statement; } }
	}

	[RuleVersion(0)]
	public StatementContext statement() {
		StatementContext _localctx = new StatementContext(Context, State);
		EnterRule(_localctx, 2, RULE_statement);
		try {
			State = 41;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,1,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 35;
				variableDeclaration();
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 36;
				assignment();
				}
				break;
			case 3:
				EnterOuterAlt(_localctx, 3);
				{
				State = 37;
				ifStatement();
				}
				break;
			case 4:
				EnterOuterAlt(_localctx, 4);
				{
				State = 38;
				whileLoop();
				}
				break;
			case 5:
				EnterOuterAlt(_localctx, 5);
				{
				State = 39;
				printStatement();
				}
				break;
			case 6:
				EnterOuterAlt(_localctx, 6);
				{
				State = 40;
				function();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class VariableDeclarationContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(सृजनParser.ID, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode TYPE() { return GetToken(सृजनParser.TYPE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode EQUALS() { return GetToken(सृजनParser.EQUALS, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SEMICOLON() { return GetToken(सृजनParser.SEMICOLON, 0); }
		public VariableDeclarationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_variableDeclaration; } }
	}

	[RuleVersion(0)]
	public VariableDeclarationContext variableDeclaration() {
		VariableDeclarationContext _localctx = new VariableDeclarationContext(Context, State);
		EnterRule(_localctx, 4, RULE_variableDeclaration);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 43;
			Match(ID);
			State = 44;
			Match(T__0);
			State = 45;
			Match(TYPE);
			State = 46;
			Match(EQUALS);
			State = 47;
			expression();
			State = 48;
			Match(SEMICOLON);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AssignmentContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(सृजनParser.ID, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode EQUALS() { return GetToken(सृजनParser.EQUALS, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SEMICOLON() { return GetToken(सृजनParser.SEMICOLON, 0); }
		public AssignmentContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_assignment; } }
	}

	[RuleVersion(0)]
	public AssignmentContext assignment() {
		AssignmentContext _localctx = new AssignmentContext(Context, State);
		EnterRule(_localctx, 6, RULE_assignment);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 50;
			Match(ID);
			State = 51;
			Match(EQUALS);
			State = 52;
			expression();
			State = 53;
			Match(SEMICOLON);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class IfStatementContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IF() { return GetToken(सृजनParser.IF, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ConditionContext condition() {
			return GetRuleContext<ConditionContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode THEN() { return GetToken(सृजनParser.THEN, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext[] statement() {
			return GetRuleContexts<StatementContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext statement(int i) {
			return GetRuleContext<StatementContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ElseStatementContext elseStatement() {
			return GetRuleContext<ElseStatementContext>(0);
		}
		public IfStatementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_ifStatement; } }
	}

	[RuleVersion(0)]
	public IfStatementContext ifStatement() {
		IfStatementContext _localctx = new IfStatementContext(Context, State);
		EnterRule(_localctx, 8, RULE_ifStatement);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 55;
			Match(IF);
			State = 56;
			condition();
			State = 57;
			Match(THEN);
			State = 58;
			Match(T__1);
			State = 60;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 59;
				statement();
				}
				}
				State = 62;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & 731136L) != 0) );
			State = 64;
			Match(T__2);
			State = 66;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==ELSE) {
				{
				State = 65;
				elseStatement();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ElseStatementContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ELSE() { return GetToken(सृजनParser.ELSE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext[] statement() {
			return GetRuleContexts<StatementContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext statement(int i) {
			return GetRuleContext<StatementContext>(i);
		}
		public ElseStatementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_elseStatement; } }
	}

	[RuleVersion(0)]
	public ElseStatementContext elseStatement() {
		ElseStatementContext _localctx = new ElseStatementContext(Context, State);
		EnterRule(_localctx, 10, RULE_elseStatement);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 68;
			Match(ELSE);
			State = 69;
			Match(T__1);
			State = 71;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 70;
				statement();
				}
				}
				State = 73;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & 731136L) != 0) );
			State = 75;
			Match(T__2);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class WhileLoopContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode WHILE() { return GetToken(सृजनParser.WHILE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ConditionContext condition() {
			return GetRuleContext<ConditionContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext[] statement() {
			return GetRuleContexts<StatementContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext statement(int i) {
			return GetRuleContext<StatementContext>(i);
		}
		public WhileLoopContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_whileLoop; } }
	}

	[RuleVersion(0)]
	public WhileLoopContext whileLoop() {
		WhileLoopContext _localctx = new WhileLoopContext(Context, State);
		EnterRule(_localctx, 12, RULE_whileLoop);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 77;
			Match(WHILE);
			State = 78;
			condition();
			State = 79;
			Match(T__1);
			State = 81;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 80;
				statement();
				}
				}
				State = 83;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & 731136L) != 0) );
			State = 85;
			Match(T__2);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PrintStatementContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode PRINT() { return GetToken(सृजनParser.PRINT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SEMICOLON() { return GetToken(सृजनParser.SEMICOLON, 0); }
		public PrintStatementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_printStatement; } }
	}

	[RuleVersion(0)]
	public PrintStatementContext printStatement() {
		PrintStatementContext _localctx = new PrintStatementContext(Context, State);
		EnterRule(_localctx, 14, RULE_printStatement);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 87;
			Match(PRINT);
			State = 88;
			expression();
			State = 89;
			Match(SEMICOLON);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ConditionContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ComparisionOperatorContext comparisionOperator() {
			return GetRuleContext<ComparisionOperatorContext>(0);
		}
		public ConditionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_condition; } }
	}

	[RuleVersion(0)]
	public ConditionContext condition() {
		ConditionContext _localctx = new ConditionContext(Context, State);
		EnterRule(_localctx, 16, RULE_condition);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 91;
			expression();
			State = 92;
			comparisionOperator();
			State = 93;
			expression();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ComparisionOperatorContext : ParserRuleContext {
		public ComparisionOperatorContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_comparisionOperator; } }
	}

	[RuleVersion(0)]
	public ComparisionOperatorContext comparisionOperator() {
		ComparisionOperatorContext _localctx = new ComparisionOperatorContext(Context, State);
		EnterRule(_localctx, 18, RULE_comparisionOperator);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 95;
			_la = TokenStream.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 1008L) != 0)) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExpressionContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public TermContext[] term() {
			return GetRuleContexts<TermContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public TermContext term(int i) {
			return GetRuleContext<TermContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] PLUS() { return GetTokens(सृजनParser.PLUS); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode PLUS(int i) {
			return GetToken(सृजनParser.PLUS, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] MINUS() { return GetTokens(सृजनParser.MINUS); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode MINUS(int i) {
			return GetToken(सृजनParser.MINUS, i);
		}
		public ExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expression; } }
	}

	[RuleVersion(0)]
	public ExpressionContext expression() {
		ExpressionContext _localctx = new ExpressionContext(Context, State);
		EnterRule(_localctx, 20, RULE_expression);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 97;
			term();
			State = 102;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==PLUS || _la==MINUS) {
				{
				{
				State = 98;
				_la = TokenStream.LA(1);
				if ( !(_la==PLUS || _la==MINUS) ) {
				ErrorHandler.RecoverInline(this);
				}
				else {
					ErrorHandler.ReportMatch(this);
				    Consume();
				}
				State = 99;
				term();
				}
				}
				State = 104;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TermContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public FactorContext[] factor() {
			return GetRuleContexts<FactorContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public FactorContext factor(int i) {
			return GetRuleContext<FactorContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] MULTIPLY() { return GetTokens(सृजनParser.MULTIPLY); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode MULTIPLY(int i) {
			return GetToken(सृजनParser.MULTIPLY, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] DIVIDE() { return GetTokens(सृजनParser.DIVIDE); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DIVIDE(int i) {
			return GetToken(सृजनParser.DIVIDE, i);
		}
		public TermContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_term; } }
	}

	[RuleVersion(0)]
	public TermContext term() {
		TermContext _localctx = new TermContext(Context, State);
		EnterRule(_localctx, 22, RULE_term);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 105;
			factor();
			State = 110;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==MULTIPLY || _la==DIVIDE) {
				{
				{
				State = 106;
				_la = TokenStream.LA(1);
				if ( !(_la==MULTIPLY || _la==DIVIDE) ) {
				ErrorHandler.RecoverInline(this);
				}
				else {
					ErrorHandler.ReportMatch(this);
				    Consume();
				}
				State = 107;
				factor();
				}
				}
				State = 112;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FunctionContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] TYPE() { return GetTokens(सृजनParser.TYPE); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode TYPE(int i) {
			return GetToken(सृजनParser.TYPE, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LPAREN() { return GetToken(सृजनParser.LPAREN, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode RPAREN() { return GetToken(सृजनParser.RPAREN, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public FunctionNameContext functionName() {
			return GetRuleContext<FunctionNameContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode MAIN() { return GetToken(सृजनParser.MAIN, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] ID() { return GetTokens(सृजनParser.ID); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID(int i) {
			return GetToken(सृजनParser.ID, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext[] statement() {
			return GetRuleContexts<StatementContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext statement(int i) {
			return GetRuleContext<StatementContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] RETURN() { return GetTokens(सृजनParser.RETURN); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode RETURN(int i) {
			return GetToken(सृजनParser.RETURN, i);
		}
		public FunctionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_function; } }
	}

	[RuleVersion(0)]
	public FunctionContext function() {
		FunctionContext _localctx = new FunctionContext(Context, State);
		EnterRule(_localctx, 24, RULE_function);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 113;
			Match(TYPE);
			State = 116;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case ID:
				{
				State = 114;
				functionName();
				}
				break;
			case MAIN:
				{
				State = 115;
				Match(MAIN);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			State = 118;
			Match(LPAREN);
			State = 131;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==TYPE) {
				{
				{
				State = 119;
				Match(TYPE);
				State = 120;
				Match(ID);
				State = 126;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while (_la==T__9) {
					{
					{
					State = 121;
					Match(T__9);
					State = 122;
					Match(TYPE);
					State = 123;
					Match(ID);
					}
					}
					State = 128;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				}
				}
				State = 133;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 134;
			Match(RPAREN);
			State = 135;
			Match(T__1);
			State = 137;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 136;
				statement();
				}
				}
				State = 139;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & 731136L) != 0) );
			State = 145;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==RETURN) {
				{
				{
				State = 141;
				Match(RETURN);
				State = 142;
				statement();
				}
				}
				State = 147;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 148;
			Match(T__2);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FunctionNameContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(सृजनParser.ID, 0); }
		public FunctionNameContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_functionName; } }
	}

	[RuleVersion(0)]
	public FunctionNameContext functionName() {
		FunctionNameContext _localctx = new FunctionNameContext(Context, State);
		EnterRule(_localctx, 26, RULE_functionName);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 150;
			Match(ID);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FactorContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LPAREN() { return GetToken(सृजनParser.LPAREN, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode RPAREN() { return GetToken(सृजनParser.RPAREN, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT() { return GetToken(सृजनParser.INT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode CHAR() { return GetToken(सृजनParser.CHAR, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING() { return GetToken(सृजनParser.STRING, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(सृजनParser.ID, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DECIMAL() { return GetToken(सृजनParser.DECIMAL, 0); }
		public FactorContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_factor; } }
	}

	[RuleVersion(0)]
	public FactorContext factor() {
		FactorContext _localctx = new FactorContext(Context, State);
		EnterRule(_localctx, 28, RULE_factor);
		try {
			State = 161;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case LPAREN:
				EnterOuterAlt(_localctx, 1);
				{
				State = 152;
				Match(LPAREN);
				State = 153;
				expression();
				State = 154;
				Match(RPAREN);
				}
				break;
			case INT:
				EnterOuterAlt(_localctx, 2);
				{
				State = 156;
				Match(INT);
				}
				break;
			case CHAR:
				EnterOuterAlt(_localctx, 3);
				{
				State = 157;
				Match(CHAR);
				}
				break;
			case STRING:
				EnterOuterAlt(_localctx, 4);
				{
				State = 158;
				Match(STRING);
				}
				break;
			case ID:
				EnterOuterAlt(_localctx, 5);
				{
				State = 159;
				Match(ID);
				}
				break;
			case DECIMAL:
				EnterOuterAlt(_localctx, 6);
				{
				State = 160;
				Match(DECIMAL);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static int[] _serializedATN = {
		4,1,32,164,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,6,2,7,
		7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,7,14,
		1,0,4,0,32,8,0,11,0,12,0,33,1,1,1,1,1,1,1,1,1,1,1,1,3,1,42,8,1,1,2,1,2,
		1,2,1,2,1,2,1,2,1,2,1,3,1,3,1,3,1,3,1,3,1,4,1,4,1,4,1,4,1,4,4,4,61,8,4,
		11,4,12,4,62,1,4,1,4,3,4,67,8,4,1,5,1,5,1,5,4,5,72,8,5,11,5,12,5,73,1,
		5,1,5,1,6,1,6,1,6,1,6,4,6,82,8,6,11,6,12,6,83,1,6,1,6,1,7,1,7,1,7,1,7,
		1,8,1,8,1,8,1,8,1,9,1,9,1,10,1,10,1,10,5,10,101,8,10,10,10,12,10,104,9,
		10,1,11,1,11,1,11,5,11,109,8,11,10,11,12,11,112,9,11,1,12,1,12,1,12,3,
		12,117,8,12,1,12,1,12,1,12,1,12,1,12,1,12,5,12,125,8,12,10,12,12,12,128,
		9,12,5,12,130,8,12,10,12,12,12,133,9,12,1,12,1,12,1,12,4,12,138,8,12,11,
		12,12,12,139,1,12,1,12,5,12,144,8,12,10,12,12,12,147,9,12,1,12,1,12,1,
		13,1,13,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,3,14,162,8,14,1,14,
		0,0,15,0,2,4,6,8,10,12,14,16,18,20,22,24,26,28,0,3,1,0,4,9,1,0,24,25,1,
		0,26,27,170,0,31,1,0,0,0,2,41,1,0,0,0,4,43,1,0,0,0,6,50,1,0,0,0,8,55,1,
		0,0,0,10,68,1,0,0,0,12,77,1,0,0,0,14,87,1,0,0,0,16,91,1,0,0,0,18,95,1,
		0,0,0,20,97,1,0,0,0,22,105,1,0,0,0,24,113,1,0,0,0,26,150,1,0,0,0,28,161,
		1,0,0,0,30,32,3,2,1,0,31,30,1,0,0,0,32,33,1,0,0,0,33,31,1,0,0,0,33,34,
		1,0,0,0,34,1,1,0,0,0,35,42,3,4,2,0,36,42,3,6,3,0,37,42,3,8,4,0,38,42,3,
		12,6,0,39,42,3,14,7,0,40,42,3,24,12,0,41,35,1,0,0,0,41,36,1,0,0,0,41,37,
		1,0,0,0,41,38,1,0,0,0,41,39,1,0,0,0,41,40,1,0,0,0,42,3,1,0,0,0,43,44,5,
		19,0,0,44,45,5,1,0,0,45,46,5,11,0,0,46,47,5,28,0,0,47,48,3,20,10,0,48,
		49,5,31,0,0,49,5,1,0,0,0,50,51,5,19,0,0,51,52,5,28,0,0,52,53,3,20,10,0,
		53,54,5,31,0,0,54,7,1,0,0,0,55,56,5,13,0,0,56,57,3,16,8,0,57,58,5,14,0,
		0,58,60,5,2,0,0,59,61,3,2,1,0,60,59,1,0,0,0,61,62,1,0,0,0,62,60,1,0,0,
		0,62,63,1,0,0,0,63,64,1,0,0,0,64,66,5,3,0,0,65,67,3,10,5,0,66,65,1,0,0,
		0,66,67,1,0,0,0,67,9,1,0,0,0,68,69,5,15,0,0,69,71,5,2,0,0,70,72,3,2,1,
		0,71,70,1,0,0,0,72,73,1,0,0,0,73,71,1,0,0,0,73,74,1,0,0,0,74,75,1,0,0,
		0,75,76,5,3,0,0,76,11,1,0,0,0,77,78,5,16,0,0,78,79,3,16,8,0,79,81,5,2,
		0,0,80,82,3,2,1,0,81,80,1,0,0,0,82,83,1,0,0,0,83,81,1,0,0,0,83,84,1,0,
		0,0,84,85,1,0,0,0,85,86,5,3,0,0,86,13,1,0,0,0,87,88,5,17,0,0,88,89,3,20,
		10,0,89,90,5,31,0,0,90,15,1,0,0,0,91,92,3,20,10,0,92,93,3,18,9,0,93,94,
		3,20,10,0,94,17,1,0,0,0,95,96,7,0,0,0,96,19,1,0,0,0,97,102,3,22,11,0,98,
		99,7,1,0,0,99,101,3,22,11,0,100,98,1,0,0,0,101,104,1,0,0,0,102,100,1,0,
		0,0,102,103,1,0,0,0,103,21,1,0,0,0,104,102,1,0,0,0,105,110,3,28,14,0,106,
		107,7,2,0,0,107,109,3,28,14,0,108,106,1,0,0,0,109,112,1,0,0,0,110,108,
		1,0,0,0,110,111,1,0,0,0,111,23,1,0,0,0,112,110,1,0,0,0,113,116,5,11,0,
		0,114,117,3,26,13,0,115,117,5,12,0,0,116,114,1,0,0,0,116,115,1,0,0,0,117,
		118,1,0,0,0,118,131,5,29,0,0,119,120,5,11,0,0,120,126,5,19,0,0,121,122,
		5,10,0,0,122,123,5,11,0,0,123,125,5,19,0,0,124,121,1,0,0,0,125,128,1,0,
		0,0,126,124,1,0,0,0,126,127,1,0,0,0,127,130,1,0,0,0,128,126,1,0,0,0,129,
		119,1,0,0,0,130,133,1,0,0,0,131,129,1,0,0,0,131,132,1,0,0,0,132,134,1,
		0,0,0,133,131,1,0,0,0,134,135,5,30,0,0,135,137,5,2,0,0,136,138,3,2,1,0,
		137,136,1,0,0,0,138,139,1,0,0,0,139,137,1,0,0,0,139,140,1,0,0,0,140,145,
		1,0,0,0,141,142,5,18,0,0,142,144,3,2,1,0,143,141,1,0,0,0,144,147,1,0,0,
		0,145,143,1,0,0,0,145,146,1,0,0,0,146,148,1,0,0,0,147,145,1,0,0,0,148,
		149,5,3,0,0,149,25,1,0,0,0,150,151,5,19,0,0,151,27,1,0,0,0,152,153,5,29,
		0,0,153,154,3,20,10,0,154,155,5,30,0,0,155,162,1,0,0,0,156,162,5,20,0,
		0,157,162,5,22,0,0,158,162,5,23,0,0,159,162,5,19,0,0,160,162,5,21,0,0,
		161,152,1,0,0,0,161,156,1,0,0,0,161,157,1,0,0,0,161,158,1,0,0,0,161,159,
		1,0,0,0,161,160,1,0,0,0,162,29,1,0,0,0,14,33,41,62,66,73,83,102,110,116,
		126,131,139,145,161
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
