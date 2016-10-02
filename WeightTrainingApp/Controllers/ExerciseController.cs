using WeightTrainingApp.Dtos;
using WeightTrainingApp.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace WeightTrainingApp.Controllers
{
    [Authorize]
    [RoutePrefix("api/exercise")]
    public class ExerciseController : ApiController
    {
        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(ExerciseAddOrUpdateResponseDto))]
        public IHttpActionResult Add(ExerciseAddOrUpdateRequestDto dto) { return Ok(_exerciseService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(ExerciseAddOrUpdateResponseDto))]
        public IHttpActionResult Update(ExerciseAddOrUpdateRequestDto dto) { return Ok(_exerciseService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<ExerciseDto>))]
        public IHttpActionResult Get() { return Ok(_exerciseService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(ExerciseDto))]
        public IHttpActionResult GetById(int id) { return Ok(_exerciseService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_exerciseService.Remove(id)); }

        protected readonly IExerciseService _exerciseService;


    }
}
