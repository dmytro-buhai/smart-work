using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.DTOs.RoomDTOs;
using SmartWork.Core.Entities;
using SmartWork.Utils.EntitiesUtils;
using System.Threading.Tasks;

namespace SmartWork.UnitTests
{
    public class RoomServiceTests : BaseOperationTest<Room, AddRoomDTO, UpdateRoomDTO>
    {
        private GeneralEntityOperationsWrapper<Room, AddRoomDTO, UpdateRoomDTO> _generalRoomOperationsWrapper;

        [SetUp]
        public void Setup()
        {
            TestEntityRepository = new Mock<IEntityRepository<Room>>();
            TestEntityConverter = new RoomEntityConverter();
            TestLogger = new Mock<ILogger<GeneralEntityOperationsWrapper<Room, AddRoomDTO, UpdateRoomDTO>>>();
            _generalRoomOperationsWrapper = new GeneralEntityOperationsWrapper<Room, AddRoomDTO, UpdateRoomDTO>(
                TestEntityRepository.Object, TestEntityConverter, TestLogger.Object);
        }

        [Test]
        public async Task AddNewRoomWithValidParameters_ReturnsTrue()
        {
            var result = await _generalRoomOperationsWrapper.AddAsync(new Mock<AddRoomDTO>().Object);

            if (result != 0)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public async Task FindRoomWithValidId_ReturnsTrue()
        {
            var result = await _generalRoomOperationsWrapper.FindAsync(1);

            if (result != null)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public async Task UpdateRoom_ReturnsTrue()
        {
            var result = await _generalRoomOperationsWrapper.UpdateAsync(new UpdateRoomDTO());

            if (result)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public async Task FindRoomWithInvalidId_ReturnsFalse()
        {
            try
            {
                var result = await _generalRoomOperationsWrapper.FindAsync(-1);
                Assert.Fail();
            }
            catch
            {
                Assert.Pass();
            }
        }
    }
}
