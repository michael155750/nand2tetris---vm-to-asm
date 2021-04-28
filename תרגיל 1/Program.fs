//Michael Bergshtein 305643033 group 47
//Netanel Zadok 304945835 group 42

open System
open System.IO


[<EntryPoint>]
let main argv =
    Console.WriteLine("Please enter the path:")
    let path = Console.ReadLine()
    let filesList = Directory.GetFiles(path,"*.vm")
     
    let path2 = path + "\\" + Path.GetFileNameWithoutExtension(path) + ".asm"
    
    if File.Exists(path2) then
        File.Delete(path2)
    
    if filesList.Length > 1 then
        Bootstrap path2
    for file in filesList do
        let fileLines = File.ReadLines(file)        
        let fileName = Path.GetFileNameWithoutExtension(file)
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
                PushFunc (line.Split(" ").[1]) (line.Split(" ").[2]|>int) (fileName) path2
            |"pop" ->
                PopFunc (line.Split(" ").[1]) (line.Split(" ").[2]|>int) (fileName) path2
            |"label" -> LabelFunc (line.Split(" ").[1]) (fileName) path2
            |"goto" -> GotoFunc (line.Split(" ").[1]) (fileName) path2
            |"if-goto" -> IfgotoFunc (line.Split(" ").[1]) (fileName) path2
            |"call" -> CallFunc (line.Split(" ").[1]) (line.Split(" ").[2]|>int) (fileName) path2
            |"function" ->
                FunctionFunc (line.Split(" ").[1]) (line.Split(" ").[2]|>int) (fileName) path2
            |"return" -> ReturnFunc path2
            |_ -> ()
            

    0 // return an integer exit code
