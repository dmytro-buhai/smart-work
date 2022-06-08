using Microsoft.Extensions.Logging;
using SmartWork.BLL.Services.General;
using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.OfficeDTOs;
using SmartWork.Core.Entities;
using SmartWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartWork.BLL.Services
{
    public class OfficeService :
        GeneraEntityOperations<Office, AddOfficeDTO, UpdateOfficeDTO>,
        IOfficeService
    {
        private readonly IEntityRepository<Office> _officeRepository;
        private readonly IOfficeEntityConverter _entityConverter;
        private readonly ILogger<OfficeService> _logger;

        public OfficeService(IEntityRepository<Office> officeRepository,
             IOfficeEntityConverter entityConverter,
             ILogger<OfficeService> logger) :
             base(officeRepository, entityConverter, logger)
        {
            _officeRepository = officeRepository;
            _entityConverter = entityConverter;
            _logger = logger;
        }

        public async Task<List<InfoOfficeDTO>> GetOfficesWithCompanyAndRoomsAsync(PageInfo pageInfo)
        {
            var infoOfficeList = new List<InfoOfficeDTO>();
            try
            {
                const string CompanyIncludeName = "Company";
                const string RoomsIncludeName = "Rooms";

                var includeNames = new[] { CompanyIncludeName, RoomsIncludeName };
                var offices = await _officeRepository.GetWithTwoIncludesAsync(pageInfo, includeNames);

                foreach (var office in offices)
                {
                    infoOfficeList.Add(new InfoOfficeDTO
                    {
                        Id = office.Id,
                        CompanyId = office.CompanyId,
                        Name = office.Name,
                        Address = office.Address,
                        PhoneNumber = office.PhoneNumber,
                        PhotoFileName = office.PhotoFileName,
                        IsFavourite = office.IsFavourite,
                        Company = office.Company,
                        Rooms = office.Rooms
                    });
                }

                return infoOfficeList;

            }
            catch (Exception ex)
            {
                _logger.LogError($"error during getting '{typeof(Office).Name}' from db: {ex.Message}");
                return default;
            }
        }
    }
}
