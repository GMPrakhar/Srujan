grammar सृजन;

// Define lexer rules
TYPE        : 'अंक' | 'अक्षर' | 'तार' | 'दशमलव';
BREAK       : 'विराम';
MAIN        : 'प्रवेश';
IF          : 'अगर';
THEN        : 'तो';
ELSE        : 'या';
WHILE       : 'जबतक';
PRINT       : 'दिखाएँ';
NEWLINE     : 'पंक्ति';
SCAN        : 'स्वीकार करें';
RETURN      : 'उत्तर';
CONTINUE    : 'जारी रखें';
TRUE        : 'सही';
FALSE       : 'गलत';
ID          : [ऀ-ॿ_]+;
INT         : [0-9]+;
DECIMAL     : INT('.' [0-9]+)?;
CHAR        : '\''.'\'';
STRING      : '"'.*?'"';
PLUS        : '+';
MOD         : '%';
MINUS       : '-';
MULTIPLY    : '*';
DIVIDE      : '/';
EQUALS      : '=';
LPAREN      : '(';
RPAREN      : ')';
SEMICOLON   : ';';
COMMENT     : '//'.*?'\n' -> skip;
WS: [ \n\t\r]+ -> skip;


// Define parser rules
program     : statement+;

statement   : variableDeclaration
            | assignment
            | ifStatement
            | whileLoop
            | printStatement
            | function
            | breakStatement
            | arrayDeclaration
            | arrayAssignment
            | arrayInitialization
            | inputStatement
            | continueStatement
            | returnStatement
            ;

inputStatement : SCAN ID SEMICOLON;

breakStatement : BREAK SEMICOLON;

continueStatement : CONTINUE SEMICOLON;

returnStatement : RETURN expression SEMICOLON;

arrayDeclaration : ID':' TYPE'['expression']' SEMICOLON; 

arrayAssignment : ID'['expression']' '=' expression SEMICOLON;

arrayAccess : ID'['expression']';

arrayInitialization : ID '=' '{' (expression (',' expression)*)? '}' SEMICOLON;

variableDeclaration :  ID':' TYPE ('=' expression)? SEMICOLON;

assignment  : ID '=' expression SEMICOLON;

ifStatement : IF condition THEN '{' statement+ '}' (elseStatement)?;

elseStatement : ELSE '{' statement+ '}';

whileLoop   : WHILE condition '{' statement+ '}';

printStatement : PRINT (NEWLINE)? expression SEMICOLON;

condition   : expression comparisionOperator expression (logicalOperator expression comparisionOperator expression)*;

comparisionOperator : '<' | '>' | '==' | '!=' | '>=' | '<=';
logicalOperator : '&&' | '||';
bitwiseOperator : '&' | '|' | '^' | '<<' | '>>';
complementOperator : '~';

expression  : term ((PLUS | MINUS) term)*
            | expression comparisionOperator expression (logicalOperator expression comparisionOperator expression)*
            | expression bitwiseOperator expression
            | complementOperator expression;

term        : factor ((MULTIPLY | DIVIDE | MOD) factor)*;

function    : TYPE (functionName | MAIN) '(' (ID ':' TYPE (',' ID ':' TYPE )*)* ')' '{' statement+ '}';

functionCall : functionName '(' (expression (',' expression)*)? ')';

functionName : ID;

factor      : LPAREN expression RPAREN
            | INT
            | CHAR
            | STRING
            | ID
            | DECIMAL
            | TRUE
            | FALSE
            | arrayAccess
            | functionCall;