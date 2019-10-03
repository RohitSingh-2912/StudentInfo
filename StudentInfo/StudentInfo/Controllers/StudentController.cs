using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using StudentInfo.Models;
using StudentInfo.Services;

namespace StudentInfo.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentController(StudentService studentService)
        {
            StudentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
        }

        public StudentService StudentService { get; }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get([FromRoute]string id)
        {
            try
            {
                ObjectId.Parse(id);
                var student = StudentService.GetById(id);
                return Ok(student);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpPost]
        [Route("")]
        public ActionResult Create([FromBody] Student student)
        {
            try
            {
                return Ok(StudentService.Create(student));
            }
            catch(Exception ex)
            {
                return Forbid(ex.Message);
            }
        }
      
        [HttpPut("{id}")]
        public ActionResult Update(string id, Student StudentIn)
        {
            var student = StudentService.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            StudentService.Update(student);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var student = StudentService.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            StudentService.Remove(student.Id);

            return NoContent();
        }
    }
}
 