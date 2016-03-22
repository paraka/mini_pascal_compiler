// $ANTLR 2.7.7 (20060906): "fpc2ilCodeGenerator.g" -> "fpc2ilCodeGenerator.cs"$

    using System.Collections;
    using Emit = System.Reflection.Emit;

	// Generate header specific to the tree-parser CSharp file
	using System;
	
	using TreeParser = antlr.TreeParser;
	using Token                    = antlr.Token;
	using IToken                   = antlr.IToken;
	using AST                      = antlr.collections.AST;
	using RecognitionException     = antlr.RecognitionException;
	using ANTLRException           = antlr.ANTLRException;
	using NoViableAltException     = antlr.NoViableAltException;
	using MismatchedTokenException = antlr.MismatchedTokenException;
	using SemanticException        = antlr.SemanticException;
	using BitSet                   = antlr.collections.impl.BitSet;
	using ASTPair                  = antlr.ASTPair;
	using ASTFactory               = antlr.ASTFactory;
	using ASTArray                 = antlr.collections.impl.ASTArray;
	
	
	public 	class fpc2ilCodeGenerator : antlr.TreeParser
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
		
		
    private Symboltable symtab;
    private Errors err;
    private string proc_actual = "";
    private uint scope = 0;
    private ExpUtils eutils;
    private ILCodeGen cgen = null;

    public void FinishCode ()
    {
        cgen.FinishGen();
    }
		public fpc2ilCodeGenerator()
		{
			tokenNames = tokenNames_;
		}
		
	public void programa(AST _t) //throws RecognitionException
{
		
		AST programa_AST_in = (AST)_t;
		
		symtab = Symboltable.Instance;
		err = Errors.Instance;
		eutils = new ExpUtils();
		
		
		try {      // for error handling
			AST __t2 = _t;
			AST tmp1_AST_in = _t;
			match(_t,PROGRAMA);
			_t = _t.getFirstChild();
			{ // ( ... )+
				int _cnt4=0;
				for (;;)
				{
					if (_t == null)
						_t = ASTNULL;
					if ((_t.Type==RES_PROGRAM))
					{
						declaracionPrograma(_t);
						_t = retTree_;
					}
					else
					{
						if (_cnt4 >= 1) { goto _loop4_breakloop; } else { throw new NoViableAltException(_t);; }
					}
					
					_cnt4++;
				}
_loop4_breakloop:				;
			}    // ( ... )+
			bloque(_t);
			_t = retTree_;
			_t = __t2;
			_t = _t.getNextSibling();
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void declaracionPrograma(AST _t) //throws RecognitionException
{
		
		AST declaracionPrograma_AST_in = (AST)_t;
		AST id = null;
		
		Symbol s;
		
		
		try {      // for error handling
			AST __t6 = _t;
			AST tmp2_AST_in = _t;
			match(_t,RES_PROGRAM);
			_t = _t.getFirstChild();
			id = _t;
			match(_t,IDENT);
			_t = _t.getNextSibling();
			_t = __t6;
			_t = _t.getNextSibling();
			
			cgen = new ILCodeGen(id.getText());
			
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void bloque(AST _t) //throws RecognitionException
{
		
		AST bloque_AST_in = (AST)_t;
		
		try {      // for error handling
			{    // ( ... )*
				for (;;)
				{
					if (null == _t)
						_t = ASTNULL;
					switch ( _t.Type )
					{
					case RES_VAR:
					{
						decVar(_t);
						_t = retTree_;
						break;
					}
					case RES_CONST:
					{
						decConst(_t);
						_t = retTree_;
						break;
					}
					case RES_PROCEDURE:
					{
						decprocedimiento(_t);
						_t = retTree_;
						break;
					}
					case RES_FUNCTION:
					{
						decFunction(_t);
						_t = retTree_;
						break;
					}
					default:
					{
						goto _loop9_breakloop;
					}
					 }
				}
_loop9_breakloop:				;
			}    // ( ... )*
			bloque_sentencia(_t);
			_t = retTree_;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void decVar(AST _t) //throws RecognitionException
{
		
		AST decVar_AST_in = (AST)_t;
		
		try {      // for error handling
			AST __t19 = _t;
			AST tmp3_AST_in = _t;
			match(_t,RES_VAR);
			_t = _t.getFirstChild();
			{ // ( ... )+
				int _cnt21=0;
				for (;;)
				{
					if (_t == null)
						_t = ASTNULL;
					if ((_t.Type==DOS_PUNTOS))
					{
						declaracionVariable(_t);
						_t = retTree_;
					}
					else
					{
						if (_cnt21 >= 1) { goto _loop21_breakloop; } else { throw new NoViableAltException(_t);; }
					}
					
					_cnt21++;
				}
_loop21_breakloop:				;
			}    // ( ... )+
			_t = __t19;
			_t = _t.getNextSibling();
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void decConst(AST _t) //throws RecognitionException
{
		
		AST decConst_AST_in = (AST)_t;
		
		try {      // for error handling
			AST __t11 = _t;
			AST tmp4_AST_in = _t;
			match(_t,RES_CONST);
			_t = _t.getFirstChild();
			{ // ( ... )+
				int _cnt13=0;
				for (;;)
				{
					if (_t == null)
						_t = ASTNULL;
					if ((_t.Type==OP_IGUAL))
					{
						declaracionConstante(_t);
						_t = retTree_;
					}
					else
					{
						if (_cnt13 >= 1) { goto _loop13_breakloop; } else { throw new NoViableAltException(_t);; }
					}
					
					_cnt13++;
				}
_loop13_breakloop:				;
			}    // ( ... )+
			_t = __t11;
			_t = _t.getNextSibling();
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void decprocedimiento(AST _t) //throws RecognitionException
{
		
		AST decprocedimiento_AST_in = (AST)_t;
		
		Procedure s;
		
		
		try {      // for error handling
			AST __t28 = _t;
			AST tmp5_AST_in = _t;
			match(_t,RES_PROCEDURE);
			_t = _t.getFirstChild();
			s=procParamActual(_t);
			_t = retTree_;
			{
				if (null == _t)
					_t = ASTNULL;
				switch ( _t.Type )
				{
				case PARAMETROS:
				{
					sparametros(_t);
					_t = retTree_;
					break;
				}
				case RES_VAR:
				case RES_CONST:
				case RES_FUNCTION:
				case RES_PROCEDURE:
				case BLOQUE:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(_t);
				}
				 }
			}
			
			scope = 1;
			cgen.genMethod(s);
			
			bloque(_t);
			_t = retTree_;
			_t = __t28;
			_t = _t.getNextSibling();
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void decFunction(AST _t) //throws RecognitionException
{
		
		AST decFunction_AST_in = (AST)_t;
		AST ty = null;
		
		Function s;
		
		
		try {      // for error handling
			AST __t45 = _t;
			AST tmp6_AST_in = _t;
			match(_t,RES_FUNCTION);
			_t = _t.getFirstChild();
			s=funcParamActual(_t);
			_t = retTree_;
			{
				if (null == _t)
					_t = ASTNULL;
				switch ( _t.Type )
				{
				case PARAMETROS:
				{
					sparametros(_t);
					_t = retTree_;
					break;
				}
				case TIPO_ENTERO:
				case TIPO_CADENA:
				case TIPO_REAL:
				case TIPO_BOOLEANO:
				case TIPO_CHAR:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(_t);
				}
				 }
			}
			
			scope = 1;
			cgen.genMethod(s);
			
			ty = _t==ASTNULL ? null : _t;
			tipo(_t);
			_t = retTree_;
			bloque(_t);
			_t = retTree_;
			_t = __t45;
			_t = _t.getNextSibling();
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void bloque_sentencia(AST _t) //throws RecognitionException
{
		
		AST bloque_sentencia_AST_in = (AST)_t;
		
		try {      // for error handling
			AST __t48 = _t;
			AST tmp7_AST_in = _t;
			match(_t,BLOQUE);
			_t = _t.getFirstChild();
			
			/* Miramos a ver si es el bloque principal */
			AST aux = tmp7_AST_in.getNextSibling();
			if (aux != null && aux.Type == PUNTO) {
			scope = 0;
			cgen.genMain();
			}
			
			{ // ( ... )+
				int _cnt50=0;
				for (;;)
				{
					if (_t == null)
						_t = ASTNULL;
					if ((tokenSet_0_.member(_t.Type)))
					{
						sentencias(_t);
						_t = retTree_;
					}
					else
					{
						if (_cnt50 >= 1) { goto _loop50_breakloop; } else { throw new NoViableAltException(_t);; }
					}
					
					_cnt50++;
				}
_loop50_breakloop:				;
			}    // ( ... )+
			_t = __t48;
			_t = _t.getNextSibling();
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void declaracionConstante(AST _t) //throws RecognitionException
{
		
		AST declaracionConstante_AST_in = (AST)_t;
		
		Constant s;
		
		
		try {      // for error handling
			{
				s=decCte(_t);
				_t = retTree_;
			}
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public Constant  decCte(AST _t) //throws RecognitionException
{
		Constant s;
		
		AST decCte_AST_in = (AST)_t;
		AST id = null;
		
		s = null;
		
		
		try {      // for error handling
			AST __t17 = _t;
			AST tmp8_AST_in = _t;
			match(_t,OP_IGUAL);
			_t = _t.getFirstChild();
			id = _t;
			match(_t,IDENT);
			_t = _t.getNextSibling();
			
			if (scope == 0)
			s = (Constant)symtab.find(id.getText());
			
			_t = __t17;
			_t = _t.getNextSibling();
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
		return s;
	}
	
	public void declaracionVariable(AST _t) //throws RecognitionException
{
		
		AST declaracionVariable_AST_in = (AST)_t;
		
		Symbol s;
		
		
		try {      // for error handling
			{
				s=decVariable(_t);
				_t = retTree_;
			}
			
			if (scope == 0) 
			cgen.genVariable(s);
			
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public Symbol  decVariable(AST _t) //throws RecognitionException
{
		Symbol s;
		
		AST decVariable_AST_in = (AST)_t;
		AST id = null;
		AST tp = null;
		
		s = null;
		
		
		try {      // for error handling
			AST __t25 = _t;
			AST tmp9_AST_in = _t;
			match(_t,DOS_PUNTOS);
			_t = _t.getFirstChild();
			id = _t;
			match(_t,IDENT);
			_t = _t.getNextSibling();
			tp = _t==ASTNULL ? null : _t;
			tipo(_t);
			_t = retTree_;
			
			if (scope == 0)
			s = symtab.find(id.getText());
			
			_t = __t25;
			_t = _t.getNextSibling();
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
		return s;
	}
	
	public void tipo(AST _t) //throws RecognitionException
{
		
		AST tipo_AST_in = (AST)_t;
		
		try {      // for error handling
			if (null == _t)
				_t = ASTNULL;
			switch ( _t.Type )
			{
			case TIPO_ENTERO:
			{
				AST tmp10_AST_in = _t;
				match(_t,TIPO_ENTERO);
				_t = _t.getNextSibling();
				break;
			}
			case TIPO_CHAR:
			{
				AST tmp11_AST_in = _t;
				match(_t,TIPO_CHAR);
				_t = _t.getNextSibling();
				break;
			}
			case TIPO_REAL:
			{
				AST tmp12_AST_in = _t;
				match(_t,TIPO_REAL);
				_t = _t.getNextSibling();
				break;
			}
			case TIPO_BOOLEANO:
			{
				AST tmp13_AST_in = _t;
				match(_t,TIPO_BOOLEANO);
				_t = _t.getNextSibling();
				break;
			}
			case TIPO_CADENA:
			{
				AST tmp14_AST_in = _t;
				match(_t,TIPO_CADENA);
				_t = _t.getNextSibling();
				break;
			}
			default:
			{
				throw new NoViableAltException(_t);
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public Procedure  procParamActual(AST _t) //throws RecognitionException
{
		Procedure s;
		
		AST procParamActual_AST_in = (AST)_t;
		AST id = null;
		
		s = null;
		
		
		try {      // for error handling
			AST __t41 = _t;
			id = (ASTNULL == _t) ? null : (AST)_t;
			match(_t,IDENT);
			_t = _t.getFirstChild();
			
			s = (Procedure)symtab.find(id.getText());
			proc_actual = id.getText();
			
			_t = __t41;
			_t = _t.getNextSibling();
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
		return s;
	}
	
	public void sparametros(AST _t) //throws RecognitionException
{
		
		AST sparametros_AST_in = (AST)_t;
		
		uint argnum = 0;
		Hashtable parametros = new Hashtable();
		Procedure s;
		
		
		try {      // for error handling
			AST __t31 = _t;
			AST tmp15_AST_in = _t;
			match(_t,PARAMETROS);
			_t = _t.getFirstChild();
			{
				if (null == _t)
					_t = ASTNULL;
				switch ( _t.Type )
				{
				case RES_VAR:
				case IDENT:
				{
					listaParametros(_t,parametros, ref argnum);
					_t = retTree_;
					break;
				}
				case 3:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(_t);
				}
				 }
			}
			_t = __t31;
			_t = _t.getNextSibling();
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void listaParametros(AST _t,
		Hashtable parametros, ref uint argnum
	) //throws RecognitionException
{
		
		AST listaParametros_AST_in = (AST)_t;
		
		try {      // for error handling
			{ // ( ... )+
				int _cnt35=0;
				for (;;)
				{
					if (null == _t)
						_t = ASTNULL;
					switch ( _t.Type )
					{
					case RES_VAR:
					{
						declaracionParametroRef(_t,parametros, ref argnum);
						_t = retTree_;
						break;
					}
					case IDENT:
					{
						declaracionParametroValor(_t,parametros, ref argnum);
						_t = retTree_;
						break;
					}
					default:
					{
						if (_cnt35 >= 1) { goto _loop35_breakloop; } else { throw new NoViableAltException(_t);; }
					}
					break; }
					_cnt35++;
				}
_loop35_breakloop:				;
			}    // ( ... )+
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void declaracionParametroRef(AST _t,
		Hashtable parametros, ref uint argnum
	) //throws RecognitionException
{
		
		AST declaracionParametroRef_AST_in = (AST)_t;
		AST id = null;
		AST ty = null;
		
		Param p = null;
		
		
		try {      // for error handling
			AST __t37 = _t;
			AST tmp16_AST_in = _t;
			match(_t,RES_VAR);
			_t = _t.getFirstChild();
			id = _t;
			match(_t,IDENT);
			_t = _t.getNextSibling();
			ty = _t==ASTNULL ? null : _t;
			tipo(_t);
			_t = retTree_;
			_t = __t37;
			_t = _t.getNextSibling();
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void declaracionParametroValor(AST _t,
		Hashtable parametros, ref uint argnum
	) //throws RecognitionException
{
		
		AST declaracionParametroValor_AST_in = (AST)_t;
		AST id = null;
		AST ty = null;
		
		Param p = null;
		
		
		try {      // for error handling
			{
				id = _t;
				match(_t,IDENT);
				_t = _t.getNextSibling();
				ty = _t==ASTNULL ? null : _t;
				tipo(_t);
				_t = retTree_;
			}
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public Function  funcParamActual(AST _t) //throws RecognitionException
{
		Function s;
		
		AST funcParamActual_AST_in = (AST)_t;
		AST id = null;
		
		s = null;
		
		
		try {      // for error handling
			AST __t43 = _t;
			id = (ASTNULL == _t) ? null : (AST)_t;
			match(_t,IDENT);
			_t = _t.getFirstChild();
			
			s = (Function)symtab.find(id.getText());
			proc_actual = id.getText();
			
			_t = __t43;
			_t = _t.getNextSibling();
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
		return s;
	}
	
	public void sentencias(AST _t) //throws RecognitionException
{
		
		AST sentencias_AST_in = (AST)_t;
		
		try {      // for error handling
			if (null == _t)
				_t = ASTNULL;
			switch ( _t.Type )
			{
			case OP_ASSING:
			case BLOQUE:
			case LLAMADA_PROC:
			{
				sentencia_simple(_t);
				_t = retTree_;
				break;
			}
			case RES_FOR:
			case RES_IF:
			case RES_WHILE:
			case RES_REPEAT:
			{
				sentencia_compuesta(_t);
				_t = retTree_;
				break;
			}
			default:
			{
				throw new NoViableAltException(_t);
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void sentencia_simple(AST _t) //throws RecognitionException
{
		
		AST sentencia_simple_AST_in = (AST)_t;
		
		try {      // for error handling
			if (null == _t)
				_t = ASTNULL;
			switch ( _t.Type )
			{
			case BLOQUE:
			{
				bloque_sentencia(_t);
				_t = retTree_;
				break;
			}
			case OP_ASSING:
			{
				asignacion(_t);
				_t = retTree_;
				break;
			}
			case LLAMADA_PROC:
			{
				llamada_proc(_t);
				_t = retTree_;
				break;
			}
			default:
			{
				throw new NoViableAltException(_t);
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void sentencia_compuesta(AST _t) //throws RecognitionException
{
		
		AST sentencia_compuesta_AST_in = (AST)_t;
		
		try {      // for error handling
			if (null == _t)
				_t = ASTNULL;
			switch ( _t.Type )
			{
			case RES_IF:
			{
				condicional(_t);
				_t = retTree_;
				break;
			}
			case RES_FOR:
			case RES_WHILE:
			case RES_REPEAT:
			{
				bucle(_t);
				_t = retTree_;
				break;
			}
			default:
			{
				throw new NoViableAltException(_t);
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void asignacion(AST _t) //throws RecognitionException
{
		
		AST asignacion_AST_in = (AST)_t;
		AST id = null;
		
		try {      // for error handling
			
			Symbol s = null;
			Expr exp = null;
			ArrayList expS = new ArrayList();;
			int tipo = 0;
			int tipoDerecha = 0;
			
			AST __t54 = _t;
			AST tmp17_AST_in = _t;
			match(_t,OP_ASSING);
			_t = _t.getFirstChild();
			id = _t;
			match(_t,IDENT);
			_t = _t.getNextSibling();
			expresion(_t,expS);
			_t = retTree_;
			
			cgen.checkAndGenLdArgInReference(scope, proc_actual, id.getText());
			try
			{
			eutils.genAritExpresion(cgen, expS, scope, proc_actual, id.getText());
			} catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }        
			
			_t = __t54;
			_t = _t.getNextSibling();
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void llamada_proc(AST _t) //throws RecognitionException
{
		
		AST llamada_proc_AST_in = (AST)_t;
		AST id = null;
		
		try {      // for error handling
			
			ArrayList lista = new ArrayList();
			Procedure proc = null;
			
			AST __t77 = _t;
			AST tmp18_AST_in = _t;
			match(_t,LLAMADA_PROC);
			_t = _t.getFirstChild();
			id = _t;
			match(_t,IDENT);
			_t = _t.getNextSibling();
			{
				if (null == _t)
					_t = ASTNULL;
				switch ( _t.Type )
				{
				case LISTA_ARGUMENTOS:
				{
					listaArgumentos(_t,lista);
					_t = retTree_;
					break;
				}
				case 3:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(_t);
				}
				 }
			}
			
			//writeln es especial, asi es que no estara en nuestra tabla
			string ident = id.getText();
			if (ident != "writeln")
			{
			try 
			{
			proc = (Procedure)symtab.find(ident);
			} catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }        
			
			if (proc != null)
			{
			/* 
			* TODO:
			* Esta comprobacion quiere decir que es una funcion pero no ha sido asignada a ninguna variable ->
			* Hay que mostrar un warning minimo. De momento mostramos error puesto que el codigo generado sin
			* asignacion es incorrecto
			*/
			if (proc is Function) 
			err.addError("Function '" + proc.Name + "' hasn't be assigned to a variable", id.getLine(),
			id.getColumn());     
			
			try 
			{
			if (proc.checkParams(lista))
			cgen.genCall(proc, lista, scope, proc_actual);
			} catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }        
			}
			} else {
			cgen.genWriteLn(proc_actual, scope, lista);
			}
			
			_t = __t77;
			_t = _t.getNextSibling();
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void expresion(AST _t,
		ArrayList expS
	) //throws RecognitionException
{
		
		AST expresion_AST_in = (AST)_t;
		AST id = null;
		AST c1 = null;
		AST c2 = null;
		AST c3 = null;
		AST c4 = null;
		AST c5 = null;
		
		Symbol sfc = null;
		Symbol s;
		
		
		try {      // for error handling
			if (null == _t)
				_t = ASTNULL;
			switch ( _t.Type )
			{
			case OP_IGUAL:
			{
				AST __t56 = _t;
				AST tmp19_AST_in = _t;
				match(_t,OP_IGUAL);
				_t = _t.getFirstChild();
				expresion(_t,expS);
				_t = retTree_;
				expresion(_t,expS);
				_t = retTree_;
				_t = __t56;
				_t = _t.getNextSibling();
				
				EQExpresion ex = new EQExpresion();
				expS.Add(ex);
				
				break;
			}
			case OP_DISTINTO:
			{
				AST __t57 = _t;
				AST tmp20_AST_in = _t;
				match(_t,OP_DISTINTO);
				_t = _t.getFirstChild();
				expresion(_t,expS);
				_t = retTree_;
				expresion(_t,expS);
				_t = retTree_;
				_t = __t57;
				_t = _t.getNextSibling();
				
				DFExpresion ex = new DFExpresion();
				expS.Add(ex);
				
				break;
			}
			case OP_MENOR:
			{
				AST __t58 = _t;
				AST tmp21_AST_in = _t;
				match(_t,OP_MENOR);
				_t = _t.getFirstChild();
				expresion(_t,expS);
				_t = retTree_;
				expresion(_t,expS);
				_t = retTree_;
				_t = __t58;
				_t = _t.getNextSibling();
				
				LTExpresion ex = new LTExpresion();
				expS.Add(ex);
				
				break;
			}
			case OP_MENOR_IGUAL:
			{
				AST __t59 = _t;
				AST tmp22_AST_in = _t;
				match(_t,OP_MENOR_IGUAL);
				_t = _t.getFirstChild();
				expresion(_t,expS);
				_t = retTree_;
				expresion(_t,expS);
				_t = retTree_;
				_t = __t59;
				_t = _t.getNextSibling();
				
				LEExpresion ex = new LEExpresion();
				expS.Add(ex);
				
				break;
			}
			case OP_MAYOR_IGUAL:
			{
				AST __t60 = _t;
				AST tmp23_AST_in = _t;
				match(_t,OP_MAYOR_IGUAL);
				_t = _t.getFirstChild();
				expresion(_t,expS);
				_t = retTree_;
				expresion(_t,expS);
				_t = retTree_;
				_t = __t60;
				_t = _t.getNextSibling();
				
				GEExpresion ex = new GEExpresion();
				expS.Add(ex);
				
				break;
			}
			case OP_MAYOR:
			{
				AST __t61 = _t;
				AST tmp24_AST_in = _t;
				match(_t,OP_MAYOR);
				_t = _t.getFirstChild();
				expresion(_t,expS);
				_t = retTree_;
				expresion(_t,expS);
				_t = retTree_;
				_t = __t61;
				_t = _t.getNextSibling();
				
				GTExpresion ex = new GTExpresion();
				expS.Add(ex);
				
				break;
			}
			case OP_MAS:
			{
				AST __t62 = _t;
				AST tmp25_AST_in = _t;
				match(_t,OP_MAS);
				_t = _t.getFirstChild();
				expresion(_t,expS);
				_t = retTree_;
				{
					if (null == _t)
						_t = ASTNULL;
					switch ( _t.Type )
					{
					case LIT_CIERTO:
					case LIT_FALSO:
					case OP_DIV:
					case OP_MOD:
					case OP_Y:
					case OP_O:
					case OP_NEG:
					case LIT_ENTERO:
					case LIT_REAL:
					case IDENT:
					case OP_IGUAL:
					case OP_MAYOR:
					case OP_MENOR:
					case OP_MAYOR_IGUAL:
					case OP_MENOR_IGUAL:
					case OP_DISTINTO:
					case OP_MAS:
					case OP_MENOS:
					case OP_PRODUCTO:
					case OP_DIVISION:
					case LIT_CADENA:
					case LLAMADA_FUNCION:
					{
						expresion(_t,expS);
						_t = retTree_;
						break;
					}
					case 3:
					{
						break;
					}
					default:
					{
						throw new NoViableAltException(_t);
					}
					 }
				}
				_t = __t62;
				_t = _t.getNextSibling();
				
				PlusExpresion ex = new PlusExpresion();
				expS.Add(ex);
				
				break;
			}
			case OP_MENOS:
			{
				AST __t64 = _t;
				AST tmp26_AST_in = _t;
				match(_t,OP_MENOS);
				_t = _t.getFirstChild();
				expresion(_t,expS);
				_t = retTree_;
				{
					if (null == _t)
						_t = ASTNULL;
					switch ( _t.Type )
					{
					case LIT_CIERTO:
					case LIT_FALSO:
					case OP_DIV:
					case OP_MOD:
					case OP_Y:
					case OP_O:
					case OP_NEG:
					case LIT_ENTERO:
					case LIT_REAL:
					case IDENT:
					case OP_IGUAL:
					case OP_MAYOR:
					case OP_MENOR:
					case OP_MAYOR_IGUAL:
					case OP_MENOR_IGUAL:
					case OP_DISTINTO:
					case OP_MAS:
					case OP_MENOS:
					case OP_PRODUCTO:
					case OP_DIVISION:
					case LIT_CADENA:
					case LLAMADA_FUNCION:
					{
						expresion(_t,expS);
						_t = retTree_;
						break;
					}
					case 3:
					{
						break;
					}
					default:
					{
						throw new NoViableAltException(_t);
					}
					 }
				}
				_t = __t64;
				_t = _t.getNextSibling();
				
				MinusExpresion ex = new MinusExpresion();
				expS.Add(ex);
				
				break;
			}
			case OP_O:
			{
				AST __t66 = _t;
				AST tmp27_AST_in = _t;
				match(_t,OP_O);
				_t = _t.getFirstChild();
				expresion(_t,expS);
				_t = retTree_;
				expresion(_t,expS);
				_t = retTree_;
				_t = __t66;
				_t = _t.getNextSibling();
				
				ORExpresion ex = new ORExpresion();
				expS.Add(ex);
				
				break;
			}
			case OP_PRODUCTO:
			{
				AST __t67 = _t;
				AST tmp28_AST_in = _t;
				match(_t,OP_PRODUCTO);
				_t = _t.getFirstChild();
				expresion(_t,expS);
				_t = retTree_;
				expresion(_t,expS);
				_t = retTree_;
				_t = __t67;
				_t = _t.getNextSibling();
				
				ProductoExpresion ex = new ProductoExpresion();
				expS.Add(ex);
				
				break;
			}
			case OP_DIVISION:
			{
				AST __t68 = _t;
				AST tmp29_AST_in = _t;
				match(_t,OP_DIVISION);
				_t = _t.getFirstChild();
				expresion(_t,expS);
				_t = retTree_;
				expresion(_t,expS);
				_t = retTree_;
				_t = __t68;
				_t = _t.getNextSibling();
				
				DivisionExpresion ex = new DivisionExpresion();
				expS.Add(ex);
				
				break;
			}
			case OP_DIV:
			{
				AST __t69 = _t;
				AST tmp30_AST_in = _t;
				match(_t,OP_DIV);
				_t = _t.getFirstChild();
				expresion(_t,expS);
				_t = retTree_;
				expresion(_t,expS);
				_t = retTree_;
				_t = __t69;
				_t = _t.getNextSibling();
				
				DIVExpresion ex = new DIVExpresion();
				expS.Add(ex);
				
				break;
			}
			case OP_MOD:
			{
				AST __t70 = _t;
				AST tmp31_AST_in = _t;
				match(_t,OP_MOD);
				_t = _t.getFirstChild();
				expresion(_t,expS);
				_t = retTree_;
				expresion(_t,expS);
				_t = retTree_;
				_t = __t70;
				_t = _t.getNextSibling();
				
				MODExpresion ex = new MODExpresion();
				expS.Add(ex);
				
				break;
			}
			case OP_Y:
			{
				AST __t71 = _t;
				AST tmp32_AST_in = _t;
				match(_t,OP_Y);
				_t = _t.getFirstChild();
				expresion(_t,expS);
				_t = retTree_;
				expresion(_t,expS);
				_t = retTree_;
				_t = __t71;
				_t = _t.getNextSibling();
				
				ANDExpresion ex = new ANDExpresion();
				expS.Add(ex);
				
				break;
			}
			case OP_NEG:
			{
				AST __t72 = _t;
				AST tmp33_AST_in = _t;
				match(_t,OP_NEG);
				_t = _t.getFirstChild();
				expresion(_t,expS);
				_t = retTree_;
				_t = __t72;
				_t = _t.getNextSibling();
				
				NOTExpresion ex = new NOTExpresion();
				expS.Add(ex);
				
				break;
			}
			case IDENT:
			{
				id = _t;
				match(_t,IDENT);
				_t = _t.getNextSibling();
				
				Variable ex = new Variable();
				ex.Value = id.getText();
				expS.Add(ex);
				
				break;
			}
			case LIT_ENTERO:
			{
				c1 = _t;
				match(_t,LIT_ENTERO);
				_t = _t.getNextSibling();
				
				IntLiteral ex = new IntLiteral();
				ex.Value = c1.getText();
				expS.Add(ex);
				
				break;
			}
			case LIT_REAL:
			{
				c2 = _t;
				match(_t,LIT_REAL);
				_t = _t.getNextSibling();
				
				RealLiteral ex = new RealLiteral();
				ex.Value = c2.getText();
				expS.Add(ex);
				
				break;
			}
			case LIT_CIERTO:
			{
				c3 = _t;
				match(_t,LIT_CIERTO);
				_t = _t.getNextSibling();
				
				BoolLiteral ex = new BoolLiteral();
				ex.Value = c3.getText();
				expS.Add(ex);
				
				break;
			}
			case LIT_FALSO:
			{
				c4 = _t;
				match(_t,LIT_FALSO);
				_t = _t.getNextSibling();
				
				BoolLiteral ex = new BoolLiteral();
				ex.Value = c4.getText();
				expS.Add(ex);
				
				break;
			}
			case LIT_CADENA:
			{
				c5 = _t;
				match(_t,LIT_CADENA);
				_t = _t.getNextSibling();
				
				if (c5.getText().Length > 1)
				{
				StringLiteral ex = new StringLiteral();
				ex.Value = c5.getText();
				expS.Add(ex);
				}
				else
				{
				CharLiteral ex = new CharLiteral();
				ex.Value = c5.getText();
				expS.Add(ex);
				}
				
				break;
			}
			case LLAMADA_FUNCION:
			{
				llamadaFuncion(_t,ref sfc);
				_t = retTree_;
				
				if (sfc != null)
				{
				Function f = (Function)sfc;
				ExpFunction ex = new ExpFunction();
				ex.Tipo = f.TypeReturn.toString();
				ex.Value = f.Name; 
				expS.Add(ex);
				}
				
				break;
			}
			default:
			{
				throw new NoViableAltException(_t);
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void llamadaFuncion(AST _t,
		ref Symbol s
	) //throws RecognitionException
{
		
		AST llamadaFuncion_AST_in = (AST)_t;
		AST id = null;
		
		try {      // for error handling
			
			ArrayList lista = new ArrayList();
			Function func = null;
			Procedure proc = null;
			
			AST __t74 = _t;
			AST tmp34_AST_in = _t;
			match(_t,LLAMADA_FUNCION);
			_t = _t.getFirstChild();
			id = _t;
			match(_t,IDENT);
			_t = _t.getNextSibling();
			{
				if (null == _t)
					_t = ASTNULL;
				switch ( _t.Type )
				{
				case LISTA_ARGUMENTOS:
				{
					listaArgumentos(_t,lista);
					_t = retTree_;
					break;
				}
				case 3:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(_t);
				}
				 }
			}
			
			try 
			{
			s = symtab.find(id.getText());
			} catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }        
			
			if (s != null) 
			{
			if (s is Function) 
			{ 
			func = (Function)s; 
			try
			{
			if (func.checkParams(lista))
			cgen.genCall(func, lista, scope, proc_actual);
			} catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }        
			}
			}
			
			_t = __t74;
			_t = _t.getNextSibling();
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void listaArgumentos(AST _t,
		ArrayList lista
	) //throws RecognitionException
{
		
		AST listaArgumentos_AST_in = (AST)_t;
		
		try {      // for error handling
			AST __t80 = _t;
			AST tmp35_AST_in = _t;
			match(_t,LISTA_ARGUMENTOS);
			_t = _t.getFirstChild();
			{ // ( ... )+
				int _cnt82=0;
				for (;;)
				{
					if (_t == null)
						_t = ASTNULL;
					if ((tokenSet_1_.member(_t.Type)))
					{
						argType(_t,lista);
						_t = retTree_;
					}
					else
					{
						if (_cnt82 >= 1) { goto _loop82_breakloop; } else { throw new NoViableAltException(_t);; }
					}
					
					_cnt82++;
				}
_loop82_breakloop:				;
			}    // ( ... )+
			_t = __t80;
			_t = _t.getNextSibling();
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void argType(AST _t,
		ArrayList lista
	) //throws RecognitionException
{
		
		AST argType_AST_in = (AST)_t;
		AST id2 = null;
		AST a = null;
		AST b = null;
		AST c = null;
		AST d = null;
		AST f = null;
		AST e = null;
		
		try {      // for error handling
			if (null == _t)
				_t = ASTNULL;
			switch ( _t.Type )
			{
			case IDENT:
			{
				
				Symbol s = null;
				
				id2 = _t;
				match(_t,IDENT);
				_t = _t.getNextSibling();
				
				try
				{
				if (scope == 0) 
				s = symtab.find(id2.getText());
				else 
				s = symtab.findInAllScopes(proc_actual, id2.getText());
				if (s != null)
				lista.Add(s);
				} catch (fpc2ilException ex) { err.addError(ex.Message, id2.getLine(), id2.getColumn()); }        
				
				break;
			}
			case LIT_CIERTO:
			case LIT_FALSO:
			case LIT_ENTERO:
			case LIT_REAL:
			case LIT_CADENA:
			case LIT_CHAR:
			{
				{
					if (null == _t)
						_t = ASTNULL;
					switch ( _t.Type )
					{
					case LIT_ENTERO:
					{
						a = _t;
						match(_t,LIT_ENTERO);
						_t = _t.getNextSibling();
						Symbol s = new Symbol(a.getText(), new Type()); s.Type = new Type (Type.T.INT,0,null); s.Literal = true; lista.Add(s);
						break;
					}
					case LIT_CIERTO:
					case LIT_FALSO:
					case LIT_REAL:
					case LIT_CADENA:
					case LIT_CHAR:
					{
						{
							if (null == _t)
								_t = ASTNULL;
							switch ( _t.Type )
							{
							case LIT_REAL:
							{
								b = _t;
								match(_t,LIT_REAL);
								_t = _t.getNextSibling();
								Symbol s = new Symbol(b.getText(), new Type()); s.Type = new Type (Type.T.REAL,0,null); s.Literal = true; lista.Add(s);
								break;
							}
							case LIT_CIERTO:
							case LIT_FALSO:
							case LIT_CADENA:
							case LIT_CHAR:
							{
								{
									if (null == _t)
										_t = ASTNULL;
									switch ( _t.Type )
									{
									case LIT_CIERTO:
									{
										c = _t;
										match(_t,LIT_CIERTO);
										_t = _t.getNextSibling();
										Symbol s = new Symbol(c.getText(), new Type()); s.Type = new Type (Type.T.BOOLEAN,0,null); s.Literal = true; lista.Add(s);
										break;
									}
									case LIT_FALSO:
									case LIT_CADENA:
									case LIT_CHAR:
									{
										{
											if (null == _t)
												_t = ASTNULL;
											switch ( _t.Type )
											{
											case LIT_FALSO:
											{
												d = _t;
												match(_t,LIT_FALSO);
												_t = _t.getNextSibling();
												Symbol s = new Symbol(d.getText(), new Type()); s.Type  = new Type (Type.T.BOOLEAN,0,null); s.Literal = true; lista.Add(s);
												break;
											}
											case LIT_CADENA:
											case LIT_CHAR:
											{
												{
													if (null == _t)
														_t = ASTNULL;
													switch ( _t.Type )
													{
													case LIT_CHAR:
													{
														f = _t;
														match(_t,LIT_CHAR);
														_t = _t.getNextSibling();
														Symbol s = new Symbol(f.getText(), new Type()); s.Type  = new Type (Type.T.CHAR,0,null); s.Literal = true; lista.Add(s);
														break;
													}
													case LIT_CADENA:
													{
														{
															e = _t;
															match(_t,LIT_CADENA);
															_t = _t.getNextSibling();
															Symbol s = new Symbol(e.getText(), new Type()); s.Type = new Type (Type.T.STRING,0,null); s.Literal = true; lista.Add(s);
														}
														break;
													}
													default:
													{
														throw new NoViableAltException(_t);
													}
													 }
												}
												break;
											}
											default:
											{
												throw new NoViableAltException(_t);
											}
											 }
										}
										break;
									}
									default:
									{
										throw new NoViableAltException(_t);
									}
									 }
								}
								break;
							}
							default:
							{
								throw new NoViableAltException(_t);
							}
							 }
						}
						break;
					}
					default:
					{
						throw new NoViableAltException(_t);
					}
					 }
				}
				break;
			}
			default:
			{
				throw new NoViableAltException(_t);
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void condicional(AST _t) //throws RecognitionException
{
		
		AST condicional_AST_in = (AST)_t;
		
		ArrayList expS = new ArrayList();
		Emit.Label ifLabel = new System.Reflection.Emit.Label();
		Emit.Label orlabel = new System.Reflection.Emit.Label();
		
		bool elseStatement = false;
		bool hasOr = false;
		
		
		try {      // for error handling
			AST __t92 = _t;
			AST tmp36_AST_in = _t;
			match(_t,RES_IF);
			_t = _t.getFirstChild();
			expresion(_t,expS);
			_t = retTree_;
			
			cgen.DefineLabel(ref ifLabel);
			hasOr = eutils.hasToGenOrLabel(expS);
			eutils.genIfExpresion(cgen, expS, scope, proc_actual, ifLabel, ref orlabel);
			if (hasOr)
			cgen.MarkLabel(orlabel);
			hasOr = false;
			
			sentencias(_t);
			_t = retTree_;
			{
				if (null == _t)
					_t = ASTNULL;
				switch ( _t.Type )
				{
				case RES_ELSE:
				{
					expresionElse(_t,ref ifLabel, ref elseStatement);
					_t = retTree_;
					break;
				}
				case 3:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(_t);
				}
				 }
			}
			_t = __t92;
			_t = _t.getNextSibling();
			
			if (!elseStatement)
			cgen.MarkLabel(ifLabel);
			
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void bucle(AST _t) //throws RecognitionException
{
		
		AST bucle_AST_in = (AST)_t;
		
		try {      // for error handling
			if (null == _t)
				_t = ASTNULL;
			switch ( _t.Type )
			{
			case RES_FOR:
			{
				efor(_t);
				_t = retTree_;
				break;
			}
			case RES_WHILE:
			{
				ewhile(_t);
				_t = retTree_;
				break;
			}
			case RES_REPEAT:
			{
				erepeat(_t);
				_t = retTree_;
				break;
			}
			default:
			{
				throw new NoViableAltException(_t);
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void expresionElse(AST _t,
		ref Emit.Label label, ref bool elseStatement
	) //throws RecognitionException
{
		
		AST expresionElse_AST_in = (AST)_t;
		
		try {      // for error handling
			
			Emit.Label elseLabel = new System.Reflection.Emit.Label();
			
			AST __t95 = _t;
			AST tmp37_AST_in = _t;
			match(_t,RES_ELSE);
			_t = _t.getFirstChild();
			
			elseStatement = true;
			cgen.genElseStatement(ref elseLabel);
			cgen.MarkLabel(label);
			
			sentencias(_t);
			_t = retTree_;
			_t = __t95;
			_t = _t.getNextSibling();
			
			cgen.MarkLabel(elseLabel);
			
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void efor(AST _t) //throws RecognitionException
{
		
		AST efor_AST_in = (AST)_t;
		AST id = null;
		
		try {      // for error handling
			
			Symbol to = null;
			string ident = "";
			Emit.Label forLabel = new System.Reflection.Emit.Label();
			Emit.Label forBody = new System.Reflection.Emit.Label();
			
			AST __t98 = _t;
			AST tmp38_AST_in = _t;
			match(_t,RES_FOR);
			_t = _t.getFirstChild();
			id = _t;
			match(_t,IDENT);
			_t = _t.getNextSibling();
			
			ident = id.getText();
			
			listaFor(_t,ident, ref to, ref forLabel, ref forBody);
			_t = retTree_;
			sentencias(_t);
			_t = retTree_;
			_t = __t98;
			_t = _t.getNextSibling();
			
			cgen.genEndForStatement(scope, proc_actual, ident, to, ref forLabel, ref forBody);
			
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void ewhile(AST _t) //throws RecognitionException
{
		
		AST ewhile_AST_in = (AST)_t;
		
		ArrayList expS = new ArrayList();
		Emit.Label whileLabel = new System.Reflection.Emit.Label();
		Emit.Label whileBody = new System.Reflection.Emit.Label();
		Emit.Label whileEnd = new System.Reflection.Emit.Label();
		
		
		try {      // for error handling
			AST __t103 = _t;
			AST tmp39_AST_in = _t;
			match(_t,RES_WHILE);
			_t = _t.getFirstChild();
			expresion(_t,expS);
			_t = retTree_;
			
			cgen.genWhileStatement(ref whileLabel, ref whileBody);
			
			sentencias(_t);
			_t = retTree_;
			_t = __t103;
			_t = _t.getNextSibling();
			
			cgen.DefineLabel(ref whileEnd);
			eutils.genWhileExpresion(cgen, expS, scope, proc_actual, whileLabel, whileBody, whileEnd);
			cgen.MarkLabel(whileEnd);
			
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void erepeat(AST _t) //throws RecognitionException
{
		
		AST erepeat_AST_in = (AST)_t;
		
		ArrayList expS = new ArrayList();
		Emit.Label repeatLabel = new System.Reflection.Emit.Label();
		Emit.Label repeatBody = new System.Reflection.Emit.Label();
		Emit.Label repeatEnd = new System.Reflection.Emit.Label();
		
		
		try {      // for error handling
			AST __t105 = _t;
			AST tmp40_AST_in = _t;
			match(_t,RES_REPEAT);
			_t = _t.getFirstChild();
			
			cgen.genWhileStatement(ref repeatLabel, ref repeatBody);
			
			sentencias(_t);
			_t = retTree_;
			expresion(_t,expS);
			_t = retTree_;
			_t = __t105;
			_t = _t.getNextSibling();
			
			cgen.DefineLabel(ref repeatEnd);
			eutils.genRepeatExpresion(cgen, expS, scope, proc_actual, repeatLabel, repeatBody, repeatEnd);
			cgen.MarkLabel(repeatEnd);
			
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public void listaFor(AST _t,
		string control_var, ref Symbol to, ref Emit.Label forLabel, ref Emit.Label forBody
	) //throws RecognitionException
{
		
		AST listaFor_AST_in = (AST)_t;
		
		try {      // for error handling
			
			Symbol ini;
			Symbol fin;
			
			AST __t100 = _t;
			AST tmp41_AST_in = _t;
			match(_t,RES_TO);
			_t = _t.getFirstChild();
			ini=valor_for(_t);
			_t = retTree_;
			fin=valor_for(_t);
			_t = retTree_;
			_t = __t100;
			_t = _t.getNextSibling();
			
			to = fin;
			cgen.genForStatement(scope, proc_actual, control_var, ini, ref forLabel, ref forBody);
			
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
	}
	
	public Symbol  valor_for(AST _t) //throws RecognitionException
{
		Symbol x;
		
		AST valor_for_AST_in = (AST)_t;
		AST id = null;
		AST lit = null;
		
		x = null;
		
		
		try {      // for error handling
			if (null == _t)
				_t = ASTNULL;
			switch ( _t.Type )
			{
			case IDENT:
			{
				id = _t;
				match(_t,IDENT);
				_t = _t.getNextSibling();
				
				if (scope == 0)
				x = symtab.find(id.getText());
				else 
				x = symtab.findInAllScopes(proc_actual, id.getText());
				
				break;
			}
			case LIT_ENTERO:
			{
				lit = _t;
				match(_t,LIT_ENTERO);
				_t = _t.getNextSibling();
				
				x = new Symbol(lit.getText(), new Type());
				x.Type = new Type (Type.T.INT,0,null);
				
				break;
			}
			default:
			{
				throw new NoViableAltException(_t);
			}
			 }
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		retTree_ = _t;
		return x;
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
		long[] data = { -9223301668097818624L, 4L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_0_ = new BitSet(mk_tokenSet_0_());
	private static long[] mk_tokenSet_1_()
	{
		long[] data = { 288230676799424000L, 8L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_1_ = new BitSet(mk_tokenSet_1_());
}

