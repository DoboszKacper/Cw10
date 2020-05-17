using Cwiczenie10.Entities;
using DTOs.Requests;
using DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenie10.Services
{
    public interface IStudentDbService 
    {
        EnrollStudentResponse EnrollStudent(EnrollStudentRequest request);
        PromoteStudentResponse PromoteStudent(int semester, string studies);
    }
}
