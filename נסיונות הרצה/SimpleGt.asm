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
@IF_TRUE2
D;JGT
D=0
@IF_FALSE2
0;JMP
(IF_TRUE2)
D=-1
(IF_FALSE2)
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
@IF_TRUE3
D;JGT
D=0
@IF_FALSE3
0;JMP
(IF_TRUE3)
D=-1
(IF_FALSE3)
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
@IF_TRUE4
D;JGT
D=0
@IF_FALSE4
0;JMP
(IF_TRUE4)
D=-1
(IF_FALSE4)
@0
A=M-1
A=A-1
M=D
@0
M=M-1
