using System;
using NumericSequence.Web.Services;
using NUnit.Framework;
using Shouldly;

namespace NumericSequence.UnitTests.Services
{
    public class OddSequenceServiceTests
    {
        private IOddSequenceService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new OddSequenceService();
        }

        [Test]
        public void Should_throw_exception_when_upper_bound_is_negative()
        {
            Should.Throw<ArgumentException>(() => _service.GenerateSequence(-14));
        }

        [Test]
        public void Should_throw_exception_when_upper_bound_is_zero()
        {
            Should.Throw<ArgumentException>(() => _service.GenerateSequence(0));
        }

        [Test]
        public void Should_generate_valid_odd_sequence_when_upper_bound_is_odd_number()
        {
            var sequence = _service.GenerateSequence(11);
            sequence.ShouldBe(new[] { 1, 3, 5, 7, 9, 11 });
        }

        [Test]
        public void Should_generate_valid_odd_sequence_when_upper_bound_is_not_odd_number()
        {
            var sequence = _service.GenerateSequence(14);
            sequence.ShouldBe(new[] { 1, 3, 5, 7, 9, 11, 13 });
        }
    }
}