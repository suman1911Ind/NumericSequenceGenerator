using System.Collections.Generic;
using System.Linq;

namespace NumericSequence.Web.Services
{
    public class OddSequenceService : BasePositiveSequenceService<int>, IOddSequenceService
    {
        protected override IEnumerable<int> SequenceAlgorithm(int upperBound)
        {
            return Enumerable
                .Range(1, upperBound)
                .Where(n => n % 2 != 0);
        }
    }

    public interface IOddSequenceService : ISequenceService<int>
    {
    }
}