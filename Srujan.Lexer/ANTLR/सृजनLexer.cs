//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from d:/Repos/Srujan/Srujan.Lexer/ANTLR/सृजन.g4 by ANTLR 4.13.1

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
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, TYPE=15, BREAK=16, MAIN=17, 
		IF=18, THEN=19, ELSE=20, WHILE=21, PRINT=22, NEWLINE=23, SCAN=24, RETURN=25, 
		CONTINUE=26, TRUE=27, FALSE=28, ID=29, INT=30, DECIMAL=31, CHAR=32, STRING=33, 
		PLUS=34, MOD=35, MINUS=36, MULTIPLY=37, DIVIDE=38, EQUALS=39, LPAREN=40, 
		RPAREN=41, SEMICOLON=42, COMMENT=43, WS=44;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "TYPE", "BREAK", "MAIN", "IF", 
		"THEN", "ELSE", "WHILE", "PRINT", "NEWLINE", "SCAN", "RETURN", "CONTINUE", 
		"TRUE", "FALSE", "ID", "INT", "DECIMAL", "CHAR", "STRING", "PLUS", "MOD", 
		"MINUS", "MULTIPLY", "DIVIDE", "EQUALS", "LPAREN", "RPAREN", "SEMICOLON", 
		"COMMENT", "WS"
	};


	public सृजनLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public सृजनLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "':'", "'['", "']'", "'{'", "','", "'}'", "'<'", "'>'", "'=='", 
		"'!='", "'>='", "'<='", "'&&'", "'||'", null, "'\\u0935\\u093F\\u0930\\u093E\\u092E'", 
		"'\\u092A\\u094D\\u0930\\u0935\\u0947\\u0936'", "'\\u0905\\u0917\\u0930'", 
		"'\\u0924\\u094B'", "'\\u092F\\u093E'", "'\\u091C\\u092C\\u0924\\u0915'", 
		"'\\u0926\\u093F\\u0916\\u093E\\u090F\\u0901'", "'\\u092A\\u0902\\u0915\\u094D\\u0924\\u093F'", 
		"'\\u0938\\u094D\\u0935\\u0940\\u0915\\u093E\\u0930 \\u0915\\u0930\\u0947\\u0902'", 
		"'\\u0909\\u0924\\u094D\\u0924\\u0930'", "'\\u091C\\u093E\\u0930\\u0940 \\u0930\\u0916\\u0947\\u0902'", 
		"'\\u0938\\u0939\\u0940'", "'\\u0917\\u0932\\u0924'", null, null, null, 
		null, null, "'+'", "'%'", "'-'", "'*'", "'/'", "'='", "'('", "')'", "';'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, "TYPE", "BREAK", "MAIN", "IF", "THEN", "ELSE", "WHILE", 
		"PRINT", "NEWLINE", "SCAN", "RETURN", "CONTINUE", "TRUE", "FALSE", "ID", 
		"INT", "DECIMAL", "CHAR", "STRING", "PLUS", "MOD", "MINUS", "MULTIPLY", 
		"DIVIDE", "EQUALS", "LPAREN", "RPAREN", "SEMICOLON", "COMMENT", "WS"
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
		4,0,44,290,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,2,34,7,34,2,35,
		7,35,2,36,7,36,2,37,7,37,2,38,7,38,2,39,7,39,2,40,7,40,2,41,7,41,2,42,
		7,42,2,43,7,43,1,0,1,0,1,1,1,1,1,2,1,2,1,3,1,3,1,4,1,4,1,5,1,5,1,6,1,6,
		1,7,1,7,1,8,1,8,1,8,1,9,1,9,1,9,1,10,1,10,1,10,1,11,1,11,1,11,1,12,1,12,
		1,12,1,13,1,13,1,13,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,
		1,14,1,14,1,14,1,14,1,14,1,14,3,14,140,8,14,1,15,1,15,1,15,1,15,1,15,1,
		15,1,16,1,16,1,16,1,16,1,16,1,16,1,16,1,17,1,17,1,17,1,17,1,18,1,18,1,
		18,1,19,1,19,1,19,1,20,1,20,1,20,1,20,1,20,1,21,1,21,1,21,1,21,1,21,1,
		21,1,21,1,22,1,22,1,22,1,22,1,22,1,22,1,22,1,23,1,23,1,23,1,23,1,23,1,
		23,1,23,1,23,1,23,1,23,1,23,1,23,1,23,1,24,1,24,1,24,1,24,1,24,1,24,1,
		25,1,25,1,25,1,25,1,25,1,25,1,25,1,25,1,25,1,25,1,26,1,26,1,26,1,26,1,
		27,1,27,1,27,1,27,1,28,4,28,222,8,28,11,28,12,28,223,1,29,4,29,227,8,29,
		11,29,12,29,228,1,30,1,30,1,30,4,30,234,8,30,11,30,12,30,235,3,30,238,
		8,30,1,31,1,31,1,31,1,31,1,32,1,32,5,32,246,8,32,10,32,12,32,249,9,32,
		1,32,1,32,1,33,1,33,1,34,1,34,1,35,1,35,1,36,1,36,1,37,1,37,1,38,1,38,
		1,39,1,39,1,40,1,40,1,41,1,41,1,42,1,42,1,42,1,42,5,42,275,8,42,10,42,
		12,42,278,9,42,1,42,1,42,1,42,1,42,1,43,4,43,285,8,43,11,43,12,43,286,
		1,43,1,43,2,247,276,0,44,1,1,3,2,5,3,7,4,9,5,11,6,13,7,15,8,17,9,19,10,
		21,11,23,12,25,13,27,14,29,15,31,16,33,17,35,18,37,19,39,20,41,21,43,22,
		45,23,47,24,49,25,51,26,53,27,55,28,57,29,59,30,61,31,63,32,65,33,67,34,
		69,35,71,36,73,37,75,38,77,39,79,40,81,41,83,42,85,43,87,44,1,0,3,2,0,
		95,95,2304,2431,1,0,48,57,3,0,9,10,13,13,32,32,299,0,1,1,0,0,0,0,3,1,0,
		0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,
		1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,
		0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,0,35,1,0,0,0,0,37,
		1,0,0,0,0,39,1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,0,0,47,1,0,0,
		0,0,49,1,0,0,0,0,51,1,0,0,0,0,53,1,0,0,0,0,55,1,0,0,0,0,57,1,0,0,0,0,59,
		1,0,0,0,0,61,1,0,0,0,0,63,1,0,0,0,0,65,1,0,0,0,0,67,1,0,0,0,0,69,1,0,0,
		0,0,71,1,0,0,0,0,73,1,0,0,0,0,75,1,0,0,0,0,77,1,0,0,0,0,79,1,0,0,0,0,81,
		1,0,0,0,0,83,1,0,0,0,0,85,1,0,0,0,0,87,1,0,0,0,1,89,1,0,0,0,3,91,1,0,0,
		0,5,93,1,0,0,0,7,95,1,0,0,0,9,97,1,0,0,0,11,99,1,0,0,0,13,101,1,0,0,0,
		15,103,1,0,0,0,17,105,1,0,0,0,19,108,1,0,0,0,21,111,1,0,0,0,23,114,1,0,
		0,0,25,117,1,0,0,0,27,120,1,0,0,0,29,139,1,0,0,0,31,141,1,0,0,0,33,147,
		1,0,0,0,35,154,1,0,0,0,37,158,1,0,0,0,39,161,1,0,0,0,41,164,1,0,0,0,43,
		169,1,0,0,0,45,176,1,0,0,0,47,183,1,0,0,0,49,196,1,0,0,0,51,202,1,0,0,
		0,53,212,1,0,0,0,55,216,1,0,0,0,57,221,1,0,0,0,59,226,1,0,0,0,61,230,1,
		0,0,0,63,239,1,0,0,0,65,243,1,0,0,0,67,252,1,0,0,0,69,254,1,0,0,0,71,256,
		1,0,0,0,73,258,1,0,0,0,75,260,1,0,0,0,77,262,1,0,0,0,79,264,1,0,0,0,81,
		266,1,0,0,0,83,268,1,0,0,0,85,270,1,0,0,0,87,284,1,0,0,0,89,90,5,58,0,
		0,90,2,1,0,0,0,91,92,5,91,0,0,92,4,1,0,0,0,93,94,5,93,0,0,94,6,1,0,0,0,
		95,96,5,123,0,0,96,8,1,0,0,0,97,98,5,44,0,0,98,10,1,0,0,0,99,100,5,125,
		0,0,100,12,1,0,0,0,101,102,5,60,0,0,102,14,1,0,0,0,103,104,5,62,0,0,104,
		16,1,0,0,0,105,106,5,61,0,0,106,107,5,61,0,0,107,18,1,0,0,0,108,109,5,
		33,0,0,109,110,5,61,0,0,110,20,1,0,0,0,111,112,5,62,0,0,112,113,5,61,0,
		0,113,22,1,0,0,0,114,115,5,60,0,0,115,116,5,61,0,0,116,24,1,0,0,0,117,
		118,5,38,0,0,118,119,5,38,0,0,119,26,1,0,0,0,120,121,5,124,0,0,121,122,
		5,124,0,0,122,28,1,0,0,0,123,124,5,2309,0,0,124,125,5,2306,0,0,125,140,
		5,2325,0,0,126,127,5,2309,0,0,127,128,5,2325,0,0,128,129,5,2381,0,0,129,
		130,5,2359,0,0,130,140,5,2352,0,0,131,132,5,2340,0,0,132,133,5,2366,0,
		0,133,140,5,2352,0,0,134,135,5,2342,0,0,135,136,5,2358,0,0,136,137,5,2350,
		0,0,137,138,5,2354,0,0,138,140,5,2357,0,0,139,123,1,0,0,0,139,126,1,0,
		0,0,139,131,1,0,0,0,139,134,1,0,0,0,140,30,1,0,0,0,141,142,5,2357,0,0,
		142,143,5,2367,0,0,143,144,5,2352,0,0,144,145,5,2366,0,0,145,146,5,2350,
		0,0,146,32,1,0,0,0,147,148,5,2346,0,0,148,149,5,2381,0,0,149,150,5,2352,
		0,0,150,151,5,2357,0,0,151,152,5,2375,0,0,152,153,5,2358,0,0,153,34,1,
		0,0,0,154,155,5,2309,0,0,155,156,5,2327,0,0,156,157,5,2352,0,0,157,36,
		1,0,0,0,158,159,5,2340,0,0,159,160,5,2379,0,0,160,38,1,0,0,0,161,162,5,
		2351,0,0,162,163,5,2366,0,0,163,40,1,0,0,0,164,165,5,2332,0,0,165,166,
		5,2348,0,0,166,167,5,2340,0,0,167,168,5,2325,0,0,168,42,1,0,0,0,169,170,
		5,2342,0,0,170,171,5,2367,0,0,171,172,5,2326,0,0,172,173,5,2366,0,0,173,
		174,5,2319,0,0,174,175,5,2305,0,0,175,44,1,0,0,0,176,177,5,2346,0,0,177,
		178,5,2306,0,0,178,179,5,2325,0,0,179,180,5,2381,0,0,180,181,5,2340,0,
		0,181,182,5,2367,0,0,182,46,1,0,0,0,183,184,5,2360,0,0,184,185,5,2381,
		0,0,185,186,5,2357,0,0,186,187,5,2368,0,0,187,188,5,2325,0,0,188,189,5,
		2366,0,0,189,190,5,2352,0,0,190,191,5,32,0,0,191,192,5,2325,0,0,192,193,
		5,2352,0,0,193,194,5,2375,0,0,194,195,5,2306,0,0,195,48,1,0,0,0,196,197,
		5,2313,0,0,197,198,5,2340,0,0,198,199,5,2381,0,0,199,200,5,2340,0,0,200,
		201,5,2352,0,0,201,50,1,0,0,0,202,203,5,2332,0,0,203,204,5,2366,0,0,204,
		205,5,2352,0,0,205,206,5,2368,0,0,206,207,5,32,0,0,207,208,5,2352,0,0,
		208,209,5,2326,0,0,209,210,5,2375,0,0,210,211,5,2306,0,0,211,52,1,0,0,
		0,212,213,5,2360,0,0,213,214,5,2361,0,0,214,215,5,2368,0,0,215,54,1,0,
		0,0,216,217,5,2327,0,0,217,218,5,2354,0,0,218,219,5,2340,0,0,219,56,1,
		0,0,0,220,222,7,0,0,0,221,220,1,0,0,0,222,223,1,0,0,0,223,221,1,0,0,0,
		223,224,1,0,0,0,224,58,1,0,0,0,225,227,7,1,0,0,226,225,1,0,0,0,227,228,
		1,0,0,0,228,226,1,0,0,0,228,229,1,0,0,0,229,60,1,0,0,0,230,237,3,59,29,
		0,231,233,5,46,0,0,232,234,7,1,0,0,233,232,1,0,0,0,234,235,1,0,0,0,235,
		233,1,0,0,0,235,236,1,0,0,0,236,238,1,0,0,0,237,231,1,0,0,0,237,238,1,
		0,0,0,238,62,1,0,0,0,239,240,5,39,0,0,240,241,9,0,0,0,241,242,5,39,0,0,
		242,64,1,0,0,0,243,247,5,34,0,0,244,246,9,0,0,0,245,244,1,0,0,0,246,249,
		1,0,0,0,247,248,1,0,0,0,247,245,1,0,0,0,248,250,1,0,0,0,249,247,1,0,0,
		0,250,251,5,34,0,0,251,66,1,0,0,0,252,253,5,43,0,0,253,68,1,0,0,0,254,
		255,5,37,0,0,255,70,1,0,0,0,256,257,5,45,0,0,257,72,1,0,0,0,258,259,5,
		42,0,0,259,74,1,0,0,0,260,261,5,47,0,0,261,76,1,0,0,0,262,263,5,61,0,0,
		263,78,1,0,0,0,264,265,5,40,0,0,265,80,1,0,0,0,266,267,5,41,0,0,267,82,
		1,0,0,0,268,269,5,59,0,0,269,84,1,0,0,0,270,271,5,47,0,0,271,272,5,47,
		0,0,272,276,1,0,0,0,273,275,9,0,0,0,274,273,1,0,0,0,275,278,1,0,0,0,276,
		277,1,0,0,0,276,274,1,0,0,0,277,279,1,0,0,0,278,276,1,0,0,0,279,280,5,
		10,0,0,280,281,1,0,0,0,281,282,6,42,0,0,282,86,1,0,0,0,283,285,7,2,0,0,
		284,283,1,0,0,0,285,286,1,0,0,0,286,284,1,0,0,0,286,287,1,0,0,0,287,288,
		1,0,0,0,288,289,6,43,0,0,289,88,1,0,0,0,9,0,139,223,228,235,237,247,276,
		286,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
