[<AutoOpen>]
module baseActions


open System.IO


let ReadTwoOp path2 = 
    File.AppendAllText(path2, "@0
A=M-1
D=M
A=A-1\n")|>ignore
    //File.AppendAllText(path2, "@0\n")|>ignore
    //File.AppendAllText(path2, "A=M-1\n")|>ignore
    //File.AppendAllText(path2, "D=M\n")|>ignore
    //File.AppendAllText(path2, "A=A-1\n")|>ignore

let StackBack path2 = 
    File.AppendAllText(path2, "@0\n")|>ignore
    File.AppendAllText(path2, "M=M-1\n")|>ignore

let StackFront path2 = 
    File.AppendAllText(path2, "@0\n")|>ignore
    File.AppendAllText(path2, "M=M+1\n")|>ignore


