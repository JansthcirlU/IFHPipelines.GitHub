namespace IFHPipelines.GitHub.Schema

module SingleLineString =
    type SingleLineStringError =
        | ContainsNewline
        | ContainsCarriageReturn

    type SingleLineString = private String of string

    let create (s: string) =
        if s.Contains '\n' then Error ContainsNewline
        elif s.Contains '\r' then Error ContainsCarriageReturn
        else Ok (String s)