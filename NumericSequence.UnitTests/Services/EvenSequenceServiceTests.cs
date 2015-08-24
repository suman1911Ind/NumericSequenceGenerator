using System;
using NumericSequence.Web.Services;
using NUnit.Framework;
using Shouldly;

namespace NumericSequence.UnitTests.Services
{
    public class EvenSequenceServiceTests
    {
        private IEvenSequenceService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new EvenSequenceService();
        }

        [Test]
        public void Should_throw_exception_when_upper_bound_is_negative()
        {
            Should.Throw<ArgumentException>(() => _service.GenerateSequence(-89));
        }

        [Test]
        public void Should_throw_exception_when_upper_bound_is_zero()
        {
            Should.Throw<ArgumentException>(() => _service.GenerateSequence(0));
        }

        [Test]
        public void Should_generate_valid_even_sequence_when_upper_bound_is_even_number()
        {
            var sequence = _service.GenerateSequence(10);
            sequence.ShouldBe(new[] { 2, 4, 6, 8, 10 });
        }

        [Test]
        public void Should_generate_valid_even_sequence_when_upper_bound_is_not_even_number()
        {
            var sequence = _service.GenerateSequence(9);
            sequence.ShouldBe(new[] { 2, 4, 6, 8 });
        }
    }
}