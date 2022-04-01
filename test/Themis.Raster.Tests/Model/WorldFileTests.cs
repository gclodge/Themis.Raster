using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using Themis.Raster.Model;

using Bogus;
using Xunit;
using Assert = Xunit.Assert;

namespace Themis.Raster.Tests.Model
{
    public class WorldFileTests
    {
        const double MinValue = 0.0;
        const double MaxValue = 1000.0;

        readonly Faker _faker;
        readonly Faker<WorldFile> _wordFileFaker;

        public WorldFileTests()
        {
            _faker = new();
            _wordFileFaker = new Faker<WorldFile>()
                .RuleFor(f => f.Top, f => f.Random.Double(MinValue, MaxValue))
                .RuleFor(f => f.Left, f => f.Random.Double(MinValue, MaxValue))
                .RuleFor(f => f.PixelSize, f => f.Random.Double(MinValue));
        }

        [Fact]
        public void EqualsOtherWorldFile_Success_Test()
        {
            var target = _wordFileFaker.Generate();

            var input = new
            {
                value = target as object
            };

            Assert.True(target.Equals(input.value));
        }

        [Fact]
        public void EqualsOtherWorldFile_Fail_Test()
        {
            var A = _wordFileFaker.Generate();
            var B = _wordFileFaker.Generate();

            Assert.False(A.Equals(B));
        }

        [Fact]
        public void SetPixelSize_Test()
        {
            double expected = -1337.0; //< comedy.exe

            var actual = _wordFileFaker.Generate().SetPixelSize(expected);

            Assert.Equal(expected, actual.PixelSize);
        }

        [Fact]
        public void SetTopLeft_Test()
        {
            double expectedTop = _faker.Random.Double(double.MinValue, MinValue - 1E-3);
            double expectedLeft = _faker.Random.Double(double.MinValue, MinValue - 1E-3);

            var actual = _wordFileFaker.Generate().SetTopLeft(expectedTop, expectedLeft);

            Assert.Equal(expectedTop, actual.Top);
            Assert.Equal(expectedLeft, actual.Left);
        }

        [Fact]
        public void GenerateWorldFile_Test()
        {
            var expected = _wordFileFaker.Generate();

            var actual = WorldFile.Generate(expected.Top, expected.Left, expected.PixelSize);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GenerateWorldFile_FromIEnumerable_Test()
        {
            var expected = _wordFileFaker.Generate();
            var expectedPos = new double[] { expected.Left, expected.Top };

            var actual = WorldFile.Generate(expectedPos, expected.PixelSize);

            Assert.Equal(expected, actual);
        }
    }
}
