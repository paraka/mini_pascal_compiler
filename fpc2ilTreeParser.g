header {
    using System.Collections;
    using System.Collections.Generic;
    using ASTEnumeration = antlr.collections.AST;
}
options
{
    language=CSharp;
}

class fpc2ilTreeParser extends TreeParser;
options
{
    importVocab=fpc2ilparserVocab;
    exportVocab=fpc2iltreeparserVocab;
    buildAST=true;
}
{
    private Symboltable symtab;
    private Errors err;
    private string proc_actual = "";
    private uint scope = 0;
    private fpc2ilTypeChecking tcheck = null;
}

programa
{
        symtab = Symboltable.Instance;
        err = Errors.Instance;
        tcheck = new fpc2ilTypeChecking();
}
: #(PROGRAMA (declaracionPrograma)+ bloque)
;

declaracionPrograma
{
    Symbol s;
}
: #(RES_PROGRAM id:IDENT)
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
    Procedure aux = null;
    int line = 0;
    int col = 0;
}
: (s=decCte[ref line, ref col]) {
    if (scope == 0)
    {
        try 
        { 
            symtab.add(s); 
        } catch (fpc2ilException e) { err.addError(e.Message, line, col); }
    } 
    else 
    {
        try 
        {
            aux = (Procedure)symtab.find(proc_actual);
        } catch (fpc2ilException e) { err.addError(e.Message, line, col); }
        try
        {
            aux.addToLocals(s);
        } catch (fpc2ilException e) { err.addError(e.Message, line, col); }
    }
}
;

/* 
 * Debemos averigiar el tipo de la constante 
 * para poder hacer el analisis semantico correcto 
 */
decCte [ref int line, ref int col] returns [Constant s]
{
    s = null;
}
: #(OP_IGUAL id:IDENT {
       s = new Constant(id.getText(), new Type());
       } (i:LIT_ENTERO {
            s.Type = new Type (Type.T.INT,0,null);
            s.Value = i.getText();
            line = i.getLine();
            col = i.getColumn();
        } | (d:LIT_REAL {
            s.Type = new Type (Type.T.REAL,0,null);
            s.Value = d.getText();
            line = d.getLine();
            col = d.getColumn();
        } | (t:LIT_CIERTO {
            s.Type = new Type (Type.T.BOOLEAN,0,null);
            s.Value = t.getText();
            line = t.getLine();
            col = t.getColumn();
        } | (f:LIT_FALSO {
            s.Type = new Type (Type.T.BOOLEAN,0,null);
            s.Value = f.getText();
            line = f.getLine();
            col = f.getColumn();
        } | (c:LIT_CADENA {
            if (c.getText().Length > 1)
            {
                s.Type = new Type (Type.T.STRING,0,null);
                s.Value = c.getText();
            } 
            else
            {
                s.Type = new Type (Type.T.CHAR,0,null);
                s.Value = c.getText();
            }
            line = c.getLine();
            col = c.getColumn();
        } )))))
     )
;

/* VARIABLES */
decVar:
    #(RES_VAR (declaracionVariable)+)
;

declaracionVariable
{
    Symbol s;
    Procedure aux = null;
    int line = 0;
    int col = 0;
}
: (s=decVariable[ref line, ref col]) {
    if (scope == 0) 
    {
        try 
        {
            symtab.add(s);
        } catch (fpc2ilException e) { err.addError(e.Message, line, col); }
    } 
    else 
    {
        try
        {
          aux = (Procedure)symtab.find(proc_actual);
        } catch (fpc2ilException e) { err.addError(e.Message, line, col); }
        try
        {
            aux.addToLocals(s);
        } catch (fpc2ilException e) { err.addError(e.Message, line, col); }
    }
}
;

decVariable [ref int line, ref int col] returns [Symbol s]
{
    s = null;
}
: #(DOS_PUNTOS id:IDENT tp:tipo {
       line = id.getLine();
       col = id.getColumn();
       s = new Symbol(id.getText(), new Type());
       switch (tp.getText()) 
       {
        case "integer":
            s.Type = new Type (Type.T.INT,0,null);
            break;
        case "char":
            s.Type = new Type (Type.T.CHAR,0,null);
            break;
        case "real":
            s.Type = new Type (Type.T.REAL,0,null);
            break;
        case "boolean":
            s.Type = new Type (Type.T.BOOLEAN,0,null);
            break;
        case "string":
            s.Type = new Type (Type.T.STRING,0,null);
            break;
       }
    } 
   )
;

tipo: 
  TIPO_ENTERO
 | TIPO_REAL
 | TIPO_CHAR
 | TIPO_BOOLEANO
 | TIPO_CADENA
 ;

/* PROCEDIMIENTOS Y FUNCIONES */

decprocedimiento
{
    Procedure s;
}
: #(RES_PROCEDURE s=procParamActual (sparametros)?{
    s.Type = new Type( Type.T.PROC, 0, s.Type);
    scope = 1;
} bloque )
;

sparametros
{
    uint argnum = 0;
    Hashtable parametros = new Hashtable();
    Procedure s;
    int line = 0;
    int col = 0;
}
: #(PARAMETROS (listaParametros[parametros, ref argnum, ref line, ref col])? {
    try
    {
        Procedure aux = (Procedure)symtab.find(proc_actual);
        aux.Parameters = parametros;
    } catch (fpc2ilException e) { err.addError(e.Message, line, col); }
})
;

listaParametros [Hashtable parametros, ref uint argnum, ref int line, ref int col]
: (declaracionParametroRef[parametros, ref argnum, ref line, ref col]
   | declaracionParametroValor[parametros, ref argnum, ref line, ref col])+
;

declaracionParametroRef [Hashtable parametros, ref uint argnum, ref int line, ref int col]
{
    Param p = null;
}
: #(RES_VAR id:IDENT ty:tipo { 
    line = id.getLine();
    col = id.getColumn();
    p = new Param(id.getText(), new Type(), argnum++, true);
    switch (ty.getText())
       {
        case "integer":
            p.Type = new Type (Type.T.INT,0,null);
            break;
        case "char":
            p.Type = new Type (Type.T.CHAR,0,null);
            break;
        case "real":
            p.Type = new Type (Type.T.REAL,0,null);
            break;
        case "boolean":
            p.Type = new Type (Type.T.BOOLEAN,0,null);
            break;
        case "string":
            p.Type = new Type (Type.T.STRING,0,null);
            break;
       }
       try 
       {
            parametros.Add(p.Name, p);
       } 
       catch (ArgumentException e) 
       {
            err.addError("Parameter '" + p.Name + "' has been previously defined", id.getLine(), id.getColumn());
       }
    } 
   )
;

declaracionParametroValor [Hashtable parametros, ref uint argnum, ref int line, ref int col]
{
    Param p = null;
}
: (id:IDENT ty:tipo { 
    line = id.getLine();
    col = id.getColumn();
    p = new Param(id.getText(), new Type(), argnum++, false);
    switch (ty.getText())
       {
        case "integer":
            p.Type = new Type (Type.T.INT,0,null);
            break;
        case "char":
            p.Type = new Type (Type.T.CHAR,0,null);
            break;
        case "real":
            p.Type = new Type (Type.T.REAL,0,null);
            break;
        case "boolean":
            p.Type = new Type (Type.T.BOOLEAN,0,null);
            break;
        case "string":
            p.Type = new Type (Type.T.STRING,0,null);
            break;
       }
       try 
       {
            parametros.Add(p.Name, p);
       } 
       catch (ArgumentException e) 
       {
            err.addError("Parameter '" + p.Name + "' has been previously defined", id.getLine(), id.getColumn());
       }
    } 
   )
;


procParamActual returns [Procedure s]
{
    s = null;
}
: #(id:IDENT {
    s = new Procedure( id.getText(), new Type());
    try
    {
        symtab.add(s);
    } catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
    proc_actual = id.getText();
    }
   )
;

funcParamActual returns [Function s]
{
    s = null;
}
: #(id:IDENT {
    s = new Function( id.getText(), new Type());
    try
    {
        symtab.add(s);
    } catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
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
    s.Type = new Type( Type.T.FUNC, 0, null);
    scope = 1;
   }  
   ty:tipo {
    switch (ty.getText())
       {
        case "integer":
            s.TypeReturn= new Type (Type.T.INT,0,null);
            break;
        case "char":
            s.TypeReturn= new Type (Type.T.CHAR,0,null);
            break;
        case "real":
            s.TypeReturn = new Type (Type.T.REAL,0,null);
            break;
        case "boolean":
            s.TypeReturn = new Type (Type.T.BOOLEAN,0,null);
            break;
        case "string":
            s.TypeReturn = new Type (Type.T.STRING,0,null);
            break;
       }
    }
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
        }
        //Console.WriteLine("BLOQUE SCOPE: " + scope);
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
    string etipo = null;
    ArrayList lexpresiones = new ArrayList();
}
    #(OP_ASSING id:IDENT expresion[lexpresiones]
    {
      if (scope == 0)
      {
        try 
        {
            s = symtab.find(id.getText());
        } catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
      }
      else
      {
        try 
        {
            s = symtab.findInAllScopes(proc_actual, id.getText());
        } catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
      }
      
      if (s != null) 
      {
        //No podemos asignar a una constante
        if (s is Constant)
            err.addError("Constant '" + s.Name + "' can't be assigned a value", id.getLine(), id.getColumn());

        string checkType = s.Type.toString();

        if (s is Function)
        {
            Function aux = (Function)s;
            checkType = aux.TypeReturn.toString();
        }

        if (!tcheck.checkTypeExpression(checkType, lexpresiones, ref etipo))
            err.addError("Cannot assing type (" + etipo + ") to variable '" + s.Name + "' (" + s.Type.toString() + ")",
                         id.getLine(), id.getColumn());
      }
     })
    ;
 
expresion [ArrayList lexpr]:
 #(OP_IGUAL a:expresion[lexpr] b:expresion[lexpr]) 
    { 
        BooleanExpresion bol = new BooleanExpresion();
        lexpr.Add(bol);
    }
| #(OP_DISTINTO c:expresion[lexpr] d:expresion[lexpr]) 
    { 
        BooleanExpresion bol = new BooleanExpresion();
        lexpr.Add(bol);
    }
| #(OP_MENOR f:expresion[lexpr] g:expresion[lexpr])
    { 
        BooleanExpresion bol = new BooleanExpresion();
        lexpr.Add(bol);
    }
| #(OP_MENOR_IGUAL h:expresion[lexpr] i:expresion[lexpr])
    { 
        BooleanExpresion bol = new BooleanExpresion();
        lexpr.Add(bol);
    }
| #(OP_MAYOR_IGUAL j:expresion[lexpr] k:expresion[lexpr])
    { 
        BooleanExpresion bol = new BooleanExpresion();
        lexpr.Add(bol);
    }
| #(OP_MAYOR l:expresion[lexpr] m:expresion[lexpr])
    { 
        BooleanExpresion bol = new BooleanExpresion();
        lexpr.Add(bol);
    }
| #(OP_MAS n:expresion[lexpr] (o:expresion[lexpr])?) 
    { 
        Expr exp1 = tcheck.getExpresion(n.getText(), scope, proc_actual);
        Expr exp2 = tcheck.getExpresion(o.getText(), scope, proc_actual);
        PlusExpresion plus = new PlusExpresion();
        if (exp1 != null)
            plus.Left = exp1;
        if (exp2 != null)
            plus.Right = exp2;

        lexpr.Add(plus);
    }
| #(OP_MENOS p:expresion[lexpr] (q:expresion[lexpr])?)
    { 
        Expr exp1 = tcheck.getExpresion(p.getText(), scope, proc_actual);
        Expr exp2 = tcheck.getExpresion(q.getText(), scope, proc_actual);
        MinusExpresion minus = new MinusExpresion();
        if (exp1 != null)
            minus.Left = exp1;
        if (exp2 != null)
            minus.Right = exp2;

        lexpr.Add(minus);
    }
| #(OP_O r:expresion[lexpr] s:expresion[lexpr]) 
    { 
        ORExpresion or = new ORExpresion();
        lexpr.Add(or);
    }
| #(OP_PRODUCTO t:expresion[lexpr] u:expresion[lexpr])
    {
        Expr exp1 = tcheck.getExpresion(t.getText(), scope, proc_actual);
        Expr exp2 = tcheck.getExpresion(u.getText(), scope, proc_actual);
        ProductoExpresion star = new ProductoExpresion();
        if (exp1 != null)
            star.Left = exp1;
        if (exp2 != null)
            star.Right = exp2;

        lexpr.Add(star);
    }
| #(OP_DIVISION v:expresion[lexpr] w:expresion[lexpr])
    {
        Expr exp1 = tcheck.getExpresion(v.getText(), scope, proc_actual);
        Expr exp2 = tcheck.getExpresion(w.getText(), scope, proc_actual);
        DivisionExpresion divis = new DivisionExpresion();
        if (exp1 != null)
            divis.Left = exp1;
        if (exp2 != null)
            divis.Right = exp2;

        lexpr.Add(divis);
    }
| #(OP_DIV x:expresion[lexpr] y:expresion[lexpr])
    {
        Expr exp1 = tcheck.getExpresion(x.getText(), scope, proc_actual);
        Expr exp2 = tcheck.getExpresion(y.getText(), scope, proc_actual);
        DIVExpresion div = new DIVExpresion();
        if (exp1 != null)
            div.Left = exp1;
        if (exp2 != null)
            div.Right = exp2;

        lexpr.Add(div);
    }
| #(OP_MOD z:expresion[lexpr] a1:expresion[lexpr])
    {
        Expr exp1 = tcheck.getExpresion(z.getText(), scope, proc_actual);
        Expr exp2 = tcheck.getExpresion(a1.getText(), scope, proc_actual);
        MODExpresion mod = new MODExpresion();
        if (exp1 != null)
            mod.Left = exp1;
        if (exp2 != null)
            mod.Right = exp2;

        lexpr.Add(mod);
    }
| #(OP_Y a2:expresion[lexpr] a3:expresion[lexpr]) 
    { 
        ANDExpresion and = new ANDExpresion();
        lexpr.Add(and);
    }
| #(OP_NEG a4:expresion[lexpr]) 
    { 
        NOTExpresion neg = new NOTExpresion();
        lexpr.Add(neg);
    }
| id:IDENT 
    { 
      Symbol sym = null;
      Variable var = null;

        /* 
         * Todas pasan por aqui luego aqui 
         * comprobamos si estan en la tabla 
         * de simbolos para mostrar error 
         */
      if (scope == 0)
      {
          try 
          {
            sym = symtab.find(id.getText()); 
          } catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
      } 
      else
      {
          try 
          {
            sym = symtab.findInAllScopes(proc_actual, id.getText());
          } catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
      }

      if (sym != null)
      {
          switch (sym.Type.toString())
          {
            case "PROC":
              err.addError("VOID type procedure '" + sym.Name + "' can't be assigned to any variable", id.getLine(),
                           id.getColumn());
              break;
            case "INT":
              var = new Variable();
              var.Tipo = "INT";
              var.Value = sym.Name;
              break;
            case "CHAR":
              var = new Variable();
              var.Tipo = "CHAR";
              var.Value = sym.Name;
              break;
            case "REAL":
              var = new Variable();
              var.Tipo = "REAL";
              var.Value = sym.Name;
              break;
            case "STRING":
              var = new Variable();
              var.Tipo = "STRING";
              var.Value = sym.Name;
              break;
            case "BOOLEAN":
              var = new Variable();
              var.Tipo = "BOOLEAN";
              var.Value = sym.Name;
              break;
          }

          lexpr.Add(var);
      }
    }
    | ct1: LIT_ENTERO   { IntLiteral ict1 = new IntLiteral(); ict1.Value = ct1.getText(); lexpr.Add(ict1); }
    | ct2: LIT_REAL     { RealLiteral ict2 = new RealLiteral(); ict2.Value = ct2.getText(); lexpr.Add(ict2); }
    | ct3: LIT_CIERTO   { BoolLiteral ict3 = new BoolLiteral(); ict3.Value = ct3.getText(); lexpr.Add(ict3); }
    | ct4: LIT_FALSO    { BoolLiteral ict4 = new BoolLiteral(); ict4.Value = ct4.getText(); lexpr.Add(ict4); }
    | ct5: LIT_CADENA   { 
                          if (ct5.getText().Length > 1 ) 
                          {
                            StringLiteral ict5 = new StringLiteral(); 
                            ict5.Value = ct5.getText(); lexpr.Add(ict5); 
                          }
                          else
                          {
                            CharLiteral ict6 = new CharLiteral();
                            ict6.Value = ct5.getText(); lexpr.Add(ict6); 
                          }
                        }
| llamadaFuncion {} //Esto se hace en la pasada de generacion de codigo que ya tenemos resueltos todos los nombres de funcion
;

llamadaFuncion:
    #(LLAMADA_FUNCION id:IDENT (listaArgumentos)?)
    ;

llamada_proc:
    #(LLAMADA_PROC id:IDENT (listaArgumentos)?)
    ;

listaArgumentos: 
    #(LISTA_ARGUMENTOS (argType)+)
    ;

argType: 
    id2:IDENT
    | (LIT_ENTERO
    | (LIT_REAL
    | (LIT_CHAR
    | (LIT_CIERTO
    | (LIT_FALSO
    | (LIT_CADENA ))))))
    ;

sentencia_compuesta:
    condicional
    | bucle
    ;

condicional:
    {
        ArrayList lexpresiones = new ArrayList();
    }
    #(RES_IF a:expresion[lexpresiones] sentencias (expresionElse)?)
        {
            if (!tcheck.checkBooleanExpresion(lexpresiones))
                err.addError("In IF statement: condition must be a BOOLEAN expression", a.getLine(), a.getColumn());
        }
    ;

expresionElse:
    #(RES_ELSE sentencias)
    ;

bucle:
      efor
    | ewhile
    | erepeat
    ;

efor:
{
    Symbol s = null;
}
    #(RES_FOR id:IDENT
    {
        if (scope == 0)
        {
            try 
            {
                s = symtab.find(id.getText());
            } catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
        }
        else
        {
            try 
            {
                s = symtab.findInAllScopes(proc_actual, id.getText());
            } catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
        }
    } listaFor[s] sentencias)
     ;

listaFor [Symbol s]:
{
    Symbol ini;
    Symbol fin;
    int line = 0;
    int col = 0;
}
    #(RES_TO ini=valor_for[ref line, ref col] fin=valor_for[ref line, ref col])
{
    if (s != null && ini != null && fin != null)
    {
        string ini_type = ini.Type.toString();
        string fin_type = fin.Type.toString();
        string control_var = s.Type.toString();
        if (ini_type != "INT")
            err.addError("In for statement: Variable '" + ini.Name + "' has to be INTEGER but founded " + ini_type,
                         line, col);
        if ( fin_type != "INT")
            err.addError("In for statement: Variable '" + fin.Name + "' has to be INTEGER but founded " + fin_type,
                         line, col);
        if ( control_var != "INT")
            err.addError("In for statement: Variable '" + s.Name + "' has to be INTEGER but founded " + control_var,
                         line, col);
    }
}
    ;

valor_for [ref int line, ref int col] returns [Symbol x]
{
    x = null;
}
: id:IDENT 
    {
        if (scope == 0)
        {
            try {
                x = symtab.find(id.getText());
            } catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
        } 
        else
        {
            try {
                x = symtab.findInAllScopes(proc_actual, id.getText());
            } catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
        }

        line = id.getLine();
        col = id.getColumn();
    }
    | lit:LIT_ENTERO 
    {
        x = new Symbol(lit.getText(), new Type());
        x.Type = new Type (Type.T.INT,0,null);
        line = lit.getLine();
        col = lit.getColumn();
    }
;
    
ewhile:
    {
        ArrayList lexpresiones = new ArrayList();
    }
    #(RES_WHILE a:expresion[lexpresiones] sentencias)
        {
            if (!tcheck.checkBooleanExpresion(lexpresiones))
                err.addError("In WHILE statement: condition must be a BOOLEAN expression", a.getLine(), a.getColumn());
        }
    ;

erepeat:
    {
        ArrayList lexpresiones = new ArrayList();
    }
    #(RES_REPEAT sentencias a:expresion[lexpresiones])
        {
            if (!tcheck.checkBooleanExpresion(lexpresiones))
                err.addError("In REPEAT statement: condition must be a BOOLEAN expression", a.getLine(), a.getColumn());
        }
    ;
