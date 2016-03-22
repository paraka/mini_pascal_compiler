program whileifs;
var a:integer;
var b:integer;
var d:integer;
var c: boolean;
begin
    a:=5;
    b:=3;
    d:=3;
    c:=true;
    while (a = 5) and c do
    begin
        if (b = 10) and (d < 5) then
        begin
            c:=false;
        end;
        b:=b+1;
        d:=d-1;
        writeln('C: ', c, ' A: ', a);
        writeln('D: ', d, ' B: ', b);
    end;
end.
