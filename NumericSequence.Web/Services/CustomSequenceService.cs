using System.Collections.Generic;
using System.Linq;

namespace NumericSequence.Web.Services
{
    public class CustomSequenceService : BasePositiveSequenceService<object>, ICustomSequenceService
    {
        protected override IEnumerable<object> SequenceAlgorithm(int upperBound)
        {
            return Enumerable
                .Range(1, upperBound)
                .Select(n =>
                    {
                        if (n % 3 == 0 && n % 5 == 0)
                            return 'Z';

                        if (n % 3 == 0)
                            return 'C';

                        if (n % 5 == 0)
                            return 'E';

                        return (object)n;
                    })
                .ToList();
        }
    }

    public interface ICustomSequenceService : ISequenceService<object>
    {
    }
}