header {
    using System.Collections;
    using Emit = System.Reflection.Emit;
}
options
{
    language=CSharp;
}

class fpc2ilCodeGenerator extends TreeParser;
options
{
    importVocab=fpc2iltreeparserVocab;
    exportVocab=fpc2ilcodegenVocab;
    buildAST=false;
}
{
    private Symboltable symtab;
    private Errors err;
    private string proc_actual = "";
    private uint scope = 0;
    private ExpUtils eutils;
    private ILCodeGen cgen = null;

    public void FinishCode ()
    {
        cgen.FinishGen();
    }
}

programa
{
        symtab = Symboltable.Instance;
        err = Errors.Instance;
        eutils = new ExpUtils();
}
: #(PROGRAMA (declaracionPrograma)+ bloque)
;

declaracionPrograma
{
    Symbol s;
}
: #(RES_PROGRAM id:IDENT)
{
    cgen = new ILCodeGen(id.getText());
}
;

bloque
: (decVar | decConst | decprocedimiento| decFunction )* bloque_sentencia
;

/* CONSTANTES */
decConst:
    #(RES_CONST (declaracionConstante)+)
;

declaracionConstante
{
    Constant s;
}
: (s=decCte) {}
;

decCte returns [Constant s]
{
    s = null;
}
: #(OP_IGUAL id:IDENT {
       if (scope == 0)
        s = (Constant)symtab.find(id.getText());
     })
;

/* VARIABLES */
decVar:
    #(RES_VAR (declaracionVariable)+)
;

declaracionVariable
{
    Symbol s;
}
: (s=decVariable) {
    if (scope == 0) 
        cgen.genVariable(s);
}
;

decVariable returns [Symbol s]
{
    s = null;
}
: #(DOS_PUNTOS id:IDENT tp:tipo 
       {
       if (scope == 0)
        s = symtab.find(id.getText());
       }
   )
;

tipo: 
  TIPO_ENTERO
 | TIPO_CHAR
 | TIPO_REAL
 | TIPO_BOOLEANO
 | TIPO_CADENA
 ;

/* DEC PROCEDIMIENTOYFUNCION */
decprocedimiento
{
    Procedure s;
}
: #(RES_PROCEDURE s=procParamActual (sparametros)?{
    scope = 1;
    cgen.genMethod(s);
} bloque )
;

sparametros
{
    uint argnum = 0;
    Hashtable parametros = new Hashtable();
    Procedure s;
}
: #(PARAMETROS (listaParametros[parametros, ref argnum])? {})
;

listaParametros [Hashtable parametros, ref uint argnum]
: (declaracionParametroRef[parametros, ref argnum]|declaracionParametroValor[parametros, ref argnum])+
;

declaracionParametroRef [Hashtable parametros, ref uint argnum]
{
    Param p = null;
}
: #(RES_VAR id:IDENT ty:tipo)
;

declaracionParametroValor [Hashtable parametros, ref uint argnum]
{
    Param p = null;
}
: (id:IDENT ty:tipo)
;


procParamActual returns [Procedure s]
{
    s = null;
}
: #(id:IDENT {
    s = (Procedure)symtab.find(id.getText());
    proc_actual = id.getText();
    }
   )
;

funcParamActual returns [Function s]
{
    s = null;
}
: #(id:IDENT {
    s = (Function)symtab.find(id.getText());
    proc_actual = id.getText();
    }
   )
;

decFunction
{
    Function s;
}
:  #(RES_FUNCTION s=funcParamActual (sparametros)?
   {
    scope = 1;
    cgen.genMethod(s);
   }  
   ty:tipo {}
   bloque 
  ) //Fin dec function 
;

/* BLOQUES */

bloque_sentencia:
    #(BLOQUE 
    {
        /* Miramos a ver si es el bloque principal */
        AST aux = tmp7_AST_in.getNextSibling();
        if (aux != null && aux.Type == PUNTO) {
            scope = 0;
            cgen.genMain();
        }
    } (sentencias)+)
;

sentencias:
    sentencia_simple
    | sentencia_compuesta
    ;

sentencia_simple:
    bloque_sentencia
    | asignacion
    | llamada_proc
    ;

asignacion:
{
    Symbol s = null;
    Expr exp = null;
    ArrayList expS = new ArrayList();;
    int tipo = 0;
    int tipoDerecha = 0;
}
    #(OP_ASSING id:IDENT expresion[expS]
    {
        cgen.checkAndGenLdArgInReference(scope, proc_actual, id.getText());
        try
        {
            eutils.genAritExpresion(cgen, expS, scope, proc_actual, id.getText());
        } catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }        
    } )
    ;


expresion [ArrayList expS]
{
    Symbol sfc = null;
    Symbol s;
}
:
    #(OP_IGUAL expresion[expS] expresion[expS])
    {
        EQExpresion ex = new EQExpresion();
        expS.Add(ex);
    }
  | #(OP_DISTINTO expresion[expS] expresion[expS])
    {
        DFExpresion ex = new DFExpresion();
        expS.Add(ex);
    }
  | #(OP_MENOR expresion[expS] expresion[expS])
    {
        LTExpresion ex = new LTExpresion();
        expS.Add(ex);
    }
  | #(OP_MENOR_IGUAL expresion[expS] expresion[expS])
    {
        LEExpresion ex = new LEExpresion();
        expS.Add(ex);
    }
  | #(OP_MAYOR_IGUAL expresion[expS] expresion[expS])
    {
        GEExpresion ex = new GEExpresion();
        expS.Add(ex);
    }
  | #(OP_MAYOR expresion[expS] expresion[expS])
    {
        GTExpresion ex = new GTExpresion();
        expS.Add(ex);
    }
  | #(OP_MAS expresion[expS] (expresion[expS])?) 
    { 
        PlusExpresion ex = new PlusExpresion();
        expS.Add(ex);
    }
  | #(OP_MENOS expresion[expS] (expresion[expS])?) 
    { 
        MinusExpresion ex = new MinusExpresion();
        expS.Add(ex);
    }
  | #(OP_O expresion[expS] expresion[expS])
    {
        ORExpresion ex = new ORExpresion();
        expS.Add(ex);
    }
  | #(OP_PRODUCTO expresion[expS] expresion[expS]) 
    { 
        ProductoExpresion ex = new ProductoExpresion();
        expS.Add(ex);
    }
  | #(OP_DIVISION expresion[expS] expresion[expS]) 
    { 
        DivisionExpresion ex = new DivisionExpresion();
        expS.Add(ex);
    }
  | #(OP_DIV expresion[expS] expresion[expS])
    {
        DIVExpresion ex = new DIVExpresion();
        expS.Add(ex);
    }
  | #(OP_MOD expresion[expS] expresion[expS])
    {
        MODExpresion ex = new MODExpresion();
        expS.Add(ex);
    }
  | #(OP_Y expresion[expS] expresion[expS])
    {
        ANDExpresion ex = new ANDExpresion();
        expS.Add(ex);
    }
  | #(OP_NEG expresion[expS])
    {
        NOTExpresion ex = new NOTExpresion();
        expS.Add(ex);
    }
  | id:IDENT 
    { 
        Variable ex = new Variable();
        ex.Value = id.getText();
        expS.Add(ex);
    }
  | c1:LIT_ENTERO 
    { 
        IntLiteral ex = new IntLiteral();
        ex.Value = c1.getText();
        expS.Add(ex);
    }
  | c2:LIT_REAL
    { 
        RealLiteral ex = new RealLiteral();
        ex.Value = c2.getText();
        expS.Add(ex);
    }
  | c3:LIT_CIERTO
    { 
        BoolLiteral ex = new BoolLiteral();
        ex.Value = c3.getText();
        expS.Add(ex);
    }
  | c4:LIT_FALSO
    { 
        BoolLiteral ex = new BoolLiteral();
        ex.Value = c4.getText();
        expS.Add(ex);
    }
  | c5:LIT_CADENA
    { 
        if (c5.getText().Length > 1)
        {
            StringLiteral ex = new StringLiteral();
            ex.Value = c5.getText();
            expS.Add(ex);
        }
        else
        {
            CharLiteral ex = new CharLiteral();
            ex.Value = c5.getText();
            expS.Add(ex);
        }
    }
  | llamadaFuncion[ref sfc]
    { 
        if (sfc != null)
        {
            Function f = (Function)sfc;
            ExpFunction ex = new ExpFunction();
            ex.Tipo = f.TypeReturn.toString();
            ex.Value = f.Name; 
            expS.Add(ex);
        }
    }
  ;
 
llamadaFuncion [ref Symbol s]:
{
    ArrayList lista = new ArrayList();
    Function func = null;
    Procedure proc = null;
}
    #(LLAMADA_FUNCION id:IDENT (listaArgumentos[lista])?
      {
        try 
        {
            s = symtab.find(id.getText());
        } catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }        

        if (s != null) 
        {
            if (s is Function) 
            { 
                func = (Function)s; 
                try
                {
                    if (func.checkParams(lista))
                        cgen.genCall(func, lista, scope, proc_actual);
                } catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }        
            }
         }
      }
     )
    ;

llamada_proc:
{
    ArrayList lista = new ArrayList();
    Procedure proc = null;
}
    #(LLAMADA_PROC id:IDENT (listaArgumentos[lista])?
      {
        //writeln es especial, asi es que no estara en nuestra tabla
        string ident = id.getText();
        if (ident != "writeln")
        {
            try 
            {
                proc = (Procedure)symtab.find(ident);
            } catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }        

            if (proc != null)
            {
                /* 
                 * TODO:
                 * Esta comprobacion quiere decir que es una funcion pero no ha sido asignada a ninguna variable ->
                 * Hay que mostrar un warning minimo. De momento mostramos error puesto que el codigo generado sin
                 * asignacion es incorrecto
                 */
                if (proc is Function) 
                    err.addError("Function '" + proc.Name + "' hasn't be assigned to a variable", id.getLine(),
                                 id.getColumn());     

                try 
                {
                    if (proc.checkParams(lista))
                        cgen.genCall(proc, lista, scope, proc_actual);
                } catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }        
            }
        } else {
          cgen.genWriteLn(proc_actual, scope, lista);
          }
       }
     )
;

listaArgumentos [ArrayList lista]:
  #(LISTA_ARGUMENTOS (argType[lista])+ {})
;

argType [ArrayList lista]:
{
    Symbol s = null;
} 
    id2:IDENT
    {   
        try
        {
            if (scope == 0) 
                s = symtab.find(id2.getText());
            else 
                s = symtab.findInAllScopes(proc_actual, id2.getText());
            if (s != null)
                lista.Add(s);
         } catch (fpc2ilException ex) { err.addError(ex.Message, id2.getLine(), id2.getColumn()); }        
    }
    | (a:LIT_ENTERO { Symbol s = new Symbol(a.getText(), new Type()); s.Type = new Type (Type.T.INT,0,null); s.Literal = true; lista.Add(s); }
    | (b:LIT_REAL { Symbol s = new Symbol(b.getText(), new Type()); s.Type = new Type (Type.T.REAL,0,null); s.Literal = true; lista.Add(s); }
    | (c:LIT_CIERTO { Symbol s = new Symbol(c.getText(), new Type()); s.Type = new Type (Type.T.BOOLEAN,0,null); s.Literal = true; lista.Add(s); }
    | (d:LIT_FALSO { Symbol s = new Symbol(d.getText(), new Type()); s.Type  = new Type (Type.T.BOOLEAN,0,null); s.Literal = true; lista.Add(s); }
    | (f:LIT_CHAR { Symbol s = new Symbol(f.getText(), new Type()); s.Type  = new Type (Type.T.CHAR,0,null); s.Literal = true; lista.Add(s); }
    | (e:LIT_CADENA {  Symbol s = new Symbol(e.getText(), new Type()); s.Type = new Type (Type.T.STRING,0,null); s.Literal = true; lista.Add(s); } ))))))
;

sentencia_compuesta:
    condicional
    | bucle
    ;

condicional
{
    ArrayList expS = new ArrayList();
    Emit.Label ifLabel = new System.Reflection.Emit.Label();
    Emit.Label orlabel = new System.Reflection.Emit.Label();

    bool elseStatement = false;
    bool hasOr = false;
}
:
    #(RES_IF expresion[expS] 
      {
        cgen.DefineLabel(ref ifLabel);
        hasOr = eutils.hasToGenOrLabel(expS);
        eutils.genIfExpresion(cgen, expS, scope, proc_actual, ifLabel, ref orlabel);
        if (hasOr)
            cgen.MarkLabel(orlabel);
        hasOr = false;
      }
      sentencias (expresionElse[ref ifLabel, ref elseStatement])?)
      {
          if (!elseStatement)
            cgen.MarkLabel(ifLabel);
      }
    ;

expresionElse [ref Emit.Label label, ref bool elseStatement]:
{
    Emit.Label elseLabel = new System.Reflection.Emit.Label();
}
    #(RES_ELSE 
      {
        elseStatement = true;
        cgen.genElseStatement(ref elseLabel);
        cgen.MarkLabel(label);
      }
      sentencias)
      {
          cgen.MarkLabel(elseLabel);
      }
    ;

bucle:
      efor
    | ewhile
    | erepeat
    ;

efor:
{
    Symbol to = null;
    string ident = "";
    Emit.Label forLabel = new System.Reflection.Emit.Label();
    Emit.Label forBody = new System.Reflection.Emit.Label();
}
    #(RES_FOR id:IDENT
    {
        ident = id.getText();
    } 
    listaFor[ident, ref to, ref forLabel, ref forBody] sentencias)
    {
        cgen.genEndForStatement(scope, proc_actual, ident, to, ref forLabel, ref forBody);
    }
     ;

listaFor [string control_var, ref Symbol to, ref Emit.Label forLabel, ref Emit.Label forBody]:
{
    Symbol ini;
    Symbol fin;
}
    #(RES_TO ini=valor_for fin=valor_for)
    {
        to = fin;
        cgen.genForStatement(scope, proc_actual, control_var, ini, ref forLabel, ref forBody);
    }
    ;

valor_for returns [Symbol x]
{
    x = null;
}
: id:IDENT 
    {
        if (scope == 0)
            x = symtab.find(id.getText());
        else 
            x = symtab.findInAllScopes(proc_actual, id.getText());
    }
    | lit:LIT_ENTERO 
    {
        x = new Symbol(lit.getText(), new Type());
        x.Type = new Type (Type.T.INT,0,null);
    }
;
    
ewhile
{
    ArrayList expS = new ArrayList();
    Emit.Label whileLabel = new System.Reflection.Emit.Label();
    Emit.Label whileBody = new System.Reflection.Emit.Label();
    Emit.Label whileEnd = new System.Reflection.Emit.Label();
}
:
    #(RES_WHILE expresion[expS] 
      {
        cgen.genWhileStatement(ref whileLabel, ref whileBody);
      }
       sentencias)
      {
        cgen.DefineLabel(ref whileEnd);
        eutils.genWhileExpresion(cgen, expS, scope, proc_actual, whileLabel, whileBody, whileEnd);
        cgen.MarkLabel(whileEnd);
      }
    ;

erepeat
{
    ArrayList expS = new ArrayList();
    Emit.Label repeatLabel = new System.Reflection.Emit.Label();
    Emit.Label repeatBody = new System.Reflection.Emit.Label();
    Emit.Label repeatEnd = new System.Reflection.Emit.Label();
}
:
    #(RES_REPEAT 
      {
       cgen.genWhileStatement(ref repeatLabel, ref repeatBody);
      }
      sentencias expresion[expS])
      {
          cgen.DefineLabel(ref repeatEnd);
          eutils.genRepeatExpresion(cgen, expS, scope, proc_actual, repeatLabel, repeatBody, repeatEnd);
          cgen.MarkLabel(repeatEnd);
      }
    ;
