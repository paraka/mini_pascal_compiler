using CommonAST             = antlr.CommonAST;
using Token                 = antlr.Token;
using IToken                = antlr.IToken;
using CommonToken           = antlr.CommonToken;
using Parser                = antlr.Parser;
using AST                   = antlr.collections.AST;
using System;

public class fpc2ilASTWalker: CommonAST 
{
    protected int line;
    protected int col;

    public override void initialize (int i, string s)
    {
        base.initialize(i, s);
    }

    public override void initialize (IToken t)
    {
        base.initialize(t);
        line = t.getLine();
        col = t.getColumn();
    }

    public override void initialize (AST t)
    {
        base.initialize(t);
        line = t.getLine();
        col = t.getColumn();
    }

    public override int getLine() 
    { 
        return line; 
    }

    public override int getColumn() 
    { 
        return col; 
    }
}
