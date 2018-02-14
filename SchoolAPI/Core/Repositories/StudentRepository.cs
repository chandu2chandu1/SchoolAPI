using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolAPI.Core.Domain;
using SchoolAPI.Models;
using System.Data.Entity;

namespace SchoolAPI.Core.Repositories
{
    public interface IStudentRepository :IRepository<Student> {

        IEnumerable<Student> GetAllBoys();
        IEnumerable<Student> GetAllGirls();
        IEnumerable<Student> GetStudentBySchool(School school);
    }

    public class StudentRepository:Repository<Student>, IStudentRepository
    {

        public StudentRepository(DbContext dbContext):base(dbContext) {
        }

        public IEnumerable<Student> GetAllBoys()
        {
            return GetAll();
        }

        public IEnumerable<Student> GetAllGirls()
        {
            return GetAll();
        }

        public IEnumerable<Student> GetStudentBySchool(School school)
        {
            return Context.Set<Student>().Where(student => student.School == school);
        }
    }
}