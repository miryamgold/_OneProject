using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IEmployeeDL
    {
        Task<List<EmployeeData>> GetEmployeeList();
        Task<bool> InsertDataToDB();
        Task<EmployeeData> GetEmployeeById(int id);
        Task<bool> UpdateEmployee(EmployeeData employee);
    }
}
