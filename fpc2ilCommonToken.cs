using Token                 = antlr.Token;
using IToken                = antlr.IToken;
using CommonToken           = antlr.CommonToken;
using System;

public class fpc2ilCommonToken : CommonToken
{
    protected int line;
    protected int col;

    public override int getLine() {  line = base.getLine(); return line; }
    public override int getColumn() { col = base.getColumn(); return col; }
}
