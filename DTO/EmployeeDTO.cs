namespace DTO
{
    public class EmployeeDTO
    {
        public string status { get; set; }
        public string message { get; set; }
        public EmployeeData [] data { get; set; }
    }

    public class EmployeeData
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }
    }
}