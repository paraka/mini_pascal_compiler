using System;
using System.Collections;

public abstract class Expr
{
}

public class StringLiteral : Expr
{
   public string Value;
}

public class IntLiteral : Expr
{
    public string Value;
}

public class CharLiteral : Expr
{
    public string Value;
}

public class RealLiteral : Expr
{
    public string Value;
}

public class BoolLiteral: Expr
{
    public string Value;
}

public class Variable: Expr
{
    public string Value;
    public string Tipo;
}

public class ExpFunction: Expr
{
    public string Value;
    public string Tipo;
}

public class PlusExpresion: Expr
{
    public Expr Left;
    public Expr Right;
}

public class MinusExpresion: Expr
{
    public Expr Left;
    public Expr Right;
}

public class ProductoExpresion: Expr
{
    public Expr Left;
    public Expr Right;
}

public class DivisionExpresion: Expr
{
    public Expr Left;
    public Expr Right;
}

public class DIVExpresion: Expr
{
    public Expr Left;
    public Expr Right;
}

public class MODExpresion: Expr
{
    public Expr Left;
    public Expr Right;
}

public class BooleanExpresion: Expr
{
    public Expr Left;
    public Expr Right;
}

public class GEExpresion: Expr
{
    public Expr Left;
    public Expr Right;
}

public class GTExpresion: Expr
{
    public Expr Left;
    public Expr Right;
}

public class LTExpresion: Expr
{
    public Expr Left;
    public Expr Right;
}

public class LEExpresion: Expr
{
    public Expr Left;
    public Expr Right;
}

public class EQExpresion: Expr
{
    public Expr Left;
    public Expr Right;
}

public class DFExpresion: Expr
{
    public Expr Left;
    public Expr Right;
}

public class ANDExpresion: Expr
{
    public Expr Left;
    public Expr Right;
}

public class ORExpresion: Expr
{
    public Expr Left;
    public Expr Right;
}

public class NOTExpresion: Expr
{
    public Expr ex;
}
