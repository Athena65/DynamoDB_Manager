using DynamoDB_Manager.Models;
using DynamoDB_Manager.Services;
using Microsoft.AspNetCore.Mvc;

namespace DynamoDB_Manager.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var student = await _studentService.GetStudentById(id);
                return Ok(student); 

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message=ex.Message;
                return BadRequest(response);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _studentService.GetAllStudents());      

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student newStudent)
        {
            try
            {
                var student= await _studentService.CreateStudent(newStudent);    
                return Ok(student+" created!");

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _studentService.DeleteStudent(id);
                return Ok("Deleted!!");
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Student updatedStudent)
        {
            try
            {
                var student = await _studentService.UpdateStudent(updatedStudent);
                return Ok(student +" Updated!");
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        
    }
}
