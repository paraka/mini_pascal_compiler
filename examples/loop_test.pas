program TestLoop;              {Program specification}
var x: integer;            {Declare variables x,y as integer}
var y: integer;            {Declare variables x,y as integer}

procedure Loop(x:integer; y: integer); {Function specification: inputs}
var i: integer;            {Declare loop index}
begin                      {Function begins here}

for i := x to y do       {Loop specification}
writeln('i = ', i);    {Loop contents or body}
end;                       {Function ends here}

begin                        {Program begins here}
x := 4;                    {Assign starting loop index value}
y := 7;                    {Assign ending loop index value}
Loop(x,y);                 {Call to procedure "Loop"}
end.                         {Program ends here}
