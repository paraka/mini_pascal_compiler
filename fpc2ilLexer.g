/* Lexer para fpc2il */

options
{
    language=CSharp;
}

class fpc2ilLexer extends Lexer;
options
{
    k=2;
    exportVocab=fpc2illexerVocab;
    caseSensitive = true;           // lower and upper case is significant
    caseSensitiveLiterals = true;   // literals are case sensitive
    testLiterals = false;
}

tokens
{
    //Tipos basicos
    TIPO_ENTERO     = "integer";
    TIPO_CADENA     = "string";
    TIPO_REAL       = "real";
    TIPO_BOOLEANO   = "boolean";
    TIPO_CHAR       = "char";

    //literales booleanos
    LIT_CIERTO  = "true"; LIT_FALSO = "false";

    //Palabras reservadas
    RES_PROGRAM     = "program";
    RES_VAR         = "var";
    RES_CONST       = "const";
    RES_BEGIN       = "begin";
    RES_END         = "end";
    RES_FOR         = "for";
    RES_IF          = "if";
    RES_THEN        = "then";
    RES_ELSE        = "else";
    RES_TO          = "to";
    RES_DO          = "do";
    RES_WHILE       = "while";
    RES_REPEAT      = "repeat";
    RES_UNTIL       = "until";
    RES_FUNCTION    = "function";
    RES_PROCEDURE   = "procedure"; 
    RES_RETURN      = "return";
    OP_DIV          = "div";
    OP_MOD          = "mod";

    //operadores
    OP_Y    = "and";
    OP_O    = "or";
    OP_NEG  = "not";

    //ojo con este literal que seran devueltos en el token privado LIT_NUMERO
    LIT_ENTERO; LIT_REAL;
}
{
    protected Errors err = Errors.Instance;

    public override void reportError (RecognitionException e)
    {
        //Console.ForegroundColor = ConsoleColor.Red;
        err.addError(e.Message, e.getLine(), e.getColumn());
        //Console.ResetColor();
    }
}

    //Ignoramos espacios en blanco
    BLANCO  : ( ' '
            |   '\t'
            |   '\f'
            |   '\n' { newline(); }
            |   '\r' { newline(); }
            ) { _ttype = Token.SKIP; }
    ;

    protected DIGITO: '0'..'9';

    protected LETRA
        : 'a'..'z'
        | 'A'..'Z'
        ;

    //regla para reconocer literal o palabra reservada
    IDENT
        options { testLiterals = true; }
        : (LETRA|'_') (LETRA|DIGITO|'_')*
        ;

    //Separadores
    PUNTO_COMA  :   ';' ;
    COMA        :   ',' ;
    DOS_PUNTOS  :   ':' ;
    PUNTO       :   '.' ;
    PARENT_AB   :   '(' ;
    PARENT_CE   :   ')' ;

    //operadores
    OP_IGUAL        :   '='  ;
    OP_ASSING       :   ":=" ;
    OP_MAYOR        :   '>'  ;
    OP_MENOR        :   '<'  ;
    OP_MAYOR_IGUAL  :   ">=" ;
    OP_MENOR_IGUAL  :   "<=" ;
    OP_DISTINTO     :   "<>" ;
    OP_MAS          :   '+'  ;
    OP_MENOS        :   '-'  ;
    OP_PRODUCTO     :   '*'  ;
    OP_DIVISION     :   '/'  ;

    //literales enteros reales sin conflictos
    LIT_NUMERO : (( DIGITO )+ '.' ) =>
                    ( DIGITO )+ '.' ( DIGITO )* { _ttype = LIT_REAL; }
               | ( DIGITO )+ { _ttype = LIT_ENTERO; }
               ;


    //Comentarios
    COMENTARIO :
            "{" (~('\n'|'\r'))* "}"
            { _ttype = Token.SKIP; }
            ;

     //Literales
    LIT_CADENA :
         '\'' !
         ( ~('\''|'\n'|'\r') )*
         '\'' !
         ;
