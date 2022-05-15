using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Entities;
using SmartWork.Core.ViewModels.Company;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services.Base
{
    public interface ICompanyService
    {
        Task<IActionResult> AddAsync(AddCompanyDTO model);
        Task<IActionResult> AddAsync(IEnumerable<AddCompanyDTO> models);
        Task<IActionResult> FindAsync(int id);
        Task<IActionResult> FindAsync(Expression<Func<Company, bool>> expression);
        Task<IActionResult> AnyAsync(Expression<Func<Company, bool>> expression = null);
        Task<IActionResult> GetAsync(Expression<Func<Company, bool>> expression);
        Task<IActionResult> RemoveAsync(Company company);
        Task<IActionResult> RemoveAsync(IEnumerable<Company> companies);
        Task<IActionResult> UpdateAsync(UpdateCompanyDTO model);
        Task<IActionResult> UpdateAsync(IEnumerable<UpdateCompanyDTO> models);
    }
}
