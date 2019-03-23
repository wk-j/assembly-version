open System
open System.Reflection
open System.IO

let version asm =
    let info = asm |> System.IO.FileInfo
    let version = Assembly.LoadFile(info.FullName).GetName().Version
    version.ToString()

[<EntryPoint>]
let main argv =
    let options = List.ofArray argv
    match options with
    | [ asm ] ->
        if File.Exists asm then
            printfn "%s" (version asm)
        0
    | _ ->
        printfn "0.0.0.0"
        -1