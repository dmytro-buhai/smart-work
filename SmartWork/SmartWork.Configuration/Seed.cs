using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWork.Configuration
{
    public class Seed
    {
        private readonly IGeneralEntityService<Company> _companyService;
        private readonly IGeneralEntityService<Office> _officeService;
        private readonly IGeneralEntityService<Room> _roomServise;

        public Seed(IGeneralEntityService<Company> companyService,
                    IGeneralEntityService<Office> officeService,
                    IGeneralEntityService<Room> roomServise)
        {
            _companyService = companyService;
            _officeService = officeService;
            _roomServise = roomServise;
        }

        public async Task SeedData()
        {
            var isAnyCompanies = await _companyService.AnyAsync();

            if (!isAnyCompanies)
            {
                var company = new Company
                {
                    Name = "SmartWork company inc.",
                    Address = "SmartWork street, 64",
                    PhoneNumber = "0663248507",
                    Description = "SmartWork is the best company for you",
                    PhotoFileName = "default_company_photo_file_name"
                };               

                await _companyService.AddAsync(company);
            } 

            var isAnyOffices = await _officeService.AnyAsync();

            if (!isAnyOffices)
            {
                var office = new Office
                {
                    CompanyId = (await _companyService.GetAsync(c => c.Id != -1)).ToList().FirstOrDefault().Id,
                    Name = "SmartWork the best office",
                    Address = "SmartWork street, 61",
                    PhoneNumber = "0661234567",
                    PhotoFileName = "default_office_photo_file_name",
                    IsFavourite = false
                };

                await _officeService.AddAsync(office);
            }

            var isAnyRooms = await _roomServise.AnyAsync();

            if (!isAnyRooms)
            {
                var room = new Room
                {
                    OfficeId = (await _officeService.GetAsync(c => c.Id != -1)).ToList().FirstOrDefault().Id,
                    Name = "SmartWork the best room",
                    Number = "1a",
                    Square = 30,
                    PhotoFileName = "default_room_photo_file_name",
                };

                await _roomServise.AddAsync(room);
            }
        }
    }
}
