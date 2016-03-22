// $ANTLR 2.7.7 (20060906): "fpc2ilTreeParser.g" -> "fpc2ilTreeParser.cs"$

    using System.Collections;
    using System.Collections.Generic;
    using ASTEnumeration = antlr.collections.AST;

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
	
	
	public 	class fpc2ilTreeParser : antlr.TreeParser
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
    private fpc2ilTypeChecking tcheck = null;
		public fpc2ilTreeParser()
		{
			tokenNames = tokenNames_;
		}
		
	public void programa(AST _t) //throws RecognitionException
{
		
		AST programa_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST programa_AST = null;
		
		symtab = Symboltable.Instance;
		err = Errors.Instance;
		tcheck = new fpc2ilTypeChecking();
		
		
		try {      // for error handling
			AST __t2 = _t;
			AST tmp1_AST = null;
			AST tmp1_AST_in = null;
			tmp1_AST = astFactory.create(_t);
			tmp1_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp1_AST);
			ASTPair __currentAST2 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
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
						astFactory.addASTChild(ref currentAST, returnAST);
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
			astFactory.addASTChild(ref currentAST, returnAST);
			currentAST = __currentAST2;
			_t = __t2;
			_t = _t.getNextSibling();
			programa_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = programa_AST;
		retTree_ = _t;
	}
	
	public void declaracionPrograma(AST _t) //throws RecognitionException
{
		
		AST declaracionPrograma_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST declaracionPrograma_AST = null;
		AST id = null;
		AST id_AST = null;
		
		Symbol s;
		
		
		try {      // for error handling
			AST __t6 = _t;
			AST tmp2_AST = null;
			AST tmp2_AST_in = null;
			tmp2_AST = astFactory.create(_t);
			tmp2_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp2_AST);
			ASTPair __currentAST6 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,RES_PROGRAM);
			_t = _t.getFirstChild();
			id = _t;
			AST id_AST_in = null;
			id_AST = astFactory.create(id);
			astFactory.addASTChild(ref currentAST, id_AST);
			match(_t,IDENT);
			_t = _t.getNextSibling();
			currentAST = __currentAST6;
			_t = __t6;
			_t = _t.getNextSibling();
			declaracionPrograma_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = declaracionPrograma_AST;
		retTree_ = _t;
	}
	
	public void bloque(AST _t) //throws RecognitionException
{
		
		AST bloque_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST bloque_AST = null;
		
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
						astFactory.addASTChild(ref currentAST, returnAST);
						break;
					}
					case RES_CONST:
					{
						decConst(_t);
						_t = retTree_;
						astFactory.addASTChild(ref currentAST, returnAST);
						break;
					}
					case RES_PROCEDURE:
					{
						decprocedimiento(_t);
						_t = retTree_;
						astFactory.addASTChild(ref currentAST, returnAST);
						break;
					}
					case RES_FUNCTION:
					{
						decFunction(_t);
						_t = retTree_;
						astFactory.addASTChild(ref currentAST, returnAST);
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
			astFactory.addASTChild(ref currentAST, returnAST);
			bloque_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = bloque_AST;
		retTree_ = _t;
	}
	
	public void decVar(AST _t) //throws RecognitionException
{
		
		AST decVar_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST decVar_AST = null;
		
		try {      // for error handling
			AST __t24 = _t;
			AST tmp3_AST = null;
			AST tmp3_AST_in = null;
			tmp3_AST = astFactory.create(_t);
			tmp3_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp3_AST);
			ASTPair __currentAST24 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,RES_VAR);
			_t = _t.getFirstChild();
			{ // ( ... )+
				int _cnt26=0;
				for (;;)
				{
					if (_t == null)
						_t = ASTNULL;
					if ((_t.Type==DOS_PUNTOS))
					{
						declaracionVariable(_t);
						_t = retTree_;
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					else
					{
						if (_cnt26 >= 1) { goto _loop26_breakloop; } else { throw new NoViableAltException(_t);; }
					}
					
					_cnt26++;
				}
_loop26_breakloop:				;
			}    // ( ... )+
			currentAST = __currentAST24;
			_t = __t24;
			_t = _t.getNextSibling();
			decVar_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = decVar_AST;
		retTree_ = _t;
	}
	
	public void decConst(AST _t) //throws RecognitionException
{
		
		AST decConst_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST decConst_AST = null;
		
		try {      // for error handling
			AST __t11 = _t;
			AST tmp4_AST = null;
			AST tmp4_AST_in = null;
			tmp4_AST = astFactory.create(_t);
			tmp4_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp4_AST);
			ASTPair __currentAST11 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
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
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					else
					{
						if (_cnt13 >= 1) { goto _loop13_breakloop; } else { throw new NoViableAltException(_t);; }
					}
					
					_cnt13++;
				}
_loop13_breakloop:				;
			}    // ( ... )+
			currentAST = __currentAST11;
			_t = __t11;
			_t = _t.getNextSibling();
			decConst_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = decConst_AST;
		retTree_ = _t;
	}
	
	public void decprocedimiento(AST _t) //throws RecognitionException
{
		
		AST decprocedimiento_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST decprocedimiento_AST = null;
		
		Procedure s;
		
		
		try {      // for error handling
			AST __t33 = _t;
			AST tmp5_AST = null;
			AST tmp5_AST_in = null;
			tmp5_AST = astFactory.create(_t);
			tmp5_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp5_AST);
			ASTPair __currentAST33 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,RES_PROCEDURE);
			_t = _t.getFirstChild();
			s=procParamActual(_t);
			_t = retTree_;
			astFactory.addASTChild(ref currentAST, returnAST);
			{
				if (null == _t)
					_t = ASTNULL;
				switch ( _t.Type )
				{
				case PARAMETROS:
				{
					sparametros(_t);
					_t = retTree_;
					astFactory.addASTChild(ref currentAST, returnAST);
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
			
			s.Type = new Type( Type.T.PROC, 0, s.Type);
			scope = 1;
			
			bloque(_t);
			_t = retTree_;
			astFactory.addASTChild(ref currentAST, returnAST);
			currentAST = __currentAST33;
			_t = __t33;
			_t = _t.getNextSibling();
			decprocedimiento_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = decprocedimiento_AST;
		retTree_ = _t;
	}
	
	public void decFunction(AST _t) //throws RecognitionException
{
		
		AST decFunction_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST decFunction_AST = null;
		AST ty_AST = null;
		AST ty = null;
		
		Function s;
		
		
		try {      // for error handling
			AST __t50 = _t;
			AST tmp6_AST = null;
			AST tmp6_AST_in = null;
			tmp6_AST = astFactory.create(_t);
			tmp6_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp6_AST);
			ASTPair __currentAST50 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,RES_FUNCTION);
			_t = _t.getFirstChild();
			s=funcParamActual(_t);
			_t = retTree_;
			astFactory.addASTChild(ref currentAST, returnAST);
			{
				if (null == _t)
					_t = ASTNULL;
				switch ( _t.Type )
				{
				case PARAMETROS:
				{
					sparametros(_t);
					_t = retTree_;
					astFactory.addASTChild(ref currentAST, returnAST);
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
			
			s.Type = new Type( Type.T.FUNC, 0, null);
			scope = 1;
			
			ty = _t==ASTNULL ? null : _t;
			tipo(_t);
			_t = retTree_;
			ty_AST = (AST)returnAST;
			astFactory.addASTChild(ref currentAST, returnAST);
			
			switch (ty.getText())
			{
			case "integer":
			s.TypeReturn= new Type (Type.T.INT,0,null);
			break;
			case "char":
			s.TypeReturn= new Type (Type.T.CHAR,0,null);
			break;
			case "real":
			s.TypeReturn = new Type (Type.T.REAL,0,null);
			break;
			case "boolean":
			s.TypeReturn = new Type (Type.T.BOOLEAN,0,null);
			break;
			case "string":
			s.TypeReturn = new Type (Type.T.STRING,0,null);
			break;
			}
			
			bloque(_t);
			_t = retTree_;
			astFactory.addASTChild(ref currentAST, returnAST);
			currentAST = __currentAST50;
			_t = __t50;
			_t = _t.getNextSibling();
			decFunction_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = decFunction_AST;
		retTree_ = _t;
	}
	
	public void bloque_sentencia(AST _t) //throws RecognitionException
{
		
		AST bloque_sentencia_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST bloque_sentencia_AST = null;
		
		try {      // for error handling
			AST __t53 = _t;
			AST tmp7_AST = null;
			AST tmp7_AST_in = null;
			tmp7_AST = astFactory.create(_t);
			tmp7_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp7_AST);
			ASTPair __currentAST53 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,BLOQUE);
			_t = _t.getFirstChild();
			
			/* Miramos a ver si es el bloque principal */
			AST aux = tmp7_AST_in.getNextSibling();
			if (aux != null && aux.Type == PUNTO) {
			scope = 0;
			}
			//Console.WriteLine("BLOQUE SCOPE: " + scope);
			
			{ // ( ... )+
				int _cnt55=0;
				for (;;)
				{
					if (_t == null)
						_t = ASTNULL;
					if ((tokenSet_0_.member(_t.Type)))
					{
						sentencias(_t);
						_t = retTree_;
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					else
					{
						if (_cnt55 >= 1) { goto _loop55_breakloop; } else { throw new NoViableAltException(_t);; }
					}
					
					_cnt55++;
				}
_loop55_breakloop:				;
			}    // ( ... )+
			currentAST = __currentAST53;
			_t = __t53;
			_t = _t.getNextSibling();
			bloque_sentencia_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = bloque_sentencia_AST;
		retTree_ = _t;
	}
	
	public void declaracionConstante(AST _t) //throws RecognitionException
{
		
		AST declaracionConstante_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST declaracionConstante_AST = null;
		
		Constant s;
		Procedure aux = null;
		int line = 0;
		int col = 0;
		
		
		try {      // for error handling
			{
				s=decCte(_t,ref line, ref col);
				_t = retTree_;
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			
			if (scope == 0)
			{
			try 
			{ 
			symtab.add(s); 
			} catch (fpc2ilException e) { err.addError(e.Message, line, col); }
			} 
			else 
			{
			try 
			{
			aux = (Procedure)symtab.find(proc_actual);
			} catch (fpc2ilException e) { err.addError(e.Message, line, col); }
			try
			{
			aux.addToLocals(s);
			} catch (fpc2ilException e) { err.addError(e.Message, line, col); }
			}
			
			declaracionConstante_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = declaracionConstante_AST;
		retTree_ = _t;
	}
	
	public Constant  decCte(AST _t,
		ref int line, ref int col
	) //throws RecognitionException
{
		Constant s;
		
		AST decCte_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST decCte_AST = null;
		AST id = null;
		AST id_AST = null;
		AST i = null;
		AST i_AST = null;
		AST d = null;
		AST d_AST = null;
		AST t = null;
		AST t_AST = null;
		AST f = null;
		AST f_AST = null;
		AST c = null;
		AST c_AST = null;
		
		s = null;
		
		
		try {      // for error handling
			AST __t17 = _t;
			AST tmp8_AST = null;
			AST tmp8_AST_in = null;
			tmp8_AST = astFactory.create(_t);
			tmp8_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp8_AST);
			ASTPair __currentAST17 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,OP_IGUAL);
			_t = _t.getFirstChild();
			id = _t;
			AST id_AST_in = null;
			id_AST = astFactory.create(id);
			astFactory.addASTChild(ref currentAST, id_AST);
			match(_t,IDENT);
			_t = _t.getNextSibling();
			
			s = new Constant(id.getText(), new Type());
			
			{
				if (null == _t)
					_t = ASTNULL;
				switch ( _t.Type )
				{
				case LIT_ENTERO:
				{
					i = _t;
					AST i_AST_in = null;
					i_AST = astFactory.create(i);
					astFactory.addASTChild(ref currentAST, i_AST);
					match(_t,LIT_ENTERO);
					_t = _t.getNextSibling();
					
					s.Type = new Type (Type.T.INT,0,null);
					s.Value = i.getText();
					line = i.getLine();
					col = i.getColumn();
					
					break;
				}
				case LIT_CIERTO:
				case LIT_FALSO:
				case LIT_REAL:
				case LIT_CADENA:
				{
					{
						if (null == _t)
							_t = ASTNULL;
						switch ( _t.Type )
						{
						case LIT_REAL:
						{
							d = _t;
							AST d_AST_in = null;
							d_AST = astFactory.create(d);
							astFactory.addASTChild(ref currentAST, d_AST);
							match(_t,LIT_REAL);
							_t = _t.getNextSibling();
							
							s.Type = new Type (Type.T.REAL,0,null);
							s.Value = d.getText();
							line = d.getLine();
							col = d.getColumn();
							
							break;
						}
						case LIT_CIERTO:
						case LIT_FALSO:
						case LIT_CADENA:
						{
							{
								if (null == _t)
									_t = ASTNULL;
								switch ( _t.Type )
								{
								case LIT_CIERTO:
								{
									t = _t;
									AST t_AST_in = null;
									t_AST = astFactory.create(t);
									astFactory.addASTChild(ref currentAST, t_AST);
									match(_t,LIT_CIERTO);
									_t = _t.getNextSibling();
									
									s.Type = new Type (Type.T.BOOLEAN,0,null);
									s.Value = t.getText();
									line = t.getLine();
									col = t.getColumn();
									
									break;
								}
								case LIT_FALSO:
								case LIT_CADENA:
								{
									{
										if (null == _t)
											_t = ASTNULL;
										switch ( _t.Type )
										{
										case LIT_FALSO:
										{
											f = _t;
											AST f_AST_in = null;
											f_AST = astFactory.create(f);
											astFactory.addASTChild(ref currentAST, f_AST);
											match(_t,LIT_FALSO);
											_t = _t.getNextSibling();
											
											s.Type = new Type (Type.T.BOOLEAN,0,null);
											s.Value = f.getText();
											line = f.getLine();
											col = f.getColumn();
											
											break;
										}
										case LIT_CADENA:
										{
											{
												c = _t;
												AST c_AST_in = null;
												c_AST = astFactory.create(c);
												astFactory.addASTChild(ref currentAST, c_AST);
												match(_t,LIT_CADENA);
												_t = _t.getNextSibling();
												
												if (c.getText().Length > 1)
												{
												s.Type = new Type (Type.T.STRING,0,null);
												s.Value = c.getText();
												} 
												else
												{
												s.Type = new Type (Type.T.CHAR,0,null);
												s.Value = c.getText();
												}
												line = c.getLine();
												col = c.getColumn();
												
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
			currentAST = __currentAST17;
			_t = __t17;
			_t = _t.getNextSibling();
			decCte_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = decCte_AST;
		retTree_ = _t;
		return s;
	}
	
	public void declaracionVariable(AST _t) //throws RecognitionException
{
		
		AST declaracionVariable_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST declaracionVariable_AST = null;
		
		Symbol s;
		Procedure aux = null;
		int line = 0;
		int col = 0;
		
		
		try {      // for error handling
			{
				s=decVariable(_t,ref line, ref col);
				_t = retTree_;
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			
			if (scope == 0) 
			{
			try 
			{
			symtab.add(s);
			} catch (fpc2ilException e) { err.addError(e.Message, line, col); }
			} 
			else 
			{
			try
			{
			aux = (Procedure)symtab.find(proc_actual);
			} catch (fpc2ilException e) { err.addError(e.Message, line, col); }
			try
			{
			aux.addToLocals(s);
			} catch (fpc2ilException e) { err.addError(e.Message, line, col); }
			}
			
			declaracionVariable_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = declaracionVariable_AST;
		retTree_ = _t;
	}
	
	public Symbol  decVariable(AST _t,
		ref int line, ref int col
	) //throws RecognitionException
{
		Symbol s;
		
		AST decVariable_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST decVariable_AST = null;
		AST id = null;
		AST id_AST = null;
		AST tp_AST = null;
		AST tp = null;
		
		s = null;
		
		
		try {      // for error handling
			AST __t30 = _t;
			AST tmp9_AST = null;
			AST tmp9_AST_in = null;
			tmp9_AST = astFactory.create(_t);
			tmp9_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp9_AST);
			ASTPair __currentAST30 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,DOS_PUNTOS);
			_t = _t.getFirstChild();
			id = _t;
			AST id_AST_in = null;
			id_AST = astFactory.create(id);
			astFactory.addASTChild(ref currentAST, id_AST);
			match(_t,IDENT);
			_t = _t.getNextSibling();
			tp = _t==ASTNULL ? null : _t;
			tipo(_t);
			_t = retTree_;
			tp_AST = (AST)returnAST;
			astFactory.addASTChild(ref currentAST, returnAST);
			
			line = id.getLine();
			col = id.getColumn();
			s = new Symbol(id.getText(), new Type());
			switch (tp.getText()) 
			{
			case "integer":
			s.Type = new Type (Type.T.INT,0,null);
			break;
			case "char":
			s.Type = new Type (Type.T.CHAR,0,null);
			break;
			case "real":
			s.Type = new Type (Type.T.REAL,0,null);
			break;
			case "boolean":
			s.Type = new Type (Type.T.BOOLEAN,0,null);
			break;
			case "string":
			s.Type = new Type (Type.T.STRING,0,null);
			break;
			}
			
			currentAST = __currentAST30;
			_t = __t30;
			_t = _t.getNextSibling();
			decVariable_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = decVariable_AST;
		retTree_ = _t;
		return s;
	}
	
	public void tipo(AST _t) //throws RecognitionException
{
		
		AST tipo_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST tipo_AST = null;
		
		try {      // for error handling
			if (null == _t)
				_t = ASTNULL;
			switch ( _t.Type )
			{
			case TIPO_ENTERO:
			{
				AST tmp10_AST = null;
				AST tmp10_AST_in = null;
				tmp10_AST = astFactory.create(_t);
				tmp10_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp10_AST);
				match(_t,TIPO_ENTERO);
				_t = _t.getNextSibling();
				tipo_AST = currentAST.root;
				break;
			}
			case TIPO_REAL:
			{
				AST tmp11_AST = null;
				AST tmp11_AST_in = null;
				tmp11_AST = astFactory.create(_t);
				tmp11_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp11_AST);
				match(_t,TIPO_REAL);
				_t = _t.getNextSibling();
				tipo_AST = currentAST.root;
				break;
			}
			case TIPO_CHAR:
			{
				AST tmp12_AST = null;
				AST tmp12_AST_in = null;
				tmp12_AST = astFactory.create(_t);
				tmp12_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp12_AST);
				match(_t,TIPO_CHAR);
				_t = _t.getNextSibling();
				tipo_AST = currentAST.root;
				break;
			}
			case TIPO_BOOLEANO:
			{
				AST tmp13_AST = null;
				AST tmp13_AST_in = null;
				tmp13_AST = astFactory.create(_t);
				tmp13_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp13_AST);
				match(_t,TIPO_BOOLEANO);
				_t = _t.getNextSibling();
				tipo_AST = currentAST.root;
				break;
			}
			case TIPO_CADENA:
			{
				AST tmp14_AST = null;
				AST tmp14_AST_in = null;
				tmp14_AST = astFactory.create(_t);
				tmp14_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp14_AST);
				match(_t,TIPO_CADENA);
				_t = _t.getNextSibling();
				tipo_AST = currentAST.root;
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
		returnAST = tipo_AST;
		retTree_ = _t;
	}
	
	public Procedure  procParamActual(AST _t) //throws RecognitionException
{
		Procedure s;
		
		AST procParamActual_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST procParamActual_AST = null;
		AST id = null;
		AST id_AST = null;
		
		s = null;
		
		
		try {      // for error handling
			AST __t46 = _t;
			id = (ASTNULL == _t) ? null : (AST)_t;
			AST id_AST_in = null;
			id_AST = astFactory.create(id);
			astFactory.addASTChild(ref currentAST, id_AST);
			ASTPair __currentAST46 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,IDENT);
			_t = _t.getFirstChild();
			
			s = new Procedure( id.getText(), new Type());
			try
			{
			symtab.add(s);
			} catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
			proc_actual = id.getText();
			
			currentAST = __currentAST46;
			_t = __t46;
			_t = _t.getNextSibling();
			procParamActual_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = procParamActual_AST;
		retTree_ = _t;
		return s;
	}
	
	public void sparametros(AST _t) //throws RecognitionException
{
		
		AST sparametros_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST sparametros_AST = null;
		
		uint argnum = 0;
		Hashtable parametros = new Hashtable();
		Procedure s;
		int line = 0;
		int col = 0;
		
		
		try {      // for error handling
			AST __t36 = _t;
			AST tmp15_AST = null;
			AST tmp15_AST_in = null;
			tmp15_AST = astFactory.create(_t);
			tmp15_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp15_AST);
			ASTPair __currentAST36 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
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
					listaParametros(_t,parametros, ref argnum, ref line, ref col);
					_t = retTree_;
					astFactory.addASTChild(ref currentAST, returnAST);
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
			Procedure aux = (Procedure)symtab.find(proc_actual);
			aux.Parameters = parametros;
			} catch (fpc2ilException e) { err.addError(e.Message, line, col); }
			
			currentAST = __currentAST36;
			_t = __t36;
			_t = _t.getNextSibling();
			sparametros_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = sparametros_AST;
		retTree_ = _t;
	}
	
	public void listaParametros(AST _t,
		Hashtable parametros, ref uint argnum, ref int line, ref int col
	) //throws RecognitionException
{
		
		AST listaParametros_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST listaParametros_AST = null;
		
		try {      // for error handling
			{ // ( ... )+
				int _cnt40=0;
				for (;;)
				{
					if (null == _t)
						_t = ASTNULL;
					switch ( _t.Type )
					{
					case RES_VAR:
					{
						declaracionParametroRef(_t,parametros, ref argnum, ref line, ref col);
						_t = retTree_;
						astFactory.addASTChild(ref currentAST, returnAST);
						break;
					}
					case IDENT:
					{
						declaracionParametroValor(_t,parametros, ref argnum, ref line, ref col);
						_t = retTree_;
						astFactory.addASTChild(ref currentAST, returnAST);
						break;
					}
					default:
					{
						if (_cnt40 >= 1) { goto _loop40_breakloop; } else { throw new NoViableAltException(_t);; }
					}
					break; }
					_cnt40++;
				}
_loop40_breakloop:				;
			}    // ( ... )+
			listaParametros_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = listaParametros_AST;
		retTree_ = _t;
	}
	
	public void declaracionParametroRef(AST _t,
		Hashtable parametros, ref uint argnum, ref int line, ref int col
	) //throws RecognitionException
{
		
		AST declaracionParametroRef_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST declaracionParametroRef_AST = null;
		AST id = null;
		AST id_AST = null;
		AST ty_AST = null;
		AST ty = null;
		
		Param p = null;
		
		
		try {      // for error handling
			AST __t42 = _t;
			AST tmp16_AST = null;
			AST tmp16_AST_in = null;
			tmp16_AST = astFactory.create(_t);
			tmp16_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp16_AST);
			ASTPair __currentAST42 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,RES_VAR);
			_t = _t.getFirstChild();
			id = _t;
			AST id_AST_in = null;
			id_AST = astFactory.create(id);
			astFactory.addASTChild(ref currentAST, id_AST);
			match(_t,IDENT);
			_t = _t.getNextSibling();
			ty = _t==ASTNULL ? null : _t;
			tipo(_t);
			_t = retTree_;
			ty_AST = (AST)returnAST;
			astFactory.addASTChild(ref currentAST, returnAST);
			
			line = id.getLine();
			col = id.getColumn();
			p = new Param(id.getText(), new Type(), argnum++, true);
			switch (ty.getText())
			{
			case "integer":
			p.Type = new Type (Type.T.INT,0,null);
			break;
			case "char":
			p.Type = new Type (Type.T.CHAR,0,null);
			break;
			case "real":
			p.Type = new Type (Type.T.REAL,0,null);
			break;
			case "boolean":
			p.Type = new Type (Type.T.BOOLEAN,0,null);
			break;
			case "string":
			p.Type = new Type (Type.T.STRING,0,null);
			break;
			}
			try 
			{
			parametros.Add(p.Name, p);
			} 
			catch (ArgumentException e) 
			{
			err.addError("Parameter '" + p.Name + "' has been previously defined", id.getLine(), id.getColumn());
			}
			
			currentAST = __currentAST42;
			_t = __t42;
			_t = _t.getNextSibling();
			declaracionParametroRef_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = declaracionParametroRef_AST;
		retTree_ = _t;
	}
	
	public void declaracionParametroValor(AST _t,
		Hashtable parametros, ref uint argnum, ref int line, ref int col
	) //throws RecognitionException
{
		
		AST declaracionParametroValor_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST declaracionParametroValor_AST = null;
		AST id = null;
		AST id_AST = null;
		AST ty_AST = null;
		AST ty = null;
		
		Param p = null;
		
		
		try {      // for error handling
			{
				id = _t;
				AST id_AST_in = null;
				id_AST = astFactory.create(id);
				astFactory.addASTChild(ref currentAST, id_AST);
				match(_t,IDENT);
				_t = _t.getNextSibling();
				ty = _t==ASTNULL ? null : _t;
				tipo(_t);
				_t = retTree_;
				ty_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				
				line = id.getLine();
				col = id.getColumn();
				p = new Param(id.getText(), new Type(), argnum++, false);
				switch (ty.getText())
				{
				case "integer":
				p.Type = new Type (Type.T.INT,0,null);
				break;
				case "char":
				p.Type = new Type (Type.T.CHAR,0,null);
				break;
				case "real":
				p.Type = new Type (Type.T.REAL,0,null);
				break;
				case "boolean":
				p.Type = new Type (Type.T.BOOLEAN,0,null);
				break;
				case "string":
				p.Type = new Type (Type.T.STRING,0,null);
				break;
				}
				try 
				{
				parametros.Add(p.Name, p);
				} 
				catch (ArgumentException e) 
				{
				err.addError("Parameter '" + p.Name + "' has been previously defined", id.getLine(), id.getColumn());
				}
				
			}
			declaracionParametroValor_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = declaracionParametroValor_AST;
		retTree_ = _t;
	}
	
	public Function  funcParamActual(AST _t) //throws RecognitionException
{
		Function s;
		
		AST funcParamActual_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST funcParamActual_AST = null;
		AST id = null;
		AST id_AST = null;
		
		s = null;
		
		
		try {      // for error handling
			AST __t48 = _t;
			id = (ASTNULL == _t) ? null : (AST)_t;
			AST id_AST_in = null;
			id_AST = astFactory.create(id);
			astFactory.addASTChild(ref currentAST, id_AST);
			ASTPair __currentAST48 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,IDENT);
			_t = _t.getFirstChild();
			
			s = new Function( id.getText(), new Type());
			try
			{
			symtab.add(s);
			} catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
			proc_actual = id.getText();
			
			currentAST = __currentAST48;
			_t = __t48;
			_t = _t.getNextSibling();
			funcParamActual_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = funcParamActual_AST;
		retTree_ = _t;
		return s;
	}
	
	public void sentencias(AST _t) //throws RecognitionException
{
		
		AST sentencias_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST sentencias_AST = null;
		
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
				astFactory.addASTChild(ref currentAST, returnAST);
				sentencias_AST = currentAST.root;
				break;
			}
			case RES_FOR:
			case RES_IF:
			case RES_WHILE:
			case RES_REPEAT:
			{
				sentencia_compuesta(_t);
				_t = retTree_;
				astFactory.addASTChild(ref currentAST, returnAST);
				sentencias_AST = currentAST.root;
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
		returnAST = sentencias_AST;
		retTree_ = _t;
	}
	
	public void sentencia_simple(AST _t) //throws RecognitionException
{
		
		AST sentencia_simple_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST sentencia_simple_AST = null;
		
		try {      // for error handling
			if (null == _t)
				_t = ASTNULL;
			switch ( _t.Type )
			{
			case BLOQUE:
			{
				bloque_sentencia(_t);
				_t = retTree_;
				astFactory.addASTChild(ref currentAST, returnAST);
				sentencia_simple_AST = currentAST.root;
				break;
			}
			case OP_ASSING:
			{
				asignacion(_t);
				_t = retTree_;
				astFactory.addASTChild(ref currentAST, returnAST);
				sentencia_simple_AST = currentAST.root;
				break;
			}
			case LLAMADA_PROC:
			{
				llamada_proc(_t);
				_t = retTree_;
				astFactory.addASTChild(ref currentAST, returnAST);
				sentencia_simple_AST = currentAST.root;
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
		returnAST = sentencia_simple_AST;
		retTree_ = _t;
	}
	
	public void sentencia_compuesta(AST _t) //throws RecognitionException
{
		
		AST sentencia_compuesta_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST sentencia_compuesta_AST = null;
		
		try {      // for error handling
			if (null == _t)
				_t = ASTNULL;
			switch ( _t.Type )
			{
			case RES_IF:
			{
				condicional(_t);
				_t = retTree_;
				astFactory.addASTChild(ref currentAST, returnAST);
				sentencia_compuesta_AST = currentAST.root;
				break;
			}
			case RES_FOR:
			case RES_WHILE:
			case RES_REPEAT:
			{
				bucle(_t);
				_t = retTree_;
				astFactory.addASTChild(ref currentAST, returnAST);
				sentencia_compuesta_AST = currentAST.root;
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
		returnAST = sentencia_compuesta_AST;
		retTree_ = _t;
	}
	
	public void asignacion(AST _t) //throws RecognitionException
{
		
		AST asignacion_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST asignacion_AST = null;
		AST id = null;
		AST id_AST = null;
		
		try {      // for error handling
			
			Symbol s = null;
			string etipo = null;
			ArrayList lexpresiones = new ArrayList();
			
			AST __t59 = _t;
			AST tmp17_AST = null;
			AST tmp17_AST_in = null;
			tmp17_AST = astFactory.create(_t);
			tmp17_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp17_AST);
			ASTPair __currentAST59 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,OP_ASSING);
			_t = _t.getFirstChild();
			id = _t;
			AST id_AST_in = null;
			id_AST = astFactory.create(id);
			astFactory.addASTChild(ref currentAST, id_AST);
			match(_t,IDENT);
			_t = _t.getNextSibling();
			expresion(_t,lexpresiones);
			_t = retTree_;
			astFactory.addASTChild(ref currentAST, returnAST);
			
			if (scope == 0)
			{
			try 
			{
			s = symtab.find(id.getText());
			} catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
			}
			else
			{
			try 
			{
			s = symtab.findInAllScopes(proc_actual, id.getText());
			} catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
			}
			
			if (s != null) 
			{
			//No podemos asignar a una constante
			if (s is Constant)
			err.addError("Constant '" + s.Name + "' can't be assigned a value", id.getLine(), id.getColumn());
			
			string checkType = s.Type.toString();
			
			if (s is Function)
			{
			Function aux = (Function)s;
			checkType = aux.TypeReturn.toString();
			}
			
			if (!tcheck.checkTypeExpression(checkType, lexpresiones, ref etipo))
			err.addError("Cannot assing type (" + etipo + ") to variable '" + s.Name + "' (" + s.Type.toString() + ")",
			id.getLine(), id.getColumn());
			}
			
			currentAST = __currentAST59;
			_t = __t59;
			_t = _t.getNextSibling();
			asignacion_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = asignacion_AST;
		retTree_ = _t;
	}
	
	public void llamada_proc(AST _t) //throws RecognitionException
{
		
		AST llamada_proc_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST llamada_proc_AST = null;
		AST id = null;
		AST id_AST = null;
		
		try {      // for error handling
			AST __t82 = _t;
			AST tmp18_AST = null;
			AST tmp18_AST_in = null;
			tmp18_AST = astFactory.create(_t);
			tmp18_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp18_AST);
			ASTPair __currentAST82 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,LLAMADA_PROC);
			_t = _t.getFirstChild();
			id = _t;
			AST id_AST_in = null;
			id_AST = astFactory.create(id);
			astFactory.addASTChild(ref currentAST, id_AST);
			match(_t,IDENT);
			_t = _t.getNextSibling();
			{
				if (null == _t)
					_t = ASTNULL;
				switch ( _t.Type )
				{
				case LISTA_ARGUMENTOS:
				{
					listaArgumentos(_t);
					_t = retTree_;
					astFactory.addASTChild(ref currentAST, returnAST);
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
			currentAST = __currentAST82;
			_t = __t82;
			_t = _t.getNextSibling();
			llamada_proc_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = llamada_proc_AST;
		retTree_ = _t;
	}
	
	public void expresion(AST _t,
		ArrayList lexpr
	) //throws RecognitionException
{
		
		AST expresion_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST expresion_AST = null;
		AST a_AST = null;
		AST a = null;
		AST b_AST = null;
		AST b = null;
		AST c_AST = null;
		AST c = null;
		AST d_AST = null;
		AST d = null;
		AST f_AST = null;
		AST f = null;
		AST g_AST = null;
		AST g = null;
		AST h_AST = null;
		AST h = null;
		AST i_AST = null;
		AST i = null;
		AST j_AST = null;
		AST j = null;
		AST k_AST = null;
		AST k = null;
		AST l_AST = null;
		AST l = null;
		AST m_AST = null;
		AST m = null;
		AST n_AST = null;
		AST n = null;
		AST o_AST = null;
		AST o = null;
		AST p_AST = null;
		AST p = null;
		AST q_AST = null;
		AST q = null;
		AST r_AST = null;
		AST r = null;
		AST s_AST = null;
		AST s = null;
		AST t_AST = null;
		AST t = null;
		AST u_AST = null;
		AST u = null;
		AST v_AST = null;
		AST v = null;
		AST w_AST = null;
		AST w = null;
		AST x_AST = null;
		AST x = null;
		AST y_AST = null;
		AST y = null;
		AST z_AST = null;
		AST z = null;
		AST a1_AST = null;
		AST a1 = null;
		AST a2_AST = null;
		AST a2 = null;
		AST a3_AST = null;
		AST a3 = null;
		AST a4_AST = null;
		AST a4 = null;
		AST id = null;
		AST id_AST = null;
		AST ct1 = null;
		AST ct1_AST = null;
		AST ct2 = null;
		AST ct2_AST = null;
		AST ct3 = null;
		AST ct3_AST = null;
		AST ct4 = null;
		AST ct4_AST = null;
		AST ct5 = null;
		AST ct5_AST = null;
		
		try {      // for error handling
			if (null == _t)
				_t = ASTNULL;
			switch ( _t.Type )
			{
			case OP_IGUAL:
			{
				AST __t61 = _t;
				AST tmp19_AST = null;
				AST tmp19_AST_in = null;
				tmp19_AST = astFactory.create(_t);
				tmp19_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp19_AST);
				ASTPair __currentAST61 = currentAST.copy();
				currentAST.root = currentAST.child;
				currentAST.child = null;
				match(_t,OP_IGUAL);
				_t = _t.getFirstChild();
				a = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				a_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				b = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				b_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				currentAST = __currentAST61;
				_t = __t61;
				_t = _t.getNextSibling();
				
				BooleanExpresion bol = new BooleanExpresion();
				lexpr.Add(bol);
				
				expresion_AST = currentAST.root;
				break;
			}
			case OP_DISTINTO:
			{
				AST __t62 = _t;
				AST tmp20_AST = null;
				AST tmp20_AST_in = null;
				tmp20_AST = astFactory.create(_t);
				tmp20_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp20_AST);
				ASTPair __currentAST62 = currentAST.copy();
				currentAST.root = currentAST.child;
				currentAST.child = null;
				match(_t,OP_DISTINTO);
				_t = _t.getFirstChild();
				c = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				c_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				d = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				d_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				currentAST = __currentAST62;
				_t = __t62;
				_t = _t.getNextSibling();
				
				BooleanExpresion bol = new BooleanExpresion();
				lexpr.Add(bol);
				
				expresion_AST = currentAST.root;
				break;
			}
			case OP_MENOR:
			{
				AST __t63 = _t;
				AST tmp21_AST = null;
				AST tmp21_AST_in = null;
				tmp21_AST = astFactory.create(_t);
				tmp21_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp21_AST);
				ASTPair __currentAST63 = currentAST.copy();
				currentAST.root = currentAST.child;
				currentAST.child = null;
				match(_t,OP_MENOR);
				_t = _t.getFirstChild();
				f = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				f_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				g = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				g_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				currentAST = __currentAST63;
				_t = __t63;
				_t = _t.getNextSibling();
				
				BooleanExpresion bol = new BooleanExpresion();
				lexpr.Add(bol);
				
				expresion_AST = currentAST.root;
				break;
			}
			case OP_MENOR_IGUAL:
			{
				AST __t64 = _t;
				AST tmp22_AST = null;
				AST tmp22_AST_in = null;
				tmp22_AST = astFactory.create(_t);
				tmp22_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp22_AST);
				ASTPair __currentAST64 = currentAST.copy();
				currentAST.root = currentAST.child;
				currentAST.child = null;
				match(_t,OP_MENOR_IGUAL);
				_t = _t.getFirstChild();
				h = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				h_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				i = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				i_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				currentAST = __currentAST64;
				_t = __t64;
				_t = _t.getNextSibling();
				
				BooleanExpresion bol = new BooleanExpresion();
				lexpr.Add(bol);
				
				expresion_AST = currentAST.root;
				break;
			}
			case OP_MAYOR_IGUAL:
			{
				AST __t65 = _t;
				AST tmp23_AST = null;
				AST tmp23_AST_in = null;
				tmp23_AST = astFactory.create(_t);
				tmp23_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp23_AST);
				ASTPair __currentAST65 = currentAST.copy();
				currentAST.root = currentAST.child;
				currentAST.child = null;
				match(_t,OP_MAYOR_IGUAL);
				_t = _t.getFirstChild();
				j = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				j_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				k = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				k_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				currentAST = __currentAST65;
				_t = __t65;
				_t = _t.getNextSibling();
				
				BooleanExpresion bol = new BooleanExpresion();
				lexpr.Add(bol);
				
				expresion_AST = currentAST.root;
				break;
			}
			case OP_MAYOR:
			{
				AST __t66 = _t;
				AST tmp24_AST = null;
				AST tmp24_AST_in = null;
				tmp24_AST = astFactory.create(_t);
				tmp24_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp24_AST);
				ASTPair __currentAST66 = currentAST.copy();
				currentAST.root = currentAST.child;
				currentAST.child = null;
				match(_t,OP_MAYOR);
				_t = _t.getFirstChild();
				l = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				l_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				m = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				m_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				currentAST = __currentAST66;
				_t = __t66;
				_t = _t.getNextSibling();
				
				BooleanExpresion bol = new BooleanExpresion();
				lexpr.Add(bol);
				
				expresion_AST = currentAST.root;
				break;
			}
			case OP_MAS:
			{
				AST __t67 = _t;
				AST tmp25_AST = null;
				AST tmp25_AST_in = null;
				tmp25_AST = astFactory.create(_t);
				tmp25_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp25_AST);
				ASTPair __currentAST67 = currentAST.copy();
				currentAST.root = currentAST.child;
				currentAST.child = null;
				match(_t,OP_MAS);
				_t = _t.getFirstChild();
				n = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				n_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
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
						o = _t==ASTNULL ? null : _t;
						expresion(_t,lexpr);
						_t = retTree_;
						o_AST = (AST)returnAST;
						astFactory.addASTChild(ref currentAST, returnAST);
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
				currentAST = __currentAST67;
				_t = __t67;
				_t = _t.getNextSibling();
				
				Expr exp1 = tcheck.getExpresion(n.getText(), scope, proc_actual);
				Expr exp2 = tcheck.getExpresion(o.getText(), scope, proc_actual);
				PlusExpresion plus = new PlusExpresion();
				if (exp1 != null)
				plus.Left = exp1;
				if (exp2 != null)
				plus.Right = exp2;
				
				lexpr.Add(plus);
				
				expresion_AST = currentAST.root;
				break;
			}
			case OP_MENOS:
			{
				AST __t69 = _t;
				AST tmp26_AST = null;
				AST tmp26_AST_in = null;
				tmp26_AST = astFactory.create(_t);
				tmp26_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp26_AST);
				ASTPair __currentAST69 = currentAST.copy();
				currentAST.root = currentAST.child;
				currentAST.child = null;
				match(_t,OP_MENOS);
				_t = _t.getFirstChild();
				p = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				p_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
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
						q = _t==ASTNULL ? null : _t;
						expresion(_t,lexpr);
						_t = retTree_;
						q_AST = (AST)returnAST;
						astFactory.addASTChild(ref currentAST, returnAST);
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
				currentAST = __currentAST69;
				_t = __t69;
				_t = _t.getNextSibling();
				
				Expr exp1 = tcheck.getExpresion(p.getText(), scope, proc_actual);
				Expr exp2 = tcheck.getExpresion(q.getText(), scope, proc_actual);
				MinusExpresion minus = new MinusExpresion();
				if (exp1 != null)
				minus.Left = exp1;
				if (exp2 != null)
				minus.Right = exp2;
				
				lexpr.Add(minus);
				
				expresion_AST = currentAST.root;
				break;
			}
			case OP_O:
			{
				AST __t71 = _t;
				AST tmp27_AST = null;
				AST tmp27_AST_in = null;
				tmp27_AST = astFactory.create(_t);
				tmp27_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp27_AST);
				ASTPair __currentAST71 = currentAST.copy();
				currentAST.root = currentAST.child;
				currentAST.child = null;
				match(_t,OP_O);
				_t = _t.getFirstChild();
				r = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				r_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				s = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				s_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				currentAST = __currentAST71;
				_t = __t71;
				_t = _t.getNextSibling();
				
				ORExpresion or = new ORExpresion();
				lexpr.Add(or);
				
				expresion_AST = currentAST.root;
				break;
			}
			case OP_PRODUCTO:
			{
				AST __t72 = _t;
				AST tmp28_AST = null;
				AST tmp28_AST_in = null;
				tmp28_AST = astFactory.create(_t);
				tmp28_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp28_AST);
				ASTPair __currentAST72 = currentAST.copy();
				currentAST.root = currentAST.child;
				currentAST.child = null;
				match(_t,OP_PRODUCTO);
				_t = _t.getFirstChild();
				t = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				t_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				u = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				u_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				currentAST = __currentAST72;
				_t = __t72;
				_t = _t.getNextSibling();
				
				Expr exp1 = tcheck.getExpresion(t.getText(), scope, proc_actual);
				Expr exp2 = tcheck.getExpresion(u.getText(), scope, proc_actual);
				ProductoExpresion star = new ProductoExpresion();
				if (exp1 != null)
				star.Left = exp1;
				if (exp2 != null)
				star.Right = exp2;
				
				lexpr.Add(star);
				
				expresion_AST = currentAST.root;
				break;
			}
			case OP_DIVISION:
			{
				AST __t73 = _t;
				AST tmp29_AST = null;
				AST tmp29_AST_in = null;
				tmp29_AST = astFactory.create(_t);
				tmp29_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp29_AST);
				ASTPair __currentAST73 = currentAST.copy();
				currentAST.root = currentAST.child;
				currentAST.child = null;
				match(_t,OP_DIVISION);
				_t = _t.getFirstChild();
				v = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				v_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				w = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				w_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				currentAST = __currentAST73;
				_t = __t73;
				_t = _t.getNextSibling();
				
				Expr exp1 = tcheck.getExpresion(v.getText(), scope, proc_actual);
				Expr exp2 = tcheck.getExpresion(w.getText(), scope, proc_actual);
				DivisionExpresion divis = new DivisionExpresion();
				if (exp1 != null)
				divis.Left = exp1;
				if (exp2 != null)
				divis.Right = exp2;
				
				lexpr.Add(divis);
				
				expresion_AST = currentAST.root;
				break;
			}
			case OP_DIV:
			{
				AST __t74 = _t;
				AST tmp30_AST = null;
				AST tmp30_AST_in = null;
				tmp30_AST = astFactory.create(_t);
				tmp30_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp30_AST);
				ASTPair __currentAST74 = currentAST.copy();
				currentAST.root = currentAST.child;
				currentAST.child = null;
				match(_t,OP_DIV);
				_t = _t.getFirstChild();
				x = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				x_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				y = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				y_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				currentAST = __currentAST74;
				_t = __t74;
				_t = _t.getNextSibling();
				
				Expr exp1 = tcheck.getExpresion(x.getText(), scope, proc_actual);
				Expr exp2 = tcheck.getExpresion(y.getText(), scope, proc_actual);
				DIVExpresion div = new DIVExpresion();
				if (exp1 != null)
				div.Left = exp1;
				if (exp2 != null)
				div.Right = exp2;
				
				lexpr.Add(div);
				
				expresion_AST = currentAST.root;
				break;
			}
			case OP_MOD:
			{
				AST __t75 = _t;
				AST tmp31_AST = null;
				AST tmp31_AST_in = null;
				tmp31_AST = astFactory.create(_t);
				tmp31_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp31_AST);
				ASTPair __currentAST75 = currentAST.copy();
				currentAST.root = currentAST.child;
				currentAST.child = null;
				match(_t,OP_MOD);
				_t = _t.getFirstChild();
				z = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				z_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				a1 = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				a1_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				currentAST = __currentAST75;
				_t = __t75;
				_t = _t.getNextSibling();
				
				Expr exp1 = tcheck.getExpresion(z.getText(), scope, proc_actual);
				Expr exp2 = tcheck.getExpresion(a1.getText(), scope, proc_actual);
				MODExpresion mod = new MODExpresion();
				if (exp1 != null)
				mod.Left = exp1;
				if (exp2 != null)
				mod.Right = exp2;
				
				lexpr.Add(mod);
				
				expresion_AST = currentAST.root;
				break;
			}
			case OP_Y:
			{
				AST __t76 = _t;
				AST tmp32_AST = null;
				AST tmp32_AST_in = null;
				tmp32_AST = astFactory.create(_t);
				tmp32_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp32_AST);
				ASTPair __currentAST76 = currentAST.copy();
				currentAST.root = currentAST.child;
				currentAST.child = null;
				match(_t,OP_Y);
				_t = _t.getFirstChild();
				a2 = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				a2_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				a3 = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				a3_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				currentAST = __currentAST76;
				_t = __t76;
				_t = _t.getNextSibling();
				
				ANDExpresion and = new ANDExpresion();
				lexpr.Add(and);
				
				expresion_AST = currentAST.root;
				break;
			}
			case OP_NEG:
			{
				AST __t77 = _t;
				AST tmp33_AST = null;
				AST tmp33_AST_in = null;
				tmp33_AST = astFactory.create(_t);
				tmp33_AST_in = _t;
				astFactory.addASTChild(ref currentAST, tmp33_AST);
				ASTPair __currentAST77 = currentAST.copy();
				currentAST.root = currentAST.child;
				currentAST.child = null;
				match(_t,OP_NEG);
				_t = _t.getFirstChild();
				a4 = _t==ASTNULL ? null : _t;
				expresion(_t,lexpr);
				_t = retTree_;
				a4_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
				currentAST = __currentAST77;
				_t = __t77;
				_t = _t.getNextSibling();
				
				NOTExpresion neg = new NOTExpresion();
				lexpr.Add(neg);
				
				expresion_AST = currentAST.root;
				break;
			}
			case IDENT:
			{
				id = _t;
				AST id_AST_in = null;
				id_AST = astFactory.create(id);
				astFactory.addASTChild(ref currentAST, id_AST);
				match(_t,IDENT);
				_t = _t.getNextSibling();
				
				Symbol sym = null;
				Variable var = null;
				
				/* 
				* Todas pasan por aqui luego aqui 
				* comprobamos si estan en la tabla 
				* de simbolos para mostrar error 
				*/
				if (scope == 0)
				{
				try 
				{
				sym = symtab.find(id.getText()); 
				} catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
				} 
				else
				{
				try 
				{
				sym = symtab.findInAllScopes(proc_actual, id.getText());
				} catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
				}
				
				if (sym != null)
				{
				switch (sym.Type.toString())
				{
				case "PROC":
				err.addError("VOID type procedure '" + sym.Name + "' can't be assigned to any variable", id.getLine(),
				id.getColumn());
				break;
				case "INT":
				var = new Variable();
				var.Tipo = "INT";
				var.Value = sym.Name;
				break;
				case "CHAR":
				var = new Variable();
				var.Tipo = "CHAR";
				var.Value = sym.Name;
				break;
				case "REAL":
				var = new Variable();
				var.Tipo = "REAL";
				var.Value = sym.Name;
				break;
				case "STRING":
				var = new Variable();
				var.Tipo = "STRING";
				var.Value = sym.Name;
				break;
				case "BOOLEAN":
				var = new Variable();
				var.Tipo = "BOOLEAN";
				var.Value = sym.Name;
				break;
				}
				
				lexpr.Add(var);
				}
				
				expresion_AST = currentAST.root;
				break;
			}
			case LIT_ENTERO:
			{
				ct1 = _t;
				AST ct1_AST_in = null;
				ct1_AST = astFactory.create(ct1);
				astFactory.addASTChild(ref currentAST, ct1_AST);
				match(_t,LIT_ENTERO);
				_t = _t.getNextSibling();
				IntLiteral ict1 = new IntLiteral(); ict1.Value = ct1.getText(); lexpr.Add(ict1);
				expresion_AST = currentAST.root;
				break;
			}
			case LIT_REAL:
			{
				ct2 = _t;
				AST ct2_AST_in = null;
				ct2_AST = astFactory.create(ct2);
				astFactory.addASTChild(ref currentAST, ct2_AST);
				match(_t,LIT_REAL);
				_t = _t.getNextSibling();
				RealLiteral ict2 = new RealLiteral(); ict2.Value = ct2.getText(); lexpr.Add(ict2);
				expresion_AST = currentAST.root;
				break;
			}
			case LIT_CIERTO:
			{
				ct3 = _t;
				AST ct3_AST_in = null;
				ct3_AST = astFactory.create(ct3);
				astFactory.addASTChild(ref currentAST, ct3_AST);
				match(_t,LIT_CIERTO);
				_t = _t.getNextSibling();
				BoolLiteral ict3 = new BoolLiteral(); ict3.Value = ct3.getText(); lexpr.Add(ict3);
				expresion_AST = currentAST.root;
				break;
			}
			case LIT_FALSO:
			{
				ct4 = _t;
				AST ct4_AST_in = null;
				ct4_AST = astFactory.create(ct4);
				astFactory.addASTChild(ref currentAST, ct4_AST);
				match(_t,LIT_FALSO);
				_t = _t.getNextSibling();
				BoolLiteral ict4 = new BoolLiteral(); ict4.Value = ct4.getText(); lexpr.Add(ict4);
				expresion_AST = currentAST.root;
				break;
			}
			case LIT_CADENA:
			{
				ct5 = _t;
				AST ct5_AST_in = null;
				ct5_AST = astFactory.create(ct5);
				astFactory.addASTChild(ref currentAST, ct5_AST);
				match(_t,LIT_CADENA);
				_t = _t.getNextSibling();
				
				if (ct5.getText().Length > 1 ) 
				{
				StringLiteral ict5 = new StringLiteral(); 
				ict5.Value = ct5.getText(); lexpr.Add(ict5); 
				}
				else
				{
				CharLiteral ict6 = new CharLiteral();
				ict6.Value = ct5.getText(); lexpr.Add(ict6); 
				}
				
				expresion_AST = currentAST.root;
				break;
			}
			case LLAMADA_FUNCION:
			{
				llamadaFuncion(_t);
				_t = retTree_;
				astFactory.addASTChild(ref currentAST, returnAST);
				expresion_AST = currentAST.root;
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
		returnAST = expresion_AST;
		retTree_ = _t;
	}
	
	public void llamadaFuncion(AST _t) //throws RecognitionException
{
		
		AST llamadaFuncion_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST llamadaFuncion_AST = null;
		AST id = null;
		AST id_AST = null;
		
		try {      // for error handling
			AST __t79 = _t;
			AST tmp34_AST = null;
			AST tmp34_AST_in = null;
			tmp34_AST = astFactory.create(_t);
			tmp34_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp34_AST);
			ASTPair __currentAST79 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,LLAMADA_FUNCION);
			_t = _t.getFirstChild();
			id = _t;
			AST id_AST_in = null;
			id_AST = astFactory.create(id);
			astFactory.addASTChild(ref currentAST, id_AST);
			match(_t,IDENT);
			_t = _t.getNextSibling();
			{
				if (null == _t)
					_t = ASTNULL;
				switch ( _t.Type )
				{
				case LISTA_ARGUMENTOS:
				{
					listaArgumentos(_t);
					_t = retTree_;
					astFactory.addASTChild(ref currentAST, returnAST);
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
			currentAST = __currentAST79;
			_t = __t79;
			_t = _t.getNextSibling();
			llamadaFuncion_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = llamadaFuncion_AST;
		retTree_ = _t;
	}
	
	public void listaArgumentos(AST _t) //throws RecognitionException
{
		
		AST listaArgumentos_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST listaArgumentos_AST = null;
		
		try {      // for error handling
			AST __t85 = _t;
			AST tmp35_AST = null;
			AST tmp35_AST_in = null;
			tmp35_AST = astFactory.create(_t);
			tmp35_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp35_AST);
			ASTPair __currentAST85 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,LISTA_ARGUMENTOS);
			_t = _t.getFirstChild();
			{ // ( ... )+
				int _cnt87=0;
				for (;;)
				{
					if (_t == null)
						_t = ASTNULL;
					if ((tokenSet_1_.member(_t.Type)))
					{
						argType(_t);
						_t = retTree_;
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					else
					{
						if (_cnt87 >= 1) { goto _loop87_breakloop; } else { throw new NoViableAltException(_t);; }
					}
					
					_cnt87++;
				}
_loop87_breakloop:				;
			}    // ( ... )+
			currentAST = __currentAST85;
			_t = __t85;
			_t = _t.getNextSibling();
			listaArgumentos_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = listaArgumentos_AST;
		retTree_ = _t;
	}
	
	public void argType(AST _t) //throws RecognitionException
{
		
		AST argType_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST argType_AST = null;
		AST id2 = null;
		AST id2_AST = null;
		
		try {      // for error handling
			if (null == _t)
				_t = ASTNULL;
			switch ( _t.Type )
			{
			case IDENT:
			{
				id2 = _t;
				AST id2_AST_in = null;
				id2_AST = astFactory.create(id2);
				astFactory.addASTChild(ref currentAST, id2_AST);
				match(_t,IDENT);
				_t = _t.getNextSibling();
				argType_AST = currentAST.root;
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
						AST tmp36_AST = null;
						AST tmp36_AST_in = null;
						tmp36_AST = astFactory.create(_t);
						tmp36_AST_in = _t;
						astFactory.addASTChild(ref currentAST, tmp36_AST);
						match(_t,LIT_ENTERO);
						_t = _t.getNextSibling();
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
								AST tmp37_AST = null;
								AST tmp37_AST_in = null;
								tmp37_AST = astFactory.create(_t);
								tmp37_AST_in = _t;
								astFactory.addASTChild(ref currentAST, tmp37_AST);
								match(_t,LIT_REAL);
								_t = _t.getNextSibling();
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
									case LIT_CHAR:
									{
										AST tmp38_AST = null;
										AST tmp38_AST_in = null;
										tmp38_AST = astFactory.create(_t);
										tmp38_AST_in = _t;
										astFactory.addASTChild(ref currentAST, tmp38_AST);
										match(_t,LIT_CHAR);
										_t = _t.getNextSibling();
										break;
									}
									case LIT_CIERTO:
									case LIT_FALSO:
									case LIT_CADENA:
									{
										{
											if (null == _t)
												_t = ASTNULL;
											switch ( _t.Type )
											{
											case LIT_CIERTO:
											{
												AST tmp39_AST = null;
												AST tmp39_AST_in = null;
												tmp39_AST = astFactory.create(_t);
												tmp39_AST_in = _t;
												astFactory.addASTChild(ref currentAST, tmp39_AST);
												match(_t,LIT_CIERTO);
												_t = _t.getNextSibling();
												break;
											}
											case LIT_FALSO:
											case LIT_CADENA:
											{
												{
													if (null == _t)
														_t = ASTNULL;
													switch ( _t.Type )
													{
													case LIT_FALSO:
													{
														AST tmp40_AST = null;
														AST tmp40_AST_in = null;
														tmp40_AST = astFactory.create(_t);
														tmp40_AST_in = _t;
														astFactory.addASTChild(ref currentAST, tmp40_AST);
														match(_t,LIT_FALSO);
														_t = _t.getNextSibling();
														break;
													}
													case LIT_CADENA:
													{
														{
															AST tmp41_AST = null;
															AST tmp41_AST_in = null;
															tmp41_AST = astFactory.create(_t);
															tmp41_AST_in = _t;
															astFactory.addASTChild(ref currentAST, tmp41_AST);
															match(_t,LIT_CADENA);
															_t = _t.getNextSibling();
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
				argType_AST = currentAST.root;
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
		returnAST = argType_AST;
		retTree_ = _t;
	}
	
	public void condicional(AST _t) //throws RecognitionException
{
		
		AST condicional_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST condicional_AST = null;
		AST a_AST = null;
		AST a = null;
		
		try {      // for error handling
			
			ArrayList lexpresiones = new ArrayList();
			
			AST __t97 = _t;
			AST tmp42_AST = null;
			AST tmp42_AST_in = null;
			tmp42_AST = astFactory.create(_t);
			tmp42_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp42_AST);
			ASTPair __currentAST97 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,RES_IF);
			_t = _t.getFirstChild();
			a = _t==ASTNULL ? null : _t;
			expresion(_t,lexpresiones);
			_t = retTree_;
			a_AST = (AST)returnAST;
			astFactory.addASTChild(ref currentAST, returnAST);
			sentencias(_t);
			_t = retTree_;
			astFactory.addASTChild(ref currentAST, returnAST);
			{
				if (null == _t)
					_t = ASTNULL;
				switch ( _t.Type )
				{
				case RES_ELSE:
				{
					expresionElse(_t);
					_t = retTree_;
					astFactory.addASTChild(ref currentAST, returnAST);
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
			currentAST = __currentAST97;
			_t = __t97;
			_t = _t.getNextSibling();
			
			if (!tcheck.checkBooleanExpresion(lexpresiones))
			err.addError("In IF statement: condition must be a BOOLEAN expression", a.getLine(), a.getColumn());
			
			condicional_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = condicional_AST;
		retTree_ = _t;
	}
	
	public void bucle(AST _t) //throws RecognitionException
{
		
		AST bucle_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST bucle_AST = null;
		
		try {      // for error handling
			if (null == _t)
				_t = ASTNULL;
			switch ( _t.Type )
			{
			case RES_FOR:
			{
				efor(_t);
				_t = retTree_;
				astFactory.addASTChild(ref currentAST, returnAST);
				bucle_AST = currentAST.root;
				break;
			}
			case RES_WHILE:
			{
				ewhile(_t);
				_t = retTree_;
				astFactory.addASTChild(ref currentAST, returnAST);
				bucle_AST = currentAST.root;
				break;
			}
			case RES_REPEAT:
			{
				erepeat(_t);
				_t = retTree_;
				astFactory.addASTChild(ref currentAST, returnAST);
				bucle_AST = currentAST.root;
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
		returnAST = bucle_AST;
		retTree_ = _t;
	}
	
	public void expresionElse(AST _t) //throws RecognitionException
{
		
		AST expresionElse_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST expresionElse_AST = null;
		
		try {      // for error handling
			AST __t100 = _t;
			AST tmp43_AST = null;
			AST tmp43_AST_in = null;
			tmp43_AST = astFactory.create(_t);
			tmp43_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp43_AST);
			ASTPair __currentAST100 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,RES_ELSE);
			_t = _t.getFirstChild();
			sentencias(_t);
			_t = retTree_;
			astFactory.addASTChild(ref currentAST, returnAST);
			currentAST = __currentAST100;
			_t = __t100;
			_t = _t.getNextSibling();
			expresionElse_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = expresionElse_AST;
		retTree_ = _t;
	}
	
	public void efor(AST _t) //throws RecognitionException
{
		
		AST efor_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST efor_AST = null;
		AST id = null;
		AST id_AST = null;
		
		try {      // for error handling
			
			Symbol s = null;
			
			AST __t103 = _t;
			AST tmp44_AST = null;
			AST tmp44_AST_in = null;
			tmp44_AST = astFactory.create(_t);
			tmp44_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp44_AST);
			ASTPair __currentAST103 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,RES_FOR);
			_t = _t.getFirstChild();
			id = _t;
			AST id_AST_in = null;
			id_AST = astFactory.create(id);
			astFactory.addASTChild(ref currentAST, id_AST);
			match(_t,IDENT);
			_t = _t.getNextSibling();
			
			if (scope == 0)
			{
			try 
			{
			s = symtab.find(id.getText());
			} catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
			}
			else
			{
			try 
			{
			s = symtab.findInAllScopes(proc_actual, id.getText());
			} catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
			}
			
			listaFor(_t,s);
			_t = retTree_;
			astFactory.addASTChild(ref currentAST, returnAST);
			sentencias(_t);
			_t = retTree_;
			astFactory.addASTChild(ref currentAST, returnAST);
			currentAST = __currentAST103;
			_t = __t103;
			_t = _t.getNextSibling();
			efor_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = efor_AST;
		retTree_ = _t;
	}
	
	public void ewhile(AST _t) //throws RecognitionException
{
		
		AST ewhile_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST ewhile_AST = null;
		AST a_AST = null;
		AST a = null;
		
		try {      // for error handling
			
			ArrayList lexpresiones = new ArrayList();
			
			AST __t108 = _t;
			AST tmp45_AST = null;
			AST tmp45_AST_in = null;
			tmp45_AST = astFactory.create(_t);
			tmp45_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp45_AST);
			ASTPair __currentAST108 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,RES_WHILE);
			_t = _t.getFirstChild();
			a = _t==ASTNULL ? null : _t;
			expresion(_t,lexpresiones);
			_t = retTree_;
			a_AST = (AST)returnAST;
			astFactory.addASTChild(ref currentAST, returnAST);
			sentencias(_t);
			_t = retTree_;
			astFactory.addASTChild(ref currentAST, returnAST);
			currentAST = __currentAST108;
			_t = __t108;
			_t = _t.getNextSibling();
			
			if (!tcheck.checkBooleanExpresion(lexpresiones))
			err.addError("In WHILE statement: condition must be a BOOLEAN expression", a.getLine(), a.getColumn());
			
			ewhile_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = ewhile_AST;
		retTree_ = _t;
	}
	
	public void erepeat(AST _t) //throws RecognitionException
{
		
		AST erepeat_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST erepeat_AST = null;
		AST a_AST = null;
		AST a = null;
		
		try {      // for error handling
			
			ArrayList lexpresiones = new ArrayList();
			
			AST __t110 = _t;
			AST tmp46_AST = null;
			AST tmp46_AST_in = null;
			tmp46_AST = astFactory.create(_t);
			tmp46_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp46_AST);
			ASTPair __currentAST110 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,RES_REPEAT);
			_t = _t.getFirstChild();
			sentencias(_t);
			_t = retTree_;
			astFactory.addASTChild(ref currentAST, returnAST);
			a = _t==ASTNULL ? null : _t;
			expresion(_t,lexpresiones);
			_t = retTree_;
			a_AST = (AST)returnAST;
			astFactory.addASTChild(ref currentAST, returnAST);
			currentAST = __currentAST110;
			_t = __t110;
			_t = _t.getNextSibling();
			
			if (!tcheck.checkBooleanExpresion(lexpresiones))
			err.addError("In REPEAT statement: condition must be a BOOLEAN expression", a.getLine(), a.getColumn());
			
			erepeat_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = erepeat_AST;
		retTree_ = _t;
	}
	
	public void listaFor(AST _t,
		Symbol s
	) //throws RecognitionException
{
		
		AST listaFor_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST listaFor_AST = null;
		
		try {      // for error handling
			
			Symbol ini;
			Symbol fin;
			int line = 0;
			int col = 0;
			
			AST __t105 = _t;
			AST tmp47_AST = null;
			AST tmp47_AST_in = null;
			tmp47_AST = astFactory.create(_t);
			tmp47_AST_in = _t;
			astFactory.addASTChild(ref currentAST, tmp47_AST);
			ASTPair __currentAST105 = currentAST.copy();
			currentAST.root = currentAST.child;
			currentAST.child = null;
			match(_t,RES_TO);
			_t = _t.getFirstChild();
			ini=valor_for(_t,ref line, ref col);
			_t = retTree_;
			astFactory.addASTChild(ref currentAST, returnAST);
			fin=valor_for(_t,ref line, ref col);
			_t = retTree_;
			astFactory.addASTChild(ref currentAST, returnAST);
			currentAST = __currentAST105;
			_t = __t105;
			_t = _t.getNextSibling();
			
			if (s != null && ini != null && fin != null)
			{
			string ini_type = ini.Type.toString();
			string fin_type = fin.Type.toString();
			string control_var = s.Type.toString();
			if (ini_type != "INT")
			err.addError("In for statement: Variable '" + ini.Name + "' has to be INTEGER but founded " + ini_type,
			line, col);
			if ( fin_type != "INT")
			err.addError("In for statement: Variable '" + fin.Name + "' has to be INTEGER but founded " + fin_type,
			line, col);
			if ( control_var != "INT")
			err.addError("In for statement: Variable '" + s.Name + "' has to be INTEGER but founded " + control_var,
			line, col);
			}
			
			listaFor_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			reportError(ex);
			if (null != _t)
			{
				_t = _t.getNextSibling();
			}
		}
		returnAST = listaFor_AST;
		retTree_ = _t;
	}
	
	public Symbol  valor_for(AST _t,
		ref int line, ref int col
	) //throws RecognitionException
{
		Symbol x;
		
		AST valor_for_AST_in = (AST)_t;
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST valor_for_AST = null;
		AST id = null;
		AST id_AST = null;
		AST lit = null;
		AST lit_AST = null;
		
		x = null;
		
		
		try {      // for error handling
			if (null == _t)
				_t = ASTNULL;
			switch ( _t.Type )
			{
			case IDENT:
			{
				id = _t;
				AST id_AST_in = null;
				id_AST = astFactory.create(id);
				astFactory.addASTChild(ref currentAST, id_AST);
				match(_t,IDENT);
				_t = _t.getNextSibling();
				
				if (scope == 0)
				{
				try {
				x = symtab.find(id.getText());
				} catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
				} 
				else
				{
				try {
				x = symtab.findInAllScopes(proc_actual, id.getText());
				} catch (fpc2ilException e) { err.addError(e.Message, id.getLine(), id.getColumn()); }
				}
				
				line = id.getLine();
				col = id.getColumn();
				
				valor_for_AST = currentAST.root;
				break;
			}
			case LIT_ENTERO:
			{
				lit = _t;
				AST lit_AST_in = null;
				lit_AST = astFactory.create(lit);
				astFactory.addASTChild(ref currentAST, lit_AST);
				match(_t,LIT_ENTERO);
				_t = _t.getNextSibling();
				
				x = new Symbol(lit.getText(), new Type());
				x.Type = new Type (Type.T.INT,0,null);
				line = lit.getLine();
				col = lit.getColumn();
				
				valor_for_AST = currentAST.root;
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
		returnAST = valor_for_AST;
		retTree_ = _t;
		return x;
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

