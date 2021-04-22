[<AutoOpen>]
module basicArithmetic


open System.IO

//arithmetic
let AddFunc path2= 
    ReadTwoOp path2
    File.AppendAllText(path2, "M=D+M\n")|>ignore
    StackBack path2

let SubFunc path2 = 
    ReadTwoOp path2
    File.AppendAllText(path2, "D=M-D\n")|>ignore
    File.AppendAllText(path2, "M=D\n")|>ignore
    StackBack path2

let OrFunc path2 = 
    ReadTwoOp path2
    File.AppendAllText(path2, "M=D|M\n")|>ignore
    StackBack path2

let AndFunc path2 = 
    ReadTwoOp path2
    File.AppendAllText(path2, "M=D&M\n")|>ignore
    StackBack path2

let NegFunc path2 = 
    File.AppendAllText(path2, "@0\n")|>ignore
    File.AppendAllText(path2, "A=M-1\n")|>ignore
    File.AppendAllText(path2, "D= -M\n")|>ignore
    File.AppendAllText(path2, "M=D\n")|>ignore

let NotFunc path2 = 
    File.AppendAllText(path2, "@0\n")|>ignore
    File.AppendAllText(path2, "A=M-1\n")|>ignore
    File.AppendAllText(path2, "D= !M\n")|>ignore
    File.AppendAllText(path2, "M=D\n")|>ignore