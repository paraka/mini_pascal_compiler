program globales;

var 
c:char;
var
variable: integer;
variable2: real; 
var3: boolean;
s:string;

const foo = 23;
foo2 = 23.6;
foo3 = false;
foo4 = 'cadenita';
foo5 = 'f';

procedure globales;
begin
variable:=3;
variable2:=5.5;
s:='mierda';
var3:=true;
end;

procedure showConstants;
begin
    writeln(foo,foo2,foo3,foo4);
end;

begin
    globales;
    writeln(variable, variable2, s, var3);
    c:='d';
    writeln('caracter: ', c);
    writeln('caracter: ', foo5);
    showConstants;
end.
