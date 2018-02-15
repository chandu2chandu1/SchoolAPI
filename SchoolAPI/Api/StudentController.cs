using SchoolAPI.Core;
using SchoolAPI.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAPI.Api
{
    public class StudentController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IEnumerable<Student> allStudents = _unitOfWork.Students.GetAll();
            if (allStudents != null && allStudents.Count() > 0)
                return Ok(allStudents);
            return Ok("No students found.. I am sorry!!");
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            Student student = _unitOfWork.Students.Get(id);
            if (student != null)
                return Ok(student);
            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
            responseMessage.ReasonPhrase = "No student found.";
            throw new HttpResponseException(responseMessage);
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult CreateStudent(Student student)
        {
            if (student.School == null)
                student.School = _unitOfWork.Schools.GetAll().FirstOrDefault();

            if (ModelState.IsValid)
            {
                _unitOfWork.Students.Add(student);
                _unitOfWork.Complete();
                return Created(Request.RequestUri.AbsoluteUri + "/" + student.Id, student);
            }

            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult UpdateStudent(int id, Student student)
        {
            if (id>0)
            {
                Student originalStudent = _unitOfWork.Students.Get(id);
                if(originalStudent != null)
                {
                    originalStudent.FirstName = student.FirstName;
                    originalStudent.LastName = student.LastName;
                    originalStudent.SurName = student.SurName;
                    originalStudent.School = _unitOfWork.Schools.Get(student.Id);
                    originalStudent.DateOfBirth = student.DateOfBirth;

                    _unitOfWork.Complete();
                    return Ok("Student information update.");
                }
            }

            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            responseMessage.ReasonPhrase = "The Student not found.  Please try again.";
            throw new HttpResponseException(responseMessage);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            if (id > 0)
            {
                var student = _unitOfWork.Students.Get(id);
                if(student != null)
                {
                    _unitOfWork.Students.Remove(student);
                    _unitOfWork.Complete();
                    return Ok("Student removed from the database.");
                }
            }

            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
            responseMessage.ReasonPhrase = "The student is not available or is already removed.";
            throw new HttpResponseException(responseMessage);
        }
    }
}