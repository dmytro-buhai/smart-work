using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.CompanyDTOs;
using SmartWork.Core.DTOs.OfficeDTOs;
using SmartWork.Core.DTOs.RoomDTOs;
using SmartWork.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWork.Configuration
{
    public class Seed
    {
        private readonly ICompanyService _companyService;
        private readonly IOfficeService _officeService;
        private readonly IRoomService _roomServise;

        public Seed(ICompanyService companyService,
                    IOfficeService officeService,
                    IRoomService roomServise)
        {
            _companyService = companyService;
            _officeService = officeService;
            _roomServise = roomServise;
        }

        public async Task SeedData()
        {
            var pageInfo = new PageInfo { CountItems = 1 };
            var isAnyCompanies = await _companyService.AnyAsync();

            if (!isAnyCompanies)
            {
                var addCompanyDTO = new AddCompanyDTO
                {
                    Name = "SmartWork company inc.",
                    Address = "SmartWork street, 64",
                    PhoneNumber = "0663248507",
                    Description = "SmartWork is the best company for you",
                    PhotoFileName = "default_company_photo_file_name"
                };               

                await _companyService.AddAsync(addCompanyDTO);
            } 

            var isAnyOffices = await _officeService.AnyAsync();

            if (!isAnyOffices)
            {
                var addOfficeDTO = new AddOfficeDTO
                {
                    CompanyId = (await _companyService.GetAsync(pageInfo)).FirstOrDefault().Id,
                    Name = "SmartWork the best office",
                    Address = "SmartWork street, 61",
                    PhoneNumber = "0661234567",
                    PhotoFileName = "default_office_photo_file_name",
                    IsFavourite = false
                };

                await _officeService.AddAsync(addOfficeDTO);
            }

            var isAnyRooms = await _roomServise.AnyAsync();

            if (!isAnyRooms)
            {
                var addRoomDTO = new AddRoomDTO
                {
                    OfficeId = (await _officeService.GetAsync(pageInfo)).FirstOrDefault().Id,
                    Name = "SmartWork the best room",
                    Number = "1a",
                    Square = 30,
                    PhotoFileName = "default_room_photo_file_name",
                };

                await _roomServise.AddAsync(addRoomDTO);
            }
        }
    }
}
