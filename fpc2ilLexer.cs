// $ANTLR 2.7.7 (20060906): "fpc2ilLexer.g" -> "fpc2ilLexer.cs"$

	// Generate header specific to lexer CSharp file
	using System;
	using Stream                          = System.IO.Stream;
	using TextReader                      = System.IO.TextReader;
	using Hashtable                       = System.Collections.Hashtable;
	using Comparer                        = System.Collections.Comparer;
	
	using TokenStreamException            = antlr.TokenStreamException;
	using TokenStreamIOException          = antlr.TokenStreamIOException;
	using TokenStreamRecognitionException = antlr.TokenStreamRecognitionException;
	using CharStreamException             = antlr.CharStreamException;
	using CharStreamIOException           = antlr.CharStreamIOException;
	using ANTLRException                  = antlr.ANTLRException;
	using CharScanner                     = antlr.CharScanner;
	using InputBuffer                     = antlr.InputBuffer;
	using ByteBuffer                      = antlr.ByteBuffer;
	using CharBuffer                      = antlr.CharBuffer;
	using Token                           = antlr.Token;
	using IToken                          = antlr.IToken;
	using CommonToken                     = antlr.CommonToken;
	using SemanticException               = antlr.SemanticException;
	using RecognitionException            = antlr.RecognitionException;
	using NoViableAltForCharException     = antlr.NoViableAltForCharException;
	using MismatchedCharException         = antlr.MismatchedCharException;
	using TokenStream                     = antlr.TokenStream;
	using LexerSharedInputState           = antlr.LexerSharedInputState;
	using BitSet                          = antlr.collections.impl.BitSet;
	
	public 	class fpc2ilLexer : antlr.CharScanner	, TokenStream
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
		
		
    protected Errors err = Errors.Instance;

    public override void reportError (RecognitionException e)
    {
        //Console.ForegroundColor = ConsoleColor.Red;
        err.addError(e.Message, e.getLine(), e.getColumn());
        //Console.ResetColor();
    }
		public fpc2ilLexer(Stream ins) : this(new ByteBuffer(ins))
		{
		}
		
		public fpc2ilLexer(TextReader r) : this(new CharBuffer(r))
		{
		}
		
		public fpc2ilLexer(InputBuffer ib)		 : this(new LexerSharedInputState(ib))
		{
		}
		
		public fpc2ilLexer(LexerSharedInputState state) : base(state)
		{
			initialize();
		}
		private void initialize()
		{
			caseSensitiveLiterals = true;
			setCaseSensitive(true);
			literals = new Hashtable(100, (float) 0.4, null, Comparer.Default);
			literals.Add("to", 20);
			literals.Add("procedure", 26);
			literals.Add("for", 16);
			literals.Add("false", 10);
			literals.Add("true", 9);
			literals.Add("integer", 4);
			literals.Add("and", 30);
			literals.Add("boolean", 7);
			literals.Add("end", 15);
			literals.Add("string", 5);
			literals.Add("until", 24);
			literals.Add("begin", 14);
			literals.Add("mod", 29);
			literals.Add("do", 21);
			literals.Add("div", 28);
			literals.Add("function", 25);
			literals.Add("char", 8);
			literals.Add("while", 22);
			literals.Add("const", 13);
			literals.Add("repeat", 23);
			literals.Add("or", 31);
			literals.Add("real", 6);
			literals.Add("return", 27);
			literals.Add("if", 17);
			literals.Add("program", 11);
			literals.Add("else", 19);
			literals.Add("var", 12);
			literals.Add("not", 32);
			literals.Add("then", 18);
		}
		
		override public IToken nextToken()			//throws TokenStreamException
		{
			IToken theRetToken = null;
tryAgain:
			for (;;)
			{
				IToken _token = null;
				int _ttype = Token.INVALID_TYPE;
				resetText();
				try     // for char stream error handling
				{
					try     // for lexical error handling
					{
						switch ( cached_LA1 )
						{
						case '\t':  case '\n':  case '\u000c':  case '\r':
						case ' ':
						{
							mBLANCO(true);
							theRetToken = returnToken_;
							break;
						}
						case 'A':  case 'B':  case 'C':  case 'D':
						case 'E':  case 'F':  case 'G':  case 'H':
						case 'I':  case 'J':  case 'K':  case 'L':
						case 'M':  case 'N':  case 'O':  case 'P':
						case 'Q':  case 'R':  case 'S':  case 'T':
						case 'U':  case 'V':  case 'W':  case 'X':
						case 'Y':  case 'Z':  case '_':  case 'a':
						case 'b':  case 'c':  case 'd':  case 'e':
						case 'f':  case 'g':  case 'h':  case 'i':
						case 'j':  case 'k':  case 'l':  case 'm':
						case 'n':  case 'o':  case 'p':  case 'q':
						case 'r':  case 's':  case 't':  case 'u':
						case 'v':  case 'w':  case 'x':  case 'y':
						case 'z':
						{
							mIDENT(true);
							theRetToken = returnToken_;
							break;
						}
						case ';':
						{
							mPUNTO_COMA(true);
							theRetToken = returnToken_;
							break;
						}
						case ',':
						{
							mCOMA(true);
							theRetToken = returnToken_;
							break;
						}
						case '.':
						{
							mPUNTO(true);
							theRetToken = returnToken_;
							break;
						}
						case '(':
						{
							mPARENT_AB(true);
							theRetToken = returnToken_;
							break;
						}
						case ')':
						{
							mPARENT_CE(true);
							theRetToken = returnToken_;
							break;
						}
						case '=':
						{
							mOP_IGUAL(true);
							theRetToken = returnToken_;
							break;
						}
						case '+':
						{
							mOP_MAS(true);
							theRetToken = returnToken_;
							break;
						}
						case '-':
						{
							mOP_MENOS(true);
							theRetToken = returnToken_;
							break;
						}
						case '*':
						{
							mOP_PRODUCTO(true);
							theRetToken = returnToken_;
							break;
						}
						case '/':
						{
							mOP_DIVISION(true);
							theRetToken = returnToken_;
							break;
						}
						case '0':  case '1':  case '2':  case '3':
						case '4':  case '5':  case '6':  case '7':
						case '8':  case '9':
						{
							mLIT_NUMERO(true);
							theRetToken = returnToken_;
							break;
						}
						case '{':
						{
							mCOMENTARIO(true);
							theRetToken = returnToken_;
							break;
						}
						case '\'':
						{
							mLIT_CADENA(true);
							theRetToken = returnToken_;
							break;
						}
						default:
							if ((cached_LA1==':') && (cached_LA2=='='))
							{
								mOP_ASSING(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='>') && (cached_LA2=='=')) {
								mOP_MAYOR_IGUAL(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='<') && (cached_LA2=='=')) {
								mOP_MENOR_IGUAL(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='<') && (cached_LA2=='>')) {
								mOP_DISTINTO(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1==':') && (true)) {
								mDOS_PUNTOS(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='>') && (true)) {
								mOP_MAYOR(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='<') && (true)) {
								mOP_MENOR(true);
								theRetToken = returnToken_;
							}
						else
						{
							if (cached_LA1==EOF_CHAR) { uponEOF(); returnToken_ = makeToken(Token.EOF_TYPE); }
				else {throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());}
						}
						break; }
						if ( null==returnToken_ ) goto tryAgain; // found SKIP token
						_ttype = returnToken_.Type;
						returnToken_.Type = _ttype;
						return returnToken_;
					}
					catch (RecognitionException e) {
							throw new TokenStreamRecognitionException(e);
					}
				}
				catch (CharStreamException cse) {
					if ( cse is CharStreamIOException ) {
						throw new TokenStreamIOException(((CharStreamIOException)cse).io);
					}
					else {
						throw new TokenStreamException(cse.Message);
					}
				}
			}
		}
		
	public void mBLANCO(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = BLANCO;
		
		{
			switch ( cached_LA1 )
			{
			case ' ':
			{
				match(' ');
				break;
			}
			case '\t':
			{
				match('\t');
				break;
			}
			case '\u000c':
			{
				match('\f');
				break;
			}
			case '\n':
			{
				match('\n');
				if (0==inputState.guessing)
				{
					newline();
				}
				break;
			}
			case '\r':
			{
				match('\r');
				if (0==inputState.guessing)
				{
					newline();
				}
				break;
			}
			default:
			{
				throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
			}
			 }
		}
		if (0==inputState.guessing)
		{
			_ttype = Token.SKIP;
		}
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	protected void mDIGITO(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = DIGITO;
		
		matchRange('0','9');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	protected void mLETRA(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = LETRA;
		
		switch ( cached_LA1 )
		{
		case 'a':  case 'b':  case 'c':  case 'd':
		case 'e':  case 'f':  case 'g':  case 'h':
		case 'i':  case 'j':  case 'k':  case 'l':
		case 'm':  case 'n':  case 'o':  case 'p':
		case 'q':  case 'r':  case 's':  case 't':
		case 'u':  case 'v':  case 'w':  case 'x':
		case 'y':  case 'z':
		{
			matchRange('a','z');
			break;
		}
		case 'A':  case 'B':  case 'C':  case 'D':
		case 'E':  case 'F':  case 'G':  case 'H':
		case 'I':  case 'J':  case 'K':  case 'L':
		case 'M':  case 'N':  case 'O':  case 'P':
		case 'Q':  case 'R':  case 'S':  case 'T':
		case 'U':  case 'V':  case 'W':  case 'X':
		case 'Y':  case 'Z':
		{
			matchRange('A','Z');
			break;
		}
		default:
		{
			throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
		}
		 }
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mIDENT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = IDENT;
		
		{
			switch ( cached_LA1 )
			{
			case 'A':  case 'B':  case 'C':  case 'D':
			case 'E':  case 'F':  case 'G':  case 'H':
			case 'I':  case 'J':  case 'K':  case 'L':
			case 'M':  case 'N':  case 'O':  case 'P':
			case 'Q':  case 'R':  case 'S':  case 'T':
			case 'U':  case 'V':  case 'W':  case 'X':
			case 'Y':  case 'Z':  case 'a':  case 'b':
			case 'c':  case 'd':  case 'e':  case 'f':
			case 'g':  case 'h':  case 'i':  case 'j':
			case 'k':  case 'l':  case 'm':  case 'n':
			case 'o':  case 'p':  case 'q':  case 'r':
			case 's':  case 't':  case 'u':  case 'v':
			case 'w':  case 'x':  case 'y':  case 'z':
			{
				mLETRA(false);
				break;
			}
			case '_':
			{
				match('_');
				break;
			}
			default:
			{
				throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
			}
			 }
		}
		{    // ( ... )*
			for (;;)
			{
				switch ( cached_LA1 )
				{
				case 'A':  case 'B':  case 'C':  case 'D':
				case 'E':  case 'F':  case 'G':  case 'H':
				case 'I':  case 'J':  case 'K':  case 'L':
				case 'M':  case 'N':  case 'O':  case 'P':
				case 'Q':  case 'R':  case 'S':  case 'T':
				case 'U':  case 'V':  case 'W':  case 'X':
				case 'Y':  case 'Z':  case 'a':  case 'b':
				case 'c':  case 'd':  case 'e':  case 'f':
				case 'g':  case 'h':  case 'i':  case 'j':
				case 'k':  case 'l':  case 'm':  case 'n':
				case 'o':  case 'p':  case 'q':  case 'r':
				case 's':  case 't':  case 'u':  case 'v':
				case 'w':  case 'x':  case 'y':  case 'z':
				{
					mLETRA(false);
					break;
				}
				case '0':  case '1':  case '2':  case '3':
				case '4':  case '5':  case '6':  case '7':
				case '8':  case '9':
				{
					mDIGITO(false);
					break;
				}
				case '_':
				{
					match('_');
					break;
				}
				default:
				{
					goto _loop8_breakloop;
				}
				 }
			}
_loop8_breakloop:			;
		}    // ( ... )*
		_ttype = testLiteralsTable(_ttype);
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mPUNTO_COMA(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = PUNTO_COMA;
		
		match(';');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mCOMA(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = COMA;
		
		match(',');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mDOS_PUNTOS(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = DOS_PUNTOS;
		
		match(':');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mPUNTO(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = PUNTO;
		
		match('.');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mPARENT_AB(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = PARENT_AB;
		
		match('(');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mPARENT_CE(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = PARENT_CE;
		
		match(')');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mOP_IGUAL(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = OP_IGUAL;
		
		match('=');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mOP_ASSING(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = OP_ASSING;
		
		match(":=");
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mOP_MAYOR(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = OP_MAYOR;
		
		match('>');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mOP_MENOR(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = OP_MENOR;
		
		match('<');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mOP_MAYOR_IGUAL(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = OP_MAYOR_IGUAL;
		
		match(">=");
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mOP_MENOR_IGUAL(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = OP_MENOR_IGUAL;
		
		match("<=");
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mOP_DISTINTO(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = OP_DISTINTO;
		
		match("<>");
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mOP_MAS(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = OP_MAS;
		
		match('+');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mOP_MENOS(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = OP_MENOS;
		
		match('-');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mOP_PRODUCTO(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = OP_PRODUCTO;
		
		match('*');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mOP_DIVISION(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = OP_DIVISION;
		
		match('/');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mLIT_NUMERO(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = LIT_NUMERO;
		
		bool synPredMatched30 = false;
		if ((((cached_LA1 >= '0' && cached_LA1 <= '9')) && (tokenSet_0_.member(cached_LA2))))
		{
			int _m30 = mark();
			synPredMatched30 = true;
			inputState.guessing++;
			try {
				{
					{ // ( ... )+
						int _cnt29=0;
						for (;;)
						{
							if (((cached_LA1 >= '0' && cached_LA1 <= '9')))
							{
								mDIGITO(false);
							}
							else
							{
								if (_cnt29 >= 1) { goto _loop29_breakloop; } else { throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());; }
							}
							
							_cnt29++;
						}
_loop29_breakloop:						;
					}    // ( ... )+
					match('.');
				}
			}
			catch (RecognitionException)
			{
				synPredMatched30 = false;
			}
			rewind(_m30);
			inputState.guessing--;
		}
		if ( synPredMatched30 )
		{
			{ // ( ... )+
				int _cnt32=0;
				for (;;)
				{
					if (((cached_LA1 >= '0' && cached_LA1 <= '9')))
					{
						mDIGITO(false);
					}
					else
					{
						if (_cnt32 >= 1) { goto _loop32_breakloop; } else { throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());; }
					}
					
					_cnt32++;
				}
_loop32_breakloop:				;
			}    // ( ... )+
			match('.');
			{    // ( ... )*
				for (;;)
				{
					if (((cached_LA1 >= '0' && cached_LA1 <= '9')))
					{
						mDIGITO(false);
					}
					else
					{
						goto _loop34_breakloop;
					}
					
				}
_loop34_breakloop:				;
			}    // ( ... )*
			if (0==inputState.guessing)
			{
				_ttype = LIT_REAL;
			}
		}
		else if (((cached_LA1 >= '0' && cached_LA1 <= '9')) && (true)) {
			{ // ( ... )+
				int _cnt36=0;
				for (;;)
				{
					if (((cached_LA1 >= '0' && cached_LA1 <= '9')))
					{
						mDIGITO(false);
					}
					else
					{
						if (_cnt36 >= 1) { goto _loop36_breakloop; } else { throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());; }
					}
					
					_cnt36++;
				}
_loop36_breakloop:				;
			}    // ( ... )+
			if (0==inputState.guessing)
			{
				_ttype = LIT_ENTERO;
			}
		}
		else
		{
			throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
		}
		
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mCOMENTARIO(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = COMENTARIO;
		
		match("{");
		{    // ( ... )*
			for (;;)
			{
				if ((tokenSet_1_.member(cached_LA1)) && (tokenSet_1_.member(cached_LA2)))
				{
					{
						match(tokenSet_1_);
					}
				}
				else
				{
					goto _loop40_breakloop;
				}
				
			}
_loop40_breakloop:			;
		}    // ( ... )*
		match("}");
		if (0==inputState.guessing)
		{
			_ttype = Token.SKIP;
		}
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mLIT_CADENA(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = LIT_CADENA;
		
		int _saveIndex = 0;
		_saveIndex = text.Length;
		match('\'');
		text.Length = _saveIndex;
		{    // ( ... )*
			for (;;)
			{
				if ((tokenSet_2_.member(cached_LA1)))
				{
					{
						match(tokenSet_2_);
					}
				}
				else
				{
					goto _loop44_breakloop;
				}
				
			}
_loop44_breakloop:			;
		}    // ( ... )*
		_saveIndex = text.Length;
		match('\'');
		text.Length = _saveIndex;
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	
	private static long[] mk_tokenSet_0_()
	{
		long[] data = { 288019269919178752L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_0_ = new BitSet(mk_tokenSet_0_());
	private static long[] mk_tokenSet_1_()
	{
		long[] data = { -9217L, -1L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_1_ = new BitSet(mk_tokenSet_1_());
	private static long[] mk_tokenSet_2_()
	{
		long[] data = { -549755823105L, -1L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_2_ = new BitSet(mk_tokenSet_2_());
	
}
