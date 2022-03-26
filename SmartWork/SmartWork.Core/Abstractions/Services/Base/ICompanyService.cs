using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Entities;
using SmartWork.Core.ViewModels.Company;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services.Base
{
    public interface ICompanyService
    {
        Task<IActionResult> AddAsync(AddCompanyViewModel model);
        Task<IActionResult> AddAsync(IEnumerable<AddCompanyViewModel> models);
        Task<IActionResult> FindAsync(int id);
        Task<IActionResult> FindAsync(Func<Company, bool> expression);
        Task<IActionResult> GetAsync(Func<Company, bool> expression);
        Task<IActionResult> RemoveAsync(int id);
        Task<IActionResult> RemoveAsync(IEnumerable<int> identifiers);
        Task<IActionResult> UpdateAsync(UpdateCompanyViewModel model);
        Task<IActionResult> UpdateAsync(IEnumerable<UpdateCompanyViewModel> models);
    }
}
