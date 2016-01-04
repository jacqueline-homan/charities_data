namespace CharitiesData
module ReportBuilder =

    open System
    open System.IO
    open Types

    let rec caller category =
        printfn "Are you reporting as an inividual or an org?"
        let resp = Console.ReadLine().Trim().ToLower()
        match resp with
        | "individual" -> Individual
        | "org" -> Org
        | _ -> 
               printfn "Sorry, %s is an invalid entry.\n" resp
               printfn "Enter 'individual' or 'org': "
               caller category
     
    let createNgo name = 
        { OrgName = name;
          EIN = 0;
          City = "";
          State = "";
          Funding = None }

           
    let rec firstNgo_input() =
        printfn "What organization did you first contact for help?"
        let resp = Console.ReadLine().Trim().ToUpper()
        printfn "What was the outcome?\n"
        printfn "Did %s help/not help/refer you to another NGO?" resp
        let input = Console.ReadLine().Trim().ToLower()
        match input with
        | "help" -> Helped
        | "not helped" -> NotHelped 
        | "referred to another org" -> let ngo = createNgo " "
                                       RefToNextNgo(nextNgo_input(), ngo)
        | _ -> printfn "invalid entry: %A" input
               firstNgo_input()

    and nextNgo_input() =
        printfn " Which NGO were you referred to?"
        let res = Console.ReadLine().Trim().ToUpper()
        printfn "Did %s help, not help, or refer you to another NGO?" res
        let inp = Console.ReadLine().Trim().ToLower()
        match inp with
        | "help" -> Helped
        | "not help" -> NotHelped
        | "refer" -> let nextNgo = createNgo " "
                     RefToNextNgo(nextNgo_input(), nextNgo)
        | _ -> printfn "Invalid entry %A: Please enter 'help', not help', or 'refer': " inp
               nextNgo_input() 
                    

    let rec followup()=
        printfn "Did a caseworker follow up with you after\n"
        printfn "you were referred elsewhere for help?" 
        printfn "Enter 'Y' for Yes and 'N' for No:"
        let resp = Console.ReadLine().Trim().ToUpper()
        match resp with
        | "Y" -> CaseworkerFollowup
        | "N" -> NoFollowup
        | _ -> printfn "%s is an Invalid Entry" resp
               followup()

    









