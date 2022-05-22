using Microsoft.Extensions.Logging;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Entities;

namespace SmartWork.BLL.Services.General
{
    public class GeneralRoomService : GeneralEntityService<Room>
    {
        private readonly IEntityRepository<Room> _repository;
        private readonly ILogger<GeneralRoomService> _logger;

        public GeneralRoomService(IEntityRepository<Room> repository,
            ILogger<GeneralRoomService> logger) : base(repository, logger)
        {
            _repository = repository;
            _logger = logger;
        }
    }
}
