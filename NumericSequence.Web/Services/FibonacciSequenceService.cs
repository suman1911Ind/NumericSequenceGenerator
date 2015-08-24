using System.Collections.Generic;

namespace NumericSequence.Web.Services
{
    public class FibonacciSequenceService : BasePositiveSequenceService<int>, IFibonacciSequenceService
    {
        protected override IEnumerable<int> SequenceAlgorithm(int upperBound)
        {
            var sequence = new List<int> { 1 };

            var previous = 1;
            var current = 1;

            while (current <= upperBound)
            {
                sequence.Add(current);

                var currentCopy = current;
                current = previous + current;
                previous = currentCopy;
            }

            return sequence;
        }
    }

    public interface IFibonacciSequenceService : ISequenceService<int>
    {
    }
}