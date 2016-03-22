program ifs;
var a:integer;
var b:integer;
var c: boolean;
begin
    a:=5;
    b:=3;
    c:=false;
    writeln('Valores que usaremos: ');
    writeln('a: ', a);
    writeln('b: ', b);
    writeln('c: ', c);
    if a > 4 or b < 2 then
    begin
        writeln('a > 4 OR b < 2');
    end
    else 
    begin
        writeln('ELSE a > 4 OR b < 2');
    end;
    if a = 4 and not c then
    begin
        writeln('a = 4 AND not c');
    end;
    if not c and a = 5 then
    begin
        writeln('not c AND a = 5');
    end;
    if a = 4 or not c then
    begin
        writeln('a = 4 OR not c');
    end;
    if not c or a = 5 then
    begin
        writeln('not c OR a = 5');
    end;
    if a = 4 or a = 3 then
    begin
        writeln('a = 4 OR a = 3');
    end
    else
    begin
        writeln('ELSE: a = 4 OR a = 3');
    end;
    if not c then
    begin
        writeln('if not c');
    end
    else
    begin
        writeln('ELSE not c');
    end;
    if c then
    begin
        writeln('if c');
    end
    else
    begin
        writeln('ELSE c');
    end;
    if a = 4 and b = 4 then
    begin
        writeln('A = 4 AND b = 4');
    end
    else
    begin
        writeln('ELSE a = 4 OR b = 4');
    end;
end.
