using System;
using NumericSequence.Web.Services;
using NUnit.Framework;
using Shouldly;

namespace NumericSequence.UnitTests.Services
{
    public class IntegerSequenceServiceTests
    {
        private IIntegerSequenceService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new IntegerSequenceService();
        }

        [Test]
        public void Should_throw_exception_when_upper_bound_is_negative()
        {
            Should.Throw<ArgumentException>(() => _service.GenerateSequence(-2));
        }

        [Test]
        public void Should_throw_exception_when_upper_bound_is_zero()
        {
            Should.Throw<ArgumentException>(() => _service.GenerateSequence(0));
        }

        [Test]
        public void Should_generate_valid_integer_sequence()
        {
            var sequence = _service.GenerateSequence(5);
            sequence.ShouldBe(new[] { 1, 2, 3, 4, 5 });
        }
    }
}