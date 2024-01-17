using AutoMapper;
using DTO;
using Entities_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DL
{
    public class EmployeeDL : IEmployeeDL
    {
        private IMapper _mapper;
        private readonly HttpClient _httpClient;
        private project_oneContext _dbContext;

        public EmployeeDL(HttpClient httpClient, project_oneContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _dbContext = dbContext;

        }
        public async Task<List<EmployeeData>> GetEmployeeList()
        {
            try
            {
                var data = _dbContext.Employees.ToList();
                List<EmployeeData> employeeData = _mapper.Map<List<EmployeeData>>(data);
                return employeeData;

            }
            catch (HttpRequestException ex)
            {
                return null; 
            }
        }
        public async Task<EmployeeData> GetEmployeeById(int id)
        {
            try
            {
                var data = await _dbContext.Employees.Where(emp => emp.id == id ).FirstOrDefaultAsync();
                EmployeeData employeeData = _mapper.Map<EmployeeData>(data);
                return employeeData;

            }
            catch (HttpRequestException ex)
            {
                return null;
            }
        }
        public async Task<bool> UpdateEmployee(EmployeeData employee)
        {
            try
            {
                var existingEmployee = await _dbContext.Employees.FindAsync(employee.id);
                if (existingEmployee == null)
                {
                    return false;
                }
                existingEmployee.employee_name = employee.employee_name;
                existingEmployee.employee_salary = employee.employee_salary;
                existingEmployee.employee_age = employee.employee_age;
                existingEmployee.profile_image = employee.profile_image;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> InsertDataToDB()
        {
            string apiUrl = "https://dummy.restapiexample.com/api/v1/employees";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    string data = await response.Content.ReadAsStringAsync();
                    EmployeeDTO empListDto = JsonConvert.DeserializeObject<EmployeeDTO>(data);
                    List<Employees> empList = _mapper.Map<List<Employees>>(empListDto.data);
                    foreach (var emp in empList)
                    {
                        try
                        {
                            _dbContext.Employees.Add(emp);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error inserting data to the database: {ex.Message}");
                        }
                    }
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting data to the database: {ex.Message}");
                }
            }
            return true;
        }
    }
}
