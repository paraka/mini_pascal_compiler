using System;
using System.Collections;
using System.Collections.Generic;

public class Type
{
    public enum T {
        INT, REAL, CHAR, STRING, BOOLEAN, PROC, FUNC, CALL 
    }
    
    T      ty;    
    int    size;
    Type   of;
    
    // default constructor
    public Type ()
    {
        ty   = T.INT;
        size = 1;
        of   = null;
    }
    
    // Custom contructor intialises all fields
    public Type( Type.T t, int s, Type o )
    {
        ty   = t;
        size = s;
        of   = o;
    }
    
    // get...() methods
    
    public Type Of {
        get { return of; }
    }
    
    public T Ty {
        get { return ty; }
    }
    
    public int Size {
        get { return size; }
    }

    public string toString ()
    {
        if ( ty == T.INT )
            return( "INT" );
        else if ( ty == T.REAL )
            return( "REAL" );
        else if ( ty == T.BOOLEAN )
            return( "BOOLEAN" );
        else if ( ty == T.STRING )
            return( "STRING" );
        else if ( ty == T.CHAR )
            return( "CHAR" );
        else if ( ty == T.FUNC )
            return( "FUNC" );
        else if ( ty == T.PROC )
            return( "PROC" );
        else
            return ("DESCONOCIDO");
    }
    
    public void dump()
    {
        if ( ty == T.INT )
            Console.Write( "INT" );
        else if ( ty == T.REAL )
            Console.Write( "REAL" );
        else if ( ty == T.CHAR )
            Console.Write( "CHAR" );
        else if ( ty == T.BOOLEAN )
            Console.Write( "BOOLEAN" );
        else if ( ty == T.STRING )
            Console.Write( "STRING" );
        else if ( ty == T.FUNC )
            Console.Write( "FUNC" );
        else if ( ty == T.PROC )
            Console.Write( "PROC" );
        else
            Console.Error.WriteLine( "*** TIPO INTERNO DESCONOCIDO ***" );
    }
}

////////////////////////////////////////////////////////////////////////////////
//
//  CLASS: Symbol y derivadas
//
//  Clases para los simbolos 
//
////////////////////////////////////////////////////////////////////////////////

public class Symbol
{
    private string name;
    private Type   type;
    private uint   scope;
    protected Errors err;
    private bool isLiteral; 
    
    public Symbol( string n, Type t )
    {
        name   = n;
        type   = t;
        scope  = 0;
        isLiteral = false;
        err = Errors.Instance;
    }
    
    public Type Type {
        get { return type; }
        set { type = value; }
    }
    
    public string Name {
        get { return name; }
    }

    public uint Scope {
        get { return scope; }
        set { scope = value; }
    }

    public bool Literal {
        get { return isLiteral; }
        set { isLiteral = value; }
    }

    public virtual void dump()
    {
        Console.Write( "Global ({0}) ", name );
        Console.Write( "Literal {0}", isLiteral);
        Console.Write( "tiene tipo :" );
        type.dump();
        Console.WriteLine();
    }
}

public class Constant: Symbol
{
    private string cvalue;

    public Constant (string n, Type t): base (n, t)
    {
        cvalue = "";
    }

    public string Value
    {
        get { return cvalue; }
        set { cvalue = value; }
    }

    public override void dump()
    {
        base.dump();
        Console.WriteLine(" Cte value: " + cvalue);
    }
}

public class Param: Symbol
{
    private uint offset;
    private bool reference;

    public Param (string n, Type t, uint o, bool isref): base (n,t)
    {
        offset = o;
        reference = isref;
    }

    public uint Offset {
        get { return offset; }
    }

    public bool Reference {
        get { return reference; }
    }
}

public class Procedure: Symbol
{
    private Hashtable parameters;
    private Hashtable local;
    
    public Procedure (string n, Type t): base (n, t)
    {
        parameters = new Hashtable();
        local = new Hashtable();
    }
    
    public Hashtable Parameters {
        get { return parameters; }
        set { parameters = value; }
    }

    public Hashtable Locales {
        get { return local; }
        set { local = value; }
    }

    public void addToLocals (Symbol n)
    {
        if (parameters.Contains(n.Name)) 
            throw new fpc2ilException("Local variable '" + n.Name + "' has been previously defined as an argument");

        if (local.Contains(n.Name))
            throw new fpc2ilException("Redefinition of local variable '" + n.Name + "'");

        try {
            local.Add(n.Name, n);
        } catch (ArgumentException) {}
    }

    private Param getParamForOffset (uint offset)
    {
        foreach (Param p in parameters.Values)
            if (p.Offset == offset)
                return p;
        return null; /* no deberia devolver nunca null */
    }

    public bool checkParams (ArrayList paramList)
    {
        int callParamNumber = paramList.Count;
        int number = parameters.Count;

        //Console.WriteLine("P: " + number + "C: " + callParamNumber);

        if (number != callParamNumber) 
        {
            throw new fpc2ilException("Procedure '" + Name + "' expects " + number + " parameters but it is been called with " + callParamNumber);
            return false;
        }

        int i = 0;
        object[] keys = new object[number];
        parameters.Keys.CopyTo(keys, 0);

        for (i=0; i<number; i++)
        {
            Param param = getParamForOffset((uint)i);
            Symbol aux = (Symbol)paramList[i];
            if (param.Reference && aux.Literal)
            {
                throw new fpc2ilException("Parameter '" + param.Name + "' expects a reference but is being called with a literal " + aux.Name);
                return false;
            }
            string proc_type = param.Type.toString();
            string call_type = aux.Type.toString();
            if (proc_type != call_type)
                throw new fpc2ilException ("Procedure param '" + param.Name + "' (" + proc_type + ") and call param '" +
                                           aux.Name + "' (" + call_type + ") type doesn't match");
        }
        return true;
    }

    public Symbol find (string n)
    {
        if ( local.Contains(n) )
            return (Symbol)local[n];
        else if (parameters.Contains(n))
            return (Symbol)parameters[n];
        else {
            throw new fpc2ilException( "Undeclared symbol '" + n + "'");
            return null;
        }
    }

    public void dumpParametros ()
    {
        foreach (Param s in parameters.Values) 
        {
            Console.Write("\t*Parametro.{1}-Ref:{2}: {0} : ", s.Name, s.Offset, s.Reference);
            s.Type.dump();
            Console.WriteLine();
        }
    }

    public void dumpLocales ()
    {
        foreach (Symbol v in local.Values) 
        {
            Console.Write("\t*Local : {0} : ", v.Name);
            v.Type.dump();
            if (v is Constant) { Constant t = (Constant)v; Console.Write(" Cte value: " + t.Value); }
            Console.WriteLine();
        }
    }

    public override void dump()
    {
        base.dump();
        if (parameters.Count != 0)
            dumpParametros();
        else
            Console.WriteLine("\t*Sin parametros");
        if (local.Count != 0)
            dumpLocales();
        else
            Console.WriteLine("\t*Sin variables locales");
    }
}

public class Function: Procedure
{
    private Type typereturn;

    public Function(string name, Type type): base(name, type)
    {
        typereturn = new Type();
    }

    public Type TypeReturn {
        get { return typereturn; }
        set { typereturn = value; }
    }

    public override void dump()
    {
        base.dump();
        Console.Write("\t*Devuelve: ");
        typereturn.dump();
        Console.WriteLine();
    }
}

////////////////////////////////////////////////////////////////////////////////
//
//  CLASS: SymbolTable
//
//  La tabla de simbolos es un singleton
//
////////////////////////////////////////////////////////////////////////////////

public sealed class Symboltable
{
    private Errors err;
    private uint        scope;
    private Hashtable   table;
    private static readonly Symboltable __instance = new Symboltable();

    // Constructor
    private Symboltable () 
    {
        scope  = 0;        
        table  = new Hashtable();
        err = Errors.Instance;
    }

    public static Symboltable Instance
    {
        get 
        {
            return __instance;
        }
    }
    
    public uint Scope {
        get { return scope; }
    }
    
    public void add (Symbol s)
    {
        if ( table.Contains(s.Name) )
            throw new fpc2ilException("Redefinition of '" + s.Name + "'"); 

        try {
            //s.Scope = scope;
            table.Add( s.Name, s ); 
         } catch (ArgumentException e) {}
    }
    
    public Symbol find (string n)
    {
        if ( table.Contains(n) )
            return (Symbol)table[n];
        else {
            throw new fpc2ilException("Undeclared symbol '" + n + "'");
            return null;
        }
    }


    public Symbol getSymbol( string n )
    {
        if ( table.Contains(n) )
            return (Symbol)table[n];
        else 
            return null;
    }

    public Symbol getSymbol (string name, string n, ref int type)
    {
        Procedure aux = null;

        /* TIpo: 0 nada , 1 parametro, 2 local */
        if (table.Contains(name)) {
            aux = (Procedure)table[name];
            if (aux.Parameters.Contains(n))
            {
                type = 1;
                return (Symbol)aux.Parameters[n];
            } 
            else if (aux.Locales.Contains(n))
            {
                type = 2;
                return (Symbol)aux.Locales[n];
            }
            else {
                if (table.Contains(n))
                    return (Symbol)table[n];
                else 
                    return null;
            }
        } else {
            return null;
        }
    }

    public Symbol findInAllScopes (string name, string n)
    {
        Procedure aux = null;

        if (table.Contains(name)) {
            aux = (Procedure)table[name];
            if (aux.Name == n) 
                return aux; /* TODO: Esto quizas de problemas, En pascal si es una funcion se usa como variable de retorno el
                               nombre de la funcion,asi es que devolvemos de momento la propia funcion,asi es que
                               devolvemos de momento la propia funcion. Quizas deberiamos crear un nuevo simbolo tipo
                               return y meterlo en la tabla de simbolos para la generacion de codigo */  
            if (aux.Parameters.Contains(n))
                return (Symbol)aux.Parameters[n];
            else if (aux.Locales.Contains(n))
                return (Symbol)aux.Locales[n];
            else {
                if (table.Contains(n))
                    return (Symbol)table[n];
                else {
                    throw new fpc2ilException("Undeclared symbol '" + n + "'");
                    return null;
                }
            }
        } else {
            throw new fpc2ilException("Undeclared procedure '" + name + "'");
            return null;
        }
    }
    
    // dump()
    // Dumps out the contents of the symbol table.
    public void dump()
    {
        Console.Write( "\n*** TABLA DE SIMBOLOS ***\n\n" );
        foreach( Symbol s in table.Values )
            s.dump();
        Console.Write( "\n***********************\n" );
    }
}
