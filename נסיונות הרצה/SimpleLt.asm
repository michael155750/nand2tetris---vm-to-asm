@7
D=A
@0
A=M
M=D
@0
M=M+1
@8
D=A
@0
A=M
M=D
@0
M=M+1
@0
A=M-1
D=M
A=A-1
D=M-D
@IF_TRUE5
D;JLT
D=0
@IF_FALSE5
0;JMP
(IF_TRUE5)
D=-1
(IF_FALSE5)
@0
A=M-1
A=A-1
M=D
@0
M=M-1
@8
D=A
@0
A=M
M=D
@0
M=M+1
@7
D=A
@0
A=M
M=D
@0
M=M+1
@0
A=M-1
D=M
A=A-1
D=M-D
@IF_TRUE6
D;JLT
D=0
@IF_FALSE6
0;JMP
(IF_TRUE6)
D=-1
(IF_FALSE6)
@0
A=M-1
A=A-1
M=D
@0
M=M-1
@7
D=A
@0
A=M
M=D
@0
M=M+1
@7
D=A
@0
A=M
M=D
@0
M=M+1
@0
A=M-1
D=M
A=A-1
D=M-D
@IF_TRUE7
D;JLT
D=0
@IF_FALSE7
0;JMP
(IF_TRUE7)
D=-1
(IF_FALSE7)
@0
A=M-1
A=A-1
M=D
@0
M=M-1
