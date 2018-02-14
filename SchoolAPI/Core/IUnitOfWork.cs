using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchoolAPI.Core.Repositories;
using System.Threading.Tasks;

namespace SchoolAPI.Core
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }
        ISchoolRepository Schools { get; }
        int Complete();
    }
}
