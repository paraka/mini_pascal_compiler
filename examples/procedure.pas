program proc_refs_funcs;

var variable: integer;
variable2: real; 
var3: boolean;
i:integer;
s:string;
c:char;

{constantes}
const foo1 = 3;
foo2 = 32.5;
foo3 = true;
foo4 = 'constante cadena';
foo5 = 'c';

function funcion (a: integer): integer;
var c: integer;
var x: integer;
begin
    x:=1;
    c:=3;
    for c:=1 to 5 do
    begin
    x:=c*x;
    x:=x+1;
    writeln('X vale ',x, 'VAR CONTROL ', c);
    end;
    funcion:=x mod a;
end;

procedure proc3 (var a: string);
var x: integer;
begin
   for x:=1 to 5 do
   begin
   writeln('For dentro de proc: ', x);
   end;
   a:='hola';
end;

procedure proc2 (var a: integer; var b:real; var c: string; var d:boolean; var f:char);
begin
a:=3+5;
b:=15.5+6.4;
c:='Cadena';
d:=false;
f:='l';
end;

procedure verConstantes;
begin
writeln('Constantes definidas:');
writeln(foo1, foo2, foo3, foo4);
writeln(foo5);
end;

procedure globales;
begin
variable:=3;
variable2:=5.5;
s:='mierda';
var3:=true;
c:='f';
end;

begin
   globales;
   writeln(variable, variable2, var3, s);
   writeln(c);
   proc2(variable, variable2, s, var3, c);
   writeln(variable, variable2, var3, s);
   writeln(c);
   variable:= variable + 15;
   variable2:= variable2 * 3.5;
   writeln(variable, variable2);
   for i:=1 to 5 do
   begin
   writeln('For global:', i);
   end;
   proc3(s);
   writeln(s);
   variable:=funcion(3);
   writeln(variable);
   verConstantes;
end.
