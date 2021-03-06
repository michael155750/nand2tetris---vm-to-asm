[<AutoOpen>]
module pushFuncs

open System.IO

let private PushConstFunc (arg:int) path2 = 
    File.AppendAllText(path2, "@" + arg.ToString() + "\n")|>ignore
    File.AppendAllText(path2, "D=A\n")|>ignore
    File.AppendAllText(path2, "@0\n")|>ignore
    File.AppendAllText(path2, "A=M\n")|>ignore
    File.AppendAllText(path2, "M=D\n")|>ignore
    StackFront path2

let private PushElseFunc seg arg path2 = 
    let mutable adr:int = 0
    match seg with
    |"local" -> (adr <- 1)
    |"argument" -> (adr <- 2)
    |"this" -> (adr <- 3)
    |"that"-> (adr <- 4)
    |_ -> ()
    if adr > 0 then
        File.AppendAllText(path2, "@" + arg.ToString() + "\n")|>ignore
        File.AppendAllText(path2, "D=A\n")|>ignore
        File.AppendAllText(path2, "@" + adr.ToString() + "\n")|>ignore
        File.AppendAllText(path2, "A=M+D\n")|>ignore
        File.AppendAllText(path2, "D=M\n")|>ignore
        File.AppendAllText(path2, "@0\n")|>ignore
        File.AppendAllText(path2, "A=M\n")|>ignore
        File.AppendAllText(path2, "M=D\n")|>ignore
        StackFront path2

//push to the pointers and temp values, also use for push
//LCL and ARG pointers (internal use of the compiler)
let private PushTPFunc (arg) path2 = 
    File.AppendAllText(path2, "@" + arg.ToString() + "\n")|>ignore
    File.AppendAllText(path2, "D=M\n")|>ignore
    File.AppendAllText(path2, "@0\n")|>ignore
    File.AppendAllText(path2, "A=M\n")|>ignore
    File.AppendAllText(path2, "M=D\n")|>ignore
    StackFront path2

let private PushStatFunc arg fileName path2 = 
    File.AppendAllText(path2, "@" + fileName + arg.ToString() + "\n")|>ignore
    File.AppendAllText(path2, "D=M\n")|>ignore
    File.AppendAllText(path2, "@0\n")|>ignore
    File.AppendAllText(path2, "A=M\n")|>ignore
    File.AppendAllText(path2, "M=D\n")|>ignore
    StackFront path2

let PushFunc (seg) (arg:int) (fileName) path2 = 
    match seg with
    |"constant" -> PushConstFunc arg path2
    |"temp" -> PushTPFunc (5 + arg) path2
    |"pointer" -> PushTPFunc (3 + arg) path2
    //LCL and ARG are internal use of the compiler for the pointers
    |"LCL"-> PushTPFunc (1) path2
    |"ARG"-> PushTPFunc (2) path2
    |"static" ->  PushStatFunc arg fileName path2
    |_ -> PushElseFunc seg arg path2