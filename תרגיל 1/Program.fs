// Learn more about F# at http://fsharp.org

open System
open System.IO


    let ReadTwoOp path2 = 
        File.AppendAllText(path2, "@0\n")|>ignore
        File.AppendAllText(path2, "A=M-1\n")|>ignore
        File.AppendAllText(path2, "D=M\n")|>ignore
        File.AppendAllText(path2, "A=A-1\n")|>ignore

    let StackBack path2 = 
        File.AppendAllText(path2, "@0\n")|>ignore
        File.AppendAllText(path2, "M=M-1\n")|>ignore

    let StackFront path2 = 
        File.AppendAllText(path2, "@0\n")|>ignore
        File.AppendAllText(path2, "M=M+1\n")|>ignore

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

    //counters for labels names
    let mutable ifTrueCounter = 0
    let mutable ifFalseCounter = 0
    
    
    let EqFunc path2 = 
        ReadTwoOp path2
        File.AppendAllText(path2, "D=D-M\n")|>ignore
        File.AppendAllText(path2, "@IF_TRUE" + ifTrueCounter.ToString() + "\n")|>ignore
        File.AppendAllText(path2, "D;JEQ\n")|>ignore
        File.AppendAllText(path2, "D=0\n")|>ignore
        File.AppendAllText(path2, "@IF_FALSE" + ifFalseCounter.ToString() + "\n")|>ignore
        File.AppendAllText(path2, "0;JMP\n")|>ignore
        File.AppendAllText(path2, "(IF_TRUE" + ifTrueCounter.ToString() + ")\n")|>ignore
        File.AppendAllText(path2, "D=-1\n")|>ignore
        File.AppendAllText(path2, "(IF_FALSE" + ifFalseCounter.ToString() + ")\n")|>ignore
        File.AppendAllText(path2, "@0\n")|>ignore
        File.AppendAllText(path2, "A=M-1\n")|>ignore
        File.AppendAllText(path2, "A=A-1\n")|>ignore
        File.AppendAllText(path2, "M=D\n")|>ignore
        StackBack path2
        ifTrueCounter <- ifTrueCounter + 1
        ifFalseCounter <- ifFalseCounter + 1
    
    let GtFunc path2= 
        ReadTwoOp path2
        File.AppendAllText(path2, "D=M-D\n")|>ignore
        File.AppendAllText(path2, "@IF_TRUE" + ifTrueCounter.ToString() + "\n")|>ignore
        File.AppendAllText(path2, "D;JGT\n")|>ignore
        File.AppendAllText(path2, "D=0\n")|>ignore
        File.AppendAllText(path2, "@IF_FALSE" + ifFalseCounter.ToString() + "\n")|>ignore
        File.AppendAllText(path2, "0;JMP\n")|>ignore
        File.AppendAllText(path2, "(IF_TRUE" + ifTrueCounter.ToString() + ")\n")|>ignore
        File.AppendAllText(path2, "D=-1\n")|>ignore
        File.AppendAllText(path2, "(IF_FALSE" + ifFalseCounter.ToString() + ")\n")|>ignore
        File.AppendAllText(path2, "@0\n")|>ignore
        File.AppendAllText(path2, "A=M-1\n")|>ignore
        File.AppendAllText(path2, "A=A-1\n")|>ignore
        File.AppendAllText(path2, "M=D\n")|>ignore
        StackBack path2
        ifTrueCounter <- ifTrueCounter + 1
        ifFalseCounter <- ifFalseCounter + 1

    let LtFunc path2= 
        ReadTwoOp path2
        File.AppendAllText(path2, "D=M-D\n")|>ignore
        File.AppendAllText(path2, "@IF_TRUE" + ifTrueCounter.ToString() + "\n")|>ignore
        File.AppendAllText(path2, "D;JLT\n")|>ignore
        File.AppendAllText(path2, "D=0\n")|>ignore
        File.AppendAllText(path2, "@IF_FALSE" + ifFalseCounter.ToString() + "\n")|>ignore
        File.AppendAllText(path2, "0;JMP\n")|>ignore
        File.AppendAllText(path2, "(IF_TRUE" + ifTrueCounter.ToString() + ")\n")|>ignore
        File.AppendAllText(path2, "D=-1\n")|>ignore
        File.AppendAllText(path2, "(IF_FALSE" + ifFalseCounter.ToString() + ")\n")|>ignore
        File.AppendAllText(path2, "@0\n")|>ignore
        File.AppendAllText(path2, "A=M-1\n")|>ignore
        File.AppendAllText(path2, "A=A-1\n")|>ignore
        File.AppendAllText(path2, "M=D\n")|>ignore
        StackBack path2
        ifTrueCounter <- ifTrueCounter + 1
        ifFalseCounter <- ifFalseCounter + 1
       
       //push
    let PushConstFunc (arg:int) path2 = 
        File.AppendAllText(path2, "@" + arg.ToString() + "\n")|>ignore
        File.AppendAllText(path2, "D=A\n")|>ignore
        File.AppendAllText(path2, "@0\n")|>ignore
        File.AppendAllText(path2, "A=M\n")|>ignore
        File.AppendAllText(path2, "M=D\n")|>ignore
        StackFront path2
    
    let PushElseFunc seg arg path2 = 
        let mutable adr:int = 0
        match seg with
        |"local" -> (adr <- 1)
        |"argument" -> (adr <- 2)
        |"this" -> (adr <- 3)
        |"that"-> (adr <- 4)

        File.AppendAllText(path2, "@" + arg.ToString() + "\n")|>ignore
        File.AppendAllText(path2, "@D=A\n")|>ignore
        File.AppendAllText(path2, "@" + adr.ToString() + "\n")|>ignore
        File.AppendAllText(path2, "A=M+D\n")|>ignore
        File.AppendAllText(path2, "D=M\n")|>ignore
        File.AppendAllText(path2, "@0\n")|>ignore
        File.AppendAllText(path2, "A=M\n")|>ignore
        File.AppendAllText(path2, "M=D\n")|>ignore
        StackFront path2
    
    let PushTPFunc (arg) path2 = 
        File.AppendAllText(path2, "@" + arg.ToString() + "\n")|>ignore
        File.AppendAllText(path2, "D=M\n")|>ignore
        File.AppendAllText(path2, "@0\n")|>ignore
        File.AppendAllText(path2, "A=M\n")|>ignore
        File.AppendAllText(path2, "M=D\n")|>ignore
        StackFront path2
    
    let PushStatFunc arg fileName path2 = 
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
        |"static" ->  PushStatFunc arg fileName path2
        |_ -> PushElseFunc seg arg path2
    
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

[<EntryPoint>]
let main argv =
    let path = Console.ReadLine()
    let filesList = Directory.GetFiles(path,"*.vm")
    
    for file in filesList do
        let fileLines = File.ReadLines(file)
        let path2 = Path.ChangeExtension(file,".asm") 
        if File.Exists(path2) then
            File.Delete(path2)
        for line in fileLines do
            
            match line.Split(" ").[0] with
            |"add" -> AddFunc path2
            |"sub" -> SubFunc path2
            |"neg" -> NegFunc path2
            |"and" -> AndFunc path2
            |"or" -> OrFunc path2
            |"not" -> NotFunc path2
            |"eq" -> EqFunc path2
            |"gt" -> GtFunc path2
            |"lt" -> LtFunc path2
            |"push" -> 
                PushFunc (line.Split(" ").[1]) (line.Split(" ").[2]|>int) (Path.GetFileNameWithoutExtension(file)) path2
            |"pop" ->
                PopFunc (line.Split(" ").[1]) (line.Split(" ").[2]|>int) (Path.GetFileNameWithoutExtension(file)) path2
            |_ -> ()
            

    0 // return an integer exit code
