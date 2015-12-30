open System
open System.Collections
open System.Data
open System.Linq
open System.Data.SqlClient
open System.IO
open CharitiesData.Types
open CharitiesData.ReportBuilder


[<EntryPoint>]
let main argv = 
    printfn "Welcome to my I-Haven't-Thought-of-a-Name-For-This-App-Yet Program" 
    printfn "Type 'exit' to quit"
    let user = Console.ReadLine().Trim().ToLower()
    0 // return an integer exit code

