
using DL;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace BL
{
    public class EmployeeBL: IEmployeeBL
    {
        private IEmployeeDL _dal;
        public EmployeeBL(IEmployeeDL dal)
        {
            _dal = dal;
        }
        public async Task<List<EmployeeData>> GetEmployeeList()
        {
            return await _dal.GetEmployeeList();
        }
        public async Task<bool> InsertDataToDB()
        {
            return await _dal.InsertDataToDB();
        }
        public async Task<EmployeeData> GetEmployeeById(int id)
        {
            return await _dal.GetEmployeeById(id);
        }
        public async Task<bool> UpdateEmployee(EmployeeData employee)
        {
            return await _dal.UpdateEmployee(employee);
        }

    }
}