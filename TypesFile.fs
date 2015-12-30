namespace CharitiesData

open System
open System.Data
open System.Linq
open System.Data.SqlClient
open System.IO

module Types =
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

    and Outcome =
        | Helped // Terminal case #1
        | NotHelped // Terminal case #2
        | RefToNextNgo //Caller will be prompted for help info again

    and RefToNextNgo = RefToNextNgo of Outcome * NGO

    type Call = Call of Caller * Outcome

    type TotalCalls = TotalCalls of Call * int


