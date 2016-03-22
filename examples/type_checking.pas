{ mierda }
program type_checking;

var a:integer;
b:integer;
c:integer;
e:integer;
s: string;
d: real;
bol: boolean;
caracter: char;

const 
    f = 'hola';
    caracter2 = 'd';

procedure Co;
begin
writeln('No hago nada');
end;

function funcion (a: integer): integer;
begin
funcion:=3.5;{no ok}
end;

begin
caracter := caracter2;{ok}
caracter := 5;
a:=4+5+3-4+a-4.5+4-4-7;{no ok 4.5 es real}
b:=a*c+d;{no ok d es real}
bol:=true;{ok}
d:= 4+3.5;{ok}
d:='hola'+4;{no ok}
bol:= 4 div 2; {no ok}
a:= 4 mod 2; {ok}
a:= 3 / 5 * 4 + 4 - 2;{ok}
a:= 3.5 + 4 * 4;{no ok}
a:=4*3.5;{no_ok}
d:=3*3.5;{ok}
d:=3/4.5;{no_ok}
while d = 5 and a > 3 do
begin
    if bol <> true then {deberia fallar en cosas como bool > true, si es bool solo debe ser = ...}
    begin
        d := 3;{ok}
    end
    else
    begin
        d := 2;{ok}
    end;
end;
while d + 4 do {no ok no es bool}
begin
    a:=5;{ok}
end;
repeat 
begin 
    c:= c*2;{ok}
    d:=Co;{no ok un procedimiento no puede asignarse}
end
until x + 3; {no ok x no definido y no es expr booleana}

bol:=funcion(a);{esto fallaria en la pasada de generacion de codigo si se arreglan el resto de errores}

end.
