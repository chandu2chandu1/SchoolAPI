using SchoolAPI.Core;
using SchoolAPI.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAPI
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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