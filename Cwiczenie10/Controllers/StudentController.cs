using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenie10.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenie10.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;
        }

        [HttpGet("getStudents")]
        public IActionResult GetStudents()
        {
            var list = _context.Student.Select(x => new
            {
                Imie = x.FirstName,
                Nazwisko = x.LastName,
                Wpis = x.IdEnrollment
            }).ToList();
           
            
            return Ok(list);
        }

        [HttpPut("updateStudent")]
        public IActionResult UpdateStudent(Student s)
        {
            var student = (from c in _context.Student
                           where c.IndexNumber == s.IndexNumber
                           select c).First();

            if (student != null)
            {
                _context.Update<Student>(s);
                _context.SaveChanges();
                return Ok("Succesuflly Updated");
            }
            else
            {
                return BadRequest("Failed to Update");

            }
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {

            // Check if data was delivered corectly
            if (!ModelState.IsValid)
            {
                return BadRequest("Data not delivered");
            }


            if (student != null)
            {
                _context.Add<Student>(student);
                _context.SaveChanges();

                return Ok(student);

            }
            else

            {
                return BadRequest("bad request");
            }


        }

        [HttpDelete("deleteStudent{id}")]
        public IActionResult DeleteStudent(string id)
        {
            var index = id;
            var student = (from c in _context.Student
                           where c.IndexNumber == id
                           select c).First();

            if (student != null)
            {
                _context.Student.Remove(student);
                _context.SaveChanges();
                return Ok("Succesfully Deleted");
            }
            else
            {
                return BadRequest("Failed to Delete");

            }

        }
    }
}