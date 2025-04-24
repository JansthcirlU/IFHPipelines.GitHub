namespace IFHPipelines.GitHub.Schema

open IFHPipelines.GitHub.Schema.Events

module Pipeline =
    type Pipeline = {
        Name: SingleLineString.SingleLineString
        RunName: RunName.RunName
        On: Event.Event list
    }