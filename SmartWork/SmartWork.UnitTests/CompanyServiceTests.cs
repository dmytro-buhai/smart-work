using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.DTOs.CompanyDTOs;
using SmartWork.Core.Entities;
using SmartWork.Utils.EntitiesUtils;
using System.Threading.Tasks;

namespace SmartWork.UnitTests
{
    public class CompanyServiceTests : BaseOperationTest<Company, AddCompanyDTO, UpdateCompanyDTO>
    {
        private GeneralEntityOperationsWrapper<Company, AddCompanyDTO, UpdateCompanyDTO> _generalCompanyOperationsWrapper;

        [SetUp]
        public void Setup()
        {
            TestEntityRepository = new Mock<IEntityRepository<Company>>();
            TestEntityConverter = new CompanyEntityConverter();
            TestLogger = new Mock<ILogger<GeneralEntityOperationsWrapper<Company, AddCompanyDTO, UpdateCompanyDTO>>>();
            _generalCompanyOperationsWrapper = new GeneralEntityOperationsWrapper<Company, AddCompanyDTO, UpdateCompanyDTO>(
                TestEntityRepository.Object, TestEntityConverter, TestLogger.Object);
        }

        [Test]
        public async Task AddNewCompanyWithValidParameters_ReturnsTrue()
        {
            var result = await _generalCompanyOperationsWrapper.AddAsync(new Mock<AddCompanyDTO>().Object);

            if (result != 0)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public async Task FindCompanyWithValidId_ReturnsTrue()
        {
            var result = await _generalCompanyOperationsWrapper.FindAsync(1);

            if (result != null)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public async Task UpdateCompany_ReturnsTrue()
        {
            var result = await _generalCompanyOperationsWrapper.UpdateAsync(new UpdateCompanyDTO());

            if (result)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }
    }
}
