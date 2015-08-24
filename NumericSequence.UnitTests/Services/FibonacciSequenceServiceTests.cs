using System;
using NumericSequence.Web.Services;
using NUnit.Framework;
using Shouldly;

namespace NumericSequence.UnitTests.Services
{
    public class FibonacciSequenceServiceTests
    {
        private IFibonacciSequenceService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new FibonacciSequenceService();
        }

        [Test]
        public void Should_throw_exception_when_upper_bound_is_negative()
        {
            Should.Throw<ArgumentException>(() => _service.GenerateSequence(-1));
        }

        [Test]
        public void Should_throw_exception_when_upper_bound_is_zero()
        {
            Should.Throw<ArgumentException>(() => _service.GenerateSequence(0));
        }

        [Test]
        public void Should_generate_valid_fibonacci_sequence_when_upper_bound_is_fibonacci_number()
        {
            var sequence = _service.GenerateSequence(8);
            sequence.ShouldBe(new[] { 1, 1, 2, 3, 5, 8 });
        }

        [Test]
        public void Should_generate_valid_fibonacci_sequence_when_upper_bound_is_not_fibonacci_number()
        {
            var sequence = _service.GenerateSequence(30);
            sequence.ShouldBe(new[] { 1, 1, 2, 3, 5, 8, 13, 21 });
        }
    }
}