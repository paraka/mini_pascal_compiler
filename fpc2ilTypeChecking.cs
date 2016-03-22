using System.Collections;
using System.Collections.Generic;

public class fpc2ilTypeChecking
{
    private Symboltable symtab = null;

    public fpc2ilTypeChecking ()
    {
        symtab = Symboltable.Instance;
    }

    private bool isBooleanOp (string name)
    {
        List<string> list = new List<string> { ">", "<", "<=", ">=", "<>", "=" };
        foreach (string s in list)
            if (s == name)
                return true;
        return false;
    }

    public bool checkBooleanExpresion (ArrayList l)
    {
        foreach (Expr exp in l)
        {
            if (exp is PlusExpresion 
                || exp is MinusExpresion 
                || exp is ProductoExpresion 
                || exp is DIVExpresion
                || exp is DivisionExpresion 
                || exp is MODExpresion)
                                                                                                    
                return false;
        }
        return true;
    }

    private bool isReservedWord (string name)
    {
        List<string> list = new List<string> { "and", "or", "not", ">", "<", "<=", ">=", "<>", "=", "+", "-", "*", "/", "div", "mod" };
        foreach (string s in list)
            if (s == name)
                return true;
        return false;
    }

    public Expr getExpresion (string s, uint scope, string proc_actual)
    {
        Symbol symbol = null;
        int foo = 0;

        if (scope == 0) 
            symbol = symtab.getSymbol(s);
        else
            symbol = symtab.getSymbol(proc_actual, s, ref foo);

        if (symbol == null && !isReservedWord(s))
        {
            if (s == "true" || s == "false")
            {
                BoolLiteral exp1 = new BoolLiteral();
                exp1.Value = s;
                return exp1;
            }
            else {
                int number = 0;
                bool canConvert = int.TryParse(s, out number);
                if (!canConvert) 
                {
                    double number2;
                    canConvert = double.TryParse(s, out number2);
                    if (canConvert)
                    {
                        RealLiteral exp2 = new RealLiteral();
                        exp2.Value = s;
                        return exp2;
                    }
                    else
                    {
                        if (s.Length > 1)
                        {
                            StringLiteral exp3 = new StringLiteral();
                            exp3.Value = s;
                            return exp3;
                        } 
                        else 
                        {
                            CharLiteral exp4 = new CharLiteral();
                            exp4.Value = s;
                            return exp4;
                        }
                    }
                } 
                else
                {
                    IntLiteral exp4 = new IntLiteral();
                    exp4.Value = s;
                    return exp4;
                }
            }
        }
        else if (symbol != null)
        {
            switch (symbol.Type.toString())
            {
                case "INT": 
                    Variable exp5 = new Variable();
                    exp5.Value = s;
                    exp5.Tipo = "INT";
                    return exp5;
                    break;
                case "REAL":
                    Variable exp6 = new Variable();
                    exp6.Value = s;
                    exp6.Tipo = "REAL";
                    return exp6;
                    break;
                case "STRING":
                    Variable exp7 = new Variable();
                    exp7.Value = s;
                    exp7.Tipo = "STRING";
                    return exp7;
                    break;
                case "BOOLEAN":
                    Variable exp8 = new Variable();
                    exp8.Value = s;
                    exp8.Tipo = "BOOLEAN";
                    return exp8;
                    break;
                case "CHAR": 
                    Variable exp9 = new Variable();
                    exp9.Value = s;
                    exp9.Tipo = "CHAR";
                    return exp9;
                    break;
            }
        }
        else 
        {
            //Esto son los simbolos reservados que ignoramos
            return null;
        }
        //Console.WriteLine("No deberia pasar por aqui: " + s);
        return null;
    }

    private bool checkVariable (string var, Expr exp, ref string tipo)
    {
        if (exp is Variable) 
        {
            Variable x = (Variable)exp;
            if (x.Tipo != var) 
            {
                tipo = x.Tipo;
                return false;
            }
        }
        return true;
    }

    private bool checkTypeLiteral (string var, Expr exp, ref string tipo)
    {
        if (exp is StringLiteral && var == "BOOLEAN")
        {
            tipo = "STRING";
            return false;
        }
        else if (exp is IntLiteral && var == "BOOLEAN")
        {
            tipo = "INT";
            return false;
        }
        else if (exp is RealLiteral && var == "BOOLEAN")
        {
            tipo = "REAL";
            return false;
        }
        else if (exp is CharLiteral && var == "BOOLEAN")
        {
            tipo = "CHAR";
            return false;
        }
        else if (exp is StringLiteral && var == "INT")
        {
            tipo = "STRING";
            return false;
        }
        else if (exp is RealLiteral && var == "INT")
        {
            tipo = "REAL";
            return false;
        }
        else if (exp is BoolLiteral && var == "INT") 
        {
            tipo = "BOOLEAN";
            return false;
        }
        else if (exp is CharLiteral && var == "INT")
        {
            tipo = "CHAR";
            return false;
        }
        else if (exp is StringLiteral && var == "REAL")
        {
            tipo = "STRING";
            return false;
        }
        else if (exp is BoolLiteral && var == "REAL")
        {
            tipo = "BOOL";
            return false;
        }
        else if (exp is IntLiteral && var == "REAL")
        {
            tipo = "INT";
            return false;
        }
        else if (exp is CharLiteral && var == "REAL")
        {
            tipo = "CHAR";
            return false;
        }
        else if (exp is IntLiteral && var == "STRING")
        {
            tipo = "INT";
            return false;
        }
        else if (exp is RealLiteral && var == "STRING")
        {
            tipo = "REAL";
            return false;
        }
        else if (exp is BoolLiteral && var == "STRING")
        {
            tipo = "BOOLEAN";
            return false;
        }
        else if (exp is CharLiteral && var == "STRING")
        {
            tipo = "CHAR";
            return false;
        }
        else if (exp is IntLiteral && var == "CHAR")
        {
            tipo = "INT";
            return false;
        }
        else if (exp is RealLiteral && var == "CHAR")
        {
            tipo = "REAL";
            return false;
        }
        else if (exp is BoolLiteral && var == "CHAR")
        {
            tipo = "BOOLEAN";
            return false;
        }
        else if (exp is StringLiteral && var == "CHAR")
        {
            tipo = "STRING";
            return false;
        }

        return true;
    }

    /* DIV MOD solo admiten operandos enteros */
    private bool checkTypeDIVMOD (string var, Expr exp, ref string tipo)
    {
        if (exp is RealLiteral) 
        {
            tipo = "REAL";
            return false;
        }
        else if (exp is StringLiteral)
        {
            tipo = "STRING";
            return false;
        }
        else if (exp is CharLiteral)
        {
            tipo = "CHAR";
            return false;
        }
        else if (exp is BoolLiteral)
        {
            tipo = "BOOLEAN";
            return false;
        }
        return true;
    }

    public bool checkTypeExpression (string var, ArrayList lexpresiones, ref string tipo)
    {
        foreach (Expr f in lexpresiones)
        {
            if (f is BooleanExpresion || f is ANDExpresion || f is ORExpresion || f is NOTExpresion)
                return false;

            else if (!checkTypeLiteral(var, f, ref tipo))
                return false;

            else if (f is Variable)
            {
                if (!checkVariable(var, f, ref tipo))
                    return false;
            }

            else if (f is DIVExpresion)
            {
                DIVExpresion x = (DIVExpresion)f;
                if (x.Left != null)
                {
                    if (!checkTypeDIVMOD(var, x.Left, ref tipo))
                        return false;
                }
                if (x.Right != null)
                {
                    if (!checkTypeDIVMOD(var, x.Right, ref tipo))
                        return false;
                }
            }

            else if (f is MODExpresion)
            {
                MODExpresion x = (MODExpresion)f;
                if (x.Left != null)
                {
                    if (!checkTypeDIVMOD(var, x.Left, ref tipo))
                        return false;
                }
                if (x.Right != null)
                {
                    if (!checkTypeDIVMOD(var, x.Right, ref tipo))
                        return false;
                }
            }

            else if (f is PlusExpresion)
            {
                PlusExpresion x = (PlusExpresion)f;
                if (x.Left != null)
                {
                    if (!checkTypeLiteral(var, x.Left, ref tipo))
                        return false;
                    if (!checkVariable(var, x.Left, ref tipo))
                        return false;
                }
                if (x.Right != null)
                {
                    if (!checkTypeLiteral(var, x.Right, ref tipo))
                        return false;
                    if (!checkVariable(var, x.Right, ref tipo))
                        return false;
                }
                else
                    return true;
            } 

            else if (f is MinusExpresion)
            {
                MinusExpresion x = (MinusExpresion)f;
                if (x.Left != null)
                {
                    if (!checkTypeLiteral(var, x.Left, ref tipo))
                        return false;
                    if (!checkVariable(var, x.Left, ref tipo))
                        return false;
                }
                if (x.Right != null)
                {
                    if (!checkTypeLiteral(var, x.Right, ref tipo))
                        return false;
                    if (!checkVariable(var, x.Right, ref tipo))
                        return false;
                }
                else
                    return true;
            }
            
            else if (f is ProductoExpresion)
            {
                ProductoExpresion x = (ProductoExpresion)f;
                if (x.Left != null)
                {
                    if (!checkTypeLiteral(var, x.Left, ref tipo))
                        return false;
                    if (!checkVariable(var, x.Left, ref tipo))
                        return false;
                }
                if (x.Right != null)
                {
                    if (!checkTypeLiteral(var, x.Right, ref tipo))
                        return false;
                    if (!checkVariable(var, x.Right, ref tipo))
                        return false;
                }
                else
                    return true;
            }
            
            else if (f is DivisionExpresion)
            {
                DivisionExpresion x = (DivisionExpresion)f;
                if (x.Left != null)
                {
                    if (!checkTypeLiteral(var, x.Left, ref tipo))
                        return false;
                    if (!checkVariable(var, x.Left, ref tipo))
                        return false;
                }
                if (x.Right != null)
                {
                    if (!checkTypeLiteral(var, x.Right, ref tipo))
                        return false;
                    if (!checkVariable(var, x.Right, ref tipo))
                        return false;
                }
                else
                    return true;
            }
        }

        return true;
    }
}
