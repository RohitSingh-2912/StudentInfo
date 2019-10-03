using StudentInfo.Models;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;

namespace StudentInfo.Services
{
    public class StudentService
    {

        private readonly IMongoCollection<Student> _students;

        public StudentService(IStudentDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _students = database.GetCollection<Student>(settings.StudentsCollectionName);
        }

        public List<Student> GetAll()
        {
          return  _students.Find(s => true).ToList();
        }

        public Student GetById(string iid)
        {
           return _students.Find<Student>(s => s.IId == iid).FirstOrDefault();
        }

        public Student Create(Student student)
        {
            student.IId = ObjectId.GenerateNewId().ToString();
             _students.InsertOne(student);
            return student;
        }

        public void Update(Student student)
        {
            _students.ReplaceOne(s => s.IId == student.IId, student);
        }

       
        public void Remove(int id)
        {
            _students.DeleteOne(s => s.Id == id);
        }
    }
}
