namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime RegistredOn { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}
