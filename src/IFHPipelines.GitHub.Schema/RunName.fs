namespace IFHPipelines.GitHub.Schema

open IFHPipelines.GitHub.Helpers

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
            else
                SingleLineString.create some
                |> StateResult.map
                    SingleLineStringError
                    SingleLineString