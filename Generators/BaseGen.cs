using System;
using System.Collections;
using System.Collections.Generic;

namespace Generators;

public abstract class BaseGen
{
    protected readonly List<double> Numbers;

    public AverageBehavior AverageBehavior { get; }

    public int N { get; }

    public BaseGen(string? name, int n, AverageBehavior averageBehavior)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        
        Name = new string(name);
        Numbers = new List<double>();
        AverageBehavior = averageBehavior;
        N = n;
    }

    public string Name { get; }

    public double PrevNumber
    {
        set
        {
            if (!Numbers.Any())
                throw new IndexOutOfRangeException("Previous number does not exist");

            Numbers[Numbers.Count() - 1] = value;
        }

        get
        {
            if (!Numbers.Any())
                throw new IndexOutOfRangeException("Previous number does not exist");

            return Numbers.Last();
        }
    }

    public double CalculateAverage()
    {
        double res = 0;

        if (Numbers.Count >= N)
            res = Numbers.TakeLast(N).Sum() / N;
        else
        {
            switch (AverageBehavior)
            {
                case AverageBehavior.ThrowException:
                    throw new InvalidOperationException("Количество чисел должно быть хотя бы N");
                case AverageBehavior.ReturnAverageOfAvailableNumbers:
                    res = Numbers.Sum() / N;
                    break;
                case AverageBehavior.ReturnNaN:
                    res = double.NaN;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        return res;

    }

    public abstract double GenerateNextNumber();

}