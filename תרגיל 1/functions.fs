[<AutoOpen>]
module functions
open System.IO

let mutable private functionCount = 0
let CallFunc name n fileName path =
    let funcName = name + functionCount.ToString()
    functionCount <- functionCount + 1
    File.AppendAllText(path, "@" + funcName + ".ReturnAddress\n")
    File.AppendAllText(path, "D=A\n")
    File.AppendAllText(path, "@0\n")
    File.AppendAllText(path, "A=M\n")
    File.AppendAllText(path, "M=D\n")
    StackFront path

    PushFunc "LCL" 0  fileName path
    PushFunc "ARG" 0  fileName path
    PushFunc "pointer" 0 fileName path
    PushFunc "pointer" 1 fileName path

    // ARG = SP-n-5 
    File.AppendAllText(path, "@0\n")
    File.AppendAllText(path, "D=M\n")
    let newArg = n + 5
    File.AppendAllText(path, "@" + newArg.ToString() + "\n") 
    File.AppendAllText(path, "D=D-A\n")
    File.AppendAllText(path, "@2\n")
    File.AppendAllText(path, "M=D\n")
    
    // LCL = SP
    File.AppendAllText(path, "@0\n")
    File.AppendAllText(path, "D=M\n")
    File.AppendAllText(path, "@1\n")
    File.AppendAllText(path, "M=D\n")
    
    //goto 
    File.AppendAllText(path, "@" + funcName + "\n")
    File.AppendAllText(path, "0;JMP\n")

    // label return-address
    File.AppendAllText(path, "(" + funcName + ".ReturnAddress)\n")
    
    
let FunctionFunc name k fileName path = 
    File.AppendAllText(path, "(" + name + ")\n")
    File.AppendAllText(path, "@" + k.ToString() + "\n")
    File.AppendAllText(path, "D=A\n")
    File.AppendAllText(path, "@" + name + ".end\n")
    File.AppendAllText(path, "D;JEQ\n")
    File.AppendAllText(path, "(" + name + ".loop)\n")
    File.AppendAllText(path, "@0\n")
    File.AppendAllText(path, "A=M\n")
    File.AppendAllText(path, "M=0\n")
    StackFront path
    File.AppendAllText(path, "@" + name + ".loop\n")
    File.AppendAllText(path, "D=D-1;JNE\n")
    File.AppendAllText(path, "(" + name + ".end)\n")

//pop pointer from address on one before LCL to the VM registers
let private PtrOnStkToReg regNum path = 
    File.AppendAllText(path, "@1\n")
    File.AppendAllText(path, "M=M-1\n")
    File.AppendAllText(path, "A=M\n")
    File.AppendAllText(path, "D=M\n")
    File.AppendAllText(path,"@" + regNum + "\n")
    File.AppendAllText(path, "M=D\n")


let ReturnFunc path = 
    //save the return address on RAM[13]
    File.AppendAllText(path, "@1\n")
    File.AppendAllText(path, "D=M\n")
    File.AppendAllText(path, "@5\n")
    File.AppendAllText(path, "A=D-A\n")
    File.AppendAllText(path, "D=M\n")
    File.AppendAllText(path, "@13\n")
    File.AppendAllText(path, "M=D\n")

    //ARG = pop the last
    File.AppendAllText(path, "@0\n")
    File.AppendAllText(path, "M=M-1\n")
    File.AppendAllText(path, "A=M\n")
    File.AppendAllText(path, "D=M\n")
    File.AppendAllText(path,"@2\n")
    File.AppendAllText(path, "A=M\n")
    File.AppendAllText(path, "M=D\n")

    //pointing SP in the new place
    File.AppendAllText(path, "@2\n")
    File.AppendAllText(path, "D=M\n")
    File.AppendAllText(path, "@0\n")
    File.AppendAllText(path, "M=D+1\n")

    PtrOnStkToReg "4" path
    PtrOnStkToReg "3" path
    PtrOnStkToReg "2" path
    PtrOnStkToReg "1" path

    //goto the return address in on reg 13
    File.AppendAllText(path, "@13\n")
    File.AppendAllText(path, "A=M\n")
    File.AppendAllText(path, "0;JMP\n")

let Bootstrap path = 
    File.AppendAllText(path, "@256\n")|>ignore
    File.AppendAllText(path, "D=A\n")|>ignore
    File.AppendAllText(path, "@0\n")|>ignore
    File.AppendAllText(path, "M=D\n")|>ignore
    GotoFunc "init" "Sys" path