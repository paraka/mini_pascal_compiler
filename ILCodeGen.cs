using Collections = System.Collections.Generic;
using System.Collections;
using Reflect = System.Reflection;
using Emit = System.Reflection.Emit;
using IO = System.IO;
using System;


public class ILCodeGen 
{
    private Symboltable symtab = null;
    private Emit.ILGenerator il = null;
    private Reflect.AssemblyName asname = null;
    private Emit.AssemblyBuilder asmb = null;
    private Emit.ModuleBuilder modb = null;
    private Emit.TypeBuilder typeBuilder = null;
    private Emit.MethodBuilder methb = null;
    private string program_name = "";
    private Hashtable mbuilderTable = null;
    private Hashtable fbuilderTable = null;
    //Variables locales: Hastable clave proc actual valor Hastable de lbuilders con clave el nombre del parametro
    private Hashtable lbuilderTable = null;

    public ILCodeGen (string name)
    {
        this.symtab = Symboltable.Instance;
        this.program_name = name;
        this.asname = new Reflect.AssemblyName(name);
        this.asmb = System.AppDomain.CurrentDomain.DefineDynamicAssembly(asname, Emit.AssemblyBuilderAccess.Save);
        this.modb = asmb.DefineDynamicModule(name);
        this.typeBuilder = modb.DefineType("fpc2IL");
        this.mbuilderTable = new Hashtable();
        this.fbuilderTable = new Hashtable();
        this.lbuilderTable = new Hashtable();
    }

    /*
     * Devolvemos el tipo correcto del sistema
     * correspondiente a nuestra tabla de simbolos.
     */
    private System.Type getSystemTypeFormat (Type ty)
    {
        if ( ty.toString() == "INT" )
            return(typeof(System.Int32));
        else if ( ty.toString() == "REAL" )
            return(typeof(System.Double));
        else if ( ty.toString() == "BOOLEAN" )
            return(typeof(System.Boolean));
        else if ( ty.toString() == "CHAR" )
            return(typeof(System.Char));
        else if ( ty.toString() == "STRING" )
            return(typeof(System.String));
        else
            return null;
    }

    public void checkAndGenLdArgInReference (uint scope, string proc_actual, string expS)
    {
        int astipo = 0;

        if (expS != "")
        {
            Symbol aux;
            if (scope == 0)
                aux = symtab.getSymbol(expS);
            else
                aux = symtab.getSymbol(proc_actual, expS, ref astipo);

            if (aux != null)
            {
                if (astipo == 1)
                {
                    Param s1 = (Param)aux;
                    if (s1.Reference)
                        this.genLdArg(s1.Offset);
                }
            }
        }
    }

    public void genLdArg (uint offset)
    {
        switch (offset)
        {
          case 0:
              this.il.Emit(Emit.OpCodes.Ldarg_0);
              break;
          case 1:
              this.il.Emit(Emit.OpCodes.Ldarg_1);
              break;
          case 2:
              this.il.Emit(Emit.OpCodes.Ldarg_2);
              break;
          case 3:
              this.il.Emit(Emit.OpCodes.Ldarg_3);
              break;
          default:
              this.il.Emit(Emit.OpCodes.Ldarg_S, (byte)offset);
              break;
        }
    }

    public void genMethod (Symbol s)
    {
        System.Type[] parameters; 
        System.Type returnType = null;
        Procedure p = null;

        //Debemos poner el ret correcto
        if (this.il != null)
            this.il.Emit(Emit.OpCodes.Ret);

        if (s is Procedure) 
            p = (Procedure)s;
        
        if (s is Function) 
        {
            Function f = (Function)s;
            returnType = getSystemTypeFormat(f.TypeReturn);
            p = (Procedure)f;
        }
        
        parameters = new System.Type[p.Parameters.Count];

        int i = 0;
        int cont = p.Parameters.Count;
        object[] keys = new object[cont];
        p.Parameters.Keys.CopyTo(keys, 0);
        Array.Reverse(keys);

        for (i=0; i<cont;i++) 
        {
            Param param = (Param)p.Parameters[keys[i]];
            parameters[i] = getSystemTypeFormat(param.Type);
            if (param.Reference) parameters[i] = parameters[i].MakeByRefType();
        }
        
        this.methb = typeBuilder.DefineMethod(s.Name,
                                              Reflect.MethodAttributes.Public | Reflect.MethodAttributes.Static,
                                              returnType,
                                              parameters);       

        mbuilderTable.Add(s.Name, methb);

        this.il = methb.GetILGenerator();

        //Local variables
        if (p.Locales.Count > 0) 
        {
            Hashtable h = new Hashtable();
            
            foreach (Symbol local in p.Locales.Values)
            {
                Emit.LocalBuilder lbuilder = this.il.DeclareLocal(getSystemTypeFormat(local.Type));
                h.Add(local.Name, lbuilder);
            }
            lbuilderTable.Add(s.Name, h);
        }
    }

    public void genEQStatement (Emit.Label lab)
    {
        this.il.Emit(Emit.OpCodes.Beq, lab);
    }

    public void genDFStatement (Emit.Label lab)
    {
        this.il.Emit(Emit.OpCodes.Bne_Un, lab);
    }

    public void genGEStatement (Emit.Label lab)
    {
        this.il.Emit(Emit.OpCodes.Bge, lab);
    }

    public void genGTStatement (Emit.Label lab)
    {
        this.il.Emit(Emit.OpCodes.Bgt, lab);
    }

    public void genLEStatement (Emit.Label lab)
    {
        this.il.Emit(Emit.OpCodes.Ble, lab);
    }

    public void genLTStatement (Emit.Label lab)
    {
        this.il.Emit(Emit.OpCodes.Blt, lab);
    }

    public void genTrueStatement (Emit.Label lab)
    {
        this.il.Emit(Emit.OpCodes.Brtrue, lab);
    }

    public void genFalseStatement (Emit.Label lab)
    {
        this.il.Emit(Emit.OpCodes.Brfalse, lab);
    }

    public void genBrStatement (Emit.Label lab)
    {
        this.il.Emit(Emit.OpCodes.Br, lab);
    }

    public void MarkLabel(Emit.Label lab)
    {
        this.il.MarkLabel(lab);
    }

    public void DefineLabel(ref Emit.Label lab)
    {
        lab = this.il.DefineLabel(); 
    }

    public void genElseStatement (ref Emit.Label elseLabel)
    {
        elseLabel = this.il.DefineLabel();
        il.Emit(Emit.OpCodes.Br, elseLabel);
    }

    public void genWhileStatement (ref Emit.Label whileLabel, ref Emit.Label whileBody)
    {
        whileLabel = this.il.DefineLabel();
        il.Emit(Emit.OpCodes.Br, whileLabel);
        whileBody = this.il.DefineLabel();
        this.il.MarkLabel(whileBody);
    }

    public void genForStatement (uint scope, string proc_actual, string varControl, Symbol ini, 
                                 ref Emit.Label forLabel, ref Emit.Label forBody)
    {
        int tipo = 0;
        this.loadVariable(ini, false, scope, proc_actual);
        Symbol store = symtab.getSymbol(proc_actual, varControl, ref tipo);
        /* Si no existen procedimientos */
        if (proc_actual == "" && store == null)
            store = symtab.getSymbol(varControl);
        /* store debe estar definido o fallar en pasadas anteriores */
        this.storeVariable(store, false, scope, proc_actual);
        forLabel = this.il.DefineLabel();
        this.il.Emit(Emit.OpCodes.Br, forLabel);
        forBody = this.il.DefineLabel();
        this.il.MarkLabel(forBody);
    }

    public void genEndForStatement (uint scope, string proc_actual, string varControl, Symbol fin, 
                                    ref Emit.Label forLabel,  ref Emit.Label forBody)
    {
        int tipo = 0;
        Symbol store = symtab.getSymbol(proc_actual, varControl, ref tipo);
        /* Si no existen procedimientos */
        if (proc_actual == "" && store == null)
            store = symtab.getSymbol(varControl);
        this.loadVariable(store, false, scope, proc_actual);
        this.il.Emit(Emit.OpCodes.Ldc_I4, 1);
        this.il.Emit(Emit.OpCodes.Add);
        this.storeVariable(store, false, scope, proc_actual);
        this.il.MarkLabel(forLabel);
        this.loadVariable(store, false, scope, proc_actual);
        this.loadVariable(fin, false, scope, proc_actual);
        this.il.Emit(Emit.OpCodes.Ble, forBody);
    }

    public void genSuma ()
    {
        this.il.Emit(Emit.OpCodes.Add);
    }

    public void genResta ()
    {
        this.il.Emit(Emit.OpCodes.Sub);
    }

    public void genMult ()
    {
        this.il.Emit(Emit.OpCodes.Mul);
    }

    public void genDivision ()
    {
        this.il.Emit(Emit.OpCodes.Div);
    }

    public void genMod ()
    {
        this.il.Emit(Emit.OpCodes.Rem);
    }

    public void storeVariable (Symbol s, bool isref, uint scope, string proc_actual)
    {
        Symbol aux;
        int tipo = 0;

        if (scope == 0) 
            aux = symtab.getSymbol(s.Name);
        else
            aux = symtab.getSymbol(proc_actual, s.Name, ref tipo);

        if (aux != null) 
        {
            /* 
             * Porque puede ser que estemos usando 
             * una variable global dentro de un metodo 
             * hay que comprobar tb el tipo
             */
            if (scope == 0 || tipo == 0)
                    this.il.Emit(Emit.OpCodes.Stsfld, (Emit.FieldBuilder)fbuilderTable[aux.Name]);
            //tipo = 1 parametro
            else if (tipo == 1) 
            {
                Param f = (Param)aux;
                if (f.Reference)
                    this.genStInd(f);
                else
                    this.il.Emit(Emit.OpCodes.Starg_S, (short)f.Offset);
            }
            else
            {
                Hashtable h = (Hashtable)lbuilderTable[proc_actual];
                Emit.LocalBuilder l = (Emit.LocalBuilder)h[s.Name];
                if (l == null) return;
                if (isref)
                    this.genStInd(s);
                else
                    this.il.Emit(Emit.OpCodes.Stloc, l);
            }
        }
    }

    private void genStInd (Symbol s)
    {
        switch (s.Type.toString())
        {
          case "INT":
              this.il.Emit(Emit.OpCodes.Stind_I4);
              break;
          case "REAL":
              this.il.Emit(Emit.OpCodes.Stind_R8);
              break;
          case "CHAR":
              this.il.Emit(Emit.OpCodes.Stind_I4);
              break;
          case "BOOLEAN":
              this.il.Emit(Emit.OpCodes.Stind_I4);
              break;
          case "STRING":
              this.il.Emit(Emit.OpCodes.Stind_Ref);
              break;
        }
    }

    private void genLdInd (Symbol s)
    {
        switch (s.Type.toString())
        {
          case "INT":
              this.il.Emit(Emit.OpCodes.Ldind_I4);
              break;
          case "CHAR":
              this.il.Emit(Emit.OpCodes.Ldind_I4);
              break;
          case "FLOAT":
              this.il.Emit(Emit.OpCodes.Ldind_R8);
              break;
          case "BOOLEAN":
              this.il.Emit(Emit.OpCodes.Ldind_I4);
              break;
          case "STRING":
              this.il.Emit(Emit.OpCodes.Ldind_Ref);
              break;
        }
    }

    public void loadVariable (Symbol s, bool isref, uint scope, string proc_actual)
    {
        Symbol aux;
        int tipo = 0;

        if (scope == 0) 
            aux = symtab.getSymbol(s.Name);
        else
            aux = symtab.getSymbol(proc_actual, s.Name, ref tipo);

        /* 
         * Si la cadena coincide con el nombre del procedimiento 
         * o de otra variable, debemos tratarlo como un literal 
         *
         * Las constantes las tratamos como literales, ya que en mono
         * no esta implementado el metodo getRawConstantValue para obtener
         * el valor. Dado que en compilacion no dejamos asignar valores, 
         * no se notara a no ser que se mire el codigo generado.
         */
        if (aux != null && !s.Literal && !(aux is Constant)) 
        {
            if (scope == 0)
            {
                if (isref)
                    this.il.Emit(Emit.OpCodes.Ldsflda, (Emit.FieldBuilder)fbuilderTable[aux.Name]);
                else
                    this.il.Emit(Emit.OpCodes.Ldsfld, (Emit.FieldBuilder)fbuilderTable[aux.Name]);
            }
            //tipo = 1 parametro
            else if (tipo == 1) 
            {
                Param f = (Param)aux;
                this.genLdArg(f.Offset);
                if (isref)
                    this.genLdInd(f);
            }
            else
            {
                Hashtable h = (Hashtable)lbuilderTable[proc_actual];
                if (h == null) return;
                Emit.LocalBuilder l = (Emit.LocalBuilder)h[s.Name];
                if (l == null) return;
                if (isref)
                    this.il.Emit(Emit.OpCodes.Ldloca, l);
                else
                    this.il.Emit(Emit.OpCodes.Ldloc, l);
            }
        }
        else 
        {
            switch (s.Type.toString())
            {
                case "INT":
                    if (aux != null && aux is Constant)
                    {
                        Constant cnt = (Constant)aux;
                        this.il.Emit(Emit.OpCodes.Ldc_I4, Int32.Parse(cnt.Value));
                    }
                    else
                        this.il.Emit(Emit.OpCodes.Ldc_I4, Int32.Parse(s.Name));
                    break;
                case "CHAR":
                    if (aux != null && aux is Constant)
                    {
                        Constant cnt = (Constant)aux;
                        this.il.Emit(Emit.OpCodes.Ldc_I4, Char.Parse(cnt.Value));
                    }
                    else
                        this.il.Emit(Emit.OpCodes.Ldc_I4, Char.Parse(s.Name));
                    break;
                case "STRING":
                    if (aux != null && aux is Constant)
                    {
                        Constant cnt = (Constant)aux;
                        this.il.Emit(Emit.OpCodes.Ldstr, cnt.Value);
                    }
                    else
                        this.il.Emit(Emit.OpCodes.Ldstr, s.Name);
                    break;
                case "REAL":
                    if (aux != null && aux is Constant)
                    {
                        Constant cnt = (Constant)aux;
                        string str = cnt.Value.Replace('.', ','); 
                        this.il.Emit(Emit.OpCodes.Ldc_R8, Double.Parse(str));
                    }
                    else
                    {
                        string str = s.Name.Replace('.', ','); 
                        this.il.Emit(Emit.OpCodes.Ldc_R8, Double.Parse(str));
                    }
                    break;
                case "BOOLEAN":
                    if (aux != null && aux is Constant)
                    {
                        Constant cnt = (Constant)aux;
                        if (cnt.Value == "true")
                            this.il.Emit(Emit.OpCodes.Ldc_I4, 1);
                        else
                            this.il.Emit(Emit.OpCodes.Ldc_I4, 0);
                    } 
                    else 
                    {
                        if (s.Name == "true")
                            this.il.Emit(Emit.OpCodes.Ldc_I4, 1);
                        else
                            this.il.Emit(Emit.OpCodes.Ldc_I4, 0);
                    }
                    break;
            }
        }
    }

    public void genCall (Symbol s, ArrayList parameters, uint scope, string proc_actual)
    {
        Procedure p = (Procedure)s;

        int cont = parameters.Count;

        if (cont != 0)
        {
            object[] keys = new object[cont];
            p.Parameters.Keys.CopyTo(keys, 0);
            Array.Reverse(keys);
        
            int i = 0;
            for (i=0; i< cont; i++)
            {
                Symbol x = (Symbol)parameters[i];
                Param procparam = (Param)p.Parameters[keys[i]];
                this.loadVariable(x, procparam.Reference, scope, proc_actual);
            }
        }

        this.il.Emit(Emit.OpCodes.Call, (Emit.MethodBuilder)mbuilderTable[p.Name]);
    }

    public void genWriteLn (string proc_actual, uint scope, ArrayList parameters)
    {
        bool concatena = false;
        int tipo = 0;

        if (parameters.Count > 1) 
            concatena = true;

        System.Type [] tipos = new System.Type[parameters.Count];

        int j = 0;
        foreach (Symbol x in parameters)
        {
            //Vemos si el parametro que pasamos en el call es un parametro de nuestro proc 
            Symbol aux = symtab.getSymbol(proc_actual, x.Name, ref tipo);

            if (aux != null && tipo == 1)
            {
                Param procparam = (Param)aux;
                this.loadVariable(x, procparam.Reference, scope, proc_actual);
            } 
            else 
            {
                this.loadVariable(x, false, scope, proc_actual);
            }

            /* Si hay mas de un parametro transformamos a object para llamar a concat */
            if (concatena)
            {
                this.il.Emit(Emit.OpCodes.Box, getSystemTypeFormat(x.Type));
                tipos[j] = typeof(System.Object);
                j++;
            }
            else
                this.il.Emit(Emit.OpCodes.Call, typeof(System.Console).GetMethod("WriteLine", new System.Type [] { getSystemTypeFormat(x.Type) }));
        }

        /* Si hay n parametros concatenamos y mostramos */
        if (concatena)
        {
            this.il.Emit(Emit.OpCodes.Call, typeof(System.String).GetMethod("Concat", tipos));
            this.il.Emit(Emit.OpCodes.Call, typeof(System.Console).GetMethod("WriteLine", new System.Type [] { typeof(System.Object) }));
        } 
    }

    public void genVariable (Symbol s)
    {
        Emit.FieldBuilder fbuilder = typeBuilder.DefineField(s.Name, getSystemTypeFormat(s.Type),
                                                             Reflect.FieldAttributes.Private | 
                                                             Reflect.FieldAttributes.Static );
        fbuilderTable.Add(s.Name, fbuilder);
    }

    public void genMain ()
    {
        //Debemos poner el ret correcto
        if (this.il != null)
            this.il.Emit(Emit.OpCodes.Ret);

        this.methb = typeBuilder.DefineMethod("Main", Reflect.MethodAttributes.Static, typeof(void),
                                                            System.Type.EmptyTypes);
        this.il = methb.GetILGenerator();
    }

    public void FinishGen ()
    {
         this.il.Emit(Emit.OpCodes.Ret);
         this.typeBuilder.CreateType();
         this.modb.CreateGlobalFunctions();
         this.asmb.SetEntryPoint(methb);
         this.asmb.Save(this.program_name);
         this.il = null;
    }
}
