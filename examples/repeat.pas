program repeats;
var a:integer;
var b:integer;
var c: boolean;
begin
    a:=5;
    b:=3;
    c:=true;
    repeat
    begin
        writeln('A = 4 AND b = 4');
    end;
    until a = 4 and c;
end.
