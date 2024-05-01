grammar सृजन;

// Define lexer rules
TYPE        : 'अंक' | 'अक्षर' | 'तार';
MAIN        : 'प्रवेश';
IF          : 'अगर';
THEN        : 'तो';
ELSE        : 'या';
WHILE       : 'जबतक';
PRINT       : 'दिखाएँ';
RETURN      : 'उत्तर';
ID          : [ऀ-ॿ]+;
INT         : [0-9]+;
CHAR        : '\''[0-9A-Za-zऀ-ॿ ]'\'';
STRING      : '"'[0-9A-Za-zऀ-ॿ ]*'"';
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
            ;

variableDeclaration :  ID':' TYPE '=' expression SEMICOLON;

assignment  : ID '=' expression SEMICOLON;

ifStatement : IF condition '{' statement+ '}' (ELSE '{' statement+ '}')?;

whileLoop   : WHILE condition '{' statement+ '}';

printStatement : PRINT expression SEMICOLON;

condition   : expression ( '<' | '>' | '==' | '!=' | '>=' | '<=' ) expression;

expression  : term ((PLUS | MINUS) term)*;

term        : factor ((MULTIPLY | DIVIDE) factor)*;

function    : TYPE (functionName | MAIN) '(' (TYPE ID (',' TYPE ID)*)* ')' '{' statement+ ( RETURN statement )* '}';

functionName : ID;

factor      : INT
            | CHAR
            | STRING
            | ID
            | LPAREN expression RPAREN;