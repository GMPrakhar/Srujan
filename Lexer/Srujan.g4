grammar BasicLanguage;

// Define lexer rules
ID          : [a-zA-Z]+;
INT         : [0-9]+;
PLUS        : '+';
MINUS       : '-';
MULTIPLY    : '*';
DIVIDE      : '/';
EQUALS      : '=';
LPAREN      : '(';
RPAREN      : ')';
SEMICOLON   : ';';
IF          : 'if';
ELSE        : 'else';
WHILE       : 'while';
PRINT       : 'print';
TYPE        : 'int'

// Define parser rules
program     : statement+;

statement   : variableDeclaration
            | assignment
            | ifStatement
            | whileLoop
            | printStatement
            ;

variableDeclaration :  ID: TYPE = expression SEMICOLON;

assignment  : ID '=' expression SEMICOLON;

ifStatement : IF condition '{' statement+ '}' (ELSE '{' statement+ '}')?;

whileLoop   : WHILE condition '{' statement+ '}';

printStatement : PRINT expression SEMICOLON;

condition   : expression ( '<' | '>' | '==' | '!=' | '>=' | '<=' ) expression;

expression  : term ((PLUS | MINUS) term)*;

term        : factor ((MULTIPLY | DIVIDE) factor)*;

factor      : INT
            | ID
            | LPAREN expression RPAREN;