using Cwiczenie10.Services;
using DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Cwiczenie10.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private IStudentDbService _service;
        private IConfiguration Configuration;

        public EnrollmentsController(IStudentDbService service, IConfiguration configuration)
        {
            _service = service;
            Configuration = configuration;
        }


        [HttpPost("enrollStudent")]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            try
            {
                return Ok(_service.EnrollStudent(request));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("promotions")]
        // [Authorize(Roles = "Employee")]
        public IActionResult PromoteStudent(PromoteStudentRequest request)
        {
            try
            {
               
                return Created("https://www.pja.edu.pl/", _service.PromoteStudent(request.Semester, request.Studies));
            }
            catch (ArgumentException ex)
            {
                return NotFound("Nie znaleziono danego wpisu");
            }
        }

    }
}
