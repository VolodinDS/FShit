open System

let generateArray (length: int) =
    let rnd = new Random()
    [| for i in 1 .. length -> rnd.Next(10, 100) |]


let getMaxElementIndex (arr: int[]) =
    let maxElement = Array.min arr
    Array.IndexOf(arr, maxElement)

let getMinElementIndex (arr: int[]) =
    let minElement = Array.max arr
    Array.IndexOf(arr, minElement)

[<EntryPoint>]
let main argv =
    let rndArray = generateArray 10
    let minIndex = getMinElementIndex rndArray
    let maxIndex = getMaxElementIndex rndArray
    for i in 0 .. rndArray.Length - 1 do printf "%d " rndArray.[i]
    if minIndex < maxIndex
    then
        let arrSlice = rndArray.[minIndex .. maxIndex]
        if arrSlice.Length = 2
            then printf "Sum: 0"
        else
            let sum = Array.sum arrSlice
            printf "Sum: %d" sum
    else
        let arrSlice = rndArray.[maxIndex .. minIndex]
        if arrSlice.Length = 2
        then printf "Sum: 0"
        else
            let sum = Array.sum arrSlice
            printf "Sum: %d" sum
    0
