options
{
    language=CSharp;
}

class fpc2ilParser extends Parser;
options
{
    k=2;
    importVocab=fpc2illexerVocab;
    exportVocab=fpc2ilparserVocab;
    buildAST=true;
}
 

tokens
{
    PROGRAMA;
    PARAMETROS;
    DEVUELVE;
    LISTA_IDS;
    BLOQUE;
    LISTA_ARGUMENTOS;
    LLAMADA_FUNCION;
    LLAMADA_PROC;
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

programa : (declaracionPrograma)+
            {## = #( #[PROGRAMA, "PROGRAM"] ,##);}
            bloque
            PUNTO
         ;

declaracionPrograma: 
        RES_PROGRAM^ id:IDENT PUNTO_COMA!
        ;

bloque:
    ( declaracionConstante
    | declaracionVariable
    | decprocedimientoYFuncion
    )*
    bloque_sentencia
    ;

declaracionConstante:
    RES_CONST^ definicionCte (PUNTO_COMA! definicionCte )* PUNTO_COMA!
    ;

definicionCte: IDENT OP_IGUAL^ literal //constante
    ;
    
declaracionVariable:
    RES_VAR^ definicionVar ( PUNTO_COMA! definicionVar )* PUNTO_COMA!;

definicionVar: listaIdents c:DOS_PUNTOS^ tipo;


decprocedimientoYFuncion:
        procedimientoOFuncion PUNTO_COMA!
        ;

procedimientoOFuncion:  declaracionProc
                     |  declaracionFunc
                     ;

declaracionProc:
        RES_PROCEDURE^ id:IDENT (listaParametros)? PUNTO_COMA! 
        bloque
        ;


seccionParametros: 
            grupoParametros
        |   RES_VAR^ grupoParametros
        ;


grupoParametros: ids:listaIdents DOS_PUNTOS! t:tipo
          //{#grupoParametros = #(#[ids],#t);}
          ;

declaracionFunc: 
        RES_FUNCTION^ id:IDENT (listaParametros)? DOS_PUNTOS! t:tipoDevuelto PUNTO_COMA!
        bloque
        ;

listaParametros: PARENT_AB! seccionParametros (PUNTO_COMA! seccionParametros)* PARENT_CE!
            {## = #( #[PARAMETROS, "PARAMETROS"] ,##);}
        ;

tipoDevuelto: t:tipo
        //{#tipoDevuelto= #(#[DEVUELVE, "DEVUELVE"],#t);}
        ;

        //TODO: no permitimos declaraciones del tipo var f,d,g:integer de momento
listaIdents: 
        id:IDENT //( COMA! IDENT )*
        //{#listaIdents = #(#[id],#listaIdents);}
        ;

literal:  LIT_ENTERO
        | LIT_REAL
        | LIT_CADENA
        | LIT_CHAR
        | literal_booleano
        ;

literal_booleano:
          LIT_CIERTO
        | LIT_FALSO
        ;

tipo:     TIPO_ENTERO
        | TIPO_REAL
        | TIPO_BOOLEANO
        | TIPO_CADENA
        | TIPO_CHAR
        | IDENT
        ;


sentencia:
        sentenciaSimple
      | expresionCompuesta
      ;

sentenciaSimple:
     bloque_sentencia
    |  asignacion
    | llamadaProc
    ;

llamadaProc!
        : id:IDENT ( PARENT_AB! args:listaArgumentos PARENT_CE! )?
        { #llamadaProc = #([LLAMADA_PROC, "LLAMADA_PROC"],id,args);}
        ;


asignacion: IDENT OP_ASSING^ expresion;

expresion:
    expresionSimple
    ( (OP_IGUAL^ | OP_DISTINTO^ | OP_MAYOR^ | OP_MENOR^ | OP_MAYOR_IGUAL^ | OP_MENOR_IGUAL^) expresionSimple)*
    ;

expresionSimple:
    term ( (OP_MAS^ | OP_MENOS^ | OP_O^) term )*
    ;

term:
    factor (( OP_PRODUCTO^ | OP_DIVISION^ | OP_DIV^ | OP_MOD^ | OP_Y^) factor)*
    ;

factor:
    IDENT
    | literal
    | llamadaFunction
    | OP_NEG^ factor
    ;

llamadaFunction!
    : id:IDENT (PARENT_AB! args:listaArgumentos)? PARENT_CE!
    { #llamadaFunction = #([LLAMADA_FUNCION, "LLAMADA_FUNCION"],id,args); }
    ;

listaArgumentos:
    argumentoActual (COMA! argumentoActual)*
    {#listaArgumentos = #([LISTA_ARGUMENTOS, "LISTA_ARGUMENTOS"],#listaArgumentos );}
    ;

argumentoActual:
    //expresion
    IDENT
    | literal
    ;

expresionCompuesta:
    | expresionCondicional
    | expresionBucle
    ;

bloque_sentencia: 
    RES_BEGIN! 
    sentencias
    RES_END!
     {## = #( #[BLOQUE, "BLOQUE" ],##);}
    ;

sentencias: 
     sentencia ( PUNTO_COMA! sentencia)*
    ;

expresionCondicional:
    expresionIf
    //| expresionCase ????
    ;
    
expresionIf:
    RES_IF^ expresion RES_THEN! sentencia
       ( options {
                 generateAmbigWarnings=false;
                 }
          : expresionElse //RES_ELSE! sentencia
        )?
       
    ;

expresionElse:
    RES_ELSE^ sentencia
    ;

expresionBucle:
      expresionFor
    | expresionWhile
    | expresionRepeat
    ;

/* Bucle for */

expresionFor:
    RES_FOR^ IDENT OP_ASSING! listaFor RES_DO! sentencia
    ;

listaFor:
    valorInicial RES_TO^ /* quizas contemplas tb downto */ valorFinal
    ;

valorInicial:
    IDENT
    | LIT_ENTERO
    ;

valorFinal:
    IDENT
    | LIT_ENTERO
    ;

/* bucle while */
expresionWhile:
    RES_WHILE^ expresion RES_DO! sentencia
    ;

/* bucle repeat */
expresionRepeat:
    RES_REPEAT^ sentencias RES_UNTIL! expresion
    ;
