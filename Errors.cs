using System;
using System.Collections;
using System.Collections.Generic;

////////////////////////////////////////////////////////////////////////////////
//
// CLASE MANEJA ERRORES SEMANTICOS: Singleton
//
////////////////////////////////////////////////////////////////////////////////

public class fpc2ilError
{
    public string msg;
    public int line;
    public int col;

    public fpc2ilError (string s, int line, int col)
    {
        this.msg = s;
        this.line = line;
        this.col = col;
    }
}

public sealed class Errors
{
    private uint num_errors;
    private ArrayList table;
    private static readonly Errors __instance = new Errors();


    // Constructor
    private Errors() 
    {
        num_errors = 0;        
        table = new ArrayList();
    }

    public static Errors Instance
    {
        get 
        {
            return __instance;
        }
    }

    public uint NumErrors 
    {
        get 
        { 
            return num_errors; 
        }
    }

    public void addError(string err, int line, int col)
    {
        num_errors++;
        fpc2ilError e = new fpc2ilError(err, line, col);
        table.Add(e);
    }

    public void showErrors (string file)
    {
        //Console.ForegroundColor = ConsoleColor.Red;
        foreach (fpc2ilError s in table) 
            Console.Error.WriteLine(file + "({0},{1}): {2}", s.line, s.col, s.msg);

        //Console.ResetColor();
    }
}
