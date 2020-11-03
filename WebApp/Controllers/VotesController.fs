namespace WebApp.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open System.IO

[<ApiController>]
[<Route("[controller]")>]
type VotesController (logger : ILogger<VotesController>) =
    inherit ControllerBase()

    [<HttpGet>]
    member __.Get() =
        "no information for this page"

    [<HttpGet("{x}")>]
    member __.Get(x:string) =
        match x with
        | "worstcongress" -> File.ReadAllText(@"data\absent_congress.json")
        | "worstsenate" -> File.ReadAllText(@"data\absent_senate.json")
        | "bestcongress" -> File.ReadAllText(@"data\bravest_congress.json")
        | "bestsenate" -> File.ReadAllText(@"data\bravest_senate.json")
        | _ -> "not a proper vote page request"
