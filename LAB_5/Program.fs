open System
open System.IO
open System.Collections.Concurrent
open System.Collections.Generic
open System.Linq

let cleanString (str: string): string =
    str.Replace(",", System.String.Empty).Replace(".", System.String.Empty)

let getWordsFromString (str: string): List<string> =
    str.Split(' ', System.StringSplitOptions.RemoveEmptyEntries).ToList();

let getWordsFromFile (path: string): string[] =
    let words = new List<string>()
    let sr = new StreamReader(path)
    while (not sr.EndOfStream) do
        let stringWords = getWordsFromString(cleanString(sr.ReadLine()))
        words.AddRange(stringWords)
    sr.Close()
    words.ToArray()

let getWordsFromDirectory (path: string): List<string> =
    let files = Directory.GetFiles(path)
    let textFiles = Array.filter (fun (file: string) -> file.Contains(".txt")) files
    (Array.Parallel.collect getWordsFromFile textFiles).ToList()

let getWordLength(word: string): int =
    word.Length

let getLongestWord (words: List<string>) =
    let uniqueWords = Array.distinct(words.ToArray())
    let mapped = Array.map(fun word -> word, getWordLength(word)) uniqueWords
    Array.maxBy (fun (_, length) -> length) mapped

[<EntryPoint>]
let main argv =
    let words = getWordsFromDirectory("/Users/imachiavelli/Downloads/FILES")
    let longestWord = getLongestWord(words)
    match longestWord with
    | (word, length) -> printf $"{word}: {length}"
    0
