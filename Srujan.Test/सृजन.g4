grammar सृजन;

// Define lexer rules
TYPE        : 'अंक' | 'अक्षर' | 'तार' | 'दशमलव';
MAIN        : 'प्रवेश';
IF          : 'अगर';
THEN        : 'तो';
ELSE        : 'या';
WHILE       : 'जबतक';
PRINT       : 'दिखाएँ';
RETURN      : 'उत्तर';
ID          : [ऀ-ॿ]+;
INT         : [0-9]+;
BREAK       : 'विराम';
DECIMAL     : INT('.' [0-9]+)?;
CHAR        : '\''[\s ]'\'';
STRING      : '"'[\s ]*'"';
PLUS        : '+';
MINUS       : '-';
MULTIPLY    : '*';
DIVIDE      : '/';
EQUALS      : '=';
LPAREN      : '(';
RPAREN      : ')';
SEMICOLON   : ';';
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
            ;

breakStatement : BREAK SEMICOLON;

arrayDeclaration : ID':' TYPE'['expression']' SEMICOLON; 

arrayAssignment : ID'['expression']' '=' expression SEMICOLON;

arrayAccess : ID'['expression']';

arrayInitialization : ID '=' '{' (expression (',' expression)*)? '}' SEMICOLON;

variableDeclaration :  ID':' TYPE '=' expression SEMICOLON;

assignment  : ID '=' expression SEMICOLON;

ifStatement : IF condition THEN '{' statement+ '}' (elseStatement)?;

elseStatement : ELSE '{' statement+ '}';

whileLoop   : WHILE condition '{' statement+ '}';

printStatement : PRINT expression SEMICOLON;

condition   : expression comparisionOperator expression;

comparisionOperator : '<' | '>' | '==' | '!=' | '>=' | '<=';

expression  : term ((PLUS | MINUS) term)*;
term        : factor ((MULTIPLY | DIVIDE) factor)*;

function    : TYPE (functionName | MAIN) '(' (TYPE ID (',' TYPE ID)*)* ')' '{' statement+ ( RETURN statement )* '}';

functionName : ID;

factor      : LPAREN expression RPAREN
            | INT
            | CHAR
            | STRING
            | ID
            | DECIMAL
            | arrayAccess;