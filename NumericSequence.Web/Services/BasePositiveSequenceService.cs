using System;
using System.Collections.Generic;

namespace NumericSequence.Web.Services
{
    public abstract class BasePositiveSequenceService<T> : ISequenceService<T>
    {
        public IEnumerable<T> GenerateSequence(int upperBound)
        {
            if (upperBound <= 0)
                throw new ArgumentException("The upper bound should be a positive integer value.", "upperBound");

            return SequenceAlgorithm(upperBound);
        }

        protected abstract IEnumerable<T> SequenceAlgorithm(int upperBound);
    }

    public interface ISequenceService<out T>
    {
        IEnumerable<T> GenerateSequence(int upperBound);
    }
}