program operaciones_reales;
var op1: real;
var op2: real;
var res_real: real;

function Suma (a: real; b:real): real;
begin
Suma:=a+b;
end;

function Resta (a: real; b:real): real;
begin
Resta:=a-b;
end;

function Mul (a: real; b:real): real;
begin
Mul:=a*b;
end;

function Division (a: real; b:real): real;
begin
Division:=a/b;
end;


begin
op1:=5.1;
op2:=2.1;
res_real:=Suma(op1,op2);
writeln('SUMA', res_real);
res_real:=Resta(op1,op2);
writeln('RESTA', res_real);
res_real:=Mul(op1,op2);
writeln('MUL', res_real);
res_real:=Division(op1,op2);
writeln('DIV', res_real);
end.
