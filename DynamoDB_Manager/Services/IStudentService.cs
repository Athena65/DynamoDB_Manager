using DynamoDB_Manager.Models;

namespace DynamoDB_Manager.Services
{
    public interface IStudentService
    {
        public Task<Student> GetStudentById(int id);
        public Task<List<Student>> GetAllStudents();
        public Task<Student> CreateStudent(Student studentRequest);
        public Task DeleteStudent(int id); 
        public Task<Student> UpdateStudent(Student student);
    }
}
