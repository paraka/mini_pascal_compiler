program impares;

var i: integer;
var x: integer;
    
begin
    i := 0;
    while i <= 10 do 
    begin
          x := i mod 2;
          if x = 1 then
                writeln (i, ' is an odd number');
          i := i + 1
    end
end.
