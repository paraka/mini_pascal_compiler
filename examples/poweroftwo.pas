program PowersofTwo;

const numperline = 5;
const maxnum = 20000;
const base = 2;

var number : integer;
var linecount : integer;

begin   
   writeln ('Powers of ', base, ', 1 <= x <= ', maxnum);
   number := 1;
   linecount := 0;
   while number <= maxnum do
      begin
         linecount := linecount + 1;
         if linecount > 1 then
            writeln (number);

         if linecount = numperline then
         begin
               linecount := 0
         end;
         number := number * base;
      end; 
end.
