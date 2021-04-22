[<AutoOpen>]
module popFuncs

open System.IO

//pop
let PopTPFunc arg path2 = 
    File.AppendAllText(path2, "@0\n")|>ignore
    File.AppendAllText(path2, "A=M-1\n")|>ignore
    File.AppendAllText(path2, "D=M\n")|>ignore
    File.AppendAllText(path2, "@" + arg.ToString() + "\n")|>ignore
    File.AppendAllText(path2, "M=D\n")|>ignore
    StackBack path2

let PopStatFunc arg fileName path2 =
    File.AppendAllText(path2, "@0\n")|>ignore
    File.AppendAllText(path2, "A=M-1\n")|>ignore
    File.AppendAllText(path2, "D=M\n")|>ignore
    File.AppendAllText(path2, "@" + fileName + arg.ToString() + "\n")|>ignore
    File.AppendAllText(path2, "M=D\n")|>ignore
    StackBack path2

let PopElseFunc seg arg path2 = 
    let mutable adr:int = 0
    match seg with
    |"local" -> (adr <- 1)
    |"argument" -> (adr <- 2)
    |"this" -> (adr <- 3)
    |"that"-> (adr <- 4)
    |_ -> ()
    if adr > 0 then
        File.AppendAllText(path2, "@0\n")|>ignore
        File.AppendAllText(path2, "A=M-1\n")|>ignore
        File.AppendAllText(path2, "D=M\n")|>ignore
        File.AppendAllText(path2, "@" + adr.ToString() + "\n")|>ignore
        File.AppendAllText(path2, "A=M\n")|>ignore
        for i = 1 to arg do
            File.AppendAllText(path2, "A=A+1\n")|>ignore
        File.AppendAllText(path2, "M=D\n")|>ignore
        StackBack path2

let PopFunc (seg) (arg:int) (fileName) path2 :unit = 
    match seg with
    |"temp" -> PopTPFunc (5 + arg) path2
    |"pointer" -> PopTPFunc (3 + arg) path2
    |"static" ->  PopStatFunc arg fileName path2
    |_ -> PopElseFunc seg arg path2