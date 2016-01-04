open System
open System.Collections.Generic
open System.Data
open System.Linq
open System.Data.SqlClient
open System.IO
open CharitiesData.Types
open CharitiesData.ReportBuilder
open Newtonsoft.Json

 
let mutable ngos : NGO list = []

let mutable calls : Call list = []

let createNgo (n:NGO) =
    ngos
    |> List.sort
    |> List.ofSeq

let rec caller (c:Caller) =
    match c with
    | Individual(c) -> (calls) |> List.sort |> List.ofSeq
    | Org(c) -> (calls) |> List.sort |> List.ofSeq
                
                  
let result = firstNgo_input()
match result with
| Helped -> printfn "Caller was helped" |> exit 0
| NotHelped -> printfn "Caller was not helped" |> exit 0
| RefToNextNgo (ngo, name) -> printfn " Caller not helped and referred to next NGO"

let next_result = nextNgo_input()
match next_result with
| Helped -> printfn "helped" |> exit 0
| NotHelped -> printfn "not helped" |> exit 0
| RefToNextNgo (outcome, ngo) -> printfn "referred" 
                               

                    

[<EntryPoint>]
let main argv = 
    printfn "Welcome to my F# Program"

    let n name = (createNgo) 
                 

   
(*

    let js = JsonConvert.SerializeObject(whateverthefuck)
    let w = new StreamWriter("report.json", false)
    w.Write(js)

    let outcome = JsonConvert.DeserializeObject<Call>(js)
*)
    printfn "Type 'q' to quit"
    let user_input = Console.ReadKey()

    0 // return an integer exit code

