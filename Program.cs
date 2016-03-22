using System;
using System.IO;
using System.Text;
using System.Collections;
using CommonAST             = antlr.CommonAST;
using Token                 = antlr.Token;
using IToken                = antlr.IToken;
using CommonToken           = antlr.CommonToken;
using AST                   = antlr.collections.AST;
using CharScanner           = antlr.CharScanner;
using CharBuffer            = antlr.CharBuffer;
using ASTFrame              = antlr.debug.misc.ASTFrame;
using RecognitionException  = antlr.RecognitionException;
using TokenStreamException  = antlr.TokenStreamException;
using DumpASTVisitor        = antlr.DumpASTVisitor;

namespace fpc2il
{
    class Program
    {
        static void ShowCompilerInfo()
        {
            Console.WriteLine("fpc2il Compiler v0.0.0.1: Mini Pascal to .NET Compiler");
            Console.WriteLine("[ Sergio Paracuellos <sergio.paracuellos@gmail.com> ]");
        }

        static void Main(string[] args)
        {
            Errors err = Errors.Instance;
            bool dumpAST = false;
            bool verbose = false;

            //Parseamos la linea de comandos
            if ( args.Length > 0 ) 
            {
                for ( int i = 1; i < args.Length; i++ ) 
                {
                    if ( args[i] == "--dumpAST" )
                        dumpAST = true;
                    else if ( args[i] == "--verbose" || args[i] == "-v" )
                        verbose = true;
                    else
                        Console.Error.WriteLine( "Ignoring unknown flag '" + args[i] + "'" );
                 }


                FileInfo srcFile = new FileInfo( args[0] );

                if ( srcFile.Extension == ".pas" ) 
                {
                    ShowCompilerInfo();

                    fpc2ilLexer lexer = new fpc2ilLexer( new CharBuffer( srcFile.OpenText() ) );
                    lexer.setFilename( args[0] );
                    lexer.setTokenObjectClass("fpc2ilCommonToken");

                    fpc2ilParser parser = new fpc2ilParser ( lexer );
                    parser.setFilename( args[0] );
                    parser.setASTNodeClass("fpc2ilASTWalker");
                    parser.programa();

                    if (err.NumErrors != 0)
                    {
                        Console.Error.WriteLine();
                        err.showErrors(args[0]);
                        Console.Error.WriteLine("Compilation failed: " + err.NumErrors + " error(s)");
                    } 
                    else 
                    {
                        //CommonAST t = (CommonAST)parser. getAST();
                        fpc2ilASTWalker t = (fpc2ilASTWalker)parser. getAST();
                
                        //debug: AST grafico para los humanos :-)
                        //ASTFrame frame = new ASTFrame(args[0], t);
                        //frame.ShowDialog();
                        if (dumpAST)
                            Console.Out.WriteLine(t.ToStringTree());

                        //DumpASTVisitor visitor = new DumpASTVisitor();
                        //visitor.visit(t);

                        fpc2ilTreeParser treeParser = new fpc2ilTreeParser();
                        treeParser.setASTNodeClass("fpc2ilASTWalker");
                        treeParser.programa(t);

                        if (err.NumErrors != 0) 
                        {
                            Console.Error.WriteLine();
                            err.showErrors(args[0]);
                            Console.Error.WriteLine("Compilation failed: " + err.NumErrors + " error(s)");
                        } 
                        else 
                        {
                            fpc2ilCodeGenerator gen = new fpc2ilCodeGenerator();
                            gen.programa(t);
                            if (err.NumErrors != 0) 
                            {
                                Console.Error.WriteLine();
                                err.showErrors(args[0]);
                                Console.Error.WriteLine("Compilation failed: " + err.NumErrors + " error(s)");
                            } 
                            else 
                            {
                                gen.FinishCode();
                                Console.Error.WriteLine("Compilation succeeded.");
                            }
                        }
                    
                        if (verbose) 
                        {
                            Symboltable symtab = Symboltable.Instance;
                            symtab.dump();
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("Compilation failed: source filename must have '.pas' extension.");
                }   
            } 
            else 
            {
                 Console.Error.WriteLine( "Usage: compiler.exe src (must have extension '.pas') [flags...]" );
            }
        }
    }
}
