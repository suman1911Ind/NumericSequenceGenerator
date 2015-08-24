using System.Collections.Generic;
using System.Linq;

namespace NumericSequence.Web.Services
{
    public class EvenSequenceService : BasePositiveSequenceService<int>, IEvenSequenceService
    {
        protected override IEnumerable<int> SequenceAlgorithm(int upperBound)
        {
            return Enumerable
                .Range(1, upperBound)
                .Where(n => n % 2 == 0);
        }
    }

    public interface IEvenSequenceService : ISequenceService<int>
    {
    }
}