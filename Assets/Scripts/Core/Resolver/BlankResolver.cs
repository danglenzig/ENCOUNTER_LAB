using Dice;
using UnityEngine;

public sealed class BlankResolver : IResolver
{
    public TurnOutcome GetTurnOutcome(ResolverInput resolverInput)
    {
        TurnOutcome blankOutcome = new TurnOutcome();
        return blankOutcome;
    }
    public string SayHello()
    {
        return "Blank resolver says hello!";
    }
}
