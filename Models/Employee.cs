namespace CrudApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsDeleted { get; set;}
        public string FatherNames { get; set; }
        public int DepartmentId { get; set;}
        public string MotherName { get; set; }
    }
}
