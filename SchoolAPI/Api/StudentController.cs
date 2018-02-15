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
        public IHttpActionResult CreatedStudent(Student student)
        {
            if (student.School == null)
                student.School = _unitOfWork.Schools.GetAll().FirstOrDefault();

            //if (ModelState.IsValid)
            {
                _unitOfWork.Students.Add(student);
                _unitOfWork.Complete();
                return Created(Request.RequestUri.AbsoluteUri + "/" + student.Id, student);
            }

            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}