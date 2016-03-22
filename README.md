# fpc2ILCompiler 
* This is an old stuff I have rescued from one of my old hard disks which I thought that could be interesting to push into my github.
* It is a simple pascal compiler which uses antlr 2.7 to generate C# code for lexer, parser and AST and uses System.Reflection C# clases to generate IL code.
* In examples directory are different pascal examples in order to test the compiler. 
* 
# Compile
* Java Runtime is necessary in order to generate parser, lexer and AST stuff. 
* mono-gmcs is neccessary for generate the compiler final exe file.
* For compile and generate the compiler only exec compile.sh script is neccessary:

    $ ./compile.sh 
    ANTLR Parser Generator   Version 2.7.7 (20060906)   1989-2005
    ANTLR Parser Generator   Version 2.7.7 (20060906)   1989-2005
    ANTLR Parser Generator   Version 2.7.7 (20060906)   1989-2005
    ANTLR Parser Generator   Version 2.7.7 (20060906)   1989-2005
    $

# Preparing the environment
* You have to be MONO_PATH environment variable exported with a path to net-2.0 directory. Then you are ready to use the compiler.

    export MONO_PATH=$MONO_PATH:/home/foo/mini_pascal_compiler/net-2.0/

# How to use
* Using the compiler without argument show usage:
  
  $ ./fpc2ILCompiler.exe 
  Usage: compiler.exe src (must have extension '.pas') [flags...]
  $

  You must provide a ".pas" file as first argument and then you can pass different flags too.

  Avaiable flags are: 

  * --dumpAST: shows the AST used in the compilation.
  * --verbose: shows info about symbol table.

  Examples:

  $ ./fpc2ILCompiler.exe examples/factorial.pas --verbose 
  fpc2il Compiler v0.0.0.1: Mini Pascal to .NET Compiler
  [ Sergio Paracuellos <sergio.paracuellos@gmail.com> ]
  Compilation succeeded.

  *** TABLA DE SIMBOLOS ***

  Global (f) Literal Falsetiene tipo :INT
  Global (factorial) Literal Falsetiene tipo :FUNC
        *Parametro.0-Ref:False: num : INT
        *Local : aux2 : INT
        *Local : aux : INT
        *Devuelve: INT
  Global (numero) Literal Falsetiene tipo :INT

  ***********************

  ./fpc2ILCompiler.exe examples/factorial.pas --dumpAST
  fpc2il Compiler v0.0.0.1: Mini Pascal to .NET Compiler
  [ Sergio Paracuellos <sergio.paracuellos@gmail.com> ]
   ( PROGRAM ( program PruebaDeFactorial ) ( var ( : numero integer ) ) ( var ( : f integer ) ) ( function factorial ( PARAMETROS num integer ) integer ( var ( : aux integer ) ) ( var ( : aux2 integer ) ) ( BLOQUE ( if ( = num 0 ) ( BLOQUE ( := factorial 1 ) ) ( else ( BLOQUE ( := aux ( - num 1 ) ) ( := aux2 ( LLAMADA_FUNCION factorial ( LISTA_ARGUMENTOS aux ) ) ) ( := factorial ( * num aux2 ) ) ) ) ) ) ) ( BLOQUE ( := numero 6 ) ( := f ( LLAMADA_FUNCION factorial ( LISTA_ARGUMENTOS numero ) ) ) ( LLAMADA_PROC writeln ( LISTA_ARGUMENTOS Su factorial es  f ) ) ) . )
   Compilation succeeded.
   usuario@BspLinux:~/mini_pascal_compiler$  

   Output is and exe file which you should be able to execute with mono:

   $ ./PruebaDeFactorial 
   Su factorial es 720
   $ 
