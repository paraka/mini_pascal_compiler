program Fibonacci;

var Fibonacci1: integer;
var Fibonacci2 : integer;
var temp : integer;
var count : integer;

begin   
writeln ('First ten Fibonacci numbers are:');
count := 0;
Fibonacci1 := 0;
Fibonacci2 := 1;
while count < 10 do
begin
    writeln (Fibonacci2);
    temp := Fibonacci2;
    Fibonacci2 := Fibonacci1 + Fibonacci2;
    Fibonacci1 := temp;
    count := count + 1
end;
end.
