using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.Enums;
using SmartWork.Core.Models;
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

        [HttpPost("[controller]/AddAttendanceStatisticInfo/{statisticId}")]
        public async Task<IActionResult> AddAttendanceInfoAsync(int statisticId, AttendanceStatisticForDate attendanceStatistic)
        {
            var result = await _statisticService.AddAttendanceStatisticInfoAsync(statisticId, attendanceStatistic);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [HttpPost("[controller]/AddClimateStatisticInfo/{statisticId}")]
        public async Task<IActionResult> AddClimateInfoAsync(int statisticId, ClimateStatisticForDate climateStatistic)
        {
            var result = await _statisticService.AddClimateStatisticInfoAsync(statisticId, climateStatistic);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [HttpPost("[controller]/AddLightingStatisticInfo/{statisticId}")]
        public async Task<IActionResult> AddClimateInfoAsync(int statisticId, LightingStatisticForDate lightingStatistic)
        {
            var result = await _statisticService.AddLightingStatisticInfo(statisticId, lightingStatistic);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }
    }
}
