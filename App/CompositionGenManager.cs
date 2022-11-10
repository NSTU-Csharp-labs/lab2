using System;
using Generators;

namespace App;

public class CompositionGenManager
{
    private static CompositionGen? _compositionGen = null;

    public static CompositionGen Get()
    {
        if (_compositionGen is { }) return _compositionGen;

        throw new NullReferenceException(nameof(_compositionGen));
    }

    public static void Initialize(string? name, int n, AverageBehavior averageBehavior)
    {
        _compositionGen = new CompositionGen(name, n, averageBehavior);
    }
}