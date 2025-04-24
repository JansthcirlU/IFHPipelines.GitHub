namespace IFHPipelines.GitHub.Helpers

open System.Text

module String =
    let concatStrings (strings: string seq) =
        strings
        |> Seq.fold (fun (sb: StringBuilder) (s: string) -> sb.Append s) (new StringBuilder())
        |> fun sb -> sb.ToString()
    
    let concatChars (characters: char seq) =
        characters
        |> Seq.fold (fun (sb: StringBuilder) (c: char) -> sb.Append c) (new StringBuilder())
        |> fun sb -> sb.ToString()
    
    let splitOn (split: char) (accumulator: char seq -> string) (text: string) =
        text
        |> Seq.splitOn (fun c -> c = split)
        |> Seq.map accumulator
    
    let indent count (string: string) =
        seq {
            yield! Seq.replicate count "    "
            yield string
        }
        |> concatStrings