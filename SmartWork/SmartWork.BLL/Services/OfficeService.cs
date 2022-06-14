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
using System.Linq.Expressions;
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

        public async Task<InfoOfficeDTO> FindOfficeWithCompanyAndRoomsAsync(int id)
        {
            try
            {
                const string CompanyIncludeName = "Company";
                const string RoomsIncludeName = "Rooms";

                var includeNames = new[] { CompanyIncludeName, RoomsIncludeName };
                var office = await _officeRepository.FindWithTwoIncludesAsync(id, includeNames);

                if(office == null)
                {
                    return default;
                }

                var officeInfo = new InfoOfficeDTO
                {
                    Id = office.Id,
                    CompanyId = office.CompanyId,
                    Name = office.Name,
                    Address = office.Address,
                    PhoneNumber = office.PhoneNumber,
                    PhotoFileName = office.PhotoFileName,
                    IsFavourite = office.IsFavourite,
                    Company = office.Company,
                    Rooms = office.Rooms,
                    Host = office.Host
                };
               
                return officeInfo;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during getting '{typeof(Office).Name}' from db: {ex.Message}");
                return default;
            }
        }

        public async Task<PagedList<Office>> GetOfficesWithCompanyAndRoomsAsync(OfficeParams param)
        {
            try
            {
                const string CompanyIncludeName = "Company";
                const string RoomsIncludeName = "Rooms";

                Expression<Func<Office, bool>> expression = null;

                
                if (param.IsFavourite)
                {
                    Expression<Func<Office, bool>> isFavouriteExpression = (o => o.IsFavourite == param.IsFavourite);
                    expression = isFavouriteExpression;
                } 
                else if (!string.IsNullOrEmpty(param.Host))
                {
                    Expression<Func<Office, bool>> isHostExpression = (o => o.Host == param.Host);
                    expression = isHostExpression;
                }
                
                var includeNames = new[] { CompanyIncludeName, RoomsIncludeName };

                var offices = await PagedList<Office>
                    .CreateAsync(_officeRepository, param.PageNumber, param.PageSize, 
                    includeNames, expression);

                return offices;

            }
            catch (Exception ex)
            {
                _logger.LogError($"error during getting '{typeof(Office).Name}' from db: {ex.Message}");
                return default;
            }
        }
    }
}
