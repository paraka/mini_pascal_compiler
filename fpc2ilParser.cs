// $ANTLR 2.7.7 (20060906): "fpc2ilParser.g" -> "fpc2ilParser.cs"$

	// Generate the header common to all output files.
	using System;
	
	using TokenBuffer              = antlr.TokenBuffer;
	using TokenStreamException     = antlr.TokenStreamException;
	using TokenStreamIOException   = antlr.TokenStreamIOException;
	using ANTLRException           = antlr.ANTLRException;
	using LLkParser = antlr.LLkParser;
	using Token                    = antlr.Token;
	using IToken                   = antlr.IToken;
	using TokenStream              = antlr.TokenStream;
	using RecognitionException     = antlr.RecognitionException;
	using NoViableAltException     = antlr.NoViableAltException;
	using MismatchedTokenException = antlr.MismatchedTokenException;
	using SemanticException        = antlr.SemanticException;
	using ParserSharedInputState   = antlr.ParserSharedInputState;
	using BitSet                   = antlr.collections.impl.BitSet;
	using AST                      = antlr.collections.AST;
	using ASTPair                  = antlr.ASTPair;
	using ASTFactory               = antlr.ASTFactory;
	using ASTArray                 = antlr.collections.impl.ASTArray;
	
	public 	class fpc2ilParser : antlr.LLkParser
	{
		public const int EOF = 1;
		public const int NULL_TREE_LOOKAHEAD = 3;
		public const int TIPO_ENTERO = 4;
		public const int TIPO_CADENA = 5;
		public const int TIPO_REAL = 6;
		public const int TIPO_BOOLEANO = 7;
		public const int TIPO_CHAR = 8;
		public const int LIT_CIERTO = 9;
		public const int LIT_FALSO = 10;
		public const int RES_PROGRAM = 11;
		public const int RES_VAR = 12;
		public const int RES_CONST = 13;
		public const int RES_BEGIN = 14;
		public const int RES_END = 15;
		public const int RES_FOR = 16;
		public const int RES_IF = 17;
		public const int RES_THEN = 18;
		public const int RES_ELSE = 19;
		public const int RES_TO = 20;
		public const int RES_DO = 21;
		public const int RES_WHILE = 22;
		public const int RES_REPEAT = 23;
		public const int RES_UNTIL = 24;
		public const int RES_FUNCTION = 25;
		public const int RES_PROCEDURE = 26;
		public const int RES_RETURN = 27;
		public const int OP_DIV = 28;
		public const int OP_MOD = 29;
		public const int OP_Y = 30;
		public const int OP_O = 31;
		public const int OP_NEG = 32;
		public const int LIT_ENTERO = 33;
		public const int LIT_REAL = 34;
		public const int BLANCO = 35;
		public const int DIGITO = 36;
		public const int LETRA = 37;
		public const int IDENT = 38;
		public const int PUNTO_COMA = 39;
		public const int COMA = 40;
		public const int DOS_PUNTOS = 41;
		public const int PUNTO = 42;
		public const int PARENT_AB = 43;
		public const int PARENT_CE = 44;
		public const int OP_IGUAL = 45;
		public const int OP_ASSING = 46;
		public const int OP_MAYOR = 47;
		public const int OP_MENOR = 48;
		public const int OP_MAYOR_IGUAL = 49;
		public const int OP_MENOR_IGUAL = 50;
		public const int OP_DISTINTO = 51;
		public const int OP_MAS = 52;
		public const int OP_MENOS = 53;
		public const int OP_PRODUCTO = 54;
		public const int OP_DIVISION = 55;
		public const int LIT_NUMERO = 56;
		public const int COMENTARIO = 57;
		public const int LIT_CADENA = 58;
		public const int PROGRAMA = 59;
		public const int PARAMETROS = 60;
		public const int DEVUELVE = 61;
		public const int LISTA_IDS = 62;
		public const int BLOQUE = 63;
		public const int LISTA_ARGUMENTOS = 64;
		public const int LLAMADA_FUNCION = 65;
		public const int LLAMADA_PROC = 66;
		public const int LIT_CHAR = 67;
		
		
    protected Errors err = Errors.Instance;

    public override void reportError (RecognitionException e)
    {
        //Console.ForegroundColor = ConsoleColor.Red;
        err.addError(e.Message, e.getLine(), e.getColumn());
        //Console.ResetColor();
    }
		
		protected void initialize()
		{
			tokenNames = tokenNames_;
			initializeFactory();
		}
		
		
		protected fpc2ilParser(TokenBuffer tokenBuf, int k) : base(tokenBuf, k)
		{
			initialize();
		}
		
		public fpc2ilParser(TokenBuffer tokenBuf) : this(tokenBuf,2)
		{
		}
		
		protected fpc2ilParser(TokenStream lexer, int k) : base(lexer,k)
		{
			initialize();
		}
		
		public fpc2ilParser(TokenStream lexer) : this(lexer,2)
		{
		}
		
		public fpc2ilParser(ParserSharedInputState state) : base(state,2)
		{
			initialize();
		}
		
	public void programa() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST programa_AST = null;
		
		try {      // for error handling
			{ // ( ... )+
				int _cnt3=0;
				for (;;)
				{
					if ((LA(1)==RES_PROGRAM))
					{
						declaracionPrograma();
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					else
					{
						if (_cnt3 >= 1) { goto _loop3_breakloop; } else { throw new NoViableAltException(LT(1), getFilename());; }
					}
					
					_cnt3++;
				}
_loop3_breakloop:				;
			}    // ( ... )+
			programa_AST = (AST)currentAST.root;
			programa_AST = (AST) astFactory.make(astFactory.create(PROGRAMA,"PROGRAM"), programa_AST);
			currentAST.root = programa_AST;
			if ( (null != programa_AST) && (null != programa_AST.getFirstChild()) )
				currentAST.child = programa_AST.getFirstChild();
			else
				currentAST.child = programa_AST;
			currentAST.advanceChildToEnd();
			bloque();
			astFactory.addASTChild(ref currentAST, returnAST);
			AST tmp1_AST = null;
			tmp1_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp1_AST);
			match(PUNTO);
			programa_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_0_);
		}
		returnAST = programa_AST;
	}
	
	public void declaracionPrograma() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST declaracionPrograma_AST = null;
		IToken  id = null;
		AST id_AST = null;
		
		try {      // for error handling
			AST tmp2_AST = null;
			tmp2_AST = astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, tmp2_AST);
			match(RES_PROGRAM);
			id = LT(1);
			id_AST = astFactory.create(id);
			astFactory.addASTChild(ref currentAST, id_AST);
			match(IDENT);
			match(PUNTO_COMA);
			declaracionPrograma_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_1_);
		}
		returnAST = declaracionPrograma_AST;
	}
	
	public void bloque() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST bloque_AST = null;
		
		try {      // for error handling
			{    // ( ... )*
				for (;;)
				{
					switch ( LA(1) )
					{
					case RES_CONST:
					{
						declaracionConstante();
						astFactory.addASTChild(ref currentAST, returnAST);
						break;
					}
					case RES_VAR:
					{
						declaracionVariable();
						astFactory.addASTChild(ref currentAST, returnAST);
						break;
					}
					case RES_FUNCTION:
					case RES_PROCEDURE:
					{
						decprocedimientoYFuncion();
						astFactory.addASTChild(ref currentAST, returnAST);
						break;
					}
					default:
					{
						goto _loop7_breakloop;
					}
					 }
				}
_loop7_breakloop:				;
			}    // ( ... )*
			bloque_sentencia();
			astFactory.addASTChild(ref currentAST, returnAST);
			bloque_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_2_);
		}
		returnAST = bloque_AST;
	}
	
	public void declaracionConstante() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST declaracionConstante_AST = null;
		
		try {      // for error handling
			AST tmp4_AST = null;
			tmp4_AST = astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, tmp4_AST);
			match(RES_CONST);
			definicionCte();
			astFactory.addASTChild(ref currentAST, returnAST);
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==PUNTO_COMA) && (LA(2)==IDENT))
					{
						match(PUNTO_COMA);
						definicionCte();
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					else
					{
						goto _loop10_breakloop;
					}
					
				}
_loop10_breakloop:				;
			}    // ( ... )*
			match(PUNTO_COMA);
			declaracionConstante_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_3_);
		}
		returnAST = declaracionConstante_AST;
	}
	
	public void declaracionVariable() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST declaracionVariable_AST = null;
		
		try {      // for error handling
			AST tmp7_AST = null;
			tmp7_AST = astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, tmp7_AST);
			match(RES_VAR);
			definicionVar();
			astFactory.addASTChild(ref currentAST, returnAST);
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==PUNTO_COMA) && (LA(2)==IDENT))
					{
						match(PUNTO_COMA);
						definicionVar();
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					else
					{
						goto _loop14_breakloop;
					}
					
				}
_loop14_breakloop:				;
			}    // ( ... )*
			match(PUNTO_COMA);
			declaracionVariable_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_3_);
		}
		returnAST = declaracionVariable_AST;
	}
	
	public void decprocedimientoYFuncion() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST decprocedimientoYFuncion_AST = null;
		
		try {      // for error handling
			procedimientoOFuncion();
			astFactory.addASTChild(ref currentAST, returnAST);
			match(PUNTO_COMA);
			decprocedimientoYFuncion_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_3_);
		}
		returnAST = decprocedimientoYFuncion_AST;
	}
	
	public void bloque_sentencia() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST bloque_sentencia_AST = null;
		
		try {      // for error handling
			match(RES_BEGIN);
			sentencias();
			astFactory.addASTChild(ref currentAST, returnAST);
			match(RES_END);
			bloque_sentencia_AST = (AST)currentAST.root;
			bloque_sentencia_AST = (AST) astFactory.make(astFactory.create(BLOQUE,"BLOQUE"), bloque_sentencia_AST);
			currentAST.root = bloque_sentencia_AST;
			if ( (null != bloque_sentencia_AST) && (null != bloque_sentencia_AST.getFirstChild()) )
				currentAST.child = bloque_sentencia_AST.getFirstChild();
			else
				currentAST.child = bloque_sentencia_AST;
			currentAST.advanceChildToEnd();
			bloque_sentencia_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_4_);
		}
		returnAST = bloque_sentencia_AST;
	}
	
	public void definicionCte() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST definicionCte_AST = null;
		
		try {      // for error handling
			AST tmp13_AST = null;
			tmp13_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp13_AST);
			match(IDENT);
			AST tmp14_AST = null;
			tmp14_AST = astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, tmp14_AST);
			match(OP_IGUAL);
			literal();
			astFactory.addASTChild(ref currentAST, returnAST);
			definicionCte_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_5_);
		}
		returnAST = definicionCte_AST;
	}
	
	public void literal() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST literal_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LIT_ENTERO:
			{
				AST tmp15_AST = null;
				tmp15_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp15_AST);
				match(LIT_ENTERO);
				literal_AST = currentAST.root;
				break;
			}
			case LIT_REAL:
			{
				AST tmp16_AST = null;
				tmp16_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp16_AST);
				match(LIT_REAL);
				literal_AST = currentAST.root;
				break;
			}
			case LIT_CADENA:
			{
				AST tmp17_AST = null;
				tmp17_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp17_AST);
				match(LIT_CADENA);
				literal_AST = currentAST.root;
				break;
			}
			case LIT_CHAR:
			{
				AST tmp18_AST = null;
				tmp18_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp18_AST);
				match(LIT_CHAR);
				literal_AST = currentAST.root;
				break;
			}
			case LIT_CIERTO:
			case LIT_FALSO:
			{
				literal_booleano();
				astFactory.addASTChild(ref currentAST, returnAST);
				literal_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_6_);
		}
		returnAST = literal_AST;
	}
	
	public void definicionVar() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST definicionVar_AST = null;
		IToken  c = null;
		AST c_AST = null;
		
		try {      // for error handling
			listaIdents();
			astFactory.addASTChild(ref currentAST, returnAST);
			c = LT(1);
			c_AST = astFactory.create(c);
			astFactory.makeASTRoot(ref currentAST, c_AST);
			match(DOS_PUNTOS);
			tipo();
			astFactory.addASTChild(ref currentAST, returnAST);
			definicionVar_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_5_);
		}
		returnAST = definicionVar_AST;
	}
	
	public void listaIdents() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST listaIdents_AST = null;
		IToken  id = null;
		AST id_AST = null;
		
		try {      // for error handling
			id = LT(1);
			id_AST = astFactory.create(id);
			astFactory.addASTChild(ref currentAST, id_AST);
			match(IDENT);
			listaIdents_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_7_);
		}
		returnAST = listaIdents_AST;
	}
	
	public void tipo() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST tipo_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case TIPO_ENTERO:
			{
				AST tmp19_AST = null;
				tmp19_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp19_AST);
				match(TIPO_ENTERO);
				tipo_AST = currentAST.root;
				break;
			}
			case TIPO_REAL:
			{
				AST tmp20_AST = null;
				tmp20_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp20_AST);
				match(TIPO_REAL);
				tipo_AST = currentAST.root;
				break;
			}
			case TIPO_BOOLEANO:
			{
				AST tmp21_AST = null;
				tmp21_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp21_AST);
				match(TIPO_BOOLEANO);
				tipo_AST = currentAST.root;
				break;
			}
			case TIPO_CADENA:
			{
				AST tmp22_AST = null;
				tmp22_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp22_AST);
				match(TIPO_CADENA);
				tipo_AST = currentAST.root;
				break;
			}
			case TIPO_CHAR:
			{
				AST tmp23_AST = null;
				tmp23_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp23_AST);
				match(TIPO_CHAR);
				tipo_AST = currentAST.root;
				break;
			}
			case IDENT:
			{
				AST tmp24_AST = null;
				tmp24_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp24_AST);
				match(IDENT);
				tipo_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_8_);
		}
		returnAST = tipo_AST;
	}
	
	public void procedimientoOFuncion() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST procedimientoOFuncion_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case RES_PROCEDURE:
			{
				declaracionProc();
				astFactory.addASTChild(ref currentAST, returnAST);
				procedimientoOFuncion_AST = currentAST.root;
				break;
			}
			case RES_FUNCTION:
			{
				declaracionFunc();
				astFactory.addASTChild(ref currentAST, returnAST);
				procedimientoOFuncion_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_5_);
		}
		returnAST = procedimientoOFuncion_AST;
	}
	
	public void declaracionProc() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST declaracionProc_AST = null;
		IToken  id = null;
		AST id_AST = null;
		
		try {      // for error handling
			AST tmp25_AST = null;
			tmp25_AST = astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, tmp25_AST);
			match(RES_PROCEDURE);
			id = LT(1);
			id_AST = astFactory.create(id);
			astFactory.addASTChild(ref currentAST, id_AST);
			match(IDENT);
			{
				switch ( LA(1) )
				{
				case PARENT_AB:
				{
					listaParametros();
					astFactory.addASTChild(ref currentAST, returnAST);
					break;
				}
				case PUNTO_COMA:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			match(PUNTO_COMA);
			bloque();
			astFactory.addASTChild(ref currentAST, returnAST);
			declaracionProc_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_5_);
		}
		returnAST = declaracionProc_AST;
	}
	
	public void declaracionFunc() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST declaracionFunc_AST = null;
		IToken  id = null;
		AST id_AST = null;
		AST t_AST = null;
		
		try {      // for error handling
			AST tmp27_AST = null;
			tmp27_AST = astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, tmp27_AST);
			match(RES_FUNCTION);
			id = LT(1);
			id_AST = astFactory.create(id);
			astFactory.addASTChild(ref currentAST, id_AST);
			match(IDENT);
			{
				switch ( LA(1) )
				{
				case PARENT_AB:
				{
					listaParametros();
					astFactory.addASTChild(ref currentAST, returnAST);
					break;
				}
				case DOS_PUNTOS:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			match(DOS_PUNTOS);
			tipoDevuelto();
			t_AST = (AST)returnAST;
			astFactory.addASTChild(ref currentAST, returnAST);
			match(PUNTO_COMA);
			bloque();
			astFactory.addASTChild(ref currentAST, returnAST);
			declaracionFunc_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_5_);
		}
		returnAST = declaracionFunc_AST;
	}
	
	public void listaParametros() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST listaParametros_AST = null;
		
		try {      // for error handling
			match(PARENT_AB);
			seccionParametros();
			astFactory.addASTChild(ref currentAST, returnAST);
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==PUNTO_COMA))
					{
						match(PUNTO_COMA);
						seccionParametros();
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					else
					{
						goto _loop26_breakloop;
					}
					
				}
_loop26_breakloop:				;
			}    // ( ... )*
			match(PARENT_CE);
			listaParametros_AST = (AST)currentAST.root;
			listaParametros_AST = (AST) astFactory.make(astFactory.create(PARAMETROS,"PARAMETROS"), listaParametros_AST);
			currentAST.root = listaParametros_AST;
			if ( (null != listaParametros_AST) && (null != listaParametros_AST.getFirstChild()) )
				currentAST.child = listaParametros_AST.getFirstChild();
			else
				currentAST.child = listaParametros_AST;
			currentAST.advanceChildToEnd();
			listaParametros_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_9_);
		}
		returnAST = listaParametros_AST;
	}
	
	public void seccionParametros() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST seccionParametros_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case IDENT:
			{
				grupoParametros();
				astFactory.addASTChild(ref currentAST, returnAST);
				seccionParametros_AST = currentAST.root;
				break;
			}
			case RES_VAR:
			{
				AST tmp33_AST = null;
				tmp33_AST = astFactory.create(LT(1));
				astFactory.makeASTRoot(ref currentAST, tmp33_AST);
				match(RES_VAR);
				grupoParametros();
				astFactory.addASTChild(ref currentAST, returnAST);
				seccionParametros_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_8_);
		}
		returnAST = seccionParametros_AST;
	}
	
	public void grupoParametros() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST grupoParametros_AST = null;
		AST ids_AST = null;
		AST t_AST = null;
		
		try {      // for error handling
			listaIdents();
			ids_AST = (AST)returnAST;
			astFactory.addASTChild(ref currentAST, returnAST);
			match(DOS_PUNTOS);
			tipo();
			t_AST = (AST)returnAST;
			astFactory.addASTChild(ref currentAST, returnAST);
			grupoParametros_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_8_);
		}
		returnAST = grupoParametros_AST;
	}
	
	public void tipoDevuelto() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST tipoDevuelto_AST = null;
		AST t_AST = null;
		
		try {      // for error handling
			tipo();
			t_AST = (AST)returnAST;
			astFactory.addASTChild(ref currentAST, returnAST);
			tipoDevuelto_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_5_);
		}
		returnAST = tipoDevuelto_AST;
	}
	
	public void literal_booleano() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST literal_booleano_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LIT_CIERTO:
			{
				AST tmp35_AST = null;
				tmp35_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp35_AST);
				match(LIT_CIERTO);
				literal_booleano_AST = currentAST.root;
				break;
			}
			case LIT_FALSO:
			{
				AST tmp36_AST = null;
				tmp36_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp36_AST);
				match(LIT_FALSO);
				literal_booleano_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_6_);
		}
		returnAST = literal_booleano_AST;
	}
	
	public void sentencia() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST sentencia_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case RES_BEGIN:
			case IDENT:
			{
				sentenciaSimple();
				astFactory.addASTChild(ref currentAST, returnAST);
				sentencia_AST = currentAST.root;
				break;
			}
			case RES_END:
			case RES_FOR:
			case RES_IF:
			case RES_ELSE:
			case RES_WHILE:
			case RES_REPEAT:
			case RES_UNTIL:
			case PUNTO_COMA:
			{
				expresionCompuesta();
				astFactory.addASTChild(ref currentAST, returnAST);
				sentencia_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_10_);
		}
		returnAST = sentencia_AST;
	}
	
	public void sentenciaSimple() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST sentenciaSimple_AST = null;
		
		try {      // for error handling
			if ((LA(1)==RES_BEGIN))
			{
				bloque_sentencia();
				astFactory.addASTChild(ref currentAST, returnAST);
				sentenciaSimple_AST = currentAST.root;
			}
			else if ((LA(1)==IDENT) && (LA(2)==OP_ASSING)) {
				asignacion();
				astFactory.addASTChild(ref currentAST, returnAST);
				sentenciaSimple_AST = currentAST.root;
			}
			else if ((LA(1)==IDENT) && (tokenSet_11_.member(LA(2)))) {
				llamadaProc();
				astFactory.addASTChild(ref currentAST, returnAST);
				sentenciaSimple_AST = currentAST.root;
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_10_);
		}
		returnAST = sentenciaSimple_AST;
	}
	
	public void expresionCompuesta() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST expresionCompuesta_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case RES_END:
			case RES_ELSE:
			case RES_UNTIL:
			case PUNTO_COMA:
			{
				expresionCompuesta_AST = currentAST.root;
				break;
			}
			case RES_IF:
			{
				expresionCondicional();
				astFactory.addASTChild(ref currentAST, returnAST);
				expresionCompuesta_AST = currentAST.root;
				break;
			}
			case RES_FOR:
			case RES_WHILE:
			case RES_REPEAT:
			{
				expresionBucle();
				astFactory.addASTChild(ref currentAST, returnAST);
				expresionCompuesta_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_10_);
		}
		returnAST = expresionCompuesta_AST;
	}
	
	public void asignacion() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST asignacion_AST = null;
		
		try {      // for error handling
			AST tmp37_AST = null;
			tmp37_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp37_AST);
			match(IDENT);
			AST tmp38_AST = null;
			tmp38_AST = astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, tmp38_AST);
			match(OP_ASSING);
			expresion();
			astFactory.addASTChild(ref currentAST, returnAST);
			asignacion_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_10_);
		}
		returnAST = asignacion_AST;
	}
	
	public void llamadaProc() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST llamadaProc_AST = null;
		IToken  id = null;
		AST id_AST = null;
		AST args_AST = null;
		
		try {      // for error handling
			id = LT(1);
			id_AST = astFactory.create(id);
			match(IDENT);
			{
				switch ( LA(1) )
				{
				case PARENT_AB:
				{
					match(PARENT_AB);
					listaArgumentos();
					args_AST = (AST)returnAST;
					match(PARENT_CE);
					break;
				}
				case RES_END:
				case RES_ELSE:
				case RES_UNTIL:
				case PUNTO_COMA:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			llamadaProc_AST = (AST)currentAST.root;
			llamadaProc_AST = (AST) astFactory.make(astFactory.create(LLAMADA_PROC,"LLAMADA_PROC"), id_AST, args_AST);
			currentAST.root = llamadaProc_AST;
			if ( (null != llamadaProc_AST) && (null != llamadaProc_AST.getFirstChild()) )
				currentAST.child = llamadaProc_AST.getFirstChild();
			else
				currentAST.child = llamadaProc_AST;
			currentAST.advanceChildToEnd();
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_10_);
		}
		returnAST = llamadaProc_AST;
	}
	
	public void listaArgumentos() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST listaArgumentos_AST = null;
		
		try {      // for error handling
			argumentoActual();
			astFactory.addASTChild(ref currentAST, returnAST);
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMA))
					{
						match(COMA);
						argumentoActual();
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					else
					{
						goto _loop54_breakloop;
					}
					
				}
_loop54_breakloop:				;
			}    // ( ... )*
			listaArgumentos_AST = (AST)currentAST.root;
			listaArgumentos_AST = (AST) astFactory.make(astFactory.create(LISTA_ARGUMENTOS,"LISTA_ARGUMENTOS"), listaArgumentos_AST);
			currentAST.root = listaArgumentos_AST;
			if ( (null != listaArgumentos_AST) && (null != listaArgumentos_AST.getFirstChild()) )
				currentAST.child = listaArgumentos_AST.getFirstChild();
			else
				currentAST.child = listaArgumentos_AST;
			currentAST.advanceChildToEnd();
			listaArgumentos_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_12_);
		}
		returnAST = listaArgumentos_AST;
	}
	
	public void expresion() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST expresion_AST = null;
		
		try {      // for error handling
			expresionSimple();
			astFactory.addASTChild(ref currentAST, returnAST);
			{    // ( ... )*
				for (;;)
				{
					if ((tokenSet_13_.member(LA(1))))
					{
						{
							switch ( LA(1) )
							{
							case OP_IGUAL:
							{
								AST tmp42_AST = null;
								tmp42_AST = astFactory.create(LT(1));
								astFactory.makeASTRoot(ref currentAST, tmp42_AST);
								match(OP_IGUAL);
								break;
							}
							case OP_DISTINTO:
							{
								AST tmp43_AST = null;
								tmp43_AST = astFactory.create(LT(1));
								astFactory.makeASTRoot(ref currentAST, tmp43_AST);
								match(OP_DISTINTO);
								break;
							}
							case OP_MAYOR:
							{
								AST tmp44_AST = null;
								tmp44_AST = astFactory.create(LT(1));
								astFactory.makeASTRoot(ref currentAST, tmp44_AST);
								match(OP_MAYOR);
								break;
							}
							case OP_MENOR:
							{
								AST tmp45_AST = null;
								tmp45_AST = astFactory.create(LT(1));
								astFactory.makeASTRoot(ref currentAST, tmp45_AST);
								match(OP_MENOR);
								break;
							}
							case OP_MAYOR_IGUAL:
							{
								AST tmp46_AST = null;
								tmp46_AST = astFactory.create(LT(1));
								astFactory.makeASTRoot(ref currentAST, tmp46_AST);
								match(OP_MAYOR_IGUAL);
								break;
							}
							case OP_MENOR_IGUAL:
							{
								AST tmp47_AST = null;
								tmp47_AST = astFactory.create(LT(1));
								astFactory.makeASTRoot(ref currentAST, tmp47_AST);
								match(OP_MENOR_IGUAL);
								break;
							}
							default:
							{
								throw new NoViableAltException(LT(1), getFilename());
							}
							 }
						}
						expresionSimple();
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					else
					{
						goto _loop40_breakloop;
					}
					
				}
_loop40_breakloop:				;
			}    // ( ... )*
			expresion_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_14_);
		}
		returnAST = expresion_AST;
	}
	
	public void expresionSimple() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST expresionSimple_AST = null;
		
		try {      // for error handling
			term();
			astFactory.addASTChild(ref currentAST, returnAST);
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==OP_O||LA(1)==OP_MAS||LA(1)==OP_MENOS))
					{
						{
							switch ( LA(1) )
							{
							case OP_MAS:
							{
								AST tmp48_AST = null;
								tmp48_AST = astFactory.create(LT(1));
								astFactory.makeASTRoot(ref currentAST, tmp48_AST);
								match(OP_MAS);
								break;
							}
							case OP_MENOS:
							{
								AST tmp49_AST = null;
								tmp49_AST = astFactory.create(LT(1));
								astFactory.makeASTRoot(ref currentAST, tmp49_AST);
								match(OP_MENOS);
								break;
							}
							case OP_O:
							{
								AST tmp50_AST = null;
								tmp50_AST = astFactory.create(LT(1));
								astFactory.makeASTRoot(ref currentAST, tmp50_AST);
								match(OP_O);
								break;
							}
							default:
							{
								throw new NoViableAltException(LT(1), getFilename());
							}
							 }
						}
						term();
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					else
					{
						goto _loop44_breakloop;
					}
					
				}
_loop44_breakloop:				;
			}    // ( ... )*
			expresionSimple_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_15_);
		}
		returnAST = expresionSimple_AST;
	}
	
	public void term() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST term_AST = null;
		
		try {      // for error handling
			factor();
			astFactory.addASTChild(ref currentAST, returnAST);
			{    // ( ... )*
				for (;;)
				{
					if ((tokenSet_16_.member(LA(1))))
					{
						{
							switch ( LA(1) )
							{
							case OP_PRODUCTO:
							{
								AST tmp51_AST = null;
								tmp51_AST = astFactory.create(LT(1));
								astFactory.makeASTRoot(ref currentAST, tmp51_AST);
								match(OP_PRODUCTO);
								break;
							}
							case OP_DIVISION:
							{
								AST tmp52_AST = null;
								tmp52_AST = astFactory.create(LT(1));
								astFactory.makeASTRoot(ref currentAST, tmp52_AST);
								match(OP_DIVISION);
								break;
							}
							case OP_DIV:
							{
								AST tmp53_AST = null;
								tmp53_AST = astFactory.create(LT(1));
								astFactory.makeASTRoot(ref currentAST, tmp53_AST);
								match(OP_DIV);
								break;
							}
							case OP_MOD:
							{
								AST tmp54_AST = null;
								tmp54_AST = astFactory.create(LT(1));
								astFactory.makeASTRoot(ref currentAST, tmp54_AST);
								match(OP_MOD);
								break;
							}
							case OP_Y:
							{
								AST tmp55_AST = null;
								tmp55_AST = astFactory.create(LT(1));
								astFactory.makeASTRoot(ref currentAST, tmp55_AST);
								match(OP_Y);
								break;
							}
							default:
							{
								throw new NoViableAltException(LT(1), getFilename());
							}
							 }
						}
						factor();
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					else
					{
						goto _loop48_breakloop;
					}
					
				}
_loop48_breakloop:				;
			}    // ( ... )*
			term_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_17_);
		}
		returnAST = term_AST;
	}
	
	public void factor() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST factor_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LIT_CIERTO:
			case LIT_FALSO:
			case LIT_ENTERO:
			case LIT_REAL:
			case LIT_CADENA:
			case LIT_CHAR:
			{
				literal();
				astFactory.addASTChild(ref currentAST, returnAST);
				factor_AST = currentAST.root;
				break;
			}
			case OP_NEG:
			{
				AST tmp56_AST = null;
				tmp56_AST = astFactory.create(LT(1));
				astFactory.makeASTRoot(ref currentAST, tmp56_AST);
				match(OP_NEG);
				factor();
				astFactory.addASTChild(ref currentAST, returnAST);
				factor_AST = currentAST.root;
				break;
			}
			default:
				if ((LA(1)==IDENT) && (tokenSet_18_.member(LA(2))))
				{
					AST tmp57_AST = null;
					tmp57_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp57_AST);
					match(IDENT);
					factor_AST = currentAST.root;
				}
				else if ((LA(1)==IDENT) && (LA(2)==PARENT_AB||LA(2)==PARENT_CE)) {
					llamadaFunction();
					astFactory.addASTChild(ref currentAST, returnAST);
					factor_AST = currentAST.root;
				}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			break; }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_18_);
		}
		returnAST = factor_AST;
	}
	
	public void llamadaFunction() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST llamadaFunction_AST = null;
		IToken  id = null;
		AST id_AST = null;
		AST args_AST = null;
		
		try {      // for error handling
			id = LT(1);
			id_AST = astFactory.create(id);
			match(IDENT);
			{
				switch ( LA(1) )
				{
				case PARENT_AB:
				{
					match(PARENT_AB);
					listaArgumentos();
					args_AST = (AST)returnAST;
					break;
				}
				case PARENT_CE:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			match(PARENT_CE);
			llamadaFunction_AST = (AST)currentAST.root;
			llamadaFunction_AST = (AST) astFactory.make(astFactory.create(LLAMADA_FUNCION,"LLAMADA_FUNCION"), id_AST, args_AST);
			currentAST.root = llamadaFunction_AST;
			if ( (null != llamadaFunction_AST) && (null != llamadaFunction_AST.getFirstChild()) )
				currentAST.child = llamadaFunction_AST.getFirstChild();
			else
				currentAST.child = llamadaFunction_AST;
			currentAST.advanceChildToEnd();
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_18_);
		}
		returnAST = llamadaFunction_AST;
	}
	
	public void argumentoActual() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST argumentoActual_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case IDENT:
			{
				AST tmp60_AST = null;
				tmp60_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp60_AST);
				match(IDENT);
				argumentoActual_AST = currentAST.root;
				break;
			}
			case LIT_CIERTO:
			case LIT_FALSO:
			case LIT_ENTERO:
			case LIT_REAL:
			case LIT_CADENA:
			case LIT_CHAR:
			{
				literal();
				astFactory.addASTChild(ref currentAST, returnAST);
				argumentoActual_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_19_);
		}
		returnAST = argumentoActual_AST;
	}
	
	public void expresionCondicional() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST expresionCondicional_AST = null;
		
		try {      // for error handling
			expresionIf();
			astFactory.addASTChild(ref currentAST, returnAST);
			expresionCondicional_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_10_);
		}
		returnAST = expresionCondicional_AST;
	}
	
	public void expresionBucle() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST expresionBucle_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case RES_FOR:
			{
				expresionFor();
				astFactory.addASTChild(ref currentAST, returnAST);
				expresionBucle_AST = currentAST.root;
				break;
			}
			case RES_WHILE:
			{
				expresionWhile();
				astFactory.addASTChild(ref currentAST, returnAST);
				expresionBucle_AST = currentAST.root;
				break;
			}
			case RES_REPEAT:
			{
				expresionRepeat();
				astFactory.addASTChild(ref currentAST, returnAST);
				expresionBucle_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_10_);
		}
		returnAST = expresionBucle_AST;
	}
	
	public void sentencias() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST sentencias_AST = null;
		
		try {      // for error handling
			sentencia();
			astFactory.addASTChild(ref currentAST, returnAST);
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==PUNTO_COMA))
					{
						match(PUNTO_COMA);
						sentencia();
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					else
					{
						goto _loop60_breakloop;
					}
					
				}
_loop60_breakloop:				;
			}    // ( ... )*
			sentencias_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_20_);
		}
		returnAST = sentencias_AST;
	}
	
	public void expresionIf() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST expresionIf_AST = null;
		
		try {      // for error handling
			AST tmp62_AST = null;
			tmp62_AST = astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, tmp62_AST);
			match(RES_IF);
			expresion();
			astFactory.addASTChild(ref currentAST, returnAST);
			match(RES_THEN);
			sentencia();
			astFactory.addASTChild(ref currentAST, returnAST);
			{
				if ((LA(1)==RES_ELSE) && (tokenSet_21_.member(LA(2))))
				{
					expresionElse();
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				else if ((tokenSet_10_.member(LA(1))) && (tokenSet_22_.member(LA(2)))) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			expresionIf_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_10_);
		}
		returnAST = expresionIf_AST;
	}
	
	public void expresionElse() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST expresionElse_AST = null;
		
		try {      // for error handling
			AST tmp64_AST = null;
			tmp64_AST = astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, tmp64_AST);
			match(RES_ELSE);
			sentencia();
			astFactory.addASTChild(ref currentAST, returnAST);
			expresionElse_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_10_);
		}
		returnAST = expresionElse_AST;
	}
	
	public void expresionFor() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST expresionFor_AST = null;
		
		try {      // for error handling
			AST tmp65_AST = null;
			tmp65_AST = astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, tmp65_AST);
			match(RES_FOR);
			AST tmp66_AST = null;
			tmp66_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp66_AST);
			match(IDENT);
			match(OP_ASSING);
			listaFor();
			astFactory.addASTChild(ref currentAST, returnAST);
			match(RES_DO);
			sentencia();
			astFactory.addASTChild(ref currentAST, returnAST);
			expresionFor_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_10_);
		}
		returnAST = expresionFor_AST;
	}
	
	public void expresionWhile() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST expresionWhile_AST = null;
		
		try {      // for error handling
			AST tmp69_AST = null;
			tmp69_AST = astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, tmp69_AST);
			match(RES_WHILE);
			expresion();
			astFactory.addASTChild(ref currentAST, returnAST);
			match(RES_DO);
			sentencia();
			astFactory.addASTChild(ref currentAST, returnAST);
			expresionWhile_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_10_);
		}
		returnAST = expresionWhile_AST;
	}
	
	public void expresionRepeat() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST expresionRepeat_AST = null;
		
		try {      // for error handling
			AST tmp71_AST = null;
			tmp71_AST = astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, tmp71_AST);
			match(RES_REPEAT);
			sentencias();
			astFactory.addASTChild(ref currentAST, returnAST);
			match(RES_UNTIL);
			expresion();
			astFactory.addASTChild(ref currentAST, returnAST);
			expresionRepeat_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_10_);
		}
		returnAST = expresionRepeat_AST;
	}
	
	public void listaFor() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST listaFor_AST = null;
		
		try {      // for error handling
			valorInicial();
			astFactory.addASTChild(ref currentAST, returnAST);
			AST tmp73_AST = null;
			tmp73_AST = astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, tmp73_AST);
			match(RES_TO);
			valorFinal();
			astFactory.addASTChild(ref currentAST, returnAST);
			listaFor_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_23_);
		}
		returnAST = listaFor_AST;
	}
	
	public void valorInicial() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST valorInicial_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case IDENT:
			{
				AST tmp74_AST = null;
				tmp74_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp74_AST);
				match(IDENT);
				valorInicial_AST = currentAST.root;
				break;
			}
			case LIT_ENTERO:
			{
				AST tmp75_AST = null;
				tmp75_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp75_AST);
				match(LIT_ENTERO);
				valorInicial_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_24_);
		}
		returnAST = valorInicial_AST;
	}
	
	public void valorFinal() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST valorFinal_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case IDENT:
			{
				AST tmp76_AST = null;
				tmp76_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp76_AST);
				match(IDENT);
				valorFinal_AST = currentAST.root;
				break;
			}
			case LIT_ENTERO:
			{
				AST tmp77_AST = null;
				tmp77_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp77_AST);
				match(LIT_ENTERO);
				valorFinal_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			recover(ex,tokenSet_23_);
		}
		returnAST = valorFinal_AST;
	}
	
	private void initializeFactory()
	{
		if (astFactory == null)
		{
			astFactory = new ASTFactory();
		}
		initializeASTFactory( astFactory );
	}
	static public void initializeASTFactory( ASTFactory factory )
	{
		factory.setMaxNodeType(67);
	}
	
	public static readonly string[] tokenNames_ = new string[] {
		@"""<0>""",
		@"""EOF""",
		@"""<2>""",
		@"""NULL_TREE_LOOKAHEAD""",
		@"""integer""",
		@"""string""",
		@"""real""",
		@"""boolean""",
		@"""char""",
		@"""true""",
		@"""false""",
		@"""program""",
		@"""var""",
		@"""const""",
		@"""begin""",
		@"""end""",
		@"""for""",
		@"""if""",
		@"""then""",
		@"""else""",
		@"""to""",
		@"""do""",
		@"""while""",
		@"""repeat""",
		@"""until""",
		@"""function""",
		@"""procedure""",
		@"""return""",
		@"""div""",
		@"""mod""",
		@"""and""",
		@"""or""",
		@"""not""",
		@"""LIT_ENTERO""",
		@"""LIT_REAL""",
		@"""BLANCO""",
		@"""DIGITO""",
		@"""LETRA""",
		@"""IDENT""",
		@"""PUNTO_COMA""",
		@"""COMA""",
		@"""DOS_PUNTOS""",
		@"""PUNTO""",
		@"""PARENT_AB""",
		@"""PARENT_CE""",
		@"""OP_IGUAL""",
		@"""OP_ASSING""",
		@"""OP_MAYOR""",
		@"""OP_MENOR""",
		@"""OP_MAYOR_IGUAL""",
		@"""OP_MENOR_IGUAL""",
		@"""OP_DISTINTO""",
		@"""OP_MAS""",
		@"""OP_MENOS""",
		@"""OP_PRODUCTO""",
		@"""OP_DIVISION""",
		@"""LIT_NUMERO""",
		@"""COMENTARIO""",
		@"""LIT_CADENA""",
		@"""PROGRAMA""",
		@"""PARAMETROS""",
		@"""DEVUELVE""",
		@"""LISTA_IDS""",
		@"""BLOQUE""",
		@"""LISTA_ARGUMENTOS""",
		@"""LLAMADA_FUNCION""",
		@"""LLAMADA_PROC""",
		@"""LIT_CHAR"""
	};
	
	private static long[] mk_tokenSet_0_()
	{
		long[] data = { 2L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_0_ = new BitSet(mk_tokenSet_0_());
	private static long[] mk_tokenSet_1_()
	{
		long[] data = { 100694016L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_1_ = new BitSet(mk_tokenSet_1_());
	private static long[] mk_tokenSet_2_()
	{
		long[] data = { 4947802324992L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_2_ = new BitSet(mk_tokenSet_2_());
	private static long[] mk_tokenSet_3_()
	{
		long[] data = { 100691968L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_3_ = new BitSet(mk_tokenSet_3_());
	private static long[] mk_tokenSet_4_()
	{
		long[] data = { 4947819659264L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_4_ = new BitSet(mk_tokenSet_4_());
	private static long[] mk_tokenSet_5_()
	{
		long[] data = { 549755813888L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_5_ = new BitSet(mk_tokenSet_5_());
	private static long[] mk_tokenSet_6_()
	{
		long[] data = { 71971286421372928L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_6_ = new BitSet(mk_tokenSet_6_());
	private static long[] mk_tokenSet_7_()
	{
		long[] data = { 2199023255552L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_7_ = new BitSet(mk_tokenSet_7_());
	private static long[] mk_tokenSet_8_()
	{
		long[] data = { 18141941858304L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_8_ = new BitSet(mk_tokenSet_8_());
	private static long[] mk_tokenSet_9_()
	{
		long[] data = { 2748779069440L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_9_ = new BitSet(mk_tokenSet_9_());
	private static long[] mk_tokenSet_10_()
	{
		long[] data = { 549773148160L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_10_ = new BitSet(mk_tokenSet_10_());
	private static long[] mk_tokenSet_11_()
	{
		long[] data = { 9345866170368L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_11_ = new BitSet(mk_tokenSet_11_());
	private static long[] mk_tokenSet_12_()
	{
		long[] data = { 17592186044416L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_12_ = new BitSet(mk_tokenSet_12_());
	private static long[] mk_tokenSet_13_()
	{
		long[] data = { 4398046511104000L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_13_ = new BitSet(mk_tokenSet_13_());
	private static long[] mk_tokenSet_14_()
	{
		long[] data = { 549775507456L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_14_ = new BitSet(mk_tokenSet_14_());
	private static long[] mk_tokenSet_15_()
	{
		long[] data = { 4398596286611456L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_15_ = new BitSet(mk_tokenSet_15_());
	private static long[] mk_tokenSet_16_()
	{
		long[] data = { 54043197407494144L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_16_ = new BitSet(mk_tokenSet_16_());
	private static long[] mk_tokenSet_17_()
	{
		long[] data = { 17909397316206592L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_17_ = new BitSet(mk_tokenSet_17_());
	private static long[] mk_tokenSet_18_()
	{
		long[] data = { 71952594723700736L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_18_ = new BitSet(mk_tokenSet_18_());
	private static long[] mk_tokenSet_19_()
	{
		long[] data = { 18691697672192L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_19_ = new BitSet(mk_tokenSet_19_());
	private static long[] mk_tokenSet_20_()
	{
		long[] data = { 16809984L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_20_ = new BitSet(mk_tokenSet_20_());
	private static long[] mk_tokenSet_21_()
	{
		long[] data = { 824663851008L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_21_ = new BitSet(mk_tokenSet_21_());
	private static long[] mk_tokenSet_22_()
	{
		long[] data = { 288235628926846464L, 8L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_22_ = new BitSet(mk_tokenSet_22_());
	private static long[] mk_tokenSet_23_()
	{
		long[] data = { 2097152L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_23_ = new BitSet(mk_tokenSet_23_());
	private static long[] mk_tokenSet_24_()
	{
		long[] data = { 1048576L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_24_ = new BitSet(mk_tokenSet_24_());
	
}
