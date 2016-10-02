using WeightTrainingApp.Dtos;
using WeightTrainingApp.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace WeightTrainingApp.Controllers
{
    [Authorize]
    [RoutePrefix("api/schedule")]
    public class ScheduleController : ApiController
    {
        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(ScheduleAddOrUpdateResponseDto))]
        public IHttpActionResult Add(ScheduleAddOrUpdateRequestDto dto) { return Ok(_scheduleService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(ScheduleAddOrUpdateResponseDto))]
        public IHttpActionResult Update(ScheduleAddOrUpdateRequestDto dto) { return Ok(_scheduleService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<ScheduleDto>))]
        public IHttpActionResult Get() { return Ok(_scheduleService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(ScheduleDto))]
        public IHttpActionResult GetById(int id) { return Ok(_scheduleService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_scheduleService.Remove(id)); }

        protected readonly IScheduleService _scheduleService;


    }
}
