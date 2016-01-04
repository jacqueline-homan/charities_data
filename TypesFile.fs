namespace CharitiesData
module Types =

    open System
    open System.Data
    open System.Linq
    open System.Data.SqlClient
    open System.IO


    (* Not all charities are required by law to file IRS Form 990
       to publicly disclose their income/revenue
    *)
        type NGO =
            { OrgName : string
              EIN : int
              City : string
              State : string
              Funding : option<float> }

        type Followup =
            | CaseworkerFollowup
            | NoFollowup

        type Caller = 
            | Individual of string
            | Org of string

        type Outcome =
            | Helped // Terminal case #1
            | NotHelped // Terminal case #2
            | RefToNextNgo of Outcome * NGO //Caller will be prompted for help info again


        type Call = Call of Caller * Outcome

   

