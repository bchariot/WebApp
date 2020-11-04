namespace WebApp.Controllers

open Microsoft.AspNetCore.Mvc
open System.IO

[<ApiController>]
[<Route("[controller]")>]
type VotesController () =
    inherit ControllerBase()

    [<HttpGet>]
    [<Route("/")>]
    member __.Get() =
        "no information for this page"

    [<HttpGet("{id}")>]
    [<Route("/{id}")>]
    member __.Get(id:string) =
        match id with
        | "worstcongress" -> File.ReadAllText(@"data\absent_congress.json")
        | "worstsenate" -> File.ReadAllText(@"data\absent_senate.json")
        | "bestcongress" -> File.ReadAllText(@"data\bravest_congress.json")
        | "bestsenate" -> File.ReadAllText(@"data\bravest_senate.json")
        | _ -> "not a proper vote page request"
