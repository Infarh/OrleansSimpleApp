using Microsoft.Extensions.Logging;
using OrleansInterfaces;

namespace OrleansGrains;

public class HelloGrain(ILogger<HelloGrain> Logger) : Grain, IHello
{

    ValueTask<string> IHello.SayHello(string greeting)
    {
        Logger.LogInformation("""
                               SayHello message received: greeting = "{Greeting}"
                               """,
            greeting);

        return ValueTask.FromResult($"""

                                     Client said: "{greeting}", so HelloGrain says: Hello!
                                     """);
    }
}
