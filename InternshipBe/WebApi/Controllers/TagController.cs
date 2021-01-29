using BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TagController : ControllerBase
    {
        public ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        [HttpGet("tags")]
        [Authorize]
        public IActionResult GetTags(int skip, int take)
        {
            return Ok(_tagService.GetSpecifiedTags(skip, take));
        }

    }
}
