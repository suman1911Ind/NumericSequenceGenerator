using System.Collections.Generic;
using System.Linq;

namespace NumericSequence.Web.Services
{
    public class IntegerSequenceService : BasePositiveSequenceService<int>, IIntegerSequenceService
    {
        protected override IEnumerable<int> SequenceAlgorithm(int upperBound)
        {
            return Enumerable.Range(1, upperBound);
        }
    }

    public interface IIntegerSequenceService : ISequenceService<int>
    {
    }
}