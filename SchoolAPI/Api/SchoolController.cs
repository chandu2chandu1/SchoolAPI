using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolAPI.Core;
using SchoolAPI.Core.Domain;
using SchoolAPI.Core.Repositories;
using System.Web.Http.Cors;

namespace SchoolAPI.Api
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class SchoolController : ApiController
    {
        IUnitOfWork _unitOfWork;

        public SchoolController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IEnumerable<School> allStudents = _unitOfWork.Schools.GetAll();
            if (allStudents != null && allStudents.Count() > 0)
                return Ok(allStudents);
            return Ok("No schools found.. I am sorry!!");
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            School school = _unitOfWork.Schools.Get(id);
            if (school != null)
                return Ok(school);
            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
            responseMessage.ReasonPhrase = "No school found.";
            throw new HttpResponseException(responseMessage);
        }

        [HttpPut]
        public IHttpActionResult UpdateSchool(int id, School school)
        {
            if (id > 0)
            {
                School originalSchool = _unitOfWork.Schools.Get(id);
                if(originalSchool!= null)
                {
                    originalSchool.Schoolname = school.Schoolname;
                    originalSchool.Address = school.Address;
                    _unitOfWork.Complete();
                    return Ok("School updated successfully.");
                }
            }

            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
            responseMessage.ReasonPhrase = "No school found.";
            throw new HttpResponseException(responseMessage);
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult CreateStudent(School school)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Schools.Add(school);
                _unitOfWork.Complete();
                return Created(Request.RequestUri.AbsoluteUri + "/" + school.Id, school);
            }

            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        [HttpDelete]
        public IHttpActionResult DeleteSchool(int id)
        {
            if (id > 0)
            {
                School originalSchool = _unitOfWork.Schools.Get(id);
                if (originalSchool != null)
                {
                    _unitOfWork.Schools.Remove(originalSchool);
                    _unitOfWork.Complete();
                    return Ok("School removed succesfully..");
                }
            }

            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
            responseMessage.ReasonPhrase = "No school found.";
            throw new HttpResponseException(responseMessage);
        }

    }
}
