export CLASSPATH=antlr/antlr-2.7.7.jar
java antlr.Tool fpc2ilLexer.g
java antlr.Tool fpc2ilParser.g
java antlr.Tool fpc2ilTreeParser.g
java antlr.Tool fpc2ilCodeGenerator.g
gmcs *.cs /out:fpc2ILCompiler.exe /r:net-2.0/antlr.runtime.dll /r:net-2.0/antlr.astframe.dll /r:net-2.0/UiaAtkBridge.dll /warn:0
