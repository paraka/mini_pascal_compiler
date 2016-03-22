using System;
using System.Collections;
using System.Collections.Generic;

////////////////////////////////////////////////////////////////////////////////
//
// CLASE MANEJA WARNINGS : Singleton
//
////////////////////////////////////////////////////////////////////////////////
public sealed class EWarnings
{
    private uint num_warnings;
    private ArrayList table;
    private static readonly EWarnings __instance = new EWarnings();

    // Constructor
    private EWarnings() 
    {
        num_warnings = 0;        
        table = new ArrayList();
    }

    public static EWarnings Instance
    {
        get 
        {
            return __instance;
        }
    }

    public uint NumWarnings {
        get { return num_warnings; }
    }

    public void addWarning(string warn)
    {
        num_warnings++;
        table.Add(warn);
    }

    public void showWarnings()
    {
        //Console.ForegroundColor = ConsoleColor.Yellow;
        foreach (string s in table) 
        {
            Console.Error.WriteLine(s);
        }
        //Console.ResetColor();
    }
}
