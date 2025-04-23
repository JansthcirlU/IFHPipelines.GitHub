namespace IFHPipelines.GitHub.Schema

module RunName =
    type RunNameError = SingleLineStringError of SingleLineString.SingleLineStringError

    type RunName =
        | Omitted
        | Whitespace
        | SingleLineString of SingleLineString.SingleLineString

    let create (s: string option) =
        match s with
        | None -> Ok Omitted
        | Some some ->
            if System.String.IsNullOrWhiteSpace some
            then Ok Whitespace
            else Error "TODO"