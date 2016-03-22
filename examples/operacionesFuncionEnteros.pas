program operaciones_enteros;
var res_entero:integer;
var res_real: real;

function Suma (a: integer; b:integer): integer;
begin
Suma:=a+b;
end;

function Resta (a: integer; b:integer): integer;
begin
Resta:=a-b;
end;

function Mul (a: integer; b:integer): integer;
begin
Mul:=a*b;
end;

function Division (a: integer; b:integer): integer;
begin
Division:=a div b;
end;

function Modulo (a: integer; b:integer): integer;
begin
Modulo:=a mod b;
end;


begin
res_entero:=Suma(5,4);
writeln('SUMA', res_entero);
res_entero:=Resta(5,4);
writeln('RESTA', res_entero);
res_entero:=Mul(5,4);
writeln('MUL', res_entero);
res_entero:=Division(5,4);
writeln('DIV', res_entero);
res_entero:=Modulo(5,4);
writeln('MOD', res_entero);
end.
