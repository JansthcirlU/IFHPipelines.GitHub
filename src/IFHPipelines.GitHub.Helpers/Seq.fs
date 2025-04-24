namespace IFHPipelines.GitHub.Helpers

module Seq =
    let singleOrDefault<'a> (predicate: 'a -> bool) (source: 'a seq) =
        match
            source
            |> Seq.filter predicate
            |> Seq.truncate 2
            |> Seq.toList
        with
        | [ single ] -> Some single
        | _ -> None
    
    let append<'a> (element: 'a) (source: 'a seq) =
        seq {
            yield! source
            yield element
        }
    
    let replaceWhere<'a> (predicate: 'a -> bool) (replacement: 'a) (source: 'a seq) =
        source
        |> Seq.map (fun e -> if predicate e then replacement else e)
    
    let replace<'a when 'a: equality> (element: 'a) (replacement: 'a) (source: 'a seq) =
        source
        |> replaceWhere (fun e -> e = element) replacement
    
    let except<'a> (predicate: 'a -> bool) (source: 'a seq) =
        source
        |> Seq.filter (fun e -> not (predicate e))
    
    let splitOn (predicate: 'a -> bool) (source: 'a seq) =
        let nextChunk sequence =
            if Seq.isEmpty sequence then None
            else
                let chunk =
                    Seq.takeWhile predicate sequence
                    |> Seq.toArray
                let rest =
                    Seq.skip chunk.Length sequence
                    |> Seq.skipWhile (fun x -> not (predicate x))
                Some (chunk, rest)
        source
        |> Seq.unfold nextChunk