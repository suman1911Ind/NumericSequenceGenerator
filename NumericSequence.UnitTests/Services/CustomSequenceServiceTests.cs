using System;
using NumericSequence.Web.Services;
using NUnit.Framework;
using Shouldly;

namespace NumericSequence.UnitTests.Services
{
    public class CustomSequenceServiceTests
    {
        private ICustomSequenceService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new CustomSequenceService();
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
        public void Should_generate_valid_custom_sequence()
        {
            var sequence = _service.GenerateSequence(15);
            sequence.ShouldBe(new object[] { 1, 2, 'C', 4, 'E', 'C', 7, 8, 'C', 'E', 11, 'C', 13, 14, 'Z' });
        } 
    }
}