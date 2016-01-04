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
                


//Unsure how to deconstruct the last line, it corresponds to
// the code in line 36 in ReportBuilder
let rec help(h:Outcome) =
    match h with
    | Helped -> printfn "Caller was helped"
    | NotHelped -> printfn "Caller was not helped"
    | RefToNextNgo (ngo, name) -> printfn " Caller not helped and referred to next NGO"
                              

(*
let total_callers(tc) acc i = 
    acc + i
*)
                  


[<EntryPoint>]
let main argv = 
    printfn "Welcome to my F# Program"

    let n name = (createNgo) 
                 
    let h = (help)
   
(*

    let js = JsonConvert.SerializeObject(whateverthefuck)
    let w = new StreamWriter("report.json", false)
    w.Write(js)

    let outcome = JsonConvert.DeserializeObject<Call>(js)
*)
    printfn "Type 'q' to quit"
    let user_input = Console.ReadKey()

    0 // return an integer exit code

