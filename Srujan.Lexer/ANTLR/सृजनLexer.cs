//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:/Users/prakh/source/repos/Srujan/Srujan.Lexer/ANTLR/सृजन.g4 by ANTLR 4.13.1

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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class सृजनLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, TYPE=11, MAIN=12, IF=13, THEN=14, ELSE=15, WHILE=16, PRINT=17, 
		RETURN=18, ID=19, INT=20, CHAR=21, STRING=22, PLUS=23, MINUS=24, MULTIPLY=25, 
		DIVIDE=26, EQUALS=27, LPAREN=28, RPAREN=29, SEMICOLON=30, WS=31;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "TYPE", "MAIN", "IF", "THEN", "ELSE", "WHILE", "PRINT", "RETURN", 
		"ID", "INT", "CHAR", "STRING", "PLUS", "MINUS", "MULTIPLY", "DIVIDE", 
		"EQUALS", "LPAREN", "RPAREN", "SEMICOLON", "WS"
	};


	public सृजनLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public सृजनLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "':'", "'{'", "'}'", "'<'", "'>'", "'=='", "'!='", "'>='", "'<='", 
		"','", null, "'\\u092A\\u094D\\u0930\\u0935\\u0947\\u0936'", "'\\u0905\\u0917\\u0930'", 
		"'\\u0924\\u094B'", "'\\u092F\\u093E'", "'\\u091C\\u092C\\u0924\\u0915'", 
		"'\\u0926\\u093F\\u0916\\u093E\\u090F\\u0901'", "'\\u0909\\u0924\\u094D\\u0924\\u0930'", 
		null, null, null, null, "'+'", "'-'", "'*'", "'/'", "'='", "'('", "')'", 
		"';'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, "TYPE", 
		"MAIN", "IF", "THEN", "ELSE", "WHILE", "PRINT", "RETURN", "ID", "INT", 
		"CHAR", "STRING", "PLUS", "MINUS", "MULTIPLY", "DIVIDE", "EQUALS", "LPAREN", 
		"RPAREN", "SEMICOLON", "WS"
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

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static सृजनLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,31,181,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,1,0,1,0,1,1,1,1,1,2,1,2,1,3,1,3,1,4,1,4,1,5,1,
		5,1,5,1,6,1,6,1,6,1,7,1,7,1,7,1,8,1,8,1,8,1,9,1,9,1,10,1,10,1,10,1,10,
		1,10,1,10,1,10,1,10,1,10,1,10,1,10,3,10,99,8,10,1,11,1,11,1,11,1,11,1,
		11,1,11,1,11,1,12,1,12,1,12,1,12,1,13,1,13,1,13,1,14,1,14,1,14,1,15,1,
		15,1,15,1,15,1,15,1,16,1,16,1,16,1,16,1,16,1,16,1,16,1,17,1,17,1,17,1,
		17,1,17,1,17,1,18,4,18,137,8,18,11,18,12,18,138,1,19,4,19,142,8,19,11,
		19,12,19,143,1,20,1,20,1,20,1,20,1,21,1,21,5,21,152,8,21,10,21,12,21,155,
		9,21,1,21,1,21,1,22,1,22,1,23,1,23,1,24,1,24,1,25,1,25,1,26,1,26,1,27,
		1,27,1,28,1,28,1,29,1,29,1,30,4,30,176,8,30,11,30,12,30,177,1,30,1,30,
		0,0,31,1,1,3,2,5,3,7,4,9,5,11,6,13,7,15,8,17,9,19,10,21,11,23,12,25,13,
		27,14,29,15,31,16,33,17,35,18,37,19,39,20,41,21,43,22,45,23,47,24,49,25,
		51,26,53,27,55,28,57,29,59,30,61,31,1,0,4,1,0,2304,2431,1,0,48,57,5,0,
		32,32,48,57,65,90,97,122,2304,2431,3,0,9,10,13,13,32,32,186,0,1,1,0,0,
		0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,
		0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,
		0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,0,35,
		1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,
		0,0,47,1,0,0,0,0,49,1,0,0,0,0,51,1,0,0,0,0,53,1,0,0,0,0,55,1,0,0,0,0,57,
		1,0,0,0,0,59,1,0,0,0,0,61,1,0,0,0,1,63,1,0,0,0,3,65,1,0,0,0,5,67,1,0,0,
		0,7,69,1,0,0,0,9,71,1,0,0,0,11,73,1,0,0,0,13,76,1,0,0,0,15,79,1,0,0,0,
		17,82,1,0,0,0,19,85,1,0,0,0,21,98,1,0,0,0,23,100,1,0,0,0,25,107,1,0,0,
		0,27,111,1,0,0,0,29,114,1,0,0,0,31,117,1,0,0,0,33,122,1,0,0,0,35,129,1,
		0,0,0,37,136,1,0,0,0,39,141,1,0,0,0,41,145,1,0,0,0,43,149,1,0,0,0,45,158,
		1,0,0,0,47,160,1,0,0,0,49,162,1,0,0,0,51,164,1,0,0,0,53,166,1,0,0,0,55,
		168,1,0,0,0,57,170,1,0,0,0,59,172,1,0,0,0,61,175,1,0,0,0,63,64,5,58,0,
		0,64,2,1,0,0,0,65,66,5,123,0,0,66,4,1,0,0,0,67,68,5,125,0,0,68,6,1,0,0,
		0,69,70,5,60,0,0,70,8,1,0,0,0,71,72,5,62,0,0,72,10,1,0,0,0,73,74,5,61,
		0,0,74,75,5,61,0,0,75,12,1,0,0,0,76,77,5,33,0,0,77,78,5,61,0,0,78,14,1,
		0,0,0,79,80,5,62,0,0,80,81,5,61,0,0,81,16,1,0,0,0,82,83,5,60,0,0,83,84,
		5,61,0,0,84,18,1,0,0,0,85,86,5,44,0,0,86,20,1,0,0,0,87,88,5,2309,0,0,88,
		89,5,2306,0,0,89,99,5,2325,0,0,90,91,5,2309,0,0,91,92,5,2325,0,0,92,93,
		5,2381,0,0,93,94,5,2359,0,0,94,99,5,2352,0,0,95,96,5,2340,0,0,96,97,5,
		2366,0,0,97,99,5,2352,0,0,98,87,1,0,0,0,98,90,1,0,0,0,98,95,1,0,0,0,99,
		22,1,0,0,0,100,101,5,2346,0,0,101,102,5,2381,0,0,102,103,5,2352,0,0,103,
		104,5,2357,0,0,104,105,5,2375,0,0,105,106,5,2358,0,0,106,24,1,0,0,0,107,
		108,5,2309,0,0,108,109,5,2327,0,0,109,110,5,2352,0,0,110,26,1,0,0,0,111,
		112,5,2340,0,0,112,113,5,2379,0,0,113,28,1,0,0,0,114,115,5,2351,0,0,115,
		116,5,2366,0,0,116,30,1,0,0,0,117,118,5,2332,0,0,118,119,5,2348,0,0,119,
		120,5,2340,0,0,120,121,5,2325,0,0,121,32,1,0,0,0,122,123,5,2342,0,0,123,
		124,5,2367,0,0,124,125,5,2326,0,0,125,126,5,2366,0,0,126,127,5,2319,0,
		0,127,128,5,2305,0,0,128,34,1,0,0,0,129,130,5,2313,0,0,130,131,5,2340,
		0,0,131,132,5,2381,0,0,132,133,5,2340,0,0,133,134,5,2352,0,0,134,36,1,
		0,0,0,135,137,7,0,0,0,136,135,1,0,0,0,137,138,1,0,0,0,138,136,1,0,0,0,
		138,139,1,0,0,0,139,38,1,0,0,0,140,142,7,1,0,0,141,140,1,0,0,0,142,143,
		1,0,0,0,143,141,1,0,0,0,143,144,1,0,0,0,144,40,1,0,0,0,145,146,5,39,0,
		0,146,147,7,2,0,0,147,148,5,39,0,0,148,42,1,0,0,0,149,153,5,34,0,0,150,
		152,7,2,0,0,151,150,1,0,0,0,152,155,1,0,0,0,153,151,1,0,0,0,153,154,1,
		0,0,0,154,156,1,0,0,0,155,153,1,0,0,0,156,157,5,34,0,0,157,44,1,0,0,0,
		158,159,5,43,0,0,159,46,1,0,0,0,160,161,5,45,0,0,161,48,1,0,0,0,162,163,
		5,42,0,0,163,50,1,0,0,0,164,165,5,47,0,0,165,52,1,0,0,0,166,167,5,61,0,
		0,167,54,1,0,0,0,168,169,5,40,0,0,169,56,1,0,0,0,170,171,5,41,0,0,171,
		58,1,0,0,0,172,173,5,59,0,0,173,60,1,0,0,0,174,176,7,3,0,0,175,174,1,0,
		0,0,176,177,1,0,0,0,177,175,1,0,0,0,177,178,1,0,0,0,178,179,1,0,0,0,179,
		180,6,30,0,0,180,62,1,0,0,0,6,0,98,138,143,153,177,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
