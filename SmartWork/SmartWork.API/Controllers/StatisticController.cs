using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.StatisticDTOs;
using SmartWork.Core.Enums;
using SmartWork.Core.Models;
using SmartWork.Utils.ActionFilters;
using System.Threading.Tasks;

namespace SmartWork.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [AllowAnonymous]
        [HttpPost("Statistics/List")]
        public async Task<IActionResult> GetAsync(PageInfo pageInfo)
        {
            return new OkObjectResult(await _statisticService.GetAsync(pageInfo));
        }

        [HttpPost("[controller]/AddAttendanceStatisticInfo")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddAttendanceInfoAsync(AttendanceForDateDTO attendanceByDay)
        {
            var result = await _statisticService.AddAttendanceStatisticInfoAsync(attendanceByDay);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [HttpPost("[controller]/AddClimateStatisticInfo")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddClimateInfoAsync(ClimateForDateDTO climateByDay)
        {
            var result = await _statisticService.AddClimateStatisticInfoAsync(climateByDay);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [HttpPost("[controller]/AddLightingStatisticInfo")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddClimateInfoAsync(LightingForDateDTO lightingByDay)
        {
            var result = await _statisticService.AddLightingStatisticInfo(lightingByDay);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }
    }
}
