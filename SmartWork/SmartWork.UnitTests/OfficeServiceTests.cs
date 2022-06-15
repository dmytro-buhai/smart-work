using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.DTOs.OfficeDTOs;
using SmartWork.Core.Entities;
using SmartWork.Utils.EntitiesUtils;
using System.Threading.Tasks;

namespace SmartWork.UnitTests
{
    public class OfficeServiceTests : BaseOperationTest<Office, AddOfficeDTO, UpdateOfficeDTO>
    {
        private GeneralEntityOperationsWrapper<Office, AddOfficeDTO, UpdateOfficeDTO> _generalOfficesOperationsWrapper;

        [SetUp]
        public void Setup()
        {
            TestEntityRepository = new Mock<IEntityRepository<Office>>();
            TestEntityConverter = new OfficeEntityConverter();
            TestLogger = new Mock<ILogger<GeneralEntityOperationsWrapper<Office, AddOfficeDTO, UpdateOfficeDTO>>>();
            _generalOfficesOperationsWrapper = new GeneralEntityOperationsWrapper<Office, AddOfficeDTO, UpdateOfficeDTO>(
                TestEntityRepository.Object, TestEntityConverter, TestLogger.Object);
        }

        [Test]
        public async Task AddNewOfficeWithValidParameters_ReturnsTrue()
        {
            var result = await _generalOfficesOperationsWrapper.AddAsync(new Mock<AddOfficeDTO>().Object);

            if (result != 0)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public async Task FindOfficeWithValidId_ReturnsTrue()
        {
            var result = await _generalOfficesOperationsWrapper.FindAsync(1);

            if (result != null)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public async Task UpdateOffice_ReturnsTrue()
        {
            var result = await _generalOfficesOperationsWrapper.UpdateAsync(new UpdateOfficeDTO());

            if (result)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public async Task FindOfficeWithInvalidId_ReturnsFalse()
        {
            try
            {
                var result = await _generalOfficesOperationsWrapper.FindAsync(-1);
                Assert.Fail();
            } catch
            {
                Assert.Pass();
            }
        }
    }
}
