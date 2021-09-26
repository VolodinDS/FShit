// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open Functions
open HelpModule

let numberFactorial (number: int): int =
    let mutable numMutable: int = number
    let mutable factorial: int = 1
    while numMutable > 0 do
        factorial <- factorial * numMutable
        numMutable <- numMutable - 1
    factorial

let numberDigitsSum (number: int): int =
    let digits: char[] = number.ToString().ToCharArray()
    let mutable sum: int = 0
    for digit: char in digits do
        sum <- sum + Convert.ToInt32(Convert.ToString(digit))
    sum

[<EntryPoint>]
let main argv =
    printf "Type number >> "
    let testFactStr = Console.ReadLine();

    let inputNum: int = Convert.ToInt32(testFactStr)

    let mutable result: int = processNumber(inputNum, numberFactorial)
    printf $"Factorial: {result} {Environment.NewLine}";

    result <- processNumber(result, numberDigitsSum)
    printfn $"Digits sum: {result} {Environment.NewLine}"

    0
