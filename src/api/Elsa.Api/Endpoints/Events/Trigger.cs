using Elsa.Api.ApiResults;
using Elsa.Contracts;
using Elsa.Modules.Activities.Activities.Primitives;
using Elsa.Runtime.Models;
using Microsoft.AspNetCore.Http;

namespace Elsa.Api.Endpoints.Events;

public static class Trigger
{
    public static IResult Handle(string eventName, IHasher hasher)
    {
        var hash = hasher.Hash(eventName);
        var stimulus = Stimulus.Standard(nameof(Event), hash);
        return new ProcessStimulusResult(stimulus);
    }
}