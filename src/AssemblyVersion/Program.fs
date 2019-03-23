open System
open System.Reflection
open System.IO

let getVersion asm =
    let info = asm |> System.IO.FileInfo
    let version = Assembly.LoadFile(info.FullName).GetName().Version
    version.ToString()

[<EntryPoint>]
let main argv =
    let options = List.ofArray argv
    match options with
    | [ asm ] ->
        match File.Exists asm with
        | true ->
            printfn "%s" (getVersion asm)
            0
        | false ->
            printfn "0.0.0.0"
            -1
    | _ ->
        printfn "0.0.0.0"
        -1