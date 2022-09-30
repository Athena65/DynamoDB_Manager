using Amazon.DynamoDBv2.DataModel;
using DynamoDB_Manager.Models;

namespace DynamoDB_Manager.Services
{
    public class StudentService:IStudentService
    {
        private readonly IDynamoDBContext _context;

        public StudentService(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateStudent(Student studentRequest)
        {
            
            await _context.SaveAsync(studentRequest);
            return studentRequest;
        }

        public async Task DeleteStudent(int id)
        {
           var student= await _context.LoadAsync<Student>(id);
           await _context.DeleteAsync(student);
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.ScanAsync<Student>(default).GetRemainingAsync();
            
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student= await _context.LoadAsync<Student>(id);
            return student; 
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            await _context.SaveAsync(student);
            return student;
        }
    }
}
