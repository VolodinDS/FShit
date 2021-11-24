type Rule = char * char list
type Grammar = Rule list

let FindSubsb c (gr : Grammar) =
    match List.tryFind(fun (x, S) -> x = c) gr with
    | Some(x, S) -> S
    | None -> [c]

let Apply (gr : Grammar) L =
    List.collect(fun c -> FindSubsb c gr) L

let rec NApply n gr L = 
    if n > 0 then Apply gr (NApply (n-1) gr L)
    else L

let str s = [for c in s -> c]

[<EntryPoint>]
let main argv =
    let ruleStr = "F+F--F+F"
    let originString = "[-F-F-F]-F-"
    printf $"{originString}\n"
    let gr = [('F', str ruleStr)]
    let result = NApply 1 gr (str originString)
    for ch in result do printf $"{ch}"
    0 // return an integer exit code
