using CrudApi.Data;
using CrudApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            await _context.students!.AddAsync(student);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _context.students!.ToListAsync();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _context.students!.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                return BadRequest("Student not found");
            }
            return Ok(student);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            var existingstudent = await _context.students!.FirstOrDefaultAsync(x => x.Id == id);
            if (existingstudent == null)
            {
                return BadRequest("Student not found");
            }
            existingstudent.StudentName = student.StudentName;
            existingstudent.Address = student.Address;
            existingstudent.Standards = student.Standards;
            await _context.SaveChangesAsync();
            return Ok(existingstudent);
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.students!.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                return BadRequest("Student not found");
            }
            _context.students!.Remove(student);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}