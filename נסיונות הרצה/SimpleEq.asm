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
D=D-M
@IF_TRUE0
D;JEQ
D=0
@IF_FALSE0
0;JMP
(IF_TRUE0)
D=-1
(IF_FALSE0)
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
D=D-M
@IF_TRUE1
D;JEQ
D=0
@IF_FALSE1
0;JMP
(IF_TRUE1)
D=-1
(IF_FALSE1)
@0
A=M-1
A=A-1
M=D
@0
M=M-1
