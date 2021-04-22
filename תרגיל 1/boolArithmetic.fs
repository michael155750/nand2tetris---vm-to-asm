
[<AutoOpen>]
module boolArithmetic

open System.IO

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

