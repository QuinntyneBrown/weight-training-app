using WeightTrainingApp.Dtos;
using WeightTrainingApp.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace WeightTrainingApp.Controllers
{
    [Authorize]
    [RoutePrefix("api/scheduledExercise")]
    public class ScheduledExerciseController : ApiController
    {
        public ScheduledExerciseController(IScheduledExerciseService scheduledExerciseService)
        {
            _scheduledExerciseService = scheduledExerciseService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(ScheduledExerciseAddOrUpdateResponseDto))]
        public IHttpActionResult Add(ScheduledExerciseAddOrUpdateRequestDto dto) { return Ok(_scheduledExerciseService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(ScheduledExerciseAddOrUpdateResponseDto))]
        public IHttpActionResult Update(ScheduledExerciseAddOrUpdateRequestDto dto) { return Ok(_scheduledExerciseService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<ScheduledExerciseDto>))]
        public IHttpActionResult Get() { return Ok(_scheduledExerciseService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(ScheduledExerciseDto))]
        public IHttpActionResult GetById(int id) { return Ok(_scheduledExerciseService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_scheduledExerciseService.Remove(id)); }

        protected readonly IScheduledExerciseService _scheduledExerciseService;


    }
}
