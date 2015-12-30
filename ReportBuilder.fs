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
     

    let rec caller_input() =
        printfn "What organization did you first contact for help?"
        let resp = Console.ReadLine().Trim().ToUpper()
        printfn "What was the outcome?\n"
        printfn "Did %s help/not help/refer you to another NGO?" resp
        let input = Console.ReadLine().Trim().ToLower()
        match input with
        | "help" -> Helped
        | "not helped" -> NotHelped 
        | "referred to another org" -> Outcome.RefToNextNgo
        | _ -> printfn "invalid entry"
               caller_input()

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

    and referral():RefToNextNgo =
        let n = caller_input()
        let f = followup()
        RefToNextNgo(n, f)







