using System;
using System.Collections;
using System.Collections.Generic;
using Emit = System.Reflection.Emit;

public class ExpUtils
{
    private Symboltable symtab;
    private Errors err;

    public ExpUtils() 
    {
        symtab = Symboltable.Instance;
        err = Errors.Instance;
    }

    public bool hasToGenOrLabel (ArrayList list)
    {
        foreach (Expr e in list)
            if (e is ORExpresion)
                return true;
        return false;
    }

    public bool hasToGenAndLabel (ArrayList list)
    {
        foreach (Expr e in list)
            if (e is ANDExpresion)
                return true;
        return false;
    }

    private bool hasAndOrNotExpression (ArrayList list)
    {
        foreach (Expr e in list)
            if (e is ORExpresion || e is ANDExpresion || e is NOTExpresion)
                return true;
        return false;
    }

    private Expr ReturnOppositeExpression (Expr e, string proc_actual, uint scope)
    {
        if (e is GEExpresion)
        {
            LTExpresion ex = new LTExpresion();
            return ex;
        }
        else if (e is GTExpresion)
        {
            LEExpresion ex= new LEExpresion();
            return ex;
        }
        else if (e is LTExpresion)
        {
            GEExpresion ex = new GEExpresion();
            return ex;
        }
        else if (e is LEExpresion)
        {
            GTExpresion ex = new GTExpresion();
            return ex;
        }
        else if (e is EQExpresion)
        {
            DFExpresion ex = new DFExpresion();
            return ex;
        }
        else if (e is DFExpresion)
        {
            EQExpresion ex = new EQExpresion();
            return ex;
        }
        else if (e is BoolLiteral)
        {
            BoolLiteral b = (BoolLiteral)e;
            if (b.Value == "true")
                b.Value = "false";
            else
                b.Value = "true";

            return b;
        }
        else if (e is Variable)
        {
            int tipo = 0;
            Variable b = (Variable)e;
            Symbol s;
            if (scope == 0)
                s = symtab.getSymbol(b.Value);
            else
                s = symtab.getSymbol(proc_actual, b.Value, ref tipo);
            if (s != null)
            {
                if (s.Type.toString() == "BOOLEAN")
                {
                    b.Tipo = "NOT"; /* marcamos diferente para saber que hay un not */
                }
            }
            return b;
        }
        else
            return e;

        return null;
    }

    private void ReorderWHILEExpression (ArrayList list, string proc_actual, uint scope)
    {
        ArrayList aux = (ArrayList)list.Clone();
        if (this.hasAndOrNotExpression(list))
        {
            int i = 0;
            foreach (Expr e in aux)
            {
                //TODO: Por separado funcionan ahora hay que ver con los NOTs en derecha e izda!!
                if (e is ANDExpresion)
                {
                    Expr a = ReturnOppositeExpression((Expr)aux[i + 1], proc_actual, scope);
                    Expr b = (Expr)aux[i - 1];
                    Expr c = (Expr)aux[i - 2];
                  /*  Console.WriteLine("A : "+ a);
                    Console.WriteLine("B : "+ b);
                    Console.WriteLine("C : "+ c);
                    */
                    if (!(a is NOTExpresion))
                    {
                        if (c is NOTExpresion)
                        {
                            list.RemoveAt(i);
                            list.RemoveAt(i-1);
                            list.RemoveAt(i-2);
                            list.Insert(i-2, a);
                            list.Insert(i-2, b);
                        }
                        else
                        {
                            if (b is NOTExpresion)
                            {
                                list.RemoveAt(i);
                                list.RemoveAt(i-1);
                                list.RemoveAt(i-2);
                                list.Insert(i-2,c);
                                list.Insert(i-2,a);
                            }
                            else
                            {
                                list.RemoveAt(i);
                                list.RemoveAt(i);
                                list.RemoveAt(i-1);
                                list.Insert(i-1,b);
                                list.Insert(i-1,a);
                            }
                        }
                    }
                    else
                    {
                        list.RemoveAt(i);
                        list.RemoveAt(i-1);
                        list.RemoveAt(i-2);
                        list.Insert(i-2,c);
                        list.Insert(i-2,b);
                    }
                }
                else if (e is ORExpresion)
                {
                    Expr a = (Expr)aux[i-1];
                    Expr b = (Expr)aux[i+1];
                    list.RemoveAt(i);
                    list.RemoveAt(i);
                    list.RemoveAt(i-1);
                    list.Insert(i-1,a);
                    list.Insert(i-1,b);
                }
                else if (e is NOTExpresion)
                {
                    Expr a = ReturnOppositeExpression((Expr)aux[i-1], proc_actual, scope);
                    if (a is Variable)
                    {
                        Variable var = (Variable)a;
                        if (var.Tipo == "NOT")
                            list.RemoveAt(i);
                        else
                        {
                            Expr b = ReturnOppositeExpression((Expr)aux[i+2], proc_actual, scope);
                            list.RemoveAt(i);
                            list.RemoveAt(i+1);
                            list.Insert(i+1, b);
                        }
                    }
                }
                i++;
            }
        }
    }

    private void ReorderIFExpression (ArrayList list, string proc_actual, uint scope)
    {
        ArrayList aux = (ArrayList)list.Clone();
        if (this.hasAndOrNotExpression(list))
        {
            int i = 0;
            foreach (Expr e in aux)
            {
                if (e is ANDExpresion)
                {
                    Expr a = (Expr)aux[i - 1];
                    Expr b = (Expr)aux[i + 1];
                    Expr c = (Expr)aux[i - 2];
                    if (!(a is NOTExpresion))
                    {
                        if (c is NOTExpresion)
                        {
                            list.RemoveAt(i);
                            list.RemoveAt(i-1);
                            list.RemoveAt(i-2);
                            list.Insert(i-2, a);
                            list.Insert(i-2, b);
                        }
                        else 
                        {
                            list.RemoveAt(i);
                            list.RemoveAt(i);
                            list.RemoveAt(i-1);
                            list.Insert(i-1, a);
                            list.Insert(i-1, b);
                        }
                    } 
                    else
                    {
                        list.RemoveAt(i);
                        list.RemoveAt(i-1);
                        list.RemoveAt(i-2);
                        list.Insert(i-2, c);
                        list.Insert(i-2, b);
                    }
                }
                else if (e is ORExpresion)
                {
                    Expr a = (Expr)aux[i - 1];
                    Expr c = ReturnOppositeExpression((Expr)aux[i+1], proc_actual, scope);
                    Expr d = (Expr)aux[i-2];
                    if (!(a is NOTExpresion))
                    {
                        if (d is NOTExpresion)
                        {
                            list.RemoveAt(i);
                            list.RemoveAt(i-1);
                            list.RemoveAt(i-2);
                            list.Insert(i-2, a);
                            list.Insert(i-2, c);
                        }
                        else
                        {
                            list.RemoveAt(i);
                            list.RemoveAt(i);
                            list.RemoveAt(i-1);
                            list.Insert(i-1, a);
                            list.Insert(i-1, c);
                        }
                    }
                    else
                    {
                        list.RemoveAt(i);
                        list.RemoveAt(i-1);
                        list.RemoveAt(i-2);
                        list.Insert(i-2, d);
                        list.Insert(i-2, c);
                    }
                }
                else if (e is NOTExpresion)
                {
                    Expr a = ReturnOppositeExpression((Expr)aux[i-1], proc_actual, scope);
                    if (a is Variable)
                    {
                        Variable var = (Variable)a;
                        if (var.Tipo == "NOT")
                            list.RemoveAt(i);
                        else
                        {
                            Expr b = ReturnOppositeExpression((Expr)aux[i+2], proc_actual, scope);
                            list.RemoveAt(i);
                            list.RemoveAt(i+1);
                            list.Insert(i+1, b);
                        }
                    }
                    else if (a is BoolLiteral)
                    {
                        list.RemoveAt(i);
                        list.RemoveAt(i-1);
                        list.Insert(i-1, a);
                    }
                }
                i++;
            }
        }
    }

    public void genAritExpresion (ILCodeGen cg, ArrayList exp, uint scope, 
                                  string proc_actual, string store)
    {
        int tipo = 0;
        Symbol s = null;

        foreach (Expr e in exp)
        {
            if (e is IntLiteral)
            {
                IntLiteral lit = (IntLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.INT,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
            }
            else if (e is RealLiteral)
            {
                RealLiteral lit = (RealLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.REAL,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
            }
            else if (e is BoolLiteral)
            {
                BoolLiteral lit = (BoolLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.BOOLEAN,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
            }
            else if (e is StringLiteral)
            {
                StringLiteral lit = (StringLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.STRING,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
            }
            else if (e is CharLiteral)
            {
                CharLiteral lit = (CharLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.CHAR,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
            }
            else if (e is Variable)
            {
                Variable var = (Variable)e;
                if (scope == 0)
                    s = symtab.getSymbol(var.Value);
                else
                    s = symtab.getSymbol(proc_actual, var.Value, ref tipo);
                if (s != null)
                {
                    if (tipo == 1)
                    {
                        Param p = (Param)s;
                        cg.loadVariable(s, p.Reference, scope, proc_actual);
                    }
                    else
                        cg.loadVariable(s, false, scope, proc_actual);
                }
                tipo = 0;
            }
            else if (e is Function)
            {
                ExpFunction ex = (ExpFunction)e;
                if (scope == 0)
                    s = symtab.find(store);
                else
                    s = symtab.getSymbol(proc_actual, store, ref tipo);

                if (s != null)
                {
                    if (s.Type.toString() != ex.Tipo)
                        throw new fpc2ilException("Cannot assing type " + ex.Tipo + " to variable '" + s.Name + "' (" +
                                     s.Type.toString() + ")");
                }
                tipo = 0;
            }
            else if (e is PlusExpresion)
            {
                cg.genSuma();
            }
            else if (e is MinusExpresion)
            {
                cg.genResta();
            }
            else if (e is ProductoExpresion)
            {
                cg.genMult();
            }
            else if (e is DivisionExpresion)
            {
                cg.genDivision();
            }
            else if (e is DIVExpresion)
            {
                cg.genDivision();
            }
            else if (e is MODExpresion)
            {
                cg.genMod();
            }
        }

        /* Una vez estan generados todos los loads generamos el store */
        if (scope == 0)
            s = symtab.getSymbol(store);
        else
            s = symtab.getSymbol(proc_actual, store, ref tipo);

        if (s != null)
        {
            if (tipo == 1)
            {
                Param p = (Param)s;
                cg.storeVariable (s, p.Reference, scope, proc_actual);
            }
            else
            {
                /* TODO: Si es una variable de retorno de funcion de momento no hacemos nada */
                if (s.Name != proc_actual)
                    cg.storeVariable (s, false, scope, proc_actual);
            }
        }
    }

    public void genWhileExpresion (ILCodeGen cg, ArrayList exp, uint scope, string proc_actual, 
                                   Emit.Label ini, Emit.Label body, Emit.Label fin)
    {
        int tipo = 0;
        Symbol s = null;

        bool hasAnd = hasToGenAndLabel(exp);
        bool hasAnd2 = hasAnd;

        ReorderWHILEExpression(exp, proc_actual, scope);

        cg.MarkLabel(ini);

        foreach (Expr e in exp)
        {
            //Console.WriteLine(e);
            if (e is IntLiteral)
            {
                IntLiteral lit = (IntLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.INT,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
            }
            else if (e is RealLiteral)
            {
                RealLiteral lit = (RealLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.REAL,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
            }
            else if (e is BoolLiteral)
            {
                BoolLiteral lit = (BoolLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.BOOLEAN,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
                if (hasAnd)
                {
                    if (lit.Value == "true")
                        cg.genFalseStatement(fin);
                    else
                        cg.genFalseStatement(fin);
                } 
                else
                {
                    if (hasAnd2)
                    {
                        if (lit.Value == "true")
                            cg.genTrueStatement(body);
                        else
                            cg.genFalseStatement(fin);
                    }
                    else
                    {
                        if (lit.Value == "true")
                            cg.genTrueStatement(body);
                        else
                            cg.genFalseStatement(body);
                    }
                    hasAnd2 = false;
                }
                hasAnd = false;
            }
            else if (e is StringLiteral)
            {
                StringLiteral lit = (StringLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.STRING,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
            }
            else if (e is CharLiteral)
            {
                CharLiteral lit = (CharLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.CHAR,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
            }
            else if (e is Variable)
            {
                Variable var = (Variable)e;
                if (scope == 0)
                    s = symtab.getSymbol(var.Value);
                else
                    s = symtab.getSymbol(proc_actual, var.Value, ref tipo);
                if (s != null)
                {
                    if (tipo == 1)
                    {
                        Param p = (Param)s;
                        cg.loadVariable(s, p.Reference, scope, proc_actual);
                    }
                    else
                        cg.loadVariable(s, false, scope, proc_actual);
                }
                tipo = 0;
                if (s.Type.toString() == "BOOLEAN")
                {
                    if (var.Tipo == "NOT")
                        cg.genTrueStatement(fin);
                    else
                        cg.genFalseStatement(fin);
                    hasAnd = false;
                }
            }
            else if (e is Function)
            {
                ExpFunction ex = (ExpFunction)e;
            }
            else if (e is EQExpresion)
            {
                if (hasAnd)
                    cg.genEQStatement(fin);
                else
                    cg.genEQStatement(body);
                hasAnd = false;
            }
            else if (e is DFExpresion)
            {
                if (hasAnd)
                    cg.genDFStatement(fin);
                else
                    cg.genDFStatement(body);
                hasAnd = false;
            }
            else if (e is GEExpresion)
            {
                if (hasAnd)
                    cg.genGEStatement(fin);
                else
                    cg.genGEStatement(body);
                hasAnd = false;
            }
            else if (e is GTExpresion)
            {
                if (hasAnd)
                    cg.genGTStatement(fin);
                else
                    cg.genGTStatement(body);
                hasAnd = false;
            }
            else if (e is LEExpresion)
            {
                if (hasAnd)
                    cg.genLEStatement(fin);
                else
                    cg.genLEStatement(body);
                hasAnd = false;
            }
            else if (e is LTExpresion)
            {
                if (hasAnd)
                    cg.genLTStatement(fin);
                else
                    cg.genLTStatement(body);
                hasAnd = false;
            }
        } 
    }

    public void genIfExpresion (ILCodeGen cg, ArrayList exp, uint scope, string proc_actual, 
                                   Emit.Label fin, ref Emit.Label orlabel)
    {
        int tipo = 0;
        Symbol s = null;

        bool hasOr = hasToGenOrLabel(exp);

        ReorderIFExpression(exp, proc_actual, scope);

        if (hasOr)
            cg.DefineLabel(ref orlabel);

        foreach (Expr e in exp)
        {
            if (e is IntLiteral)
            {
                IntLiteral lit = (IntLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.INT,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
            }
            else if (e is RealLiteral)
            {
                RealLiteral lit = (RealLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.REAL,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
            }
            else if (e is BoolLiteral)
            {
                BoolLiteral lit = (BoolLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.BOOLEAN,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
                if (lit.Value == "true")
                    cg.genFalseStatement(fin);
                else
                    cg.genTrueStatement(fin);
            }
            else if (e is StringLiteral)
            {
                StringLiteral lit = (StringLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.STRING,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
            }
            else if (e is CharLiteral)
            {
                CharLiteral lit = (CharLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.CHAR,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
            }
            else if (e is Variable)
            {
                Variable var = (Variable)e;
                if (scope == 0)
                    s = symtab.getSymbol(var.Value);
                else
                    s = symtab.getSymbol(proc_actual, var.Value, ref tipo);
                if (s != null)
                {
                    if (tipo == 1)
                    {
                        Param p = (Param)s;
                        cg.loadVariable(s, p.Reference, scope, proc_actual);
                    }
                    else
                        cg.loadVariable(s, false, scope, proc_actual);
                }
                tipo = 0;
                if (s.Type.toString() == "BOOLEAN")
                {
                    if (var.Tipo == "NOT")
                        cg.genTrueStatement(fin);
                    else
                        cg.genFalseStatement(fin);
                }
            }
            else if (e is Function)
            {
                ExpFunction ex = (ExpFunction)e;
            }
            else if (e is EQExpresion)
            {
                if (hasOr)
                    cg.genDFStatement(orlabel);
                else
                    cg.genDFStatement(fin);
                hasOr = false;
            }
            else if (e is DFExpresion)
            {
                if (hasOr)
                    cg.genEQStatement(orlabel);
                else
                    cg.genEQStatement(fin);
                hasOr = false;
            }
            else if (e is GEExpresion)
            {
                if (hasOr)
                    cg.genLTStatement(orlabel);
                else
                    cg.genLTStatement(fin);
                hasOr = false;
            }
            else if (e is GTExpresion)
            {
                if (hasOr)
                    cg.genLEStatement(orlabel);
                else
                    cg.genLEStatement(fin);
                hasOr = false;
            }
            else if (e is LEExpresion)
            {
                if (hasOr)
                    cg.genGTStatement(orlabel);
                else
                    cg.genGTStatement(fin);
                hasOr = false;
            }
            else if (e is LTExpresion)
            {
                if (hasOr)
                    cg.genGEStatement(orlabel);
                else
                    cg.genGEStatement(fin);
                hasOr = false;
            }
        } 
    }

    public void genRepeatExpresion (ILCodeGen cg, ArrayList exp, uint scope, string proc_actual, 
                                    Emit.Label ini, Emit.Label body, Emit.Label fin)
    {
        int tipo = 0;
        Symbol s = null;

        bool hasAnd = hasToGenAndLabel(exp);

        ReorderWHILEExpression(exp, proc_actual, scope);

        cg.MarkLabel(ini);

        foreach (Expr e in exp)
        {
            if (e is IntLiteral)
            {
                IntLiteral lit = (IntLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.INT,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
            }
            else if (e is RealLiteral)
            {
                RealLiteral lit = (RealLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.REAL,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
            }
            else if (e is BoolLiteral)
            {
                BoolLiteral lit = (BoolLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.BOOLEAN,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
                if (lit.Value == "true")
                    cg.genFalseStatement(body);
                else
                    cg.genTrueStatement(body);
            }
            else if (e is StringLiteral)
            {
                StringLiteral lit = (StringLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.STRING,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
            }
            else if (e is CharLiteral)
            {
                CharLiteral lit = (CharLiteral)e;
                s = new Symbol(lit.Value, new Type()); 
                s.Type = new Type (Type.T.CHAR,0,null);
                cg.loadVariable(s, false, scope, proc_actual);
            }
            else if (e is Variable)
            {
                Variable var = (Variable)e;
                if (scope == 0)
                    s = symtab.getSymbol(var.Value);
                else
                    s = symtab.getSymbol(proc_actual, var.Value, ref tipo);
                if (s != null)
                {
                    if (tipo == 1)
                    {
                        Param p = (Param)s;
                        cg.loadVariable(s, p.Reference, scope, proc_actual);
                    }
                    else
                        cg.loadVariable(s, false, scope, proc_actual);
                }
                tipo = 0;
                if (s.Type.toString() == "BOOLEAN")
                {
                    if (var.Tipo == "NOT")
                        cg.genTrueStatement(body);
                    else
                        cg.genFalseStatement(body);
                }
            }
            else if (e is Function)
            {
                ExpFunction ex = (ExpFunction)e;
            }
            else if (e is EQExpresion)
            {
                if (hasAnd)
                    cg.genDFStatement(fin);
                else
                    cg.genDFStatement(body);
                hasAnd = false;
            }
            else if (e is DFExpresion)
            {
                if (hasAnd)
                    cg.genEQStatement(fin);
                else
                    cg.genEQStatement(body);
                hasAnd = false;
            }
            else if (e is GEExpresion)
            {
                if (hasAnd)
                    cg.genLTStatement(fin);
                else
                    cg.genLTStatement(body);
                hasAnd = false;
            }
            else if (e is GTExpresion)
            {
                if (hasAnd)
                    cg.genLEStatement(fin);
                else
                    cg.genLEStatement(body);
                hasAnd = false;
            }
            else if (e is LEExpresion)
            {
                if (hasAnd)
                    cg.genGTStatement(fin);
                else
                    cg.genGTStatement(body);
                hasAnd = false;
            }
            else if (e is LTExpresion)
            {
                if (hasAnd)
                    cg.genGEStatement(fin);
                else
                    cg.genGEStatement(body);
                hasAnd = false;
            }
        } 
    }
}
