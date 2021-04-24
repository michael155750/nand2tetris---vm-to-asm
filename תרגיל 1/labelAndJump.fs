[<AutoOpen>]
module labelAndJump

open System.IO

let LabelFunc name fileName path = 
    File.AppendAllText(path, "(" + fileName + "." + name + ")\n")|>ignore

let GotoFunc name fileName path = 
    File.AppendAllText(path, "@" + fileName + "." + name + "\n")|>ignore 
    File.AppendAllText(path, "0; JMP\n")|>ignore

let IfgotoFunc name fileName path = 
    File.AppendAllText(path, "@0\n")
    StackBack path
    File.AppendAllText(path, "A=M\n")
    File.AppendAllText(path, "D=M\n")
    File.AppendAllText(path, "@" + fileName + "." + name + "\n")|>ignore 
    File.AppendAllText(path, "D;JNE\n")