using Microsoft.Extensions.Logging;
using OrleansInterfaces;

namespace OrleansGrains;

public class HelloGrain(ILogger<HelloGrain> Logger) : Grain, IHello
{
    async ValueTask<string> IHello.SayHello(string greeting)
    {
        Logger.LogInformation("""
                               SayHello message received: greeting = "{Greeting}"
                               """,
            greeting);

        await Task.Delay(3000).ConfigureAwait(false);

        return $"""

                Client said: "{greeting}", so HelloGrain says: Hello!
                """;
    }
}
