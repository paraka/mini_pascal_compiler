{ mierda }
program foo;
const perico = 'Palote'; 
var variable: integer;
var var3: string;
var x: real;

procedure proc2 (b: integer; a: real;c: string);
var x: integer;
begin
for x := 1 to 25 do
begin
writeln('procedure 2');
end;
end;

procedure proc1;
var foo: boolean;
begin
writeln('proc1');
proc2(variable, 3.5, perico);
end;


function fun1 (x: real; y:integer): real;
var c: boolean;
var co:boolean;
begin
co:=true;
proc2(y,5.6,'perro');
writeln('fun1');
fun1:=3.5;
end;

function fun2: string;
var pe : string;
var x: integer;
begin
   proc2(x,3.5,'hola');
   pe:= fun2;
   repeat
   begin
    writeln('func2');
    x := 4;
   end;
   until x < 1;
   fun2:=pe;
end;

begin
   proc2(1,3.5,'hola');
   x:= fun1(1.5, variable);
   x:= fun1(1.5,1);
   {variable := fun2;}
end.
