program whiles;
var a:integer;
var b:integer;
var c: boolean;
begin
    a:=5;
    b:=3;
    c:=false;
    while false and a = 5 do
    begin
        writeln('A = 4 AND b = 4');
    end;
    while a = 5 and false do
    begin
        writeln('2 while');
    end;
    while a = 5 and not c do
    begin
        writeln('3 while');
    end;
end.
