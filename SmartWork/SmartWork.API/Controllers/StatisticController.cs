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
            var statisticsList = await _statisticService.GetAsync(pageInfo);
            
            if (statisticsList != null)
            {
                return new OkObjectResult(statisticsList);
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [AllowAnonymous]
        [HttpPost("AttendanceStatistic/List")]
        public async Task<IActionResult> GetAttendanceStatisticAsync(PageInfo pageInfo)
        {
            var attendanceStatisticsList = await _statisticService.GetAttendanceStatisticAsync(pageInfo);

            if (attendanceStatisticsList != null)
            {
                return new OkObjectResult(attendanceStatisticsList);
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [AllowAnonymous]
        [HttpGet("AttendanceStatistic/List/{roomId}")]
        public async Task<IActionResult> GetAttendanceStatisticForRoomAsync(int roomId)
        {
            var attendanceStatisticsList = await _statisticService.GetAttendanceStatisticForRoomAsync(roomId);

            if (attendanceStatisticsList != null)
            {
                return new OkObjectResult(attendanceStatisticsList);
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [AllowAnonymous]
        [HttpGet("[controller]/FindById/{id}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            var statistic = await _statisticService.FindAsync(id);

            if (statistic != null)
            {
                return new OkObjectResult(statistic);
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [AllowAnonymous]
        [HttpGet("[controller]/GetByRoomId/{roomid}")]
        public async Task<IActionResult> GetByRoomIdAsync(int roomid)
        {
            var statistics = await _statisticService.GetByRoomIdAsync(roomid);

            if (statistics != null)
            {
                return new OkObjectResult(statistics);
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [AllowAnonymous]
        [HttpPost("[controller]/AddAttendanceStatisticFromFile")]
        public async Task<IActionResult> AddAttendanceStatisticFromFileAsync(string data)
        {
            var result = await _statisticService.AddAttendanceStatisticDataFromFile(data);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [AllowAnonymous]
        [HttpPost("[controller]/AddClimateStatisticFromFile")]
        public async Task<IActionResult> AddClimateStatisticFromFileAsync(string data)
        {
            var result = await _statisticService.AddClimateStatisticDataFromFile(data);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [AllowAnonymous]
        [HttpPost("[controller]/AddLightingStatisticDataFromFile")]
        public async Task<IActionResult> AddLightingStatisticDataFromFileAsync(string data)
        {
            var result = await _statisticService.AddLightingStatisticDataFromFile(data);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
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

        [AllowAnonymous]
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
