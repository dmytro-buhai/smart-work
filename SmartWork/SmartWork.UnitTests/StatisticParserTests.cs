using NUnit.Framework;
using SmartWork.BLL;
using SmartWork.Core.DTOs.StatisticDTOs;

namespace SmartWork.UnitTests
{
    public class StatisticParserTests
    {
        private readonly string _testData = "[{'Lumens':307,'StatisticId':52,'Date':'2022-06-12T00:00:00'},{'Lumens':317,'StatisticId':52,'Date':'2022-06-13T00:00:00'},{'Lumens':293,'StatisticId':52,'Date':'2022-06-14T00:00:00'},{'Lumens':304,'StatisticId':52,'Date':'2022-06-15T00:00:00'},{'Lumens':319,'StatisticId':52,'Date':'2022-06-16T00:00:00'},{'Lumens':325,'StatisticId':52,'Date':'2022-06-17T00:00:00'},{'Lumens':315,'StatisticId':52,'Date':'2022-06-18T00:00:00'},{'Lumens':316,'StatisticId':52,'Date':'2022-06-19T00:00:00'}]";

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ParseLightingStatisticData_ReturnsTrue()
        {
            var result = StatisticHandler.ParseDate<LightingForDateDTO>(_testData);

            if (result.Count == 0)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }

        [Test]
        public void ParseLightingStatisticDataWithInvalitString_ReturnsFalse()
        {
            var result = StatisticHandler.ParseDate<LightingForDateDTO>("");

            if (result == null)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }
    }
}
