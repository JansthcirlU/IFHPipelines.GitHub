namespace IFHPipelines.GitHub.Schema.Events

module Event =
    /// <summary>See <see href="https://docs.github.com/en/actions/writing-workflows/choosing-when-your-workflow-runs/events-that-trigger-workflows">https://docs.github.com/en/actions/writing-workflows/choosing-when-your-workflow-runs/events-that-trigger-workflows</see>.</summary>
    type Event =
        | Push