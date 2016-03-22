program PruebaDeFactorial;

var numero: integer;
var f : integer;

function factorial( num : integer) : integer;
var aux: integer;
var aux2: integer;
begin
  if num = 0 then
  begin
    factorial := 1        
  end
  else
  begin
    aux:= num - 1;
    aux2:= factorial(aux);
    factorial := num * aux2;       
  end;
end;

begin
  numero:=6;
  f:= factorial(numero);
  writeln('Su factorial es ', f);
end. 


