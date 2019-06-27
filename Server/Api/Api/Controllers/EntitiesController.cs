namespace Api.Controllers
{
    using System;
    using System.Linq;

    using BLL;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json.Linq;

    [Route("[controller]")]
    [ApiController]
    public class EntitiesController : BaseController
    {
        private readonly IEntitiesService _entitiesService;

        public EntitiesController(IEntitiesService entitiesService)
        {
            _entitiesService = entitiesService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var response = string.IsNullOrEmpty(query) ? _entitiesService.Get() : _entitiesService.Get(query);
            return Ok(response.Select(entity => JObject.Parse(entity.Value)));
        }

        [HttpGet("{id}", Name = GetEntityRouteName)]
        public IActionResult Get(Guid id)
        {
            var response = _entitiesService.FindById(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] JObject request)
        {
            if (ModelState.IsValid)
            {
                var entity = _entitiesService.Add(request.ToString());
                var link = Url.Link(GetEntityRouteName, new { id = entity.Id });
                return Created(link, entity.Value);
            }

            return BadRequest(ModelState);
        }
    }
}